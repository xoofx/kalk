using System;
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
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        private void RegisterFunctions()
        {
            Builtins.Import("help", new Action<ScriptExpression>(Help));
            Builtins.Import("version", new Action(Version));
            Builtins.Import("reset", new Action(Reset));
            Builtins.Import("exit", new Action(Exit));
            Builtins.Import("history", new Action<object>(History));

            Builtins.Import("list", new Action(ListVariables));
            Builtins.Import("del", new Action<ScriptVariable>(DeleteVariable));
            Builtins.SetValue("empty", EmptyScriptObject.Default, true);
            var clear = new Action<ScriptExpression>(Clear);
            Builtins.Import("clear", clear);
            Builtins.Import("cls", clear);
            Builtins.Import("out", new Func<object>(Last));


            RegisterMathFunctions();


            Builtins.Import("kb", new Func<object, object>(Kb));
            Builtins.Import("mb", new Func<object, object>(Mb));
            Builtins.Import("gb", new Func<object, object>(Gb));
            Builtins.Import("tb", new Func<object, object>(Tb));
            Builtins.Import("i", new Func<object, object>(ComplexNumber));

            Builtins.Import("unit", new Func<ScriptVariable, string, ScriptExpression, ScriptVariable, KalkUnit>(Unit));
        }
    }
}