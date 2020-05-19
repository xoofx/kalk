using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using Kalk.Core.Helpers;
using Scriban;
using Scriban.Helpers;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkVectorConstructor<T> : KalkConstructor where T : unmanaged
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
                var arg = arguments[0];
                var argLength = GetArgLength(arg, true);
                var length = index + argLength;
                if (length != Dimension)
                {
                    throw new ScriptArgumentException(0, $"Invalid number of arguments for {vector.TypeName}. Expecting {Dimension} arguments instead of {length}.");
                }

                ProcessSingleArgument(context, ref index, arg, vector);
            }
            else
            {
                for (var i = 0; i < arguments.Length; i++)
                {
                    var arg = arguments[i];
                    var argLength = GetArgLength(arg, false);

                    var length = index + argLength;
                    if (length > Dimension)
                    {
                        throw new ScriptArgumentException(i, $"Invalid number of arguments for {vector.TypeName}. Expecting {Dimension} arguments instead of {length}.");
                    }

                    ProcessArgument(context, ref index, arg, vector);
                }
            }

            if (index != Dimension)
            {
                throw new ScriptArgumentException(arguments.Length - 1, $"Invalid number of arguments for {vector.TypeName}. Expecting {Dimension} arguments instead of {index}.");
            }

            return vector;
        }

        private int GetArgLength(object arg, bool isSingleArg)
        {
            if (arg is IList list)
            {
                int argLength = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    argLength += GetArgLength(list[i], false);
                }
                return argLength;
            }

            return isSingleArg ? Dimension : 1;
        }

        private void AddListItem(TemplateContext context, ref int index, object arg, KalkVector<T> vector)
        {
            if (arg is IList list)
            {
                var count = list.Count;
                for (int j = 0; j < count; j++)
                {
                    AddListItem(context, ref index, list[j], vector);
                }
            }
            else
            {
                var value = GetArgumentValue(context, arg);
                vector[index++] = value;
            }
        }

        protected virtual void ProcessSingleArgument(TemplateContext context, ref int index, object arg, KalkVector<T> vector)
        {
            if (arg is IList list)
            {
                AddListItem(context, ref index, list, vector);
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
                AddListItem(context, ref index, list, vector);
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
