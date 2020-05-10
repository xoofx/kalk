using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkCurrencies : IScriptObject, IScriptCustomFunction
    {
        private readonly KalkUnits _units;

        public KalkCurrencies(KalkUnits units)
        {
            _units = units;
        }

        public int Count => _units.Count;

        public IEnumerable<string> GetMembers()
        {
            // Show only currencies from units
            foreach (var unitPair in _units)
            {
                if (unitPair.Value is KalkCurrency) yield return unitPair.Key;
            }
        }

        public bool Contains(string member)
        {
            return _units.Contains(member) && _units[member] is KalkCurrency;
        }

        public bool IsReadOnly
        {
            get => _units.IsReadOnly;
            set => _units.IsReadOnly = value;
        }

        public bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object value)
        {
            if (_units.TryGetValue(context, span, member, out value) && value is KalkCurrency)
            {
                return true;
            }
            value = null;
            return false;
        }

        public bool CanWrite(string member) => false;

        public bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly) => false;

        public bool Remove(string member) => false;

        public void SetReadOnly(string member, bool readOnly)
        {
        }

        public IScriptObject Clone(bool deep)
        {
            throw new NotSupportedException("Clone is not supported");
        }

        public int RequiredParameterCount => 0;

        public int ParameterCount => 0;

        public bool HasVariableParams => false;

        public Type ReturnType => typeof(object);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            throw new NotSupportedException("Units don't have any parameters.");
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (!(callerContext.Parent is ScriptExpressionStatement))
            {
                return this;
            }

            _units.Display((KalkEngine)context, "Builtin Currencies", symbol => symbol is KalkCurrency && !symbol.IsUser, false);
            _units.Display((KalkEngine)context, "User Defined Currencies", symbol => symbol is KalkCurrency && symbol.IsUser, false);

            return null;
        }

        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            return new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
        }
    }
}