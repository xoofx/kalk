using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkSymbol : KalkExpressionWithMembers, IScriptCustomFunction, IScriptCustomImplicitMultiplyPrecedence
    {
        private static readonly (string, Func<KalkExpressionWithMembers, object> getter)[] MemberDefs = {
            ("kind", unit => unit.Kind),
            ("name", unit => ((KalkSymbol)unit).Name),
            ("symbol", unit => ((KalkSymbol)unit).Symbol),
            ("description", unit => ((KalkSymbol)unit).Description),
            ("prefix", unit => ((KalkSymbol)unit).Prefix),
            ("value", unit => ((KalkSymbol)unit).Value),
        };

        public KalkSymbol(string name)
        {
            Name = name;
            Symbol = name;
            Derived = new List<KalkSymbol>();
        }

        public override string Kind => "symbol definition";

        public string Name { get; }

        public string Symbol { get; set; }

        public string Description { get; set; }

        public string Prefix { get; set; }

        public bool IsUser { get; set; }

        public KalkExpression Value { get; set; }

        public List<KalkSymbol> Derived { get; }

        public KalkSymbol Parent { get; set; }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            return Symbol;
        }

        protected override (string, Func<KalkExpressionWithMembers, object> getter)[] Members => MemberDefs;

        public override IScriptObject Clone(bool deep)
        {
            throw new NotSupportedException("Cloning a symbol is not supported");
        }

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
            engine.WriteHighlight(builder.ToString());

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