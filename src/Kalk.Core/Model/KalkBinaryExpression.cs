using System;
using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkBinaryExpression : KalkExpressionWithMembers
    {
        private static readonly (string, Func<KalkExpressionWithMembers, object> getter)[] MemberDefs = {
            ("kind", unit => unit.Kind),
            ("left", unit => ((KalkBinaryExpression)unit).Left),
            ("operator", unit => ((KalkBinaryExpression)unit).OperatorText),
            ("right", unit => ((KalkBinaryExpression)unit).Right),
        };

        public KalkBinaryExpression()
        {
        }

        public KalkBinaryExpression(object left, ScriptBinaryOperator @operator, object right)
        {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public override string Kind => "binary expression";

        public object Left { get; set; }

        /// <summary>
        /// Gets or sets the operator. Supported: /, *, ^
        /// </summary>
        public ScriptBinaryOperator Operator { get; set; }

        public string OperatorText => Operator.ToText();

        public object Right { get; set; }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            switch (Operator)
            {
                case ScriptBinaryOperator.Power:
                    return (Left is ScriptBinaryExpression) ? $"({string.Format(formatProvider, "{0}",Left)}){OperatorText}{string.Format(formatProvider, "{0}", Right)}" : $"{string.Format(formatProvider, "{0}", Left)}{OperatorText}{string.Format(formatProvider, "{0}", Right)}";
                default:
                    return $"{string.Format(formatProvider, "{0}", Left)} {OperatorText} {string.Format(formatProvider, "{0}", Right)}";
            }
        }

        protected override (string, Func<KalkExpressionWithMembers, object> getter)[] Members => MemberDefs;

        public override IScriptObject Clone(bool deep)
        {
            var operationUnity = new KalkBinaryExpression()
            {
                Left = Left,
                Operator = Operator,
                Right = Right,
            };
            if (deep)
            {
                if (Left is KalkExpression leftUnit)
                {
                    operationUnity.Left = leftUnit.Clone(deep);
                }
                if (Right is KalkExpression rightUnit )
                {
                    operationUnity.Right = rightUnit.Clone(deep);
                }
            }

            return operationUnity;
        }

        protected override bool EqualsImpl(TemplateContext context, KalkExpression other)
        {
            var otherBin = (KalkBinaryExpression) other;
            if (Operator != otherBin.Operator) return false;

            if (Left is KalkExpression && otherBin.Left.GetType() != Left.GetType()) return false;
            if (Right is KalkExpression && otherBin.Right.GetType() != Right.GetType()) return false;

            if (Left is KalkExpression leftExpr)
            {
                if (!Equals(context, leftExpr, (KalkExpression) otherBin.Left))
                {
                    return false;
                }
            }
            else
            {
                var leftValue = context.ToObject<double>(context.CurrentSpan, Left);
                var otherLeftValue = context.ToObject<double>(context.CurrentSpan, otherBin.Left);
                if (!KalkNumber.AlmostEqual(leftValue, otherLeftValue))
                {
                    return false;
                }
            }

            if (Right is KalkExpression rightExpr)
            {
                if (!Equals(context, rightExpr, (KalkExpression)otherBin.Right))
                {
                    return false;
                }
            }
            else
            {
                var rightValue = context.ToObject<double>(context.CurrentSpan, Right);
                var otherRightValue = context.ToObject<double>(context.CurrentSpan, otherBin.Right);
                if (!KalkNumber.AlmostEqual(rightValue, otherRightValue))
                {
                    return false;
                }
            }

            return true;
        }
    }
}