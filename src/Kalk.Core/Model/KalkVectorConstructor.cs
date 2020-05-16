using System;
using System.Collections;
using System.Threading.Tasks;
using Scriban;
using Scriban.Parsing;
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

        public int Dimension => _dimension;

        public int RequiredParameterCount => 1;

        public int ParameterCount => 1;

        public bool HasVariableParams => true;

        public virtual Type ReturnType => typeof(KalkVector<T>);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            return new ScriptParameterInfo(typeof(object), "");
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (_dimension == 1) return context.ToObject<T>(callerContext.Span, arguments[0]);

            var vector = NewVector(_dimension);
            int index = 0;
            var singleArg = arguments.Count == 1;
            for (var i = 0; i < arguments.Count; i++)
            {
                var arg = arguments[i];
                var argLength = GetLength(arg, singleArg);

                var length = index + argLength;
                if (length > _dimension)
                {
                    throw new ScriptArgumentException(i, $"Invalid number of arguments. Expecting {_dimension} arguments instead of {length} for {vector.Kind}.");
                }
                ProcessArgument(context, callerContext.Span, ref index, arg, i, argLength, vector, singleArg);
            }

            if (index != _dimension)
            {
                throw new ScriptArgumentException(arguments.Count - 1, $"Invalid number of arguments. Expecting {_dimension} arguments instead of {index} for {vector.Kind}.");
            }


            return vector;
        }

        protected virtual KalkVector<T> NewVector(int dimension) => new KalkVector<T>(dimension);

        protected virtual int GetLength(object arg, bool singleArg)
        {
            return arg is IList list ? list.Count : singleArg ? Dimension : 1;
        }

        protected virtual void ProcessArgument(TemplateContext context, SourceSpan span, ref int index, object arg, int argIndex, int argLength, KalkVector<T> vector, bool singleArg)
        {
            if (arg is IList listToAdd)
            {
                for (int j = 0; j < argLength; j++)
                {
                    vector[index++] = GetArgumentValue(context, span, listToAdd[j]);
                }
            }
            else
            {
                var value = GetArgumentValue(context, span, arg);
                if (singleArg)
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

        protected virtual T GetArgumentValue(TemplateContext context, SourceSpan span, object value)
        {
            return context.ToObject<T>(span, value);
        }

#if !SCRIBAN_NO_ASYNC
        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) => new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
#endif
    }
}
