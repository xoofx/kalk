using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
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
        private bool _registerAsSystem;

        private const string SystemFileName = "system.kalk";

        private void RegisterFunctions()
        {
            RegisterIntrinsics();
            RegisterGeneralFunctions();
            RegisterMathFunctions();
            RegisterDeveloperFunctions();
            RegisterUnitFunctions();
            RegisterDocumentation();

            // Register last the system file
            RegisterSystemFile();
        }

        private void RegisterSystemFile()
        {
            // Register all units
            var unitsFilePath = Path.Combine(KalkEngineFolder, SystemFileName);
            try
            {
                _registerAsSystem = true;
                LoadFile(unitsFilePath);
            }
            catch (Exception ex)
            {
                WriteError($"Unable to load units from `{unitsFilePath}`. Reason:\n{ex.Message}");
            }
            finally
            {
                _registerAsSystem = false;
            }
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

        public void RegisterFunction(string name, Func<KalkIntValue, object> func, string category)
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

        private static DelegateCustomFunction Wrap(Func<KalkIntValue, object> func)
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