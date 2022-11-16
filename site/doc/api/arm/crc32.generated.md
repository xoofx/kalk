---
title: Arm Crc32 Intrinsics
url: /doc/api/arm/crc32/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Crc32` features.

{{end}}


## crc32b

`crc32b`

uint32_t __crc32b (uint32_t a, uint8_t b)
A32: CRC32B Rd, Rn, Rm
A64: CRC32B Wd, Wn, Wm


Instruction Documentation: [crc32b](https://developer.arm.com/architectures/instruction-sets/intrinsics/crc32b)

## crc32cb

`crc32cb`

uint32_t __crc32cb (uint32_t a, uint8_t b)
A32: CRC32CB Rd, Rn, Rm
A64: CRC32CB Wd, Wn, Wm


Instruction Documentation: [crc32cb](https://developer.arm.com/architectures/instruction-sets/intrinsics/crc32cb)

## crc32ch

`crc32ch`

uint32_t __crc32ch (uint32_t a, uint16_t b)
A32: CRC32CH Rd, Rn, Rm
A64: CRC32CH Wd, Wn, Wm


Instruction Documentation: [crc32ch](https://developer.arm.com/architectures/instruction-sets/intrinsics/crc32ch)

## crc32cw

`crc32cw`

uint32_t __crc32cw (uint32_t a, uint32_t b)
A32: CRC32CW Rd, Rn, Rm
A64: CRC32CW Wd, Wn, Wm


Instruction Documentation: [crc32cw](https://developer.arm.com/architectures/instruction-sets/intrinsics/crc32cw)

## crc32h

`crc32h`

uint32_t __crc32h (uint32_t a, uint16_t b)
A32: CRC32H Rd, Rn, Rm
A64: CRC32H Wd, Wn, Wm


Instruction Documentation: [crc32h](https://developer.arm.com/architectures/instruction-sets/intrinsics/crc32h)

## crc32w

`crc32w`

uint32_t __crc32w (uint32_t a, uint32_t b)
A32: CRC32W Rd, Rn, Rm
A64: CRC32W Wd, Wn, Wm


Instruction Documentation: [crc32w](https://developer.arm.com/architectures/instruction-sets/intrinsics/crc32w)
