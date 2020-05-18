using System.Collections;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkMatrixConstructor<T>
    {
        public KalkMatrixConstructor(int row, int column)
        {
            RowCount = row;
            ColumnCount = column;
        }

        public int RowCount { get; }

        public int ColumnCount { get; }

        public KalkMatrix<T> Invoke(KalkEngine context, params object[] arguments)
        {
            var matrix = new KalkMatrix<T>(RowCount, ColumnCount);
            if (arguments.Length == 0) return matrix;
            
            int index = 0;
            int columnIndex = 0;
            var maxTotal = ColumnCount * RowCount;
            if (arguments.Length == 1)
            {
                var arg0 = arguments[0];
                if (arg0 is KalkMatrix m)
                {
                    var values = m.Values;
                    for (int j = 0; j < values.Length; j++)
                    {
                        matrix[index++] = context.ToObject<T>(0, values.GetValue(j));
                    }
                }
                else if (arg0 is IList list)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        matrix[index++] = context.ToObject<T>(0, list[j]);
                    }
                }
                else
                {
                    var value = context.ToObject<T>(0, arg0);
                    for (int j = 0; j < ColumnCount * RowCount; j++)
                    {
                        matrix[index++] = value;
                    }
                }
            }
            else
            {
                for (var i = 0; i < arguments.Length; i++)
                {
                    var arg = arguments[i];
                    var argLength = arg is IList list ? list.Count : 1;

                    var length = columnIndex + argLength;
                    if (length > ColumnCount)
                    {
                        throw new ScriptArgumentException(i, $"Invalid number of arguments crossing a row. Expecting {ColumnCount} arguments instead of {length} for {matrix.TypeName}.");
                    }

                    if (length == ColumnCount)
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
                            matrix[index++] = context.ToObject<T>(i, listToAdd[j]);
                        }
                    }
                    else
                    {
                        var value = context.ToObject<T>(i, arg);
                        matrix[index++] = value;
                    }
                }
            }

            if (index != maxTotal)
            {
                throw new ScriptArgumentException(arguments.Length - 1, $"Invalid number of arguments. Expecting {maxTotal} arguments instead of {index} for {matrix.TypeName}.");
            }
            
            return matrix;
        }
    }
}