using System;
using System.Collections;
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

        public int ParameterCount => 1;

        public bool HasVariableParams => true;

        public Type ReturnType => typeof(KalkVector<T>);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            return new ScriptParameterInfo(typeof(object), "");
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (_dimension == 1) return context.ToObject<T>(callerContext.Span, arguments[0]);

            var vector = new KalkVector<T>(_dimension);
            int index = 0;
            for (var i = 0; i < arguments.Count; i++)
            {
                var arg = arguments[i];
                var argLength = arg is IList list ? list.Count : 1;

                var length = index + argLength;
                if (length > _dimension)
                {
                    throw new ScriptArgumentException(i, $"Invalid number of arguments. Expecting {_dimension} arguments instead of {length} for {vector.Kind}.");
                }

                if (arg is IList listToAdd)
                {
                    for (int j = 0; j < argLength; j++)
                    {
                        vector[index++] = context.ToObject<T>(callerContext.Span, listToAdd[j]);
                    }
                }
                else
                {
                    var value = context.ToObject<T>(callerContext.Span, arg);
                    if (arguments.Count == 1)
                    {
                        for (int j = 0; j < _dimension; j++)
                        {
                            vector[index++] = value;
                        }
                    }
                    else
                    {
                        vector[index++] = value;
                    }
                }
            }

            if (index != _dimension)
            {
                throw new ScriptArgumentException(arguments.Count - 1, $"Invalid number of arguments. Expecting {_dimension} arguments instead of {index} for {vector.Kind}.");
            }


            return vector;
        }

#if !SCRIBAN_NO_ASYNC
        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) => new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
#endif
    }
}