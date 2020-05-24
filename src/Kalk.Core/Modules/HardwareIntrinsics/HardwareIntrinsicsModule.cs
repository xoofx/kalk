using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Kalk.Core.Modules
{
    public partial class HardwareIntrinsicsModule : KalkModuleWithFunctions
    {
        private const string CategoryIntrinsics = "Vector Hardware Intrinsics";
        
        public HardwareIntrinsicsModule()
        {
        }

        //protected override void Initialize()
        //{
        //}

        //private bool TryToConvertToVectorType(SourceSpan span, object value, Type destinationtype, out object newvalue)
        //{
        //    if (destinationtype.Name.StartsWith("Vector") && destinationtype.Namespace == "System.Runtime.Intrinsics")
        //    {
        //        if (destinationtype == typeof(Vector128<float>))
        //        {
        //            var sourceVector = (KalkVector) value;
        //            var destVector = new Vector128<float>();
        //            for(int i = 0; i < destVector.)
        //            sourceVector.GetComponent(0)
        //        }
        //    }
        //    return false;
        //}


        protected override void DisplayImport()
        {
            Engine.WriteHighlightLine($"# 594 functions successfully imported from module `{Name}`.");
        }

        [KalkDoc("mm_add_ps", CategoryIntrinsics + " / SSE")]
        public object mm_add_ps(object left, object right) => ProcessArgs<float, Vector128<float>, float, Vector128<float>, float, Vector128<float>>(left, right, Sse.Add);


        [KalkDoc("mm_xor_ps", CategoryIntrinsics + " / SSE")]
        public object mm_xor_ps(object left, object right) => ProcessArgs<float, Vector128<float>, float, Vector128<float>, float, Vector128<float>>(left, right, Sse.Xor);

        
        private object ProcessArgs<TArg1Base, TArg1, TResultBase, TResult>(object left, object right, Func<TArg1, TResult> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TResultBase : unmanaged where TResult: unmanaged
        {
            var arg1 = ToArg<TArg1Base, TArg1>(0, left);
            var nativeResult = func(arg1);
            return ToResult<TResultBase, TResult>(nativeResult);
        }        
        
        private object ProcessArgs<TArg1Base, TArg1, TArg2Base, TArg2, TResultBase, TResult>(object left, object right, Func<TArg1, TArg2, TResult> func) 
            where TArg1Base : unmanaged where TArg1: unmanaged
            where TArg2Base : unmanaged where TArg2: unmanaged
            where TResultBase : unmanaged where TResult: unmanaged
        {
            var arg1 = ToArg<TArg1Base, TArg1>(0, left);
            var arg2 = ToArg<TArg2Base, TArg2>(1, right);
            var nativeResult = func(arg1, arg2);
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