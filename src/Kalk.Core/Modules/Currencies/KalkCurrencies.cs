using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kalk.Core.Modules;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkCurrencies : IScriptObject, IScriptCustomFunction
    {
        private KalkUnits _units;
        private readonly CurrencyModule _currencyModule;

        public KalkCurrencies(CurrencyModule currencyModule)
        {
            _currencyModule = currencyModule;
        }

        public void Initialize(KalkEngine engine)
        {
            if (engine == null) throw new ArgumentNullException(nameof(engine));
            _units = engine.Units;
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var unitPair in _units)
                {
                    if (unitPair.Value is KalkCurrency) count++;
                }
                return count;
            }
        }

        public void Clear()
        {
            var keys = _units.Keys.ToList();
            foreach (var unitKey in keys)
            {
                if (_units.TryGetValue(unitKey, out var unitObject) && unitObject is KalkCurrency)
                {
                    _units.Remove(unitKey);
                }
            }
        }

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
            get => false;
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
            throw new NotSupportedException("Currencies don't have any parameters.");
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (!(callerContext.Parent is ScriptExpressionStatement))
            {
                return this;
            }

            var engine = (KalkEngine) context;
            if (_units.All(x => x.Value.GetType() != typeof(KalkCurrency)))
            {
                engine.WriteHighlightLine($"# No Currencies defined (e.g try `import {nameof(CurrencyModule)}`)");
            }
            else
            {
                _units.Display(engine, $"Builtin Currencies (Last Update: {_currencyModule.LastUpdate})", symbol => symbol is KalkCurrency && !symbol.IsUser, false);
                _units.Display(engine, "User Defined Currencies", symbol => symbol is KalkCurrency && symbol.IsUser, false);
            }

            return null;
        }

        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            return new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
        }
    }
}