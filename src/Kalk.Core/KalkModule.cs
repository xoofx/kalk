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
    public abstract class KalkModule : IScriptCustomFunction, IScriptObject
    {
        protected KalkModule() : this(null)
        {
        }

        protected KalkModule(string name)
        {
            Name = name;
            if (Name == null)
            {
                Name = this.GetType().Name;
                if (Name.EndsWith("Module"))
                {
                    Name = Name.Substring(0, Name.Length - "Module".Length);
                }
            }
            Descriptors = new Dictionary<string, KalkDescriptor>();
        }

        public string Name { get; private set; }

        public KalkEngine Engine { get; private set; }

        public bool IsImported { get; private set; }

        public bool IsBuiltin { get; protected set; }

        public bool IsInitialized { get; private set; }

        internal void Initialize(KalkEngine engine)
        {
            if (IsInitialized) return;
            Engine = engine;
            Initialize();
            IsInitialized = true;
        }

        internal void InternalImport()
        {
            if (IsImported) return;

            Import();

            IsImported = true;
        }

        protected virtual void Initialize()
        {
        }

        protected virtual void Import()
        {
            foreach (var descriptor in Descriptors)
            {
                Engine.Descriptors[descriptor.Key] = descriptor.Value;
            }
        }

        public Dictionary<string, KalkDescriptor> Descriptors { get; }

        int IScriptFunctionInfo.RequiredParameterCount => 0;

        int IScriptFunctionInfo.ParameterCount => 0;

        bool IScriptFunctionInfo.HasVariableParams => false;

        Type IScriptFunctionInfo.ReturnType => typeof(object);

        ScriptParameterInfo IScriptFunctionInfo.GetParameterInfo(int index) => throw new NotSupportedException("A module doesn't have any parameters.");

        object IScriptCustomFunction.Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            if (!(callerContext.Parent is ScriptExpressionStatement))
            {
                return this;
            }

            var engine = (KalkEngine) context;
            engine.WriteHighlightLine($"# Module {Name}");
            return null;
        }

        ValueTask<object> IScriptCustomFunction.InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement)
        {
            return new ValueTask<object>(((IScriptCustomFunction)this).Invoke(context, callerContext, arguments, blockStatement));
        }

        int IScriptObject.Count => 0;

        IEnumerable<string> IScriptObject.GetMembers() => Enumerable.Empty<string>();

        bool IScriptObject.Contains(string member) => false;

        bool IScriptObject.IsReadOnly
        {
            get => true;
            set
            {
            }
        }

        bool IScriptObject.TryGetValue(TemplateContext context, SourceSpan span, string member, out object value)
        {
            value = null;
            return false;
        }

        bool IScriptObject.CanWrite(string member) => false;

        bool IScriptObject.TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly) => false;


        bool IScriptObject.Remove(string member) => false;

        void IScriptObject.SetReadOnly(string member, bool readOnly)
        {
        }

        IScriptObject IScriptObject.Clone(bool deep)
        {
            throw new NotSupportedException("A module does not support the clone operation.");
        }
    }
}