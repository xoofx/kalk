using System;
using Scriban.Runtime;

namespace Kalk.Core
{
    public abstract class KalkModuleWithFunctions : KalkModule
    {
        protected KalkModuleWithFunctions() : this(null)
        {
        }

        protected KalkModuleWithFunctions(string name) : base(name)
        {
            Content = new ScriptObject();
        }

        public ScriptObject Content { get; }
        
        protected override void Import()
        {
            base.Import();

            // Feed the engine with our new builtins
            Engine.Builtins.Import(Content);

            if (!IsBuiltin && Content.Count > 0)
            {
                Engine.WriteHighlightLine($"# {Content.Count} functions successfully imported from module `{Name}`.");
            }
        }

        protected void RegisterConstant(string name, object value, string category = null)
        {
            RegisterVariable(name, value, category);
        }
        protected void RegisterAction(string name, Action action, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterAction<T1>(string name, Action<T1> action, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterAction<T1, T2>(string name, Action<T1, T2> action, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterAction<T1, T2, T3>(string name, Action<T1, T2, T3> action, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterAction<T1, T2, T3, T4>(string name, Action<T1, T2, T3, T4> action, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterFunction<T1>(string name, Func<T1> func, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        protected void RegisterFunction<T1, T2>(string name, Func<T1, T2> func, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        protected void RegisterFunction<T1, T2, T3>(string name, Func<T1, T2, T3> func, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        protected void RegisterFunction<T1, T2, T3, T4>(string name, Func<T1, T2, T3, T4> func, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        protected void RegisterFunction<T1, T2, T3, T4, T5>(string name, Func<T1, T2, T3, T4, T5> func, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        protected void RegisterFunction<T1, T2, T3, T4, T5, T6>(string name, Func<T1, T2, T3, T4, T5, T6> func, string category = null)
        {
            RegisterCustomFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        protected void RegisterCustomFunction(string name, IScriptCustomFunction func, string category = null)
        {
            RegisterVariable(name, func, category);
        }

        protected void RegisterVariable(string name, object value, string category = null)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
            var names = name.Split(',');

            KalkDescriptor descriptor = null;

            foreach (var subName in names)
            {
                Content.SetValue(subName, value, true);

                if (descriptor == null || !Descriptors.TryGetValue(names[0], out descriptor))
                {
                    descriptor = new KalkDescriptor();
                }
                Descriptors.Add(subName, descriptor);
                descriptor.Names.Add(subName);
            }
        }
    }
}