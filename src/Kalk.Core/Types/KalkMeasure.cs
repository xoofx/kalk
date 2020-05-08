using System;
using System.Globalization;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;

namespace Kalk.Core
{
    public class KalkMeasure : KalkReadOnlyObject, IFormattable, IScriptTransformable
    {
        private static readonly (string, Func<KalkReadOnlyObject, object> getter)[] MemberDefs = {
            ("kind", unit => unit.Kind),
            ("value", unit => ((KalkMeasure)unit).Value),
            ("unit", unit => ((KalkMeasure)unit).Unit),
        };

        public KalkMeasure(object value, KalkUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public override string Kind => "measure";

        public object Value { get; }

        public KalkUnit Unit { get; }

        protected override (string, Func<KalkReadOnlyObject, object> getter)[] Members => MemberDefs;

        public override IScriptObject Clone(bool deep)
        {
            return new KalkMeasure(Value, (KalkUnit) Unit.Clone(deep));
        }

        public override string ToString()
        {
            return ToString(null, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, "{0} {1}", Value, Unit);
        }

        public Type ElementType => typeof(object);

        public bool CanTransform(Type transformType)
        {
            return true;
        }

        public object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply)
        {
            return new KalkMeasure(apply(Value), Unit);
        }
    }
}