using System;
using System.Collections.Generic;
using Scriban.Runtime;

namespace Kalk.Core
{
    public class KalkModule : ScriptObject
    {

        public KalkModule() : this(null)
        {
        }

        public KalkModule(string name)
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
            
            // Feed the engine with our new builtins
            Engine.Builtins.Import(this);
            foreach (var descriptor in Descriptors)
            {
                Engine.Descriptors[descriptor.Key] = descriptor.Value;
            }

            Import();

            IsImported = true;
        }

        protected virtual void Initialize()
        {
        }

        protected virtual void Import()
        {
            if (!IsBuiltin)
            {
                Engine.WriteHighlightLine($"# {Count} functions successfully imported.");
            }
        }

        public Dictionary<string, KalkDescriptor> Descriptors { get; }

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
                SetValue(subName, value, true);

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