using System;
using System.Collections;
using System.Threading.Tasks;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkVectorConstructor<T> : KalkConstructor
    {
        private readonly int _dimension;

        public KalkVectorConstructor(int dimension)
        {
            _dimension = dimension;
        }

        public int Dimension => _dimension;

        public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (_dimension == 1) return context.ToObject<T>(callerContext.Span, arguments[0]);

            var vector = NewVector(_dimension);
            int index = 0;
            var span = callerContext.Span;
            if (arguments.Count == 1)
            {
                ProcessSingleArgument(context, span, ref index, arguments[0], vector);
            }
            else
            {
                for (var i = 0; i < arguments.Count; i++)
                {
                    var arg = arguments[i];
                    var argLength = GetLength(arg);

                    var length = index + argLength;
                    if (length > _dimension)
                    {
                        throw new ScriptArgumentException(i, $"Invalid number of arguments. Expecting {_dimension} arguments instead of {length} for {vector.Kind}.");
                    }

                    ProcessArgument(context, callerContext.Span, ref index, arg, i, argLength, vector);
                }
            }

            if (index != _dimension)
            {
                throw new ScriptArgumentException(arguments.Count - 1, $"Invalid number of arguments. Expecting {_dimension} arguments instead of {index} for {vector.Kind}.");
            }


            return vector;
        }

        protected virtual void ProcessSingleArgument(TemplateContext context, SourceSpan span, ref int index, object arg, KalkVector<T> vector)
        {
            var value = GetArgumentValue(context, span, arg);
            for (int j = 0; j < _dimension; j++)
            {
                vector[index++] = value;
            }
        }

        protected virtual KalkVector<T> NewVector(int dimension) => new KalkVector<T>(dimension);

        protected virtual int GetLength(object arg)
        {
            return arg is IList list ? list.Count : 1;
        }

        protected virtual void ProcessArgument(TemplateContext context, SourceSpan span, ref int index, object arg, int argIndex, int argLength, KalkVector<T> vector)
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
                vector[index++] = value;
            }
        }

        protected virtual T GetArgumentValue(TemplateContext context, SourceSpan span, object value)
        {
            return context.ToObject<T>(span, value);
        }
    }
}
