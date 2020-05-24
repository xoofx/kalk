using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using Scriban.Syntax;

namespace Kalk.Core.Modules.HardwareIntrinsics
{
   
    public abstract class IntrinsicsModuleBase : KalkModuleWithFunctions
    {
        public const string CategoryIntrinsics = "Vector Hardware Intrinsics";
        
        protected IntrinsicsModuleBase(string name) : base(name)
        {
        }
        
        protected void ProcessAction<TArg1Base, TArg1>(object arg1, Action<TArg1> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
        {
            var nativeArg1 = ToArg<TArg1Base, TArg1>(0, arg1);
            func(nativeArg1);
        }        
        
        protected void ProcessAction<TArg1Base, TArg1, TArg2Base, TArg2>(object arg1, object arg2, Action<TArg1, TArg2> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TArg2Base : unmanaged where TArg2: unmanaged
        {
            var nativeArg1 = ToArg<TArg1Base, TArg1>(0, arg1);
            var nativeArg2 = ToArg<TArg2Base, TArg2>(1, arg2);
            func(nativeArg1, nativeArg2);
        }
        
        protected void ProcessAction<TArg1Base, TArg1, TArg2Base, TArg2, TArg3Base, TArg3>(object arg1, object arg2, object arg3, Action<TArg1, TArg2, TArg3> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TArg2Base : unmanaged where TArg2: unmanaged
            where TArg3Base : unmanaged where TArg3: unmanaged
        {
            var nativeArg1 = ToArg<TArg1Base, TArg1>(0, arg1);
            var nativeArg2 = ToArg<TArg2Base, TArg2>(1, arg2);
            var nativeArg3 = ToArg<TArg3Base, TArg3>(2, arg3);
            func(nativeArg1, nativeArg2, nativeArg3);
        }        

        protected object ProcessFunc<TArg1Base, TArg1, TResultBase, TResult>(object arg1, Func<TArg1, TResult> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TResultBase : unmanaged where TResult: unmanaged
        {
            var nativeArg1 = ToArg<TArg1Base, TArg1>(0, arg1);
            var nativeResult = func(nativeArg1);
            return ToResult<TResultBase, TResult>(nativeResult);
        }        
        
        protected object ProcessFunc<TArg1Base, TArg1, TArg2Base, TArg2, TResultBase, TResult>(object arg1, object arg2, Func<TArg1, TArg2, TResult> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TArg2Base : unmanaged where TArg2: unmanaged
            where TResultBase : unmanaged where TResult: unmanaged
        {
            var nativeArg1 = ToArg<TArg1Base, TArg1>(0, arg1);
            var nativeArg2 = ToArg<TArg2Base, TArg2>(1, arg2);
            var nativeResult = func(nativeArg1, nativeArg2);
            return ToResult<TResultBase, TResult>(nativeResult);
        }
        
        protected object ProcessFunc<TArg1Base, TArg1, TArg2Base, TArg2, TArg3Base, TArg3, TResultBase, TResult>(object arg1, object arg2, object arg3, Func<TArg1, TArg2, TArg3, TResult> func) 
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
            if (typeof(T) == typeof(IntPtr))
            {
                var buffer = value as KalkByteBuffer;
                if (buffer == null)
                {
                    throw new ScriptArgumentException(argIndex, "Expecting a byte buffer. Use malloc(size) to pass data to this argument.");
                }

                var ptr = buffer.Lock();
                var rawPtr = Unsafe.As<IntPtr, T>(ref ptr);
                return rawPtr;
            }
            
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