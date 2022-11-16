---
title: Arm Aes Intrinsics
url: /doc/api/arm/aes/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Aes` features.

{{end}}


## vaesdq_u8

`vaesdq_u8`

uint8x16_t vaesdq_u8 (uint8x16_t data, uint8x16_t key)
A32: AESD.8 Qd, Qm
A64: AESD Vd.16B, Vn.16B


Instruction Documentation: [vaesdq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaesdq_u8)

## vaeseq_u8

`vaeseq_u8`

uint8x16_t vaeseq_u8 (uint8x16_t data, uint8x16_t key)
A32: AESE.8 Qd, Qm
A64: AESE Vd.16B, Vn.16B


Instruction Documentation: [vaeseq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaeseq_u8)

## vaesimcq_u8

`vaesimcq_u8`

uint8x16_t vaesimcq_u8 (uint8x16_t data)
A32: AESIMC.8 Qd, Qm
A64: AESIMC Vd.16B, Vn.16B


Instruction Documentation: [vaesimcq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaesimcq_u8)

## vaesmcq_u8

`vaesmcq_u8`

uint8x16_t vaesmcq_u8 (uint8x16_t data)
A32: AESMC.8 Qd, Qm
A64: AESMC V>.16B, Vn.16B


Instruction Documentation: [vaesmcq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaesmcq_u8)

## vmull_high_p64

`vmull_high_p64`

poly128_t vmull_high_p64 (poly64x2_t a, poly64x2_t b)
A32: VMULL.P8 Qd, Dn+1, Dm+1
A64: PMULL2 Vd.1Q, Vn.2D, Vm.2D


Instruction Documentation: [vmull_high_p64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_p64)

## vmull_p64

`vmull_p64`

poly128_t vmull_p64 (poly64_t a, poly64_t b)
A32: VMULL.P8 Qd, Dn, Dm
A64: PMULL Vd.1Q, Vn.1D, Vm.1D


Instruction Documentation: [vmull_p64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_p64)
