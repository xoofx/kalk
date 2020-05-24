using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Kalk.Core.Modules.HardwareIntrinsics
{
    public partial class SseIntrinsicsModule : IntrinsicsModuleBase
    {
        public SseIntrinsicsModule() => RegisterFunctionsAuto();
    } 
    
    public partial class Sse2IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse2IntrinsicsModule() => RegisterFunctionsAuto();
    }

    public partial class Sse3IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse3IntrinsicsModule() => RegisterFunctionsAuto();
    }

    public partial class Sse41IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse41IntrinsicsModule() => RegisterFunctionsAuto();
    }

    public partial class Sse42IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse42IntrinsicsModule() => RegisterFunctionsAuto();
    }

    public partial class Ssse3IntrinsicsModule : IntrinsicsModuleBase
    {
        public Ssse3IntrinsicsModule() => RegisterFunctionsAuto();
    }
    public partial class AvxIntrinsicsModule : IntrinsicsModuleBase
    {
        public AvxIntrinsicsModule() => RegisterFunctionsAuto();
    }
    public partial class Avx2IntrinsicsModule : IntrinsicsModuleBase
    {
        public Avx2IntrinsicsModule() => RegisterFunctionsAuto();
    }

    public partial class AesIntrinsicsModule : IntrinsicsModuleBase
    {
        public AesIntrinsicsModule() => RegisterFunctionsAuto();
    }
    
    public partial class IntrinsicsModuleBase : KalkModuleWithFunctions
    {
        public const string CategoryIntrinsics = "Vector Hardware Intrinsics";
        
        public IntrinsicsModuleBase()
        {
        }

        protected object ProcessArgs<TArg1Base, TArg1, TResultBase, TResult>(object arg1, Func<TArg1, TResult> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TResultBase : unmanaged where TResult: unmanaged
        {
            var nativeArg1 = ToArg<TArg1Base, TArg1>(0, arg1);
            var nativeResult = func(nativeArg1);
            return ToResult<TResultBase, TResult>(nativeResult);
        }        
        
        protected object ProcessArgs<TArg1Base, TArg1, TArg2Base, TArg2, TResultBase, TResult>(object arg1, object arg2, Func<TArg1, TArg2, TResult> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TArg2Base : unmanaged where TArg2: unmanaged
            where TResultBase : unmanaged where TResult: unmanaged
        {
            var nativeArg1 = ToArg<TArg1Base, TArg1>(0, arg1);
            var nativeArg2 = ToArg<TArg2Base, TArg2>(1, arg2);
            var nativeResult = func(nativeArg1, nativeArg2);
            return ToResult<TResultBase, TResult>(nativeResult);
        }
        
        protected object ProcessArgs<TArg1Base, TArg1, TArg2Base, TArg2, TArg3Base, TArg3, TResultBase, TResult>(object arg1, object arg2, object arg3, Func<TArg1, TArg2, TArg3, TResult> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TArg2Base : unmanaged where TArg2: unmanaged
            where TArg3Base : unmanaged where TArg3: unmanaged
            where TResultBase : unmanaged where TResult: unmanaged
        {
            var nativeArg1 = ToArg<TArg1Base, TArg1>(0, arg1);
            var nativeArg2 = ToArg<TArg2Base, TArg2>(1, arg2);
            var nativeArg3 = ToArg<TArg3Base, TArg3>(2, arg3);
            var nativeResult = func(nativeArg1, nativeArg2, nativeArg3);
            return ToResult<TResultBase, TResult>(nativeResult);
        }
        
        private T ToArg<TBase, T>(int argIndex, object value) where T : unmanaged where TBase: unmanaged
        {
            var targetSize = Unsafe.SizeOf<T>();
            var baseElementSize = Unsafe.SizeOf<TBase>();
            var dimension = targetSize / baseElementSize;
            if (dimension == 1)
            {
                return Engine.ToObject<T>(argIndex, value);
            }
            else
            {
                Debug.Assert(dimension > 1);
                Span<TBase> elements = stackalloc TBase[dimension];
                if (value is KalkVector vec)
                {
                    var span = vec.AsSpan();
                    var minSize = Math.Min(targetSize, span.Length);
                    span = span.Slice(0, minSize);
                    span.CopyTo(MemoryMarshal.Cast<TBase, byte>(elements));
                }
                else
                {
                    var leftValueT = Engine.ToObject<TBase>(argIndex, value);
                    for (int i = 0; i < dimension; i++)
                    {
                        elements[i] = leftValueT;
                    }
                }
                return Unsafe.As<TBase, T>(ref elements[0]);
            }
        }
        
        private object ToResult<TBase, T>(T result) where T: unmanaged where TBase: unmanaged
        {
            var targetSize = Unsafe.SizeOf<T>();
            var baseElementSize = Unsafe.SizeOf<TBase>();
            var dimension = targetSize / baseElementSize;
            var span = MemoryMarshal.Cast<T, TBase>(MemoryMarshal.CreateSpan(ref result, 1));
            if (dimension == 1)
            {
                return span[0];
            }
            else
            {
                var vector = new KalkVector<TBase>(dimension);
                for (int i = 0; i < dimension; i++)
                {
                    vector[i] = span[i];
                }
                return vector;
            }
        }
    }
}