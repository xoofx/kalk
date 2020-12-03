using System;
using System.Collections.Generic;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public sealed class KalkShortcutKeySequence : ScriptObject
    {
        public KalkShortcutKeySequence(IEnumerable<KalkConsoleKey> keys, ScriptExpression expression)
        {
            if (keys == null) throw new ArgumentNullException(nameof(keys));
            Keys = new List<KalkConsoleKey>(keys);
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            var readonlyKeys = new ScriptArray(Keys) {IsReadOnly = true};
            SetValue("keys", readonlyKeys, true);
            SetValue("expression", Expression.ToString(), true);
            IsReadOnly = true;
        }
        
        public new List<KalkConsoleKey> Keys { get; }
        
        public ScriptExpression Expression { get; }
        
        public static List<KalkShortcutKeySequence> Parse(ScriptExpression keys, ScriptExpression expression)
        {
            if (keys == null) throw new ArgumentNullException(nameof(keys));

            var keyAsString = keys is ScriptLiteral literal && literal.Value is string strValue? strValue : keys.ToString();


            var keySequencesAsText = keyAsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var keySequences = new List<KalkShortcutKeySequence>();

            foreach (var keySequence in keySequencesAsText)
            {
                var keyList = keySequence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var resultKeys = new List<KalkConsoleKey>();

                foreach (var keyText in keyList)
                {
                    try
                    {
                        var key = KalkConsoleKey.Parse(keyText);
                        resultKeys.Add(key);
                    }
                    catch (Exception ex)
                    {
                        throw new ScriptRuntimeException(keys.Span, $"Unable to parse key. Reason: {ex.Message}");
                    }
                }

                keySequences.Add(new KalkShortcutKeySequence(resultKeys, expression));
            }

            return keySequences;
        }
    }
}