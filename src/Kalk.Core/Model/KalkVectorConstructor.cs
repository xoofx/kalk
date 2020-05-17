using System.Collections;
using System.Globalization;
using Scriban;
using Scriban.Helpers;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkVectorConstructor<T>
    {
        public KalkVectorConstructor(int dimension)
        {
            Dimension = dimension;
        }

        public int Dimension { get; }

        public KalkVector<T> Invoke(TemplateContext context, object[] arguments)
        {
            if (arguments.Length == 0)
            {
                return NewVector(Dimension);
            }

            var vector = NewVector(Dimension);
            int index = 0;
            if (arguments.Length == 1)
            {
                ProcessSingleArgument(context, ref index, arguments[0], vector);
            }
            else
            {
                for (var i = 0; i < arguments.Length; i++)
                {
                    var arg = arguments[i];
                    var argLength = arg is IList list ? list.Count : 1;

                    var length = index + argLength;
                    if (length > Dimension)
                    {
                        throw new ScriptArgumentException(i, $"Invalid number of arguments. Expecting {Dimension} arguments instead of {length} for {vector.Kind}.");
                    }

                    ProcessArgument(context, ref index, arg, vector);
                }
            }

            if (index != Dimension)
            {
                throw new ScriptArgumentException(arguments.Length - 1, $"Invalid number of arguments. Expecting {Dimension} arguments instead of {index} for {vector.Kind}.");
            }

            return vector;
        }

        protected virtual void ProcessSingleArgument(TemplateContext context, ref int index, object arg, KalkVector<T> vector)
        {
            if (arg is IList list)
            {
                var count = list.Count;
                for (int j = 0; j < count; j++)
                {
                    vector[index++] = GetArgumentValue(context, list[j]);
                }
            }
            else
            {
                var value = GetArgumentValue(context, arg);
                for (int j = 0; j < Dimension; j++)
                {
                    vector[index++] = value;
                }
            }
        }

        protected void ProcessArgument(TemplateContext context, ref int index, object arg, KalkVector<T> vector)
        {
            if (arg is IList list)
            {
                var count = list.Count;
                for (int j = 0; j < count; j++)
                {
                    vector[index++] = GetArgumentValue(context, list[j]);
                }
            }
            else
            {
                var value = GetArgumentValue(context, arg);
                vector[index++] = value;
            }
        }

        protected virtual KalkVector<T> NewVector(int dimension) => new KalkVector<T>(dimension);

        protected virtual T GetArgumentValue(TemplateContext context, object value)
        {
            return context.ToObject<T>(context.CurrentSpan, value);
        }
    }
}
