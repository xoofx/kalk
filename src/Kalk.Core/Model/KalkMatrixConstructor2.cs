using System;
using System.Threading.Tasks;
using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkMatrixConstructor2<T> : IScriptCustomFunction where T : struct, IEquatable<T>, IFormattable
    {
        public KalkMatrixConstructor2(int row, int column)
        {
            if (row <= 0) throw new ArgumentOutOfRangeException(nameof(row));
            if (column <= 0) throw new ArgumentOutOfRangeException(nameof(column));
            RowLength = row;
            ColumnLength = column;
        }

        public int RowLength { get; }

        public int ColumnLength { get; }

        public int RequiredParameterCount => 1;

        public int ParameterCount => RowLength * ColumnLength;

        public bool HasVariableParams => false;

        public Type ReturnType => typeof(KalkMatrix<T>);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            return new ScriptParameterInfo(typeof(object), "");
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            var vector = new KalkMatrix<T>(RowLength, ColumnLength);
            for (int i = 0; i < arguments.Count; i++)
            {
                vector[i] = context.ToObject<T>(callerContext.Span, arguments[i]);
            }
            return vector;
        }

#if !SCRIBAN_NO_ASYNC
        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) => new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
#endif
    }
}