using Kalk.Core.Modules.HardwareIntrinsics;

namespace Kalk.Core.Modules
{
    public partial class HardwareIntrinsicsModule : KalkModuleWithFunctions
    {
        private const string CategoryIntrinsics = "Vector Hardware Intrinsics";
        
        public HardwareIntrinsicsModule()
        {
        }

        protected override void Import()
        {
            if (System.Runtime.Intrinsics.X86.Sse.IsSupported)
            {
                DynamicRegister<SseIntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse2.IsSupported)
            {
                DynamicRegister<Sse2IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse3.IsSupported)
            {
                DynamicRegister<Sse3IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse41.IsSupported)
            {
                DynamicRegister<Sse41IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse42.IsSupported)
            {
                DynamicRegister<Sse42IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Avx.IsSupported)
            {
                DynamicRegister<AvxIntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Avx2.IsSupported)
            {
                DynamicRegister<Avx2IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Aes.IsSupported)
            {
                DynamicRegister<AesIntrinsicsModule>();
            }
        }

        private void DynamicRegister<TModule>() where TModule : IntrinsicsModuleBase, new()
        {
            var module = new TModule();
            module.Initialize(Engine);
            module.InternalImport();
        }
    }
}