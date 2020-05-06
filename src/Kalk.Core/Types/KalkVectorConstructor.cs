using System;
using System.Threading.Tasks;
using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkVectorConstructor<T> : IScriptCustomFunction where T : struct, IEquatable<T>, IFormattable
    {
        private readonly int _dimension;

        public KalkVectorConstructor(int dimension)
        {
            _dimension = dimension;
        }

        public int RequiredParameterCount => 1;

        public int ParameterCount => _dimension;

        public bool HasVariableParams => false;

        public Type ReturnType => typeof(KalkVector<T>);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            return new ScriptParameterInfo(typeof(object), "");
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            var values = arguments.Count;
            var vector = new KalkVector<T>(_dimension);
            for (int i = 0; i < arguments.Count; i++)
            {
                vector[i] = context.ToObject<T>(callerContext.Span, arguments[i]);
            }
            return vector;
        }

#if !SCRIBAN_NO_ASYNC
        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            var values = arguments.Count;
            var vector = new KalkVector<T>(_dimension);
            for (int i = 0; i < arguments.Count; i++)
            {
                vector[i] = context.ToObject<T>(callerContext.Span, arguments[i]);
            }
            return new ValueTask<object>(vector);
        }
#endif
    }
}