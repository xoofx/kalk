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
        private const string CategoryMisc = "Misc Functions";

        private void RegisterMiscFunctions()
        {
            RegisterVariable("ascii", AsciiTable, CategoryMisc);
            RegisterFunction("keys", DelegateCustomFunction.CreateFunc<object, IEnumerable>(Keys), CategoryMisc);
            RegisterFunction("values", DelegateCustomFunction.CreateFunc<object, IEnumerable>(Values), CategoryMisc);
        }

        /// <summary>
        /// Returns the ascii table or print
        /// </summary>
        [KalkDoc("ascii")]
        public KalkAsciiTable AsciiTable { get; }
        
        [KalkDoc("keys")]
        public IEnumerable Keys(object obj)
        {
            return ObjectFunctions.Keys(this, obj);
        }

        [KalkDoc("values")]
        public IEnumerable Values(object obj)
        {
            switch (obj)
            {
                case IDictionary<string, object> dict:
                    return ObjectFunctions.Values(dict);
                case IEnumerable list:
                    return new ScriptArray(list);
                default:
                    return new ScriptArray() {obj};
            }
        }
    }
}