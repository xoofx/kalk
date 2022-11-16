---
title: Arm Crc32Arm64 Intrinsics
url: /doc/api/arm/crc32arm64/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Crc32Arm64` features.

{{end}}


## crc32cd

`crc32cd`

uint32_t __crc32cd (uint32_t a, uint64_t b)
A64: CRC32CX Wd, Wn, Xm


Instruction Documentation: [crc32cd](https://developer.arm.com/architectures/instruction-sets/intrinsics/crc32cd)

## crc32d

`crc32d`

uint32_t __crc32d (uint32_t a, uint64_t b)
A64: CRC32X Wd, Wn, Xm


Instruction Documentation: [crc32d](https://developer.arm.com/architectures/instruction-sets/intrinsics/crc32d)
