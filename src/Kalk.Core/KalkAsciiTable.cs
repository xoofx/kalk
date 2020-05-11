using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Scriban;
using Scriban.Functions;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkAsciiTable : IScriptObject, IScriptCustomFunction
    {
        public static readonly Encoding EncodingExtendedAscii = CodePagesEncodingProvider.Instance.GetEncoding(1252);

        public int Count => 255;

        public IEnumerable<string> GetMembers()
        {
            for (int i = 0; i <= 255; i++)
            {
                yield return GetAsciiString(i);
            }
        }

        public bool Contains(string member)
        {
            return true;
        }

        public bool IsReadOnly { get; set; }

        public bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object value)
        {
            if (member.Length == 1)
            {
                if (member[0] > 255)
                {
                    throw new ScriptRuntimeException(span, $"The character `{member}` is not an ascii character in the range 0..255.");
                }

                value = (int) member[0];
            }
            else
            {
                var array = new ScriptArray();
                foreach (var c in member)
                {
                    if (c > 255)
                    {
                        throw new ScriptRuntimeException(span, $"The character `{c}` in `{member}` is not an ascii character in the range 0..255.");
                    }
                    array.Add((int) c);
                }

                value = array;
            }
            return true;
        }

        public bool CanWrite(string member) => false;

        public bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
        {
            return false;
        }

        public bool Remove(string member) => false;

        public void SetReadOnly(string member, bool readOnly)
        {
            throw new System.NotImplementedException();
        }

        public IScriptObject Clone(bool deep)
        {
            throw new System.NotImplementedException();
        }

        public int RequiredParameterCount => 0;
        public int ParameterCount => 1;
        public bool HasVariableParams => false;

        public Type ReturnType => typeof(object);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            return new ScriptParameterInfo(typeof(object), "name");
        }

        private static unsafe string GetAsciiString(int c)
        {
            var value = (byte)c;
            return EncodingExtendedAscii.GetString(&value, 1);
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            Debug.Assert(arguments.Count == 1);

            var arg = arguments[0];

            if (arg == null && callerContext.Parent is ScriptExpressionStatement)
            {
                var engine = (KalkEngine) context;
                var builder = new StringBuilder();

                const int alignControls = 16;
                const int alignStandard = 15;
                const int columnWidth = 3 + 4 + 1;

                for (int y = 0; y < 32; y++)
                {
                    builder.Length = 0;
                    for (int x = 0; x < 8; x++)
                    {
                        var c = x * 32 + y;
                        if (x > 0) builder.Append(" ");

                        var index = $"{c,3}";

                        var valueAsString = StringFunctions.Escape(GetAsciiString(c));
                        var strValue = $"\"{valueAsString}\"";
                        var column = $"{index} {strValue,-4}";

                        OutputColumn(builder, x, column);
                    }

                    if (y == 0)
                    {
                        engine.WriteHighlight($"{"ASCII controls",alignControls}  {"ASCII printable characters",-(columnWidth * 2 + alignStandard + 2)} {"Extended ASCII Characters"}");
                    }

                    engine.WriteHighlight(builder.ToString());
                }

                void OutputColumn(StringBuilder output, int columnIndex, string text)
                {
                    output.Append(columnIndex == 0 ? $"{text,-alignControls}" : columnIndex == 3 ? $"{text,-alignControls}" : $"{text}");
                }


                return null;
            }
            else
            {
                return ConvertAscii(context, arg);
            }
        }

        private static object ConvertAscii(TemplateContext context, object argument)
        {
            if (argument is string text)
            {
                var bytes = EncodingExtendedAscii.GetBytes(text);
                if (bytes.Length == 1)
                {
                    return bytes[0];
                }

                var array = new ScriptArray();
                for (int i = 0; i < bytes.Length; i++)
                {
                    array.Add((int)bytes[i]);
                }
                return array;
            }
            else if (argument is IEnumerable it)
            {
                return new ScriptRange(GetIteration(context, it));
            }
            else
            {
                return GetAsciiString(context.ToInt(context.CurrentSpan, argument));
            }
        }

        private static IEnumerable GetIteration(TemplateContext context, IEnumerable it)
        {
            var iterator = it.GetEnumerator();
            while (iterator.MoveNext())
            {
                yield return ConvertAscii(context, iterator.Current);
            }
        }



        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            return new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
        }
    }
}