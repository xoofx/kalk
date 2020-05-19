using System;
using System.Runtime.CompilerServices;

namespace Kalk.Core.Helpers
{
    internal static class UnsafeHelpers
    {
        public static void BitCast<T>(ref T dest, int size, byte[] src)
        {
            var maxSize = Math.Min(size, src.Length);
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<T, byte>(ref dest), ref src[0], (uint)maxSize);
        }
    }
}