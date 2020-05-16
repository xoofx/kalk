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
        private const string CategoryDevelopers = "Misc Functions";

        private void RegisterDeveloperFunctions()
        {
            RegisterVariable("ascii", AsciiTable, CategoryDevelopers);
        }

        /// <summary>
        /// Returns the ascii table or print
        /// </summary>
        [KalkDoc("ascii")]
        public KalkAsciiTable AsciiTable { get; }
   }
}