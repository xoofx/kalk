namespace Kalk.Core.Modules.HardwareIntrinsics.Arm
{
    public partial class AdvSimdIntrinsicsModule : IntrinsicsModuleBase
    {
        public AdvSimdIntrinsicsModule() : base("ARM") => RegisterFunctionsAuto();
    }

    public partial class AdvSimdArm64IntrinsicsModule : IntrinsicsModuleBase
    {
        public AdvSimdArm64IntrinsicsModule() : base("ARM64") => RegisterFunctionsAuto();
    }
    
    public partial class AesIntrinsicsModule : IntrinsicsModuleBase
    {
        public AesIntrinsicsModule() : base("ARM AES") => RegisterFunctionsAuto();
    }

    public partial class Crc32IntrinsicsModule : IntrinsicsModuleBase
    {
        public Crc32IntrinsicsModule() : base("ARM Crc32") => RegisterFunctionsAuto();
    }

    public partial class Crc32Arm64IntrinsicsModule : IntrinsicsModuleBase
    {
        public Crc32Arm64IntrinsicsModule() : base("ARM64 Crc32") => RegisterFunctionsAuto();
    }

    public partial class Sha1IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sha1IntrinsicsModule() : base("ARM Sha1") => RegisterFunctionsAuto();
    }

    public partial class Sha256IntrinsicsModule : IntrinsicsModuleBase
    {
        public Sha256IntrinsicsModule() : base("ARM Sha256") => RegisterFunctionsAuto();
    }
}