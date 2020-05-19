using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkUnit : KalkExpressionWithMembers, IScriptCustomFunction, IScriptCustomImplicitMultiplyPrecedence
    {
        private static readonly (string, Func<KalkExpressionWithMembers, object> getter)[] MemberDefs = {
            ("kind", unit => unit.TypeName),
            ("name", unit => ((KalkUnit)unit).Name),
            ("symbol", unit => ((KalkUnit)unit).Symbol),
            ("description", unit => ((KalkUnit)unit).Description),
            ("prefix", unit => ((KalkUnit)unit).Prefix),
            ("plural", unit => ((KalkUnit)unit).Plural),
            ("value", unit => ((KalkUnit)unit).Value),
        };

        public KalkUnit(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Symbol = name;
            Plural = name + "s";
            Derived = new List<KalkUnit>();
        }

        public override string TypeName => "symbol definition";

        public string Name { get; }

        public string Symbol { get; set; }

        public string Description { get; set; }

        public string Prefix { get; set; }

        public bool IsUser { get; set; }

        public string Plural { get; set; }

        public KalkExpression Value { get; set; }

        public List<KalkUnit> Derived { get; }

        public KalkUnit Parent { get; set; }

        public override object GetValue() => 1.0;

        public override KalkUnit GetUnit() => this;

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            return Symbol;
        }

        protected override (string, Func<KalkExpressionWithMembers, object> getter)[] Members => MemberDefs;

        protected override bool EqualsImpl(TemplateContext context, KalkExpression right)
        {
            // If we reach here, that means that the symbols are necessarily not equal
            return false;
        }

        public int RequiredParameterCount => 0;

        public int ParameterCount => 0;

        public bool HasVariableParams => false;

        public Type ReturnType => typeof(object);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            throw new NotSupportedException("A Unit symbol does not support arguments.");
        }

        public virtual object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (!(callerContext.Parent is ScriptExpressionStatement))
            {
                return this;
            }

            var engine = (KalkEngine) context;
            var builder = new StringBuilder();
            builder.Length = 0;
            builder.Append($"unit({Name}, \"{Description.Replace("\"", @"\""")}\", {Symbol}");
            if (Value != null)
            {
                builder.Append($", {Value.OriginalExpression ?? Value}");
            }
            if (Prefix != null)
            {
                builder.Append($", prefix: \"{Prefix}\"");
            }

            builder.Append(")");
            engine.WriteHighlightLine(builder.ToString());

            if (Derived.Count > 0)
            {
                builder.Length = 0;
                for (var i = 0; i < Derived.Count; i++)
                {
                    var derived = Derived[i];
                    if (i > 0) builder.Append(", ");
                    builder.Append($"{derived.Name}/{derived.Symbol}");
                }

                engine.WriteHighlightAligned("  - ", builder.ToString());
            }

            return null;
        }

        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            return new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
        }
    }
}