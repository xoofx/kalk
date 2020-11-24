using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkShortcuts : ScriptObject, IScriptCustomFunction
    {
        public KalkShortcuts()
        {
            ShortcutKeyMap = new KalkShortcutKeyMap();
        }

        public KalkShortcutKeyMap ShortcutKeyMap { get; }

        public int RequiredParameterCount => 0;

        public int ParameterCount => 0;
        
        public ScriptVarParamKind VarParamKind => ScriptVarParamKind.None;

        public Type ReturnType => typeof(object);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            throw new NotSupportedException("Shortcuts don't have any parameters.");
        }

        public new void Clear()
        {
            base.Clear();
            ShortcutKeyMap.Clear();
        }

        public void RemoveShortcut(string name)
        {
            if (!TryGetValue(name, out var shortcut)) return;
            Remove(name);

            foreach (KalkShortcutKey shortcutKey in shortcut.Keys)
            {
                var map = ShortcutKeyMap;
                KalkConsoleKey consoleKey = default;
                for (int i = 0; i < shortcutKey.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        if (!map.TryGetShortcut(consoleKey, out var newMap) || !(newMap is KalkShortcutKeyMap))
                        {
                            continue;
                        }
                        map = (KalkShortcutKeyMap)newMap;
                    }
                    consoleKey = shortcutKey.Keys[i];
                }
                map.Remove(consoleKey);
            }

            // Cleanup all maps to remove empty ones
            CleanupMap(ShortcutKeyMap);

        }

        private void CleanupMap(KalkShortcutKeyMap map)
        {
            var keyParis = map.ToList();
            foreach (var keyPair in keyParis)
            {
                if (keyPair.Value is KalkShortcutKeyMap nestedMap)
                {
                    CleanupMap(nestedMap);
                    if (nestedMap.Count == 0)
                    {
                        map.Remove(keyPair.Key);
                    }
                }
            }
        }
        
        public void SetSymbolShortcut(KalkShortcut shortcut)
        {
            if (shortcut == null) throw new ArgumentNullException(nameof(shortcut));
            RemoveShortcut(shortcut.Name);
            Add(shortcut.Name, shortcut);

            foreach (KalkShortcutKey shortcutKey in shortcut.Keys)
            {
                var map = ShortcutKeyMap;
                KalkConsoleKey consoleKey = default;
                for (int i = 0; i < shortcutKey.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        if (!map.TryGetShortcut(consoleKey, out var newMap) || !(newMap is KalkShortcutKeyMap))
                        {
                            newMap = new KalkShortcutKeyMap();
                            map[consoleKey] = newMap;
                        }
                        map = (KalkShortcutKeyMap)newMap;
                    }
                    consoleKey = shortcutKey.Keys[i];
                }

                map[consoleKey] = shortcutKey.Expression;
            }
        }
        
        public bool TryGetValue(string key, out KalkShortcut value)
        {
            value = null;
            if (TryGetValue(null, new SourceSpan(), key, out var valueObj))
            {
                value = (KalkShortcut) valueObj;
                return true;
            }
            return false;
        }
        
        public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
        {
            // In the case of using KalkSymbols outside of the scripting engine
            if (context == null) return base.TrySetValue(null, span, member, value, readOnly);

            // Otherwise, we are not allowing to modify this object.
            throw new ScriptRuntimeException(span, "Shortcuts object can't be modified directly. You need to use the command `shortcut` instead.");
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (!(callerContext.Parent is ScriptExpressionStatement))
            {
                return this;
            }

            Display((KalkEngine)context, "Builtin Shortcuts", filter => !filter.IsUser);
            Display((KalkEngine) context, "User-defined Shortcuts", filter => filter.IsUser);
            return null;
        }

        public void Display(KalkEngine engine, string title, Func<KalkShortcut, bool> filter = null, bool addBlankLine = false)
        {
            if (engine == null) throw new ArgumentNullException(nameof(engine));
            if (title == null) throw new ArgumentNullException(nameof(title));

            var alreadyPrinted = new HashSet<KalkShortcut>();
            bool isFirst = true;
            foreach (var unitKey in this.Keys.OrderBy(x => x))
            {
                var shortcut = this[unitKey] as KalkShortcut;
                if (shortcut == null || !alreadyPrinted.Add(shortcut) || (filter != null && !filter(shortcut))) continue;

                if (isFirst)
                {
                    engine.WriteHighlightLine($"# {title}");
                }
                else if (addBlankLine)
                {
                    engine.WriteHighlightLine("");
                }
                isFirst = false;

                engine.WriteHighlightLine(shortcut.ToString());
            }
        }
        
        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            return new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
        }
    }
}