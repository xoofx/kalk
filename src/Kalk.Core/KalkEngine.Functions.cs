using System;
using System.IO;
using Kalk.Core.Modules;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private bool _registerAsSystem;

        private const string CoreFileName = "core.kalk";

        private MiscModule _miscModule;

        private void RegisterFunctions()
        {
            RegisterFunctionsAuto();

            // builtins
            GetOrCreateModule<MathModule>();
            _miscModule = GetOrCreateModule<MiscModule>();
            GetOrCreateModule<MemoryModule>();
            GetOrCreateModule<TypesModule>();
            GetOrCreateModule<VectorModule>();

            var allModule = GetOrCreateModule<AllModule>();
            allModule.Modules.Add(GetOrCreateModule<HardwareIntrinsicsModule>());
            FileModule = GetOrCreateModule<FileModule>();
            allModule.Modules.Add(FileModule);
            allModule.Modules.Add(GetOrCreateModule<CsvModule>());
            allModule.Modules.Add(GetOrCreateModule<StringModule>());
            allModule.Modules.Add(GetOrCreateModule<CurrencyModule>());
            allModule.Modules.Add(GetOrCreateModule<StandardUnitsModule>());
            allModule.Modules.Add(GetOrCreateModule<WebModule>());

            // Register last the system file
            LoadCoreFile();
        }

        public FileModule FileModule { get; private set; }

        private void LoadCoreFile()
        {
            LoadSystemFileFromResource(CoreFileName);
        }

        private void LoadUserConfigFile()
        {
            if (KalkUserFolder == null) return;
            const string configFileName = "config.kalk";
            var userConfigFile = Path.Combine(KalkUserFolder, configFileName);

            //WriteHighlightLine($"# Try loading from {userConfigFile}");

            if (!FileService.FileExists(userConfigFile)) return;

            using var stream = FileService.FileOpen(userConfigFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            LoadConfigFile($".kalk/{configFileName}", stream, false);
        }

        internal void LoadSystemFileFromResource(string filename)
        {
            var stream = typeof(KalkEngine).Assembly.GetManifestResourceStream($"{typeof(KalkEngine).Namespace}.{filename}");
            if (stream == null)
            {
                throw new FileNotFoundException($"The resource {filename} was not found");
            }

            LoadConfigFile(filename, stream, true);
        }

        internal void LoadConfigFile(string filename, Stream stream, bool isSystem)
        {
            // Register all units
            bool previousEchoEnabled = EchoEnabled;
            try
            {
                _registerAsSystem = isSystem;
                EchoEnabled = false;
                using var reader = new StreamReader(stream);
                var text = reader.ReadToEnd();
                EvaluateTextImpl(text, filename, false);
            }
            catch (Exception ex)
            {
                WriteErrorLine($"Unable to load file {filename}. Reason:\n{ex.Message}");
            }
            finally
            {
                EchoEnabled = previousEchoEnabled;
                _registerAsSystem = false;
            }
        }

        protected void RegisterAction(string name, Action action, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterAction<T1>(string name, Action<T1> action, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterAction<T1, T2>(string name, Action<T1, T2> action, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterAction<T1, T2, T3>(string name, Action<T1, T2, T3> action, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.Create(action), category);
        }

        protected void RegisterAction<T1, T2, T3, T4>(string name, Action<T1, T2, T3, T4> action, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.Create(action), category);
        }

        public void RegisterConstant(string name, object value, string category = null)
        {
            RegisterVariable(name, value, category);
        }

        public void RegisterFunction(string name, Delegate del, string category = null)
        {
            RegisterFunction(name, new DelegateCustomFunction(del), category);
        }

        public void RegisterFunction(string name, Func<KalkMatrix, object> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<KalkMatrix, KalkMatrix> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<KalkVector, KalkVector, object> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, object, object> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, bool> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        
        public void RegisterFunction(string name, Func<double, double> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, double> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, long> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<double, double, double> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<KalkDoubleValue, object> func, string category = null)
        {
            RegisterFunction(name, Wrap(func), category);
        }

        public void RegisterFunction(string name, Func<KalkLongValue, object> func, string category = null)
        {
            RegisterFunction(name, Wrap(func), category);
        }

        public void RegisterFunction(string name, Func<KalkIntValue, object> func, string category = null)
        {
            RegisterFunction(name, Wrap(func), category);
        }

        public void RegisterFunction(string name, Func<KalkCompositeValue, object> func, string category = null)
        {
            RegisterFunction(name, Wrap(func), category);
        }


        public void RegisterFunction(string name, Func<object, int> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkVector<int>> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<object[], KalkVector<KalkBool>> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<object[], KalkVector<float>> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<object[], KalkVector<double>> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkMatrix<KalkBool>> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkMatrix<int>> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkMatrix<double>> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkMatrix<float>> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object[], KalkColorRgb> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<object[], KalkColorRgba> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }
        public void RegisterFunction(string name, Func<ScriptVariable, int, object[], object> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, float> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, Func<object, object> func, string category = null)
        {
            RegisterFunction(name, DelegateCustomFunction.CreateFunc(func), category);
        }

        public void RegisterFunction(string name, IScriptCustomFunction func, string category = null)
        {
            RegisterVariable(name, func, category);
        }

        private void RegisterVariable(string name, object value, string category = null)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
            var names = name.Split(',');

            KalkDescriptor descriptor = null;

            foreach (var subName in names)
            {
                Builtins.SetValue(subName, value, true);

                if (descriptor == null || !Descriptors.TryGetValue(names[0], out descriptor))
                {
                    descriptor = new KalkDescriptor();
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