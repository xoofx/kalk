using System.Collections;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkMatrixConstructor<T> : KalkConstructor
    {
        public KalkMatrixConstructor(int row, int column)
        {
            RowLength = row;
            ColumnLength = column;
        }

        public int RowLength { get; }

        public int ColumnLength { get; }

        public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            var matrix = new KalkMatrix<T>(RowLength, ColumnLength);
            int index = 0;
            int columnIndex = 0;
            var maxTotal = ColumnLength * RowLength;
            var span = callerContext.Span;
            if (arguments.Count == 1)
            {
                var value = context.ToObject<T>(span, arguments[0]);
                for (int j = 0; j < ColumnLength * RowLength; j++)
                {
                    matrix[index++] = value;
                }
            }
            else
            {
                for (var i = 0; i < arguments.Count; i++)
                {
                    var arg = arguments[i];
                    var argLength = arg is IList list ? list.Count : 1;

                    var length = columnIndex + argLength;
                    if (length > ColumnLength)
                    {
                        throw new ScriptArgumentException(i, $"Invalid number of arguments crossing a row. Expecting {ColumnLength} arguments instead of {length} for {matrix.Kind}.");
                    }

                    if (length == ColumnLength)
                    {
                        columnIndex = 0;
                    }
                    else
                    {
                        columnIndex += argLength;
                    }

                    if (arg is IList listToAdd)
                    {
                        for (int j = 0; j < argLength; j++)
                        {
                            matrix[index++] = context.ToObject<T>(span, listToAdd[j]);
                        }
                    }
                    else
                    {
                        var value = context.ToObject<T>(span, arg);
                        matrix[index++] = value;
                    }
                }
            }

            if (index != maxTotal)
            {
                throw new ScriptArgumentException(arguments.Count - 1, $"Invalid number of arguments. Expecting {maxTotal} arguments instead of {index} for {matrix.Kind}.");
            }
            
            return matrix;
        }
    }
}