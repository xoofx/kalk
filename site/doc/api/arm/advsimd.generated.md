---
title: Arm AdvSimd Intrinsics
url: /doc/api/arm/advsimd/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `AdvSimd` features.

{{end}}


## vaba_s16

`vaba_s16`

int16x4_t vaba_s16 (int16x4_t a, int16x4_t b, int16x4_t c)
A32: VABA.S16 Dd, Dn, Dm
A64: SABA Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vaba_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaba_s16)

## vaba_s32

`vaba_s32`

int32x2_t vaba_s32 (int32x2_t a, int32x2_t b, int32x2_t c)
A32: VABA.S32 Dd, Dn, Dm
A64: SABA Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vaba_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaba_s32)

## vaba_s8

`vaba_s8`

int8x8_t vaba_s8 (int8x8_t a, int8x8_t b, int8x8_t c)
A32: VABA.S8 Dd, Dn, Dm
A64: SABA Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vaba_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaba_s8)

## vaba_u16

`vaba_u16`

uint16x4_t vaba_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t c)
A32: VABA.U16 Dd, Dn, Dm
A64: UABA Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vaba_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaba_u16)

## vaba_u32

`vaba_u32`

uint32x2_t vaba_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t c)
A32: VABA.U32 Dd, Dn, Dm
A64: UABA Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vaba_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaba_u32)

## vaba_u8

`vaba_u8`

uint8x8_t vaba_u8 (uint8x8_t a, uint8x8_t b, uint8x8_t c)
A32: VABA.U8 Dd, Dn, Dm
A64: UABA Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vaba_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaba_u8)

## vabal_high_s16

`vabal_high_s16`

int32x4_t vabal_high_s16 (int32x4_t a, int16x8_t b, int16x8_t c)
A32: VABAL.S16 Qd, Dn+1, Dm+1
A64: SABAL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vabal_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_high_s16)

## vabal_high_s32

`vabal_high_s32`

int64x2_t vabal_high_s32 (int64x2_t a, int32x4_t b, int32x4_t c)
A32: VABAL.S32 Qd, Dn+1, Dm+1
A64: SABAL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vabal_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_high_s32)

## vabal_high_s8

`vabal_high_s8`

int16x8_t vabal_high_s8 (int16x8_t a, int8x16_t b, int8x16_t c)
A32: VABAL.S8 Qd, Dn+1, Dm+1
A64: SABAL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vabal_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_high_s8)

## vabal_high_u16

`vabal_high_u16`

uint32x4_t vabal_high_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t c)
A32: VABAL.U16 Qd, Dn+1, Dm+1
A64: UABAL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vabal_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_high_u16)

## vabal_high_u32

`vabal_high_u32`

uint64x2_t vabal_high_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t c)
A32: VABAL.U32 Qd, Dn+1, Dm+1
A64: UABAL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vabal_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_high_u32)

## vabal_high_u8

`vabal_high_u8`

uint16x8_t vabal_high_u8 (uint16x8_t a, uint8x16_t b, uint8x16_t c)
A32: VABAL.U8 Qd, Dn+1, Dm+1
A64: UABAL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vabal_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_high_u8)

## vabal_s16

`vabal_s16`

int32x4_t vabal_s16 (int32x4_t a, int16x4_t b, int16x4_t c)
A32: VABAL.S16 Qd, Dn, Dm
A64: SABAL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vabal_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_s16)

## vabal_s32

`vabal_s32`

int64x2_t vabal_s32 (int64x2_t a, int32x2_t b, int32x2_t c)
A32: VABAL.S32 Qd, Dn, Dm
A64: SABAL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vabal_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_s32)

## vabal_s8

`vabal_s8`

int16x8_t vabal_s8 (int16x8_t a, int8x8_t b, int8x8_t c)
A32: VABAL.S8 Qd, Dn, Dm
A64: SABAL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vabal_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_s8)

## vabal_u16

`vabal_u16`

uint32x4_t vabal_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t c)
A32: VABAL.U16 Qd, Dn, Dm
A64: UABAL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vabal_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_u16)

## vabal_u32

`vabal_u32`

uint64x2_t vabal_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t c)
A32: VABAL.U32 Qd, Dn, Dm
A64: UABAL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vabal_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_u32)

## vabal_u8

`vabal_u8`

uint16x8_t vabal_u8 (uint16x8_t a, uint8x8_t b, uint8x8_t c)
A32: VABAL.U8 Qd, Dn, Dm
A64: UABAL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vabal_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabal_u8)

## vabaq_s16

`vabaq_s16`

int16x8_t vabaq_s16 (int16x8_t a, int16x8_t b, int16x8_t c)
A32: VABA.S16 Qd, Qn, Qm
A64: SABA Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vabaq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabaq_s16)

## vabaq_s32

`vabaq_s32`

int32x4_t vabaq_s32 (int32x4_t a, int32x4_t b, int32x4_t c)
A32: VABA.S32 Qd, Qn, Qm
A64: SABA Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vabaq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabaq_s32)

## vabaq_s8

`vabaq_s8`

int8x16_t vabaq_s8 (int8x16_t a, int8x16_t b, int8x16_t c)
A32: VABA.S8 Qd, Qn, Qm
A64: SABA Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vabaq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabaq_s8)

## vabaq_u16

`vabaq_u16`

uint16x8_t vabaq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t c)
A32: VABA.U16 Qd, Qn, Qm
A64: UABA Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vabaq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabaq_u16)

## vabaq_u32

`vabaq_u32`

uint32x4_t vabaq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t c)
A32: VABA.U32 Qd, Qn, Qm
A64: UABA Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vabaq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabaq_u32)

## vabaq_u8

`vabaq_u8`

uint8x16_t vabaq_u8 (uint8x16_t a, uint8x16_t b, uint8x16_t c)
A32: VABA.U8 Qd, Qn, Qm
A64: UABA Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vabaq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabaq_u8)

## vabd_f32

`vabd_f32`

float32x2_t vabd_f32 (float32x2_t a, float32x2_t b)
A32: VABD.F32 Dd, Dn, Dm
A64: FABD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vabd_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabd_f32)

## vabd_s16

`vabd_s16`

int16x4_t vabd_s16 (int16x4_t a, int16x4_t b)
A32: VABD.S16 Dd, Dn, Dm
A64: SABD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vabd_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabd_s16)

## vabd_s32

`vabd_s32`

int32x2_t vabd_s32 (int32x2_t a, int32x2_t b)
A32: VABD.S32 Dd, Dn, Dm
A64: SABD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vabd_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabd_s32)

## vabd_s8

`vabd_s8`

int8x8_t vabd_s8 (int8x8_t a, int8x8_t b)
A32: VABD.S8 Dd, Dn, Dm
A64: SABD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vabd_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabd_s8)

## vabd_u16

`vabd_u16`

uint16x4_t vabd_u16 (uint16x4_t a, uint16x4_t b)
A32: VABD.U16 Dd, Dn, Dm
A64: UABD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vabd_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabd_u16)

## vabd_u32

`vabd_u32`

uint32x2_t vabd_u32 (uint32x2_t a, uint32x2_t b)
A32: VABD.U32 Dd, Dn, Dm
A64: UABD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vabd_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabd_u32)

## vabd_u8

`vabd_u8`

uint8x8_t vabd_u8 (uint8x8_t a, uint8x8_t b)
A32: VABD.U8 Dd, Dn, Dm
A64: UABD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vabd_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabd_u8)

## vabdl_high_s16

`vabdl_high_s16`

int32x4_t vabdl_high_s16 (int16x8_t a, int16x8_t b)
A32: VABDL.S16 Qd, Dn+1, Dm+1
A64: SABDL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vabdl_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_high_s16)

## vabdl_high_s32

`vabdl_high_s32`

int64x2_t vabdl_high_s32 (int32x4_t a, int32x4_t b)
A32: VABDL.S32 Qd, Dn+1, Dm+1
A64: SABDL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vabdl_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_high_s32)

## vabdl_high_s8

`vabdl_high_s8`

int16x8_t vabdl_high_s8 (int8x16_t a, int8x16_t b)
A32: VABDL.S8 Qd, Dn+1, Dm+1
A64: SABDL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vabdl_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_high_s8)

## vabdl_high_u16

`vabdl_high_u16`

uint32x4_t vabdl_high_u16 (uint16x8_t a, uint16x8_t b)
A32: VABDL.U16 Qd, Dn+1, Dm+1
A64: UABDL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vabdl_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_high_u16)

## vabdl_high_u32

`vabdl_high_u32`

uint64x2_t vabdl_high_u32 (uint32x4_t a, uint32x4_t b)
A32: VABDL.U32 Qd, Dn+1, Dm+1
A64: UABDL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vabdl_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_high_u32)

## vabdl_high_u8

`vabdl_high_u8`

uint16x8_t vabdl_high_u8 (uint8x16_t a, uint8x16_t b)
A32: VABDL.U8 Qd, Dn+1, Dm+1
A64: UABDL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vabdl_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_high_u8)

## vabdl_s16

`vabdl_s16`

int32x4_t vabdl_s16 (int16x4_t a, int16x4_t b)
A32: VABDL.S16 Qd, Dn, Dm
A64: SABDL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vabdl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_s16)

## vabdl_s32

`vabdl_s32`

int64x2_t vabdl_s32 (int32x2_t a, int32x2_t b)
A32: VABDL.S32 Qd, Dn, Dm
A64: SABDL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vabdl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_s32)

## vabdl_s8

`vabdl_s8`

int16x8_t vabdl_s8 (int8x8_t a, int8x8_t b)
A32: VABDL.S8 Qd, Dn, Dm
A64: SABDL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vabdl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_s8)

## vabdl_u16

`vabdl_u16`

uint32x4_t vabdl_u16 (uint16x4_t a, uint16x4_t b)
A32: VABDL.U16 Qd, Dn, Dm
A64: UABDL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vabdl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_u16)

## vabdl_u32

`vabdl_u32`

uint64x2_t vabdl_u32 (uint32x2_t a, uint32x2_t b)
A32: VABDL.U32 Qd, Dn, Dm
A64: UABDL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vabdl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_u32)

## vabdl_u8

`vabdl_u8`

uint16x8_t vabdl_u8 (uint8x8_t a, uint8x8_t b)
A32: VABDL.U8 Qd, Dn, Dm
A64: UABDL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vabdl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdl_u8)

## vabdq_f32

`vabdq_f32`

float32x4_t vabdq_f32 (float32x4_t a, float32x4_t b)
A32: VABD.F32 Qd, Qn, Qm
A64: FABD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vabdq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdq_f32)

## vabdq_s16

`vabdq_s16`

int16x8_t vabdq_s16 (int16x8_t a, int16x8_t b)
A32: VABD.S16 Qd, Qn, Qm
A64: SABD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vabdq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdq_s16)

## vabdq_s32

`vabdq_s32`

int32x4_t vabdq_s32 (int32x4_t a, int32x4_t b)
A32: VABD.S32 Qd, Qn, Qm
A64: SABD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vabdq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdq_s32)

## vabdq_s8

`vabdq_s8`

int8x16_t vabdq_s8 (int8x16_t a, int8x16_t b)
A32: VABD.S8 Qd, Qn, Qm
A64: SABD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vabdq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdq_s8)

## vabdq_u16

`vabdq_u16`

uint16x8_t vabdq_u16 (uint16x8_t a, uint16x8_t b)
A32: VABD.U16 Qd, Qn, Qm
A64: UABD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vabdq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdq_u16)

## vabdq_u32

`vabdq_u32`

uint32x4_t vabdq_u32 (uint32x4_t a, uint32x4_t b)
A32: VABD.U32 Qd, Qn, Qm
A64: UABD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vabdq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdq_u32)

## vabdq_u8

`vabdq_u8`

uint8x16_t vabdq_u8 (uint8x16_t a, uint8x16_t b)
A32: VABD.U8 Qd, Qn, Qm
A64: UABD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vabdq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdq_u8)

## vabs_f32

`vabs_f32`

float32x2_t vabs_f32 (float32x2_t a)
A32: VABS.F32 Dd, Dm
A64: FABS Vd.2S, Vn.2S


Instruction Documentation: [vabs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabs_f32)

## vabs_f64

`vabs_f64`

float64x1_t vabs_f64 (float64x1_t a)
A32: VABS.F64 Dd, Dm
A64: FABS Dd, Dn


Instruction Documentation: [vabs_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabs_f64)

## vabs_s16

`vabs_s16`

int16x4_t vabs_s16 (int16x4_t a)
A32: VABS.S16 Dd, Dm
A64: ABS Vd.4H, Vn.4H


Instruction Documentation: [vabs_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabs_s16)

## vabs_s32

`vabs_s32`

int32x2_t vabs_s32 (int32x2_t a)
A32: VABS.S32 Dd, Dm
A64: ABS Vd.2S, Vn.2S


Instruction Documentation: [vabs_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabs_s32)

## vabs_s8

`vabs_s8`

int8x8_t vabs_s8 (int8x8_t a)
A32: VABS.S8 Dd, Dm
A64: ABS Vd.8B, Vn.8B


Instruction Documentation: [vabs_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabs_s8)

## vabsq_f32

`vabsq_f32`

float32x4_t vabsq_f32 (float32x4_t a)
A32: VABS.F32 Qd, Qm
A64: FABS Vd.4S, Vn.4S


Instruction Documentation: [vabsq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabsq_f32)

## vabsq_s16

`vabsq_s16`

int16x8_t vabsq_s16 (int16x8_t a)
A32: VABS.S16 Qd, Qm
A64: ABS Vd.8H, Vn.8H


Instruction Documentation: [vabsq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabsq_s16)

## vabsq_s32

`vabsq_s32`

int32x4_t vabsq_s32 (int32x4_t a)
A32: VABS.S32 Qd, Qm
A64: ABS Vd.4S, Vn.4S


Instruction Documentation: [vabsq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabsq_s32)

## vabsq_s8

`vabsq_s8`

int8x16_t vabsq_s8 (int8x16_t a)
A32: VABS.S8 Qd, Qm
A64: ABS Vd.16B, Vn.16B


Instruction Documentation: [vabsq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabsq_s8)

## vabss_f32

`vabss_f32`

float32_t vabss_f32 (float32_t a)
A32: VABS.F32 Sd, Sm
A64: FABS Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vabss_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabss_f32)

## vadd_f32

`vadd_f32`

float32x2_t vadd_f32 (float32x2_t a, float32x2_t b)
A32: VADD.F32 Dd, Dn, Dm
A64: FADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vadd_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_f32)

## vadd_f64

`vadd_f64`

float64x1_t vadd_f64 (float64x1_t a, float64x1_t b)
A32: VADD.F64 Dd, Dn, Dm
A64: FADD Dd, Dn, Dm


Instruction Documentation: [vadd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_f64)

## vadd_s16

`vadd_s16`

int16x4_t vadd_s16 (int16x4_t a, int16x4_t b)
A32: VADD.I16 Dd, Dn, Dm
A64: ADD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vadd_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_s16)

## vadd_s32

`vadd_s32`

int32x2_t vadd_s32 (int32x2_t a, int32x2_t b)
A32: VADD.I32 Dd, Dn, Dm
A64: ADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vadd_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_s32)

## vadd_s64

`vadd_s64`

int64x1_t vadd_s64 (int64x1_t a, int64x1_t b)
A32: VADD.I64 Dd, Dn, Dm
A64: ADD Dd, Dn, Dm


Instruction Documentation: [vadd_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_s64)

## vadd_s8

`vadd_s8`

int8x8_t vadd_s8 (int8x8_t a, int8x8_t b)
A32: VADD.I8 Dd, Dn, Dm
A64: ADD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vadd_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_s8)

## vadd_u16

`vadd_u16`

uint16x4_t vadd_u16 (uint16x4_t a, uint16x4_t b)
A32: VADD.I16 Dd, Dn, Dm
A64: ADD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vadd_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_u16)

## vadd_u32

`vadd_u32`

uint32x2_t vadd_u32 (uint32x2_t a, uint32x2_t b)
A32: VADD.I32 Dd, Dn, Dm
A64: ADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vadd_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_u32)

## vadd_u64

`vadd_u64`

uint64x1_t vadd_u64 (uint64x1_t a, uint64x1_t b)
A32: VADD.I64 Dd, Dn, Dm
A64: ADD Dd, Dn, Dm


Instruction Documentation: [vadd_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_u64)

## vadd_u8

`vadd_u8`

uint8x8_t vadd_u8 (uint8x8_t a, uint8x8_t b)
A32: VADD.I8 Dd, Dn, Dm
A64: ADD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vadd_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadd_u8)

## vaddhn_high_s16

`vaddhn_high_s16`

int8x16_t vaddhn_high_s16 (int8x8_t r, int16x8_t a, int16x8_t b)
A32: VADDHN.I16 Dd+1, Qn, Qm
A64: ADDHN2 Vd.16B, Vn.8H, Vm.8H


Instruction Documentation: [vaddhn_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_high_s16)

## vaddhn_high_s32

`vaddhn_high_s32`

int16x8_t vaddhn_high_s32 (int16x4_t r, int32x4_t a, int32x4_t b)
A32: VADDHN.I32 Dd+1, Qn, Qm
A64: ADDHN2 Vd.8H, Vn.4S, Vm.4S


Instruction Documentation: [vaddhn_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_high_s32)

## vaddhn_high_s64

`vaddhn_high_s64`

int32x4_t vaddhn_high_s64 (int32x2_t r, int64x2_t a, int64x2_t b)
A32: VADDHN.I64 Dd+1, Qn, Qm
A64: ADDHN2 Vd.4S, Vn.2D, Vm.2D


Instruction Documentation: [vaddhn_high_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_high_s64)

## vaddhn_high_u16

`vaddhn_high_u16`

uint8x16_t vaddhn_high_u16 (uint8x8_t r, uint16x8_t a, uint16x8_t b)
A32: VADDHN.I16 Dd+1, Qn, Qm
A64: ADDHN2 Vd.16B, Vn.8H, Vm.8H


Instruction Documentation: [vaddhn_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_high_u16)

## vaddhn_high_u32

`vaddhn_high_u32`

uint16x8_t vaddhn_high_u32 (uint16x4_t r, uint32x4_t a, uint32x4_t b)
A32: VADDHN.I32 Dd+1, Qn, Qm
A64: ADDHN2 Vd.8H, Vn.4S, Vm.4S


Instruction Documentation: [vaddhn_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_high_u32)

## vaddhn_high_u64

`vaddhn_high_u64`

uint32x4_t vaddhn_high_u64 (uint32x2_t r, uint64x2_t a, uint64x2_t b)
A32: VADDHN.I64 Dd+1, Qn, Qm
A64: ADDHN2 Vd.4S, Vn.2D, Vm.2D


Instruction Documentation: [vaddhn_high_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_high_u64)

## vaddhn_s16

`vaddhn_s16`

int8x8_t vaddhn_s16 (int16x8_t a, int16x8_t b)
A32: VADDHN.I16 Dd, Qn, Qm
A64: ADDHN Vd.8B, Vn.8H, Vm.8H


Instruction Documentation: [vaddhn_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_s16)

## vaddhn_s32

`vaddhn_s32`

int16x4_t vaddhn_s32 (int32x4_t a, int32x4_t b)
A32: VADDHN.I32 Dd, Qn, Qm
A64: ADDHN Vd.4H, Vn.4S, Vm.4S


Instruction Documentation: [vaddhn_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_s32)

## vaddhn_s64

`vaddhn_s64`

int32x2_t vaddhn_s64 (int64x2_t a, int64x2_t b)
A32: VADDHN.I64 Dd, Qn, Qm
A64: ADDHN Vd.2S, Vn.2D, Vm.2D


Instruction Documentation: [vaddhn_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_s64)

## vaddhn_u16

`vaddhn_u16`

uint8x8_t vaddhn_u16 (uint16x8_t a, uint16x8_t b)
A32: VADDHN.I16 Dd, Qn, Qm
A64: ADDHN Vd.8B, Vn.8H, Vm.8H


Instruction Documentation: [vaddhn_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_u16)

## vaddhn_u32

`vaddhn_u32`

uint16x4_t vaddhn_u32 (uint32x4_t a, uint32x4_t b)
A32: VADDHN.I32 Dd, Qn, Qm
A64: ADDHN Vd.4H, Vn.4S, Vm.4S


Instruction Documentation: [vaddhn_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_u32)

## vaddhn_u64

`vaddhn_u64`

uint32x2_t vaddhn_u64 (uint64x2_t a, uint64x2_t b)
A32: VADDHN.I64 Dd, Qn, Qm
A64: ADDHN Vd.2S, Vn.2D, Vm.2D


Instruction Documentation: [vaddhn_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddhn_u64)

## vaddl_high_s16

`vaddl_high_s16`

int32x4_t vaddl_high_s16 (int16x8_t a, int16x8_t b)
A32: VADDL.S16 Qd, Dn+1, Dm+1
A64: SADDL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vaddl_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_high_s16)

## vaddl_high_s32

`vaddl_high_s32`

int64x2_t vaddl_high_s32 (int32x4_t a, int32x4_t b)
A32: VADDL.S32 Qd, Dn+1, Dm+1
A64: SADDL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vaddl_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_high_s32)

## vaddl_high_s8

`vaddl_high_s8`

int16x8_t vaddl_high_s8 (int8x16_t a, int8x16_t b)
A32: VADDL.S8 Qd, Dn+1, Dm+1
A64: SADDL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vaddl_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_high_s8)

## vaddl_high_u16

`vaddl_high_u16`

uint32x4_t vaddl_high_u16 (uint16x8_t a, uint16x8_t b)
A32: VADDL.U16 Qd, Dn+1, Dm+1
A64: UADDL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vaddl_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_high_u16)

## vaddl_high_u32

`vaddl_high_u32`

uint64x2_t vaddl_high_u32 (uint32x4_t a, uint32x4_t b)
A32: VADDL.U32 Qd, Dn+1, Dm+1
A64: UADDL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vaddl_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_high_u32)

## vaddl_high_u8

`vaddl_high_u8`

uint16x8_t vaddl_high_u8 (uint8x16_t a, uint8x16_t b)
A32: VADDL.U8 Qd, Dn+1, Dm+1
A64: UADDL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vaddl_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_high_u8)

## vaddl_s16

`vaddl_s16`

int32x4_t vaddl_s16 (int16x4_t a, int16x4_t b)
A32: VADDL.S16 Qd, Dn, Dm
A64: SADDL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vaddl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_s16)

## vaddl_s32

`vaddl_s32`

int64x2_t vaddl_s32 (int32x2_t a, int32x2_t b)
A32: VADDL.S32 Qd, Dn, Dm
A64: SADDL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vaddl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_s32)

## vaddl_s8

`vaddl_s8`

int16x8_t vaddl_s8 (int8x8_t a, int8x8_t b)
A32: VADDL.S8 Qd, Dn, Dm
A64: SADDL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vaddl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_s8)

## vaddl_u16

`vaddl_u16`

uint32x4_t vaddl_u16 (uint16x4_t a, uint16x4_t b)
A32: VADDL.U16 Qd, Dn, Dm
A64: UADDL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vaddl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_u16)

## vaddl_u32

`vaddl_u32`

uint64x2_t vaddl_u32 (uint32x2_t a, uint32x2_t b)
A32: VADDL.U32 Qd, Dn, Dm
A64: UADDL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vaddl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_u32)

## vaddl_u8

`vaddl_u8`

uint16x8_t vaddl_u8 (uint8x8_t a, uint8x8_t b)
A32: VADDL.U8 Qd, Dn, Dm
A64: UADDL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vaddl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddl_u8)

## vaddq_f32

`vaddq_f32`

float32x4_t vaddq_f32 (float32x4_t a, float32x4_t b)
A32: VADD.F32 Qd, Qn, Qm
A64: FADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vaddq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_f32)

## vaddq_s16

`vaddq_s16`

int16x8_t vaddq_s16 (int16x8_t a, int16x8_t b)
A32: VADD.I16 Qd, Qn, Qm
A64: ADD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vaddq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_s16)

## vaddq_s32

`vaddq_s32`

int32x4_t vaddq_s32 (int32x4_t a, int32x4_t b)
A32: VADD.I32 Qd, Qn, Qm
A64: ADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vaddq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_s32)

## vaddq_s64

`vaddq_s64`

int64x2_t vaddq_s64 (int64x2_t a, int64x2_t b)
A32: VADD.I64 Qd, Qn, Qm
A64: ADD Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vaddq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_s64)

## vaddq_s8

`vaddq_s8`

int8x16_t vaddq_s8 (int8x16_t a, int8x16_t b)
A32: VADD.I8 Qd, Qn, Qm
A64: ADD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vaddq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_s8)

## vaddq_u16

`vaddq_u16`

uint16x8_t vaddq_u16 (uint16x8_t a, uint16x8_t b)
A32: VADD.I16 Qd, Qn, Qm
A64: ADD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vaddq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_u16)

## vaddq_u32

`vaddq_u32`

uint32x4_t vaddq_u32 (uint32x4_t a, uint32x4_t b)
A32: VADD.I32 Qd, Qn, Qm
A64: ADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vaddq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_u32)

## vaddq_u64

`vaddq_u64`

uint64x2_t vaddq_u64 (uint64x2_t a, uint64x2_t b)
A32: VADD.I64 Qd, Qn, Qm
A64: ADD Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vaddq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_u64)

## vaddq_u8

`vaddq_u8`

uint8x16_t vaddq_u8 (uint8x16_t a, uint8x16_t b)
A32: VADD.I8 Qd, Qn, Qm
A64: ADD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vaddq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_u8)

## vadds_f32

`vadds_f32`

float32_t vadds_f32 (float32_t a, float32_t b)
A32: VADD.F32 Sd, Sn, Sm
A64: FADD Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vadds_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vadds_f32)

## vaddw_high_s16

`vaddw_high_s16`

int32x4_t vaddw_high_s16 (int32x4_t a, int16x8_t b)
A32: VADDW.S16 Qd, Qn, Dm+1
A64: SADDW2 Vd.4S, Vn.4S, Vm.8H


Instruction Documentation: [vaddw_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_high_s16)

## vaddw_high_s32

`vaddw_high_s32`

int64x2_t vaddw_high_s32 (int64x2_t a, int32x4_t b)
A32: VADDW.S32 Qd, Qn, Dm+1
A64: SADDW2 Vd.2D, Vn.2D, Vm.4S


Instruction Documentation: [vaddw_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_high_s32)

## vaddw_high_s8

`vaddw_high_s8`

int16x8_t vaddw_high_s8 (int16x8_t a, int8x16_t b)
A32: VADDW.S8 Qd, Qn, Dm+1
A64: SADDW2 Vd.8H, Vn.8H, Vm.16B


Instruction Documentation: [vaddw_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_high_s8)

## vaddw_high_u16

`vaddw_high_u16`

uint32x4_t vaddw_high_u16 (uint32x4_t a, uint16x8_t b)
A32: VADDW.U16 Qd, Qn, Dm+1
A64: UADDW2 Vd.4S, Vn.4S, Vm.8H


Instruction Documentation: [vaddw_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_high_u16)

## vaddw_high_u32

`vaddw_high_u32`

uint64x2_t vaddw_high_u32 (uint64x2_t a, uint32x4_t b)
A32: VADDW.U32 Qd, Qn, Dm+1
A64: UADDW2 Vd.2D, Vn.2D, Vm.4S


Instruction Documentation: [vaddw_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_high_u32)

## vaddw_high_u8

`vaddw_high_u8`

uint16x8_t vaddw_high_u8 (uint16x8_t a, uint8x16_t b)
A32: VADDW.U8 Qd, Qn, Dm+1
A64: UADDW2 Vd.8H, Vn.8H, Vm.16B


Instruction Documentation: [vaddw_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_high_u8)

## vaddw_s16

`vaddw_s16`

int32x4_t vaddw_s16 (int32x4_t a, int16x4_t b)
A32: VADDW.S16 Qd, Qn, Dm
A64: SADDW Vd.4S, Vn.4S, Vm.4H


Instruction Documentation: [vaddw_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_s16)

## vaddw_s32

`vaddw_s32`

int64x2_t vaddw_s32 (int64x2_t a, int32x2_t b)
A32: VADDW.S32 Qd, Qn, Dm
A64: SADDW Vd.2D, Vn.2D, Vm.2S


Instruction Documentation: [vaddw_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_s32)

## vaddw_s8

`vaddw_s8`

int16x8_t vaddw_s8 (int16x8_t a, int8x8_t b)
A32: VADDW.S8 Qd, Qn, Dm
A64: SADDW Vd.8H, Vn.8H, Vm.8B


Instruction Documentation: [vaddw_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_s8)

## vaddw_u16

`vaddw_u16`

uint32x4_t vaddw_u16 (uint32x4_t a, uint16x4_t b)
A32: VADDW.U16 Qd, Qn, Dm
A64: UADDW Vd.4S, Vn.4S, Vm.4H


Instruction Documentation: [vaddw_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_u16)

## vaddw_u32

`vaddw_u32`

uint64x2_t vaddw_u32 (uint64x2_t a, uint32x2_t b)
A32: VADDW.U32 Qd, Qn, Dm
A64: UADDW Vd.2D, Vn.2D, Vm.2S


Instruction Documentation: [vaddw_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_u32)

## vaddw_u8

`vaddw_u8`

uint16x8_t vaddw_u8 (uint16x8_t a, uint8x8_t b)
A32: VADDW.U8 Qd, Qn, Dm
A64: UADDW Vd.8H, Vn.8H, Vm.8B


Instruction Documentation: [vaddw_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddw_u8)

## vand_f32

`vand_f32`

float32x2_t vand_f32 (float32x2_t a, float32x2_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vand_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_f32)

## vand_f64

`vand_f64`

float64x1_t vand_f64 (float64x1_t a, float64x1_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vand_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_f64)

## vand_s16

`vand_s16`

int16x4_t vand_s16 (int16x4_t a, int16x4_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vand_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_s16)

## vand_s32

`vand_s32`

int32x2_t vand_s32 (int32x2_t a, int32x2_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vand_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_s32)

## vand_s64

`vand_s64`

int64x1_t vand_s64 (int64x1_t a, int64x1_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vand_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_s64)

## vand_s8

`vand_s8`

int8x8_t vand_s8 (int8x8_t a, int8x8_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vand_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_s8)

## vand_u16

`vand_u16`

uint16x4_t vand_u16 (uint16x4_t a, uint16x4_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vand_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_u16)

## vand_u32

`vand_u32`

uint32x2_t vand_u32 (uint32x2_t a, uint32x2_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vand_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_u32)

## vand_u64

`vand_u64`

uint64x1_t vand_u64 (uint64x1_t a, uint64x1_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vand_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_u64)

## vand_u8

`vand_u8`

uint8x8_t vand_u8 (uint8x8_t a, uint8x8_t b)
A32: VAND Dd, Dn, Dm
A64: AND Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vand_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vand_u8)

## vandq_f32

`vandq_f32`

float32x4_t vandq_f32 (float32x4_t a, float32x4_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vandq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_f32)

## vandq_f64

`vandq_f64`

float64x2_t vandq_f64 (float64x2_t a, float64x2_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vandq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_f64)

## vandq_s16

`vandq_s16`

int16x8_t vandq_s16 (int16x8_t a, int16x8_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vandq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_s16)

## vandq_s32

`vandq_s32`

int32x4_t vandq_s32 (int32x4_t a, int32x4_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vandq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_s32)

## vandq_s64

`vandq_s64`

int64x2_t vandq_s64 (int64x2_t a, int64x2_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vandq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_s64)

## vandq_s8

`vandq_s8`

int8x16_t vandq_s8 (int8x16_t a, int8x16_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vandq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_s8)

## vandq_u16

`vandq_u16`

uint16x8_t vandq_u16 (uint16x8_t a, uint16x8_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vandq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_u16)

## vandq_u32

`vandq_u32`

uint32x4_t vandq_u32 (uint32x4_t a, uint32x4_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vandq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_u32)

## vandq_u64

`vandq_u64`

uint64x2_t vandq_u64 (uint64x2_t a, uint64x2_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vandq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_u64)

## vandq_u8

`vandq_u8`

uint8x16_t vandq_u8 (uint8x16_t a, uint8x16_t b)
A32: VAND Qd, Qn, Qm
A64: AND Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vandq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vandq_u8)

## vbic_f32

`vbic_f32`

float32x2_t vbic_f32 (float32x2_t a, float32x2_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vbic_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_f32)

## vbic_f64

`vbic_f64`

float64x1_t vbic_f64 (float64x1_t a, float64x1_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vbic_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_f64)

## vbic_s16

`vbic_s16`

int16x4_t vbic_s16 (int16x4_t a, int16x4_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbic_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_s16)

## vbic_s32

`vbic_s32`

int32x2_t vbic_s32 (int32x2_t a, int32x2_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbic_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_s32)

## vbic_s64

`vbic_s64`

int64x1_t vbic_s64 (int64x1_t a, int64x1_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbic_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_s64)

## vbic_s8

`vbic_s8`

int8x8_t vbic_s8 (int8x8_t a, int8x8_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbic_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_s8)

## vbic_u16

`vbic_u16`

uint16x4_t vbic_u16 (uint16x4_t a, uint16x4_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbic_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_u16)

## vbic_u32

`vbic_u32`

uint32x2_t vbic_u32 (uint32x2_t a, uint32x2_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbic_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_u32)

## vbic_u64

`vbic_u64`

uint64x1_t vbic_u64 (uint64x1_t a, uint64x1_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbic_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_u64)

## vbic_u8

`vbic_u8`

uint8x8_t vbic_u8 (uint8x8_t a, uint8x8_t b)
A32: VBIC Dd, Dn, Dm
A64: BIC Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbic_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbic_u8)

## vbicq_f32

`vbicq_f32`

float32x4_t vbicq_f32 (float32x4_t a, float32x4_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vbicq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_f32)

## vbicq_f64

`vbicq_f64`

float64x2_t vbicq_f64 (float64x2_t a, float64x2_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vbicq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_f64)

## vbicq_s16

`vbicq_s16`

int16x8_t vbicq_s16 (int16x8_t a, int16x8_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbicq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_s16)

## vbicq_s32

`vbicq_s32`

int32x4_t vbicq_s32 (int32x4_t a, int32x4_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbicq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_s32)

## vbicq_s64

`vbicq_s64`

int64x2_t vbicq_s64 (int64x2_t a, int64x2_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbicq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_s64)

## vbicq_s8

`vbicq_s8`

int8x16_t vbicq_s8 (int8x16_t a, int8x16_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbicq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_s8)

## vbicq_u16

`vbicq_u16`

uint16x8_t vbicq_u16 (uint16x8_t a, uint16x8_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbicq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_u16)

## vbicq_u32

`vbicq_u32`

uint32x4_t vbicq_u32 (uint32x4_t a, uint32x4_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbicq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_u32)

## vbicq_u64

`vbicq_u64`

uint64x2_t vbicq_u64 (uint64x2_t a, uint64x2_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbicq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_u64)

## vbicq_u8

`vbicq_u8`

uint8x16_t vbicq_u8 (uint8x16_t a, uint8x16_t b)
A32: VBIC Qd, Qn, Qm
A64: BIC Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbicq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbicq_u8)

## vbsl_f32

`vbsl_f32`

float32x2_t vbsl_f32 (uint32x2_t a, float32x2_t b, float32x2_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_f32)

## vbsl_f64

`vbsl_f64`

float64x1_t vbsl_f64 (uint64x1_t a, float64x1_t b, float64x1_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_f64)

## vbsl_s16

`vbsl_s16`

int16x4_t vbsl_s16 (uint16x4_t a, int16x4_t b, int16x4_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_s16)

## vbsl_s32

`vbsl_s32`

int32x2_t vbsl_s32 (uint32x2_t a, int32x2_t b, int32x2_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_s32)

## vbsl_s64

`vbsl_s64`

int64x1_t vbsl_s64 (uint64x1_t a, int64x1_t b, int64x1_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_s64)

## vbsl_s8

`vbsl_s8`

int8x8_t vbsl_s8 (uint8x8_t a, int8x8_t b, int8x8_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_s8)

## vbsl_u16

`vbsl_u16`

uint16x4_t vbsl_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_u16)

## vbsl_u32

`vbsl_u32`

uint32x2_t vbsl_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_u32)

## vbsl_u64

`vbsl_u64`

uint64x1_t vbsl_u64 (uint64x1_t a, uint64x1_t b, uint64x1_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_u64)

## vbsl_u8

`vbsl_u8`

uint8x8_t vbsl_u8 (uint8x8_t a, uint8x8_t b, uint8x8_t c)
A32: VBSL Dd, Dn, Dm
A64: BSL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vbsl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbsl_u8)

## vbslq_f32

`vbslq_f32`

float32x4_t vbslq_f32 (uint32x4_t a, float32x4_t b, float32x4_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_f32)

## vbslq_f64

`vbslq_f64`

float64x2_t vbslq_f64 (uint64x2_t a, float64x2_t b, float64x2_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_f64)

## vbslq_s16

`vbslq_s16`

int16x8_t vbslq_s16 (uint16x8_t a, int16x8_t b, int16x8_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_s16)

## vbslq_s32

`vbslq_s32`

int32x4_t vbslq_s32 (uint32x4_t a, int32x4_t b, int32x4_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_s32)

## vbslq_s64

`vbslq_s64`

int64x2_t vbslq_s64 (uint64x2_t a, int64x2_t b, int64x2_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_s64)

## vbslq_s8

`vbslq_s8`

int8x16_t vbslq_s8 (uint8x16_t a, int8x16_t b, int8x16_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_s8)

## vbslq_u16

`vbslq_u16`

uint16x8_t vbslq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_u16)

## vbslq_u32

`vbslq_u32`

uint32x4_t vbslq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_u32)

## vbslq_u64

`vbslq_u64`

uint64x2_t vbslq_u64 (uint64x2_t a, uint64x2_t b, uint64x2_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_u64)

## vbslq_u8

`vbslq_u8`

uint8x16_t vbslq_u8 (uint8x16_t a, uint8x16_t b, uint8x16_t c)
A32: VBSL Qd, Qn, Qm
A64: BSL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vbslq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vbslq_u8)

## vcage_f32

`vcage_f32`

uint32x2_t vcage_f32 (float32x2_t a, float32x2_t b)
A32: VACGE.F32 Dd, Dn, Dm
A64: FACGE Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcage_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcage_f32)

## vcageq_f32

`vcageq_f32`

uint32x4_t vcageq_f32 (float32x4_t a, float32x4_t b)
A32: VACGE.F32 Qd, Qn, Qm
A64: FACGE Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcageq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcageq_f32)

## vcagt_f32

`vcagt_f32`

uint32x2_t vcagt_f32 (float32x2_t a, float32x2_t b)
A32: VACGT.F32 Dd, Dn, Dm
A64: FACGT Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcagt_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcagt_f32)

## vcagtq_f32

`vcagtq_f32`

uint32x4_t vcagtq_f32 (float32x4_t a, float32x4_t b)
A32: VACGT.F32 Qd, Qn, Qm
A64: FACGT Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcagtq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcagtq_f32)

## vcale_f32

`vcale_f32`

uint32x2_t vcale_f32 (float32x2_t a, float32x2_t b)
A32: VACLE.F32 Dd, Dn, Dm
A64: FACGE Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcale_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcale_f32)

## vcaleq_f32

`vcaleq_f32`

uint32x4_t vcaleq_f32 (float32x4_t a, float32x4_t b)
A32: VACLE.F32 Qd, Qn, Qm
A64: FACGE Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcaleq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcaleq_f32)

## vcalt_f32

`vcalt_f32`

uint32x2_t vcalt_f32 (float32x2_t a, float32x2_t b)
A32: VACLT.F32 Dd, Dn, Dm
A64: FACGT Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcalt_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcalt_f32)

## vcaltq_f32

`vcaltq_f32`

uint32x4_t vcaltq_f32 (float32x4_t a, float32x4_t b)
A32: VACLT.F32 Qd, Qn, Qm
A64: FACGT Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcaltq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcaltq_f32)

## vceq_f32

`vceq_f32`

uint32x2_t vceq_f32 (float32x2_t a, float32x2_t b)
A32: VCEQ.F32 Dd, Dn, Dm
A64: FCMEQ Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vceq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_f32)

## vceq_s16

`vceq_s16`

uint16x4_t vceq_s16 (int16x4_t a, int16x4_t b)
A32: VCEQ.I16 Dd, Dn, Dm
A64: CMEQ Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vceq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_s16)

## vceq_s32

`vceq_s32`

uint32x2_t vceq_s32 (int32x2_t a, int32x2_t b)
A32: VCEQ.I32 Dd, Dn, Dm
A64: CMEQ Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vceq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_s32)

## vceq_s8

`vceq_s8`

uint8x8_t vceq_s8 (int8x8_t a, int8x8_t b)
A32: VCEQ.I8 Dd, Dn, Dm
A64: CMEQ Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vceq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_s8)

## vceq_u16

`vceq_u16`

uint16x4_t vceq_u16 (uint16x4_t a, uint16x4_t b)
A32: VCEQ.I16 Dd, Dn, Dm
A64: CMEQ Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vceq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_u16)

## vceq_u32

`vceq_u32`

uint32x2_t vceq_u32 (uint32x2_t a, uint32x2_t b)
A32: VCEQ.I32 Dd, Dn, Dm
A64: CMEQ Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vceq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_u32)

## vceq_u8

`vceq_u8`

uint8x8_t vceq_u8 (uint8x8_t a, uint8x8_t b)
A32: VCEQ.I8 Dd, Dn, Dm
A64: CMEQ Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vceq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_u8)

## vceqq_f32

`vceqq_f32`

uint32x4_t vceqq_f32 (float32x4_t a, float32x4_t b)
A32: VCEQ.F32 Qd, Qn, Qm
A64: FCMEQ Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vceqq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_f32)

## vceqq_s16

`vceqq_s16`

uint16x8_t vceqq_s16 (int16x8_t a, int16x8_t b)
A32: VCEQ.I16 Qd, Qn, Qm
A64: CMEQ Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vceqq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_s16)

## vceqq_s32

`vceqq_s32`

uint32x4_t vceqq_s32 (int32x4_t a, int32x4_t b)
A32: VCEQ.I32 Qd, Qn, Qm
A64: CMEQ Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vceqq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_s32)

## vceqq_s8

`vceqq_s8`

uint8x16_t vceqq_s8 (int8x16_t a, int8x16_t b)
A32: VCEQ.I8 Qd, Qn, Qm
A64: CMEQ Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vceqq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_s8)

## vceqq_u16

`vceqq_u16`

uint16x8_t vceqq_u16 (uint16x8_t a, uint16x8_t b)
A32: VCEQ.I16 Qd, Qn, Qm
A64: CMEQ Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vceqq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_u16)

## vceqq_u32

`vceqq_u32`

uint32x4_t vceqq_u32 (uint32x4_t a, uint32x4_t b)
A32: VCEQ.I32 Qd, Qn, Qm
A64: CMEQ Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vceqq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_u32)

## vceqq_u8

`vceqq_u8`

uint8x16_t vceqq_u8 (uint8x16_t a, uint8x16_t b)
A32: VCEQ.I8 Qd, Qn, Qm
A64: CMEQ Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vceqq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_u8)

## vcge_f32

`vcge_f32`

uint32x2_t vcge_f32 (float32x2_t a, float32x2_t b)
A32: VCGE.F32 Dd, Dn, Dm
A64: FCMGE Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcge_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_f32)

## vcge_s16

`vcge_s16`

uint16x4_t vcge_s16 (int16x4_t a, int16x4_t b)
A32: VCGE.S16 Dd, Dn, Dm
A64: CMGE Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vcge_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_s16)

## vcge_s32

`vcge_s32`

uint32x2_t vcge_s32 (int32x2_t a, int32x2_t b)
A32: VCGE.S32 Dd, Dn, Dm
A64: CMGE Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcge_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_s32)

## vcge_s8

`vcge_s8`

uint8x8_t vcge_s8 (int8x8_t a, int8x8_t b)
A32: VCGE.S8 Dd, Dn, Dm
A64: CMGE Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vcge_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_s8)

## vcge_u16

`vcge_u16`

uint16x4_t vcge_u16 (uint16x4_t a, uint16x4_t b)
A32: VCGE.U16 Dd, Dn, Dm
A64: CMHS Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vcge_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_u16)

## vcge_u32

`vcge_u32`

uint32x2_t vcge_u32 (uint32x2_t a, uint32x2_t b)
A32: VCGE.U32 Dd, Dn, Dm
A64: CMHS Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcge_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_u32)

## vcge_u8

`vcge_u8`

uint8x8_t vcge_u8 (uint8x8_t a, uint8x8_t b)
A32: VCGE.U8 Dd, Dn, Dm
A64: CMHS Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vcge_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_u8)

## vcgeq_f32

`vcgeq_f32`

uint32x4_t vcgeq_f32 (float32x4_t a, float32x4_t b)
A32: VCGE.F32 Qd, Qn, Qm
A64: FCMGE Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcgeq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_f32)

## vcgeq_s16

`vcgeq_s16`

uint16x8_t vcgeq_s16 (int16x8_t a, int16x8_t b)
A32: VCGE.S16 Qd, Qn, Qm
A64: CMGE Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vcgeq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_s16)

## vcgeq_s32

`vcgeq_s32`

uint32x4_t vcgeq_s32 (int32x4_t a, int32x4_t b)
A32: VCGE.S32 Qd, Qn, Qm
A64: CMGE Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcgeq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_s32)

## vcgeq_s8

`vcgeq_s8`

uint8x16_t vcgeq_s8 (int8x16_t a, int8x16_t b)
A32: VCGE.S8 Qd, Qn, Qm
A64: CMGE Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vcgeq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_s8)

## vcgeq_u16

`vcgeq_u16`

uint16x8_t vcgeq_u16 (uint16x8_t a, uint16x8_t b)
A32: VCGE.U16 Qd, Qn, Qm
A64: CMHS Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vcgeq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_u16)

## vcgeq_u32

`vcgeq_u32`

uint32x4_t vcgeq_u32 (uint32x4_t a, uint32x4_t b)
A32: VCGE.U32 Qd, Qn, Qm
A64: CMHS Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcgeq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_u32)

## vcgeq_u8

`vcgeq_u8`

uint8x16_t vcgeq_u8 (uint8x16_t a, uint8x16_t b)
A32: VCGE.U8 Qd, Qn, Qm
A64: CMHS Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vcgeq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_u8)

## vcgt_f32

`vcgt_f32`

uint32x2_t vcgt_f32 (float32x2_t a, float32x2_t b)
A32: VCGT.F32 Dd, Dn, Dm
A64: FCMGT Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcgt_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_f32)

## vcgt_s16

`vcgt_s16`

uint16x4_t vcgt_s16 (int16x4_t a, int16x4_t b)
A32: VCGT.S16 Dd, Dn, Dm
A64: CMGT Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vcgt_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_s16)

## vcgt_s32

`vcgt_s32`

uint32x2_t vcgt_s32 (int32x2_t a, int32x2_t b)
A32: VCGT.S32 Dd, Dn, Dm
A64: CMGT Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcgt_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_s32)

## vcgt_s8

`vcgt_s8`

uint8x8_t vcgt_s8 (int8x8_t a, int8x8_t b)
A32: VCGT.S8 Dd, Dn, Dm
A64: CMGT Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vcgt_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_s8)

## vcgt_u16

`vcgt_u16`

uint16x4_t vcgt_u16 (uint16x4_t a, uint16x4_t b)
A32: VCGT.U16 Dd, Dn, Dm
A64: CMHI Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vcgt_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_u16)

## vcgt_u32

`vcgt_u32`

uint32x2_t vcgt_u32 (uint32x2_t a, uint32x2_t b)
A32: VCGT.U32 Dd, Dn, Dm
A64: CMHI Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcgt_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_u32)

## vcgt_u8

`vcgt_u8`

uint8x8_t vcgt_u8 (uint8x8_t a, uint8x8_t b)
A32: VCGT.U8 Dd, Dn, Dm
A64: CMHI Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vcgt_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_u8)

## vcgtq_f32

`vcgtq_f32`

uint32x4_t vcgtq_f32 (float32x4_t a, float32x4_t b)
A32: VCGT.F32 Qd, Qn, Qm
A64: FCMGT Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcgtq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_f32)

## vcgtq_s16

`vcgtq_s16`

uint16x8_t vcgtq_s16 (int16x8_t a, int16x8_t b)
A32: VCGT.S16 Qd, Qn, Qm
A64: CMGT Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vcgtq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_s16)

## vcgtq_s32

`vcgtq_s32`

uint32x4_t vcgtq_s32 (int32x4_t a, int32x4_t b)
A32: VCGT.S32 Qd, Qn, Qm
A64: CMGT Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcgtq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_s32)

## vcgtq_s8

`vcgtq_s8`

uint8x16_t vcgtq_s8 (int8x16_t a, int8x16_t b)
A32: VCGT.S8 Qd, Qn, Qm
A64: CMGT Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vcgtq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_s8)

## vcgtq_u16

`vcgtq_u16`

uint16x8_t vcgtq_u16 (uint16x8_t a, uint16x8_t b)
A32: VCGT.U16 Qd, Qn, Qm
A64: CMHI Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vcgtq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_u16)

## vcgtq_u32

`vcgtq_u32`

uint32x4_t vcgtq_u32 (uint32x4_t a, uint32x4_t b)
A32: VCGT.U32 Qd, Qn, Qm
A64: CMHI Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcgtq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_u32)

## vcgtq_u8

`vcgtq_u8`

uint8x16_t vcgtq_u8 (uint8x16_t a, uint8x16_t b)
A32: VCGT.U8 Qd, Qn, Qm
A64: CMHI Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vcgtq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_u8)

## vcle_f32

`vcle_f32`

uint32x2_t vcle_f32 (float32x2_t a, float32x2_t b)
A32: VCLE.F32 Dd, Dn, Dm
A64: FCMGE Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcle_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_f32)

## vcle_s16

`vcle_s16`

uint16x4_t vcle_s16 (int16x4_t a, int16x4_t b)
A32: VCLE.S16 Dd, Dn, Dm
A64: CMGE Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vcle_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_s16)

## vcle_s32

`vcle_s32`

uint32x2_t vcle_s32 (int32x2_t a, int32x2_t b)
A32: VCLE.S32 Dd, Dn, Dm
A64: CMGE Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcle_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_s32)

## vcle_s8

`vcle_s8`

uint8x8_t vcle_s8 (int8x8_t a, int8x8_t b)
A32: VCLE.S8 Dd, Dn, Dm
A64: CMGE Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vcle_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_s8)

## vcle_u16

`vcle_u16`

uint16x4_t vcle_u16 (uint16x4_t a, uint16x4_t b)
A32: VCLE.U16 Dd, Dn, Dm
A64: CMHS Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vcle_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_u16)

## vcle_u32

`vcle_u32`

uint32x2_t vcle_u32 (uint32x2_t a, uint32x2_t b)
A32: VCLE.U32 Dd, Dn, Dm
A64: CMHS Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vcle_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_u32)

## vcle_u8

`vcle_u8`

uint8x8_t vcle_u8 (uint8x8_t a, uint8x8_t b)
A32: VCLE.U8 Dd, Dn, Dm
A64: CMHS Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vcle_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_u8)

## vcleq_f32

`vcleq_f32`

uint32x4_t vcleq_f32 (float32x4_t a, float32x4_t b)
A32: VCLE.F32 Qd, Qn, Qm
A64: FCMGE Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcleq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_f32)

## vcleq_s16

`vcleq_s16`

uint16x8_t vcleq_s16 (int16x8_t a, int16x8_t b)
A32: VCLE.S16 Qd, Qn, Qm
A64: CMGE Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vcleq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_s16)

## vcleq_s32

`vcleq_s32`

uint32x4_t vcleq_s32 (int32x4_t a, int32x4_t b)
A32: VCLE.S32 Qd, Qn, Qm
A64: CMGE Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcleq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_s32)

## vcleq_s8

`vcleq_s8`

uint8x16_t vcleq_s8 (int8x16_t a, int8x16_t b)
A32: VCLE.S8 Qd, Qn, Qm
A64: CMGE Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vcleq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_s8)

## vcleq_u16

`vcleq_u16`

uint16x8_t vcleq_u16 (uint16x8_t a, uint16x8_t b)
A32: VCLE.U16 Qd, Qn, Qm
A64: CMHS Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vcleq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_u16)

## vcleq_u32

`vcleq_u32`

uint32x4_t vcleq_u32 (uint32x4_t a, uint32x4_t b)
A32: VCLE.U32 Qd, Qn, Qm
A64: CMHS Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcleq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_u32)

## vcleq_u8

`vcleq_u8`

uint8x16_t vcleq_u8 (uint8x16_t a, uint8x16_t b)
A32: VCLE.U8 Qd, Qn, Qm
A64: CMHS Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vcleq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_u8)

## vcls_s16

`vcls_s16`

int16x4_t vcls_s16 (int16x4_t a)
A32: VCLS.S16 Dd, Dm
A64: CLS Vd.4H, Vn.4H


Instruction Documentation: [vcls_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcls_s16)

## vcls_s32

`vcls_s32`

int32x2_t vcls_s32 (int32x2_t a)
A32: VCLS.S32 Dd, Dm
A64: CLS Vd.2S, Vn.2S


Instruction Documentation: [vcls_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcls_s32)

## vcls_s8

`vcls_s8`

int8x8_t vcls_s8 (int8x8_t a)
A32: VCLS.S8 Dd, Dm
A64: CLS Vd.8B, Vn.8B


Instruction Documentation: [vcls_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcls_s8)

## vclsq_s16

`vclsq_s16`

int16x8_t vclsq_s16 (int16x8_t a)
A32: VCLS.S16 Qd, Qm
A64: CLS Vd.8H, Vn.8H


Instruction Documentation: [vclsq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclsq_s16)

## vclsq_s32

`vclsq_s32`

int32x4_t vclsq_s32 (int32x4_t a)
A32: VCLS.S32 Qd, Qm
A64: CLS Vd.4S, Vn.4S


Instruction Documentation: [vclsq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclsq_s32)

## vclsq_s8

`vclsq_s8`

int8x16_t vclsq_s8 (int8x16_t a)
A32: VCLS.S8 Qd, Qm
A64: CLS Vd.16B, Vn.16B


Instruction Documentation: [vclsq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclsq_s8)

## vclt_f32

`vclt_f32`

uint32x2_t vclt_f32 (float32x2_t a, float32x2_t b)
A32: VCLT.F32 Dd, Dn, Dm
A64: FCMGT Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vclt_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_f32)

## vclt_s16

`vclt_s16`

uint16x4_t vclt_s16 (int16x4_t a, int16x4_t b)
A32: VCLT.S16 Dd, Dn, Dm
A64: CMGT Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vclt_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_s16)

## vclt_s32

`vclt_s32`

uint32x2_t vclt_s32 (int32x2_t a, int32x2_t b)
A32: VCLT.S32 Dd, Dn, Dm
A64: CMGT Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vclt_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_s32)

## vclt_s8

`vclt_s8`

uint8x8_t vclt_s8 (int8x8_t a, int8x8_t b)
A32: VCLT.S8 Dd, Dn, Dm
A64: CMGT Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vclt_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_s8)

## vclt_u16

`vclt_u16`

uint16x4_t vclt_u16 (uint16x4_t a, uint16x4_t b)
A32: VCLT.U16 Dd, Dn, Dm
A64: CMHI Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vclt_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_u16)

## vclt_u32

`vclt_u32`

uint32x2_t vclt_u32 (uint32x2_t a, uint32x2_t b)
A32: VCLT.U32 Dd, Dn, Dm
A64: CMHI Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vclt_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_u32)

## vclt_u8

`vclt_u8`

uint8x8_t vclt_u8 (uint8x8_t a, uint8x8_t b)
A32: VCLT.U8 Dd, Dn, Dm
A64: CMHI Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vclt_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_u8)

## vcltq_f32

`vcltq_f32`

uint32x4_t vcltq_f32 (float32x4_t a, float32x4_t b)
A32: VCLT.F32 Qd, Qn, Qm
A64: FCMGT Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcltq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_f32)

## vcltq_s16

`vcltq_s16`

uint16x8_t vcltq_s16 (int16x8_t a, int16x8_t b)
A32: VCLT.S16 Qd, Qn, Qm
A64: CMGT Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vcltq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_s16)

## vcltq_s32

`vcltq_s32`

uint32x4_t vcltq_s32 (int32x4_t a, int32x4_t b)
A32: VCLT.S32 Qd, Qn, Qm
A64: CMGT Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcltq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_s32)

## vcltq_s8

`vcltq_s8`

uint8x16_t vcltq_s8 (int8x16_t a, int8x16_t b)
A32: VCLT.S8 Qd, Qn, Qm
A64: CMGT Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vcltq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_s8)

## vcltq_u16

`vcltq_u16`

uint16x8_t vcltq_u16 (uint16x8_t a, uint16x8_t b)
A32: VCLT.U16 Qd, Qn, Qm
A64: CMHI Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vcltq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_u16)

## vcltq_u32

`vcltq_u32`

uint32x4_t vcltq_u32 (uint32x4_t a, uint32x4_t b)
A32: VCLT.U32 Qd, Qn, Qm
A64: CMHI Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vcltq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_u32)

## vcltq_u8

`vcltq_u8`

uint8x16_t vcltq_u8 (uint8x16_t a, uint8x16_t b)
A32: VCLT.U8 Qd, Qn, Qm
A64: CMHI Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vcltq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_u8)

## vclz_s16

`vclz_s16`

int16x4_t vclz_s16 (int16x4_t a)
A32: VCLZ.I16 Dd, Dm
A64: CLZ Vd.4H, Vn.4H


Instruction Documentation: [vclz_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclz_s16)

## vclz_s32

`vclz_s32`

int32x2_t vclz_s32 (int32x2_t a)
A32: VCLZ.I32 Dd, Dm
A64: CLZ Vd.2S, Vn.2S


Instruction Documentation: [vclz_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclz_s32)

## vclz_s8

`vclz_s8`

int8x8_t vclz_s8 (int8x8_t a)
A32: VCLZ.I8 Dd, Dm
A64: CLZ Vd.8B, Vn.8B


Instruction Documentation: [vclz_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclz_s8)

## vclz_u16

`vclz_u16`

uint16x4_t vclz_u16 (uint16x4_t a)
A32: VCLZ.I16 Dd, Dm
A64: CLZ Vd.4H, Vn.4H


Instruction Documentation: [vclz_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclz_u16)

## vclz_u32

`vclz_u32`

uint32x2_t vclz_u32 (uint32x2_t a)
A32: VCLZ.I32 Dd, Dm
A64: CLZ Vd.2S, Vn.2S


Instruction Documentation: [vclz_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclz_u32)

## vclz_u8

`vclz_u8`

uint8x8_t vclz_u8 (uint8x8_t a)
A32: VCLZ.I8 Dd, Dm
A64: CLZ Vd.8B, Vn.8B


Instruction Documentation: [vclz_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclz_u8)

## vclzq_s16

`vclzq_s16`

int16x8_t vclzq_s16 (int16x8_t a)
A32: VCLZ.I16 Qd, Qm
A64: CLZ Vd.8H, Vn.8H


Instruction Documentation: [vclzq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclzq_s16)

## vclzq_s32

`vclzq_s32`

int32x4_t vclzq_s32 (int32x4_t a)
A32: VCLZ.I32 Qd, Qm
A64: CLZ Vd.4S, Vn.4S


Instruction Documentation: [vclzq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclzq_s32)

## vclzq_s8

`vclzq_s8`

int8x16_t vclzq_s8 (int8x16_t a)
A32: VCLZ.I8 Qd, Qm
A64: CLZ Vd.16B, Vn.16B


Instruction Documentation: [vclzq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclzq_s8)

## vclzq_u16

`vclzq_u16`

uint16x8_t vclzq_u16 (uint16x8_t a)
A32: VCLZ.I16 Qd, Qm
A64: CLZ Vd.8H, Vn.8H


Instruction Documentation: [vclzq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclzq_u16)

## vclzq_u32

`vclzq_u32`

uint32x4_t vclzq_u32 (uint32x4_t a)
A32: VCLZ.I32 Qd, Qm
A64: CLZ Vd.4S, Vn.4S


Instruction Documentation: [vclzq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclzq_u32)

## vclzq_u8

`vclzq_u8`

uint8x16_t vclzq_u8 (uint8x16_t a)
A32: VCLZ.I8 Qd, Qm
A64: CLZ Vd.16B, Vn.16B


Instruction Documentation: [vclzq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclzq_u8)

## vcnt_s8

`vcnt_s8`

int8x8_t vcnt_s8 (int8x8_t a)
A32: VCNT.I8 Dd, Dm
A64: CNT Vd.8B, Vn.8B


Instruction Documentation: [vcnt_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcnt_s8)

## vcnt_u8

`vcnt_u8`

uint8x8_t vcnt_u8 (uint8x8_t a)
A32: VCNT.I8 Dd, Dm
A64: CNT Vd.8B, Vn.8B


Instruction Documentation: [vcnt_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcnt_u8)

## vcntq_s8

`vcntq_s8`

int8x16_t vcntq_s8 (int8x16_t a)
A32: VCNT.I8 Qd, Qm
A64: CNT Vd.16B, Vn.16B


Instruction Documentation: [vcntq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcntq_s8)

## vcntq_u8

`vcntq_u8`

uint8x16_t vcntq_u8 (uint8x16_t a)
A32: VCNT.I8 Qd, Qm
A64: CNT Vd.16B, Vn.16B


Instruction Documentation: [vcntq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcntq_u8)

## vcvt_f32_s32

`vcvt_f32_s32`

float32x2_t vcvt_f32_s32 (int32x2_t a)
A32: VCVT.F32.S32 Dd, Dm
A64: SCVTF Vd.2S, Vn.2S


Instruction Documentation: [vcvt_f32_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_f32_s32)

## vcvt_f32_u32

`vcvt_f32_u32`

float32x2_t vcvt_f32_u32 (uint32x2_t a)
A32: VCVT.F32.U32 Dd, Dm
A64: UCVTF Vd.2S, Vn.2S


Instruction Documentation: [vcvt_f32_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_f32_u32)

## vcvt_s32_f32

`vcvt_s32_f32`

int32x2_t vcvt_s32_f32 (float32x2_t a)
A32: VCVT.S32.F32 Dd, Dm
A64: FCVTZS Vd.2S, Vn.2S


Instruction Documentation: [vcvt_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_s32_f32)

## vcvt_u32_f32

`vcvt_u32_f32`

uint32x2_t vcvt_u32_f32 (float32x2_t a)
A32: VCVT.U32.F32 Dd, Dm
A64: FCVTZU Vd.2S, Vn.2S


Instruction Documentation: [vcvt_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_u32_f32)

## vcvta_s32_f32

`vcvta_s32_f32`

int32x2_t vcvta_s32_f32 (float32x2_t a)
A32: VCVTA.S32.F32 Dd, Dm
A64: FCVTAS Vd.2S, Vn.2S


Instruction Documentation: [vcvta_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvta_s32_f32)

## vcvta_u32_f32

`vcvta_u32_f32`

uint32x2_t vcvta_u32_f32 (float32x2_t a)
A32: VCVTA.U32.F32 Dd, Dm
A64: FCVTAU Vd.2S, Vn.2S


Instruction Documentation: [vcvta_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvta_u32_f32)

## vcvtaq_s32_f32

`vcvtaq_s32_f32`

int32x4_t vcvtaq_s32_f32 (float32x4_t a)
A32: VCVTA.S32.F32 Qd, Qm
A64: FCVTAS Vd.4S, Vn.4S


Instruction Documentation: [vcvtaq_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtaq_s32_f32)

## vcvtaq_u32_f32

`vcvtaq_u32_f32`

uint32x4_t vcvtaq_u32_f32 (float32x4_t a)
A32: VCVTA.U32.F32 Qd, Qm
A64: FCVTAU Vd.4S, Vn.4S


Instruction Documentation: [vcvtaq_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtaq_u32_f32)

## vcvtas_s32_f32

`vcvtas_s32_f32`

int32_t vcvtas_s32_f32 (float32_t a)
A32: VCVTA.S32.F32 Sd, Sm
A64: FCVTAS Sd, Sn


Instruction Documentation: [vcvtas_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtas_s32_f32)

## vcvtas_u32_f32

`vcvtas_u32_f32`

uint32_t vcvtas_u32_f32 (float32_t a)
A32: VCVTA.U32.F32 Sd, Sm
A64: FCVTAU Sd, Sn


Instruction Documentation: [vcvtas_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtas_u32_f32)

## vcvtm_s32_f32

`vcvtm_s32_f32`

int32x2_t vcvtm_s32_f32 (float32x2_t a)
A32: VCVTM.S32.F32 Dd, Dm
A64: FCVTMS Vd.2S, Vn.2S


Instruction Documentation: [vcvtm_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtm_s32_f32)

## vcvtm_u32_f32

`vcvtm_u32_f32`

uint32x2_t vcvtm_u32_f32 (float32x2_t a)
A32: VCVTM.U32.F32 Dd, Dm
A64: FCVTMU Vd.2S, Vn.2S


Instruction Documentation: [vcvtm_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtm_u32_f32)

## vcvtmq_s32_f32

`vcvtmq_s32_f32`

int32x4_t vcvtmq_s32_f32 (float32x4_t a)
A32: VCVTM.S32.F32 Qd, Qm
A64: FCVTMS Vd.4S, Vn.4S


Instruction Documentation: [vcvtmq_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtmq_s32_f32)

## vcvtmq_u32_f32

`vcvtmq_u32_f32`

uint32x4_t vcvtmq_u32_f32 (float32x4_t a)
A32: VCVTM.U32.F32 Qd, Qm
A64: FCVTMU Vd.4S, Vn.4S


Instruction Documentation: [vcvtmq_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtmq_u32_f32)

## vcvtms_s32_f32

`vcvtms_s32_f32`

int32_t vcvtms_s32_f32 (float32_t a)
A32: VCVTM.S32.F32 Sd, Sm
A64: FCVTMS Sd, Sn


Instruction Documentation: [vcvtms_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtms_s32_f32)

## vcvtms_u32_f32

`vcvtms_u32_f32`

uint32_t vcvtms_u32_f32 (float32_t a)
A32: VCVTM.U32.F32 Sd, Sm
A64: FCVTMU Sd, Sn


Instruction Documentation: [vcvtms_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtms_u32_f32)

## vcvtn_s32_f32

`vcvtn_s32_f32`

int32x2_t vcvtn_s32_f32 (float32x2_t a)
A32: VCVTN.S32.F32 Dd, Dm
A64: FCVTNS Vd.2S, Vn.2S


Instruction Documentation: [vcvtn_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtn_s32_f32)

## vcvtn_u32_f32

`vcvtn_u32_f32`

uint32x2_t vcvtn_u32_f32 (float32x2_t a)
A32: VCVTN.U32.F32 Dd, Dm
A64: FCVTNU Vd.2S, Vn.2S


Instruction Documentation: [vcvtn_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtn_u32_f32)

## vcvtnq_s32_f32

`vcvtnq_s32_f32`

int32x4_t vcvtnq_s32_f32 (float32x4_t a)
A32: VCVTN.S32.F32 Qd, Qm
A64: FCVTNS Vd.4S, Vn.4S


Instruction Documentation: [vcvtnq_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtnq_s32_f32)

## vcvtnq_u32_f32

`vcvtnq_u32_f32`

uint32x4_t vcvtnq_u32_f32 (float32x4_t a)
A32: VCVTN.U32.F32 Qd, Qm
A64: FCVTNU Vd.4S, Vn.4S


Instruction Documentation: [vcvtnq_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtnq_u32_f32)

## vcvtns_s32_f32

`vcvtns_s32_f32`

int32_t vcvtns_s32_f32 (float32_t a)
A32: VCVTN.S32.F32 Sd, Sm
A64: FCVTNS Sd, Sn


Instruction Documentation: [vcvtns_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtns_s32_f32)

## vcvtns_u32_f32

`vcvtns_u32_f32`

uint32_t vcvtns_u32_f32 (float32_t a)
A32: VCVTN.U32.F32 Sd, Sm
A64: FCVTNU Sd, Sn


Instruction Documentation: [vcvtns_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtns_u32_f32)

## vcvtp_s32_f32

`vcvtp_s32_f32`

int32x2_t vcvtp_s32_f32 (float32x2_t a)
A32: VCVTP.S32.F32 Dd, Dm
A64: FCVTPS Vd.2S, Vn.2S


Instruction Documentation: [vcvtp_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtp_s32_f32)

## vcvtp_u32_f32

`vcvtp_u32_f32`

uint32x2_t vcvtp_u32_f32 (float32x2_t a)
A32: VCVTP.U32.F32 Dd, Dm
A64: FCVTPU Vd.2S, Vn.2S


Instruction Documentation: [vcvtp_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtp_u32_f32)

## vcvtpq_s32_f32

`vcvtpq_s32_f32`

int32x4_t vcvtpq_s32_f32 (float32x4_t a)
A32: VCVTP.S32.F32 Qd, Qm
A64: FCVTPS Vd.4S, Vn.4S


Instruction Documentation: [vcvtpq_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtpq_s32_f32)

## vcvtpq_u32_f32

`vcvtpq_u32_f32`

uint32x4_t vcvtpq_u32_f32 (float32x4_t a)
A32: VCVTP.U32.F32 Qd, Qm
A64: FCVTPU Vd.4S, Vn.4S


Instruction Documentation: [vcvtpq_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtpq_u32_f32)

## vcvtps_s32_f32

`vcvtps_s32_f32`

int32_t vcvtps_s32_f32 (float32_t a)
A32: VCVTP.S32.F32 Sd, Sm
A64: FCVTPS Sd, Sn


Instruction Documentation: [vcvtps_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtps_s32_f32)

## vcvtps_u32_f32

`vcvtps_u32_f32`

uint32_t vcvtps_u32_f32 (float32_t a)
A32: VCVTP.U32.F32 Sd, Sm
A64: FCVTPU Sd, Sn


Instruction Documentation: [vcvtps_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtps_u32_f32)

## vcvtq_f32_s32

`vcvtq_f32_s32`

float32x4_t vcvtq_f32_s32 (int32x4_t a)
A32: VCVT.F32.S32 Qd, Qm
A64: SCVTF Vd.4S, Vn.4S


Instruction Documentation: [vcvtq_f32_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtq_f32_s32)

## vcvtq_f32_u32

`vcvtq_f32_u32`

float32x4_t vcvtq_f32_u32 (uint32x4_t a)
A32: VCVT.F32.U32 Qd, Qm
A64: UCVTF Vd.4S, Vn.4S


Instruction Documentation: [vcvtq_f32_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtq_f32_u32)

## vcvtq_s32_f32

`vcvtq_s32_f32`

int32x4_t vcvtq_s32_f32 (float32x4_t a)
A32: VCVT.S32.F32 Qd, Qm
A64: FCVTZS Vd.4S, Vn.4S


Instruction Documentation: [vcvtq_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtq_s32_f32)

## vcvtq_u32_f32

`vcvtq_u32_f32`

uint32x4_t vcvtq_u32_f32 (float32x4_t a)
A32: VCVT.U32.F32 Qd, Qm
A64: FCVTZU Vd.4S, Vn.4S


Instruction Documentation: [vcvtq_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtq_u32_f32)

## vcvts_f32_s32

`vcvts_f32_s32`

float32_t vcvts_f32_s32 (int32_t a)
A32: VCVT.F32.S32 Sd, Sm
A64: SCVTF Sd, Sn


Instruction Documentation: [vcvts_f32_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvts_f32_s32)

## vcvts_f32_u32

`vcvts_f32_u32`

float32_t vcvts_f32_u32 (uint32_t a)
A32: VCVT.F32.U32 Sd, Sm
A64: UCVTF Sd, Sn


Instruction Documentation: [vcvts_f32_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvts_f32_u32)

## vcvts_s32_f32

`vcvts_s32_f32`

int32_t vcvts_s32_f32 (float32_t a)
A32: VCVT.S32.F32 Sd, Sm
A64: FCVTZS Sd, Sn


Instruction Documentation: [vcvts_s32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvts_s32_f32)

## vcvts_u32_f32

`vcvts_u32_f32`

uint32_t vcvts_u32_f32 (float32_t a)
A32: VCVT.U32.F32 Sd, Sm
A64: FCVTZU Sd, Sn


Instruction Documentation: [vcvts_u32_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvts_u32_f32)

## vdiv_f64

`vdiv_f64`

float64x1_t vdiv_f64 (float64x1_t a, float64x1_t b)
A32: VDIV.F64 Dd, Dn, Dm
A64: FDIV Dd, Dn, Dm


Instruction Documentation: [vdiv_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdiv_f64)

## vdivs_f32

`vdivs_f32`

float32_t vdivs_f32 (float32_t a, float32_t b)
A32: VDIV.F32 Sd, Sn, Sm
A64: FDIV Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vdivs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdivs_f32)

## vdup_lane_f32

`vdup_lane_f32`

float32x2_t vdup_lane_f32 (float32x2_t vec, const int lane)
A32: VDUP.32 Dd, Dm[index]
A64: DUP Vd.2S, Vn.S[index]


Instruction Documentation: [vdup_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_lane_f32)

## vdup_lane_s16

`vdup_lane_s16`

int16x4_t vdup_lane_s16 (int16x4_t vec, const int lane)
A32: VDUP.16 Dd, Dm[index]
A64: DUP Vd.4H, Vn.H[index]


Instruction Documentation: [vdup_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_lane_s16)

## vdup_lane_s32

`vdup_lane_s32`

int32x2_t vdup_lane_s32 (int32x2_t vec, const int lane)
A32: VDUP.32 Dd, Dm[index]
A64: DUP Vd.2S, Vn.S[index]


Instruction Documentation: [vdup_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_lane_s32)

## vdup_lane_s8

`vdup_lane_s8`

int8x8_t vdup_lane_s8 (int8x8_t vec, const int lane)
A32: VDUP.8 Dd, Dm[index]
A64: DUP Vd.8B, Vn.B[index]


Instruction Documentation: [vdup_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_lane_s8)

## vdup_lane_u16

`vdup_lane_u16`

uint16x4_t vdup_lane_u16 (uint16x4_t vec, const int lane)
A32: VDUP.16 Dd, Dm[index]
A64: DUP Vd.4H, Vn.H[index]


Instruction Documentation: [vdup_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_lane_u16)

## vdup_lane_u32

`vdup_lane_u32`

uint32x2_t vdup_lane_u32 (uint32x2_t vec, const int lane)
A32: VDUP.32 Dd, Dm[index]
A64: DUP Vd.2S, Vn.S[index]


Instruction Documentation: [vdup_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_lane_u32)

## vdup_lane_u8

`vdup_lane_u8`

uint8x8_t vdup_lane_u8 (uint8x8_t vec, const int lane)
A32: VDUP.8 Dd, Dm[index]
A64: DUP Vd.8B, Vn.B[index]


Instruction Documentation: [vdup_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_lane_u8)

## vdup_laneq_f32

`vdup_laneq_f32`

float32x2_t vdup_laneq_f32 (float32x4_t vec, const int lane)
A32: VDUP.32 Dd, Dm[index]
A64: DUP Vd.2S, Vn.S[index]


Instruction Documentation: [vdup_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_laneq_f32)

## vdup_laneq_s16

`vdup_laneq_s16`

int16x4_t vdup_laneq_s16 (int16x8_t vec, const int lane)
A32: VDUP.16 Dd, Dm[index]
A64: DUP Vd.4H, Vn.H[index]


Instruction Documentation: [vdup_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_laneq_s16)

## vdup_laneq_s32

`vdup_laneq_s32`

int32x2_t vdup_laneq_s32 (int32x4_t vec, const int lane)
A32: VDUP.32 Dd, Dm[index]
A64: DUP Vd.2S, Vn.S[index]


Instruction Documentation: [vdup_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_laneq_s32)

## vdup_laneq_s8

`vdup_laneq_s8`

int8x8_t vdup_laneq_s8 (int8x16_t vec, const int lane)
A32: VDUP.8 Dd, Dm[index]
A64: DUP Vd.8B, Vn.B[index]


Instruction Documentation: [vdup_laneq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_laneq_s8)

## vdup_laneq_u16

`vdup_laneq_u16`

uint16x4_t vdup_laneq_u16 (uint16x8_t vec, const int lane)
A32: VDUP.16 Dd, Dm[index]
A64: DUP Vd.4H, Vn.H[index]


Instruction Documentation: [vdup_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_laneq_u16)

## vdup_laneq_u32

`vdup_laneq_u32`

uint32x2_t vdup_laneq_u32 (uint32x4_t vec, const int lane)
A32: VDUP.32 Dd, Dm[index]
A64: DUP Vd.2S, Vn.S[index]


Instruction Documentation: [vdup_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_laneq_u32)

## vdup_laneq_u8

`vdup_laneq_u8`

uint8x8_t vdup_laneq_u8 (uint8x16_t vec, const int lane)
A32: VDUP.8 Dd, Dm[index]
A64: DUP Vd.8B, Vn.B[index]


Instruction Documentation: [vdup_laneq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_laneq_u8)

## vdup_n_f32

`vdup_n_f32`

float32x2_t vdup_n_f32 (float32_t value)
A32: VDUP Dd, Dm[0]
A64: DUP Vd.2S, Vn.S[0]


Instruction Documentation: [vdup_n_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_n_f32)

## vdup_n_s16

`vdup_n_s16`

int16x4_t vdup_n_s16 (int16_t value)
A32: VDUP.16 Dd, Rt
A64: DUP Vd.4H, Rn


Instruction Documentation: [vdup_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_n_s16)

## vdup_n_s32

`vdup_n_s32`

int32x2_t vdup_n_s32 (int32_t value)
A32: VDUP.32 Dd, Rt
A64: DUP Vd.2S, Rn


Instruction Documentation: [vdup_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_n_s32)

## vdup_n_s8

`vdup_n_s8`

int8x8_t vdup_n_s8 (int8_t value)
A32: VDUP.8 Dd, Rt
A64: DUP Vd.8B, Rn


Instruction Documentation: [vdup_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_n_s8)

## vdup_n_u16

`vdup_n_u16`

uint16x4_t vdup_n_u16 (uint16_t value)
A32: VDUP.16 Dd, Rt
A64: DUP Vd.4H, Rn


Instruction Documentation: [vdup_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_n_u16)

## vdup_n_u32

`vdup_n_u32`

uint32x2_t vdup_n_u32 (uint32_t value)
A32: VDUP.32 Dd, Rt
A64: DUP Vd.2S, Rn


Instruction Documentation: [vdup_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_n_u32)

## vdup_n_u8

`vdup_n_u8`

uint8x8_t vdup_n_u8 (uint8_t value)
A32: VDUP.8 Dd, Rt
A64: DUP Vd.8B, Rn


Instruction Documentation: [vdup_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdup_n_u8)

## vdupq_lane_f32

`vdupq_lane_f32`

float32x4_t vdupq_lane_f32 (float32x2_t vec, const int lane)
A32: VDUP.32 Qd, Dm[index]
A64: DUP Vd.4S, Vn.S[index]


Instruction Documentation: [vdupq_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_lane_f32)

## vdupq_lane_s16

`vdupq_lane_s16`

int16x8_t vdupq_lane_s16 (int16x8_t vec, const int lane)
A32: VDUP.16 Qd, Dm[index]
A64: DUP Vd.8H, Vn.H[index]


Instruction Documentation: [vdupq_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_lane_s16)

## vdupq_lane_s32

`vdupq_lane_s32`

int32x4_t vdupq_lane_s32 (int32x4_t vec, const int lane)
A32: VDUP.32 Qd, Dm[index]
A64: DUP Vd.4S, Vn.S[index]


Instruction Documentation: [vdupq_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_lane_s32)

## vdupq_lane_s8

`vdupq_lane_s8`

int8x16_t vdupq_lane_s8 (int8x16_t vec, const int lane)
A32: VDUP.8 Qd, Dm[index]
A64: DUP Vd.16B, Vn.B[index]


Instruction Documentation: [vdupq_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_lane_s8)

## vdupq_lane_u16

`vdupq_lane_u16`

uint16x8_t vdupq_lane_u16 (uint16x8_t vec, const int lane)
A32: VDUP.16 Qd, Dm[index]
A64: DUP Vd.8H, Vn.H[index]


Instruction Documentation: [vdupq_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_lane_u16)

## vdupq_lane_u32

`vdupq_lane_u32`

uint32x4_t vdupq_lane_u32 (uint32x4_t vec, const int lane)
A32: VDUP.32 Qd, Dm[index]
A64: DUP Vd.4S, Vn.S[index]


Instruction Documentation: [vdupq_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_lane_u32)

## vdupq_lane_u8

`vdupq_lane_u8`

uint8x16_t vdupq_lane_u8 (uint8x16_t vec, const int lane)
A32: VDUP.8 Qd, Dm[index]
A64: DUP Vd.16B, Vn.B[index]


Instruction Documentation: [vdupq_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_lane_u8)

## vdupq_n_f32

`vdupq_n_f32`

float32x4_t vdupq_n_f32 (float32_t value)
A32: VDUP Qd, Dm[0]
A64: DUP Vd.4S, Vn.S[0]


Instruction Documentation: [vdupq_n_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_f32)

## vdupq_n_s16

`vdupq_n_s16`

int16x8_t vdupq_n_s16 (int16_t value)
A32: VDUP.16 Qd, Rt
A64: DUP Vd.8H, Rn


Instruction Documentation: [vdupq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_s16)

## vdupq_n_s32

`vdupq_n_s32`

int32x4_t vdupq_n_s32 (int32_t value)
A32: VDUP.32 Qd, Rt
A64: DUP Vd.4S, Rn


Instruction Documentation: [vdupq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_s32)

## vdupq_n_s8

`vdupq_n_s8`

int8x16_t vdupq_n_s8 (int8_t value)
A32: VDUP.8 Qd, Rt
A64: DUP Vd.16B, Rn


Instruction Documentation: [vdupq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_s8)

## vdupq_n_u16

`vdupq_n_u16`

uint16x8_t vdupq_n_u16 (uint16_t value)
A32: VDUP.16 Qd, Rt
A64: DUP Vd.8H, Rn


Instruction Documentation: [vdupq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_u16)

## vdupq_n_u32

`vdupq_n_u32`

uint32x4_t vdupq_n_u32 (uint32_t value)
A32: VDUP.32 Qd, Rt
A64: DUP Vd.4S, Rn


Instruction Documentation: [vdupq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_u32)

## vdupq_n_u8

`vdupq_n_u8`

uint8x16_t vdupq_n_u8 (uint8_t value)
A32: VDUP.8 Qd, Rt
A64: DUP Vd.16B, Rn


Instruction Documentation: [vdupq_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_u8)

## veor_f32

`veor_f32`

float32x2_t veor_f32 (float32x2_t a, float32x2_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [veor_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_f32)

## veor_f64

`veor_f64`

float64x1_t veor_f64 (float64x1_t a, float64x1_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [veor_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_f64)

## veor_s16

`veor_s16`

int16x4_t veor_s16 (int16x4_t a, int16x4_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [veor_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_s16)

## veor_s32

`veor_s32`

int32x2_t veor_s32 (int32x2_t a, int32x2_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [veor_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_s32)

## veor_s64

`veor_s64`

int64x1_t veor_s64 (int64x1_t a, int64x1_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [veor_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_s64)

## veor_s8

`veor_s8`

int8x8_t veor_s8 (int8x8_t a, int8x8_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [veor_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_s8)

## veor_u16

`veor_u16`

uint16x4_t veor_u16 (uint16x4_t a, uint16x4_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [veor_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_u16)

## veor_u32

`veor_u32`

uint32x2_t veor_u32 (uint32x2_t a, uint32x2_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [veor_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_u32)

## veor_u64

`veor_u64`

uint64x1_t veor_u64 (uint64x1_t a, uint64x1_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [veor_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_u64)

## veor_u8

`veor_u8`

uint8x8_t veor_u8 (uint8x8_t a, uint8x8_t b)
A32: VEOR Dd, Dn, Dm
A64: EOR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [veor_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/veor_u8)

## veorq_f32

`veorq_f32`

float32x4_t veorq_f32 (float32x4_t a, float32x4_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [veorq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_f32)

## veorq_f64

`veorq_f64`

float64x2_t veorq_f64 (float64x2_t a, float64x2_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [veorq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_f64)

## veorq_s16

`veorq_s16`

int16x8_t veorq_s16 (int16x8_t a, int16x8_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [veorq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_s16)

## veorq_s32

`veorq_s32`

int32x4_t veorq_s32 (int32x4_t a, int32x4_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [veorq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_s32)

## veorq_s64

`veorq_s64`

int64x2_t veorq_s64 (int64x2_t a, int64x2_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [veorq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_s64)

## veorq_s8

`veorq_s8`

int8x16_t veorq_s8 (int8x16_t a, int8x16_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [veorq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_s8)

## veorq_u16

`veorq_u16`

uint16x8_t veorq_u16 (uint16x8_t a, uint16x8_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [veorq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_u16)

## veorq_u32

`veorq_u32`

uint32x4_t veorq_u32 (uint32x4_t a, uint32x4_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [veorq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_u32)

## veorq_u64

`veorq_u64`

uint64x2_t veorq_u64 (uint64x2_t a, uint64x2_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [veorq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_u64)

## veorq_u8

`veorq_u8`

uint8x16_t veorq_u8 (uint8x16_t a, uint8x16_t b)
A32: VEOR Qd, Qn, Qm
A64: EOR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [veorq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/veorq_u8)

## vext_f32

`vext_f32`

float32x2_t vext_f32 (float32x2_t a, float32x2_t b, const int n)
A32: VEXT.8 Dd, Dn, Dm, #(n*4)
A64: EXT Vd.8B, Vn.8B, Vm.8B, #(n*4)


Instruction Documentation: [vext_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vext_f32)

## vext_s16

`vext_s16`

int16x4_t vext_s16 (int16x4_t a, int16x4_t b, const int n)
A32: VEXT.8 Dd, Dn, Dm, #(n*2)
A64: EXT Vd.8B, Vn.8B, Vm.8B, #(n*2)


Instruction Documentation: [vext_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vext_s16)

## vext_s32

`vext_s32`

int32x2_t vext_s32 (int32x2_t a, int32x2_t b, const int n)
A32: VEXT.8 Dd, Dn, Dm, #(n*4)
A64: EXT Vd.8B, Vn.8B, Vm.8B, #(n*4)


Instruction Documentation: [vext_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vext_s32)

## vext_s8

`vext_s8`

uint8x8_t vext_s8 (uint8x8_t a, uint8x8_t b, const int n)
A32: VEXT.8 Dd, Dn, Dm, #n
A64: EXT Vd.8B, Vn.8B, Vm.8B, #n


Instruction Documentation: [vext_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vext_s8)

## vextq_f32

`vextq_f32`

float32x4_t vextq_f32 (float32x4_t a, float32x4_t b, const int n)
A32: VEXT.8 Qd, Qn, Qm, #(n*4)
A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*4)


Instruction Documentation: [vextq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vextq_f32)

## vextq_f64

`vextq_f64`

float64x2_t vextq_f64 (float64x2_t a, float64x2_t b, const int n)
A32: VEXT.8 Qd, Qn, Qm, #(n*8)
A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*8)


Instruction Documentation: [vextq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vextq_f64)

## vextq_s16

`vextq_s16`

int16x8_t vextq_s16 (int16x8_t a, int16x8_t b, const int n)
A32: VEXT.8 Qd, Qn, Qm, #(n*2)
A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*2)


Instruction Documentation: [vextq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vextq_s16)

## vextq_s32

`vextq_s32`

int32x4_t vextq_s32 (int32x4_t a, int32x4_t b, const int n)
A32: VEXT.8 Qd, Qn, Qm, #(n*4)
A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*4)


Instruction Documentation: [vextq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vextq_s32)

## vextq_s64

`vextq_s64`

int64x2_t vextq_s64 (int64x2_t a, int64x2_t b, const int n)
A32: VEXT.8 Qd, Qn, Qm, #(n*8)
A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*8)


Instruction Documentation: [vextq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vextq_s64)

## vextq_s8

`vextq_s8`

uint8x16_t vextq_s8 (uint8x16_t a, uint8x16_t b, const int n)
A32: VEXT.8 Qd, Qn, Qm, #n
A64: EXT Vd.16B, Vn.16B, Vm.16B, #n


Instruction Documentation: [vextq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vextq_s8)

## vfma_f32

`vfma_f32`

float32x2_t vfma_f32 (float32x2_t a, float32x2_t b, float32x2_t c)
A32: VFMA.F32 Dd, Dn, Dm
A64: FMLA Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vfma_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfma_f32)

## vfma_f64

`vfma_f64`

float64x1_t vfma_f64 (float64x1_t a, float64x1_t b, float64x1_t c)
A32: VFMA.F64 Dd, Dn, Dm
A64: FMADD Dd, Dn, Dm, Da


Instruction Documentation: [vfma_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfma_f64)

## vfmaq_f32

`vfmaq_f32`

float32x4_t vfmaq_f32 (float32x4_t a, float32x4_t b, float32x4_t c)
A32: VFMA.F32 Qd, Qn, Qm
A64: FMLA Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vfmaq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmaq_f32)

## vfmas_f32

`vfmas_f32`

float32_t vfmas_f32 (float32_t a, float32_t b, float32_t c)
A32: VFMA.F32 Sd, Sn, Sm
A64: FMADD Sd, Sn, Sm, Sa The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vfmas_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmas_f32)

## vfms_f32

`vfms_f32`

float32x2_t vfms_f32 (float32x2_t a, float32x2_t b, float32x2_t c)
A32: VFMS.F32 Dd, Dn, Dm
A64: FMLS Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vfms_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfms_f32)

## vfms_f64

`vfms_f64`

float64x1_t vfms_f64 (float64x1_t a, float64x1_t b, float64x1_t c)
A32: VFMS.F64 Dd, Dn, Dm
A64: FMSUB Dd, Dn, Dm, Da


Instruction Documentation: [vfms_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfms_f64)

## vfmsq_f32

`vfmsq_f32`

float32x4_t vfmsq_f32 (float32x4_t a, float32x4_t b, float32x4_t c)
A32: VFMS.F32 Qd, Qn, Qm
A64: FMLS Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vfmsq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmsq_f32)

## vfmss_f32

`vfmss_f32`

float32_t vfmss_f32 (float32_t a, float32_t b, float32_t c)
A32: VFMS.F32 Sd, Sn, Sm
A64: FMSUB Sd, Sn, Sm, Sa The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vfmss_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmss_f32)

## vfnma_f64

`vfnma_f64`

float64x1_t vfnma_f64 (float64x1_t a, float64x1_t b, float64x1_t c)
A32: VFNMA.F64 Dd, Dn, Dm
A64: FNMADD Dd, Dn, Dm, Da The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vfnma_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfnma_f64)

## vfnmas_f32

`vfnmas_f32`

float32_t vfnmas_f32 (float32_t a, float32_t b, float32_t c)
A32: VFNMA.F32 Sd, Sn, Sm
A64: FNMADD Sd, Sn, Sm, Sa The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vfnmas_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfnmas_f32)

## vfnms_f64

`vfnms_f64`

float64x1_t vfnms_f64 (float64x1_t a, float64x1_t b, float64x1_t c)
A32: VFNMS.F64 Dd, Dn, Dm
A64: FNMSUB Dd, Dn, Dm, Da The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vfnms_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfnms_f64)

## vfnmss_f32

`vfnmss_f32`

float32_t vfnmss_f32 (float32_t a, float32_t b, float32_t c)
A32: VFNMS.F32 Sd, Sn, Sm
A64: FNMSUB Sd, Sn, Sm, Sa The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vfnmss_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfnmss_f32)

## vget_lane_f32

`vget_lane_f32`

float32_t vget_lane_f32 (float32x2_t v, const int lane)
A32: VMOV.F32 Sd, Sm
A64: DUP Sd, Vn.S[lane]


Instruction Documentation: [vget_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vget_lane_f32)

## vget_lane_s16

`vget_lane_s16`

int16_t vget_lane_s16 (int16x4_t v, const int lane)
A32: VMOV.S16 Rt, Dn[lane]
A64: SMOV Wd, Vn.H[lane]


Instruction Documentation: [vget_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vget_lane_s16)

## vget_lane_s32

`vget_lane_s32`

int32_t vget_lane_s32 (int32x2_t v, const int lane)
A32: VMOV.32 Rt, Dn[lane]
A64: SMOV Wd, Vn.S[lane]


Instruction Documentation: [vget_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vget_lane_s32)

## vget_lane_s8

`vget_lane_s8`

int8_t vget_lane_s8 (int8x8_t v, const int lane)
A32: VMOV.S8 Rt, Dn[lane]
A64: SMOV Wd, Vn.B[lane]


Instruction Documentation: [vget_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vget_lane_s8)

## vget_lane_u16

`vget_lane_u16`

uint16_t vget_lane_u16 (uint16x4_t v, const int lane)
A32: VMOV.U16 Rt, Dn[lane]
A64: UMOV Wd, Vn.H[lane]


Instruction Documentation: [vget_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vget_lane_u16)

## vget_lane_u32

`vget_lane_u32`

uint32_t vget_lane_u32 (uint32x2_t v, const int lane)
A32: VMOV.32 Rt, Dn[lane]
A64: UMOV Wd, Vn.S[lane]


Instruction Documentation: [vget_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vget_lane_u32)

## vget_lane_u8

`vget_lane_u8`

uint8_t vget_lane_u8 (uint8x8_t v, const int lane)
A32: VMOV.U8 Rt, Dn[lane]
A64: UMOV Wd, Vn.B[lane]


Instruction Documentation: [vget_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vget_lane_u8)

## vgetq_lane_f32

`vgetq_lane_f32`

float32_t vgetq_lane_f32 (float32x4_t v, const int lane)
A32: VMOV.F32 Sd, Sm
A64: DUP Sd, Vn.S[lane]


Instruction Documentation: [vgetq_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_f32)

## vgetq_lane_f64

`vgetq_lane_f64`

float64_t vgetq_lane_f64 (float64x2_t v, const int lane)
A32: VMOV.F64 Dd, Dm
A64: DUP Dd, Vn.D[lane]


Instruction Documentation: [vgetq_lane_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_f64)

## vgetq_lane_s16

`vgetq_lane_s16`

int16_t vgetq_lane_s16 (int16x8_t v, const int lane)
A32: VMOV.S16 Rt, Dn[lane]
A64: SMOV Wd, Vn.H[lane]


Instruction Documentation: [vgetq_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_s16)

## vgetq_lane_s32

`vgetq_lane_s32`

int32_t vgetq_lane_s32 (int32x4_t v, const int lane)
A32: VMOV.32 Rt, Dn[lane]
A64: SMOV Wd, Vn.S[lane]


Instruction Documentation: [vgetq_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_s32)

## vgetq_lane_s64

`vgetq_lane_s64`

int64_t vgetq_lane_s64 (int64x2_t v, const int lane)
A32: VMOV Rt, Rt2, Dm
A64: UMOV Xd, Vn.D[lane]


Instruction Documentation: [vgetq_lane_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_s64)

## vgetq_lane_s8

`vgetq_lane_s8`

int8_t vgetq_lane_s8 (int8x16_t v, const int lane)
A32: VMOV.S8 Rt, Dn[lane]
A64: SMOV Wd, Vn.B[lane]


Instruction Documentation: [vgetq_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_s8)

## vgetq_lane_u16

`vgetq_lane_u16`

uint16_t vgetq_lane_u16 (uint16x8_t v, const int lane)
A32: VMOV.U16 Rt, Dn[lane]
A64: UMOV Wd, Vn.H[lane]


Instruction Documentation: [vgetq_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_u16)

## vgetq_lane_u32

`vgetq_lane_u32`

uint32_t vgetq_lane_u32 (uint32x4_t v, const int lane)
A32: VMOV.32 Rt, Dn[lane]
A64: UMOV Wd, Vn.S[lane]


Instruction Documentation: [vgetq_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_u32)

## vgetq_lane_u64

`vgetq_lane_u64`

uint64_t vgetq_lane_u64 (uint64x2_t v, const int lane)
A32: VMOV Rt, Rt2, Dm
A64: UMOV Xd, Vn.D[lane]


Instruction Documentation: [vgetq_lane_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_u64)

## vgetq_lane_u8

`vgetq_lane_u8`

uint8_t vgetq_lane_u8 (uint8x16_t v, const int lane)
A32: VMOV.U8 Rt, Dn[lane]
A64: UMOV Wd, Vn.B[lane]


Instruction Documentation: [vgetq_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vgetq_lane_u8)

## vhadd_s16

`vhadd_s16`

int16x4_t vhadd_s16 (int16x4_t a, int16x4_t b)
A32: VHADD.S16 Dd, Dn, Dm
A64: SHADD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vhadd_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhadd_s16)

## vhadd_s32

`vhadd_s32`

int32x2_t vhadd_s32 (int32x2_t a, int32x2_t b)
A32: VHADD.S32 Dd, Dn, Dm
A64: SHADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vhadd_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhadd_s32)

## vhadd_s8

`vhadd_s8`

int8x8_t vhadd_s8 (int8x8_t a, int8x8_t b)
A32: VHADD.S8 Dd, Dn, Dm
A64: SHADD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vhadd_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhadd_s8)

## vhadd_u16

`vhadd_u16`

uint16x4_t vhadd_u16 (uint16x4_t a, uint16x4_t b)
A32: VHADD.U16 Dd, Dn, Dm
A64: UHADD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vhadd_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhadd_u16)

## vhadd_u32

`vhadd_u32`

uint32x2_t vhadd_u32 (uint32x2_t a, uint32x2_t b)
A32: VHADD.U32 Dd, Dn, Dm
A64: UHADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vhadd_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhadd_u32)

## vhadd_u8

`vhadd_u8`

uint8x8_t vhadd_u8 (uint8x8_t a, uint8x8_t b)
A32: VHADD.U8 Dd, Dn, Dm
A64: UHADD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vhadd_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhadd_u8)

## vhaddq_s16

`vhaddq_s16`

int16x8_t vhaddq_s16 (int16x8_t a, int16x8_t b)
A32: VHADD.S16 Qd, Qn, Qm
A64: SHADD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vhaddq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhaddq_s16)

## vhaddq_s32

`vhaddq_s32`

int32x4_t vhaddq_s32 (int32x4_t a, int32x4_t b)
A32: VHADD.S32 Qd, Qn, Qm
A64: SHADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vhaddq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhaddq_s32)

## vhaddq_s8

`vhaddq_s8`

int8x16_t vhaddq_s8 (int8x16_t a, int8x16_t b)
A32: VHADD.S8 Qd, Qn, Qm
A64: SHADD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vhaddq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhaddq_s8)

## vhaddq_u16

`vhaddq_u16`

uint16x8_t vhaddq_u16 (uint16x8_t a, uint16x8_t b)
A32: VHADD.U16 Qd, Qn, Qm
A64: UHADD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vhaddq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhaddq_u16)

## vhaddq_u32

`vhaddq_u32`

uint32x4_t vhaddq_u32 (uint32x4_t a, uint32x4_t b)
A32: VHADD.U32 Qd, Qn, Qm
A64: UHADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vhaddq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhaddq_u32)

## vhaddq_u8

`vhaddq_u8`

uint8x16_t vhaddq_u8 (uint8x16_t a, uint8x16_t b)
A32: VHADD.U8 Qd, Qn, Qm
A64: UHADD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vhaddq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhaddq_u8)

## vhsub_s16

`vhsub_s16`

int16x4_t vhsub_s16 (int16x4_t a, int16x4_t b)
A32: VHSUB.S16 Dd, Dn, Dm
A64: SHSUB Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vhsub_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsub_s16)

## vhsub_s32

`vhsub_s32`

int32x2_t vhsub_s32 (int32x2_t a, int32x2_t b)
A32: VHSUB.S32 Dd, Dn, Dm
A64: SHSUB Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vhsub_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsub_s32)

## vhsub_s8

`vhsub_s8`

int8x8_t vhsub_s8 (int8x8_t a, int8x8_t b)
A32: VHSUB.S8 Dd, Dn, Dm
A64: SHSUB Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vhsub_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsub_s8)

## vhsub_u16

`vhsub_u16`

uint16x4_t vhsub_u16 (uint16x4_t a, uint16x4_t b)
A32: VHSUB.U16 Dd, Dn, Dm
A64: UHSUB Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vhsub_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsub_u16)

## vhsub_u32

`vhsub_u32`

uint32x2_t vhsub_u32 (uint32x2_t a, uint32x2_t b)
A32: VHSUB.U32 Dd, Dn, Dm
A64: UHSUB Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vhsub_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsub_u32)

## vhsub_u8

`vhsub_u8`

uint8x8_t vhsub_u8 (uint8x8_t a, uint8x8_t b)
A32: VHSUB.U8 Dd, Dn, Dm
A64: UHSUB Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vhsub_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsub_u8)

## vhsubq_s16

`vhsubq_s16`

int16x8_t vhsubq_s16 (int16x8_t a, int16x8_t b)
A32: VHSUB.S16 Qd, Qn, Qm
A64: SHSUB Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vhsubq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsubq_s16)

## vhsubq_s32

`vhsubq_s32`

int32x4_t vhsubq_s32 (int32x4_t a, int32x4_t b)
A32: VHSUB.S32 Qd, Qn, Qm
A64: SHSUB Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vhsubq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsubq_s32)

## vhsubq_s8

`vhsubq_s8`

int8x16_t vhsubq_s8 (int8x16_t a, int8x16_t b)
A32: VHSUB.S8 Qd, Qn, Qm
A64: SHSUB Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vhsubq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsubq_s8)

## vhsubq_u16

`vhsubq_u16`

uint16x8_t vhsubq_u16 (uint16x8_t a, uint16x8_t b)
A32: VHSUB.U16 Qd, Qn, Qm
A64: UHSUB Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vhsubq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsubq_u16)

## vhsubq_u32

`vhsubq_u32`

uint32x4_t vhsubq_u32 (uint32x4_t a, uint32x4_t b)
A32: VHSUB.U32 Qd, Qn, Qm
A64: UHSUB Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vhsubq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsubq_u32)

## vhsubq_u8

`vhsubq_u8`

uint8x16_t vhsubq_u8 (uint8x16_t a, uint8x16_t b)
A32: VHSUB.U8 Qd, Qn, Qm
A64: UHSUB Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vhsubq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vhsubq_u8)

## vld1_dup_f32

`vld1_dup_f32`

float32x2_t vld1_dup_f32 (float32_t const * ptr)
A32: VLD1.32 { Dd[] }, [Rn]
A64: LD1R { Vt.2S }, [Xn]


Instruction Documentation: [vld1_dup_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_dup_f32)

## vld1_dup_s16

`vld1_dup_s16`

int16x4_t vld1_dup_s16 (int16_t const * ptr)
A32: VLD1.16 { Dd[] }, [Rn]
A64: LD1R { Vt.4H }, [Xn]


Instruction Documentation: [vld1_dup_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_dup_s16)

## vld1_dup_s32

`vld1_dup_s32`

int32x2_t vld1_dup_s32 (int32_t const * ptr)
A32: VLD1.32 { Dd[] }, [Rn]
A64: LD1R { Vt.2S }, [Xn]


Instruction Documentation: [vld1_dup_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_dup_s32)

## vld1_dup_s8

`vld1_dup_s8`

int8x8_t vld1_dup_s8 (int8_t const * ptr)
A32: VLD1.8 { Dd[] }, [Rn]
A64: LD1R { Vt.8B }, [Xn]


Instruction Documentation: [vld1_dup_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_dup_s8)

## vld1_dup_u16

`vld1_dup_u16`

uint16x4_t vld1_dup_u16 (uint16_t const * ptr)
A32: VLD1.16 { Dd[] }, [Rn]
A64: LD1R { Vt.4H }, [Xn]


Instruction Documentation: [vld1_dup_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_dup_u16)

## vld1_dup_u32

`vld1_dup_u32`

uint32x2_t vld1_dup_u32 (uint32_t const * ptr)
A32: VLD1.32 { Dd[] }, [Rn]
A64: LD1R { Vt.2S }, [Xn]


Instruction Documentation: [vld1_dup_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_dup_u32)

## vld1_dup_u8

`vld1_dup_u8`

uint8x8_t vld1_dup_u8 (uint8_t const * ptr)
A32: VLD1.8 { Dd[] }, [Rn]
A64: LD1R { Vt.8B }, [Xn]


Instruction Documentation: [vld1_dup_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_dup_u8)

## vld1_f32

`vld1_f32`

float32x2_t vld1_f32 (float32_t const * ptr)
A32: VLD1.32 Dd, [Rn]
A64: LD1 Vt.2S, [Xn]


Instruction Documentation: [vld1_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_f32)

## vld1_f64

`vld1_f64`

float64x1_t vld1_f64 (float64_t const * ptr)
A32: VLD1.64 Dd, [Rn]
A64: LD1 Vt.1D, [Xn]


Instruction Documentation: [vld1_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_f64)

## vld1_lane_f32

`vld1_lane_f32`

float32x2_t vld1_lane_f32 (float32_t const * ptr, float32x2_t src, const int lane)
A32: VLD1.32 { Dd[index] }, [Rn]
A64: LD1 { Vt.S }[index], [Xn]


Instruction Documentation: [vld1_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_lane_f32)

## vld1_lane_s16

`vld1_lane_s16`

int16x4_t vld1_lane_s16 (int16_t const * ptr, int16x4_t src, const int lane)
A32: VLD1.16 { Dd[index] }, [Rn]
A64: LD1 { Vt.H }[index], [Xn]


Instruction Documentation: [vld1_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_lane_s16)

## vld1_lane_s32

`vld1_lane_s32`

int32x2_t vld1_lane_s32 (int32_t const * ptr, int32x2_t src, const int lane)
A32: VLD1.32 { Dd[index] }, [Rn]
A64: LD1 { Vt.S }[index], [Xn]


Instruction Documentation: [vld1_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_lane_s32)

## vld1_lane_s8

`vld1_lane_s8`

int8x8_t vld1_lane_s8 (int8_t const * ptr, int8x8_t src, const int lane)
A32: VLD1.8 { Dd[index] }, [Rn]
A64: LD1 { Vt.B }[index], [Xn]


Instruction Documentation: [vld1_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_lane_s8)

## vld1_lane_u16

`vld1_lane_u16`

uint16x4_t vld1_lane_u16 (uint16_t const * ptr, uint16x4_t src, const int lane)
A32: VLD1.16 { Dd[index] }, [Rn]
A64: LD1 { Vt.H }[index], [Xn]


Instruction Documentation: [vld1_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_lane_u16)

## vld1_lane_u32

`vld1_lane_u32`

uint32x2_t vld1_lane_u32 (uint32_t const * ptr, uint32x2_t src, const int lane)
A32: VLD1.32 { Dd[index] }, [Rn]
A64: LD1 { Vt.S }[index], [Xn]


Instruction Documentation: [vld1_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_lane_u32)

## vld1_lane_u8

`vld1_lane_u8`

uint8x8_t vld1_lane_u8 (uint8_t const * ptr, uint8x8_t src, const int lane)
A32: VLD1.8 { Dd[index] }, [Rn]
A64: LD1 { Vt.B }[index], [Xn]


Instruction Documentation: [vld1_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_lane_u8)

## vld1_s16

`vld1_s16`

int16x4_t vld1_s16 (int16_t const * ptr)
A32: VLD1.16 Dd, [Rn]
A64: LD1 Vt.4H, [Xn]


Instruction Documentation: [vld1_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_s16)

## vld1_s32

`vld1_s32`

int32x2_t vld1_s32 (int32_t const * ptr)
A32: VLD1.32 Dd, [Rn]
A64: LD1 Vt.2S, [Xn]


Instruction Documentation: [vld1_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_s32)

## vld1_s64

`vld1_s64`

int64x1_t vld1_s64 (int64_t const * ptr)
A32: VLD1.64 Dd, [Rn]
A64: LD1 Vt.1D, [Xn]


Instruction Documentation: [vld1_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_s64)

## vld1_s8

`vld1_s8`

int8x8_t vld1_s8 (int8_t const * ptr)
A32: VLD1.8 Dd, [Rn]
A64: LD1 Vt.8B, [Xn]


Instruction Documentation: [vld1_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_s8)

## vld1_u16

`vld1_u16`

uint16x4_t vld1_u16 (uint16_t const * ptr)
A32: VLD1.16 Dd, [Rn]
A64: LD1 Vt.4H, [Xn]


Instruction Documentation: [vld1_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_u16)

## vld1_u32

`vld1_u32`

uint32x2_t vld1_u32 (uint32_t const * ptr)
A32: VLD1.32 Dd, [Rn]
A64: LD1 Vt.2S, [Xn]


Instruction Documentation: [vld1_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_u32)

## vld1_u64

`vld1_u64`

uint64x1_t vld1_u64 (uint64_t const * ptr)
A32: VLD1.64 Dd, [Rn]
A64: LD1 Vt.1D, [Xn]


Instruction Documentation: [vld1_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_u64)

## vld1_u8

`vld1_u8`

uint8x8_t vld1_u8 (uint8_t const * ptr)
A32: VLD1.8 Dd, [Rn]
A64: LD1 Vt.8B, [Xn]


Instruction Documentation: [vld1_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1_u8)

## vld1q_dup_f32

`vld1q_dup_f32`

float32x4_t vld1q_dup_f32 (float32_t const * ptr)
A32: VLD1.32 { Dd[], Dd+1[] }, [Rn]
A64: LD1R { Vt.4S }, [Xn]


Instruction Documentation: [vld1q_dup_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_f32)

## vld1q_dup_s16

`vld1q_dup_s16`

int16x8_t vld1q_dup_s16 (int16_t const * ptr)
A32: VLD1.16 { Dd[], Dd+1[] }, [Rn]
A64: LD1R { Vt.8H }, [Xn]


Instruction Documentation: [vld1q_dup_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_s16)

## vld1q_dup_s32

`vld1q_dup_s32`

int32x4_t vld1q_dup_s32 (int32_t const * ptr)
A32: VLD1.32 { Dd[], Dd+1[] }, [Rn]
A64: LD1R { Vt.4S }, [Xn]


Instruction Documentation: [vld1q_dup_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_s32)

## vld1q_dup_s8

`vld1q_dup_s8`

int8x16_t vld1q_dup_s8 (int8_t const * ptr)
A32: VLD1.8 { Dd[], Dd+1[] }, [Rn]
A64: LD1R { Vt.16B }, [Xn]


Instruction Documentation: [vld1q_dup_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_s8)

## vld1q_dup_u16

`vld1q_dup_u16`

uint16x8_t vld1q_dup_u16 (uint16_t const * ptr)
A32: VLD1.16 { Dd[], Dd+1[] }, [Rn]
A64: LD1R { Vt.8H }, [Xn]


Instruction Documentation: [vld1q_dup_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_u16)

## vld1q_dup_u32

`vld1q_dup_u32`

uint32x4_t vld1q_dup_u32 (uint32_t const * ptr)
A32: VLD1.32 { Dd[], Dd+1[] }, [Rn]
A64: LD1R { Vt.4S }, [Xn]


Instruction Documentation: [vld1q_dup_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_u32)

## vld1q_dup_u8

`vld1q_dup_u8`

uint8x16_t vld1q_dup_u8 (uint8_t const * ptr)
A32: VLD1.8 { Dd[], Dd+1[] }, [Rn]
A64: LD1R { Vt.16B }, [Xn]


Instruction Documentation: [vld1q_dup_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_u8)

## vld1q_f32

`vld1q_f32`

float32x4_t vld1q_f32 (float32_t const * ptr)
A32: VLD1.32 Dd, Dd+1, [Rn]
A64: LD1 Vt.4S, [Xn]


Instruction Documentation: [vld1q_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_f32)

## vld1q_f64

`vld1q_f64`

float64x2_t vld1q_f64 (float64_t const * ptr)
A32: VLD1.64 Dd, Dd+1, [Rn]
A64: LD1 Vt.2D, [Xn]


Instruction Documentation: [vld1q_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_f64)

## vld1q_lane_f32

`vld1q_lane_f32`

float32x4_t vld1q_lane_f32 (float32_t const * ptr, float32x4_t src, const int lane)
A32: VLD1.32 { Dd[index] }, [Rn]
A64: LD1 { Vt.S }[index], [Xn]


Instruction Documentation: [vld1q_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_f32)

## vld1q_lane_f64

`vld1q_lane_f64`

float64x2_t vld1q_lane_f64 (float64_t const * ptr, float64x2_t src, const int lane)
A32: VLDR.64 Dd, [Rn]
A64: LD1 { Vt.D }[index], [Xn]


Instruction Documentation: [vld1q_lane_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_f64)

## vld1q_lane_s16

`vld1q_lane_s16`

int16x8_t vld1q_lane_s16 (int16_t const * ptr, int16x8_t src, const int lane)
A32: VLD1.16 { Dd[index] }, [Rn]
A64: LD1 { Vt.H }[index], [Xn]


Instruction Documentation: [vld1q_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_s16)

## vld1q_lane_s32

`vld1q_lane_s32`

int32x4_t vld1q_lane_s32 (int32_t const * ptr, int32x4_t src, const int lane)
A32: VLD1.32 { Dd[index] }, [Rn]
A64: LD1 { Vt.S }[index], [Xn]


Instruction Documentation: [vld1q_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_s32)

## vld1q_lane_s64

`vld1q_lane_s64`

int64x2_t vld1q_lane_s64 (int64_t const * ptr, int64x2_t src, const int lane)
A32: VLDR.64 Dd, [Rn]
A64: LD1 { Vt.D }[index], [Xn]


Instruction Documentation: [vld1q_lane_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_s64)

## vld1q_lane_s8

`vld1q_lane_s8`

int8x16_t vld1q_lane_s8 (int8_t const * ptr, int8x16_t src, const int lane)
A32: VLD1.8 { Dd[index] }, [Rn]
A64: LD1 { Vt.B }[index], [Xn]


Instruction Documentation: [vld1q_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_s8)

## vld1q_lane_u16

`vld1q_lane_u16`

uint16x8_t vld1q_lane_u16 (uint16_t const * ptr, uint16x8_t src, const int lane)
A32: VLD1.16 { Dd[index] }, [Rn]
A64: LD1 { Vt.H }[index], [Xn]


Instruction Documentation: [vld1q_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_u16)

## vld1q_lane_u32

`vld1q_lane_u32`

uint32x4_t vld1q_lane_u32 (uint32_t const * ptr, uint32x4_t src, const int lane)
A32: VLD1.32 { Dd[index] }, [Rn]
A64: LD1 { Vt.S }[index], [Xn]


Instruction Documentation: [vld1q_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_u32)

## vld1q_lane_u64

`vld1q_lane_u64`

uint64x2_t vld1q_lane_u64 (uint64_t const * ptr, uint64x2_t src, const int lane)
A32: VLDR.64 Dd, [Rn]
A64: LD1 { Vt.D }[index], [Xn]


Instruction Documentation: [vld1q_lane_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_u64)

## vld1q_lane_u8

`vld1q_lane_u8`

uint8x16_t vld1q_lane_u8 (uint8_t const * ptr, uint8x16_t src, const int lane)
A32: VLD1.8 { Dd[index] }, [Rn]
A64: LD1 { Vt.B }[index], [Xn]


Instruction Documentation: [vld1q_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_lane_u8)

## vld1q_s16

`vld1q_s16`

int16x8_t vld1q_s16 (int16_t const * ptr)
A32: VLD1.16 Dd, Dd+1, [Rn]
A64: LD1 Vt.8H, [Xn]


Instruction Documentation: [vld1q_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_s16)

## vld1q_s32

`vld1q_s32`

int32x4_t vld1q_s32 (int32_t const * ptr)
A32: VLD1.32 Dd, Dd+1, [Rn]
A64: LD1 Vt.4S, [Xn]


Instruction Documentation: [vld1q_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_s32)

## vld1q_s64

`vld1q_s64`

int64x2_t vld1q_s64 (int64_t const * ptr)
A32: VLD1.64 Dd, Dd+1, [Rn]
A64: LD1 Vt.2D, [Xn]


Instruction Documentation: [vld1q_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_s64)

## vld1q_s8

`vld1q_s8`

int8x16_t vld1q_s8 (int8_t const * ptr)
A32: VLD1.8 Dd, Dd+1, [Rn]
A64: LD1 Vt.16B, [Xn]


Instruction Documentation: [vld1q_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_s8)

## vld1q_u64

`vld1q_u64`

uint64x2_t vld1q_u64 (uint64_t const * ptr)
A32: VLD1.64 Dd, Dd+1, [Rn]
A64: LD1 Vt.2D, [Xn]


Instruction Documentation: [vld1q_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_u64)

## vld1q_u8

`vld1q_u8`

uint8x16_t vld1q_u8 (uint8_t const * ptr)
A32: VLD1.8 Dd, Dd+1, [Rn]
A64: LD1 Vt.16B, [Xn]


Instruction Documentation: [vld1q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_u8)

## vmax_f32

`vmax_f32`

float32x2_t vmax_f32 (float32x2_t a, float32x2_t b)
A32: VMAX.F32 Dd, Dn, Dm
A64: FMAX Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmax_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmax_f32)

## vmax_s16

`vmax_s16`

int16x4_t vmax_s16 (int16x4_t a, int16x4_t b)
A32: VMAX.S16 Dd, Dn, Dm
A64: SMAX Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmax_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmax_s16)

## vmax_s32

`vmax_s32`

int32x2_t vmax_s32 (int32x2_t a, int32x2_t b)
A32: VMAX.S32 Dd, Dn, Dm
A64: SMAX Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmax_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmax_s32)

## vmax_s8

`vmax_s8`

int8x8_t vmax_s8 (int8x8_t a, int8x8_t b)
A32: VMAX.S8 Dd, Dn, Dm
A64: SMAX Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmax_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmax_s8)

## vmax_u16

`vmax_u16`

uint16x4_t vmax_u16 (uint16x4_t a, uint16x4_t b)
A32: VMAX.U16 Dd, Dn, Dm
A64: UMAX Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmax_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmax_u16)

## vmax_u32

`vmax_u32`

uint32x2_t vmax_u32 (uint32x2_t a, uint32x2_t b)
A32: VMAX.U32 Dd, Dn, Dm
A64: UMAX Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmax_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmax_u32)

## vmax_u8

`vmax_u8`

uint8x8_t vmax_u8 (uint8x8_t a, uint8x8_t b)
A32: VMAX.U8 Dd, Dn, Dm
A64: UMAX Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmax_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmax_u8)

## vmaxnm_f32

`vmaxnm_f32`

float32x2_t vmaxnm_f32 (float32x2_t a, float32x2_t b)
A32: VMAXNM.F32 Dd, Dn, Dm
A64: FMAXNM Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmaxnm_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxnm_f32)

## vmaxnm_f64

`vmaxnm_f64`

float64x1_t vmaxnm_f64 (float64x1_t a, float64x1_t b)
A32: VMAXNM.F64 Dd, Dn, Dm
A64: FMAXNM Dd, Dn, Dm


Instruction Documentation: [vmaxnm_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxnm_f64)

## vmaxnmq_f32

`vmaxnmq_f32`

float32x4_t vmaxnmq_f32 (float32x4_t a, float32x4_t b)
A32: VMAXNM.F32 Qd, Qn, Qm
A64: FMAXNM Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmaxnmq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxnmq_f32)

## vmaxnms_f32

`vmaxnms_f32`

float32_t vmaxnms_f32 (float32_t a, float32_t b)
A32: VMAXNM.F32 Sd, Sn, Sm
A64: FMAXNM Sd, Sn, Sm


Instruction Documentation: [vmaxnms_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxnms_f32)

## vmaxq_f32

`vmaxq_f32`

float32x4_t vmaxq_f32 (float32x4_t a, float32x4_t b)
A32: VMAX.F32 Qd, Qn, Qm
A64: FMAX Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmaxq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxq_f32)

## vmaxq_s16

`vmaxq_s16`

int16x8_t vmaxq_s16 (int16x8_t a, int16x8_t b)
A32: VMAX.S16 Qd, Qn, Qm
A64: SMAX Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vmaxq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxq_s16)

## vmaxq_s32

`vmaxq_s32`

int32x4_t vmaxq_s32 (int32x4_t a, int32x4_t b)
A32: VMAX.S32 Qd, Qn, Qm
A64: SMAX Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmaxq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxq_s32)

## vmaxq_s8

`vmaxq_s8`

int8x16_t vmaxq_s8 (int8x16_t a, int8x16_t b)
A32: VMAX.S8 Qd, Qn, Qm
A64: SMAX Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmaxq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxq_s8)

## vmaxq_u16

`vmaxq_u16`

uint16x8_t vmaxq_u16 (uint16x8_t a, uint16x8_t b)
A32: VMAX.U16 Qd, Qn, Qm
A64: UMAX Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vmaxq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxq_u16)

## vmaxq_u32

`vmaxq_u32`

uint32x4_t vmaxq_u32 (uint32x4_t a, uint32x4_t b)
A32: VMAX.U32 Qd, Qn, Qm
A64: UMAX Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmaxq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxq_u32)

## vmaxq_u8

`vmaxq_u8`

uint8x16_t vmaxq_u8 (uint8x16_t a, uint8x16_t b)
A32: VMAX.U8 Qd, Qn, Qm
A64: UMAX Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmaxq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxq_u8)

## vmin_f32

`vmin_f32`

float32x2_t vmin_f32 (float32x2_t a, float32x2_t b)
A32: VMIN.F32 Dd, Dn, Dm
A64: FMIN Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmin_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmin_f32)

## vmin_s16

`vmin_s16`

int16x4_t vmin_s16 (int16x4_t a, int16x4_t b)
A32: VMIN.S16 Dd, Dn, Dm
A64: SMIN Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmin_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmin_s16)

## vmin_s32

`vmin_s32`

int32x2_t vmin_s32 (int32x2_t a, int32x2_t b)
A32: VMIN.S32 Dd, Dn, Dm
A64: SMIN Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmin_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmin_s32)

## vmin_s8

`vmin_s8`

int8x8_t vmin_s8 (int8x8_t a, int8x8_t b)
A32: VMIN.S8 Dd, Dn, Dm
A64: SMIN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmin_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmin_s8)

## vmin_u16

`vmin_u16`

uint16x4_t vmin_u16 (uint16x4_t a, uint16x4_t b)
A32: VMIN.U16 Dd, Dn, Dm
A64: UMIN Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmin_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmin_u16)

## vmin_u32

`vmin_u32`

uint32x2_t vmin_u32 (uint32x2_t a, uint32x2_t b)
A32: VMIN.U32 Dd, Dn, Dm
A64: UMIN Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmin_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmin_u32)

## vmin_u8

`vmin_u8`

uint8x8_t vmin_u8 (uint8x8_t a, uint8x8_t b)
A32: VMIN.U8 Dd, Dn, Dm
A64: UMIN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmin_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmin_u8)

## vminnm_f32

`vminnm_f32`

float32x2_t vminnm_f32 (float32x2_t a, float32x2_t b)
A32: VMINNM.F32 Dd, Dn, Dm
A64: FMINNM Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vminnm_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminnm_f32)

## vminnm_f64

`vminnm_f64`

float64x1_t vminnm_f64 (float64x1_t a, float64x1_t b)
A32: VMINNM.F64 Dd, Dn, Dm
A64: FMINNM Dd, Dn, Dm


Instruction Documentation: [vminnm_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminnm_f64)

## vminnmq_f32

`vminnmq_f32`

float32x4_t vminnmq_f32 (float32x4_t a, float32x4_t b)
A32: VMINNM.F32 Qd, Qn, Qm
A64: FMINNM Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vminnmq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminnmq_f32)

## vminnms_f32

`vminnms_f32`

float32_t vminnms_f32 (float32_t a, float32_t b)
A32: VMINNM.F32 Sd, Sn, Sm
A64: FMINNM Sd, Sn, Sm


Instruction Documentation: [vminnms_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminnms_f32)

## vminq_f32

`vminq_f32`

float32x4_t vminq_f32 (float32x4_t a, float32x4_t b)
A32: VMIN.F32 Qd, Qn, Qm
A64: FMIN Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vminq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminq_f32)

## vminq_s16

`vminq_s16`

int16x8_t vminq_s16 (int16x8_t a, int16x8_t b)
A32: VMIN.S16 Qd, Qn, Qm
A64: SMIN Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vminq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminq_s16)

## vminq_s32

`vminq_s32`

int32x4_t vminq_s32 (int32x4_t a, int32x4_t b)
A32: VMIN.S32 Qd, Qn, Qm
A64: SMIN Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vminq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminq_s32)

## vminq_s8

`vminq_s8`

int8x16_t vminq_s8 (int8x16_t a, int8x16_t b)
A32: VMIN.S8 Qd, Qn, Qm
A64: SMIN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vminq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminq_s8)

## vminq_u16

`vminq_u16`

uint16x8_t vminq_u16 (uint16x8_t a, uint16x8_t b)
A32: VMIN.U16 Qd, Qn, Qm
A64: UMIN Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vminq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminq_u16)

## vminq_u32

`vminq_u32`

uint32x4_t vminq_u32 (uint32x4_t a, uint32x4_t b)
A32: VMIN.U32 Qd, Qn, Qm
A64: UMIN Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vminq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminq_u32)

## vminq_u8

`vminq_u8`

uint8x16_t vminq_u8 (uint8x16_t a, uint8x16_t b)
A32: VMIN.U8 Qd, Qn, Qm
A64: UMIN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vminq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminq_u8)

## vmla_lane_s16

`vmla_lane_s16`

int16x4_t vmla_lane_s16 (int16x4_t a, int16x4_t b, int16x4_t v, const int lane)
A32: VMLA.I16 Dd, Dn, Dm[lane]
A64: MLA Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmla_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_lane_s16)

## vmla_lane_s32

`vmla_lane_s32`

int32x2_t vmla_lane_s32 (int32x2_t a, int32x2_t b, int32x2_t v, const int lane)
A32: VMLA.I32 Dd, Dn, Dm[lane]
A64: MLA Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmla_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_lane_s32)

## vmla_lane_u16

`vmla_lane_u16`

uint16x4_t vmla_lane_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t v, const int lane)
A32: VMLA.I16 Dd, Dn, Dm[lane]
A64: MLA Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmla_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_lane_u16)

## vmla_lane_u32

`vmla_lane_u32`

uint32x2_t vmla_lane_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t v, const int lane)
A32: VMLA.I32 Dd, Dn, Dm[lane]
A64: MLA Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmla_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_lane_u32)

## vmla_laneq_s16

`vmla_laneq_s16`

int16x4_t vmla_laneq_s16 (int16x4_t a, int16x4_t b, int16x8_t v, const int lane)
A32: VMLA.I16 Dd, Dn, Dm[lane]
A64: MLA Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmla_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_laneq_s16)

## vmla_laneq_s32

`vmla_laneq_s32`

int32x2_t vmla_laneq_s32 (int32x2_t a, int32x2_t b, int32x4_t v, const int lane)
A32: VMLA.I32 Dd, Dn, Dm[lane]
A64: MLA Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmla_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_laneq_s32)

## vmla_laneq_u16

`vmla_laneq_u16`

uint16x4_t vmla_laneq_u16 (uint16x4_t a, uint16x4_t b, uint16x8_t v, const int lane)
A32: VMLA.I16 Dd, Dn, Dm[lane]
A64: MLA Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmla_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_laneq_u16)

## vmla_laneq_u32

`vmla_laneq_u32`

uint32x2_t vmla_laneq_u32 (uint32x2_t a, uint32x2_t b, uint32x4_t v, const int lane)
A32: VMLA.I32 Dd, Dn, Dm[lane]
A64: MLA Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmla_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_laneq_u32)

## vmla_n_s16

`vmla_n_s16`

int16x4_t vmla_n_s16 (int16x4_t a, int16x4_t b, int16_t c)
A32: VMLA.I16 Dd, Dn, Dm[0]
A64: MLA Vd.4H, Vn.4H, Vm.H[0]


Instruction Documentation: [vmla_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_n_s16)

## vmla_n_s32

`vmla_n_s32`

int32x2_t vmla_n_s32 (int32x2_t a, int32x2_t b, int32_t c)
A32: VMLA.I32 Dd, Dn, Dm[0]
A64: MLA Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vmla_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_n_s32)

## vmla_n_u16

`vmla_n_u16`

uint16x4_t vmla_n_u16 (uint16x4_t a, uint16x4_t b, uint16_t c)
A32: VMLA.I16 Dd, Dn, Dm[0]
A64: MLA Vd.4H, Vn.4H, Vm.H[0]


Instruction Documentation: [vmla_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_n_u16)

## vmla_n_u32

`vmla_n_u32`

uint32x2_t vmla_n_u32 (uint32x2_t a, uint32x2_t b, uint32_t c)
A32: VMLA.I32 Dd, Dn, Dm[0]
A64: MLA Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vmla_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_n_u32)

## vmla_s16

`vmla_s16`

int16x4_t vmla_s16 (int16x4_t a, int16x4_t b, int16x4_t c)
A32: VMLA.I16 Dd, Dn, Dm
A64: MLA Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmla_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_s16)

## vmla_s32

`vmla_s32`

int32x2_t vmla_s32 (int32x2_t a, int32x2_t b, int32x2_t c)
A32: VMLA.I32 Dd, Dn, Dm
A64: MLA Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmla_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_s32)

## vmla_s8

`vmla_s8`

int8x8_t vmla_s8 (int8x8_t a, int8x8_t b, int8x8_t c)
A32: VMLA.I8 Dd, Dn, Dm
A64: MLA Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmla_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_s8)

## vmla_u16

`vmla_u16`

uint16x4_t vmla_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t c)
A32: VMLA.I16 Dd, Dn, Dm
A64: MLA Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmla_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_u16)

## vmla_u32

`vmla_u32`

uint32x2_t vmla_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t c)
A32: VMLA.I32 Dd, Dn, Dm
A64: MLA Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmla_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_u32)

## vmla_u8

`vmla_u8`

uint8x8_t vmla_u8 (uint8x8_t a, uint8x8_t b, uint8x8_t c)
A32: VMLA.I8 Dd, Dn, Dm
A64: MLA Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmla_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmla_u8)

## vmlal_high_lane_s16

`vmlal_high_lane_s16`

int32x4_t vmlal_high_lane_s16 (int32x4_t a, int16x8_t b, int16x4_t v, const int lane)
A32: VMLAL.S16 Qd, Dn+1, Dm[lane]
A64: SMLAL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlal_high_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_lane_s16)

## vmlal_high_lane_s32

`vmlal_high_lane_s32`

int64x2_t vmlal_high_lane_s32 (int64x2_t a, int32x4_t b, int32x2_t v, const int lane)
A32: VMLAL.S32 Qd, Dn+1, Dm[lane]
A64: SMLAL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlal_high_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_lane_s32)

## vmlal_high_lane_u16

`vmlal_high_lane_u16`

uint32x4_t vmlal_high_lane_u16 (uint32x4_t a, uint16x8_t b, uint16x4_t v, const int lane)
A32: VMLAL.U16 Qd, Dn+1, Dm[lane]
A64: UMLAL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlal_high_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_lane_u16)

## vmlal_high_lane_u32

`vmlal_high_lane_u32`

uint64x2_t vmlal_high_lane_u32 (uint64x2_t a, uint32x4_t b, uint32x2_t v, const int lane)
A32: VMLAL.U32 Qd, Dn+1, Dm[lane]
A64: UMLAL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlal_high_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_lane_u32)

## vmlal_high_laneq_s16

`vmlal_high_laneq_s16`

int32x4_t vmlal_high_laneq_s16 (int32x4_t a, int16x8_t b, int16x8_t v, const int lane)
A32: VMLAL.S16 Qd, Dn+1, Dm[lane]
A64: SMLAL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlal_high_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_laneq_s16)

## vmlal_high_laneq_s32

`vmlal_high_laneq_s32`

int64x2_t vmlal_high_laneq_s32 (int64x2_t a, int32x4_t b, int32x4_t v, const int lane)
A32: VMLAL.S32 Qd, Dn+1, Dm[lane]
A64: SMLAL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlal_high_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_laneq_s32)

## vmlal_high_laneq_u16

`vmlal_high_laneq_u16`

uint32x4_t vmlal_high_laneq_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t v, const int lane)
A32: VMLAL.U16 Qd, Dn+1, Dm[lane]
A64: UMLAL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlal_high_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_laneq_u16)

## vmlal_high_laneq_u32

`vmlal_high_laneq_u32`

uint64x2_t vmlal_high_laneq_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t v, const int lane)
A32: VMLAL.U32 Qd, Dn+1, Dm[lane]
A64: UMLAL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlal_high_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_laneq_u32)

## vmlal_high_s16

`vmlal_high_s16`

int32x4_t vmlal_high_s16 (int32x4_t a, int16x8_t b, int16x8_t c)
A32: VMLAL.S16 Qd, Dn+1, Dm+1
A64: SMLAL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vmlal_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_s16)

## vmlal_high_s32

`vmlal_high_s32`

int64x2_t vmlal_high_s32 (int64x2_t a, int32x4_t b, int32x4_t c)
A32: VMLAL.S32 Qd, Dn+1, Dm+1
A64: SMLAL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vmlal_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_s32)

## vmlal_high_s8

`vmlal_high_s8`

int16x8_t vmlal_high_s8 (int16x8_t a, int8x16_t b, int8x16_t c)
A32: VMLAL.S8 Qd, Dn+1, Dm+1
A64: SMLAL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vmlal_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_s8)

## vmlal_high_u16

`vmlal_high_u16`

uint32x4_t vmlal_high_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t c)
A32: VMLAL.U16 Qd, Dn+1, Dm+1
A64: UMLAL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vmlal_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_u16)

## vmlal_high_u32

`vmlal_high_u32`

uint64x2_t vmlal_high_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t c)
A32: VMLAL.U32 Qd, Dn+1, Dm+1
A64: UMLAL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vmlal_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_u32)

## vmlal_high_u8

`vmlal_high_u8`

uint16x8_t vmlal_high_u8 (uint16x8_t a, uint8x16_t b, uint8x16_t c)
A32: VMLAL.U8 Qd, Dn+1, Dm+1
A64: UMLAL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vmlal_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_high_u8)

## vmlal_lane_s16

`vmlal_lane_s16`

int32x4_t vmlal_lane_s16 (int32x4_t a, int16x4_t b, int16x4_t v, const int lane)
A32: VMLAL.S16 Qd, Dn, Dm[lane]
A64: SMLAL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmlal_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_lane_s16)

## vmlal_lane_s32

`vmlal_lane_s32`

int64x2_t vmlal_lane_s32 (int64x2_t a, int32x2_t b, int32x2_t v, const int lane)
A32: VMLAL.S32 Qd, Dn, Dm[lane]
A64: SMLAL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmlal_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_lane_s32)

## vmlal_lane_u16

`vmlal_lane_u16`

uint32x4_t vmlal_lane_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t v, const int lane)
A32: VMLAL.U16 Qd, Dn, Dm[lane]
A64: UMLAL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmlal_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_lane_u16)

## vmlal_lane_u32

`vmlal_lane_u32`

uint64x2_t vmlal_lane_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t v, const int lane)
A32: VMLAL.U32 Qd, Dn, Dm[lane]
A64: UMLAL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmlal_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_lane_u32)

## vmlal_laneq_s16

`vmlal_laneq_s16`

int32x4_t vmlal_laneq_s16 (int32x4_t a, int16x4_t b, int16x8_t v, const int lane)
A32: VMLAL.S16 Qd, Dn, Dm[lane]
A64: SMLAL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmlal_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_laneq_s16)

## vmlal_laneq_s32

`vmlal_laneq_s32`

int64x2_t vmlal_laneq_s32 (int64x2_t a, int32x2_t b, int32x4_t v, const int lane)
A32: VMLAL.S32 Qd, Dn, Dm[lane]
A64: SMLAL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmlal_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_laneq_s32)

## vmlal_laneq_u16

`vmlal_laneq_u16`

uint32x4_t vmlal_laneq_u16 (uint32x4_t a, uint16x4_t b, uint16x8_t v, const int lane)
A32: VMLAL.U16 Qd, Dn, Dm[lane]
A64: UMLAL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmlal_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_laneq_u16)

## vmlal_laneq_u32

`vmlal_laneq_u32`

uint64x2_t vmlal_laneq_u32 (uint64x2_t a, uint32x2_t b, uint32x4_t v, const int lane)
A32: VMLAL.U32 Qd, Dn, Dm[lane]
A64: UMLAL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmlal_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_laneq_u32)

## vmlal_s16

`vmlal_s16`

int32x4_t vmlal_s16 (int32x4_t a, int16x4_t b, int16x4_t c)
A32: VMLAL.S16 Qd, Dn, Dm
A64: SMLAL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vmlal_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_s16)

## vmlal_s32

`vmlal_s32`

int64x2_t vmlal_s32 (int64x2_t a, int32x2_t b, int32x2_t c)
A32: VMLAL.S32 Qd, Dn, Dm
A64: SMLAL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vmlal_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_s32)

## vmlal_s8

`vmlal_s8`

int16x8_t vmlal_s8 (int16x8_t a, int8x8_t b, int8x8_t c)
A32: VMLAL.S8 Qd, Dn, Dm
A64: SMLAL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vmlal_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_s8)

## vmlal_u16

`vmlal_u16`

uint32x4_t vmlal_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t c)
A32: VMLAL.U16 Qd, Dn, Dm
A64: UMLAL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vmlal_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_u16)

## vmlal_u32

`vmlal_u32`

uint64x2_t vmlal_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t c)
A32: VMLAL.U32 Qd, Dn, Dm
A64: UMLAL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vmlal_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_u32)

## vmlal_u8

`vmlal_u8`

uint16x8_t vmlal_u8 (uint16x8_t a, uint8x8_t b, uint8x8_t c)
A32: VMLAL.U8 Qd, Dn, Dm
A64: UMLAL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vmlal_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlal_u8)

## vmlaq_lane_s16

`vmlaq_lane_s16`

int16x8_t vmlaq_lane_s16 (int16x8_t a, int16x8_t b, int16x4_t v, const int lane)
A32: VMLA.I16 Qd, Qn, Dm[lane]
A64: MLA Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlaq_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_lane_s16)

## vmlaq_lane_s32

`vmlaq_lane_s32`

int32x4_t vmlaq_lane_s32 (int32x4_t a, int32x4_t b, int32x2_t v, const int lane)
A32: VMLA.I32 Qd, Qn, Dm[lane]
A64: MLA Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlaq_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_lane_s32)

## vmlaq_lane_u16

`vmlaq_lane_u16`

uint16x8_t vmlaq_lane_u16 (uint16x8_t a, uint16x8_t b, uint16x4_t v, const int lane)
A32: VMLA.I16 Qd, Qn, Dm[lane]
A64: MLA Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlaq_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_lane_u16)

## vmlaq_lane_u32

`vmlaq_lane_u32`

uint32x4_t vmlaq_lane_u32 (uint32x4_t a, uint32x4_t b, uint32x2_t v, const int lane)
A32: VMLA.I32 Qd, Qn, Dm[lane]
A64: MLA Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlaq_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_lane_u32)

## vmlaq_laneq_s16

`vmlaq_laneq_s16`

int16x8_t vmlaq_laneq_s16 (int16x8_t a, int16x8_t b, int16x8_t v, const int lane)
A32: VMLA.I16 Qd, Qn, Dm[lane]
A64: MLA Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlaq_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_laneq_s16)

## vmlaq_laneq_s32

`vmlaq_laneq_s32`

int32x4_t vmlaq_laneq_s32 (int32x4_t a, int32x4_t b, int32x4_t v, const int lane)
A32: VMLA.I32 Qd, Qn, Dm[lane]
A64: MLA Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlaq_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_laneq_s32)

## vmlaq_laneq_u16

`vmlaq_laneq_u16`

uint16x8_t vmlaq_laneq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t v, const int lane)
A32: VMLA.I16 Qd, Qn, Dm[lane]
A64: MLA Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlaq_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_laneq_u16)

## vmlaq_laneq_u32

`vmlaq_laneq_u32`

uint32x4_t vmlaq_laneq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t v, const int lane)
A32: VMLA.I32 Qd, Qn, Dm[lane]
A64: MLA Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlaq_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_laneq_u32)

## vmlaq_n_s16

`vmlaq_n_s16`

int16x8_t vmlaq_n_s16 (int16x8_t a, int16x8_t b, int16_t c)
A32: VMLA.I16 Qd, Qn, Dm[0]
A64: MLA Vd.8H, Vn.8H, Vm.H[0]


Instruction Documentation: [vmlaq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_n_s16)

## vmlaq_n_s32

`vmlaq_n_s32`

int32x4_t vmlaq_n_s32 (int32x4_t a, int32x4_t b, int32_t c)
A32: VMLA.I32 Qd, Qn, Dm[0]
A64: MLA Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vmlaq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_n_s32)

## vmlaq_n_u16

`vmlaq_n_u16`

uint16x8_t vmlaq_n_u16 (uint16x8_t a, uint16x8_t b, uint16_t c)
A32: VMLA.I16 Qd, Qn, Dm[0]
A64: MLA Vd.8H, Vn.8H, Vm.H[0]


Instruction Documentation: [vmlaq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_n_u16)

## vmlaq_n_u32

`vmlaq_n_u32`

uint32x4_t vmlaq_n_u32 (uint32x4_t a, uint32x4_t b, uint32_t c)
A32: VMLA.I32 Qd, Qn, Dm[0]
A64: MLA Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vmlaq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_n_u32)

## vmlaq_s16

`vmlaq_s16`

int16x8_t vmlaq_s16 (int16x8_t a, int16x8_t b, int16x8_t c)
A32: VMLA.I16 Qd, Qn, Qm
A64: MLA Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vmlaq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_s16)

## vmlaq_s32

`vmlaq_s32`

int32x4_t vmlaq_s32 (int32x4_t a, int32x4_t b, int32x4_t c)
A32: VMLA.I32 Qd, Qn, Qm
A64: MLA Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmlaq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_s32)

## vmlaq_s8

`vmlaq_s8`

int8x16_t vmlaq_s8 (int8x16_t a, int8x16_t b, int8x16_t c)
A32: VMLA.I8 Qd, Qn, Qm
A64: MLA Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmlaq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_s8)

## vmlaq_u16

`vmlaq_u16`

uint16x8_t vmlaq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t c)
A32: VMLA.I16 Qd, Qn, Qm
A64: MLA Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vmlaq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_u16)

## vmlaq_u32

`vmlaq_u32`

uint32x4_t vmlaq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t c)
A32: VMLA.I32 Qd, Qn, Qm
A64: MLA Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmlaq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_u32)

## vmlaq_u8

`vmlaq_u8`

uint8x16_t vmlaq_u8 (uint8x16_t a, uint8x16_t b, uint8x16_t c)
A32: VMLA.I8 Qd, Qn, Qm
A64: MLA Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmlaq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlaq_u8)

## vmls_lane_s16

`vmls_lane_s16`

int16x4_t vmls_lane_s16 (int16x4_t a, int16x4_t b, int16x4_t v, const int lane)
A32: VMLS.I16 Dd, Dn, Dm[lane]
A64: MLS Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmls_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_lane_s16)

## vmls_lane_s32

`vmls_lane_s32`

int32x2_t vmls_lane_s32 (int32x2_t a, int32x2_t b, int32x2_t v, const int lane)
A32: VMLS.I32 Dd, Dn, Dm[lane]
A64: MLS Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmls_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_lane_s32)

## vmls_lane_u16

`vmls_lane_u16`

uint16x4_t vmls_lane_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t v, const int lane)
A32: VMLS.I16 Dd, Dn, Dm[lane]
A64: MLS Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmls_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_lane_u16)

## vmls_lane_u32

`vmls_lane_u32`

uint32x2_t vmls_lane_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t v, const int lane)
A32: VMLS.I32 Dd, Dn, Dm[lane]
A64: MLS Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmls_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_lane_u32)

## vmls_laneq_s16

`vmls_laneq_s16`

int16x4_t vmls_laneq_s16 (int16x4_t a, int16x4_t b, int16x8_t v, const int lane)
A32: VMLS.I16 Dd, Dn, Dm[lane]
A64: MLS Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmls_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_laneq_s16)

## vmls_laneq_s32

`vmls_laneq_s32`

int32x2_t vmls_laneq_s32 (int32x2_t a, int32x2_t b, int32x4_t v, const int lane)
A32: VMLS.I32 Dd, Dn, Dm[lane]
A64: MLS Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmls_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_laneq_s32)

## vmls_laneq_u16

`vmls_laneq_u16`

uint16x4_t vmls_laneq_u16 (uint16x4_t a, uint16x4_t b, uint16x8_t v, const int lane)
A32: VMLS.I16 Dd, Dn, Dm[lane]
A64: MLS Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmls_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_laneq_u16)

## vmls_laneq_u32

`vmls_laneq_u32`

uint32x2_t vmls_laneq_u32 (uint32x2_t a, uint32x2_t b, uint32x4_t v, const int lane)
A32: VMLS.I32 Dd, Dn, Dm[lane]
A64: MLS Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmls_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_laneq_u32)

## vmls_n_s16

`vmls_n_s16`

int16x4_t vmls_n_s16 (int16x4_t a, int16x4_t b, int16_t c)
A32: VMLS.I16 Dd, Dn, Dm[0]
A64: MLS Vd.4H, Vn.4H, Vm.H[0]


Instruction Documentation: [vmls_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_n_s16)

## vmls_n_s32

`vmls_n_s32`

int32x2_t vmls_n_s32 (int32x2_t a, int32x2_t b, int32_t c)
A32: VMLS.I32 Dd, Dn, Dm[0]
A64: MLS Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vmls_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_n_s32)

## vmls_n_u16

`vmls_n_u16`

uint16x4_t vmls_n_u16 (uint16x4_t a, uint16x4_t b, uint16_t c)
A32: VMLS.I16 Dd, Dn, Dm[0]
A64: MLS Vd.4H, Vn.4H, Vm.H[0]


Instruction Documentation: [vmls_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_n_u16)

## vmls_n_u32

`vmls_n_u32`

uint32x2_t vmls_n_u32 (uint32x2_t a, uint32x2_t b, uint32_t c)
A32: VMLS.I32 Dd, Dn, Dm[0]
A64: MLS Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vmls_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_n_u32)

## vmls_s16

`vmls_s16`

int16x4_t vmls_s16 (int16x4_t a, int16x4_t b, int16x4_t c)
A32: VMLS.I16 Dd, Dn, Dm
A64: MLS Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmls_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_s16)

## vmls_s32

`vmls_s32`

int32x2_t vmls_s32 (int32x2_t a, int32x2_t b, int32x2_t c)
A32: VMLS.I32 Dd, Dn, Dm
A64: MLS Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmls_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_s32)

## vmls_s8

`vmls_s8`

int8x8_t vmls_s8 (int8x8_t a, int8x8_t b, int8x8_t c)
A32: VMLS.I8 Dd, Dn, Dm
A64: MLS Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmls_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_s8)

## vmls_u16

`vmls_u16`

uint16x4_t vmls_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t c)
A32: VMLS.I16 Dd, Dn, Dm
A64: MLS Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmls_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_u16)

## vmls_u32

`vmls_u32`

uint32x2_t vmls_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t c)
A32: VMLS.I32 Dd, Dn, Dm
A64: MLS Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmls_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_u32)

## vmls_u8

`vmls_u8`

uint8x8_t vmls_u8 (uint8x8_t a, uint8x8_t b, uint8x8_t c)
A32: VMLS.I8 Dd, Dn, Dm
A64: MLS Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmls_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmls_u8)

## vmlsl_high_lane_s16

`vmlsl_high_lane_s16`

int32x4_t vmlsl_high_lane_s16 (int32x4_t a, int16x8_t b, int16x4_t v, const int lane)
A32: VMLSL.S16 Qd, Dn+1, Dm[lane]
A64: SMLSL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlsl_high_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_lane_s16)

## vmlsl_high_lane_s32

`vmlsl_high_lane_s32`

int64x2_t vmlsl_high_lane_s32 (int64x2_t a, int32x4_t b, int32x2_t v, const int lane)
A32: VMLSL.S32 Qd, Dn+1, Dm[lane]
A64: SMLSL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlsl_high_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_lane_s32)

## vmlsl_high_lane_u16

`vmlsl_high_lane_u16`

uint32x4_t vmlsl_high_lane_u16 (uint32x4_t a, uint16x8_t b, uint16x4_t v, const int lane)
A32: VMLSL.U16 Qd, Dn+1, Dm[lane]
A64: UMLSL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlsl_high_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_lane_u16)

## vmlsl_high_lane_u32

`vmlsl_high_lane_u32`

uint64x2_t vmlsl_high_lane_u32 (uint64x2_t a, uint32x4_t b, uint32x2_t v, const int lane)
A32: VMLSL.U32 Qd, Dn+1, Dm[lane]
A64: UMLSL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlsl_high_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_lane_u32)

## vmlsl_high_laneq_s16

`vmlsl_high_laneq_s16`

int32x4_t vmlsl_high_laneq_s16 (int32x4_t a, int16x8_t b, int16x8_t v, const int lane)
A32: VMLSL.S16 Qd, Dn+1, Dm[lane]
A64: SMLSL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlsl_high_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_laneq_s16)

## vmlsl_high_laneq_s32

`vmlsl_high_laneq_s32`

int64x2_t vmlsl_high_laneq_s32 (int64x2_t a, int32x4_t b, int32x4_t v, const int lane)
A32: VMLSL.S32 Qd, Dn+1, Dm[lane]
A64: SMLSL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlsl_high_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_laneq_s32)

## vmlsl_high_laneq_u16

`vmlsl_high_laneq_u16`

uint32x4_t vmlsl_high_laneq_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t v, const int lane)
A32: VMLSL.U16 Qd, Dn+1, Dm[lane]
A64: UMLSL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlsl_high_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_laneq_u16)

## vmlsl_high_laneq_u32

`vmlsl_high_laneq_u32`

uint64x2_t vmlsl_high_laneq_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t v, const int lane)
A32: VMLSL.U32 Qd, Dn+1, Dm[lane]
A64: UMLSL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlsl_high_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_laneq_u32)

## vmlsl_high_s16

`vmlsl_high_s16`

int32x4_t vmlsl_high_s16 (int32x4_t a, int16x8_t b, int16x8_t c)
A32: VMLSL.S16 Qd, Dn+1, Dm+1
A64: SMLSL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vmlsl_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_s16)

## vmlsl_high_s32

`vmlsl_high_s32`

int64x2_t vmlsl_high_s32 (int64x2_t a, int32x4_t b, int32x4_t c)
A32: VMLSL.S32 Qd, Dn+1, Dm+1
A64: SMLSL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vmlsl_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_s32)

## vmlsl_high_s8

`vmlsl_high_s8`

int16x8_t vmlsl_high_s8 (int16x8_t a, int8x16_t b, int8x16_t c)
A32: VMLSL.S8 Qd, Dn+1, Dm+1
A64: SMLSL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vmlsl_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_s8)

## vmlsl_high_u16

`vmlsl_high_u16`

uint32x4_t vmlsl_high_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t c)
A32: VMLSL.U16 Qd, Dn+1, Dm+1
A64: UMLSL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vmlsl_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_u16)

## vmlsl_high_u32

`vmlsl_high_u32`

uint64x2_t vmlsl_high_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t c)
A32: VMLSL.U32 Qd, Dn+1, Dm+1
A64: UMLSL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vmlsl_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_u32)

## vmlsl_high_u8

`vmlsl_high_u8`

uint16x8_t vmlsl_high_u8 (uint16x8_t a, uint8x16_t b, uint8x16_t c)
A32: VMLSL.U8 Qd, Dn+1, Dm+1
A64: UMLSL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vmlsl_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_high_u8)

## vmlsl_lane_s16

`vmlsl_lane_s16`

int32x4_t vmlsl_lane_s16 (int32x4_t a, int16x4_t b, int16x4_t v, const int lane)
A32: VMLSL.S16 Qd, Dn, Dm[lane]
A64: SMLSL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmlsl_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_lane_s16)

## vmlsl_lane_s32

`vmlsl_lane_s32`

int64x2_t vmlsl_lane_s32 (int64x2_t a, int32x2_t b, int32x2_t v, const int lane)
A32: VMLSL.S32 Qd, Dn, Dm[lane]
A64: SMLSL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmlsl_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_lane_s32)

## vmlsl_lane_u16

`vmlsl_lane_u16`

uint32x4_t vmlsl_lane_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t v, const int lane)
A32: VMLSL.U16 Qd, Dn, Dm[lane]
A64: UMLSL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmlsl_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_lane_u16)

## vmlsl_lane_u32

`vmlsl_lane_u32`

uint64x2_t vmlsl_lane_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t v, const int lane)
A32: VMLSL.U32 Qd, Dn, Dm[lane]
A64: UMLSL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmlsl_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_lane_u32)

## vmlsl_laneq_s16

`vmlsl_laneq_s16`

int32x4_t vmlsl_laneq_s16 (int32x4_t a, int16x4_t b, int16x8_t v, const int lane)
A32: VMLSL.S16 Qd, Dn, Dm[lane]
A64: SMLSL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmlsl_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_laneq_s16)

## vmlsl_laneq_s32

`vmlsl_laneq_s32`

int64x2_t vmlsl_laneq_s32 (int64x2_t a, int32x2_t b, int32x4_t v, const int lane)
A32: VMLSL.S32 Qd, Dn, Dm[lane]
A64: SMLSL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmlsl_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_laneq_s32)

## vmlsl_laneq_u16

`vmlsl_laneq_u16`

uint32x4_t vmlsl_laneq_u16 (uint32x4_t a, uint16x4_t b, uint16x8_t v, const int lane)
A32: VMLSL.U16 Qd, Dn, Dm[lane]
A64: UMLSL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmlsl_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_laneq_u16)

## vmlsl_laneq_u32

`vmlsl_laneq_u32`

uint64x2_t vmlsl_laneq_u32 (uint64x2_t a, uint32x2_t b, uint32x4_t v, const int lane)
A32: VMLSL.U32 Qd, Dn, Dm[lane]
A64: UMLSL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmlsl_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_laneq_u32)

## vmlsl_s16

`vmlsl_s16`

int32x4_t vmlsl_s16 (int32x4_t a, int16x4_t b, int16x4_t c)
A32: VMLSL.S16 Qd, Dn, Dm
A64: SMLSL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vmlsl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_s16)

## vmlsl_s32

`vmlsl_s32`

int64x2_t vmlsl_s32 (int64x2_t a, int32x2_t b, int32x2_t c)
A32: VMLSL.S32 Qd, Dn, Dm
A64: SMLSL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vmlsl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_s32)

## vmlsl_s8

`vmlsl_s8`

int16x8_t vmlsl_s8 (int16x8_t a, int8x8_t b, int8x8_t c)
A32: VMLSL.S8 Qd, Dn, Dm
A64: SMLSL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vmlsl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_s8)

## vmlsl_u16

`vmlsl_u16`

uint32x4_t vmlsl_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t c)
A32: VMLSL.U16 Qd, Dn, Dm
A64: UMLSL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vmlsl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_u16)

## vmlsl_u32

`vmlsl_u32`

uint64x2_t vmlsl_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t c)
A32: VMLSL.U32 Qd, Dn, Dm
A64: UMLSL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vmlsl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_u32)

## vmlsl_u8

`vmlsl_u8`

uint16x8_t vmlsl_u8 (uint16x8_t a, uint8x8_t b, uint8x8_t c)
A32: VMLSL.U8 Qd, Dn, Dm
A64: UMLSL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vmlsl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsl_u8)

## vmlsq_lane_s16

`vmlsq_lane_s16`

int16x8_t vmlsq_lane_s16 (int16x8_t a, int16x8_t b, int16x4_t v, const int lane)
A32: VMLS.I16 Qd, Qn, Dm[lane]
A64: MLS Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlsq_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_lane_s16)

## vmlsq_lane_s32

`vmlsq_lane_s32`

int32x4_t vmlsq_lane_s32 (int32x4_t a, int32x4_t b, int32x2_t v, const int lane)
A32: VMLS.I32 Qd, Qn, Dm[lane]
A64: MLS Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlsq_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_lane_s32)

## vmlsq_lane_u16

`vmlsq_lane_u16`

uint16x8_t vmlsq_lane_u16 (uint16x8_t a, uint16x8_t b, uint16x4_t v, const int lane)
A32: VMLS.I16 Qd, Qn, Dm[lane]
A64: MLS Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlsq_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_lane_u16)

## vmlsq_lane_u32

`vmlsq_lane_u32`

uint32x4_t vmlsq_lane_u32 (uint32x4_t a, uint32x4_t b, uint32x2_t v, const int lane)
A32: VMLS.I32 Qd, Qn, Dm[lane]
A64: MLS Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlsq_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_lane_u32)

## vmlsq_laneq_s16

`vmlsq_laneq_s16`

int16x8_t vmlsq_laneq_s16 (int16x8_t a, int16x8_t b, int16x8_t v, const int lane)
A32: VMLS.I16 Qd, Qn, Dm[lane]
A64: MLS Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlsq_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_laneq_s16)

## vmlsq_laneq_s32

`vmlsq_laneq_s32`

int32x4_t vmlsq_laneq_s32 (int32x4_t a, int32x4_t b, int32x4_t v, const int lane)
A32: VMLS.I32 Qd, Qn, Dm[lane]
A64: MLS Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlsq_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_laneq_s32)

## vmlsq_laneq_u16

`vmlsq_laneq_u16`

uint16x8_t vmlsq_laneq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t v, const int lane)
A32: VMLS.I16 Qd, Qn, Dm[lane]
A64: MLS Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmlsq_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_laneq_u16)

## vmlsq_laneq_u32

`vmlsq_laneq_u32`

uint32x4_t vmlsq_laneq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t v, const int lane)
A32: VMLS.I32 Qd, Qn, Dm[lane]
A64: MLS Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmlsq_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_laneq_u32)

## vmlsq_n_s16

`vmlsq_n_s16`

int16x8_t vmlsq_n_s16 (int16x8_t a, int16x8_t b, int16_t c)
A32: VMLS.I16 Qd, Qn, Dm[0]
A64: MLS Vd.8H, Vn.8H, Vm.H[0]


Instruction Documentation: [vmlsq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_n_s16)

## vmlsq_n_s32

`vmlsq_n_s32`

int32x4_t vmlsq_n_s32 (int32x4_t a, int32x4_t b, int32_t c)
A32: VMLS.I32 Qd, Qn, Dm[0]
A64: MLS Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vmlsq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_n_s32)

## vmlsq_n_u16

`vmlsq_n_u16`

uint16x8_t vmlsq_n_u16 (uint16x8_t a, uint16x8_t b, uint16_t c)
A32: VMLS.I16 Qd, Qn, Dm[0]
A64: MLS Vd.8H, Vn.8H, Vm.H[0]


Instruction Documentation: [vmlsq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_n_u16)

## vmlsq_n_u32

`vmlsq_n_u32`

uint32x4_t vmlsq_n_u32 (uint32x4_t a, uint32x4_t b, uint32_t c)
A32: VMLS.I32 Qd, Qn, Dm[0]
A64: MLS Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vmlsq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_n_u32)

## vmlsq_s16

`vmlsq_s16`

int16x8_t vmlsq_s16 (int16x8_t a, int16x8_t b, int16x8_t c)
A32: VMLS.I16 Qd, Qn, Qm
A64: MLS Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vmlsq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_s16)

## vmlsq_s32

`vmlsq_s32`

int32x4_t vmlsq_s32 (int32x4_t a, int32x4_t b, int32x4_t c)
A32: VMLS.I32 Qd, Qn, Qm
A64: MLS Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmlsq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_s32)

## vmlsq_s8

`vmlsq_s8`

int8x16_t vmlsq_s8 (int8x16_t a, int8x16_t b, int8x16_t c)
A32: VMLS.I8 Qd, Qn, Qm
A64: MLS Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmlsq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_s8)

## vmlsq_u16

`vmlsq_u16`

uint16x8_t vmlsq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t c)
A32: VMLS.I16 Qd, Qn, Qm
A64: MLS Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vmlsq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_u16)

## vmlsq_u32

`vmlsq_u32`

uint32x4_t vmlsq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t c)
A32: VMLS.I32 Qd, Qn, Qm
A64: MLS Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmlsq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_u32)

## vmlsq_u8

`vmlsq_u8`

uint8x16_t vmlsq_u8 (uint8x16_t a, uint8x16_t b, uint8x16_t c)
A32: VMLS.I8 Qd, Qn, Qm
A64: MLS Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmlsq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmlsq_u8)

## vmovl_high_s16

`vmovl_high_s16`

int32x4_t vmovl_high_s16 (int16x8_t a)
A32: VMOVL.S16 Qd, Dm+1
A64: SXTL2 Vd.4S, Vn.8H


Instruction Documentation: [vmovl_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_high_s16)

## vmovl_high_s32

`vmovl_high_s32`

int64x2_t vmovl_high_s32 (int32x4_t a)
A32: VMOVL.S32 Qd, Dm+1
A64: SXTL2 Vd.2D, Vn.4S


Instruction Documentation: [vmovl_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_high_s32)

## vmovl_high_s8

`vmovl_high_s8`

int16x8_t vmovl_high_s8 (int8x16_t a)
A32: VMOVL.S8 Qd, Dm+1
A64: SXTL2 Vd.8H, Vn.16B


Instruction Documentation: [vmovl_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_high_s8)

## vmovl_high_u16

`vmovl_high_u16`

uint32x4_t vmovl_high_u16 (uint16x8_t a)
A32: VMOVL.U16 Qd, Dm+1
A64: UXTL2 Vd.4S, Vn.8H


Instruction Documentation: [vmovl_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_high_u16)

## vmovl_high_u32

`vmovl_high_u32`

uint64x2_t vmovl_high_u32 (uint32x4_t a)
A32: VMOVL.U32 Qd, Dm+1
A64: UXTL2 Vd.2D, Vn.4S


Instruction Documentation: [vmovl_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_high_u32)

## vmovl_high_u8

`vmovl_high_u8`

uint16x8_t vmovl_high_u8 (uint8x16_t a)
A32: VMOVL.U8 Qd, Dm+1
A64: UXTL2 Vd.8H, Vn.16B


Instruction Documentation: [vmovl_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_high_u8)

## vmovl_s16

`vmovl_s16`

int32x4_t vmovl_s16 (int16x4_t a)
A32: VMOVL.S16 Qd, Dm
A64: SXTL Vd.4S, Vn.4H


Instruction Documentation: [vmovl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_s16)

## vmovl_s32

`vmovl_s32`

int64x2_t vmovl_s32 (int32x2_t a)
A32: VMOVL.S32 Qd, Dm
A64: SXTL Vd.2D, Vn.2S


Instruction Documentation: [vmovl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_s32)

## vmovl_s8

`vmovl_s8`

int16x8_t vmovl_s8 (int8x8_t a)
A32: VMOVL.S8 Qd, Dm
A64: SXTL Vd.8H, Vn.8B


Instruction Documentation: [vmovl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_s8)

## vmovl_u16

`vmovl_u16`

uint32x4_t vmovl_u16 (uint16x4_t a)
A32: VMOVL.U16 Qd, Dm
A64: UXTL Vd.4S, Vn.4H


Instruction Documentation: [vmovl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_u16)

## vmovl_u32

`vmovl_u32`

uint64x2_t vmovl_u32 (uint32x2_t a)
A32: VMOVL.U32 Qd, Dm
A64: UXTL Vd.2D, Vn.2S


Instruction Documentation: [vmovl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_u32)

## vmovl_u8

`vmovl_u8`

uint16x8_t vmovl_u8 (uint8x8_t a)
A32: VMOVL.U8 Qd, Dm
A64: UXTL Vd.8H, Vn.8B


Instruction Documentation: [vmovl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovl_u8)

## vmovn_high_s16

`vmovn_high_s16`

int8x16_t vmovn_high_s16 (int8x8_t r, int16x8_t a)
A32: VMOVN.I16 Dd+1, Qm
A64: XTN2 Vd.16B, Vn.8H


Instruction Documentation: [vmovn_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_high_s16)

## vmovn_high_s32

`vmovn_high_s32`

int16x8_t vmovn_high_s32 (int16x4_t r, int32x4_t a)
A32: VMOVN.I32 Dd+1, Qm
A64: XTN2 Vd.8H, Vn.4S


Instruction Documentation: [vmovn_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_high_s32)

## vmovn_high_s64

`vmovn_high_s64`

int32x4_t vmovn_high_s64 (int32x2_t r, int64x2_t a)
A32: VMOVN.I64 Dd+1, Qm
A64: XTN2 Vd.4S, Vn.2D


Instruction Documentation: [vmovn_high_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_high_s64)

## vmovn_high_u16

`vmovn_high_u16`

uint8x16_t vmovn_high_u16 (uint8x8_t r, uint16x8_t a)
A32: VMOVN.I16 Dd+1, Qm
A64: XTN2 Vd.16B, Vn.8H


Instruction Documentation: [vmovn_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_high_u16)

## vmovn_high_u32

`vmovn_high_u32`

uint16x8_t vmovn_high_u32 (uint16x4_t r, uint32x4_t a)
A32: VMOVN.I32 Dd+1, Qm
A64: XTN2 Vd.8H, Vn.4S


Instruction Documentation: [vmovn_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_high_u32)

## vmovn_high_u64

`vmovn_high_u64`

uint32x4_t vmovn_high_u64 (uint32x2_t r, uint64x2_t a)
A32: VMOVN.I64 Dd+1, Qm
A64: XTN2 Vd.4S, Vn.2D


Instruction Documentation: [vmovn_high_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_high_u64)

## vmovn_s16

`vmovn_s16`

int8x8_t vmovn_s16 (int16x8_t a)
A32: VMOVN.I16 Dd, Qm
A64: XTN Vd.8B, Vn.8H


Instruction Documentation: [vmovn_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_s16)

## vmovn_s32

`vmovn_s32`

int16x4_t vmovn_s32 (int32x4_t a)
A32: VMOVN.I32 Dd, Qm
A64: XTN Vd.4H, Vn.4S


Instruction Documentation: [vmovn_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_s32)

## vmovn_s64

`vmovn_s64`

int32x2_t vmovn_s64 (int64x2_t a)
A32: VMOVN.I64 Dd, Qm
A64: XTN Vd.2S, Vn.2D


Instruction Documentation: [vmovn_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_s64)

## vmovn_u16

`vmovn_u16`

uint8x8_t vmovn_u16 (uint16x8_t a)
A32: VMOVN.I16 Dd, Qm
A64: XTN Vd.8B, Vn.8H


Instruction Documentation: [vmovn_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_u16)

## vmovn_u32

`vmovn_u32`

uint16x4_t vmovn_u32 (uint32x4_t a)
A32: VMOVN.I32 Dd, Qm
A64: XTN Vd.4H, Vn.4S


Instruction Documentation: [vmovn_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_u32)

## vmovn_u64

`vmovn_u64`

uint32x2_t vmovn_u64 (uint64x2_t a)
A32: VMOVN.I64 Dd, Qm
A64: XTN Vd.2S, Vn.2D


Instruction Documentation: [vmovn_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmovn_u64)

## vmul_f32

`vmul_f32`

float32x2_t vmul_f32 (float32x2_t a, float32x2_t b)
A32: VMUL.F32 Dd, Dn, Dm
A64: FMUL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmul_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_f32)

## vmul_f64

`vmul_f64`

float64x1_t vmul_f64 (float64x1_t a, float64x1_t b)
A32: VMUL.F64 Dd, Dn, Dm
A64: FMUL Dd, Dn, Dm


Instruction Documentation: [vmul_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_f64)

## vmul_lane_f32

`vmul_lane_f32`

float32x2_t vmul_lane_f32 (float32x2_t a, float32x2_t v, const int lane)
A32: VMUL.F32 Dd, Dn, Dm[lane]
A64: FMUL Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmul_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_lane_f32)

## vmul_lane_s16

`vmul_lane_s16`

int16x4_t vmul_lane_s16 (int16x4_t a, int16x4_t v, const int lane)
A32: VMUL.I16 Dd, Dn, Dm[lane]
A64: MUL Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmul_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_lane_s16)

## vmul_lane_s32

`vmul_lane_s32`

int32x2_t vmul_lane_s32 (int32x2_t a, int32x2_t v, const int lane)
A32: VMUL.I32 Dd, Dn, Dm[lane]
A64: MUL Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmul_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_lane_s32)

## vmul_lane_u16

`vmul_lane_u16`

uint16x4_t vmul_lane_u16 (uint16x4_t a, uint16x4_t v, const int lane)
A32: VMUL.I16 Dd, Dn, Dm[lane]
A64: MUL Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmul_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_lane_u16)

## vmul_lane_u32

`vmul_lane_u32`

uint32x2_t vmul_lane_u32 (uint32x2_t a, uint32x2_t v, const int lane)
A32: VMUL.I32 Dd, Dn, Dm[lane]
A64: MUL Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmul_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_lane_u32)

## vmul_laneq_f32

`vmul_laneq_f32`

float32x2_t vmul_laneq_f32 (float32x2_t a, float32x4_t v, const int lane)
A32: VMUL.F32 Dd, Dn, Dm[lane]
A64: FMUL Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmul_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_laneq_f32)

## vmul_laneq_s16

`vmul_laneq_s16`

int16x4_t vmul_laneq_s16 (int16x4_t a, int16x8_t v, const int lane)
A32: VMUL.I16 Dd, Dn, Dm[lane]
A64: MUL Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmul_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_laneq_s16)

## vmul_laneq_s32

`vmul_laneq_s32`

int32x2_t vmul_laneq_s32 (int32x2_t a, int32x4_t v, const int lane)
A32: VMUL.I32 Dd, Dn, Dm[lane]
A64: MUL Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmul_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_laneq_s32)

## vmul_laneq_u16

`vmul_laneq_u16`

uint16x4_t vmul_laneq_u16 (uint16x4_t a, uint16x8_t v, const int lane)
A32: VMUL.I16 Dd, Dn, Dm[lane]
A64: MUL Vd.4H, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmul_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_laneq_u16)

## vmul_laneq_u32

`vmul_laneq_u32`

uint32x2_t vmul_laneq_u32 (uint32x2_t a, uint32x4_t v, const int lane)
A32: VMUL.I32 Dd, Dn, Dm[lane]
A64: MUL Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmul_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_laneq_u32)

## vmul_n_f32

`vmul_n_f32`

float32x2_t vmul_n_f32 (float32x2_t a, float32_t b)
A32: VMUL.F32 Dd, Dn, Dm[0]
A64: FMUL Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vmul_n_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_n_f32)

## vmul_n_s16

`vmul_n_s16`

int16x4_t vmul_n_s16 (int16x4_t a, int16_t b)
A32: VMUL.I16 Dd, Dn, Dm[0]
A64: MUL Vd.4H, Vn.4H, Vm.H[0]


Instruction Documentation: [vmul_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_n_s16)

## vmul_n_s32

`vmul_n_s32`

int32x2_t vmul_n_s32 (int32x2_t a, int32_t b)
A32: VMUL.I32 Dd, Dn, Dm[0]
A64: MUL Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vmul_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_n_s32)

## vmul_n_u16

`vmul_n_u16`

uint16x4_t vmul_n_u16 (uint16x4_t a, uint16_t b)
A32: VMUL.I16 Dd, Dn, Dm[0]
A64: MUL Vd.4H, Vn.4H, Vm.H[0]


Instruction Documentation: [vmul_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_n_u16)

## vmul_n_u32

`vmul_n_u32`

uint32x2_t vmul_n_u32 (uint32x2_t a, uint32_t b)
A32: VMUL.I32 Dd, Dn, Dm[0]
A64: MUL Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vmul_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_n_u32)

## vmul_p8

`vmul_p8`

poly8x8_t vmul_p8 (poly8x8_t a, poly8x8_t b)
A32: VMUL.P8 Dd, Dn, Dm
A64: PMUL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmul_p8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_p8)

## vmul_s16

`vmul_s16`

int16x4_t vmul_s16 (int16x4_t a, int16x4_t b)
A32: VMUL.I16 Dd, Dn, Dm
A64: MUL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmul_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_s16)

## vmul_s32

`vmul_s32`

int32x2_t vmul_s32 (int32x2_t a, int32x2_t b)
A32: VMUL.I32 Dd, Dn, Dm
A64: MUL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmul_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_s32)

## vmul_s8

`vmul_s8`

int8x8_t vmul_s8 (int8x8_t a, int8x8_t b)
A32: VMUL.I8 Dd, Dn, Dm
A64: MUL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmul_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_s8)

## vmul_u16

`vmul_u16`

uint16x4_t vmul_u16 (uint16x4_t a, uint16x4_t b)
A32: VMUL.I16 Dd, Dn, Dm
A64: MUL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vmul_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_u16)

## vmul_u32

`vmul_u32`

uint32x2_t vmul_u32 (uint32x2_t a, uint32x2_t b)
A32: VMUL.I32 Dd, Dn, Dm
A64: MUL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmul_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_u32)

## vmul_u8

`vmul_u8`

uint8x8_t vmul_u8 (uint8x8_t a, uint8x8_t b)
A32: VMUL.I8 Dd, Dn, Dm
A64: MUL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vmul_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmul_u8)

## vmull_high_lane_s16

`vmull_high_lane_s16`

int32x4_t vmull_high_lane_s16 (int16x8_t a, int16x4_t v, const int lane)
A32: VMULL.S16 Qd, Dn+1, Dm[lane]
A64: SMULL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmull_high_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_lane_s16)

## vmull_high_lane_s32

`vmull_high_lane_s32`

int64x2_t vmull_high_lane_s32 (int32x4_t a, int32x2_t v, const int lane)
A32: VMULL.S32 Qd, Dn+1, Dm[lane]
A64: SMULL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmull_high_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_lane_s32)

## vmull_high_lane_u16

`vmull_high_lane_u16`

uint32x4_t vmull_high_lane_u16 (uint16x8_t a, uint16x4_t v, const int lane)
A32: VMULL.U16 Qd, Dn+1, Dm[lane]
A64: UMULL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmull_high_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_lane_u16)

## vmull_high_lane_u32

`vmull_high_lane_u32`

uint64x2_t vmull_high_lane_u32 (uint32x4_t a, uint32x2_t v, const int lane)
A32: VMULL.U32 Qd, Dn+1, Dm[lane]
A64: UMULL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmull_high_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_lane_u32)

## vmull_high_laneq_s16

`vmull_high_laneq_s16`

int32x4_t vmull_high_laneq_s16 (int16x8_t a, int16x8_t v, const int lane)
A32: VMULL.S16 Qd, Dn+1, Dm[lane]
A64: SMULL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmull_high_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_laneq_s16)

## vmull_high_laneq_s32

`vmull_high_laneq_s32`

int64x2_t vmull_high_laneq_s32 (int32x4_t a, int32x4_t v, const int lane)
A32: VMULL.S32 Qd, Dn+1, Dm[lane]
A64: SMULL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmull_high_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_laneq_s32)

## vmull_high_laneq_u16

`vmull_high_laneq_u16`

uint32x4_t vmull_high_laneq_u16 (uint16x8_t a, uint16x8_t v, const int lane)
A32: VMULL.U16 Qd, Dn+1, Dm[lane]
A64: UMULL2 Vd.4S, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmull_high_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_laneq_u16)

## vmull_high_laneq_u32

`vmull_high_laneq_u32`

uint64x2_t vmull_high_laneq_u32 (uint32x4_t a, uint32x4_t v, const int lane)
A32: VMULL.U32 Qd, Dn+1, Dm[lane]
A64: UMULL2 Vd.2D, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmull_high_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_laneq_u32)

## vmull_high_p8

`vmull_high_p8`

poly16x8_t vmull_high_p8 (poly8x16_t a, poly8x16_t b)
A32: VMULL.P8 Qd, Dn+1, Dm+1
A64: PMULL2 Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmull_high_p8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_p8)

## vmull_high_s16

`vmull_high_s16`

int32x4_t vmull_high_s16 (int16x8_t a, int16x8_t b)
A32: VMULL.S16 Qd, Dn+1, Dm+1
A64: SMULL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vmull_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_s16)

## vmull_high_s32

`vmull_high_s32`

int64x2_t vmull_high_s32 (int32x4_t a, int32x4_t b)
A32: VMULL.S32 Qd, Dn+1, Dm+1
A64: SMULL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vmull_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_s32)

## vmull_high_s8

`vmull_high_s8`

int16x8_t vmull_high_s8 (int8x16_t a, int8x16_t b)
A32: VMULL.S8 Qd, Dn+1, Dm+1
A64: SMULL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vmull_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_s8)

## vmull_high_u16

`vmull_high_u16`

uint32x4_t vmull_high_u16 (uint16x8_t a, uint16x8_t b)
A32: VMULL.U16 Qd, Dn+1, Dm+1
A64: UMULL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vmull_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_u16)

## vmull_high_u32

`vmull_high_u32`

uint64x2_t vmull_high_u32 (uint32x4_t a, uint32x4_t b)
A32: VMULL.U32 Qd, Dn+1, Dm+1
A64: UMULL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vmull_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_u32)

## vmull_high_u8

`vmull_high_u8`

uint16x8_t vmull_high_u8 (uint8x16_t a, uint8x16_t b)
A32: VMULL.U8 Qd, Dn+1, Dm+1
A64: UMULL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vmull_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_high_u8)

## vmull_lane_s16

`vmull_lane_s16`

int32x4_t vmull_lane_s16 (int16x4_t a, int16x4_t v, const int lane)
A32: VMULL.S16 Qd, Dn, Dm[lane]
A64: SMULL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmull_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_lane_s16)

## vmull_lane_s32

`vmull_lane_s32`

int64x2_t vmull_lane_s32 (int32x2_t a, int32x2_t v, const int lane)
A32: VMULL.S32 Qd, Dn, Dm[lane]
A64: SMULL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmull_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_lane_s32)

## vmull_lane_u16

`vmull_lane_u16`

uint32x4_t vmull_lane_u16 (uint16x4_t a, uint16x4_t v, const int lane)
A32: VMULL.U16 Qd, Dn, Dm[lane]
A64: UMULL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmull_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_lane_u16)

## vmull_lane_u32

`vmull_lane_u32`

uint64x2_t vmull_lane_u32 (uint32x2_t a, uint32x2_t v, const int lane)
A32: VMULL.U32 Qd, Dn, Dm[lane]
A64: UMULL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmull_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_lane_u32)

## vmull_laneq_s16

`vmull_laneq_s16`

int32x4_t vmull_laneq_s16 (int16x4_t a, int16x8_t v, const int lane)
A32: VMULL.S16 Qd, Dn, Dm[lane]
A64: SMULL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmull_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_laneq_s16)

## vmull_laneq_s32

`vmull_laneq_s32`

int64x2_t vmull_laneq_s32 (int32x2_t a, int32x4_t v, const int lane)
A32: VMULL.S32 Qd, Dn, Dm[lane]
A64: SMULL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmull_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_laneq_s32)

## vmull_laneq_u16

`vmull_laneq_u16`

uint32x4_t vmull_laneq_u16 (uint16x4_t a, uint16x8_t v, const int lane)
A32: VMULL.U16 Qd, Dn, Dm[lane]
A64: UMULL Vd.4S, Vn.4H, Vm.H[lane]


Instruction Documentation: [vmull_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_laneq_u16)

## vmull_laneq_u32

`vmull_laneq_u32`

uint64x2_t vmull_laneq_u32 (uint32x2_t a, uint32x4_t v, const int lane)
A32: VMULL.U32 Qd, Dn, Dm[lane]
A64: UMULL Vd.2D, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmull_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_laneq_u32)

## vmull_p8

`vmull_p8`

poly16x8_t vmull_p8 (poly8x8_t a, poly8x8_t b)
A32: VMULL.P8 Qd, Dn, Dm
A64: PMULL Vd.16B, Vn.8B, Vm.8B


Instruction Documentation: [vmull_p8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_p8)

## vmull_s16

`vmull_s16`

int32x4_t vmull_s16 (int16x4_t a, int16x4_t b)
A32: VMULL.S16 Qd, Dn, Dm
A64: SMULL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vmull_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_s16)

## vmull_s32

`vmull_s32`

int64x2_t vmull_s32 (int32x2_t a, int32x2_t b)
A32: VMULL.S32 Qd, Dn, Dm
A64: SMULL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vmull_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_s32)

## vmull_s8

`vmull_s8`

int16x8_t vmull_s8 (int8x8_t a, int8x8_t b)
A32: VMULL.S8 Qd, Dn, Dm
A64: SMULL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vmull_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_s8)

## vmull_u16

`vmull_u16`

uint32x4_t vmull_u16 (uint16x4_t a, uint16x4_t b)
A32: VMULL.U16 Qd, Dn, Dm
A64: UMULL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vmull_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_u16)

## vmull_u32

`vmull_u32`

uint64x2_t vmull_u32 (uint32x2_t a, uint32x2_t b)
A32: VMULL.U32 Qd, Dn, Dm
A64: UMULL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vmull_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_u32)

## vmull_u8

`vmull_u8`

uint16x8_t vmull_u8 (uint8x8_t a, uint8x8_t b)
A32: VMULL.U8 Qd, Dn, Dm
A64: UMULL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vmull_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmull_u8)

## vmulq_f32

`vmulq_f32`

float32x4_t vmulq_f32 (float32x4_t a, float32x4_t b)
A32: VMUL.F32 Qd, Qn, Qm
A64: FMUL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmulq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_f32)

## vmulq_lane_f32

`vmulq_lane_f32`

float32x4_t vmulq_lane_f32 (float32x4_t a, float32x2_t v, const int lane)
A32: VMUL.F32 Qd, Qn, Dm[lane]
A64: FMUL Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmulq_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_lane_f32)

## vmulq_lane_s16

`vmulq_lane_s16`

int16x8_t vmulq_lane_s16 (int16x8_t a, int16x4_t v, const int lane)
A32: VMUL.I16 Qd, Qn, Dm[lane]
A64: MUL Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmulq_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_lane_s16)

## vmulq_lane_s32

`vmulq_lane_s32`

int32x4_t vmulq_lane_s32 (int32x4_t a, int32x2_t v, const int lane)
A32: VMUL.I32 Qd, Qn, Dm[lane]
A64: MUL Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmulq_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_lane_s32)

## vmulq_lane_u16

`vmulq_lane_u16`

uint16x8_t vmulq_lane_u16 (uint16x8_t a, uint16x4_t v, const int lane)
A32: VMUL.I16 Qd, Qn, Dm[lane]
A64: MUL Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmulq_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_lane_u16)

## vmulq_lane_u32

`vmulq_lane_u32`

uint32x4_t vmulq_lane_u32 (uint32x4_t a, uint32x2_t v, const int lane)
A32: VMUL.I32 Qd, Qn, Dm[lane]
A64: MUL Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmulq_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_lane_u32)

## vmulq_laneq_f32

`vmulq_laneq_f32`

float32x4_t vmulq_laneq_f32 (float32x4_t a, float32x4_t v, const int lane)
A32: VMUL.F32 Qd, Qn, Dm[lane]
A64: FMUL Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmulq_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_laneq_f32)

## vmulq_laneq_s16

`vmulq_laneq_s16`

int16x8_t vmulq_laneq_s16 (int16x8_t a, int16x8_t v, const int lane)
A32: VMUL.I16 Qd, Qn, Dm[lane]
A64: MUL Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmulq_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_laneq_s16)

## vmulq_laneq_s32

`vmulq_laneq_s32`

int32x4_t vmulq_laneq_s32 (int32x4_t a, int32x4_t v, const int lane)
A32: VMUL.I32 Qd, Qn, Dm[lane]
A64: MUL Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmulq_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_laneq_s32)

## vmulq_laneq_u16

`vmulq_laneq_u16`

uint16x8_t vmulq_laneq_u16 (uint16x8_t a, uint16x8_t v, const int lane)
A32: VMUL.I16 Qd, Qn, Dm[lane]
A64: MUL Vd.8H, Vn.8H, Vm.H[lane]


Instruction Documentation: [vmulq_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_laneq_u16)

## vmulq_laneq_u32

`vmulq_laneq_u32`

uint32x4_t vmulq_laneq_u32 (uint32x4_t a, uint32x4_t v, const int lane)
A32: VMUL.I32 Qd, Qn, Dm[lane]
A64: MUL Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmulq_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_laneq_u32)

## vmulq_n_f32

`vmulq_n_f32`

float32x4_t vmulq_n_f32 (float32x4_t a, float32_t b)
A32: VMUL.F32 Qd, Qn, Dm[0]
A64: FMUL Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vmulq_n_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_n_f32)

## vmulq_n_s16

`vmulq_n_s16`

int16x8_t vmulq_n_s16 (int16x8_t a, int16_t b)
A32: VMUL.I16 Qd, Qn, Dm[0]
A64: MUL Vd.8H, Vn.8H, Vm.H[0]


Instruction Documentation: [vmulq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_n_s16)

## vmulq_n_s32

`vmulq_n_s32`

int32x4_t vmulq_n_s32 (int32x4_t a, int32_t b)
A32: VMUL.I32 Qd, Qn, Dm[0]
A64: MUL Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vmulq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_n_s32)

## vmulq_n_u16

`vmulq_n_u16`

uint16x8_t vmulq_n_u16 (uint16x8_t a, uint16_t b)
A32: VMUL.I16 Qd, Qn, Dm[0]
A64: MUL Vd.8H, Vn.8H, Vm.H[0]


Instruction Documentation: [vmulq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_n_u16)

## vmulq_n_u32

`vmulq_n_u32`

uint32x4_t vmulq_n_u32 (uint32x4_t a, uint32_t b)
A32: VMUL.I32 Qd, Qn, Dm[0]
A64: MUL Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vmulq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_n_u32)

## vmulq_p8

`vmulq_p8`

poly8x16_t vmulq_p8 (poly8x16_t a, poly8x16_t b)
A32: VMUL.P8 Qd, Qn, Qm
A64: PMUL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmulq_p8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_p8)

## vmulq_s16

`vmulq_s16`

int16x8_t vmulq_s16 (int16x8_t a, int16x8_t b)
A32: VMUL.I16 Qd, Qn, Qm
A64: MUL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vmulq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_s16)

## vmulq_s32

`vmulq_s32`

int32x4_t vmulq_s32 (int32x4_t a, int32x4_t b)
A32: VMUL.I32 Qd, Qn, Qm
A64: MUL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmulq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_s32)

## vmulq_s8

`vmulq_s8`

int8x16_t vmulq_s8 (int8x16_t a, int8x16_t b)
A32: VMUL.I8 Qd, Qn, Qm
A64: MUL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmulq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_s8)

## vmulq_u16

`vmulq_u16`

uint16x8_t vmulq_u16 (uint16x8_t a, uint16x8_t b)
A32: VMUL.I16 Qd, Qn, Qm
A64: MUL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vmulq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_u16)

## vmulq_u32

`vmulq_u32`

uint32x4_t vmulq_u32 (uint32x4_t a, uint32x4_t b)
A32: VMUL.I32 Qd, Qn, Qm
A64: MUL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmulq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_u32)

## vmulq_u8

`vmulq_u8`

uint8x16_t vmulq_u8 (uint8x16_t a, uint8x16_t b)
A32: VMUL.I8 Qd, Qn, Qm
A64: MUL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vmulq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_u8)

## vmuls_f32

`vmuls_f32`

float32_t vmuls_f32 (float32_t a, float32_t b)
A32: VMUL.F32 Sd, Sn, Sm
A64: FMUL Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vmuls_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmuls_f32)

## vmuls_lane_f32

`vmuls_lane_f32`

float32_t vmuls_lane_f32 (float32_t a, float32x2_t v, const int lane)
A32: VMUL.F32 Sd, Sn, Dm[lane]
A64: FMUL Sd, Sn, Vm.S[lane]


Instruction Documentation: [vmuls_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmuls_lane_f32)

## vmuls_laneq_f32

`vmuls_laneq_f32`

float32_t vmuls_laneq_f32 (float32_t a, float32x4_t v, const int lane)
A32: VMUL.F32 Sd, Sn, Dm[lane]
A64: FMUL Sd, Sn, Vm.S[lane]


Instruction Documentation: [vmuls_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmuls_laneq_f32)

## vmvn_f32

`vmvn_f32`

float32x2_t vmvn_f32 (float32x2_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vmvn_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_f32)

## vmvn_f64

`vmvn_f64`

float64x1_t vmvn_f64 (float64x1_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vmvn_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_f64)

## vmvn_s16

`vmvn_s16`

int16x4_t vmvn_s16 (int16x4_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B


Instruction Documentation: [vmvn_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_s16)

## vmvn_s32

`vmvn_s32`

int32x2_t vmvn_s32 (int32x2_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B


Instruction Documentation: [vmvn_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_s32)

## vmvn_s64

`vmvn_s64`

int64x1_t vmvn_s64 (int64x1_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B


Instruction Documentation: [vmvn_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_s64)

## vmvn_s8

`vmvn_s8`

int8x8_t vmvn_s8 (int8x8_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B


Instruction Documentation: [vmvn_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_s8)

## vmvn_u16

`vmvn_u16`

uint16x4_t vmvn_u16 (uint16x4_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B


Instruction Documentation: [vmvn_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_u16)

## vmvn_u32

`vmvn_u32`

uint32x2_t vmvn_u32 (uint32x2_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B


Instruction Documentation: [vmvn_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_u32)

## vmvn_u64

`vmvn_u64`

uint64x1_t vmvn_u64 (uint64x1_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B


Instruction Documentation: [vmvn_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_u64)

## vmvn_u8

`vmvn_u8`

uint8x8_t vmvn_u8 (uint8x8_t a)
A32: VMVN Dd, Dm
A64: MVN Vd.8B, Vn.8B


Instruction Documentation: [vmvn_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvn_u8)

## vmvnq_f32

`vmvnq_f32`

float32x4_t vmvnq_f32 (float32x4_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vmvnq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_f32)

## vmvnq_f64

`vmvnq_f64`

float64x2_t vmvnq_f64 (float64x2_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vmvnq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_f64)

## vmvnq_s16

`vmvnq_s16`

int16x8_t vmvnq_s16 (int16x8_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B


Instruction Documentation: [vmvnq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_s16)

## vmvnq_s32

`vmvnq_s32`

int32x4_t vmvnq_s32 (int32x4_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B


Instruction Documentation: [vmvnq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_s32)

## vmvnq_s64

`vmvnq_s64`

int64x2_t vmvnq_s64 (int64x2_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B


Instruction Documentation: [vmvnq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_s64)

## vmvnq_s8

`vmvnq_s8`

int8x16_t vmvnq_s8 (int8x16_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B


Instruction Documentation: [vmvnq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_s8)

## vmvnq_u16

`vmvnq_u16`

uint16x8_t vmvnq_u16 (uint16x8_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B


Instruction Documentation: [vmvnq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_u16)

## vmvnq_u32

`vmvnq_u32`

uint32x4_t vmvnq_u32 (uint32x4_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B


Instruction Documentation: [vmvnq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_u32)

## vmvnq_u64

`vmvnq_u64`

uint64x2_t vmvnq_u64 (uint64x2_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B


Instruction Documentation: [vmvnq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_u64)

## vmvnq_u8

`vmvnq_u8`

uint8x16_t vmvnq_u8 (uint8x16_t a)
A32: VMVN Qd, Qm
A64: MVN Vd.16B, Vn.16B


Instruction Documentation: [vmvnq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmvnq_u8)

## vneg_f32

`vneg_f32`

float32x2_t vneg_f32 (float32x2_t a)
A32: VNEG.F32 Dd, Dm
A64: FNEG Vd.2S, Vn.2S


Instruction Documentation: [vneg_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vneg_f32)

## vneg_f64

`vneg_f64`

float64x1_t vneg_f64 (float64x1_t a)
A32: VNEG.F64 Dd, Dm
A64: FNEG Dd, Dn


Instruction Documentation: [vneg_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vneg_f64)

## vneg_s16

`vneg_s16`

int16x4_t vneg_s16 (int16x4_t a)
A32: VNEG.S16 Dd, Dm
A64: NEG Vd.4H, Vn.4H


Instruction Documentation: [vneg_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vneg_s16)

## vneg_s32

`vneg_s32`

int32x2_t vneg_s32 (int32x2_t a)
A32: VNEG.S32 Dd, Dm
A64: NEG Vd.2S, Vn.2S


Instruction Documentation: [vneg_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vneg_s32)

## vneg_s8

`vneg_s8`

int8x8_t vneg_s8 (int8x8_t a)
A32: VNEG.S8 Dd, Dm
A64: NEG Vd.8B, Vn.8B


Instruction Documentation: [vneg_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vneg_s8)

## vnegq_f32

`vnegq_f32`

float32x4_t vnegq_f32 (float32x4_t a)
A32: VNEG.F32 Qd, Qm
A64: FNEG Vd.4S, Vn.4S


Instruction Documentation: [vnegq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vnegq_f32)

## vnegq_s16

`vnegq_s16`

int16x8_t vnegq_s16 (int16x8_t a)
A32: VNEG.S16 Qd, Qm
A64: NEG Vd.8H, Vn.8H


Instruction Documentation: [vnegq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vnegq_s16)

## vnegq_s32

`vnegq_s32`

int32x4_t vnegq_s32 (int32x4_t a)
A32: VNEG.S32 Qd, Qm
A64: NEG Vd.4S, Vn.4S


Instruction Documentation: [vnegq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vnegq_s32)

## vnegq_s8

`vnegq_s8`

int8x16_t vnegq_s8 (int8x16_t a)
A32: VNEG.S8 Qd, Qm
A64: NEG Vd.16B, Vn.16B


Instruction Documentation: [vnegq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vnegq_s8)

## vnegs_f32

`vnegs_f32`

float32_t vnegs_f32 (float32_t a)
A32: VNEG.F32 Sd, Sm
A64: FNEG Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vnegs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vnegs_f32)

## vorn_f32

`vorn_f32`

float32x2_t vorn_f32 (float32x2_t a, float32x2_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vorn_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_f32)

## vorn_f64

`vorn_f64`

float64x1_t vorn_f64 (float64x1_t a, float64x1_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vorn_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_f64)

## vorn_s16

`vorn_s16`

int16x4_t vorn_s16 (int16x4_t a, int16x4_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorn_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_s16)

## vorn_s32

`vorn_s32`

int32x2_t vorn_s32 (int32x2_t a, int32x2_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorn_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_s32)

## vorn_s64

`vorn_s64`

int64x1_t vorn_s64 (int64x1_t a, int64x1_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorn_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_s64)

## vorn_s8

`vorn_s8`

int8x8_t vorn_s8 (int8x8_t a, int8x8_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorn_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_s8)

## vorn_u16

`vorn_u16`

uint16x4_t vorn_u16 (uint16x4_t a, uint16x4_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorn_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_u16)

## vorn_u32

`vorn_u32`

uint32x2_t vorn_u32 (uint32x2_t a, uint32x2_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorn_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_u32)

## vorn_u64

`vorn_u64`

uint64x1_t vorn_u64 (uint64x1_t a, uint64x1_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorn_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_u64)

## vorn_u8

`vorn_u8`

uint8x8_t vorn_u8 (uint8x8_t a, uint8x8_t b)
A32: VORN Dd, Dn, Dm
A64: ORN Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorn_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorn_u8)

## vornq_f32

`vornq_f32`

float32x4_t vornq_f32 (float32x4_t a, float32x4_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vornq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_f32)

## vornq_f64

`vornq_f64`

float64x2_t vornq_f64 (float64x2_t a, float64x2_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vornq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_f64)

## vornq_s16

`vornq_s16`

int16x8_t vornq_s16 (int16x8_t a, int16x8_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vornq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_s16)

## vornq_s32

`vornq_s32`

int32x4_t vornq_s32 (int32x4_t a, int32x4_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vornq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_s32)

## vornq_s64

`vornq_s64`

int64x2_t vornq_s64 (int64x2_t a, int64x2_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vornq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_s64)

## vornq_s8

`vornq_s8`

int8x16_t vornq_s8 (int8x16_t a, int8x16_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vornq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_s8)

## vornq_u16

`vornq_u16`

uint16x8_t vornq_u16 (uint16x8_t a, uint16x8_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vornq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_u16)

## vornq_u32

`vornq_u32`

uint32x4_t vornq_u32 (uint32x4_t a, uint32x4_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vornq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_u32)

## vornq_u64

`vornq_u64`

uint64x2_t vornq_u64 (uint64x2_t a, uint64x2_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vornq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_u64)

## vornq_u8

`vornq_u8`

uint8x16_t vornq_u8 (uint8x16_t a, uint8x16_t b)
A32: VORN Qd, Qn, Qm
A64: ORN Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vornq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vornq_u8)

## vorr_f32

`vorr_f32`

float32x2_t vorr_f32 (float32x2_t a, float32x2_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vorr_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_f32)

## vorr_f64

`vorr_f64`

float64x1_t vorr_f64 (float64x1_t a, float64x1_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vorr_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_f64)

## vorr_s16

`vorr_s16`

int16x4_t vorr_s16 (int16x4_t a, int16x4_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorr_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_s16)

## vorr_s32

`vorr_s32`

int32x2_t vorr_s32 (int32x2_t a, int32x2_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorr_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_s32)

## vorr_s64

`vorr_s64`

int64x1_t vorr_s64 (int64x1_t a, int64x1_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorr_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_s64)

## vorr_s8

`vorr_s8`

int8x8_t vorr_s8 (int8x8_t a, int8x8_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorr_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_s8)

## vorr_u16

`vorr_u16`

uint16x4_t vorr_u16 (uint16x4_t a, uint16x4_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorr_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_u16)

## vorr_u32

`vorr_u32`

uint32x2_t vorr_u32 (uint32x2_t a, uint32x2_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorr_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_u32)

## vorr_u64

`vorr_u64`

uint64x1_t vorr_u64 (uint64x1_t a, uint64x1_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorr_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_u64)

## vorr_u8

`vorr_u8`

uint8x8_t vorr_u8 (uint8x8_t a, uint8x8_t b)
A32: VORR Dd, Dn, Dm
A64: ORR Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vorr_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorr_u8)

## vorrq_f32

`vorrq_f32`

float32x4_t vorrq_f32 (float32x4_t a, float32x4_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vorrq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_f32)

## vorrq_f64

`vorrq_f64`

float64x2_t vorrq_f64 (float64x2_t a, float64x2_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vorrq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_f64)

## vorrq_s16

`vorrq_s16`

int16x8_t vorrq_s16 (int16x8_t a, int16x8_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vorrq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_s16)

## vorrq_s32

`vorrq_s32`

int32x4_t vorrq_s32 (int32x4_t a, int32x4_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vorrq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_s32)

## vorrq_s64

`vorrq_s64`

int64x2_t vorrq_s64 (int64x2_t a, int64x2_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vorrq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_s64)

## vorrq_s8

`vorrq_s8`

int8x16_t vorrq_s8 (int8x16_t a, int8x16_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vorrq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_s8)

## vorrq_u16

`vorrq_u16`

uint16x8_t vorrq_u16 (uint16x8_t a, uint16x8_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vorrq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_u16)

## vorrq_u32

`vorrq_u32`

uint32x4_t vorrq_u32 (uint32x4_t a, uint32x4_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vorrq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_u32)

## vorrq_u64

`vorrq_u64`

uint64x2_t vorrq_u64 (uint64x2_t a, uint64x2_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vorrq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_u64)

## vorrq_u8

`vorrq_u8`

uint8x16_t vorrq_u8 (uint8x16_t a, uint8x16_t b)
A32: VORR Qd, Qn, Qm
A64: ORR Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vorrq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vorrq_u8)

## vpadal_s16

`vpadal_s16`

int32x2_t vpadal_s16 (int32x2_t a, int16x4_t b)
A32: VPADAL.S16 Dd, Dm
A64: SADALP Vd.2S, Vn.4H


Instruction Documentation: [vpadal_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadal_s16)

## vpadal_s32

`vpadal_s32`

int64x1_t vpadal_s32 (int64x1_t a, int32x2_t b)
A32: VPADAL.S32 Dd, Dm
A64: SADALP Vd.1D, Vn.2S


Instruction Documentation: [vpadal_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadal_s32)

## vpadal_s8

`vpadal_s8`

int16x4_t vpadal_s8 (int16x4_t a, int8x8_t b)
A32: VPADAL.S8 Dd, Dm
A64: SADALP Vd.4H, Vn.8B


Instruction Documentation: [vpadal_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadal_s8)

## vpadal_u16

`vpadal_u16`

uint32x2_t vpadal_u16 (uint32x2_t a, uint16x4_t b)
A32: VPADAL.U16 Dd, Dm
A64: UADALP Vd.2S, Vn.4H


Instruction Documentation: [vpadal_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadal_u16)

## vpadal_u32

`vpadal_u32`

uint64x1_t vpadal_u32 (uint64x1_t a, uint32x2_t b)
A32: VPADAL.U32 Dd, Dm
A64: UADALP Vd.1D, Vn.2S


Instruction Documentation: [vpadal_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadal_u32)

## vpadal_u8

`vpadal_u8`

uint16x4_t vpadal_u8 (uint16x4_t a, uint8x8_t b)
A32: VPADAL.U8 Dd, Dm
A64: UADALP Vd.4H, Vn.8B


Instruction Documentation: [vpadal_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadal_u8)

## vpadalq_s16

`vpadalq_s16`

int32x4_t vpadalq_s16 (int32x4_t a, int16x8_t b)
A32: VPADAL.S16 Qd, Qm
A64: SADALP Vd.4S, Vn.8H


Instruction Documentation: [vpadalq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadalq_s16)

## vpadalq_s32

`vpadalq_s32`

int64x2_t vpadalq_s32 (int64x2_t a, int32x4_t b)
A32: VPADAL.S32 Qd, Qm
A64: SADALP Vd.2D, Vn.4S


Instruction Documentation: [vpadalq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadalq_s32)

## vpadalq_s8

`vpadalq_s8`

int16x8_t vpadalq_s8 (int16x8_t a, int8x16_t b)
A32: VPADAL.S8 Qd, Qm
A64: SADALP Vd.8H, Vn.16B


Instruction Documentation: [vpadalq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadalq_s8)

## vpadalq_u16

`vpadalq_u16`

uint32x4_t vpadalq_u16 (uint32x4_t a, uint16x8_t b)
A32: VPADAL.U16 Qd, Qm
A64: UADALP Vd.4S, Vn.8H


Instruction Documentation: [vpadalq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadalq_u16)

## vpadalq_u32

`vpadalq_u32`

uint64x2_t vpadalq_u32 (uint64x2_t a, uint32x4_t b)
A32: VPADAL.U32 Qd, Qm
A64: UADALP Vd.2D, Vn.4S


Instruction Documentation: [vpadalq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadalq_u32)

## vpadalq_u8

`vpadalq_u8`

uint16x8_t vpadalq_u8 (uint16x8_t a, uint8x16_t b)
A32: VPADAL.U8 Qd, Qm
A64: UADALP Vd.8H, Vn.16B


Instruction Documentation: [vpadalq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadalq_u8)

## vpadd_f32

`vpadd_f32`

float32x2_t vpadd_f32 (float32x2_t a, float32x2_t b)
A32: VPADD.F32 Dd, Dn, Dm
A64: FADDP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpadd_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadd_f32)

## vpadd_s16

`vpadd_s16`

int16x4_t vpadd_s16 (int16x4_t a, int16x4_t b)
A32: VPADD.I16 Dd, Dn, Dm
A64: ADDP Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vpadd_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadd_s16)

## vpadd_s32

`vpadd_s32`

int32x2_t vpadd_s32 (int32x2_t a, int32x2_t b)
A32: VPADD.I32 Dd, Dn, Dm
A64: ADDP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpadd_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadd_s32)

## vpadd_s8

`vpadd_s8`

int8x8_t vpadd_s8 (int8x8_t a, int8x8_t b)
A32: VPADD.I8 Dd, Dn, Dm
A64: ADDP Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vpadd_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadd_s8)

## vpadd_u16

`vpadd_u16`

uint16x4_t vpadd_u16 (uint16x4_t a, uint16x4_t b)
A32: VPADD.I16 Dd, Dn, Dm
A64: ADDP Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vpadd_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadd_u16)

## vpadd_u32

`vpadd_u32`

uint32x2_t vpadd_u32 (uint32x2_t a, uint32x2_t b)
A32: VPADD.I32 Dd, Dn, Dm
A64: ADDP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpadd_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadd_u32)

## vpadd_u8

`vpadd_u8`

uint8x8_t vpadd_u8 (uint8x8_t a, uint8x8_t b)
A32: VPADD.I8 Dd, Dn, Dm
A64: ADDP Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vpadd_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadd_u8)

## vpaddl_s16

`vpaddl_s16`

int32x2_t vpaddl_s16 (int16x4_t a)
A32: VPADDL.S16 Dd, Dm
A64: SADDLP Vd.2S, Vn.4H


Instruction Documentation: [vpaddl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddl_s16)

## vpaddl_s32

`vpaddl_s32`

int64x1_t vpaddl_s32 (int32x2_t a)
A32: VPADDL.S32 Dd, Dm
A64: SADDLP Dd, Vn.2S


Instruction Documentation: [vpaddl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddl_s32)

## vpaddl_s8

`vpaddl_s8`

int16x4_t vpaddl_s8 (int8x8_t a)
A32: VPADDL.S8 Dd, Dm
A64: SADDLP Vd.4H, Vn.8B


Instruction Documentation: [vpaddl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddl_s8)

## vpaddl_u16

`vpaddl_u16`

uint32x2_t vpaddl_u16 (uint16x4_t a)
A32: VPADDL.U16 Dd, Dm
A64: UADDLP Vd.2S, Vn.4H


Instruction Documentation: [vpaddl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddl_u16)

## vpaddl_u32

`vpaddl_u32`

uint64x1_t vpaddl_u32 (uint32x2_t a)
A32: VPADDL.U32 Dd, Dm
A64: UADDLP Dd, Vn.2S


Instruction Documentation: [vpaddl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddl_u32)

## vpaddl_u8

`vpaddl_u8`

uint16x4_t vpaddl_u8 (uint8x8_t a)
A32: VPADDL.U8 Dd, Dm
A64: UADDLP Vd.4H, Vn.8B


Instruction Documentation: [vpaddl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddl_u8)

## vpaddlq_s16

`vpaddlq_s16`

int32x4_t vpaddlq_s16 (int16x8_t a)
A32: VPADDL.S16 Qd, Qm
A64: SADDLP Vd.4S, Vn.8H


Instruction Documentation: [vpaddlq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddlq_s16)

## vpaddlq_s32

`vpaddlq_s32`

int64x2_t vpaddlq_s32 (int32x4_t a)
A32: VPADDL.S32 Qd, Qm
A64: SADDLP Vd.2D, Vn.4S


Instruction Documentation: [vpaddlq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddlq_s32)

## vpaddlq_s8

`vpaddlq_s8`

int16x8_t vpaddlq_s8 (int8x16_t a)
A32: VPADDL.S8 Qd, Qm
A64: SADDLP Vd.8H, Vn.16B


Instruction Documentation: [vpaddlq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddlq_s8)

## vpaddlq_u16

`vpaddlq_u16`

uint32x4_t vpaddlq_u16 (uint16x8_t a)
A32: VPADDL.U16 Qd, Qm
A64: UADDLP Vd.4S, Vn.8H


Instruction Documentation: [vpaddlq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddlq_u16)

## vpaddlq_u32

`vpaddlq_u32`

uint64x2_t vpaddlq_u32 (uint32x4_t a)
A32: VPADDL.U32 Qd, Qm
A64: UADDLP Vd.2D, Vn.4S


Instruction Documentation: [vpaddlq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddlq_u32)

## vpaddlq_u8

`vpaddlq_u8`

uint16x8_t vpaddlq_u8 (uint8x16_t a)
A32: VPADDL.U8 Qd, Qm
A64: UADDLP Vd.8H, Vn.16B


Instruction Documentation: [vpaddlq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddlq_u8)

## vpmax_f32

`vpmax_f32`

float32x2_t vpmax_f32 (float32x2_t a, float32x2_t b)
A32: VPMAX.F32 Dd, Dn, Dm
A64: FMAXP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpmax_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmax_f32)

## vpmax_s16

`vpmax_s16`

int16x4_t vpmax_s16 (int16x4_t a, int16x4_t b)
A32: VPMAX.S16 Dd, Dn, Dm
A64: SMAXP Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vpmax_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmax_s16)

## vpmax_s32

`vpmax_s32`

int32x2_t vpmax_s32 (int32x2_t a, int32x2_t b)
A32: VPMAX.S32 Dd, Dn, Dm
A64: SMAXP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpmax_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmax_s32)

## vpmax_s8

`vpmax_s8`

int8x8_t vpmax_s8 (int8x8_t a, int8x8_t b)
A32: VPMAX.S8 Dd, Dn, Dm
A64: SMAXP Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vpmax_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmax_s8)

## vpmax_u16

`vpmax_u16`

uint16x4_t vpmax_u16 (uint16x4_t a, uint16x4_t b)
A32: VPMAX.U16 Dd, Dn, Dm
A64: UMAXP Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vpmax_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmax_u16)

## vpmax_u32

`vpmax_u32`

uint32x2_t vpmax_u32 (uint32x2_t a, uint32x2_t b)
A32: VPMAX.U32 Dd, Dn, Dm
A64: UMAXP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpmax_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmax_u32)

## vpmax_u8

`vpmax_u8`

uint8x8_t vpmax_u8 (uint8x8_t a, uint8x8_t b)
A32: VPMAX.U8 Dd, Dn, Dm
A64: UMAXP Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vpmax_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmax_u8)

## vpmin_f32

`vpmin_f32`

float32x2_t vpmin_f32 (float32x2_t a, float32x2_t b)
A32: VPMIN.F32 Dd, Dn, Dm
A64: FMINP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpmin_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmin_f32)

## vpmin_s16

`vpmin_s16`

int16x4_t vpmin_s16 (int16x4_t a, int16x4_t b)
A32: VPMIN.S16 Dd, Dn, Dm
A64: SMINP Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vpmin_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmin_s16)

## vpmin_s32

`vpmin_s32`

int32x2_t vpmin_s32 (int32x2_t a, int32x2_t b)
A32: VPMIN.S32 Dd, Dn, Dm
A64: SMINP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpmin_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmin_s32)

## vpmin_s8

`vpmin_s8`

int8x8_t vpmin_s8 (int8x8_t a, int8x8_t b)
A32: VPMIN.S8 Dd, Dn, Dm
A64: SMINP Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vpmin_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmin_s8)

## vpmin_u16

`vpmin_u16`

uint16x4_t vpmin_u16 (uint16x4_t a, uint16x4_t b)
A32: VPMIN.U16 Dd, Dn, Dm
A64: UMINP Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vpmin_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmin_u16)

## vpmin_u32

`vpmin_u32`

uint32x2_t vpmin_u32 (uint32x2_t a, uint32x2_t b)
A32: VPMIN.U32 Dd, Dn, Dm
A64: UMINP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpmin_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmin_u32)

## vpmin_u8

`vpmin_u8`

uint8x8_t vpmin_u8 (uint8x8_t a, uint8x8_t b)
A32: VPMIN.U8 Dd, Dn, Dm
A64: UMINP Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vpmin_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmin_u8)

## vqabs_s16

`vqabs_s16`

int16x4_t vqabs_s16 (int16x4_t a)
A32: VQABS.S16 Dd, Dm
A64: SQABS Vd.4H, Vn.4H


Instruction Documentation: [vqabs_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabs_s16)

## vqabs_s32

`vqabs_s32`

int32x2_t vqabs_s32 (int32x2_t a)
A32: VQABS.S32 Dd, Dm
A64: SQABS Vd.2S, Vn.2S


Instruction Documentation: [vqabs_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabs_s32)

## vqabs_s8

`vqabs_s8`

int8x8_t vqabs_s8 (int8x8_t a)
A32: VQABS.S8 Dd, Dm
A64: SQABS Vd.8B, Vn.8B


Instruction Documentation: [vqabs_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabs_s8)

## vqabsq_s16

`vqabsq_s16`

int16x8_t vqabsq_s16 (int16x8_t a)
A32: VQABS.S16 Qd, Qm
A64: SQABS Vd.8H, Vn.8H


Instruction Documentation: [vqabsq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabsq_s16)

## vqabsq_s32

`vqabsq_s32`

int32x4_t vqabsq_s32 (int32x4_t a)
A32: VQABS.S32 Qd, Qm
A64: SQABS Vd.4S, Vn.4S


Instruction Documentation: [vqabsq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabsq_s32)

## vqabsq_s8

`vqabsq_s8`

int8x16_t vqabsq_s8 (int8x16_t a)
A32: VQABS.S8 Qd, Qm
A64: SQABS Vd.16B, Vn.16B


Instruction Documentation: [vqabsq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabsq_s8)

## vqadd_s16

`vqadd_s16`

int16x4_t vqadd_s16 (int16x4_t a, int16x4_t b)
A32: VQADD.S16 Dd, Dn, Dm
A64: SQADD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vqadd_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadd_s16)

## vqadd_s32

`vqadd_s32`

int32x2_t vqadd_s32 (int32x2_t a, int32x2_t b)
A32: VQADD.S32 Dd, Dn, Dm
A64: SQADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vqadd_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadd_s32)

## vqadd_s64

`vqadd_s64`

int64x1_t vqadd_s64 (int64x1_t a, int64x1_t b)
A32: VQADD.S64 Dd, Dn, Dm
A64: SQADD Dd, Dn, Dm


Instruction Documentation: [vqadd_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadd_s64)

## vqadd_s8

`vqadd_s8`

int8x8_t vqadd_s8 (int8x8_t a, int8x8_t b)
A32: VQADD.S8 Dd, Dn, Dm
A64: SQADD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vqadd_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadd_s8)

## vqadd_u16

`vqadd_u16`

uint16x4_t vqadd_u16 (uint16x4_t a, uint16x4_t b)
A32: VQADD.U16 Dd, Dn, Dm
A64: UQADD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vqadd_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadd_u16)

## vqadd_u32

`vqadd_u32`

uint32x2_t vqadd_u32 (uint32x2_t a, uint32x2_t b)
A32: VQADD.U32 Dd, Dn, Dm
A64: UQADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vqadd_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadd_u32)

## vqadd_u64

`vqadd_u64`

uint64x1_t vqadd_u64 (uint64x1_t a, uint64x1_t b)
A32: VQADD.U64 Dd, Dn, Dm
A64: UQADD Dd, Dn, Dm


Instruction Documentation: [vqadd_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadd_u64)

## vqadd_u8

`vqadd_u8`

uint8x8_t vqadd_u8 (uint8x8_t a, uint8x8_t b)
A32: VQADD.U8 Dd, Dn, Dm
A64: UQADD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vqadd_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadd_u8)

## vqaddq_s16

`vqaddq_s16`

int16x8_t vqaddq_s16 (int16x8_t a, int16x8_t b)
A32: VQADD.S16 Qd, Qn, Qm
A64: SQADD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vqaddq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddq_s16)

## vqaddq_s32

`vqaddq_s32`

int32x4_t vqaddq_s32 (int32x4_t a, int32x4_t b)
A32: VQADD.S32 Qd, Qn, Qm
A64: SQADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vqaddq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddq_s32)

## vqaddq_s64

`vqaddq_s64`

int64x2_t vqaddq_s64 (int64x2_t a, int64x2_t b)
A32: VQADD.S64 Qd, Qn, Qm
A64: SQADD Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vqaddq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddq_s64)

## vqaddq_s8

`vqaddq_s8`

int8x16_t vqaddq_s8 (int8x16_t a, int8x16_t b)
A32: VQADD.S8 Qd, Qn, Qm
A64: SQADD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vqaddq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddq_s8)

## vqaddq_u16

`vqaddq_u16`

uint16x8_t vqaddq_u16 (uint16x8_t a, uint16x8_t b)
A32: VQADD.U16 Qd, Qn, Qm
A64: UQADD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vqaddq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddq_u16)

## vqaddq_u32

`vqaddq_u32`

uint32x4_t vqaddq_u32 (uint32x4_t a, uint32x4_t b)
A32: VQADD.U32 Qd, Qn, Qm
A64: UQADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vqaddq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddq_u32)

## vqaddq_u64

`vqaddq_u64`

uint64x2_t vqaddq_u64 (uint64x2_t a, uint64x2_t b)
A32: VQADD.U64 Qd, Qn, Qm
A64: UQADD Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vqaddq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddq_u64)

## vqaddq_u8

`vqaddq_u8`

uint8x16_t vqaddq_u8 (uint8x16_t a, uint8x16_t b)
A32: VQADD.U8 Qd, Qn, Qm
A64: UQADD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vqaddq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddq_u8)

## vqneg_s16

`vqneg_s16`

int16x4_t vqneg_s16 (int16x4_t a)
A32: VQNEG.S16 Dd, Dm
A64: SQNEG Vd.4H, Vn.4H


Instruction Documentation: [vqneg_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqneg_s16)

## vqneg_s32

`vqneg_s32`

int32x2_t vqneg_s32 (int32x2_t a)
A32: VQNEG.S32 Dd, Dm
A64: SQNEG Vd.2S, Vn.2S


Instruction Documentation: [vqneg_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqneg_s32)

## vqneg_s8

`vqneg_s8`

int8x8_t vqneg_s8 (int8x8_t a)
A32: VQNEG.S8 Dd, Dm
A64: SQNEG Vd.8B, Vn.8B


Instruction Documentation: [vqneg_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqneg_s8)

## vqnegq_s16

`vqnegq_s16`

int16x8_t vqnegq_s16 (int16x8_t a)
A32: VQNEG.S16 Qd, Qm
A64: SQNEG Vd.8H, Vn.8H


Instruction Documentation: [vqnegq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqnegq_s16)

## vqnegq_s32

`vqnegq_s32`

int32x4_t vqnegq_s32 (int32x4_t a)
A32: VQNEG.S32 Qd, Qm
A64: SQNEG Vd.4S, Vn.4S


Instruction Documentation: [vqnegq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqnegq_s32)

## vqnegq_s8

`vqnegq_s8`

int8x16_t vqnegq_s8 (int8x16_t a)
A32: VQNEG.S8 Qd, Qm
A64: SQNEG Vd.16B, Vn.16B


Instruction Documentation: [vqnegq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqnegq_s8)

## vqrshl_s16

`vqrshl_s16`

int16x4_t vqrshl_s16 (int16x4_t a, int16x4_t b)
A32: VQRSHL.S16 Dd, Dn, Dm
A64: SQRSHL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vqrshl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshl_s16)

## vqrshl_s32

`vqrshl_s32`

int32x2_t vqrshl_s32 (int32x2_t a, int32x2_t b)
A32: VQRSHL.S32 Dd, Dn, Dm
A64: SQRSHL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vqrshl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshl_s32)

## vqrshl_s64

`vqrshl_s64`

int64x1_t vqrshl_s64 (int64x1_t a, int64x1_t b)
A32: VQRSHL.S64 Dd, Dn, Dm
A64: SQRSHL Dd, Dn, Dm


Instruction Documentation: [vqrshl_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshl_s64)

## vqrshl_s8

`vqrshl_s8`

int8x8_t vqrshl_s8 (int8x8_t a, int8x8_t b)
A32: VQRSHL.S8 Dd, Dn, Dm
A64: SQRSHL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vqrshl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshl_s8)

## vqrshl_u16

`vqrshl_u16`

uint16x4_t vqrshl_u16 (uint16x4_t a, int16x4_t b)
A32: VQRSHL.U16 Dd, Dn, Dm
A64: UQRSHL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vqrshl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshl_u16)

## vqrshl_u32

`vqrshl_u32`

uint32x2_t vqrshl_u32 (uint32x2_t a, int32x2_t b)
A32: VQRSHL.U32 Dd, Dn, Dm
A64: UQRSHL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vqrshl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshl_u32)

## vqrshl_u64

`vqrshl_u64`

uint64x1_t vqrshl_u64 (uint64x1_t a, int64x1_t b)
A32: VQRSHL.U64 Dd, Dn, Dm
A64: UQRSHL Dd, Dn, Dm


Instruction Documentation: [vqrshl_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshl_u64)

## vqrshl_u8

`vqrshl_u8`

uint8x8_t vqrshl_u8 (uint8x8_t a, int8x8_t b)
A32: VQRSHL.U8 Dd, Dn, Dm
A64: UQRSHL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vqrshl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshl_u8)

## vqrshlq_s16

`vqrshlq_s16`

int16x8_t vqrshlq_s16 (int16x8_t a, int16x8_t b)
A32: VQRSHL.S16 Qd, Qn, Qm
A64: SQRSHL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vqrshlq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlq_s16)

## vqrshlq_s32

`vqrshlq_s32`

int32x4_t vqrshlq_s32 (int32x4_t a, int32x4_t b)
A32: VQRSHL.S32 Qd, Qn, Qm
A64: SQRSHL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vqrshlq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlq_s32)

## vqrshlq_s64

`vqrshlq_s64`

int64x2_t vqrshlq_s64 (int64x2_t a, int64x2_t b)
A32: VQRSHL.S64 Qd, Qn, Qm
A64: SQRSHL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vqrshlq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlq_s64)

## vqrshlq_s8

`vqrshlq_s8`

int8x16_t vqrshlq_s8 (int8x16_t a, int8x16_t b)
A32: VQRSHL.S8 Qd, Qn, Qm
A64: SQRSHL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vqrshlq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlq_s8)

## vqrshlq_u16

`vqrshlq_u16`

uint16x8_t vqrshlq_u16 (uint16x8_t a, int16x8_t b)
A32: VQRSHL.U16 Qd, Qn, Qm
A64: UQRSHL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vqrshlq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlq_u16)

## vqrshlq_u32

`vqrshlq_u32`

uint32x4_t vqrshlq_u32 (uint32x4_t a, int32x4_t b)
A32: VQRSHL.U32 Qd, Qn, Qm
A64: UQRSHL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vqrshlq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlq_u32)

## vqrshlq_u64

`vqrshlq_u64`

uint64x2_t vqrshlq_u64 (uint64x2_t a, int64x2_t b)
A32: VQRSHL.U64 Qd, Qn, Qm
A64: UQRSHL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vqrshlq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlq_u64)

## vqrshlq_u8

`vqrshlq_u8`

uint8x16_t vqrshlq_u8 (uint8x16_t a, int8x16_t b)
A32: VQRSHL.U8 Qd, Qn, Qm
A64: UQRSHL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vqrshlq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlq_u8)

## vqrshrn_high_n_s16

`vqrshrn_high_n_s16`

int8x16_t vqrshrn_high_n_s16 (int8x8_t r, int16x8_t a, const int n)
A32: VQRSHRN.S16 Dd+1, Dn, #n
A64: SQRSHRN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vqrshrn_high_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_high_n_s16)

## vqrshrn_high_n_s32

`vqrshrn_high_n_s32`

int16x8_t vqrshrn_high_n_s32 (int16x4_t r, int32x4_t a, const int n)
A32: VQRSHRN.S32 Dd+1, Dn, #n
A64: SQRSHRN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vqrshrn_high_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_high_n_s32)

## vqrshrn_high_n_s64

`vqrshrn_high_n_s64`

int32x4_t vqrshrn_high_n_s64 (int32x2_t r, int64x2_t a, const int n)
A32: VQRSHRN.S64 Dd+1, Dn, #n
A64: SQRSHRN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vqrshrn_high_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_high_n_s64)

## vqrshrn_high_n_u16

`vqrshrn_high_n_u16`

uint8x16_t vqrshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n)
A32: VQRSHRN.U16 Dd+1, Dn, #n
A64: UQRSHRN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vqrshrn_high_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_high_n_u16)

## vqrshrn_high_n_u32

`vqrshrn_high_n_u32`

uint16x8_t vqrshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n)
A32: VQRSHRN.U32 Dd+1, Dn, #n
A64: UQRSHRN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vqrshrn_high_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_high_n_u32)

## vqrshrn_high_n_u64

`vqrshrn_high_n_u64`

uint32x4_t vqrshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n)
A32: VQRSHRN.U64 Dd+1, Dn, #n
A64: UQRSHRN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vqrshrn_high_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_high_n_u64)

## vqrshrn_n_s16

`vqrshrn_n_s16`

int8x8_t vqrshrn_n_s16 (int16x8_t a, const int n)
A32: VQRSHRN.S16 Dd, Qm, #n
A64: SQRSHRN Vd.8B, Vn.8H, #n


Instruction Documentation: [vqrshrn_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_n_s16)

## vqrshrn_n_s32

`vqrshrn_n_s32`

int16x4_t vqrshrn_n_s32 (int32x4_t a, const int n)
A32: VQRSHRN.S32 Dd, Qm, #n
A64: SQRSHRN Vd.4H, Vn.4S, #n


Instruction Documentation: [vqrshrn_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_n_s32)

## vqrshrn_n_s64

`vqrshrn_n_s64`

int32x2_t vqrshrn_n_s64 (int64x2_t a, const int n)
A32: VQRSHRN.S64 Dd, Qm, #n
A64: SQRSHRN Vd.2S, Vn.2D, #n


Instruction Documentation: [vqrshrn_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_n_s64)

## vqrshrn_n_u16

`vqrshrn_n_u16`

uint8x8_t vqrshrn_n_u16 (uint16x8_t a, const int n)
A32: VQRSHRN.U16 Dd, Qm, #n
A64: UQRSHRN Vd.8B, Vn.8H, #n


Instruction Documentation: [vqrshrn_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_n_u16)

## vqrshrn_n_u32

`vqrshrn_n_u32`

uint16x4_t vqrshrn_n_u32 (uint32x4_t a, const int n)
A32: VQRSHRN.U32 Dd, Qm, #n
A64: UQRSHRN Vd.4H, Vn.4S, #n


Instruction Documentation: [vqrshrn_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_n_u32)

## vqrshrn_n_u64

`vqrshrn_n_u64`

uint32x2_t vqrshrn_n_u64 (uint64x2_t a, const int n)
A32: VQRSHRN.U64 Dd, Qm, #n
A64: UQRSHRN Vd.2S, Vn.2D, #n


Instruction Documentation: [vqrshrn_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrn_n_u64)

## vqrshrun_high_n_s16

`vqrshrun_high_n_s16`

uint8x16_t vqrshrun_high_n_s16 (uint8x8_t r, int16x8_t a, const int n)
A32: VQRSHRUN.S16 Dd+1, Dn, #n
A64: SQRSHRUN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vqrshrun_high_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrun_high_n_s16)

## vqrshrun_high_n_s32

`vqrshrun_high_n_s32`

uint16x8_t vqrshrun_high_n_s32 (uint16x4_t r, int32x4_t a, const int n)
A32: VQRSHRUN.S32 Dd+1, Dn, #n
A64: SQRSHRUN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vqrshrun_high_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrun_high_n_s32)

## vqrshrun_high_n_s64

`vqrshrun_high_n_s64`

uint32x4_t vqrshrun_high_n_s64 (uint32x2_t r, int64x2_t a, const int n)
A32: VQRSHRUN.S64 Dd+1, Dn, #n
A64: SQRSHRUN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vqrshrun_high_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrun_high_n_s64)

## vqrshrun_n_s16

`vqrshrun_n_s16`

uint8x8_t vqrshrun_n_s16 (int16x8_t a, const int n)
A32: VQRSHRUN.S16 Dd, Qm, #n
A64: SQRSHRUN Vd.8B, Vn.8H, #n


Instruction Documentation: [vqrshrun_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrun_n_s16)

## vqrshrun_n_s32

`vqrshrun_n_s32`

uint16x4_t vqrshrun_n_s32 (int32x4_t a, const int n)
A32: VQRSHRUN.S32 Dd, Qm, #n
A64: SQRSHRUN Vd.4H, Vn.4S, #n


Instruction Documentation: [vqrshrun_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrun_n_s32)

## vqrshrun_n_s64

`vqrshrun_n_s64`

uint32x2_t vqrshrun_n_s64 (int64x2_t a, const int n)
A32: VQRSHRUN.S64 Dd, Qm, #n
A64: SQRSHRUN Vd.2S, Vn.2D, #n


Instruction Documentation: [vqrshrun_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrun_n_s64)

## vqshl_n_s16

`vqshl_n_s16`

int16x4_t vqshl_n_s16 (int16x4_t a, const int n)
A32: VQSHL.S16 Dd, Dm, #n
A64: SQSHL Vd.4H, Vn.4H, #n


Instruction Documentation: [vqshl_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_n_s16)

## vqshl_n_s32

`vqshl_n_s32`

int32x2_t vqshl_n_s32 (int32x2_t a, const int n)
A32: VQSHL.S32 Dd, Dm, #n
A64: SQSHL Vd.2S, Vn.2S, #n


Instruction Documentation: [vqshl_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_n_s32)

## vqshl_n_s64

`vqshl_n_s64`

int64x1_t vqshl_n_s64 (int64x1_t a, const int n)
A32: VQSHL.S64 Dd, Dm, #n
A64: SQSHL Dd, Dn, #n


Instruction Documentation: [vqshl_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_n_s64)

## vqshl_n_s8

`vqshl_n_s8`

int8x8_t vqshl_n_s8 (int8x8_t a, const int n)
A32: VQSHL.S8 Dd, Dm, #n
A64: SQSHL Vd.8B, Vn.8B, #n


Instruction Documentation: [vqshl_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_n_s8)

## vqshl_n_u16

`vqshl_n_u16`

uint16x4_t vqshl_n_u16 (uint16x4_t a, const int n)
A32: VQSHL.U16 Dd, Dm, #n
A64: UQSHL Vd.4H, Vn.4H, #n


Instruction Documentation: [vqshl_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_n_u16)

## vqshl_n_u32

`vqshl_n_u32`

uint32x2_t vqshl_n_u32 (uint32x2_t a, const int n)
A32: VQSHL.U32 Dd, Dm, #n
A64: UQSHL Vd.2S, Vn.2S, #n


Instruction Documentation: [vqshl_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_n_u32)

## vqshl_n_u64

`vqshl_n_u64`

uint64x1_t vqshl_n_u64 (uint64x1_t a, const int n)
A32: VQSHL.U64 Dd, Dm, #n
A64: UQSHL Dd, Dn, #n


Instruction Documentation: [vqshl_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_n_u64)

## vqshl_n_u8

`vqshl_n_u8`

uint8x8_t vqshl_n_u8 (uint8x8_t a, const int n)
A32: VQSHL.U8 Dd, Dm, #n
A64: UQSHL Vd.8B, Vn.8B, #n


Instruction Documentation: [vqshl_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_n_u8)

## vqshl_s16

`vqshl_s16`

int16x4_t vqshl_s16 (int16x4_t a, int16x4_t b)
A32: VQSHL.S16 Dd, Dn, Dm
A64: SQSHL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vqshl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_s16)

## vqshl_s32

`vqshl_s32`

int32x2_t vqshl_s32 (int32x2_t a, int32x2_t b)
A32: VQSHL.S32 Dd, Dn, Dm
A64: SQSHL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vqshl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_s32)

## vqshl_s64

`vqshl_s64`

int64x1_t vqshl_s64 (int64x1_t a, int64x1_t b)
A32: VQSHL.S64 Dd, Dn, Dm
A64: SQSHL Dd, Dn, Dm


Instruction Documentation: [vqshl_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_s64)

## vqshl_s8

`vqshl_s8`

int8x8_t vqshl_s8 (int8x8_t a, int8x8_t b)
A32: VQSHL.S8 Dd, Dn, Dm
A64: SQSHL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vqshl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_s8)

## vqshl_u16

`vqshl_u16`

uint16x4_t vqshl_u16 (uint16x4_t a, int16x4_t b)
A32: VQSHL.U16 Dd, Dn, Dm
A64: UQSHL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vqshl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_u16)

## vqshl_u32

`vqshl_u32`

uint32x2_t vqshl_u32 (uint32x2_t a, int32x2_t b)
A32: VQSHL.U32 Dd, Dn, Dm
A64: UQSHL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vqshl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_u32)

## vqshl_u64

`vqshl_u64`

uint64x1_t vqshl_u64 (uint64x1_t a, int64x1_t b)
A32: VQSHL.U64 Dd, Dn, Dm
A64: UQSHL Dd, Dn, Dm


Instruction Documentation: [vqshl_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_u64)

## vqshl_u8

`vqshl_u8`

uint8x8_t vqshl_u8 (uint8x8_t a, int8x8_t b)
A32: VQSHL.U8 Dd, Dn, Dm
A64: UQSHL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vqshl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshl_u8)

## vqshlq_n_s16

`vqshlq_n_s16`

int16x8_t vqshlq_n_s16 (int16x8_t a, const int n)
A32: VQSHL.S16 Qd, Qm, #n
A64: SQSHL Vd.8H, Vn.8H, #n


Instruction Documentation: [vqshlq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_n_s16)

## vqshlq_n_s32

`vqshlq_n_s32`

int32x4_t vqshlq_n_s32 (int32x4_t a, const int n)
A32: VQSHL.S32 Qd, Qm, #n
A64: SQSHL Vd.4S, Vn.4S, #n


Instruction Documentation: [vqshlq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_n_s32)

## vqshlq_n_s64

`vqshlq_n_s64`

int64x2_t vqshlq_n_s64 (int64x2_t a, const int n)
A32: VQSHL.S64 Qd, Qm, #n
A64: SQSHL Vd.2D, Vn.2D, #n


Instruction Documentation: [vqshlq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_n_s64)

## vqshlq_n_s8

`vqshlq_n_s8`

int8x16_t vqshlq_n_s8 (int8x16_t a, const int n)
A32: VQSHL.S8 Qd, Qm, #n
A64: SQSHL Vd.16B, Vn.16B, #n


Instruction Documentation: [vqshlq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_n_s8)

## vqshlq_n_u16

`vqshlq_n_u16`

uint16x8_t vqshlq_n_u16 (uint16x8_t a, const int n)
A32: VQSHL.U16 Qd, Qm, #n
A64: UQSHL Vd.8H, Vn.8H, #n


Instruction Documentation: [vqshlq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_n_u16)

## vqshlq_n_u32

`vqshlq_n_u32`

uint32x4_t vqshlq_n_u32 (uint32x4_t a, const int n)
A32: VQSHL.U32 Qd, Qm, #n
A64: UQSHL Vd.4S, Vn.4S, #n


Instruction Documentation: [vqshlq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_n_u32)

## vqshlq_n_u64

`vqshlq_n_u64`

uint64x2_t vqshlq_n_u64 (uint64x2_t a, const int n)
A32: VQSHL.U64 Qd, Qm, #n
A64: UQSHL Vd.2D, Vn.2D, #n


Instruction Documentation: [vqshlq_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_n_u64)

## vqshlq_n_u8

`vqshlq_n_u8`

uint8x16_t vqshlq_n_u8 (uint8x16_t a, const int n)
A32: VQSHL.U8 Qd, Qm, #n
A64: UQSHL Vd.16B, Vn.16B, #n


Instruction Documentation: [vqshlq_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_n_u8)

## vqshlq_s16

`vqshlq_s16`

int16x8_t vqshlq_s16 (int16x8_t a, int16x8_t b)
A32: VQSHL.S16 Qd, Qn, Qm
A64: SQSHL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vqshlq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_s16)

## vqshlq_s32

`vqshlq_s32`

int32x4_t vqshlq_s32 (int32x4_t a, int32x4_t b)
A32: VQSHL.S32 Qd, Qn, Qm
A64: SQSHL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vqshlq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_s32)

## vqshlq_s64

`vqshlq_s64`

int64x2_t vqshlq_s64 (int64x2_t a, int64x2_t b)
A32: VQSHL.S64 Qd, Qn, Qm
A64: SQSHL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vqshlq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_s64)

## vqshlq_s8

`vqshlq_s8`

int8x16_t vqshlq_s8 (int8x16_t a, int8x16_t b)
A32: VQSHL.S8 Qd, Qn, Qm
A64: SQSHL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vqshlq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_s8)

## vqshlq_u16

`vqshlq_u16`

uint16x8_t vqshlq_u16 (uint16x8_t a, int16x8_t b)
A32: VQSHL.U16 Qd, Qn, Qm
A64: UQSHL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vqshlq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_u16)

## vqshlq_u32

`vqshlq_u32`

uint32x4_t vqshlq_u32 (uint32x4_t a, int32x4_t b)
A32: VQSHL.U32 Qd, Qn, Qm
A64: UQSHL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vqshlq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_u32)

## vqshlq_u64

`vqshlq_u64`

uint64x2_t vqshlq_u64 (uint64x2_t a, int64x2_t b)
A32: VQSHL.U64 Qd, Qn, Qm
A64: UQSHL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vqshlq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_u64)

## vqshlq_u8

`vqshlq_u8`

uint8x16_t vqshlq_u8 (uint8x16_t a, int8x16_t b)
A32: VQSHL.U8 Qd, Qn, Qm
A64: UQSHL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vqshlq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlq_u8)

## vqshlu_n_s16

`vqshlu_n_s16`

uint16x4_t vqshlu_n_s16 (int16x4_t a, const int n)
A32: VQSHLU.S16 Dd, Dm, #n
A64: SQSHLU Vd.4H, Vn.4H, #n


Instruction Documentation: [vqshlu_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlu_n_s16)

## vqshlu_n_s32

`vqshlu_n_s32`

uint32x2_t vqshlu_n_s32 (int32x2_t a, const int n)
A32: VQSHLU.S32 Dd, Dm, #n
A64: SQSHLU Vd.2S, Vn.2S, #n


Instruction Documentation: [vqshlu_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlu_n_s32)

## vqshlu_n_s64

`vqshlu_n_s64`

uint64x1_t vqshlu_n_s64 (int64x1_t a, const int n)
A32: VQSHLU.S64 Dd, Dm, #n
A64: SQSHLU Dd, Dn, #n


Instruction Documentation: [vqshlu_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlu_n_s64)

## vqshlu_n_s8

`vqshlu_n_s8`

uint8x8_t vqshlu_n_s8 (int8x8_t a, const int n)
A32: VQSHLU.S8 Dd, Dm, #n
A64: SQSHLU Vd.8B, Vn.8B, #n


Instruction Documentation: [vqshlu_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlu_n_s8)

## vqshluq_n_s16

`vqshluq_n_s16`

uint16x8_t vqshluq_n_s16 (int16x8_t a, const int n)
A32: VQSHLU.S16 Qd, Qm, #n
A64: SQSHLU Vd.8H, Vn.8H, #n


Instruction Documentation: [vqshluq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshluq_n_s16)

## vqshluq_n_s32

`vqshluq_n_s32`

uint32x4_t vqshluq_n_s32 (int32x4_t a, const int n)
A32: VQSHLU.S32 Qd, Qm, #n
A64: SQSHLU Vd.4S, Vn.4S, #n


Instruction Documentation: [vqshluq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshluq_n_s32)

## vqshluq_n_s64

`vqshluq_n_s64`

uint64x2_t vqshluq_n_s64 (int64x2_t a, const int n)
A32: VQSHLU.S64 Qd, Qm, #n
A64: SQSHLU Vd.2D, Vn.2D, #n


Instruction Documentation: [vqshluq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshluq_n_s64)

## vqshluq_n_s8

`vqshluq_n_s8`

uint8x16_t vqshluq_n_s8 (int8x16_t a, const int n)
A32: VQSHLU.S8 Qd, Qm, #n
A64: SQSHLU Vd.16B, Vn.16B, #n


Instruction Documentation: [vqshluq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshluq_n_s8)

## vqshrn_high_n_s16

`vqshrn_high_n_s16`

int8x16_t vqshrn_high_n_s16 (int8x8_t r, int16x8_t a, const int n)
A32: VQSHRN.S16 Dd+1, Qm, #n
A64: SQSHRN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vqshrn_high_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_high_n_s16)

## vqshrn_high_n_s32

`vqshrn_high_n_s32`

int16x8_t vqshrn_high_n_s32 (int16x4_t r, int32x4_t a, const int n)
A32: VQSHRN.S32 Dd+1, Qm, #n
A64: SQSHRN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vqshrn_high_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_high_n_s32)

## vqshrn_high_n_s64

`vqshrn_high_n_s64`

int32x4_t vqshrn_high_n_s64 (int32x2_t r, int64x2_t a, const int n)
A32: VQSHRN.S64 Dd+1, Qm, #n
A64: SQSHRN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vqshrn_high_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_high_n_s64)

## vqshrn_high_n_u16

`vqshrn_high_n_u16`

uint8x16_t vqshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n)
A32: VQSHRN.U16 Dd+1, Qm, #n
A64: UQSHRN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vqshrn_high_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_high_n_u16)

## vqshrn_high_n_u32

`vqshrn_high_n_u32`

uint16x8_t vqshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n)
A32: VQSHRN.U32 Dd+1, Qm, #n
A64: UQSHRN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vqshrn_high_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_high_n_u32)

## vqshrn_high_n_u64

`vqshrn_high_n_u64`

uint32x4_t vqshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n)
A32: VQSHRN.U64 Dd+1, Qm, #n
A64: UQSHRN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vqshrn_high_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_high_n_u64)

## vqshrn_n_s16

`vqshrn_n_s16`

int8x8_t vqshrn_n_s16 (int16x8_t a, const int n)
A32: VQSHRN.S16 Dd, Qm, #n
A64: SQSHRN Vd.8B, Vn.8H, #n


Instruction Documentation: [vqshrn_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_n_s16)

## vqshrn_n_s32

`vqshrn_n_s32`

int16x4_t vqshrn_n_s32 (int32x4_t a, const int n)
A32: VQSHRN.S32 Dd, Qm, #n
A64: SQSHRN Vd.4H, Vn.4S, #n


Instruction Documentation: [vqshrn_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_n_s32)

## vqshrn_n_s64

`vqshrn_n_s64`

int32x2_t vqshrn_n_s64 (int64x2_t a, const int n)
A32: VQSHRN.S64 Dd, Qm, #n
A64: SQSHRN Vd.2S, Vn.2D, #n


Instruction Documentation: [vqshrn_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_n_s64)

## vqshrn_n_u16

`vqshrn_n_u16`

uint8x8_t vqshrn_n_u16 (uint16x8_t a, const int n)
A32: VQSHRN.U16 Dd, Qm, #n
A64: UQSHRN Vd.8B, Vn.8H, #n


Instruction Documentation: [vqshrn_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_n_u16)

## vqshrn_n_u32

`vqshrn_n_u32`

uint16x4_t vqshrn_n_u32 (uint32x4_t a, const int n)
A32: VQSHRN.U32 Dd, Qm, #n
A64: UQSHRN Vd.4H, Vn.4S, #n


Instruction Documentation: [vqshrn_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_n_u32)

## vqshrn_n_u64

`vqshrn_n_u64`

uint32x2_t vqshrn_n_u64 (uint64x2_t a, const int n)
A32: VQSHRN.U64 Dd, Qm, #n
A64: UQSHRN Vd.2S, Vn.2D, #n


Instruction Documentation: [vqshrn_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrn_n_u64)

## vqshrun_high_n_s16

`vqshrun_high_n_s16`

uint8x16_t vqshrun_high_n_s16 (uint8x8_t r, int16x8_t a, const int n)
A32: VQSHRUN.S16 Dd+1, Dn, #n
A64: SQSHRUN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vqshrun_high_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrun_high_n_s16)

## vqshrun_high_n_s32

`vqshrun_high_n_s32`

uint16x8_t vqshrun_high_n_s32 (uint16x4_t r, int32x4_t a, const int n)
A32: VQSHRUN.S32 Dd+1, Dn, #n
A64: SQSHRUN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vqshrun_high_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrun_high_n_s32)

## vqshrun_high_n_s64

`vqshrun_high_n_s64`

uint32x4_t vqshrun_high_n_s64 (uint32x2_t r, int64x2_t a, const int n)
A32: VQSHRUN.S64 Dd+1, Dn, #n
A64: SQSHRUN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vqshrun_high_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrun_high_n_s64)

## vqshrun_n_s16

`vqshrun_n_s16`

uint8x8_t vqshrun_n_s16 (int16x8_t a, const int n)
A32: VQSHRUN.S16 Dd, Qm, #n
A64: SQSHRUN Vd.8B, Vn.8H, #n


Instruction Documentation: [vqshrun_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrun_n_s16)

## vqshrun_n_s32

`vqshrun_n_s32`

uint16x4_t vqshrun_n_s32 (int32x4_t a, const int n)
A32: VQSHRUN.S32 Dd, Qm, #n
A64: SQSHRUN Vd.4H, Vn.4S, #n


Instruction Documentation: [vqshrun_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrun_n_s32)

## vqshrun_n_s64

`vqshrun_n_s64`

uint32x2_t vqshrun_n_s64 (int64x2_t a, const int n)
A32: VQSHRUN.S64 Dd, Qm, #n
A64: SQSHRUN Vd.2S, Vn.2D, #n


Instruction Documentation: [vqshrun_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrun_n_s64)

## vqsub_s16

`vqsub_s16`

int16x4_t vqsub_s16 (int16x4_t a, int16x4_t b)
A32: VQSUB.S16 Dd, Dn, Dm
A64: SQSUB Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vqsub_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsub_s16)

## vqsub_s32

`vqsub_s32`

int32x2_t vqsub_s32 (int32x2_t a, int32x2_t b)
A32: VQSUB.S32 Dd, Dn, Dm
A64: SQSUB Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vqsub_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsub_s32)

## vqsub_s64

`vqsub_s64`

int64x1_t vqsub_s64 (int64x1_t a, int64x1_t b)
A32: VQSUB.S64 Dd, Dn, Dm
A64: SQSUB Dd, Dn, Dm


Instruction Documentation: [vqsub_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsub_s64)

## vqsub_s8

`vqsub_s8`

int8x8_t vqsub_s8 (int8x8_t a, int8x8_t b)
A32: VQSUB.S8 Dd, Dn, Dm
A64: SQSUB Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vqsub_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsub_s8)

## vqsub_u16

`vqsub_u16`

uint16x4_t vqsub_u16 (uint16x4_t a, uint16x4_t b)
A32: VQSUB.U16 Dd, Dn, Dm
A64: UQSUB Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vqsub_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsub_u16)

## vqsub_u32

`vqsub_u32`

uint32x2_t vqsub_u32 (uint32x2_t a, uint32x2_t b)
A32: VQSUB.U32 Dd, Dn, Dm
A64: UQSUB Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vqsub_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsub_u32)

## vqsub_u64

`vqsub_u64`

uint64x1_t vqsub_u64 (uint64x1_t a, uint64x1_t b)
A32: VQSUB.U64 Dd, Dn, Dm
A64: UQSUB Dd, Dn, Dm


Instruction Documentation: [vqsub_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsub_u64)

## vqsub_u8

`vqsub_u8`

uint8x8_t vqsub_u8 (uint8x8_t a, uint8x8_t b)
A32: VQSUB.U8 Dd, Dn, Dm
A64: UQSUB Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vqsub_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsub_u8)

## vqsubq_s16

`vqsubq_s16`

int16x8_t vqsubq_s16 (int16x8_t a, int16x8_t b)
A32: VQSUB.S16 Qd, Qn, Qm
A64: SQSUB Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vqsubq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubq_s16)

## vqsubq_s32

`vqsubq_s32`

int32x4_t vqsubq_s32 (int32x4_t a, int32x4_t b)
A32: VQSUB.S32 Qd, Qn, Qm
A64: SQSUB Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vqsubq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubq_s32)

## vqsubq_s64

`vqsubq_s64`

int64x2_t vqsubq_s64 (int64x2_t a, int64x2_t b)
A32: VQSUB.S64 Qd, Qn, Qm
A64: SQSUB Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vqsubq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubq_s64)

## vqsubq_s8

`vqsubq_s8`

int8x16_t vqsubq_s8 (int8x16_t a, int8x16_t b)
A32: VQSUB.S8 Qd, Qn, Qm
A64: SQSUB Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vqsubq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubq_s8)

## vqsubq_u16

`vqsubq_u16`

uint16x8_t vqsubq_u16 (uint16x8_t a, uint16x8_t b)
A32: VQSUB.U16 Qd, Qn, Qm
A64: UQSUB Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vqsubq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubq_u16)

## vqsubq_u32

`vqsubq_u32`

uint32x4_t vqsubq_u32 (uint32x4_t a, uint32x4_t b)
A32: VQSUB.U32 Qd, Qn, Qm
A64: UQSUB Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vqsubq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubq_u32)

## vqsubq_u64

`vqsubq_u64`

uint64x2_t vqsubq_u64 (uint64x2_t a, uint64x2_t b)
A32: VQSUB.U64 Qd, Qn, Qm
A64: UQSUB Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vqsubq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubq_u64)

## vqsubq_u8

`vqsubq_u8`

uint8x16_t vqsubq_u8 (uint8x16_t a, uint8x16_t b)
A32: VQSUB.U8 Qd, Qn, Qm
A64: UQSUB Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vqsubq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubq_u8)

## vqvtbl1_s8

`vqvtbl1_s8`

int8x8_t vqvtbl1_s8(int8x16_t t, uint8x8_t idx)
A32: VTBL Dd, {Dn, Dn+1}, Dm
A64: TBL Vd.8B, {Vn.16B}, Vm.8B


Instruction Documentation: [vqvtbl1_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqvtbl1_s8)

## vqvtbl1_u8

`vqvtbl1_u8`

uint8x8_t vqvtbl1_u8(uint8x16_t t, uint8x8_t idx)
A32: VTBL Dd, {Dn, Dn+1}, Dm
A64: TBL Vd.8B, {Vn.16B}, Vm.8B


Instruction Documentation: [vqvtbl1_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqvtbl1_u8)

## vqvtbx1_s8

`vqvtbx1_s8`

int8x8_t vqvtbx1_s8(int8x8_t r, int8x16_t t, uint8x8_t idx)
A32: VTBX Dd, {Dn, Dn+1}, Dm
A64: TBX Vd.8B, {Vn.16B}, Vm.8B


Instruction Documentation: [vqvtbx1_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqvtbx1_s8)

## vqvtbx1_u8

`vqvtbx1_u8`

uint8x8_t vqvtbx1_u8(uint8x8_t r, uint8x16_t t, uint8x8_t idx)
A32: VTBX Dd, {Dn, Dn+1}, Dm
A64: TBX Vd.8B, {Vn.16B}, Vm.8B


Instruction Documentation: [vqvtbx1_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqvtbx1_u8)

## vraddhn_high_s16

`vraddhn_high_s16`

int8x16_t vraddhn_high_s16 (int8x8_t r, int16x8_t a, int16x8_t b)
A32: VRADDHN.I16 Dd+1, Qn, Qm
A64: RADDHN2 Vd.16B, Vn.8H, Vm.8H


Instruction Documentation: [vraddhn_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_high_s16)

## vraddhn_high_s32

`vraddhn_high_s32`

int16x8_t vraddhn_high_s32 (int16x4_t r, int32x4_t a, int32x4_t b)
A32: VRADDHN.I32 Dd+1, Qn, Qm
A64: RADDHN2 Vd.8H, Vn.4S, Vm.4S


Instruction Documentation: [vraddhn_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_high_s32)

## vraddhn_high_s64

`vraddhn_high_s64`

int32x4_t vraddhn_high_s64 (int32x2_t r, int64x2_t a, int64x2_t b)
A32: VRADDHN.I64 Dd+1, Qn, Qm
A64: RADDHN2 Vd.4S, Vn.2D, Vm.2D


Instruction Documentation: [vraddhn_high_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_high_s64)

## vraddhn_high_u16

`vraddhn_high_u16`

uint8x16_t vraddhn_high_u16 (uint8x8_t r, uint16x8_t a, uint16x8_t b)
A32: VRADDHN.I16 Dd+1, Qn, Qm
A64: RADDHN2 Vd.16B, Vn.8H, Vm.8H


Instruction Documentation: [vraddhn_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_high_u16)

## vraddhn_high_u32

`vraddhn_high_u32`

uint16x8_t vraddhn_high_u32 (uint16x4_t r, uint32x4_t a, uint32x4_t b)
A32: VRADDHN.I32 Dd+1, Qn, Qm
A64: RADDHN2 Vd.8H, Vn.4S, Vm.4S


Instruction Documentation: [vraddhn_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_high_u32)

## vraddhn_high_u64

`vraddhn_high_u64`

uint32x4_t vraddhn_high_u64 (uint32x2_t r, uint64x2_t a, uint64x2_t b)
A32: VRADDHN.I64 Dd+1, Qn, Qm
A64: RADDHN2 Vd.4S, Vn.2D, Vm.2D


Instruction Documentation: [vraddhn_high_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_high_u64)

## vraddhn_s16

`vraddhn_s16`

int8x8_t vraddhn_s16 (int16x8_t a, int16x8_t b)
A32: VRADDHN.I16 Dd, Qn, Qm
A64: RADDHN Vd.8B, Vn.8H, Vm.8H


Instruction Documentation: [vraddhn_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_s16)

## vraddhn_s32

`vraddhn_s32`

int16x4_t vraddhn_s32 (int32x4_t a, int32x4_t b)
A32: VRADDHN.I32 Dd, Qn, Qm
A64: RADDHN Vd.4H, Vn.4S, Vm.4S


Instruction Documentation: [vraddhn_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_s32)

## vraddhn_s64

`vraddhn_s64`

int32x2_t vraddhn_s64 (int64x2_t a, int64x2_t b)
A32: VRADDHN.I64 Dd, Qn, Qm
A64: RADDHN Vd.2S, Vn.2D, Vm.2D


Instruction Documentation: [vraddhn_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_s64)

## vraddhn_u16

`vraddhn_u16`

uint8x8_t vraddhn_u16 (uint16x8_t a, uint16x8_t b)
A32: VRADDHN.I16 Dd, Qn, Qm
A64: RADDHN Vd.8B, Vn.8H, Vm.8H


Instruction Documentation: [vraddhn_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_u16)

## vraddhn_u32

`vraddhn_u32`

uint16x4_t vraddhn_u32 (uint32x4_t a, uint32x4_t b)
A32: VRADDHN.I32 Dd, Qn, Qm
A64: RADDHN Vd.4H, Vn.4S, Vm.4S


Instruction Documentation: [vraddhn_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_u32)

## vraddhn_u64

`vraddhn_u64`

uint32x2_t vraddhn_u64 (uint64x2_t a, uint64x2_t b)
A32: VRADDHN.I64 Dd, Qn, Qm
A64: RADDHN Vd.2S, Vn.2D, Vm.2D


Instruction Documentation: [vraddhn_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vraddhn_u64)

## vrecpe_f32

`vrecpe_f32`

float32x2_t vrecpe_f32 (float32x2_t a)
A32: VRECPE.F32 Dd, Dm
A64: FRECPE Vd.2S, Vn.2S


Instruction Documentation: [vrecpe_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpe_f32)

## vrecpe_u32

`vrecpe_u32`

uint32x2_t vrecpe_u32 (uint32x2_t a)
A32: VRECPE.U32 Dd, Dm
A64: URECPE Vd.2S, Vn.2S


Instruction Documentation: [vrecpe_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpe_u32)

## vrecpeq_f32

`vrecpeq_f32`

float32x4_t vrecpeq_f32 (float32x4_t a)
A32: VRECPE.F32 Qd, Qm
A64: FRECPE Vd.4S, Vn.4S


Instruction Documentation: [vrecpeq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpeq_f32)

## vrecpeq_u32

`vrecpeq_u32`

uint32x4_t vrecpeq_u32 (uint32x4_t a)
A32: VRECPE.U32 Qd, Qm
A64: URECPE Vd.4S, Vn.4S


Instruction Documentation: [vrecpeq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpeq_u32)

## vrecps_f32

`vrecps_f32`

float32x2_t vrecps_f32 (float32x2_t a, float32x2_t b)
A32: VRECPS.F32 Dd, Dn, Dm
A64: FRECPS Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vrecps_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecps_f32)

## vrecpsq_f32

`vrecpsq_f32`

float32x4_t vrecpsq_f32 (float32x4_t a, float32x4_t b)
A32: VRECPS.F32 Qd, Qn, Qm
A64: FRECPS Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vrecpsq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpsq_f32)

## vrhadd_s16

`vrhadd_s16`

int16x4_t vrhadd_s16 (int16x4_t a, int16x4_t b)
A32: VRHADD.S16 Dd, Dn, Dm
A64: SRHADD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vrhadd_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhadd_s16)

## vrhadd_s32

`vrhadd_s32`

int32x2_t vrhadd_s32 (int32x2_t a, int32x2_t b)
A32: VRHADD.S32 Dd, Dn, Dm
A64: SRHADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vrhadd_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhadd_s32)

## vrhadd_s8

`vrhadd_s8`

int8x8_t vrhadd_s8 (int8x8_t a, int8x8_t b)
A32: VRHADD.S8 Dd, Dn, Dm
A64: SRHADD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vrhadd_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhadd_s8)

## vrhadd_u16

`vrhadd_u16`

uint16x4_t vrhadd_u16 (uint16x4_t a, uint16x4_t b)
A32: VRHADD.U16 Dd, Dn, Dm
A64: URHADD Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vrhadd_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhadd_u16)

## vrhadd_u32

`vrhadd_u32`

uint32x2_t vrhadd_u32 (uint32x2_t a, uint32x2_t b)
A32: VRHADD.U32 Dd, Dn, Dm
A64: URHADD Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vrhadd_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhadd_u32)

## vrhadd_u8

`vrhadd_u8`

uint8x8_t vrhadd_u8 (uint8x8_t a, uint8x8_t b)
A32: VRHADD.U8 Dd, Dn, Dm
A64: URHADD Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vrhadd_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhadd_u8)

## vrhaddq_s16

`vrhaddq_s16`

int16x8_t vrhaddq_s16 (int16x8_t a, int16x8_t b)
A32: VRHADD.S16 Qd, Qn, Qm
A64: SRHADD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vrhaddq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhaddq_s16)

## vrhaddq_s32

`vrhaddq_s32`

int32x4_t vrhaddq_s32 (int32x4_t a, int32x4_t b)
A32: VRHADD.S32 Qd, Qn, Qm
A64: SRHADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vrhaddq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhaddq_s32)

## vrhaddq_s8

`vrhaddq_s8`

int8x16_t vrhaddq_s8 (int8x16_t a, int8x16_t b)
A32: VRHADD.S8 Qd, Qn, Qm
A64: SRHADD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vrhaddq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhaddq_s8)

## vrhaddq_u16

`vrhaddq_u16`

uint16x8_t vrhaddq_u16 (uint16x8_t a, uint16x8_t b)
A32: VRHADD.U16 Qd, Qn, Qm
A64: URHADD Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vrhaddq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhaddq_u16)

## vrhaddq_u32

`vrhaddq_u32`

uint32x4_t vrhaddq_u32 (uint32x4_t a, uint32x4_t b)
A32: VRHADD.U32 Qd, Qn, Qm
A64: URHADD Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vrhaddq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhaddq_u32)

## vrhaddq_u8

`vrhaddq_u8`

uint8x16_t vrhaddq_u8 (uint8x16_t a, uint8x16_t b)
A32: VRHADD.U8 Qd, Qn, Qm
A64: URHADD Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vrhaddq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrhaddq_u8)

## vrnd_f32

`vrnd_f32`

float32x2_t vrnd_f32 (float32x2_t a)
A32: VRINTZ.F32 Dd, Dm
A64: FRINTZ Vd.2S, Vn.2S


Instruction Documentation: [vrnd_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrnd_f32)

## vrnd_f64

`vrnd_f64`

float64x1_t vrnd_f64 (float64x1_t a)
A32: VRINTZ.F64 Dd, Dm
A64: FRINTZ Dd, Dn


Instruction Documentation: [vrnd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrnd_f64)

## vrnda_f32

`vrnda_f32`

float32x2_t vrnda_f32 (float32x2_t a)
A32: VRINTA.F32 Dd, Dm
A64: FRINTA Vd.2S, Vn.2S


Instruction Documentation: [vrnda_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrnda_f32)

## vrnda_f64

`vrnda_f64`

float64x1_t vrnda_f64 (float64x1_t a)
A32: VRINTA.F64 Dd, Dm
A64: FRINTA Dd, Dn


Instruction Documentation: [vrnda_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrnda_f64)

## vrndaq_f32

`vrndaq_f32`

float32x4_t vrndaq_f32 (float32x4_t a)
A32: VRINTA.F32 Qd, Qm
A64: FRINTA Vd.4S, Vn.4S


Instruction Documentation: [vrndaq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndaq_f32)

## vrndas_f32

`vrndas_f32`

float32_t vrndas_f32 (float32_t a)
A32: VRINTA.F32 Sd, Sm
A64: FRINTA Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vrndas_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndas_f32)

## vrndm_f32

`vrndm_f32`

float32x2_t vrndm_f32 (float32x2_t a)
A32: VRINTM.F32 Dd, Dm
A64: FRINTM Vd.2S, Vn.2S


Instruction Documentation: [vrndm_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndm_f32)

## vrndm_f64

`vrndm_f64`

float64x1_t vrndm_f64 (float64x1_t a)
A32: VRINTM.F64 Dd, Dm
A64: FRINTM Dd, Dn


Instruction Documentation: [vrndm_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndm_f64)

## vrndmq_f32

`vrndmq_f32`

float32x4_t vrndmq_f32 (float32x4_t a)
A32: VRINTM.F32 Qd, Qm
A64: FRINTM Vd.4S, Vn.4S


Instruction Documentation: [vrndmq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndmq_f32)

## vrndms_f32

`vrndms_f32`

float32_t vrndms_f32 (float32_t a)
A32: VRINTM.F32 Sd, Sm
A64: FRINTM Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vrndms_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndms_f32)

## vrndn_f32

`vrndn_f32`

float32x2_t vrndn_f32 (float32x2_t a)
A32: VRINTN.F32 Dd, Dm
A64: FRINTN Vd.2S, Vn.2S


Instruction Documentation: [vrndn_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndn_f32)

## vrndn_f64

`vrndn_f64`

float64x1_t vrndn_f64 (float64x1_t a)
A32: VRINTN.F64 Dd, Dm
A64: FRINTN Dd, Dn


Instruction Documentation: [vrndn_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndn_f64)

## vrndnq_f32

`vrndnq_f32`

float32x4_t vrndnq_f32 (float32x4_t a)
A32: VRINTN.F32 Qd, Qm
A64: FRINTN Vd.4S, Vn.4S


Instruction Documentation: [vrndnq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndnq_f32)

## vrndns_f32

`vrndns_f32`

float32_t vrndns_f32 (float32_t a)
A32: VRINTN.F32 Sd, Sm
A64: FRINTN Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vrndns_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndns_f32)

## vrndp_f32

`vrndp_f32`

float32x2_t vrndp_f32 (float32x2_t a)
A32: VRINTP.F32 Dd, Dm
A64: FRINTP Vd.2S, Vn.2S


Instruction Documentation: [vrndp_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndp_f32)

## vrndp_f64

`vrndp_f64`

float64x1_t vrndp_f64 (float64x1_t a)
A32: VRINTP.F64 Dd, Dm
A64: FRINTP Dd, Dn


Instruction Documentation: [vrndp_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndp_f64)

## vrndpq_f32

`vrndpq_f32`

float32x4_t vrndpq_f32 (float32x4_t a)
A32: VRINTP.F32 Qd, Qm
A64: FRINTP Vd.4S, Vn.4S


Instruction Documentation: [vrndpq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndpq_f32)

## vrndps_f32

`vrndps_f32`

float32_t vrndps_f32 (float32_t a)
A32: VRINTP.F32 Sd, Sm
A64: FRINTP Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vrndps_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndps_f32)

## vrndq_f32

`vrndq_f32`

float32x4_t vrndq_f32 (float32x4_t a)
A32: VRINTZ.F32 Qd, Qm
A64: FRINTZ Vd.4S, Vn.4S


Instruction Documentation: [vrndq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndq_f32)

## vrnds_f32

`vrnds_f32`

float32_t vrnds_f32 (float32_t a)
A32: VRINTZ.F32 Sd, Sm
A64: FRINTZ Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vrnds_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrnds_f32)

## vrshl_s16

`vrshl_s16`

int16x4_t vrshl_s16 (int16x4_t a, int16x4_t b)
A32: VRSHL.S16 Dd, Dn, Dm
A64: SRSHL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vrshl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshl_s16)

## vrshl_s32

`vrshl_s32`

int32x2_t vrshl_s32 (int32x2_t a, int32x2_t b)
A32: VRSHL.S32 Dd, Dn, Dm
A64: SRSHL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vrshl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshl_s32)

## vrshl_s64

`vrshl_s64`

int64x1_t vrshl_s64 (int64x1_t a, int64x1_t b)
A32: VRSHL.S64 Dd, Dn, Dm
A64: SRSHL Dd, Dn, Dm


Instruction Documentation: [vrshl_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshl_s64)

## vrshl_s8

`vrshl_s8`

int8x8_t vrshl_s8 (int8x8_t a, int8x8_t b)
A32: VRSHL.S8 Dd, Dn, Dm
A64: SRSHL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vrshl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshl_s8)

## vrshl_u16

`vrshl_u16`

uint16x4_t vrshl_u16 (uint16x4_t a, int16x4_t b)
A32: VRSHL.U16 Dd, Dn, Dm
A64: URSHL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vrshl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshl_u16)

## vrshl_u32

`vrshl_u32`

uint32x2_t vrshl_u32 (uint32x2_t a, int32x2_t b)
A32: VRSHL.U32 Dd, Dn, Dm
A64: URSHL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vrshl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshl_u32)

## vrshl_u64

`vrshl_u64`

uint64x1_t vrshl_u64 (uint64x1_t a, int64x1_t b)
A32: VRSHL.U64 Dd, Dn, Dm
A64: URSHL Dd, Dn, Dm


Instruction Documentation: [vrshl_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshl_u64)

## vrshl_u8

`vrshl_u8`

uint8x8_t vrshl_u8 (uint8x8_t a, int8x8_t b)
A32: VRSHL.U8 Dd, Dn, Dm
A64: URSHL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vrshl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshl_u8)

## vrshlq_s16

`vrshlq_s16`

int16x8_t vrshlq_s16 (int16x8_t a, int16x8_t b)
A32: VRSHL.S16 Qd, Qn, Qm
A64: SRSHL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vrshlq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshlq_s16)

## vrshlq_s32

`vrshlq_s32`

int32x4_t vrshlq_s32 (int32x4_t a, int32x4_t b)
A32: VRSHL.S32 Qd, Qn, Qm
A64: SRSHL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vrshlq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshlq_s32)

## vrshlq_s64

`vrshlq_s64`

int64x2_t vrshlq_s64 (int64x2_t a, int64x2_t b)
A32: VRSHL.S64 Qd, Qn, Qm
A64: SRSHL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vrshlq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshlq_s64)

## vrshlq_s8

`vrshlq_s8`

int8x16_t vrshlq_s8 (int8x16_t a, int8x16_t b)
A32: VRSHL.S8 Qd, Qn, Qm
A64: SRSHL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vrshlq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshlq_s8)

## vrshlq_u16

`vrshlq_u16`

uint16x8_t vrshlq_u16 (uint16x8_t a, int16x8_t b)
A32: VRSHL.U16 Qd, Qn, Qm
A64: URSHL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vrshlq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshlq_u16)

## vrshlq_u32

`vrshlq_u32`

uint32x4_t vrshlq_u32 (uint32x4_t a, int32x4_t b)
A32: VRSHL.U32 Qd, Qn, Qm
A64: URSHL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vrshlq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshlq_u32)

## vrshlq_u64

`vrshlq_u64`

uint64x2_t vrshlq_u64 (uint64x2_t a, int64x2_t b)
A32: VRSHL.U64 Qd, Qn, Qm
A64: URSHL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vrshlq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshlq_u64)

## vrshlq_u8

`vrshlq_u8`

uint8x16_t vrshlq_u8 (uint8x16_t a, int8x16_t b)
A32: VRSHL.U8 Qd, Qn, Qm
A64: URSHL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vrshlq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshlq_u8)

## vrshr_n_s16

`vrshr_n_s16`

int16x4_t vrshr_n_s16 (int16x4_t a, const int n)
A32: VRSHR.S16 Dd, Dm, #n
A64: SRSHR Vd.4H, Vn.4H, #n


Instruction Documentation: [vrshr_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshr_n_s16)

## vrshr_n_s32

`vrshr_n_s32`

int32x2_t vrshr_n_s32 (int32x2_t a, const int n)
A32: VRSHR.S32 Dd, Dm, #n
A64: SRSHR Vd.2S, Vn.2S, #n


Instruction Documentation: [vrshr_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshr_n_s32)

## vrshr_n_s64

`vrshr_n_s64`

int64x1_t vrshr_n_s64 (int64x1_t a, const int n)
A32: VRSHR.S64 Dd, Dm, #n
A64: SRSHR Dd, Dn, #n


Instruction Documentation: [vrshr_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshr_n_s64)

## vrshr_n_s8

`vrshr_n_s8`

int8x8_t vrshr_n_s8 (int8x8_t a, const int n)
A32: VRSHR.S8 Dd, Dm, #n
A64: SRSHR Vd.8B, Vn.8B, #n


Instruction Documentation: [vrshr_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshr_n_s8)

## vrshr_n_u16

`vrshr_n_u16`

uint16x4_t vrshr_n_u16 (uint16x4_t a, const int n)
A32: VRSHR.U16 Dd, Dm, #n
A64: URSHR Vd.4H, Vn.4H, #n


Instruction Documentation: [vrshr_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshr_n_u16)

## vrshr_n_u32

`vrshr_n_u32`

uint32x2_t vrshr_n_u32 (uint32x2_t a, const int n)
A32: VRSHR.U32 Dd, Dm, #n
A64: URSHR Vd.2S, Vn.2S, #n


Instruction Documentation: [vrshr_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshr_n_u32)

## vrshr_n_u64

`vrshr_n_u64`

uint64x1_t vrshr_n_u64 (uint64x1_t a, const int n)
A32: VRSHR.U64 Dd, Dm, #n
A64: URSHR Dd, Dn, #n


Instruction Documentation: [vrshr_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshr_n_u64)

## vrshr_n_u8

`vrshr_n_u8`

uint8x8_t vrshr_n_u8 (uint8x8_t a, const int n)
A32: VRSHR.U8 Dd, Dm, #n
A64: URSHR Vd.8B, Vn.8B, #n


Instruction Documentation: [vrshr_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshr_n_u8)

## vrshrn_high_n_s16

`vrshrn_high_n_s16`

int8x16_t vrshrn_high_n_s16 (int8x8_t r, int16x8_t a, const int n)
A32: VRSHRN.I16 Dd+1, Qm, #n
A64: RSHRN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vrshrn_high_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_high_n_s16)

## vrshrn_high_n_s32

`vrshrn_high_n_s32`

int16x8_t vrshrn_high_n_s32 (int16x4_t r, int32x4_t a, const int n)
A32: VRSHRN.I32 Dd+1, Qm, #n
A64: RSHRN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vrshrn_high_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_high_n_s32)

## vrshrn_high_n_s64

`vrshrn_high_n_s64`

int32x4_t vrshrn_high_n_s64 (int32x2_t r, int64x2_t a, const int n)
A32: VRSHRN.I64 Dd+1, Qm, #n
A64: RSHRN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vrshrn_high_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_high_n_s64)

## vrshrn_high_n_u16

`vrshrn_high_n_u16`

uint8x16_t vrshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n)
A32: VRSHRN.I16 Dd+1, Qm, #n
A64: RSHRN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vrshrn_high_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_high_n_u16)

## vrshrn_high_n_u32

`vrshrn_high_n_u32`

uint16x8_t vrshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n)
A32: VRSHRN.I32 Dd+1, Qm, #n
A64: RSHRN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vrshrn_high_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_high_n_u32)

## vrshrn_high_n_u64

`vrshrn_high_n_u64`

uint32x4_t vrshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n)
A32: VRSHRN.I64 Dd+1, Qm, #n
A64: RSHRN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vrshrn_high_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_high_n_u64)

## vrshrn_n_s16

`vrshrn_n_s16`

int8x8_t vrshrn_n_s16 (int16x8_t a, const int n)
A32: VRSHRN.I16 Dd, Qm, #n
A64: RSHRN Vd.8B, Vn.8H, #n


Instruction Documentation: [vrshrn_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_n_s16)

## vrshrn_n_s32

`vrshrn_n_s32`

int16x4_t vrshrn_n_s32 (int32x4_t a, const int n)
A32: VRSHRN.I32 Dd, Qm, #n
A64: RSHRN Vd.4H, Vn.4S, #n


Instruction Documentation: [vrshrn_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_n_s32)

## vrshrn_n_s64

`vrshrn_n_s64`

int32x2_t vrshrn_n_s64 (int64x2_t a, const int n)
A32: VRSHRN.I64 Dd, Qm, #n
A64: RSHRN Vd.2S, Vn.2D, #n


Instruction Documentation: [vrshrn_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_n_s64)

## vrshrn_n_u16

`vrshrn_n_u16`

uint8x8_t vrshrn_n_u16 (uint16x8_t a, const int n)
A32: VRSHRN.I16 Dd, Qm, #n
A64: RSHRN Vd.8B, Vn.8H, #n


Instruction Documentation: [vrshrn_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_n_u16)

## vrshrn_n_u32

`vrshrn_n_u32`

uint16x4_t vrshrn_n_u32 (uint32x4_t a, const int n)
A32: VRSHRN.I32 Dd, Qm, #n
A64: RSHRN Vd.4H, Vn.4S, #n


Instruction Documentation: [vrshrn_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_n_u32)

## vrshrn_n_u64

`vrshrn_n_u64`

uint32x2_t vrshrn_n_u64 (uint64x2_t a, const int n)
A32: VRSHRN.I64 Dd, Qm, #n
A64: RSHRN Vd.2S, Vn.2D, #n


Instruction Documentation: [vrshrn_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrn_n_u64)

## vrshrq_n_s16

`vrshrq_n_s16`

int16x8_t vrshrq_n_s16 (int16x8_t a, const int n)
A32: VRSHR.S16 Qd, Qm, #n
A64: SRSHR Vd.8H, Vn.8H, #n


Instruction Documentation: [vrshrq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrq_n_s16)

## vrshrq_n_s32

`vrshrq_n_s32`

int32x4_t vrshrq_n_s32 (int32x4_t a, const int n)
A32: VRSHR.S32 Qd, Qm, #n
A64: SRSHR Vd.4S, Vn.4S, #n


Instruction Documentation: [vrshrq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrq_n_s32)

## vrshrq_n_s64

`vrshrq_n_s64`

int64x2_t vrshrq_n_s64 (int64x2_t a, const int n)
A32: VRSHR.S64 Qd, Qm, #n
A64: SRSHR Vd.2D, Vn.2D, #n


Instruction Documentation: [vrshrq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrq_n_s64)

## vrshrq_n_s8

`vrshrq_n_s8`

int8x16_t vrshrq_n_s8 (int8x16_t a, const int n)
A32: VRSHR.S8 Qd, Qm, #n
A64: SRSHR Vd.16B, Vn.16B, #n


Instruction Documentation: [vrshrq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrq_n_s8)

## vrshrq_n_u16

`vrshrq_n_u16`

uint16x8_t vrshrq_n_u16 (uint16x8_t a, const int n)
A32: VRSHR.U16 Qd, Qm, #n
A64: URSHR Vd.8H, Vn.8H, #n


Instruction Documentation: [vrshrq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrq_n_u16)

## vrshrq_n_u32

`vrshrq_n_u32`

uint32x4_t vrshrq_n_u32 (uint32x4_t a, const int n)
A32: VRSHR.U32 Qd, Qm, #n
A64: URSHR Vd.4S, Vn.4S, #n


Instruction Documentation: [vrshrq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrq_n_u32)

## vrshrq_n_u64

`vrshrq_n_u64`

uint64x2_t vrshrq_n_u64 (uint64x2_t a, const int n)
A32: VRSHR.U64 Qd, Qm, #n
A64: URSHR Vd.2D, Vn.2D, #n


Instruction Documentation: [vrshrq_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrq_n_u64)

## vrshrq_n_u8

`vrshrq_n_u8`

uint8x16_t vrshrq_n_u8 (uint8x16_t a, const int n)
A32: VRSHR.U8 Qd, Qm, #n
A64: URSHR Vd.16B, Vn.16B, #n


Instruction Documentation: [vrshrq_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrshrq_n_u8)

## vrsqrte_f32

`vrsqrte_f32`

float32x2_t vrsqrte_f32 (float32x2_t a)
A32: VRSQRTE.F32 Dd, Dm
A64: FRSQRTE Vd.2S, Vn.2S


Instruction Documentation: [vrsqrte_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrte_f32)

## vrsqrte_u32

`vrsqrte_u32`

uint32x2_t vrsqrte_u32 (uint32x2_t a)
A32: VRSQRTE.U32 Dd, Dm
A64: URSQRTE Vd.2S, Vn.2S


Instruction Documentation: [vrsqrte_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrte_u32)

## vrsqrteq_f32

`vrsqrteq_f32`

float32x4_t vrsqrteq_f32 (float32x4_t a)
A32: VRSQRTE.F32 Qd, Qm
A64: FRSQRTE Vd.4S, Vn.4S


Instruction Documentation: [vrsqrteq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrteq_f32)

## vrsqrteq_u32

`vrsqrteq_u32`

uint32x4_t vrsqrteq_u32 (uint32x4_t a)
A32: VRSQRTE.U32 Qd, Qm
A64: URSQRTE Vd.4S, Vn.4S


Instruction Documentation: [vrsqrteq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrteq_u32)

## vrsqrts_f32

`vrsqrts_f32`

float32x2_t vrsqrts_f32 (float32x2_t a, float32x2_t b)
A32: VRSQRTS.F32 Dd, Dn, Dm
A64: FRSQRTS Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vrsqrts_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrts_f32)

## vrsqrtsq_f32

`vrsqrtsq_f32`

float32x4_t vrsqrtsq_f32 (float32x4_t a, float32x4_t b)
A32: VRSQRTS.F32 Qd, Qn, Qm
A64: FRSQRTS Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vrsqrtsq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrtsq_f32)

## vrsra_n_s16

`vrsra_n_s16`

int16x4_t vrsra_n_s16 (int16x4_t a, int16x4_t b, const int n)
A32: VRSRA.S16 Dd, Dm, #n
A64: SRSRA Vd.4H, Vn.4H, #n


Instruction Documentation: [vrsra_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsra_n_s16)

## vrsra_n_s32

`vrsra_n_s32`

int32x2_t vrsra_n_s32 (int32x2_t a, int32x2_t b, const int n)
A32: VRSRA.S32 Dd, Dm, #n
A64: SRSRA Vd.2S, Vn.2S, #n


Instruction Documentation: [vrsra_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsra_n_s32)

## vrsra_n_s64

`vrsra_n_s64`

int64x1_t vrsra_n_s64 (int64x1_t a, int64x1_t b, const int n)
A32: VRSRA.S64 Dd, Dm, #n
A64: SRSRA Dd, Dn, #n


Instruction Documentation: [vrsra_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsra_n_s64)

## vrsra_n_s8

`vrsra_n_s8`

int8x8_t vrsra_n_s8 (int8x8_t a, int8x8_t b, const int n)
A32: VRSRA.S8 Dd, Dm, #n
A64: SRSRA Vd.8B, Vn.8B, #n


Instruction Documentation: [vrsra_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsra_n_s8)

## vrsra_n_u16

`vrsra_n_u16`

uint16x4_t vrsra_n_u16 (uint16x4_t a, uint16x4_t b, const int n)
A32: VRSRA.U16 Dd, Dm, #n
A64: URSRA Vd.4H, Vn.4H, #n


Instruction Documentation: [vrsra_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsra_n_u16)

## vrsra_n_u32

`vrsra_n_u32`

uint32x2_t vrsra_n_u32 (uint32x2_t a, uint32x2_t b, const int n)
A32: VRSRA.U32 Dd, Dm, #n
A64: URSRA Vd.2S, Vn.2S, #n


Instruction Documentation: [vrsra_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsra_n_u32)

## vrsra_n_u64

`vrsra_n_u64`

uint64x1_t vrsra_n_u64 (uint64x1_t a, uint64x1_t b, const int n)
A32: VRSRA.U64 Dd, Dm, #n
A64: URSRA Dd, Dn, #n


Instruction Documentation: [vrsra_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsra_n_u64)

## vrsra_n_u8

`vrsra_n_u8`

uint8x8_t vrsra_n_u8 (uint8x8_t a, uint8x8_t b, const int n)
A32: VRSRA.U8 Dd, Dm, #n
A64: URSRA Vd.8B, Vn.8B, #n


Instruction Documentation: [vrsra_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsra_n_u8)

## vrsraq_n_s16

`vrsraq_n_s16`

int16x8_t vrsraq_n_s16 (int16x8_t a, int16x8_t b, const int n)
A32: VRSRA.S16 Qd, Qm, #n
A64: SRSRA Vd.8H, Vn.8H, #n


Instruction Documentation: [vrsraq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsraq_n_s16)

## vrsraq_n_s32

`vrsraq_n_s32`

int32x4_t vrsraq_n_s32 (int32x4_t a, int32x4_t b, const int n)
A32: VRSRA.S32 Qd, Qm, #n
A64: SRSRA Vd.4S, Vn.4S, #n


Instruction Documentation: [vrsraq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsraq_n_s32)

## vrsraq_n_s64

`vrsraq_n_s64`

int64x2_t vrsraq_n_s64 (int64x2_t a, int64x2_t b, const int n)
A32: VRSRA.S64 Qd, Qm, #n
A64: SRSRA Vd.2D, Vn.2D, #n


Instruction Documentation: [vrsraq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsraq_n_s64)

## vrsraq_n_s8

`vrsraq_n_s8`

int8x16_t vrsraq_n_s8 (int8x16_t a, int8x16_t b, const int n)
A32: VRSRA.S8 Qd, Qm, #n
A64: SRSRA Vd.16B, Vn.16B, #n


Instruction Documentation: [vrsraq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsraq_n_s8)

## vrsraq_n_u16

`vrsraq_n_u16`

uint16x8_t vrsraq_n_u16 (uint16x8_t a, uint16x8_t b, const int n)
A32: VRSRA.U16 Qd, Qm, #n
A64: URSRA Vd.8H, Vn.8H, #n


Instruction Documentation: [vrsraq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsraq_n_u16)

## vrsraq_n_u32

`vrsraq_n_u32`

uint32x4_t vrsraq_n_u32 (uint32x4_t a, uint32x4_t b, const int n)
A32: VRSRA.U32 Qd, Qm, #n
A64: URSRA Vd.4S, Vn.4S, #n


Instruction Documentation: [vrsraq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsraq_n_u32)

## vrsraq_n_u64

`vrsraq_n_u64`

uint64x2_t vrsraq_n_u64 (uint64x2_t a, uint64x2_t b, const int n)
A32: VRSRA.U64 Qd, Qm, #n
A64: URSRA Vd.2D, Vn.2D, #n


Instruction Documentation: [vrsraq_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsraq_n_u64)

## vrsraq_n_u8

`vrsraq_n_u8`

uint8x16_t vrsraq_n_u8 (uint8x16_t a, uint8x16_t b, const int n)
A32: VRSRA.U8 Qd, Qm, #n
A64: URSRA Vd.16B, Vn.16B, #n


Instruction Documentation: [vrsraq_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsraq_n_u8)

## vrsubhn_high_s16

`vrsubhn_high_s16`

int8x16_t vrsubhn_high_s16 (int8x8_t r, int16x8_t a, int16x8_t b)
A32: VRSUBHN.I16 Dd+1, Qn, Qm
A64: RSUBHN2 Vd.16B, Vn.8H, Vm.8H


Instruction Documentation: [vrsubhn_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_high_s16)

## vrsubhn_high_s32

`vrsubhn_high_s32`

int16x8_t vrsubhn_high_s32 (int16x4_t r, int32x4_t a, int32x4_t b)
A32: VRSUBHN.I32 Dd+1, Qn, Qm
A64: RSUBHN2 Vd.8H, Vn.4S, Vm.4S


Instruction Documentation: [vrsubhn_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_high_s32)

## vrsubhn_high_s64

`vrsubhn_high_s64`

int32x4_t vrsubhn_high_s64 (int32x2_t r, int64x2_t a, int64x2_t b)
A32: VRSUBHN.I64 Dd+1, Qn, Qm
A64: RSUBHN2 Vd.4S, Vn.2D, Vm.2D


Instruction Documentation: [vrsubhn_high_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_high_s64)

## vrsubhn_high_u16

`vrsubhn_high_u16`

uint8x16_t vrsubhn_high_u16 (uint8x8_t r, uint16x8_t a, uint16x8_t b)
A32: VRSUBHN.I16 Dd+1, Qn, Qm
A64: RSUBHN2 Vd.16B, Vn.8H, Vm.8H


Instruction Documentation: [vrsubhn_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_high_u16)

## vrsubhn_high_u32

`vrsubhn_high_u32`

uint16x8_t vrsubhn_high_u32 (uint16x4_t r, uint32x4_t a, uint32x4_t b)
A32: VRSUBHN.I32 Dd+1, Qn, Qm
A64: RSUBHN2 Vd.8H, Vn.4S, Vm.4S


Instruction Documentation: [vrsubhn_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_high_u32)

## vrsubhn_high_u64

`vrsubhn_high_u64`

uint32x4_t vrsubhn_high_u64 (uint32x2_t r, uint64x2_t a, uint64x2_t b)
A32: VRSUBHN.I64 Dd+1, Qn, Qm
A64: RSUBHN2 Vd.4S, Vn.2D, Vm.2D


Instruction Documentation: [vrsubhn_high_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_high_u64)

## vrsubhn_s16

`vrsubhn_s16`

int8x8_t vrsubhn_s16 (int16x8_t a, int16x8_t b)
A32: VRSUBHN.I16 Dd, Qn, Qm
A64: RSUBHN Vd.8B, Vn.8H, Vm.8H


Instruction Documentation: [vrsubhn_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_s16)

## vrsubhn_s32

`vrsubhn_s32`

int16x4_t vrsubhn_s32 (int32x4_t a, int32x4_t b)
A32: VRSUBHN.I32 Dd, Qn, Qm
A64: RSUBHN Vd.4H, Vn.4S, Vm.4S


Instruction Documentation: [vrsubhn_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_s32)

## vrsubhn_s64

`vrsubhn_s64`

int32x2_t vrsubhn_s64 (int64x2_t a, int64x2_t b)
A32: VRSUBHN.I64 Dd, Qn, Qm
A64: RSUBHN Vd.2S, Vn.2D, Vm.2D


Instruction Documentation: [vrsubhn_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_s64)

## vrsubhn_u16

`vrsubhn_u16`

uint8x8_t vrsubhn_u16 (uint16x8_t a, uint16x8_t b)
A32: VRSUBHN.I16 Dd, Qn, Qm
A64: RSUBHN Vd.8B, Vn.8H, Vm.8H


Instruction Documentation: [vrsubhn_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_u16)

## vrsubhn_u32

`vrsubhn_u32`

uint16x4_t vrsubhn_u32 (uint32x4_t a, uint32x4_t b)
A32: VRSUBHN.I32 Dd, Qn, Qm
A64: RSUBHN Vd.4H, Vn.4S, Vm.4S


Instruction Documentation: [vrsubhn_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_u32)

## vrsubhn_u64

`vrsubhn_u64`

uint32x2_t vrsubhn_u64 (uint64x2_t a, uint64x2_t b)
A32: VRSUBHN.I64 Dd, Qn, Qm
A64: RSUBHN Vd.2S, Vn.2D, Vm.2D


Instruction Documentation: [vrsubhn_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsubhn_u64)

## vset_lane_f32

`vset_lane_f32`

float32x2_t vset_lane_f32 (float32_t a, float32x2_t v, const int lane)
A32: VMOV.F32 Sd, Sm
A64: INS Vd.S[lane], Vn.S[0]


Instruction Documentation: [vset_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vset_lane_f32)

## vset_lane_s16

`vset_lane_s16`

int16x4_t vset_lane_s16 (int16_t a, int16x4_t v, const int lane)
A32: VMOV.16 Dd[lane], Rt
A64: INS Vd.H[lane], Wn


Instruction Documentation: [vset_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vset_lane_s16)

## vset_lane_s32

`vset_lane_s32`

int32x2_t vset_lane_s32 (int32_t a, int32x2_t v, const int lane)
A32: VMOV.32 Dd[lane], Rt
A64: INS Vd.S[lane], Wn


Instruction Documentation: [vset_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vset_lane_s32)

## vset_lane_s8

`vset_lane_s8`

int8x8_t vset_lane_s8 (int8_t a, int8x8_t v, const int lane)
A32: VMOV.8 Dd[lane], Rt
A64: INS Vd.B[lane], Wn


Instruction Documentation: [vset_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vset_lane_s8)

## vset_lane_u16

`vset_lane_u16`

uint16x4_t vset_lane_u16 (uint16_t a, uint16x4_t v, const int lane)
A32: VMOV.16 Dd[lane], Rt
A64: INS Vd.H[lane], Wn


Instruction Documentation: [vset_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vset_lane_u16)

## vset_lane_u32

`vset_lane_u32`

uint32x2_t vset_lane_u32 (uint32_t a, uint32x2_t v, const int lane)
A32: VMOV.32 Dd[lane], Rt
A64: INS Vd.S[lane], Wn


Instruction Documentation: [vset_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vset_lane_u32)

## vset_lane_u8

`vset_lane_u8`

uint8x8_t vset_lane_u8 (uint8_t a, uint8x8_t v, const int lane)
A32: VMOV.8 Dd[lane], Rt
A64: INS Vd.B[lane], Wn


Instruction Documentation: [vset_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vset_lane_u8)

## vsetq_lane_f32

`vsetq_lane_f32`

float32x4_t vsetq_lane_f32 (float32_t a, float32x4_t v, const int lane)
A32: VMOV.F32 Sd, Sm
A64: INS Vd.S[lane], Vn.S[0]


Instruction Documentation: [vsetq_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_f32)

## vsetq_lane_f64

`vsetq_lane_f64`

float64x2_t vsetq_lane_f64 (float64_t a, float64x2_t v, const int lane)
A32: VMOV.F64 Dd, Dm
A64: INS Vd.D[lane], Vn.D[0]


Instruction Documentation: [vsetq_lane_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_f64)

## vsetq_lane_s16

`vsetq_lane_s16`

int16x8_t vsetq_lane_s16 (int16_t a, int16x8_t v, const int lane)
A32: VMOV.16 Dd[lane], Rt
A64: INS Vd.H[lane], Wn


Instruction Documentation: [vsetq_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_s16)

## vsetq_lane_s32

`vsetq_lane_s32`

int32x4_t vsetq_lane_s32 (int32_t a, int32x4_t v, const int lane)
A32: VMOV.32 Dd[lane], Rt
A64: INS Vd.S[lane], Wn


Instruction Documentation: [vsetq_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_s32)

## vsetq_lane_s64

`vsetq_lane_s64`

int64x2_t vsetq_lane_s64 (int64_t a, int64x2_t v, const int lane)
A32: VMOV.64 Dd, Rt, Rt2
A64: INS Vd.D[lane], Xn


Instruction Documentation: [vsetq_lane_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_s64)

## vsetq_lane_s8

`vsetq_lane_s8`

int8x16_t vsetq_lane_s8 (int8_t a, int8x16_t v, const int lane)
A32: VMOV.8 Dd[lane], Rt
A64: INS Vd.B[lane], Wn


Instruction Documentation: [vsetq_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_s8)

## vsetq_lane_u16

`vsetq_lane_u16`

uint16x8_t vsetq_lane_u16 (uint16_t a, uint16x8_t v, const int lane)
A32: VMOV.16 Dd[lane], Rt
A64: INS Vd.H[lane], Wn


Instruction Documentation: [vsetq_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_u16)

## vsetq_lane_u32

`vsetq_lane_u32`

uint32x4_t vsetq_lane_u32 (uint32_t a, uint32x4_t v, const int lane)
A32: VMOV.32 Dd[lane], Rt
A64: INS Vd.S[lane], Wn


Instruction Documentation: [vsetq_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_u32)

## vsetq_lane_u64

`vsetq_lane_u64`

uint64x2_t vsetq_lane_u64 (uint64_t a, uint64x2_t v, const int lane)
A32: VMOV.64 Dd, Rt, Rt2
A64: INS Vd.D[lane], Xn


Instruction Documentation: [vsetq_lane_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_u64)

## vsetq_lane_u8

`vsetq_lane_u8`

uint8x16_t vsetq_lane_u8 (uint8_t a, uint8x16_t v, const int lane)
A32: VMOV.8 Dd[lane], Rt
A64: INS Vd.B[lane], Wn


Instruction Documentation: [vsetq_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsetq_lane_u8)

## vshl_n_s16

`vshl_n_s16`

int16x4_t vshl_n_s16 (int16x4_t a, const int n)
A32: VSHL.I16 Dd, Dm, #n
A64: SHL Vd.4H, Vn.4H, #n


Instruction Documentation: [vshl_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_n_s16)

## vshl_n_s32

`vshl_n_s32`

int32x2_t vshl_n_s32 (int32x2_t a, const int n)
A32: VSHL.I32 Dd, Dm, #n
A64: SHL Vd.2S, Vn.2S, #n


Instruction Documentation: [vshl_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_n_s32)

## vshl_n_s64

`vshl_n_s64`

int64x1_t vshl_n_s64 (int64x1_t a, const int n)
A32: VSHL.I64 Dd, Dm, #n
A64: SHL Dd, Dn, #n


Instruction Documentation: [vshl_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_n_s64)

## vshl_n_s8

`vshl_n_s8`

int8x8_t vshl_n_s8 (int8x8_t a, const int n)
A32: VSHL.I8 Dd, Dm, #n
A64: SHL Vd.8B, Vn.8B, #n


Instruction Documentation: [vshl_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_n_s8)

## vshl_n_u16

`vshl_n_u16`

uint16x4_t vshl_n_u16 (uint16x4_t a, const int n)
A32: VSHL.I16 Dd, Dm, #n
A64: SHL Vd.4H, Vn.4H, #n


Instruction Documentation: [vshl_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_n_u16)

## vshl_n_u32

`vshl_n_u32`

uint32x2_t vshl_n_u32 (uint32x2_t a, const int n)
A32: VSHL.I32 Dd, Dm, #n
A64: SHL Vd.2S, Vn.2S, #n


Instruction Documentation: [vshl_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_n_u32)

## vshl_n_u64

`vshl_n_u64`

uint64x1_t vshl_n_u64 (uint64x1_t a, const int n)
A32: VSHL.I64 Dd, Dm, #n
A64: SHL Dd, Dn, #n


Instruction Documentation: [vshl_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_n_u64)

## vshl_n_u8

`vshl_n_u8`

uint8x8_t vshl_n_u8 (uint8x8_t a, const int n)
A32: VSHL.I8 Dd, Dm, #n
A64: SHL Vd.8B, Vn.8B, #n


Instruction Documentation: [vshl_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_n_u8)

## vshl_s16

`vshl_s16`

int16x4_t vshl_s16 (int16x4_t a, int16x4_t b)
A32: VSHL.S16 Dd, Dn, Dm
A64: SSHL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vshl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_s16)

## vshl_s32

`vshl_s32`

int32x2_t vshl_s32 (int32x2_t a, int32x2_t b)
A32: VSHL.S32 Dd, Dn, Dm
A64: SSHL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vshl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_s32)

## vshl_s64

`vshl_s64`

int64x1_t vshl_s64 (int64x1_t a, int64x1_t b)
A32: VSHL.S64 Dd, Dn, Dm
A64: SSHL Dd, Dn, Dm


Instruction Documentation: [vshl_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_s64)

## vshl_s8

`vshl_s8`

int8x8_t vshl_s8 (int8x8_t a, int8x8_t b)
A32: VSHL.S8 Dd, Dn, Dm
A64: SSHL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vshl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_s8)

## vshl_u16

`vshl_u16`

uint16x4_t vshl_u16 (uint16x4_t a, int16x4_t b)
A32: VSHL.U16 Dd, Dn, Dm
A64: USHL Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vshl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_u16)

## vshl_u32

`vshl_u32`

uint32x2_t vshl_u32 (uint32x2_t a, int32x2_t b)
A32: VSHL.U32 Dd, Dn, Dm
A64: USHL Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vshl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_u32)

## vshl_u64

`vshl_u64`

uint64x1_t vshl_u64 (uint64x1_t a, int64x1_t b)
A32: VSHL.U64 Dd, Dn, Dm
A64: USHL Dd, Dn, Dm


Instruction Documentation: [vshl_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_u64)

## vshl_u8

`vshl_u8`

uint8x8_t vshl_u8 (uint8x8_t a, int8x8_t b)
A32: VSHL.U8 Dd, Dn, Dm
A64: USHL Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vshl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_u8)

## vshll_high_n_s16

`vshll_high_n_s16`

int32x4_t vshll_high_n_s16 (int16x8_t a, const int n)
A32: VSHLL.S16 Qd, Dm+1, #n
A64: SSHLL2 Vd.4S, Vn.8H, #n


Instruction Documentation: [vshll_high_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_high_n_s16)

## vshll_high_n_s32

`vshll_high_n_s32`

int64x2_t vshll_high_n_s32 (int32x4_t a, const int n)
A32: VSHLL.S32 Qd, Dm+1, #n
A64: SSHLL2 Vd.2D, Vn.4S, #n


Instruction Documentation: [vshll_high_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_high_n_s32)

## vshll_high_n_s8

`vshll_high_n_s8`

int16x8_t vshll_high_n_s8 (int8x16_t a, const int n)
A32: VSHLL.S8 Qd, Dm+1, #n
A64: SSHLL2 Vd.8H, Vn.16B, #n


Instruction Documentation: [vshll_high_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_high_n_s8)

## vshll_high_n_u16

`vshll_high_n_u16`

uint32x4_t vshll_high_n_u16 (uint16x8_t a, const int n)
A32: VSHLL.U16 Qd, Dm+1, #n
A64: USHLL2 Vd.4S, Vn.8H, #n


Instruction Documentation: [vshll_high_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_high_n_u16)

## vshll_high_n_u32

`vshll_high_n_u32`

uint64x2_t vshll_high_n_u32 (uint32x4_t a, const int n)
A32: VSHLL.U32 Qd, Dm+1, #n
A64: USHLL2 Vd.2D, Vn.4S, #n


Instruction Documentation: [vshll_high_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_high_n_u32)

## vshll_high_n_u8

`vshll_high_n_u8`

uint16x8_t vshll_high_n_u8 (uint8x16_t a, const int n)
A32: VSHLL.U8 Qd, Dm+1, #n
A64: USHLL2 Vd.8H, Vn.16B, #n


Instruction Documentation: [vshll_high_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_high_n_u8)

## vshll_n_s16

`vshll_n_s16`

int32x4_t vshll_n_s16 (int16x4_t a, const int n)
A32: VSHLL.S16 Qd, Dm, #n
A64: SSHLL Vd.4S, Vn.4H, #n


Instruction Documentation: [vshll_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_n_s16)

## vshll_n_s32

`vshll_n_s32`

int64x2_t vshll_n_s32 (int32x2_t a, const int n)
A32: VSHLL.S32 Qd, Dm, #n
A64: SSHLL Vd.2D, Vn.2S, #n


Instruction Documentation: [vshll_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_n_s32)

## vshll_n_s8

`vshll_n_s8`

int16x8_t vshll_n_s8 (int8x8_t a, const int n)
A32: VSHLL.S8 Qd, Dm, #n
A64: SSHLL Vd.8H, Vn.8B, #n


Instruction Documentation: [vshll_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_n_s8)

## vshll_n_u16

`vshll_n_u16`

uint32x4_t vshll_n_u16 (uint16x4_t a, const int n)
A32: VSHLL.U16 Qd, Dm, #n
A64: USHLL Vd.4S, Vn.4H, #n


Instruction Documentation: [vshll_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_n_u16)

## vshll_n_u32

`vshll_n_u32`

uint64x2_t vshll_n_u32 (uint32x2_t a, const int n)
A32: VSHLL.U32 Qd, Dm, #n
A64: USHLL Vd.2D, Vn.2S, #n


Instruction Documentation: [vshll_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_n_u32)

## vshll_n_u8

`vshll_n_u8`

uint16x8_t vshll_n_u8 (uint8x8_t a, const int n)
A32: VSHLL.U8 Qd, Dm, #n
A64: USHLL Vd.8H, Vn.8B, #n


Instruction Documentation: [vshll_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshll_n_u8)

## vshlq_n_s16

`vshlq_n_s16`

int16x8_t vshlq_n_s16 (int16x8_t a, const int n)
A32: VSHL.I16 Qd, Qm, #n
A64: SHL Vd.8H, Vn.8H, #n


Instruction Documentation: [vshlq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_n_s16)

## vshlq_n_s64

`vshlq_n_s64`

int64x2_t vshlq_n_s64 (int64x2_t a, const int n)
A32: VSHL.I64 Qd, Qm, #n
A64: SHL Vd.2D, Vn.2D, #n


Instruction Documentation: [vshlq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_n_s64)

## vshlq_n_s8

`vshlq_n_s8`

int8x16_t vshlq_n_s8 (int8x16_t a, const int n)
A32: VSHL.I8 Qd, Qm, #n
A64: SHL Vd.16B, Vn.16B, #n


Instruction Documentation: [vshlq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_n_s8)

## vshlq_n_u16

`vshlq_n_u16`

uint16x8_t vshlq_n_u16 (uint16x8_t a, const int n)
A32: VSHL.I16 Qd, Qm, #n
A64: SHL Vd.8H, Vn.8H, #n


Instruction Documentation: [vshlq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_n_u16)

## vshlq_n_u32

`vshlq_n_u32`

uint32x4_t vshlq_n_u32 (uint32x4_t a, const int n)
A32: VSHL.I32 Qd, Qm, #n
A64: SHL Vd.4S, Vn.4S, #n


Instruction Documentation: [vshlq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_n_u32)

## vshlq_n_u64

`vshlq_n_u64`

uint64x2_t vshlq_n_u64 (uint64x2_t a, const int n)
A32: VSHL.I64 Qd, Qm, #n
A64: SHL Vd.2D, Vn.2D, #n


Instruction Documentation: [vshlq_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_n_u64)

## vshlq_n_u8

`vshlq_n_u8`

uint8x16_t vshlq_n_u8 (uint8x16_t a, const int n)
A32: VSHL.I8 Qd, Qm, #n
A64: SHL Vd.16B, Vn.16B, #n


Instruction Documentation: [vshlq_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_n_u8)

## vshlq_s16

`vshlq_s16`

int16x8_t vshlq_s16 (int16x8_t a, int16x8_t b)
A32: VSHL.S16 Qd, Qn, Qm
A64: SSHL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vshlq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_s16)

## vshlq_s32

`vshlq_s32`

int32x4_t vshlq_s32 (int32x4_t a, int32x4_t b)
A32: VSHL.S32 Qd, Qn, Qm
A64: SSHL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vshlq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_s32)

## vshlq_s64

`vshlq_s64`

int64x2_t vshlq_s64 (int64x2_t a, int64x2_t b)
A32: VSHL.S64 Qd, Qn, Qm
A64: SSHL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vshlq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_s64)

## vshlq_s8

`vshlq_s8`

int8x16_t vshlq_s8 (int8x16_t a, int8x16_t b)
A32: VSHL.S8 Qd, Qn, Qm
A64: SSHL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vshlq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_s8)

## vshlq_u16

`vshlq_u16`

uint16x8_t vshlq_u16 (uint16x8_t a, int16x8_t b)
A32: VSHL.U16 Qd, Qn, Qm
A64: USHL Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vshlq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_u16)

## vshlq_u32

`vshlq_u32`

uint32x4_t vshlq_u32 (uint32x4_t a, int32x4_t b)
A32: VSHL.U32 Qd, Qn, Qm
A64: USHL Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vshlq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_u32)

## vshlq_u64

`vshlq_u64`

uint64x2_t vshlq_u64 (uint64x2_t a, int64x2_t b)
A32: VSHL.U64 Qd, Qn, Qm
A64: USHL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vshlq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_u64)

## vshlq_u8

`vshlq_u8`

uint8x16_t vshlq_u8 (uint8x16_t a, int8x16_t b)
A32: VSHL.U8 Qd, Qn, Qm
A64: USHL Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vshlq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshlq_u8)

## vshr_n_s16

`vshr_n_s16`

int16x4_t vshr_n_s16 (int16x4_t a, const int n)
A32: VSHR.S16 Dd, Dm, #n
A64: SSHR Vd.4H, Vn.4H, #n


Instruction Documentation: [vshr_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshr_n_s16)

## vshr_n_s32

`vshr_n_s32`

int32x2_t vshr_n_s32 (int32x2_t a, const int n)
A32: VSHR.S32 Dd, Dm, #n
A64: SSHR Vd.2S, Vn.2S, #n


Instruction Documentation: [vshr_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshr_n_s32)

## vshr_n_s64

`vshr_n_s64`

int64x1_t vshr_n_s64 (int64x1_t a, const int n)
A32: VSHR.S64 Dd, Dm, #n
A64: SSHR Dd, Dn, #n


Instruction Documentation: [vshr_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshr_n_s64)

## vshr_n_s8

`vshr_n_s8`

int8x8_t vshr_n_s8 (int8x8_t a, const int n)
A32: VSHR.S8 Dd, Dm, #n
A64: SSHR Vd.8B, Vn.8B, #n


Instruction Documentation: [vshr_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshr_n_s8)

## vshr_n_u16

`vshr_n_u16`

uint16x4_t vshr_n_u16 (uint16x4_t a, const int n)
A32: VSHR.U16 Dd, Dm, #n
A64: USHR Vd.4H, Vn.4H, #n


Instruction Documentation: [vshr_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshr_n_u16)

## vshr_n_u32

`vshr_n_u32`

uint32x2_t vshr_n_u32 (uint32x2_t a, const int n)
A32: VSHR.U32 Dd, Dm, #n
A64: USHR Vd.2S, Vn.2S, #n


Instruction Documentation: [vshr_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshr_n_u32)

## vshr_n_u64

`vshr_n_u64`

uint64x1_t vshr_n_u64 (uint64x1_t a, const int n)
A32: VSHR.U64 Dd, Dm, #n
A64: USHR Dd, Dn, #n


Instruction Documentation: [vshr_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshr_n_u64)

## vshr_n_u8

`vshr_n_u8`

uint8x8_t vshr_n_u8 (uint8x8_t a, const int n)
A32: VSHR.U8 Dd, Dm, #n
A64: USHR Vd.8B, Vn.8B, #n


Instruction Documentation: [vshr_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshr_n_u8)

## vshrn_high_n_s16

`vshrn_high_n_s16`

int8x16_t vshrn_high_n_s16 (int8x8_t r, int16x8_t a, const int n)
A32: VSHRN.I16 Dd+1, Qm, #n
A64: SHRN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vshrn_high_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_high_n_s16)

## vshrn_high_n_s32

`vshrn_high_n_s32`

int16x8_t vshrn_high_n_s32 (int16x4_t r, int32x4_t a, const int n)
A32: VSHRN.I32 Dd+1, Qm, #n
A64: SHRN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vshrn_high_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_high_n_s32)

## vshrn_high_n_s64

`vshrn_high_n_s64`

int32x4_t vshrn_high_n_s64 (int32x2_t r, int64x2_t a, const int n)
A32: VSHRN.I64 Dd+1, Qm, #n
A64: SHRN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vshrn_high_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_high_n_s64)

## vshrn_high_n_u16

`vshrn_high_n_u16`

uint8x16_t vshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n)
A32: VSHRN.I16 Dd+1, Qm, #n
A64: SHRN2 Vd.16B, Vn.8H, #n


Instruction Documentation: [vshrn_high_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_high_n_u16)

## vshrn_high_n_u32

`vshrn_high_n_u32`

uint16x8_t vshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n)
A32: VSHRN.I32 Dd+1, Qm, #n
A64: SHRN2 Vd.8H, Vn.4S, #n


Instruction Documentation: [vshrn_high_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_high_n_u32)

## vshrn_high_n_u64

`vshrn_high_n_u64`

uint32x4_t vshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n)
A32: VSHRN.I64 Dd+1, Qm, #n
A64: SHRN2 Vd.4S, Vn.2D, #n


Instruction Documentation: [vshrn_high_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_high_n_u64)

## vshrn_n_s16

`vshrn_n_s16`

int8x8_t vshrn_n_s16 (int16x8_t a, const int n)
A32: VSHRN.I16 Dd, Qm, #n
A64: SHRN Vd.8B, Vn.8H, #n


Instruction Documentation: [vshrn_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_n_s16)

## vshrn_n_s32

`vshrn_n_s32`

int16x4_t vshrn_n_s32 (int32x4_t a, const int n)
A32: VSHRN.I32 Dd, Qm, #n
A64: SHRN Vd.4H, Vn.4S, #n


Instruction Documentation: [vshrn_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_n_s32)

## vshrn_n_s64

`vshrn_n_s64`

int32x2_t vshrn_n_s64 (int64x2_t a, const int n)
A32: VSHRN.I64 Dd, Qm, #n
A64: SHRN Vd.2S, Vn.2D, #n


Instruction Documentation: [vshrn_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_n_s64)

## vshrn_n_u16

`vshrn_n_u16`

uint8x8_t vshrn_n_u16 (uint16x8_t a, const int n)
A32: VSHRN.I16 Dd, Qm, #n
A64: SHRN Vd.8B, Vn.8H, #n


Instruction Documentation: [vshrn_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_n_u16)

## vshrn_n_u32

`vshrn_n_u32`

uint16x4_t vshrn_n_u32 (uint32x4_t a, const int n)
A32: VSHRN.I32 Dd, Qm, #n
A64: SHRN Vd.4H, Vn.4S, #n


Instruction Documentation: [vshrn_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_n_u32)

## vshrn_n_u64

`vshrn_n_u64`

uint32x2_t vshrn_n_u64 (uint64x2_t a, const int n)
A32: VSHRN.I64 Dd, Qm, #n
A64: SHRN Vd.2S, Vn.2D, #n


Instruction Documentation: [vshrn_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrn_n_u64)

## vshrq_n_s16

`vshrq_n_s16`

int16x8_t vshrq_n_s16 (int16x8_t a, const int n)
A32: VSHR.S16 Qd, Qm, #n
A64: SSHR Vd.8H, Vn.8H, #n


Instruction Documentation: [vshrq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrq_n_s16)

## vshrq_n_s32

`vshrq_n_s32`

int32x4_t vshrq_n_s32 (int32x4_t a, const int n)
A32: VSHR.S32 Qd, Qm, #n
A64: SSHR Vd.4S, Vn.4S, #n


Instruction Documentation: [vshrq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrq_n_s32)

## vshrq_n_s64

`vshrq_n_s64`

int64x2_t vshrq_n_s64 (int64x2_t a, const int n)
A32: VSHR.S64 Qd, Qm, #n
A64: SSHR Vd.2D, Vn.2D, #n


Instruction Documentation: [vshrq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrq_n_s64)

## vshrq_n_s8

`vshrq_n_s8`

int8x16_t vshrq_n_s8 (int8x16_t a, const int n)
A32: VSHR.S8 Qd, Qm, #n
A64: SSHR Vd.16B, Vn.16B, #n


Instruction Documentation: [vshrq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrq_n_s8)

## vshrq_n_u16

`vshrq_n_u16`

uint16x8_t vshrq_n_u16 (uint16x8_t a, const int n)
A32: VSHR.U16 Qd, Qm, #n
A64: USHR Vd.8H, Vn.8H, #n


Instruction Documentation: [vshrq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrq_n_u16)

## vshrq_n_u32

`vshrq_n_u32`

uint32x4_t vshrq_n_u32 (uint32x4_t a, const int n)
A32: VSHR.U32 Qd, Qm, #n
A64: USHR Vd.4S, Vn.4S, #n


Instruction Documentation: [vshrq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrq_n_u32)

## vshrq_n_u64

`vshrq_n_u64`

uint64x2_t vshrq_n_u64 (uint64x2_t a, const int n)
A32: VSHR.U64 Qd, Qm, #n
A64: USHR Vd.2D, Vn.2D, #n


Instruction Documentation: [vshrq_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrq_n_u64)

## vshrq_n_u8

`vshrq_n_u8`

uint8x16_t vshrq_n_u8 (uint8x16_t a, const int n)
A32: VSHR.U8 Qd, Qm, #n
A64: USHR Vd.16B, Vn.16B, #n


Instruction Documentation: [vshrq_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vshrq_n_u8)

## vsqrt_f64

`vsqrt_f64`

float64x1_t vsqrt_f64 (float64x1_t a)
A32: VSQRT.F64 Dd, Dm
A64: FSQRT Dd, Dn


Instruction Documentation: [vsqrt_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqrt_f64)

## vsqrts_f32

`vsqrts_f32`

float32_t vsqrts_f32 (float32_t a)
A32: VSQRT.F32 Sd, Sm
A64: FSQRT Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vsqrts_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqrts_f32)

## vsra_n_s16

`vsra_n_s16`

int16x4_t vsra_n_s16 (int16x4_t a, int16x4_t b, const int n)
A32: VSRA.S16 Dd, Dm, #n
A64: SSRA Vd.4H, Vn.4H, #n


Instruction Documentation: [vsra_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsra_n_s16)

## vsra_n_s32

`vsra_n_s32`

int32x2_t vsra_n_s32 (int32x2_t a, int32x2_t b, const int n)
A32: VSRA.S32 Dd, Dm, #n
A64: SSRA Vd.2S, Vn.2S, #n


Instruction Documentation: [vsra_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsra_n_s32)

## vsra_n_s64

`vsra_n_s64`

int64x1_t vsra_n_s64 (int64x1_t a, int64x1_t b, const int n)
A32: VSRA.S64 Dd, Dm, #n
A64: SSRA Dd, Dn, #n


Instruction Documentation: [vsra_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsra_n_s64)

## vsra_n_s8

`vsra_n_s8`

int8x8_t vsra_n_s8 (int8x8_t a, int8x8_t b, const int n)
A32: VSRA.S8 Dd, Dm, #n
A64: SSRA Vd.8B, Vn.8B, #n


Instruction Documentation: [vsra_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsra_n_s8)

## vsra_n_u16

`vsra_n_u16`

uint16x4_t vsra_n_u16 (uint16x4_t a, uint16x4_t b, const int n)
A32: VSRA.U16 Dd, Dm, #n
A64: USRA Vd.4H, Vn.4H, #n


Instruction Documentation: [vsra_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsra_n_u16)

## vsra_n_u32

`vsra_n_u32`

uint32x2_t vsra_n_u32 (uint32x2_t a, uint32x2_t b, const int n)
A32: VSRA.U32 Dd, Dm, #n
A64: USRA Vd.2S, Vn.2S, #n


Instruction Documentation: [vsra_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsra_n_u32)

## vsra_n_u64

`vsra_n_u64`

uint64x1_t vsra_n_u64 (uint64x1_t a, uint64x1_t b, const int n)
A32: VSRA.U64 Dd, Dm, #n
A64: USRA Dd, Dn, #n


Instruction Documentation: [vsra_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsra_n_u64)

## vsra_n_u8

`vsra_n_u8`

uint8x8_t vsra_n_u8 (uint8x8_t a, uint8x8_t b, const int n)
A32: VSRA.U8 Dd, Dm, #n
A64: USRA Vd.8B, Vn.8B, #n


Instruction Documentation: [vsra_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsra_n_u8)

## vsraq_n_s16

`vsraq_n_s16`

int16x8_t vsraq_n_s16 (int16x8_t a, int16x8_t b, const int n)
A32: VSRA.S16 Qd, Qm, #n
A64: SSRA Vd.8H, Vn.8H, #n


Instruction Documentation: [vsraq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsraq_n_s16)

## vsraq_n_s32

`vsraq_n_s32`

int32x4_t vsraq_n_s32 (int32x4_t a, int32x4_t b, const int n)
A32: VSRA.S32 Qd, Qm, #n
A64: SSRA Vd.4S, Vn.4S, #n


Instruction Documentation: [vsraq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsraq_n_s32)

## vsraq_n_s64

`vsraq_n_s64`

int64x2_t vsraq_n_s64 (int64x2_t a, int64x2_t b, const int n)
A32: VSRA.S64 Qd, Qm, #n
A64: SSRA Vd.2D, Vn.2D, #n


Instruction Documentation: [vsraq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsraq_n_s64)

## vsraq_n_s8

`vsraq_n_s8`

int8x16_t vsraq_n_s8 (int8x16_t a, int8x16_t b, const int n)
A32: VSRA.S8 Qd, Qm, #n
A64: SSRA Vd.16B, Vn.16B, #n


Instruction Documentation: [vsraq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsraq_n_s8)

## vsraq_n_u16

`vsraq_n_u16`

uint16x8_t vsraq_n_u16 (uint16x8_t a, uint16x8_t b, const int n)
A32: VSRA.U16 Qd, Qm, #n
A64: USRA Vd.8H, Vn.8H, #n


Instruction Documentation: [vsraq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsraq_n_u16)

## vsraq_n_u32

`vsraq_n_u32`

uint32x4_t vsraq_n_u32 (uint32x4_t a, uint32x4_t b, const int n)
A32: VSRA.U32 Qd, Qm, #n
A64: USRA Vd.4S, Vn.4S, #n


Instruction Documentation: [vsraq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsraq_n_u32)

## vsraq_n_u64

`vsraq_n_u64`

uint64x2_t vsraq_n_u64 (uint64x2_t a, uint64x2_t b, const int n)
A32: VSRA.U64 Qd, Qm, #n
A64: USRA Vd.2D, Vn.2D, #n


Instruction Documentation: [vsraq_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsraq_n_u64)

## vsraq_n_u8

`vsraq_n_u8`

uint8x16_t vsraq_n_u8 (uint8x16_t a, uint8x16_t b, const int n)
A32: VSRA.U8 Qd, Qm, #n
A64: USRA Vd.16B, Vn.16B, #n


Instruction Documentation: [vsraq_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsraq_n_u8)

## vsri_n_s16

`vsri_n_s16`

int16x4_t vsri_n_s16(int16x4_t a, int16x4_t b, __builtin_constant_p(n))
A32: VSRI.16 Dd, Dm, #n
A64: SRI Vd.4H, Vn.4H, #n


Instruction Documentation: [vsri_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsri_n_s16)

## vsri_n_s32

`vsri_n_s32`

int32x2_t vsri_n_s32(int32x2_t a, int32x2_t b, __builtin_constant_p(n))
A32: VSRI.32 Dd, Dm, #n
A64: SRI Vd.2S, Vn.2S, #n


Instruction Documentation: [vsri_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsri_n_s32)

## vsri_n_s8

`vsri_n_s8`

int8x8_t vsri_n_s8(int8x8_t a, int8x8_t b, __builtin_constant_p(n))
A32: VSRI.8 Dd, Dm, #n
A64: SRI Vd.8B, Vn.8B, #n


Instruction Documentation: [vsri_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsri_n_s8)

## vsri_n_u16

`vsri_n_u16`

uint16x4_t vsri_n_u16(uint16x4_t a, uint16x4_t b, __builtin_constant_p(n))
A32: VSRI.16 Dd, Dm, #n
A64: SRI Vd.4H, Vn.4H, #n


Instruction Documentation: [vsri_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsri_n_u16)

## vsri_n_u32

`vsri_n_u32`

uint32x2_t vsri_n_u32(uint32x2_t a, uint32x2_t b, __builtin_constant_p(n))
A32: VSRI.32 Dd, Dm, #n
A64: SRI Vd.2S, Vn.2S, #n


Instruction Documentation: [vsri_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsri_n_u32)

## vsri_n_u8

`vsri_n_u8`

uint8x8_t vsri_n_u8(uint8x8_t a, uint8x8_t b, __builtin_constant_p(n))
A32: VSRI.8 Dd, Dm, #n
A64: SRI Vd.8B, Vn.8B, #n


Instruction Documentation: [vsri_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsri_n_u8)

## vsriq_n_s16

`vsriq_n_s16`

int16x8_t vsriq_n_s16(int16x8_t a, int16x8_t b, __builtin_constant_p(n))
A32: VSRI.16 Qd, Qm, #n
A64: SRI Vd.8H, Vn.8H, #n


Instruction Documentation: [vsriq_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsriq_n_s16)

## vsriq_n_s32

`vsriq_n_s32`

int32x4_t vsriq_n_s32(int32x4_t a, int32x4_t b, __builtin_constant_p(n))
A32: VSRI.32 Qd, Qm, #n
A64: SRI Vd.4S, Vn.4S, #n


Instruction Documentation: [vsriq_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsriq_n_s32)

## vsriq_n_s64

`vsriq_n_s64`

int64x2_t vsriq_n_s64(int64x2_t a, int64x2_t b, __builtin_constant_p(n))
A32: VSRI.64 Qd, Qm, #n
A64: SRI Vd.2D, Vn.2D, #n


Instruction Documentation: [vsriq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsriq_n_s64)

## vsriq_n_s8

`vsriq_n_s8`

int8x16_t vsriq_n_s8(int8x16_t a, int8x16_t b, __builtin_constant_p(n))
A32: VSRI.8 Qd, Qm, #n
A64: SRI Vd.16B, Vn.16B, #n


Instruction Documentation: [vsriq_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsriq_n_s8)

## vsriq_n_u16

`vsriq_n_u16`

uint16x8_t vsriq_n_u16(uint16x8_t a, uint16x8_t b, __builtin_constant_p(n))
A32: VSRI.16 Qd, Qm, #n
A64: SRI Vd.8H, Vn.8H, #n


Instruction Documentation: [vsriq_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsriq_n_u16)

## vsriq_n_u32

`vsriq_n_u32`

uint32x4_t vsriq_n_u32(uint32x4_t a, uint32x4_t b, __builtin_constant_p(n))
A32: VSRI.32 Qd, Qm, #n
A64: SRI Vd.4S, Vn.4S, #n


Instruction Documentation: [vsriq_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsriq_n_u32)

## vsriq_n_u64

`vsriq_n_u64`

uint64x2_t vsriq_n_u64(uint64x2_t a, uint64x2_t b, __builtin_constant_p(n))
A32: VSRI.64 Qd, Qm, #n
A64: SRI Vd.2D, Vn.2D, #n


Instruction Documentation: [vsriq_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsriq_n_u64)

## vsriq_n_u8

`vsriq_n_u8`

uint8x16_t vsriq_n_u8(uint8x16_t a, uint8x16_t b, __builtin_constant_p(n))
A32: VSRI.8 Qd, Qm, #n
A64: SRI Vd.16B, Vn.16B, #n


Instruction Documentation: [vsriq_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsriq_n_u8)

## vst1_f32

`vst1_f32`

void vst1_f32 (float32_t * ptr, float32x2_t val)
A32: VST1.32 { Dd }, [Rn]
A64: ST1 { Vt.2S }, [Xn]


Instruction Documentation: [vst1_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_f32)

## vst1_f64

`vst1_f64`

void vst1_f64 (float64_t * ptr, float64x1_t val)
A32: VST1.64 { Dd }, [Rn]
A64: ST1 { Vt.1D }, [Xn]


Instruction Documentation: [vst1_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_f64)

## vst1_lane_f32

`vst1_lane_f32`

void vst1_lane_f32 (float32_t * ptr, float32x2_t val, const int lane)
A32: VST1.32 { Dd[index] }, [Rn]
A64: ST1 { Vt.S }[index], [Xn]


Instruction Documentation: [vst1_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_lane_f32)

## vst1_lane_s16

`vst1_lane_s16`

void vst1_lane_s16 (int16_t * ptr, int16x4_t val, const int lane)
A32: VST1.16 { Dd[index] }, [Rn]
A64: ST1 { Vt.H }[index], [Xn]


Instruction Documentation: [vst1_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_lane_s16)

## vst1_lane_s32

`vst1_lane_s32`

void vst1_lane_s32 (int32_t * ptr, int32x2_t val, const int lane)
A32: VST1.32 { Dd[index] }, [Rn]
A64: ST1 { Vt.S }[index], [Xn]


Instruction Documentation: [vst1_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_lane_s32)

## vst1_lane_s8

`vst1_lane_s8`

void vst1_lane_s8 (int8_t * ptr, int8x8_t val, const int lane)
A32: VST1.8 { Dd[index] }, [Rn]
A64: ST1 { Vt.B }[index], [Xn]


Instruction Documentation: [vst1_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_lane_s8)

## vst1_lane_u16

`vst1_lane_u16`

void vst1_lane_u16 (uint16_t * ptr, uint16x4_t val, const int lane)
A32: VST1.16 { Dd[index] }, [Rn]
A64: ST1 { Vt.H }[index], [Xn]


Instruction Documentation: [vst1_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_lane_u16)

## vst1_lane_u32

`vst1_lane_u32`

void vst1_lane_u32 (uint32_t * ptr, uint32x2_t val, const int lane)
A32: VST1.32 { Dd[index] }, [Rn]
A64: ST1 { Vt.S }[index], [Xn]


Instruction Documentation: [vst1_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_lane_u32)

## vst1_lane_u8

`vst1_lane_u8`

void vst1_lane_u8 (uint8_t * ptr, uint8x8_t val, const int lane)
A32: VST1.8 { Dd[index] }, [Rn]
A64: ST1 { Vt.B }[index], [Xn]


Instruction Documentation: [vst1_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_lane_u8)

## vst1_s16

`vst1_s16`

void vst1_s16 (int16_t * ptr, int16x4_t val)
A32: VST1.16 { Dd }, [Rn]
A64: ST1 {Vt.4H }, [Xn]


Instruction Documentation: [vst1_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_s16)

## vst1_s32

`vst1_s32`

void vst1_s32 (int32_t * ptr, int32x2_t val)
A32: VST1.32 { Dd }, [Rn]
A64: ST1 { Vt.2S }, [Xn]


Instruction Documentation: [vst1_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_s32)

## vst1_s64

`vst1_s64`

void vst1_s64 (int64_t * ptr, int64x1_t val)
A32: VST1.64 { Dd }, [Rn]
A64: ST1 { Vt.1D }, [Xn]


Instruction Documentation: [vst1_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_s64)

## vst1_s8

`vst1_s8`

void vst1_s8 (int8_t * ptr, int8x8_t val)
A32: VST1.8 { Dd }, [Rn]
A64: ST1 { Vt.8B }, [Xn]


Instruction Documentation: [vst1_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_s8)

## vst1_u16

`vst1_u16`

void vst1_u16 (uint16_t * ptr, uint16x4_t val)
A32: VST1.16 { Dd }, [Rn]
A64: ST1 { Vt.4H }, [Xn]


Instruction Documentation: [vst1_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_u16)

## vst1_u32

`vst1_u32`

void vst1_u32 (uint32_t * ptr, uint32x2_t val)
A32: VST1.32 { Dd }, [Rn]
A64: ST1 { Vt.2S }, [Xn]


Instruction Documentation: [vst1_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_u32)

## vst1_u64

`vst1_u64`

void vst1_u64 (uint64_t * ptr, uint64x1_t val)
A32: VST1.64 { Dd }, [Rn]
A64: ST1 { Vt.1D }, [Xn]


Instruction Documentation: [vst1_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_u64)

## vst1_u8

`vst1_u8`

void vst1_u8 (uint8_t * ptr, uint8x8_t val)
A32: VST1.8 { Dd }, [Rn]
A64: ST1 { Vt.8B }, [Xn]


Instruction Documentation: [vst1_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1_u8)

## vst1q_f32

`vst1q_f32`

void vst1q_f32 (float32_t * ptr, float32x4_t val)
A32: VST1.32 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.4S }, [Xn]


Instruction Documentation: [vst1q_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_f32)

## vst1q_f64

`vst1q_f64`

void vst1q_f64 (float64_t * ptr, float64x2_t val)
A32: VST1.64 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.2D }, [Xn]


Instruction Documentation: [vst1q_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_f64)

## vst1q_lane_f32

`vst1q_lane_f32`

void vst1q_lane_f32 (float32_t * ptr, float32x4_t val, const int lane)
A32: VST1.32 { Dd[index] }, [Rn]
A64: ST1 { Vt.S }[index], [Xn]


Instruction Documentation: [vst1q_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_f32)

## vst1q_lane_f64

`vst1q_lane_f64`

void vst1q_lane_f64 (float64_t * ptr, float64x2_t val, const int lane)
A32: VSTR.64 Dd, [Rn]
A64: ST1 { Vt.D }[index], [Xn]


Instruction Documentation: [vst1q_lane_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_f64)

## vst1q_lane_s16

`vst1q_lane_s16`

void vst1q_lane_s16 (int16_t * ptr, int16x8_t val, const int lane)
A32: VST1.16 { Dd[index] }, [Rn]
A64: ST1 { Vt.H }[index], [Xn]


Instruction Documentation: [vst1q_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_s16)

## vst1q_lane_s32

`vst1q_lane_s32`

void vst1q_lane_s32 (int32_t * ptr, int32x4_t val, const int lane)
A32: VST1.32 { Dd[index] }, [Rn]
A64: ST1 { Vt.S }[index], [Xn]


Instruction Documentation: [vst1q_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_s32)

## vst1q_lane_s64

`vst1q_lane_s64`

void vst1q_lane_s64 (int64_t * ptr, int64x2_t val, const int lane)
A32: VSTR.64 Dd, [Rn]
A64: ST1 { Vt.D }[index], [Xn]


Instruction Documentation: [vst1q_lane_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_s64)

## vst1q_lane_s8

`vst1q_lane_s8`

void vst1q_lane_s8 (int8_t * ptr, int8x16_t val, const int lane)
A32: VST1.8 { Dd[index] }, [Rn]
A64: ST1 { Vt.B }[index], [Xn]


Instruction Documentation: [vst1q_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_s8)

## vst1q_lane_u16

`vst1q_lane_u16`

void vst1q_lane_u16 (uint16_t * ptr, uint16x8_t val, const int lane)
A32: VST1.16 { Dd[index] }, [Rn]
A64: ST1 { Vt.H }[index], [Xn]


Instruction Documentation: [vst1q_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_u16)

## vst1q_lane_u32

`vst1q_lane_u32`

void vst1q_lane_u32 (uint32_t * ptr, uint32x4_t val, const int lane)
A32: VST1.32 { Dd[index] }, [Rn]
A64: ST1 { Vt.S }[index], [Xn]


Instruction Documentation: [vst1q_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_u32)

## vst1q_lane_u64

`vst1q_lane_u64`

void vst1q_lane_u64 (uint64_t * ptr, uint64x2_t val, const int lane)
A32: VSTR.64 Dd, [Rn]
A64: ST1 { Vt.D }[index], [Xn]


Instruction Documentation: [vst1q_lane_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_u64)

## vst1q_lane_u8

`vst1q_lane_u8`

void vst1q_lane_u8 (uint8_t * ptr, uint8x16_t val, const int lane)
A32: VST1.8 { Dd[index] }, [Rn]
A64: ST1 { Vt.B }[index], [Xn]


Instruction Documentation: [vst1q_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_lane_u8)

## vst1q_s16

`vst1q_s16`

void vst1q_s16 (int16_t * ptr, int16x8_t val)
A32: VST1.16 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.8H }, [Xn]


Instruction Documentation: [vst1q_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_s16)

## vst1q_s32

`vst1q_s32`

void vst1q_s32 (int32_t * ptr, int32x4_t val)
A32: VST1.32 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.4S }, [Xn]


Instruction Documentation: [vst1q_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_s32)

## vst1q_s64

`vst1q_s64`

void vst1q_s64 (int64_t * ptr, int64x2_t val)
A32: VST1.64 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.2D }, [Xn]


Instruction Documentation: [vst1q_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_s64)

## vst1q_s8

`vst1q_s8`

void vst1q_s8 (int8_t * ptr, int8x16_t val)
A32: VST1.8 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.16B }, [Xn]


Instruction Documentation: [vst1q_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_s8)

## vst1q_u16

`vst1q_u16`

void vst1q_u16 (uint16_t * ptr, uint16x8_t val)
A32: VST1.16 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.8H }, [Xn]


Instruction Documentation: [vst1q_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_u16)

## vst1q_u32

`vst1q_u32`

void vst1q_u32 (uint32_t * ptr, uint32x4_t val)
A32: VST1.32 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.4S }, [Xn]


Instruction Documentation: [vst1q_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_u32)

## vst1q_u64

`vst1q_u64`

void vst1q_u64 (uint64_t * ptr, uint64x2_t val)
A32: VST1.64 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.2D }, [Xn]


Instruction Documentation: [vst1q_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_u64)

## vst1q_u8

`vst1q_u8`

void vst1q_u8 (uint8_t * ptr, uint8x16_t val)
A32: VST1.8 { Dd, Dd+1 }, [Rn]
A64: ST1 { Vt.16B }, [Xn]


Instruction Documentation: [vst1q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vst1q_u8)

## vsub_f32

`vsub_f32`

float32x2_t vsub_f32 (float32x2_t a, float32x2_t b)
A32: VSUB.F32 Dd, Dn, Dm
A64: FSUB Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vsub_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_f32)

## vsub_f64

`vsub_f64`

float64x1_t vsub_f64 (float64x1_t a, float64x1_t b)
A32: VSUB.F64 Dd, Dn, Dm
A64: FSUB Dd, Dn, Dm


Instruction Documentation: [vsub_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_f64)

## vsub_s16

`vsub_s16`

int16x4_t vsub_s16 (int16x4_t a, int16x4_t b)
A32: VSUB.I16 Dd, Dn, Dm
A64: SUB Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vsub_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_s16)

## vsub_s32

`vsub_s32`

int32x2_t vsub_s32 (int32x2_t a, int32x2_t b)
A32: VSUB.I32 Dd, Dn, Dm
A64: SUB Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vsub_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_s32)

## vsub_s64

`vsub_s64`

int64x1_t vsub_s64 (int64x1_t a, int64x1_t b)
A32: VSUB.I64 Dd, Dn, Dm
A64: SUB Dd, Dn, Dm


Instruction Documentation: [vsub_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_s64)

## vsub_s8

`vsub_s8`

int8x8_t vsub_s8 (int8x8_t a, int8x8_t b)
A32: VSUB.I8 Dd, Dn, Dm
A64: SUB Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vsub_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_s8)

## vsub_u16

`vsub_u16`

uint16x4_t vsub_u16 (uint16x4_t a, uint16x4_t b)
A32: VSUB.I16 Dd, Dn, Dm
A64: SUB Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vsub_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_u16)

## vsub_u32

`vsub_u32`

uint32x2_t vsub_u32 (uint32x2_t a, uint32x2_t b)
A32: VSUB.I32 Dd, Dn, Dm
A64: SUB Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vsub_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_u32)

## vsub_u64

`vsub_u64`

uint64x1_t vsub_u64 (uint64x1_t a, uint64x1_t b)
A32: VSUB.I64 Dd, Dn, Dm
A64: SUB Dd, Dn, Dm


Instruction Documentation: [vsub_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_u64)

## vsub_u8

`vsub_u8`

uint8x8_t vsub_u8 (uint8x8_t a, uint8x8_t b)
A32: VSUB.I8 Dd, Dn, Dm
A64: SUB Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vsub_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsub_u8)

## vsubhn_high_s16

`vsubhn_high_s16`

int8x16_t vsubhn_high_s16 (int8x8_t r, int16x8_t a, int16x8_t b)
A32: VSUBHN.I16 Dd+1, Qn, Qm
A64: SUBHN2 Vd.16B, Vn.8H, Vm.8H


Instruction Documentation: [vsubhn_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_high_s16)

## vsubhn_high_s32

`vsubhn_high_s32`

int16x8_t vsubhn_high_s32 (int16x4_t r, int32x4_t a, int32x4_t b)
A32: VSUBHN.I32 Dd+1, Qn, Qm
A64: SUBHN2 Vd.8H, Vn.4S, Vm.4S


Instruction Documentation: [vsubhn_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_high_s32)

## vsubhn_high_s64

`vsubhn_high_s64`

int32x4_t vsubhn_high_s64 (int32x2_t r, int64x2_t a, int64x2_t b)
A32: VSUBHN.I64 Dd+1, Qn, Qm
A64: SUBHN2 Vd.4S, Vn.2D, Vm.2D


Instruction Documentation: [vsubhn_high_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_high_s64)

## vsubhn_high_u16

`vsubhn_high_u16`

uint8x16_t vsubhn_high_u16 (uint8x8_t r, uint16x8_t a, uint16x8_t b)
A32: VSUBHN.I16 Dd+1, Qn, Qm
A64: SUBHN2 Vd.16B, Vn.8H, Vm.8H


Instruction Documentation: [vsubhn_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_high_u16)

## vsubhn_high_u32

`vsubhn_high_u32`

uint16x8_t vsubhn_high_u32 (uint16x4_t r, uint32x4_t a, uint32x4_t b)
A32: VSUBHN.I32 Dd+1, Qn, Qm
A64: SUBHN2 Vd.8H, Vn.4S, Vm.4S


Instruction Documentation: [vsubhn_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_high_u32)

## vsubhn_high_u64

`vsubhn_high_u64`

uint32x4_t vsubhn_high_u64 (uint32x2_t r, uint64x2_t a, uint64x2_t b)
A32: VSUBHN.I64 Dd+1, Qn, Qm
A64: SUBHN2 Vd.4S, Vn.2D, Vm.2D


Instruction Documentation: [vsubhn_high_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_high_u64)

## vsubhn_s16

`vsubhn_s16`

int8x8_t vsubhn_s16 (int16x8_t a, int16x8_t b)
A32: VSUBHN.I16 Dd, Qn, Qm
A64: SUBHN Vd.8B, Vn.8H, Vm.8H


Instruction Documentation: [vsubhn_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_s16)

## vsubhn_s32

`vsubhn_s32`

int16x4_t vsubhn_s32 (int32x4_t a, int32x4_t b)
A32: VSUBHN.I32 Dd, Qn, Qm
A64: SUBHN Vd.4H, Vn.4S, Vm.4S


Instruction Documentation: [vsubhn_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_s32)

## vsubhn_s64

`vsubhn_s64`

int32x2_t vsubhn_s64 (int64x2_t a, int64x2_t b)
A32: VSUBHN.I64 Dd, Qn, Qm
A64: SUBHN Vd.2S, Vn.2D, Vm.2D


Instruction Documentation: [vsubhn_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_s64)

## vsubhn_u16

`vsubhn_u16`

uint8x8_t vsubhn_u16 (uint16x8_t a, uint16x8_t b)
A32: VSUBHN.I16 Dd, Qn, Qm
A64: SUBHN Vd.8B, Vn.8H, Vm.8H


Instruction Documentation: [vsubhn_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_u16)

## vsubhn_u32

`vsubhn_u32`

uint16x4_t vsubhn_u32 (uint32x4_t a, uint32x4_t b)
A32: VSUBHN.I32 Dd, Qn, Qm
A64: SUBHN Vd.4H, Vn.4S, Vm.4S


Instruction Documentation: [vsubhn_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_u32)

## vsubhn_u64

`vsubhn_u64`

uint32x2_t vsubhn_u64 (uint64x2_t a, uint64x2_t b)
A32: VSUBHN.I64 Dd, Qn, Qm
A64: SUBHN Vd.2S, Vn.2D, Vm.2D


Instruction Documentation: [vsubhn_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubhn_u64)

## vsubl_high_s16

`vsubl_high_s16`

int32x4_t vsubl_high_s16 (int16x8_t a, int16x8_t b)
A32: VSUBL.S16 Qd, Dn+1, Dm+1
A64: SSUBL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vsubl_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_high_s16)

## vsubl_high_s32

`vsubl_high_s32`

int64x2_t vsubl_high_s32 (int32x4_t a, int32x4_t b)
A32: VSUBL.S32 Qd, Dn+1, Dm+1
A64: SSUBL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vsubl_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_high_s32)

## vsubl_high_s8

`vsubl_high_s8`

int16x8_t vsubl_high_s8 (int8x16_t a, int8x16_t b)
A32: VSUBL.S8 Qd, Dn+1, Dm+1
A64: SSUBL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vsubl_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_high_s8)

## vsubl_high_u16

`vsubl_high_u16`

uint32x4_t vsubl_high_u16 (uint16x8_t a, uint16x8_t b)
A32: VSUBL.U16 Qd, Dn+1, Dm+1
A64: USUBL2 Vd.4S, Vn.8H, Vm.8H


Instruction Documentation: [vsubl_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_high_u16)

## vsubl_high_u32

`vsubl_high_u32`

uint64x2_t vsubl_high_u32 (uint32x4_t a, uint32x4_t b)
A32: VSUBL.U32 Qd, Dn+1, Dm+1
A64: USUBL2 Vd.2D, Vn.4S, Vm.4S


Instruction Documentation: [vsubl_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_high_u32)

## vsubl_high_u8

`vsubl_high_u8`

uint16x8_t vsubl_high_u8 (uint8x16_t a, uint8x16_t b)
A32: VSUBL.U8 Qd, Dn+1, Dm+1
A64: USUBL2 Vd.8H, Vn.16B, Vm.16B


Instruction Documentation: [vsubl_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_high_u8)

## vsubl_s16

`vsubl_s16`

int32x4_t vsubl_s16 (int16x4_t a, int16x4_t b)
A32: VSUBL.S16 Qd, Dn, Dm
A64: SSUBL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vsubl_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_s16)

## vsubl_s32

`vsubl_s32`

int64x2_t vsubl_s32 (int32x2_t a, int32x2_t b)
A32: VSUBL.S32 Qd, Dn, Dm
A64: SSUBL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vsubl_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_s32)

## vsubl_s8

`vsubl_s8`

int16x8_t vsubl_s8 (int8x8_t a, int8x8_t b)
A32: VSUBL.S8 Qd, Dn, Dm
A64: SSUBL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vsubl_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_s8)

## vsubl_u16

`vsubl_u16`

uint32x4_t vsubl_u16 (uint16x4_t a, uint16x4_t b)
A32: VSUBL.U16 Qd, Dn, Dm
A64: USUBL Vd.4S, Vn.4H, Vm.4H


Instruction Documentation: [vsubl_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_u16)

## vsubl_u32

`vsubl_u32`

uint64x2_t vsubl_u32 (uint32x2_t a, uint32x2_t b)
A32: VSUBL.U32 Qd, Dn, Dm
A64: USUBL Vd.2D, Vn.2S, Vm.2S


Instruction Documentation: [vsubl_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_u32)

## vsubl_u8

`vsubl_u8`

uint16x8_t vsubl_u8 (uint8x8_t a, uint8x8_t b)
A32: VSUBL.U8 Qd, Dn, Dm
A64: USUBL Vd.8H, Vn.8B, Vm.8B


Instruction Documentation: [vsubl_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubl_u8)

## vsubq_f32

`vsubq_f32`

float32x4_t vsubq_f32 (float32x4_t a, float32x4_t b)
A32: VSUB.F32 Qd, Qn, Qm
A64: FSUB Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vsubq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_f32)

## vsubq_s16

`vsubq_s16`

int16x8_t vsubq_s16 (int16x8_t a, int16x8_t b)
A32: VSUB.I16 Qd, Qn, Qm
A64: SUB Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vsubq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_s16)

## vsubq_s32

`vsubq_s32`

int32x4_t vsubq_s32 (int32x4_t a, int32x4_t b)
A32: VSUB.I32 Qd, Qn, Qm
A64: SUB Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vsubq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_s32)

## vsubq_s64

`vsubq_s64`

int64x2_t vsubq_s64 (int64x2_t a, int64x2_t b)
A32: VSUB.I64 Qd, Qn, Qm
A64: SUB Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vsubq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_s64)

## vsubq_s8

`vsubq_s8`

int8x16_t vsubq_s8 (int8x16_t a, int8x16_t b)
A32: VSUB.I8 Qd, Qn, Qm
A64: SUB Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vsubq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_s8)

## vsubq_u16

`vsubq_u16`

uint16x8_t vsubq_u16 (uint16x8_t a, uint16x8_t b)
A32: VSUB.I16 Qd, Qn, Qm
A64: SUB Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vsubq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_u16)

## vsubq_u32

`vsubq_u32`

uint32x4_t vsubq_u32 (uint32x4_t a, uint32x4_t b)
A32: VSUB.I32 Qd, Qn, Qm
A64: SUB Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vsubq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_u32)

## vsubq_u64

`vsubq_u64`

uint64x2_t vsubq_u64 (uint64x2_t a, uint64x2_t b)
A32: VSUB.I64 Qd, Qn, Qm
A64: SUB Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vsubq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_u64)

## vsubq_u8

`vsubq_u8`

uint8x16_t vsubq_u8 (uint8x16_t a, uint8x16_t b)
A32: VSUB.I8 Qd, Qn, Qm
A64: SUB Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vsubq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_u8)

## vsubs_f32

`vsubs_f32`

float32_t vsubs_f32 (float32_t a, float32_t b)
A32: VSUB.F32 Sd, Sn, Sm
A64: FSUB Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vsubs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubs_f32)

## vsubw_high_s16

`vsubw_high_s16`

int32x4_t vsubw_high_s16 (int32x4_t a, int16x8_t b)
A32: VSUBW.S16 Qd, Qn, Dm+1
A64: SSUBW2 Vd.4S, Vn.4S, Vm.8H


Instruction Documentation: [vsubw_high_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_high_s16)

## vsubw_high_s32

`vsubw_high_s32`

int64x2_t vsubw_high_s32 (int64x2_t a, int32x4_t b)
A32: VSUBW.S32 Qd, Qn, Dm+1
A64: SSUBW2 Vd.2D, Vn.2D, Vm.4S


Instruction Documentation: [vsubw_high_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_high_s32)

## vsubw_high_s8

`vsubw_high_s8`

int16x8_t vsubw_high_s8 (int16x8_t a, int8x16_t b)
A32: VSUBW.S8 Qd, Qn, Dm+1
A64: SSUBW2 Vd.8H, Vn.8H, Vm.16B


Instruction Documentation: [vsubw_high_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_high_s8)

## vsubw_high_u16

`vsubw_high_u16`

uint32x4_t vsubw_high_u16 (uint32x4_t a, uint16x8_t b)
A32: VSUBW.U16 Qd, Qn, Dm+1
A64: USUBW2 Vd.4S, Vn.4S, Vm.8H


Instruction Documentation: [vsubw_high_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_high_u16)

## vsubw_high_u32

`vsubw_high_u32`

uint64x2_t vsubw_high_u32 (uint64x2_t a, uint32x4_t b)
A32: VSUBW.U32 Qd, Qn, Dm+1
A64: USUBW2 Vd.2D, Vn.2D, Vm.4S


Instruction Documentation: [vsubw_high_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_high_u32)

## vsubw_high_u8

`vsubw_high_u8`

uint16x8_t vsubw_high_u8 (uint16x8_t a, uint8x16_t b)
A32: VSUBW.U8 Qd, Qn, Dm+1
A64: USUBW2 Vd.8H, Vn.8H, Vm.16B


Instruction Documentation: [vsubw_high_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_high_u8)

## vsubw_s16

`vsubw_s16`

int32x4_t vsubw_s16 (int32x4_t a, int16x4_t b)
A32: VSUBW.S16 Qd, Qn, Dm
A64: SSUBW Vd.4S, Vn.4S, Vm.4H


Instruction Documentation: [vsubw_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_s16)

## vsubw_s32

`vsubw_s32`

int64x2_t vsubw_s32 (int64x2_t a, int32x2_t b)
A32: VSUBW.S32 Qd, Qn, Dm
A64: SSUBW Vd.2D, Vn.2D, Vm.2S


Instruction Documentation: [vsubw_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_s32)

## vsubw_s8

`vsubw_s8`

int16x8_t vsubw_s8 (int16x8_t a, int8x8_t b)
A32: VSUBW.S8 Qd, Qn, Dm
A64: SSUBW Vd.8H, Vn.8H, Vm.8B


Instruction Documentation: [vsubw_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_s8)

## vsubw_u16

`vsubw_u16`

uint32x4_t vsubw_u16 (uint32x4_t a, uint16x4_t b)
A32: VSUBW.U16 Qd, Qn, Dm
A64: USUBW Vd.4S, Vn.4S, Vm.4H


Instruction Documentation: [vsubw_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_u16)

## vsubw_u32

`vsubw_u32`

uint64x2_t vsubw_u32 (uint64x2_t a, uint32x2_t b)
A32: VSUBW.U32 Qd, Qn, Dm
A64: USUBW Vd.2D, Vn.2D, Vm.2S


Instruction Documentation: [vsubw_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_u32)

## vsubw_u8

`vsubw_u8`

uint16x8_t vsubw_u8 (uint16x8_t a, uint8x8_t b)
A32: VSUBW.U8 Qd, Qn, Dm
A64: USUBW Vd.8H, Vn.8H, Vm.8B


Instruction Documentation: [vsubw_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubw_u8)

## vtst_f32

`vtst_f32`

uint32x2_t vtst_f32 (float32x2_t a, float32x2_t b)
A32: VTST.32 Dd, Dn, Dm
A64: CMTST Vd.2S, Vn.2S, Vm.2S The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vtst_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_f32)

## vtst_s16

`vtst_s16`

uint16x4_t vtst_s16 (int16x4_t a, int16x4_t b)
A32: VTST.16 Dd, Dn, Dm
A64: CMTST Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vtst_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_s16)

## vtst_s32

`vtst_s32`

uint32x2_t vtst_s32 (int32x2_t a, int32x2_t b)
A32: VTST.32 Dd, Dn, Dm
A64: CMTST Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vtst_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_s32)

## vtst_s8

`vtst_s8`

uint8x8_t vtst_s8 (int8x8_t a, int8x8_t b)
A32: VTST.8 Dd, Dn, Dm
A64: CMTST Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vtst_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_s8)

## vtst_u16

`vtst_u16`

uint16x4_t vtst_u16 (uint16x4_t a, uint16x4_t b)
A32: VTST.16 Dd, Dn, Dm
A64: CMTST Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vtst_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_u16)

## vtst_u32

`vtst_u32`

uint32x2_t vtst_u32 (uint32x2_t a, uint32x2_t b)
A32: VTST.32 Dd, Dn, Dm
A64: CMTST Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vtst_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_u32)

## vtst_u8

`vtst_u8`

uint8x8_t vtst_u8 (uint8x8_t a, uint8x8_t b)
A32: VTST.8 Dd, Dn, Dm
A64: CMTST Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vtst_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_u8)

## vtstq_f32

`vtstq_f32`

uint32x4_t vtstq_f32 (float32x4_t a, float32x4_t b)
A32: VTST.32 Qd, Qn, Qm
A64: CMTST Vd.4S, Vn.4S, Vm.4S The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vtstq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_f32)

## vtstq_s16

`vtstq_s16`

uint16x8_t vtstq_s16 (int16x8_t a, int16x8_t b)
A32: VTST.16 Qd, Qn, Qm
A64: CMTST Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vtstq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_s16)

## vtstq_s32

`vtstq_s32`

uint32x4_t vtstq_s32 (int32x4_t a, int32x4_t b)
A32: VTST.32 Qd, Qn, Qm
A64: CMTST Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vtstq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_s32)

## vtstq_s8

`vtstq_s8`

uint8x16_t vtstq_s8 (int8x16_t a, int8x16_t b)
A32: VTST.8 Qd, Qn, Qm
A64: CMTST Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vtstq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_s8)

## vtstq_u16

`vtstq_u16`

uint16x8_t vtstq_u16 (uint16x8_t a, uint16x8_t b)
A32: VTST.16 Qd, Qn, Qm
A64: CMTST Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vtstq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_u16)

## vtstq_u32

`vtstq_u32`

uint32x4_t vtstq_u32 (uint32x4_t a, uint32x4_t b)
A32: VTST.32 Qd, Qn, Qm
A64: CMTST Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vtstq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_u32)

## vtstq_u8

`vtstq_u8`

uint8x16_t vtstq_u8 (uint8x16_t a, uint8x16_t b)
A32: VTST.8 Qd, Qn, Qm
A64: CMTST Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vtstq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_u8)
