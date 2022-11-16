namespace Kalk.Core.Modules.HardwareIntrinsics.X86
{
    public partial class SseIntrinsicsModule : IntrinsicsModuleBase
    {
        public SseIntrinsicsModule() : base("SSE") => RegisterFunctionsAuto();
    }

    public partial class SseX64IntrinsicsModule : IntrinsicsModuleBase
    {
        public SseX64IntrinsicsModule() : base("SSE (x64)") => RegisterFunctionsAuto();
    }
    
    public partial class Sse2IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse2IntrinsicsModule() : base("SSE2") => RegisterFunctionsAuto();
    }

    public partial class Sse2X64IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse2X64IntrinsicsModule() : base("SSE2 (x64)") => RegisterFunctionsAuto();
    }

    public partial class Sse3IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse3IntrinsicsModule() : base("SSE3") => RegisterFunctionsAuto();
    }

    public partial class Sse41IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse41IntrinsicsModule() : base("SSE4.1") => RegisterFunctionsAuto();
    }

    public partial class Sse41X64IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse41X64IntrinsicsModule() : base("SSE4.1 (x64)") => RegisterFunctionsAuto();
    }

    public partial class Sse42IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse42IntrinsicsModule() : base("SSE4.2") => RegisterFunctionsAuto();
    }
    
    public partial class Sse42X64IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sse42X64IntrinsicsModule() : base("SSE4.2 (x64)") => RegisterFunctionsAuto();
    }

    public partial class Ssse3IntrinsicsModule : IntrinsicsModuleBase
    {
        public Ssse3IntrinsicsModule() : base("SSSE3") => RegisterFunctionsAuto();
    }
    public partial class AvxIntrinsicsModule : IntrinsicsModuleBase
    {
        public AvxIntrinsicsModule() : base("AVX") => RegisterFunctionsAuto();
    }
    public partial class Avx2IntrinsicsModule : IntrinsicsModuleBase
    {
        public Avx2IntrinsicsModule() : base("AVX2") => RegisterFunctionsAuto();
    }

    public partial class AesIntrinsicsModule : IntrinsicsModuleBase
    {
        public AesIntrinsicsModule() : base("AES") => RegisterFunctionsAuto();
    }

    public partial class Bmi1IntrinsicsModule : IntrinsicsModuleBase
    {
        public Bmi1IntrinsicsModule() : base("BMI1") => RegisterFunctionsAuto();
    }

    public partial class Bmi1X64IntrinsicsModule : IntrinsicsModuleBase
    {
        public Bmi1X64IntrinsicsModule() : base("BMI1 (x64)") => RegisterFunctionsAuto();
    }
    
    public partial class Bmi2IntrinsicsModule : IntrinsicsModuleBase
    {
        public Bmi2IntrinsicsModule() : base("BMI2") => RegisterFunctionsAuto();
    }
    
    public partial class Bmi2X64IntrinsicsModule : IntrinsicsModuleBase
    {
        public Bmi2X64IntrinsicsModule() : base("BMI2 (x64)") => RegisterFunctionsAuto();
    }
}