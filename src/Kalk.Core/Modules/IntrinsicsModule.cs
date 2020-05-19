using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Consolus;
using Scriban;
using Scriban.Functions;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core.Modules
{
    public partial class IntrinsicsModule : KalkModule
    {
        private const string CategoryIntrinsics = "Vector HW Intrinsics Functions";

        private void RegisterIntrinsics()
        {
            //Vector256<short> value = Vector256.Create((byte)1).As<byte, short>();
            //var result = Avx2.Add(value, value);
            //for (int i = 0; i < Vector256<short>.Count ; i++)
            //{
            //    Console.WriteLine(result.GetElement(i));
            //}
        }
   }
}