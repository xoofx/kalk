using System;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public abstract class KalkUnit : KalkReadOnlyObject, IScriptCustomBinaryOperation, IScriptCustomUnaryOperation
    {
        protected KalkUnit()
        {
        }
        
        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            result = null;
            return false;
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            result = null;
            return false;
        }
    }

    // s	second	time
    // m	meter	length
    // kg	kilogram	mass
    // A	ampere	electric current
    // K	kelvin	thermodynamic temperature
    // mol	mole	amount of substance
    // cd	candela	luminous intensity
    public class KalkOperationUnit : KalkUnit
    {
        private static readonly (string, Func<KalkReadOnlyObject, object> getter)[] MemberDefs = {
            ("kind", unit => unit.Kind),
            ("left", unit => ((KalkOperationUnit)unit).Left),
            ("operator", unit => ((KalkOperationUnit)unit).Operator),
            ("right", unit => ((KalkOperationUnit)unit).Right),
        };

        public KalkOperationUnit()
        {
        }
        
        public override string Kind => "unit operation";

        public object Left { get; set; }

        /// <summary>
        /// Gets or sets the operator. Supported: /, *, ^
        /// </summary>
        public string Operator { get; set; }

        public object Right { get; set; }

        public override string ToString()
        {
            return $"{Left}{Operator}{Right}";
        }

        protected override (string, Func<KalkReadOnlyObject, object> getter)[] Members => MemberDefs;

        public override IScriptObject Clone(bool deep)
        {
            var operationUnity = new KalkOperationUnit()
            {
                Left = Left,
                Operator = Operator,
                Right = Right,
            };
            if (deep)
            {
                if (Left is KalkUnit leftUnit)
                {
                    operationUnity.Left = leftUnit.Clone(deep);
                }
                if (Right is KalkUnit rightUnit )
                {
                    operationUnity.Right = rightUnit.Clone(deep);
                }
            }

            return operationUnity;
        }
    }

    public class KalkDefinitionUnit : KalkUnit
    {
        private static readonly (string, Func<KalkReadOnlyObject, object> getter)[] MemberDefs = {
            ("kind", unit => unit.Kind),
            ("name", unit => ((KalkDefinitionUnit)unit).Name),
            ("symbol", unit => ((KalkDefinitionUnit)unit).Symbol),
            ("description", unit => ((KalkDefinitionUnit)unit).Description),
            ("prefix", unit => ((KalkDefinitionUnit)unit).Prefix),
            ("value", unit => ((KalkDefinitionUnit)unit).Value),
        };

        public KalkDefinitionUnit(string name)
        {
            Name = name;
        }

        public override string Kind => "unit definition";

        public string Name { get; }

        public string Symbol { get; set; }

        public string Description { get; set; }

        public string Prefix { get; set; }

        public bool IsUser { get; set; }

        public KalkUnit Value { get; set; }
        
        public override string ToString()
        {
            return Symbol;
        }

        protected override (string, Func<KalkReadOnlyObject, object> getter)[] Members => MemberDefs;

        public override IScriptObject Clone(bool deep)
        {
            var operationUnity = new KalkDefinitionUnit(Name)
            {
                Symbol = Symbol,
                Description = Description,
                Prefix = Prefix,
                Value = Value
            };
            operationUnity.Value = (KalkUnit)Value?.Clone(deep);
            return operationUnity;
        }
    }
}