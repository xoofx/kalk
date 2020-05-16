using System;
using System.Threading.Tasks;
using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public abstract class KalkConstructor : IScriptCustomFunction
    {
        public int RequiredParameterCount => 1;

        public int ParameterCount => 1;

        public bool HasVariableParams => true;

        public virtual Type ReturnType => typeof(object);

        public ScriptParameterInfo GetParameterInfo(int index)
        {
            return new ScriptParameterInfo(typeof(object), "");
        }

        public abstract object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement);

        public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) => new ValueTask<object>(Invoke(context, callerContext, arguments, blockStatement));
    }
}