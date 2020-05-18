using System;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkBinaryExpression : KalkExpressionWithMembers
    {
        private static readonly (string, Func<KalkExpressionWithMembers, object> getter)[] MemberDefs = {
            ("kind", unit => unit.TypeName),
            ("value", unit => ((KalkBinaryExpression)unit).Value),
            ("operator", unit => ((KalkBinaryExpression)unit).OperatorText),
            ("unit", unit => ((KalkBinaryExpression)unit).Unit),
        };

        public KalkBinaryExpression()
        {
        }

        public KalkBinaryExpression(object value, ScriptBinaryOperator @operator, object unit)
        {
            Value = value;
            Operator = @operator;
            Unit = unit;
        }

        public override string TypeName => "binary expression";

        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the operator. Supported: /, *, ^
        /// </summary>
        public ScriptBinaryOperator Operator { get; set; }

        public string OperatorText => Operator.ToText();

        public object Unit { get; set; }

        public override object GetValue() => Value;

        public override KalkUnit GetUnit() => Unit as KalkUnit;

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            switch (Operator)
            {
                case ScriptBinaryOperator.Power:
                    return (Value is ScriptBinaryExpression) ? $"({string.Format(formatProvider, "{0}",Value)}){OperatorText}{string.Format(formatProvider, "{0}", Unit)}" : $"{string.Format(formatProvider, "{0}", Value)}{OperatorText}{string.Format(formatProvider, "{0}", Unit)}";
                default:
                    return $"{string.Format(formatProvider, "{0}", Value)} {OperatorText} {string.Format(formatProvider, "{0}", Unit)}";
            }
        }

        protected override (string, Func<KalkExpressionWithMembers, object> getter)[] Members => MemberDefs;

        protected override bool EqualsImpl(TemplateContext context, KalkExpression other)
        {
            var otherBin = (KalkBinaryExpression) other;
            if (Operator != otherBin.Operator) return false;

            if (Value is KalkExpression && otherBin.Value.GetType() != Value.GetType()) return false;
            if (Unit is KalkExpression && otherBin.Unit.GetType() != Unit.GetType()) return false;

            if (Value is KalkExpression leftExpr)
            {
                if (!Equals(context, leftExpr, (KalkExpression) otherBin.Value))
                {
                    return false;
                }
            }
            else
            {
                var leftValue = context.ToObject<double>(context.CurrentSpan, Value);
                var otherLeftValue = context.ToObject<double>(context.CurrentSpan, otherBin.Value);
                if (!KalkValue.AlmostEqual(leftValue, otherLeftValue))
                {
                    return false;
                }
            }

            if (Unit is KalkExpression rightExpr)
            {
                if (!Equals(context, rightExpr, (KalkExpression)otherBin.Unit))
                {
                    return false;
                }
            }
            else
            {
                var rightValue = context.ToObject<double>(context.CurrentSpan, Unit);
                var otherRightValue = context.ToObject<double>(context.CurrentSpan, otherBin.Unit);
                if (!KalkValue.AlmostEqual(rightValue, otherRightValue))
                {
                    return false;
                }
            }

            return true;
        }
    }
}