using Kalk.Core.Modules.HardwareIntrinsics;

namespace Kalk.Core.Modules
{
    /// <summary>
    /// Module with CPU Hardware intrinsics.
    /// </summary>
    [KalkExportModule(ModuleName)]
    public partial class HardwareIntrinsicsModule : KalkModuleWithFunctions
    {
        private const string ModuleName = "HardwareIntrinsics";
        private const string CategoryIntrinsics = "Vector Hardware Intrinsics";
        
        public HardwareIntrinsicsModule() : base(ModuleName)
        {
            RegisterDocumentationAuto();
        }

        protected override void Import()
        {
            // X86
            if (System.Runtime.Intrinsics.X86.Sse.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.SseIntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse.X64.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.SseX64IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse2.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Sse2IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse2.X64.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Sse2X64IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse3.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Sse3IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Ssse3.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Ssse3IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse41.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Sse41IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse41.X64.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Sse41X64IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse42.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Sse42IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Sse42.X64.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Sse42X64IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Avx.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.AvxIntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Avx2.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Avx2IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Aes.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.AesIntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Bmi1.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Bmi1IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Bmi1.X64.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Bmi1X64IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Bmi2.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Bmi2IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.X86.Bmi2.X64.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.X86.Bmi2X64IntrinsicsModule>();
            }
            // Arm
            if (System.Runtime.Intrinsics.Arm.AdvSimd.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.Arm.AdvSimdIntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.Arm.AdvSimd.Arm64.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.Arm.AdvSimdArm64IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.Arm.Aes.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.Arm.AesIntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.Arm.Crc32.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.Arm.Crc32IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.Arm.Crc32.Arm64.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.Arm.Crc32Arm64IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.Arm.Sha1.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.Arm.Sha1IntrinsicsModule>();
            }
            if (System.Runtime.Intrinsics.Arm.Sha256.IsSupported)
            {
                DynamicRegister<HardwareIntrinsics.Arm.Sha256IntrinsicsModule>();
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