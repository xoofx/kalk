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
using Kalk.Core.Modules;
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

        private const string CoreFileName = "core.kalk";

        private void RegisterFunctions()
        {
            RegisterGeneralFunctions();
            RegisterModule(new MathModule());
            RegisterMiscFunctions();
            RegisterUnitFunctions();

            RegisterModule(new IntrinsicsModule());
            RegisterModule(new FileModule());
            RegisterModule(new StringModule());
            RegisterModule(new CurrencyModule());
            RegisterModule(new VectorModule());
            RegisterModule(new StandardUnitsModule());
            //RegisterDocumentation();

            // Register last the system file
            LoadCoreFile();
        }

        private void LoadCoreFile()
        {
            LoadSystemFile(CoreFileName);
        }

        internal void LoadSystemFile(string filename)
        {
            // Register all units
            var packageFilePath = Path.Combine(KalkEngineFolder, filename);
            try
            {
                _registerAsSystem = true;
                LoadFile(packageFilePath);
            }
            catch (Exception ex)
            {
                WriteError($"Unable to load units from `{packageFilePath}`. Reason:\n{ex.Message}");
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

        public void RegisterFunction(string name, Func<KalkMatrix, object> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<KalkMatrix, KalkMatrix> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<KalkVector, KalkVector, object> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, object, object> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, bool> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        
        public void RegisterFunction(string name, Func<double, double> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, double> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, long> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<double, double, double> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
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

        public void RegisterFunction(string name, Func<KalkCompositeValue, object> func, string category)
        {
            RegisterFunction(name, Wrap(func), category);
        }


        public void RegisterFunction(string name, Func<object, int> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkVector<int>> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<object[], KalkVector<bool>> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<object[], KalkVector<float>> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<object[], KalkVector<double>> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkMatrix<bool>> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkMatrix<int>> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkMatrix<double>> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkMatrix<float>> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkColorRgb> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<object[], KalkColorRgba> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<ScriptVariable, int, object[], object> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, float> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, object> func, string category)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
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

        private static DelegateCustomFunction Wrap(Func<KalkCompositeValue, object> func)
        {
            return DelegateCustomFunction.CreateFunc(func);
        }

        private static DelegateCustomFunction Wrap(Func<KalkLongValue, object> func)
        {
            return DelegateCustomFunction.CreateFunc(func);
        }
    }
}