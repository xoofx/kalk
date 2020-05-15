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
    public class KalkAliases : ScriptObject, IScriptCustomFunction
    {
        public KalkAliases()
        {
            Aliases = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Aliases { get; }

        public int RequiredParameterCount => 0;

        public int ParameterCount => 0;

        public bool HasVariableParams => false;

        public Type ReturnType => typeof(object);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            throw new NotSupportedException("Aliases don't have any parameters.");
        }
       
        public void AddAlias(KalkAlias alias)
        {
            if (alias == null) throw new ArgumentNullException(nameof(alias));
            Add(alias.Name, alias);

            foreach (string aliasName in alias.Aliases)
            {
                Aliases[aliasName] = alias.Name;
            }
        }

        public bool TryGetAlias(string name, out string alias)
        {
            return Aliases.TryGetValue(name, out alias);
        }
        
        public bool TryGetValue(string key, out KalkAlias value)
        {
            value = null;
            if (TryGetValue(null, new SourceSpan(), key, out var valueObj))
            {
                value = (KalkAlias) valueObj;
                return true;
            }
            return false;
        }
        
        public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
        {
            // In the case of using KalkSymbols outside of the scripting engine
            if (context == null) return base.TrySetValue(null, span, member, value, readOnly);

            // Otherwise, we are not allowing to modify this object.
            throw new ScriptRuntimeException(span, "Aliases object can't be modified directly. You need to use the command `shortcut` instead.");
        }

        public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (!(callerContext.Parent is ScriptExpressionStatement))
            {
                return this;
            }

            Display((KalkEngine)context, "Builtin Aliases", filter => !filter.IsUser);
            Display((KalkEngine) context, "User-defined Aliases", filter => filter.IsUser);
            return null;
        }

        public void Display(KalkEngine engine, string title, Func<KalkAlias, bool> filter = null, bool addBlankLine = false)
        {
            if (engine == null) throw new ArgumentNullException(nameof(engine));
            if (title == null) throw new ArgumentNullException(nameof(title));

            bool isFirst = true;
            foreach (var aliasKey in this.Keys.OrderBy(x => x))
            {
                var alias = this[aliasKey] as KalkAlias;
                if (alias == null || (filter != null && !filter(alias))) continue;

                if (isFirst)
                {
                    engine.WriteHighlightLine($"# {title}");
                }
                else if (addBlankLine)
                {
                    engine.WriteHighlightLine("");
                }
                isFirst = false;

                engine.WriteHighlightLine(alias.ToString());
            }
        }
        
        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            return new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
        }
    }
}