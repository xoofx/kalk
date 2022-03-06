using System;
using System.Globalization;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Complex;
using Scriban;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{


    public abstract class KalkExpression : KalkObject, IScriptCustomBinaryOperation, IScriptCustomUnaryOperation, IFormattable, IScriptTransformable
    {
        protected KalkExpression()
        {
            OriginalExpression = this;
        }

        public abstract object GetValue();

        public abstract KalkUnit GetUnit();


        public override string ToString()
        {
            return ToString(null, CultureInfo.CurrentCulture);
        }
        
        public abstract string ToString(string format, IFormatProvider formatProvider);

        public static bool Equals(TemplateContext context, KalkExpression  left, KalkExpression right)
        {
            if (ReferenceEquals(null, right)) return false;
            if (ReferenceEquals(left, right)) return true;
            return right.GetType() == left.GetType() && left.EqualsImpl(context, right);
        }

        public KalkExpression OriginalExpression { get; set; }

        public sealed override IScriptObject Clone(bool deep)
        {
            throw new NotSupportedException("This expression cannot be cloned.");
        }

        protected abstract bool EqualsImpl(TemplateContext context, KalkExpression right);

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            var leftExpr = leftValue as KalkExpression;
            if (leftExpr is null && !KalkValue.IsNumber(leftValue))
            {
                throw new ScriptRuntimeException(leftSpan, "Expecting a number, vector or matrix");
            }
            var rightExpr = rightValue as KalkExpression;
            if (rightExpr is null && !KalkValue.IsNumber(rightValue))
            {
                throw new ScriptRuntimeException(rightSpan, "Expecting a number, vector or matrix");
            }

            result = null;
            switch (op)
            {
                case ScriptBinaryOperator.CompareEqual:
                case ScriptBinaryOperator.CompareNotEqual:
                case ScriptBinaryOperator.CompareLessOrEqual:
                case ScriptBinaryOperator.CompareGreaterOrEqual:
                case ScriptBinaryOperator.CompareLess:
                case ScriptBinaryOperator.CompareGreater:
                    if (leftExpr != null && rightExpr != null)
                    {
                        var leftSimplifier = new KalkExpressionSimplifier(context);
                        var (leftValueMultiplier, newLeftExpr) = leftSimplifier.Canonical(leftExpr);

                        var rightSimplifier = new KalkExpressionSimplifier(context);
                        var (rightValueMultiplier, newRightExpr) = rightSimplifier.Canonical(rightExpr);

                        var exprEquals = Equals(context, newLeftExpr, newRightExpr);
                        if (exprEquals)
                        {
                            var almostEqual = KalkValue.AlmostEqual(leftValueMultiplier, rightValueMultiplier);
                            switch (op)
                            {
                                case ScriptBinaryOperator.CompareEqual:
                                    result = almostEqual;
                                    break;
                                case ScriptBinaryOperator.CompareNotEqual:
                                    result = !almostEqual;
                                    break;
                                case ScriptBinaryOperator.CompareLessOrEqual:
                                    result = almostEqual || ScriptBinaryExpression.Evaluate(context, span, op, leftSpan, leftValueMultiplier, rightSpan, rightValueMultiplier) is bool v1 && v1;
                                    break;
                                case ScriptBinaryOperator.CompareGreaterOrEqual:
                                    result = almostEqual || ScriptBinaryExpression.Evaluate(context, span, op, leftSpan, leftValueMultiplier, rightSpan, rightValueMultiplier) is bool v2 && v2;
                                    break;
                                case ScriptBinaryOperator.CompareLess:
                                    result = ScriptBinaryExpression.Evaluate(context, span, op, leftSpan, leftValueMultiplier, rightSpan, rightValueMultiplier) is bool v3 && v3;
                                    break;
                                case ScriptBinaryOperator.CompareGreater:
                                    result = ScriptBinaryExpression.Evaluate(context, span, op, leftSpan, leftValueMultiplier, rightSpan, rightValueMultiplier) is bool v4 && v4;
                                    break;
                            }
                        }
                        else
                        {
                            result = op == ScriptBinaryOperator.CompareNotEqual;
                        }
                    }
                    else
                    {
                        if (op == ScriptBinaryOperator.CompareEqual || op == ScriptBinaryOperator.CompareNotEqual)
                        {
                            result = op == ScriptBinaryOperator.CompareNotEqual;
                        }
                        else
                        {
                            throw NotMatching(leftSpan, leftExpr, rightSpan, rightExpr);
                        }
                    }
                    return true;

                case ScriptBinaryOperator.Multiply:
                case ScriptBinaryOperator.Divide:
                case ScriptBinaryOperator.Power:
                {
                    if (op != ScriptBinaryOperator.Power || rightExpr == null)
                    {
                        var simplifier = new KalkExpressionSimplifier(context);
                        var (valueMul, valueExpr) = simplifier.Canonical(new KalkBinaryExpression(leftValue, op, rightValue));
                        var valueBinExpr = valueExpr as KalkBinaryExpression;

                        result = KalkValue.AlmostEqual(valueMul, 1.0) && valueBinExpr == null ? valueExpr ?? (object)1.0 : valueExpr == null ? valueMul : (object)new KalkBinaryExpression(valueMul, ScriptBinaryOperator.Multiply, valueExpr)
                        {
                            OriginalExpression = new KalkBinaryExpression(leftValue, op, rightValue)
                        };
                        return true;
                    }
                    else
                    {
                        throw new ScriptRuntimeException(rightSpan, "Cannot use a unit as an exponent.");
                    }
                }

                case ScriptBinaryOperator.Add:
                case ScriptBinaryOperator.Subtract:

                    if (leftExpr != null && rightExpr != null)
                    {
                        var leftSimplifier = new KalkExpressionSimplifier(context);
                        var (leftValueMultiplier, newLeftExpr) = leftSimplifier.Canonical(leftExpr);
                        
                        var rightSimplifier = new KalkExpressionSimplifier(context);
                        var (rightValueMultiplier, newRightExpr) = rightSimplifier.Canonical(rightExpr);

                        if (!Equals(context, newLeftExpr, newRightExpr))
                        {
                            throw new ScriptRuntimeException(span, $"Cannot {(op == ScriptBinaryOperator.Add ? "add" : "subtract")} the expression. Units are not matching. The left expression with unit `{newLeftExpr}` is not matching the right expression with unit `{newRightExpr}`.");
                        }

                        result = new KalkBinaryExpression(ScriptBinaryExpression.Evaluate(context, span, op, leftSpan, leftValueMultiplier, rightSpan, rightValueMultiplier), ScriptBinaryOperator.Multiply, newLeftExpr)
                        {
                            OriginalExpression = new KalkBinaryExpression(leftValue, op, rightValue)
                        };
                    }
                    else
                    {
                        throw NotMatching(leftSpan, leftExpr, rightSpan, rightExpr);
                    }

                    return true;
            }

            return false;
        }


        private static ScriptRuntimeException NotMatching(SourceSpan leftSpan, KalkExpression leftExpr, SourceSpan rightSpan, KalkExpression rightExpr)
        {
            return new ScriptRuntimeException(leftExpr == null ? leftSpan : rightSpan, $"Missing unit for the {(leftExpr == null ? "left" : "right")} expression. It must match the unit of the other expression `{leftExpr ?? rightExpr}`.");
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            result = null;
            return false;
        }

        public KalkExpression ConvertTo(TemplateContext context, KalkExpression dst)
        {
            var src = this;

            var destExpr = dst.OriginalExpression ?? dst;

            var span = context.CurrentSpan;
            if (!this.TryEvaluate(context, span, ScriptBinaryOperator.Divide, span, this, span, dst, out var result) || result is KalkExpression)
            {
                throw new ScriptRuntimeException(context.CurrentSpan, $"Cannot convert the expression {src} to the unit `{destExpr}`. Units are not matching.");
            }

            var value = context.ToObject<double>(span, result);
            return new KalkBinaryExpression(value, ScriptBinaryOperator.Multiply, dst.OriginalExpression);
        }

        public Type ElementType => typeof(double);

        public bool CanTransform(Type transformType)
        {
            return transformType == typeof(double) || transformType == typeof(float);
        }
        
        public bool Visit(TemplateContext context, SourceSpan span, Func<object, bool> visit)
        {
            return visit(GetValue());
        }
        
        public object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply, Type destType)
        {
            return apply(GetValue());
        }

    }
}