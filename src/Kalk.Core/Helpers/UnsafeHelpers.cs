using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Scriban.Runtime;

namespace Kalk.Core.Helpers
{
    internal static class UnsafeHelpers
    {
        public static unsafe object BitCast<T>(KalkNativeBuffer src) where T: unmanaged
        {
            var countItem = src.Count / sizeof(T);
            if (countItem == 0)
            {
                return default(T);
            }

            if (countItem == 1)
            {
                return MemoryMarshal.Cast<byte, T>(src.AsSpan())[0];
            }
            else
            {

                var array = MemoryMarshal.Cast<byte, T>(src.AsSpan());
                var scriptArray = new ScriptArray(array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    scriptArray[i] = array[i];
                }

                return scriptArray;
            }
        }
    }
}