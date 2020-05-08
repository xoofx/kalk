using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Consolus;
using Scriban;
using Scriban.Functions;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private const string CategoryGeneral = "General";

        private void RegisterFunctions()
        {
            RegisterFunction("help", new Action<ScriptExpression>(Help), CategoryGeneral);
            RegisterFunction("version", new Action(Version), CategoryGeneral);
            RegisterFunction("reset", new Action(Reset), CategoryGeneral);
            RegisterFunction("exit", new Action(Exit), CategoryGeneral);
            RegisterFunction("history", new Action<object>(History), CategoryGeneral);

            RegisterFunction("list", new Action(ListVariables), CategoryGeneral);
            RegisterFunction("del", new Action<ScriptVariable>(DeleteVariable), CategoryGeneral);

            RegisterFunction("keys", DelegateCustomFunction.CreateFunc<object, IEnumerable>(Keys), CategoryGeneral);
            
            //Builtins.SetValue("empty", EmptyScriptObject.Default, true);
            var clear = new Action<ScriptExpression>(Clear);
            RegisterFunction("cls,clear", clear, CategoryGeneral);
            RegisterFunction("out", new Func<object>(Last), CategoryGeneral);

            RegisterMathFunctions();

            Builtins.Import("kb", new Func<object, object>(Kb));
            Builtins.Import("mb", new Func<object, object>(Mb));
            Builtins.Import("gb", new Func<object, object>(Gb));
            Builtins.Import("tb", new Func<object, object>(Tb));
            Builtins.Import("i", new Func<object, object>(ComplexNumber));

            RegisterUnitFunctions();

            RegisterDocumentation();
        }

        [KalkDoc("keys")]
        public IEnumerable Keys(object obj)
        {
            return ObjectFunctions.Keys(this, obj);
        }

        partial void RegisterDocumentation();


        public void RegisterConstant(string name, object value, string category)
        {
            RegisterVariable(name, value, category);
        }

        public void RegisterFunction(string name, Delegate del, string category)
        {
            RegisterFunction(name, new DelegateCustomFunction(del), category);
        }

        public void RegisterFunction(string name, Func<KalkDoubleValue, object> func, string category)
        {
            RegisterFunction(name, Wrap(func), category);
        }

        public void RegisterFunction(string name, Func<KalkLongValue, object> func, string category)
        {
            RegisterFunction(name, Wrap(func), category);
        }

        public void RegisterFunction(string name, Func<KalkValue, object> func, string category)
        {
            RegisterFunction(name, Wrap(func), category);
        }

        public void RegisterFunction(string name, IScriptCustomFunction func, string category)
        {
            RegisterVariable(name, func, category);
        }

        private void RegisterVariable(string name, object value, string category)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (category == null) throw new ArgumentNullException(nameof(category));
            var names = name.Split(',');

            KalkDescriptor descriptor = null;

            foreach (var subName in names)
            {
                Builtins.SetValue(subName, value, true);

                if (descriptor == null || !Descriptors.TryGetValue(names[0], out descriptor))
                {
                    descriptor = new KalkDescriptor { Category = category };
                }
                Descriptors.Add(subName, descriptor);
                descriptor.Names.Add(subName);
            }
        }

        private static DelegateCustomFunction Wrap(Func<KalkDoubleValue, object> func)
        {
            return DelegateCustomFunction.CreateFunc(func);
        }

        private static DelegateCustomFunction Wrap(Func<KalkValue, object> func)
        {
            return DelegateCustomFunction.CreateFunc(func);
        }

        private static DelegateCustomFunction Wrap(Func<KalkLongValue, object> func)
        {
            return DelegateCustomFunction.CreateFunc(func);
        }
    }
}