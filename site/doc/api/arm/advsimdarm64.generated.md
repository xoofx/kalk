---
title: Arm AdvSimdArm64 Intrinsics
url: /doc/api/arm/advsimdarm64/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `AdvSimdArm64` features.

{{end}}


## vabd_f64

`vabd_f64`

float64x1_t vabd_f64 (float64x1_t a, float64x1_t b)
A64: FABD Dd, Dn, Dm


Instruction Documentation: [vabd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabd_f64)

## vabdq_f64

`vabdq_f64`

float64x2_t vabdq_f64 (float64x2_t a, float64x2_t b)
A64: FABD Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vabdq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabdq_f64)

## vabds_f32

`vabds_f32`

float32_t vabds_f32 (float32_t a, float32_t b)
A64: FABD Sd, Sn, Sm


Instruction Documentation: [vabds_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabds_f32)

## vabs_s64

`vabs_s64`

int64x1_t vabs_s64 (int64x1_t a)
A64: ABS Dd, Dn


Instruction Documentation: [vabs_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabs_s64)

## vabsq_f64

`vabsq_f64`

float64x2_t vabsq_f64 (float64x2_t a)
A64: FABS Vd.2D, Vn.2D


Instruction Documentation: [vabsq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabsq_f64)

## vabsq_s64

`vabsq_s64`

int64x2_t vabsq_s64 (int64x2_t a)
A64: ABS Vd.2D, Vn.2D


Instruction Documentation: [vabsq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vabsq_s64)

## vaddlv_s16

`vaddlv_s16`

int32_t vaddlv_s16 (int16x4_t a)
A64: SADDLV Sd, Vn.4H


Instruction Documentation: [vaddlv_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlv_s16)

## vaddlv_s8

`vaddlv_s8`

int16_t vaddlv_s8 (int8x8_t a)
A64: SADDLV Hd, Vn.8B


Instruction Documentation: [vaddlv_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlv_s8)

## vaddlv_u16

`vaddlv_u16`

uint32_t vaddlv_u16 (uint16x4_t a)
A64: UADDLV Sd, Vn.4H


Instruction Documentation: [vaddlv_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlv_u16)

## vaddlv_u8

`vaddlv_u8`

uint16_t vaddlv_u8 (uint8x8_t a)
A64: UADDLV Hd, Vn.8B


Instruction Documentation: [vaddlv_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlv_u8)

## vaddlvq_s16

`vaddlvq_s16`

int32_t vaddlvq_s16 (int16x8_t a)
A64: SADDLV Sd, Vn.8H


Instruction Documentation: [vaddlvq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlvq_s16)

## vaddlvq_s32

`vaddlvq_s32`

int64_t vaddlvq_s32 (int32x4_t a)
A64: SADDLV Dd, Vn.4S


Instruction Documentation: [vaddlvq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlvq_s32)

## vaddlvq_s8

`vaddlvq_s8`

int16_t vaddlvq_s8 (int8x16_t a)
A64: SADDLV Hd, Vn.16B


Instruction Documentation: [vaddlvq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlvq_s8)

## vaddlvq_u16

`vaddlvq_u16`

uint32_t vaddlvq_u16 (uint16x8_t a)
A64: UADDLV Sd, Vn.8H


Instruction Documentation: [vaddlvq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlvq_u16)

## vaddlvq_u32

`vaddlvq_u32`

uint64_t vaddlvq_u32 (uint32x4_t a)
A64: UADDLV Dd, Vn.4S


Instruction Documentation: [vaddlvq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlvq_u32)

## vaddlvq_u8

`vaddlvq_u8`

uint16_t vaddlvq_u8 (uint8x16_t a)
A64: UADDLV Hd, Vn.16B


Instruction Documentation: [vaddlvq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddlvq_u8)

## vaddq_f64

`vaddq_f64`

float64x2_t vaddq_f64 (float64x2_t a, float64x2_t b)
A64: FADD Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vaddq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddq_f64)

## vaddv_s16

`vaddv_s16`

int16_t vaddv_s16 (int16x4_t a)
A64: ADDV Hd, Vn.4H


Instruction Documentation: [vaddv_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddv_s16)

## vaddv_s8

`vaddv_s8`

int8_t vaddv_s8 (int8x8_t a)
A64: ADDV Bd, Vn.8B


Instruction Documentation: [vaddv_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddv_s8)

## vaddv_u16

`vaddv_u16`

uint16_t vaddv_u16 (uint16x4_t a)
A64: ADDV Hd, Vn.4H


Instruction Documentation: [vaddv_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddv_u16)

## vaddv_u8

`vaddv_u8`

uint8_t vaddv_u8 (uint8x8_t a)
A64: ADDV Bd, Vn.8B


Instruction Documentation: [vaddv_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddv_u8)

## vaddvq_s16

`vaddvq_s16`

int16_t vaddvq_s16 (int16x8_t a)
A64: ADDV Hd, Vn.8H


Instruction Documentation: [vaddvq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddvq_s16)

## vaddvq_s32

`vaddvq_s32`

int32_t vaddvq_s32 (int32x4_t a)
A64: ADDV Sd, Vn.4S


Instruction Documentation: [vaddvq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddvq_s32)

## vaddvq_s8

`vaddvq_s8`

int8_t vaddvq_s8 (int8x16_t a)
A64: ADDV Bd, Vn.16B


Instruction Documentation: [vaddvq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddvq_s8)

## vaddvq_u16

`vaddvq_u16`

uint16_t vaddvq_u16 (uint16x8_t a)
A64: ADDV Hd, Vn.8H


Instruction Documentation: [vaddvq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddvq_u16)

## vaddvq_u32

`vaddvq_u32`

uint32_t vaddvq_u32 (uint32x4_t a)
A64: ADDV Sd, Vn.4S


Instruction Documentation: [vaddvq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddvq_u32)

## vaddvq_u8

`vaddvq_u8`

uint8_t vaddvq_u8 (uint8x16_t a)
A64: ADDV Bd, Vn.16B


Instruction Documentation: [vaddvq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vaddvq_u8)

## vcage_f64

`vcage_f64`

uint64x1_t vcage_f64 (float64x1_t a, float64x1_t b)
A64: FACGE Dd, Dn, Dm


Instruction Documentation: [vcage_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcage_f64)

## vcageq_f64

`vcageq_f64`

uint64x2_t vcageq_f64 (float64x2_t a, float64x2_t b)
A64: FACGE Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcageq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcageq_f64)

## vcages_f32

`vcages_f32`

uint32_t vcages_f32 (float32_t a, float32_t b)
A64: FACGE Sd, Sn, Sm


Instruction Documentation: [vcages_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcages_f32)

## vcagt_f64

`vcagt_f64`

uint64x1_t vcagt_f64 (float64x1_t a, float64x1_t b)
A64: FACGT Dd, Dn, Dm


Instruction Documentation: [vcagt_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcagt_f64)

## vcagtq_f64

`vcagtq_f64`

uint64x2_t vcagtq_f64 (float64x2_t a, float64x2_t b)
A64: FACGT Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcagtq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcagtq_f64)

## vcagts_f32

`vcagts_f32`

uint32_t vcagts_f32 (float32_t a, float32_t b)
A64: FACGT Sd, Sn, Sm


Instruction Documentation: [vcagts_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcagts_f32)

## vcale_f64

`vcale_f64`

uint64x1_t vcale_f64 (float64x1_t a, float64x1_t b)
A64: FACGE Dd, Dn, Dm


Instruction Documentation: [vcale_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcale_f64)

## vcaleq_f64

`vcaleq_f64`

uint64x2_t vcaleq_f64 (float64x2_t a, float64x2_t b)
A64: FACGE Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcaleq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcaleq_f64)

## vcales_f32

`vcales_f32`

uint32_t vcales_f32 (float32_t a, float32_t b)
A64: FACGE Sd, Sn, Sm


Instruction Documentation: [vcales_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcales_f32)

## vcalt_f64

`vcalt_f64`

uint64x1_t vcalt_f64 (float64x1_t a, float64x1_t b)
A64: FACGT Dd, Dn, Dm


Instruction Documentation: [vcalt_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcalt_f64)

## vcaltq_f64

`vcaltq_f64`

uint64x2_t vcaltq_f64 (float64x2_t a, float64x2_t b)
A64: FACGT Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcaltq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcaltq_f64)

## vcalts_f32

`vcalts_f32`

uint32_t vcalts_f32 (float32_t a, float32_t b)
A64: FACGT Sd, Sn, Sm


Instruction Documentation: [vcalts_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcalts_f32)

## vceq_f64

`vceq_f64`

uint64x1_t vceq_f64 (float64x1_t a, float64x1_t b)
A64: FCMEQ Dd, Dn, Dm


Instruction Documentation: [vceq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_f64)

## vceq_s64

`vceq_s64`

uint64x1_t vceq_s64 (int64x1_t a, int64x1_t b)
A64: CMEQ Dd, Dn, Dm


Instruction Documentation: [vceq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_s64)

## vceq_u64

`vceq_u64`

uint64x1_t vceq_u64 (uint64x1_t a, uint64x1_t b)
A64: CMEQ Dd, Dn, Dm


Instruction Documentation: [vceq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceq_u64)

## vceqq_f64

`vceqq_f64`

uint64x2_t vceqq_f64 (float64x2_t a, float64x2_t b)
A64: FCMEQ Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vceqq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_f64)

## vceqq_s64

`vceqq_s64`

uint64x2_t vceqq_s64 (int64x2_t a, int64x2_t b)
A64: CMEQ Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vceqq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_s64)

## vceqq_u64

`vceqq_u64`

uint64x2_t vceqq_u64 (uint64x2_t a, uint64x2_t b)
A64: CMEQ Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vceqq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqq_u64)

## vceqs_f32

`vceqs_f32`

uint32_t vceqs_f32 (float32_t a, float32_t b)
A64: FCMEQ Sd, Sn, Sm


Instruction Documentation: [vceqs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vceqs_f32)

## vcge_f64

`vcge_f64`

uint64x1_t vcge_f64 (float64x1_t a, float64x1_t b)
A64: FCMGE Dd, Dn, Dm


Instruction Documentation: [vcge_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_f64)

## vcge_s64

`vcge_s64`

uint64x1_t vcge_s64 (int64x1_t a, int64x1_t b)
A64: CMGE Dd, Dn, Dm


Instruction Documentation: [vcge_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_s64)

## vcge_u64

`vcge_u64`

uint64x1_t vcge_u64 (uint64x1_t a, uint64x1_t b)
A64: CMHS Dd, Dn, Dm


Instruction Documentation: [vcge_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcge_u64)

## vcgeq_f64

`vcgeq_f64`

uint64x2_t vcgeq_f64 (float64x2_t a, float64x2_t b)
A64: FCMGE Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcgeq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_f64)

## vcgeq_s64

`vcgeq_s64`

uint64x2_t vcgeq_s64 (int64x2_t a, int64x2_t b)
A64: CMGE Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcgeq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_s64)

## vcgeq_u64

`vcgeq_u64`

uint64x2_t vcgeq_u64 (uint64x2_t a, uint64x2_t b)
A64: CMHS Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcgeq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgeq_u64)

## vcges_f32

`vcges_f32`

uint32_t vcges_f32 (float32_t a, float32_t b)
A64: FCMGE Sd, Sn, Sm


Instruction Documentation: [vcges_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcges_f32)

## vcgt_f64

`vcgt_f64`

uint64x1_t vcgt_f64 (float64x1_t a, float64x1_t b)
A64: FCMGT Dd, Dn, Dm


Instruction Documentation: [vcgt_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_f64)

## vcgt_s64

`vcgt_s64`

uint64x1_t vcgt_s64 (int64x1_t a, int64x1_t b)
A64: CMGT Dd, Dn, Dm


Instruction Documentation: [vcgt_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_s64)

## vcgt_u64

`vcgt_u64`

uint64x1_t vcgt_u64 (uint64x1_t a, uint64x1_t b)
A64: CMHI Dd, Dn, Dm


Instruction Documentation: [vcgt_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgt_u64)

## vcgtq_f64

`vcgtq_f64`

uint64x2_t vcgtq_f64 (float64x2_t a, float64x2_t b)
A64: FCMGT Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcgtq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_f64)

## vcgtq_s64

`vcgtq_s64`

uint64x2_t vcgtq_s64 (int64x2_t a, int64x2_t b)
A64: CMGT Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcgtq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_s64)

## vcgtq_u64

`vcgtq_u64`

uint64x2_t vcgtq_u64 (uint64x2_t a, uint64x2_t b)
A64: CMHI Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcgtq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgtq_u64)

## vcgts_f32

`vcgts_f32`

uint32_t vcgts_f32 (float32_t a, float32_t b)
A64: FCMGT Sd, Sn, Sm


Instruction Documentation: [vcgts_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcgts_f32)

## vcle_f64

`vcle_f64`

uint64x1_t vcle_f64 (float64x1_t a, float64x1_t b)
A64: FCMGE Dd, Dn, Dm


Instruction Documentation: [vcle_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_f64)

## vcle_s64

`vcle_s64`

uint64x1_t vcle_s64 (int64x1_t a, int64x1_t b)
A64: CMGE Dd, Dn, Dm


Instruction Documentation: [vcle_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_s64)

## vcle_u64

`vcle_u64`

uint64x1_t vcle_u64 (uint64x1_t a, uint64x1_t b)
A64: CMHS Dd, Dn, Dm


Instruction Documentation: [vcle_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcle_u64)

## vcleq_f64

`vcleq_f64`

uint64x2_t vcleq_f64 (float64x2_t a, float64x2_t b)
A64: FCMGE Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcleq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_f64)

## vcleq_s64

`vcleq_s64`

uint64x2_t vcleq_s64 (int64x2_t a, int64x2_t b)
A64: CMGE Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcleq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_s64)

## vcleq_u64

`vcleq_u64`

uint64x2_t vcleq_u64 (uint64x2_t a, uint64x2_t b)
A64: CMHS Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcleq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcleq_u64)

## vcles_f32

`vcles_f32`

uint32_t vcles_f32 (float32_t a, float32_t b)
A64: FCMGE Sd, Sn, Sm


Instruction Documentation: [vcles_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcles_f32)

## vclt_f64

`vclt_f64`

uint64x1_t vclt_f64 (float64x1_t a, float64x1_t b)
A64: FCMGT Dd, Dn, Dm


Instruction Documentation: [vclt_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_f64)

## vclt_s64

`vclt_s64`

uint64x1_t vclt_s64 (int64x1_t a, int64x1_t b)
A64: CMGT Dd, Dn, Dm


Instruction Documentation: [vclt_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_s64)

## vclt_u64

`vclt_u64`

uint64x1_t vclt_u64 (uint64x1_t a, uint64x1_t b)
A64: CMHI Dd, Dn, Dm


Instruction Documentation: [vclt_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclt_u64)

## vcltq_f64

`vcltq_f64`

uint64x2_t vcltq_f64 (float64x2_t a, float64x2_t b)
A64: FCMGT Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcltq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_f64)

## vcltq_s64

`vcltq_s64`

uint64x2_t vcltq_s64 (int64x2_t a, int64x2_t b)
A64: CMGT Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcltq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_s64)

## vcltq_u64

`vcltq_u64`

uint64x2_t vcltq_u64 (uint64x2_t a, uint64x2_t b)
A64: CMHI Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vcltq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcltq_u64)

## vclts_f32

`vclts_f32`

uint32_t vclts_f32 (float32_t a, float32_t b)
A64: FCMGT Sd, Sn, Sm


Instruction Documentation: [vclts_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vclts_f32)

## vcopy_lane_f32

`vcopy_lane_f32`

float32x2_t vcopy_lane_f32 (float32x2_t a, const int lane1, float32x2_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopy_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_lane_f32)

## vcopy_lane_s16

`vcopy_lane_s16`

int16x4_t vcopy_lane_s16 (int16x4_t a, const int lane1, int16x4_t b, const int lane2)
A64: INS Vd.H[lane1], Vn.H[lane2]


Instruction Documentation: [vcopy_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_lane_s16)

## vcopy_lane_s32

`vcopy_lane_s32`

int32x2_t vcopy_lane_s32 (int32x2_t a, const int lane1, int32x2_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopy_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_lane_s32)

## vcopy_lane_s8

`vcopy_lane_s8`

int8x8_t vcopy_lane_s8 (int8x8_t a, const int lane1, int8x8_t b, const int lane2)
A64: INS Vd.B[lane1], Vn.B[lane2]


Instruction Documentation: [vcopy_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_lane_s8)

## vcopy_lane_u16

`vcopy_lane_u16`

uint16x4_t vcopy_lane_u16 (uint16x4_t a, const int lane1, uint16x4_t b, const int lane2)
A64: INS Vd.H[lane1], Vn.H[lane2]


Instruction Documentation: [vcopy_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_lane_u16)

## vcopy_lane_u32

`vcopy_lane_u32`

uint32x2_t vcopy_lane_u32 (uint32x2_t a, const int lane1, uint32x2_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopy_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_lane_u32)

## vcopy_lane_u8

`vcopy_lane_u8`

uint8x8_t vcopy_lane_u8 (uint8x8_t a, const int lane1, uint8x8_t b, const int lane2)
A64: INS Vd.B[lane1], Vn.B[lane2]


Instruction Documentation: [vcopy_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_lane_u8)

## vcopy_laneq_f32

`vcopy_laneq_f32`

float32x2_t vcopy_laneq_f32 (float32x2_t a, const int lane1, float32x4_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopy_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_laneq_f32)

## vcopy_laneq_s16

`vcopy_laneq_s16`

int16x4_t vcopy_laneq_s16 (int16x4_t a, const int lane1, int16x8_t b, const int lane2)
A64: INS Vd.H[lane1], Vn.H[lane2]


Instruction Documentation: [vcopy_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_laneq_s16)

## vcopy_laneq_s32

`vcopy_laneq_s32`

int32x2_t vcopy_laneq_s32 (int32x2_t a, const int lane1, int32x4_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopy_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_laneq_s32)

## vcopy_laneq_s8

`vcopy_laneq_s8`

int8x8_t vcopy_laneq_s8 (int8x8_t a, const int lane1, int8x16_t b, const int lane2)
A64: INS Vd.B[lane1], Vn.B[lane2]


Instruction Documentation: [vcopy_laneq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_laneq_s8)

## vcopy_laneq_u16

`vcopy_laneq_u16`

uint16x4_t vcopy_laneq_u16 (uint16x4_t a, const int lane1, uint16x8_t b, const int lane2)
A64: INS Vd.H[lane1], Vn.H[lane2]


Instruction Documentation: [vcopy_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_laneq_u16)

## vcopy_laneq_u32

`vcopy_laneq_u32`

uint32x2_t vcopy_laneq_u32 (uint32x2_t a, const int lane1, uint32x4_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopy_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_laneq_u32)

## vcopy_laneq_u8

`vcopy_laneq_u8`

uint8x8_t vcopy_laneq_u8 (uint8x8_t a, const int lane1, uint8x16_t b, const int lane2)
A64: INS Vd.B[lane1], Vn.B[lane2]


Instruction Documentation: [vcopy_laneq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopy_laneq_u8)

## vcopyq_lane_f32

`vcopyq_lane_f32`

float32x4_t vcopyq_lane_f32 (float32x4_t a, const int lane1, float32x2_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopyq_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_lane_f32)

## vcopyq_lane_s16

`vcopyq_lane_s16`

int16x8_t vcopyq_lane_s16 (int16x8_t a, const int lane1, int16x4_t b, const int lane2)
A64: INS Vd.H[lane1], Vn.H[lane2]


Instruction Documentation: [vcopyq_lane_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_lane_s16)

## vcopyq_lane_s32

`vcopyq_lane_s32`

int32x4_t vcopyq_lane_s32 (int32x4_t a, const int lane1, int32x2_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopyq_lane_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_lane_s32)

## vcopyq_lane_s8

`vcopyq_lane_s8`

int8x16_t vcopyq_lane_s8 (int8x16_t a, const int lane1, int8x8_t b, const int lane2)
A64: INS Vd.B[lane1], Vn.B[lane2]


Instruction Documentation: [vcopyq_lane_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_lane_s8)

## vcopyq_lane_u16

`vcopyq_lane_u16`

uint16x8_t vcopyq_lane_u16 (uint16x8_t a, const int lane1, uint16x4_t b, const int lane2)
A64: INS Vd.H[lane1], Vn.H[lane2]


Instruction Documentation: [vcopyq_lane_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_lane_u16)

## vcopyq_lane_u32

`vcopyq_lane_u32`

uint32x4_t vcopyq_lane_u32 (uint32x4_t a, const int lane1, uint32x2_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopyq_lane_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_lane_u32)

## vcopyq_lane_u8

`vcopyq_lane_u8`

uint8x16_t vcopyq_lane_u8 (uint8x16_t a, const int lane1, uint8x8_t b, const int lane2)
A64: INS Vd.B[lane1], Vn.B[lane2]


Instruction Documentation: [vcopyq_lane_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_lane_u8)

## vcopyq_laneq_f32

`vcopyq_laneq_f32`

float32x4_t vcopyq_laneq_f32 (float32x4_t a, const int lane1, float32x4_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopyq_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_f32)

## vcopyq_laneq_f64

`vcopyq_laneq_f64`

float64x2_t vcopyq_laneq_f64 (float64x2_t a, const int lane1, float64x2_t b, const int lane2)
A64: INS Vd.D[lane1], Vn.D[lane2]


Instruction Documentation: [vcopyq_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_f64)

## vcopyq_laneq_s16

`vcopyq_laneq_s16`

int16x8_t vcopyq_laneq_s16 (int16x8_t a, const int lane1, int16x8_t b, const int lane2)
A64: INS Vd.H[lane1], Vn.H[lane2]


Instruction Documentation: [vcopyq_laneq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_s16)

## vcopyq_laneq_s32

`vcopyq_laneq_s32`

int32x4_t vcopyq_laneq_s32 (int32x4_t a, const int lane1, int32x4_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopyq_laneq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_s32)

## vcopyq_laneq_s64

`vcopyq_laneq_s64`

int64x2_t vcopyq_laneq_s64 (int64x2_t a, const int lane1, int64x2_t b, const int lane2)
A64: INS Vd.D[lane1], Vn.D[lane2]


Instruction Documentation: [vcopyq_laneq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_s64)

## vcopyq_laneq_s8

`vcopyq_laneq_s8`

int8x16_t vcopyq_laneq_s8 (int8x16_t a, const int lane1, int8x16_t b, const int lane2)
A64: INS Vd.B[lane1], Vn.B[lane2]


Instruction Documentation: [vcopyq_laneq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_s8)

## vcopyq_laneq_u16

`vcopyq_laneq_u16`

uint16x8_t vcopyq_laneq_u16 (uint16x8_t a, const int lane1, uint16x8_t b, const int lane2)
A64: INS Vd.H[lane1], Vn.H[lane2]


Instruction Documentation: [vcopyq_laneq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_u16)

## vcopyq_laneq_u32

`vcopyq_laneq_u32`

uint32x4_t vcopyq_laneq_u32 (uint32x4_t a, const int lane1, uint32x4_t b, const int lane2)
A64: INS Vd.S[lane1], Vn.S[lane2]


Instruction Documentation: [vcopyq_laneq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_u32)

## vcopyq_laneq_u64

`vcopyq_laneq_u64`

uint64x2_t vcopyq_laneq_u64 (uint64x2_t a, const int lane1, uint64x2_t b, const int lane2)
A64: INS Vd.D[lane1], Vn.D[lane2]


Instruction Documentation: [vcopyq_laneq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_u64)

## vcopyq_laneq_u8

`vcopyq_laneq_u8`

uint8x16_t vcopyq_laneq_u8 (uint8x16_t a, const int lane1, uint8x16_t b, const int lane2)
A64: INS Vd.B[lane1], Vn.B[lane2]


Instruction Documentation: [vcopyq_laneq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcopyq_laneq_u8)

## vcvt_f32_f64

`vcvt_f32_f64`

float32x2_t vcvt_f32_f64 (float64x2_t a)
A64: FCVTN Vd.2S, Vn.2D


Instruction Documentation: [vcvt_f32_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_f32_f64)

## vcvt_f64_f32

`vcvt_f64_f32`

float64x2_t vcvt_f64_f32 (float32x2_t a)
A64: FCVTL Vd.2D, Vn.2S


Instruction Documentation: [vcvt_f64_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_f64_f32)

## vcvt_f64_s64

`vcvt_f64_s64`

float64x1_t vcvt_f64_s64 (int64x1_t a)
A64: SCVTF Dd, Dn


Instruction Documentation: [vcvt_f64_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_f64_s64)

## vcvt_f64_u64

`vcvt_f64_u64`

float64x1_t vcvt_f64_u64 (uint64x1_t a)
A64: UCVTF Dd, Dn


Instruction Documentation: [vcvt_f64_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_f64_u64)

## vcvt_high_f32_f64

`vcvt_high_f32_f64`

float32x4_t vcvt_high_f32_f64 (float32x2_t r, float64x2_t a)
A64: FCVTN2 Vd.4S, Vn.2D


Instruction Documentation: [vcvt_high_f32_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_high_f32_f64)

## vcvt_high_f64_f32

`vcvt_high_f64_f32`

float64x2_t vcvt_high_f64_f32 (float32x4_t a)
A64: FCVTL2 Vd.2D, Vn.4S


Instruction Documentation: [vcvt_high_f64_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_high_f64_f32)

## vcvt_s64_f64

`vcvt_s64_f64`

int64x1_t vcvt_s64_f64 (float64x1_t a)
A64: FCVTZS Dd, Dn


Instruction Documentation: [vcvt_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_s64_f64)

## vcvt_u64_f64

`vcvt_u64_f64`

uint64x1_t vcvt_u64_f64 (float64x1_t a)
A64: FCVTZU Dd, Dn


Instruction Documentation: [vcvt_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvt_u64_f64)

## vcvta_s64_f64

`vcvta_s64_f64`

int64x1_t vcvta_s64_f64 (float64x1_t a)
A64: FCVTAS Dd, Dn


Instruction Documentation: [vcvta_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvta_s64_f64)

## vcvta_u64_f64

`vcvta_u64_f64`

uint64x1_t vcvta_u64_f64 (float64x1_t a)
A64: FCVTAU Dd, Dn


Instruction Documentation: [vcvta_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvta_u64_f64)

## vcvtaq_s64_f64

`vcvtaq_s64_f64`

int64x2_t vcvtaq_s64_f64 (float64x2_t a)
A64: FCVTAS Vd.2D, Vn.2D


Instruction Documentation: [vcvtaq_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtaq_s64_f64)

## vcvtaq_u64_f64

`vcvtaq_u64_f64`

uint64x2_t vcvtaq_u64_f64 (float64x2_t a)
A64: FCVTAU Vd.2D, Vn.2D


Instruction Documentation: [vcvtaq_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtaq_u64_f64)

## vcvtm_s64_f64

`vcvtm_s64_f64`

int64x1_t vcvtm_s64_f64 (float64x1_t a)
A64: FCVTMS Dd, Dn


Instruction Documentation: [vcvtm_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtm_s64_f64)

## vcvtm_u64_f64

`vcvtm_u64_f64`

uint64x1_t vcvtm_u64_f64 (float64x1_t a)
A64: FCVTMU Dd, Dn


Instruction Documentation: [vcvtm_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtm_u64_f64)

## vcvtmq_s64_f64

`vcvtmq_s64_f64`

int64x2_t vcvtmq_s64_f64 (float64x2_t a)
A64: FCVTMS Vd.2D, Vn.2D


Instruction Documentation: [vcvtmq_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtmq_s64_f64)

## vcvtmq_u64_f64

`vcvtmq_u64_f64`

uint64x2_t vcvtmq_u64_f64 (float64x2_t a)
A64: FCVTMU Vd.2D, Vn.2D


Instruction Documentation: [vcvtmq_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtmq_u64_f64)

## vcvtn_s64_f64

`vcvtn_s64_f64`

int64x1_t vcvtn_s64_f64 (float64x1_t a)
A64: FCVTNS Dd, Dn


Instruction Documentation: [vcvtn_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtn_s64_f64)

## vcvtn_u64_f64

`vcvtn_u64_f64`

uint64x1_t vcvtn_u64_f64 (float64x1_t a)
A64: FCVTNU Dd, Dn


Instruction Documentation: [vcvtn_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtn_u64_f64)

## vcvtnq_s64_f64

`vcvtnq_s64_f64`

int64x2_t vcvtnq_s64_f64 (float64x2_t a)
A64: FCVTNS Vd.2D, Vn.2D


Instruction Documentation: [vcvtnq_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtnq_s64_f64)

## vcvtnq_u64_f64

`vcvtnq_u64_f64`

uint64x2_t vcvtnq_u64_f64 (float64x2_t a)
A64: FCVTNU Vd.2D, Vn.2D


Instruction Documentation: [vcvtnq_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtnq_u64_f64)

## vcvtp_s64_f64

`vcvtp_s64_f64`

int64x1_t vcvtp_s64_f64 (float64x1_t a)
A64: FCVTPS Dd, Dn


Instruction Documentation: [vcvtp_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtp_s64_f64)

## vcvtp_u64_f64

`vcvtp_u64_f64`

uint64x1_t vcvtp_u64_f64 (float64x1_t a)
A64: FCVTPU Dd, Dn


Instruction Documentation: [vcvtp_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtp_u64_f64)

## vcvtpq_s64_f64

`vcvtpq_s64_f64`

int64x2_t vcvtpq_s64_f64 (float64x2_t a)
A64: FCVTPS Vd.2D, Vn.2D


Instruction Documentation: [vcvtpq_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtpq_s64_f64)

## vcvtpq_u64_f64

`vcvtpq_u64_f64`

uint64x2_t vcvtpq_u64_f64 (float64x2_t a)
A64: FCVTPU Vd.2D, Vn.2D


Instruction Documentation: [vcvtpq_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtpq_u64_f64)

## vcvtq_f64_s64

`vcvtq_f64_s64`

float64x2_t vcvtq_f64_s64 (int64x2_t a)
A64: SCVTF Vd.2D, Vn.2D


Instruction Documentation: [vcvtq_f64_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtq_f64_s64)

## vcvtq_f64_u64

`vcvtq_f64_u64`

float64x2_t vcvtq_f64_u64 (uint64x2_t a)
A64: UCVTF Vd.2D, Vn.2D


Instruction Documentation: [vcvtq_f64_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtq_f64_u64)

## vcvtq_s64_f64

`vcvtq_s64_f64`

int64x2_t vcvtq_s64_f64 (float64x2_t a)
A64: FCVTZS Vd.2D, Vn.2D


Instruction Documentation: [vcvtq_s64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtq_s64_f64)

## vcvtq_u64_f64

`vcvtq_u64_f64`

uint64x2_t vcvtq_u64_f64 (float64x2_t a)
A64: FCVTZU Vd.2D, Vn.2D


Instruction Documentation: [vcvtq_u64_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtq_u64_f64)

## vcvtx_f32_f64

`vcvtx_f32_f64`

float32x2_t vcvtx_f32_f64 (float64x2_t a)
A64: FCVTXN Vd.2S, Vn.2D


Instruction Documentation: [vcvtx_f32_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtx_f32_f64)

## vcvtx_high_f32_f64

`vcvtx_high_f32_f64`

float32x4_t vcvtx_high_f32_f64 (float32x2_t r, float64x2_t a)
A64: FCVTXN2 Vd.4S, Vn.2D


Instruction Documentation: [vcvtx_high_f32_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vcvtx_high_f32_f64)

## vdiv_f32

`vdiv_f32`

float32x2_t vdiv_f32 (float32x2_t a, float32x2_t b)
A64: FDIV Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vdiv_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdiv_f32)

## vdivq_f32

`vdivq_f32`

float32x4_t vdivq_f32 (float32x4_t a, float32x4_t b)
A64: FDIV Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vdivq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdivq_f32)

## vdivq_f64

`vdivq_f64`

float64x2_t vdivq_f64 (float64x2_t a, float64x2_t b)
A64: FDIV Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vdivq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdivq_f64)

## vdupq_laneq_f64

`vdupq_laneq_f64`

float64x2_t vdupq_laneq_f64 (float64x2_t vec, const int lane)
A64: DUP Vd.2D, Vn.D[index]


Instruction Documentation: [vdupq_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_laneq_f64)

## vdupq_laneq_s64

`vdupq_laneq_s64`

int64x2_t vdupq_laneq_s64 (int64x2_t vec, const int lane)
A64: DUP Vd.2D, Vn.D[index]


Instruction Documentation: [vdupq_laneq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_laneq_s64)

## vdupq_laneq_u64

`vdupq_laneq_u64`

uint64x2_t vdupq_laneq_u64 (uint64x2_t vec, const int lane)
A64: DUP Vd.2D, Vn.D[index]


Instruction Documentation: [vdupq_laneq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_laneq_u64)

## vdupq_n_f64

`vdupq_n_f64`

float64x2_t vdupq_n_f64 (float64_t value)
A64: DUP Vd.2D, Vn.D[0]


Instruction Documentation: [vdupq_n_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_f64)

## vdupq_n_s64

`vdupq_n_s64`

int64x2_t vdupq_n_s64 (int64_t value)
A64: DUP Vd.2D, Rn


Instruction Documentation: [vdupq_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vdupq_n_s64)

## vfma_lane_f32

`vfma_lane_f32`

float32x2_t vfma_lane_f32 (float32x2_t a, float32x2_t b, float32x2_t v, const int lane)
A64: FMLA Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vfma_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfma_lane_f32)

## vfma_laneq_f32

`vfma_laneq_f32`

float32x2_t vfma_laneq_f32 (float32x2_t a, float32x2_t b, float32x4_t v, const int lane)
A64: FMLA Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vfma_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfma_laneq_f32)

## vfma_n_f32

`vfma_n_f32`

float32x2_t vfma_n_f32 (float32x2_t a, float32x2_t b, float32_t n)
A64: FMLA Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vfma_n_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfma_n_f32)

## vfmad_laneq_f64

`vfmad_laneq_f64`

float64_t vfmad_laneq_f64 (float64_t a, float64_t b, float64x2_t v, const int lane)
A64: FMLA Dd, Dn, Vm.D[lane]


Instruction Documentation: [vfmad_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmad_laneq_f64)

## vfmaq_f64

`vfmaq_f64`

float64x2_t vfmaq_f64 (float64x2_t a, float64x2_t b, float64x2_t c)
A64: FMLA Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vfmaq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmaq_f64)

## vfmaq_lane_f32

`vfmaq_lane_f32`

float32x4_t vfmaq_lane_f32 (float32x4_t a, float32x4_t b, float32x2_t v, const int lane)
A64: FMLA Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vfmaq_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmaq_lane_f32)

## vfmaq_laneq_f32

`vfmaq_laneq_f32`

float32x4_t vfmaq_laneq_f32 (float32x4_t a, float32x4_t b, float32x4_t v, const int lane)
A64: FMLA Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vfmaq_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmaq_laneq_f32)

## vfmaq_laneq_f64

`vfmaq_laneq_f64`

float64x2_t vfmaq_laneq_f64 (float64x2_t a, float64x2_t b, float64x2_t v, const int lane)
A64: FMLA Vd.2D, Vn.2D, Vm.D[lane]


Instruction Documentation: [vfmaq_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmaq_laneq_f64)

## vfmaq_n_f32

`vfmaq_n_f32`

float32x4_t vfmaq_n_f32 (float32x4_t a, float32x4_t b, float32_t n)
A64: FMLA Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vfmaq_n_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmaq_n_f32)

## vfmaq_n_f64

`vfmaq_n_f64`

float64x2_t vfmaq_n_f64 (float64x2_t a, float64x2_t b, float64_t n)
A64: FMLA Vd.2D, Vn.2D, Vm.D[0]


Instruction Documentation: [vfmaq_n_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmaq_n_f64)

## vfmas_lane_f32

`vfmas_lane_f32`

float32_t vfmas_lane_f32 (float32_t a, float32_t b, float32x2_t v, const int lane)
A64: FMLA Sd, Sn, Vm.S[lane]


Instruction Documentation: [vfmas_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmas_lane_f32)

## vfmas_laneq_f32

`vfmas_laneq_f32`

float32_t vfmas_laneq_f32 (float32_t a, float32_t b, float32x4_t v, const int lane)
A64: FMLA Sd, Sn, Vm.S[lane]


Instruction Documentation: [vfmas_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmas_laneq_f32)

## vfms_lane_f32

`vfms_lane_f32`

float32x2_t vfms_lane_f32 (float32x2_t a, float32x2_t b, float32x2_t v, const int lane)
A64: FMLS Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vfms_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfms_lane_f32)

## vfms_laneq_f32

`vfms_laneq_f32`

float32x2_t vfms_laneq_f32 (float32x2_t a, float32x2_t b, float32x4_t v, const int lane)
A64: FMLS Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vfms_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfms_laneq_f32)

## vfms_n_f32

`vfms_n_f32`

float32x2_t vfms_n_f32 (float32x2_t a, float32x2_t b, float32_t n)
A64: FMLS Vd.2S, Vn.2S, Vm.S[0]


Instruction Documentation: [vfms_n_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfms_n_f32)

## vfmsd_laneq_f64

`vfmsd_laneq_f64`

float64_t vfmsd_laneq_f64 (float64_t a, float64_t b, float64x2_t v, const int lane)
A64: FMLS Dd, Dn, Vm.D[lane]


Instruction Documentation: [vfmsd_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmsd_laneq_f64)

## vfmsq_f64

`vfmsq_f64`

float64x2_t vfmsq_f64 (float64x2_t a, float64x2_t b, float64x2_t c)
A64: FMLS Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vfmsq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmsq_f64)

## vfmsq_lane_f32

`vfmsq_lane_f32`

float32x4_t vfmsq_lane_f32 (float32x4_t a, float32x4_t b, float32x2_t v, const int lane)
A64: FMLS Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vfmsq_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmsq_lane_f32)

## vfmsq_laneq_f32

`vfmsq_laneq_f32`

float32x4_t vfmsq_laneq_f32 (float32x4_t a, float32x4_t b, float32x4_t v, const int lane)
A64: FMLS Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vfmsq_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmsq_laneq_f32)

## vfmsq_laneq_f64

`vfmsq_laneq_f64`

float64x2_t vfmsq_laneq_f64 (float64x2_t a, float64x2_t b, float64x2_t v, const int lane)
A64: FMLS Vd.2D, Vn.2D, Vm.D[lane]


Instruction Documentation: [vfmsq_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmsq_laneq_f64)

## vfmsq_n_f32

`vfmsq_n_f32`

float32x4_t vfmsq_n_f32 (float32x4_t a, float32x4_t b, float32_t n)
A64: FMLS Vd.4S, Vn.4S, Vm.S[0]


Instruction Documentation: [vfmsq_n_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmsq_n_f32)

## vfmsq_n_f64

`vfmsq_n_f64`

float64x2_t vfmsq_n_f64 (float64x2_t a, float64x2_t b, float64_t n)
A64: FMLS Vd.2D, Vn.2D, Vm.D[0]


Instruction Documentation: [vfmsq_n_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmsq_n_f64)

## vfmss_lane_f32

`vfmss_lane_f32`

float32_t vfmss_lane_f32 (float32_t a, float32_t b, float32x2_t v, const int lane)
A64: FMLS Sd, Sn, Vm.S[lane]


Instruction Documentation: [vfmss_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmss_lane_f32)

## vfmss_laneq_f32

`vfmss_laneq_f32`

float32_t vfmss_laneq_f32 (float32_t a, float32_t b, float32x4_t v, const int lane)
A64: FMLS Sd, Sn, Vm.S[lane]


Instruction Documentation: [vfmss_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vfmss_laneq_f32)

## vld1q_dup_f64

`vld1q_dup_f64`

float64x2_t vld1q_dup_f64 (float64_t const * ptr)
A64: LD1R { Vt.2D }, [Xn]


Instruction Documentation: [vld1q_dup_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_f64)

## vld1q_dup_s64

`vld1q_dup_s64`

int64x2_t vld1q_dup_s64 (int64_t const * ptr)
A64: LD1R { Vt.2D }, [Xn]


Instruction Documentation: [vld1q_dup_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_s64)

## vld1q_dup_u64

`vld1q_dup_u64`

uint64x2_t vld1q_dup_u64 (uint64_t const * ptr)
A64: LD1R { Vt.2D }, [Xn]


Instruction Documentation: [vld1q_dup_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vld1q_dup_u64)

## vmax_f64

`vmax_f64`

float64x1_t vmax_f64 (float64x1_t a, float64x1_t b)
A64: FMAX Dd, Dn, Dm


Instruction Documentation: [vmax_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmax_f64)

## vmaxnmq_f64

`vmaxnmq_f64`

float64x2_t vmaxnmq_f64 (float64x2_t a, float64x2_t b)
A64: FMAXNM Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vmaxnmq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxnmq_f64)

## vmaxnmvq_f32

`vmaxnmvq_f32`

float32_t vmaxnmvq_f32 (float32x4_t a)
A64: FMAXNMV Sd, Vn.4S


Instruction Documentation: [vmaxnmvq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxnmvq_f32)

## vmaxq_f64

`vmaxq_f64`

float64x2_t vmaxq_f64 (float64x2_t a, float64x2_t b)
A64: FMAX Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vmaxq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxq_f64)

## vmaxs_f32

`vmaxs_f32`

float32_t vmaxs_f32 (float32_t a, float32_t b)
A64: FMAX Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vmaxs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxs_f32)

## vmaxv_s16

`vmaxv_s16`

int16_t vmaxv_s16 (int16x4_t a)
A64: SMAXV Hd, Vn.4H


Instruction Documentation: [vmaxv_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxv_s16)

## vmaxv_s8

`vmaxv_s8`

int8_t vmaxv_s8 (int8x8_t a)
A64: SMAXV Bd, Vn.8B


Instruction Documentation: [vmaxv_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxv_s8)

## vmaxv_u16

`vmaxv_u16`

uint16_t vmaxv_u16 (uint16x4_t a)
A64: UMAXV Hd, Vn.4H


Instruction Documentation: [vmaxv_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxv_u16)

## vmaxv_u8

`vmaxv_u8`

uint8_t vmaxv_u8 (uint8x8_t a)
A64: UMAXV Bd, Vn.8B


Instruction Documentation: [vmaxv_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxv_u8)

## vmaxvq_f32

`vmaxvq_f32`

float32_t vmaxvq_f32 (float32x4_t a)
A64: FMAXV Sd, Vn.4S


Instruction Documentation: [vmaxvq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxvq_f32)

## vmaxvq_s16

`vmaxvq_s16`

int16_t vmaxvq_s16 (int16x8_t a)
A64: SMAXV Hd, Vn.8H


Instruction Documentation: [vmaxvq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxvq_s16)

## vmaxvq_s32

`vmaxvq_s32`

int32_t vmaxvq_s32 (int32x4_t a)
A64: SMAXV Sd, Vn.4S


Instruction Documentation: [vmaxvq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxvq_s32)

## vmaxvq_s8

`vmaxvq_s8`

int8_t vmaxvq_s8 (int8x16_t a)
A64: SMAXV Bd, Vn.16B


Instruction Documentation: [vmaxvq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxvq_s8)

## vmaxvq_u16

`vmaxvq_u16`

uint16_t vmaxvq_u16 (uint16x8_t a)
A64: UMAXV Hd, Vn.8H


Instruction Documentation: [vmaxvq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxvq_u16)

## vmaxvq_u32

`vmaxvq_u32`

uint32_t vmaxvq_u32 (uint32x4_t a)
A64: UMAXV Sd, Vn.4S


Instruction Documentation: [vmaxvq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxvq_u32)

## vmaxvq_u8

`vmaxvq_u8`

uint8_t vmaxvq_u8 (uint8x16_t a)
A64: UMAXV Bd, Vn.16B


Instruction Documentation: [vmaxvq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmaxvq_u8)

## vmin_f64

`vmin_f64`

float64x1_t vmin_f64 (float64x1_t a, float64x1_t b)
A64: FMIN Dd, Dn, Dm


Instruction Documentation: [vmin_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmin_f64)

## vminnmq_f64

`vminnmq_f64`

float64x2_t vminnmq_f64 (float64x2_t a, float64x2_t b)
A64: FMINNM Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vminnmq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminnmq_f64)

## vminnmvq_f32

`vminnmvq_f32`

float32_t vminnmvq_f32 (float32x4_t a)
A64: FMINNMV Sd, Vn.4S


Instruction Documentation: [vminnmvq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminnmvq_f32)

## vminq_f64

`vminq_f64`

float64x2_t vminq_f64 (float64x2_t a, float64x2_t b)
A64: FMIN Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vminq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminq_f64)

## vmins_f32

`vmins_f32`

float32_t vmins_f32 (float32_t a, float32_t b)
A64: FMIN Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vmins_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmins_f32)

## vminv_s16

`vminv_s16`

int16_t vminv_s16 (int16x4_t a)
A64: SMINV Hd, Vn.4H


Instruction Documentation: [vminv_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminv_s16)

## vminv_s8

`vminv_s8`

int8_t vminv_s8 (int8x8_t a)
A64: SMINV Bd, Vn.8B


Instruction Documentation: [vminv_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminv_s8)

## vminv_u16

`vminv_u16`

uint16_t vminv_u16 (uint16x4_t a)
A64: UMINV Hd, Vn.4H


Instruction Documentation: [vminv_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminv_u16)

## vminv_u8

`vminv_u8`

uint8_t vminv_u8 (uint8x8_t a)
A64: UMINV Bd, Vn.8B


Instruction Documentation: [vminv_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminv_u8)

## vminvq_f32

`vminvq_f32`

float32_t vminvq_f32 (float32x4_t a)
A64: FMINV Sd, Vn.4S


Instruction Documentation: [vminvq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminvq_f32)

## vminvq_s16

`vminvq_s16`

int16_t vminvq_s16 (int16x8_t a)
A64: SMINV Hd, Vn.8H


Instruction Documentation: [vminvq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminvq_s16)

## vminvq_s8

`vminvq_s8`

int8_t vminvq_s8 (int8x16_t a)
A64: SMINV Bd, Vn.16B


Instruction Documentation: [vminvq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminvq_s8)

## vminvq_u16

`vminvq_u16`

uint16_t vminvq_u16 (uint16x8_t a)
A64: UMINV Hd, Vn.8H


Instruction Documentation: [vminvq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminvq_u16)

## vminvq_u32

`vminvq_u32`

uint32_t vminvq_u32 (uint32x4_t a)
A64: UMINV Sd, Vn.4S


Instruction Documentation: [vminvq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminvq_u32)

## vminvq_u8

`vminvq_u8`

uint8_t vminvq_u8 (uint8x16_t a)
A64: UMINV Bd, Vn.16B


Instruction Documentation: [vminvq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vminvq_u8)

## vmuld_laneq_f64

`vmuld_laneq_f64`

float64_t vmuld_laneq_f64 (float64_t a, float64x2_t v, const int lane)
A64: FMUL Dd, Dn, Vm.D[lane]


Instruction Documentation: [vmuld_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmuld_laneq_f64)

## vmulq_f64

`vmulq_f64`

float64x2_t vmulq_f64 (float64x2_t a, float64x2_t b)
A64: FMUL Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vmulq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_f64)

## vmulq_laneq_f64

`vmulq_laneq_f64`

float64x2_t vmulq_laneq_f64 (float64x2_t a, float64x2_t v, const int lane)
A64: FMUL Vd.2D, Vn.2D, Vm.D[lane]


Instruction Documentation: [vmulq_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_laneq_f64)

## vmulq_n_f64

`vmulq_n_f64`

float64x2_t vmulq_n_f64 (float64x2_t a, float64_t b)
A64: FMUL Vd.2D, Vn.2D, Vm.D[0]


Instruction Documentation: [vmulq_n_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulq_n_f64)

## vmulx_f32

`vmulx_f32`

float32x2_t vmulx_f32 (float32x2_t a, float32x2_t b)
A64: FMULX Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vmulx_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulx_f32)

## vmulx_f64

`vmulx_f64`

float64x1_t vmulx_f64 (float64x1_t a, float64x1_t b)
A64: FMULX Dd, Dn, Dm


Instruction Documentation: [vmulx_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulx_f64)

## vmulx_lane_f32

`vmulx_lane_f32`

float32x2_t vmulx_lane_f32 (float32x2_t a, float32x2_t v, const int lane)
A64: FMULX Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmulx_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulx_lane_f32)

## vmulx_laneq_f32

`vmulx_laneq_f32`

float32x2_t vmulx_laneq_f32 (float32x2_t a, float32x4_t v, const int lane)
A64: FMULX Vd.2S, Vn.2S, Vm.S[lane]


Instruction Documentation: [vmulx_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulx_laneq_f32)

## vmulxd_laneq_f64

`vmulxd_laneq_f64`

float64_t vmulxd_laneq_f64 (float64_t a, float64x2_t v, const int lane)
A64: FMULX Dd, Dn, Vm.D[lane]


Instruction Documentation: [vmulxd_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxd_laneq_f64)

## vmulxq_f32

`vmulxq_f32`

float32x4_t vmulxq_f32 (float32x4_t a, float32x4_t b)
A64: FMULX Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vmulxq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxq_f32)

## vmulxq_f64

`vmulxq_f64`

float64x2_t vmulxq_f64 (float64x2_t a, float64x2_t b)
A64: FMULX Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vmulxq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxq_f64)

## vmulxq_lane_f32

`vmulxq_lane_f32`

float32x4_t vmulxq_lane_f32 (float32x4_t a, float32x2_t v, const int lane)
A64: FMULX Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmulxq_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxq_lane_f32)

## vmulxq_lane_f64

`vmulxq_lane_f64`

float64x2_t vmulxq_lane_f64 (float64x2_t a, float64x1_t v, const int lane)
A64: FMULX Vd.2D, Vn.2D, Vm.D[0]


Instruction Documentation: [vmulxq_lane_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxq_lane_f64)

## vmulxq_laneq_f32

`vmulxq_laneq_f32`

float32x4_t vmulxq_laneq_f32 (float32x4_t a, float32x4_t v, const int lane)
A64: FMULX Vd.4S, Vn.4S, Vm.S[lane]


Instruction Documentation: [vmulxq_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxq_laneq_f32)

## vmulxq_laneq_f64

`vmulxq_laneq_f64`

float64x2_t vmulxq_laneq_f64 (float64x2_t a, float64x2_t v, const int lane)
A64: FMULX Vd.2D, Vn.2D, Vm.D[lane]


Instruction Documentation: [vmulxq_laneq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxq_laneq_f64)

## vmulxs_f32

`vmulxs_f32`

float32_t vmulxs_f32 (float32_t a, float32_t b)
A64: FMULX Sd, Sn, Sm


Instruction Documentation: [vmulxs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxs_f32)

## vmulxs_lane_f32

`vmulxs_lane_f32`

float32_t vmulxs_lane_f32 (float32_t a, float32x2_t v, const int lane)
A64: FMULX Sd, Sn, Vm.S[lane]


Instruction Documentation: [vmulxs_lane_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxs_lane_f32)

## vmulxs_laneq_f32

`vmulxs_laneq_f32`

float32_t vmulxs_laneq_f32 (float32_t a, float32x4_t v, const int lane)
A64: FMULX Sd, Sn, Vm.S[lane]


Instruction Documentation: [vmulxs_laneq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vmulxs_laneq_f32)

## vneg_s64

`vneg_s64`

int64x1_t vneg_s64 (int64x1_t a)
A64: NEG Dd, Dn


Instruction Documentation: [vneg_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vneg_s64)

## vnegq_f64

`vnegq_f64`

float64x2_t vnegq_f64 (float64x2_t a)
A64: FNEG Vd.2D, Vn.2D


Instruction Documentation: [vnegq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vnegq_f64)

## vnegq_s64

`vnegq_s64`

int64x2_t vnegq_s64 (int64x2_t a)
A64: NEG Vd.2D, Vn.2D


Instruction Documentation: [vnegq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vnegq_s64)

## vpaddd_f64

`vpaddd_f64`

float64_t vpaddd_f64 (float64x2_t a)
A64: FADDP Dd, Vn.2D


Instruction Documentation: [vpaddd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddd_f64)

## vpaddd_s64

`vpaddd_s64`

int64_t vpaddd_s64 (int64x2_t a)
A64: ADDP Dd, Vn.2D


Instruction Documentation: [vpaddd_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddd_s64)

## vpaddd_u64

`vpaddd_u64`

uint64_t vpaddd_u64 (uint64x2_t a)
A64: ADDP Dd, Vn.2D


Instruction Documentation: [vpaddd_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddd_u64)

## vpaddq_f32

`vpaddq_f32`

float32x4_t vpaddq_f32 (float32x4_t a, float32x4_t b)
A64: FADDP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpaddq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_f32)

## vpaddq_f64

`vpaddq_f64`

float64x2_t vpaddq_f64 (float64x2_t a, float64x2_t b)
A64: FADDP Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vpaddq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_f64)

## vpaddq_s16

`vpaddq_s16`

int16x8_t vpaddq_s16 (int16x8_t a, int16x8_t b)
A64: ADDP Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vpaddq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_s16)

## vpaddq_s32

`vpaddq_s32`

int32x4_t vpaddq_s32 (int32x4_t a, int32x4_t b)
A64: ADDP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpaddq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_s32)

## vpaddq_s64

`vpaddq_s64`

int64x2_t vpaddq_s64 (int64x2_t a, int64x2_t b)
A64: ADDP Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vpaddq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_s64)

## vpaddq_s8

`vpaddq_s8`

int8x16_t vpaddq_s8 (int8x16_t a, int8x16_t b)
A64: ADDP Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vpaddq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_s8)

## vpaddq_u16

`vpaddq_u16`

uint16x8_t vpaddq_u16 (uint16x8_t a, uint16x8_t b)
A64: ADDP Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vpaddq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_u16)

## vpaddq_u32

`vpaddq_u32`

uint32x4_t vpaddq_u32 (uint32x4_t a, uint32x4_t b)
A64: ADDP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpaddq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_u32)

## vpaddq_u64

`vpaddq_u64`

uint64x2_t vpaddq_u64 (uint64x2_t a, uint64x2_t b)
A64: ADDP Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vpaddq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_u64)

## vpaddq_u8

`vpaddq_u8`

uint8x16_t vpaddq_u8 (uint8x16_t a, uint8x16_t b)
A64: ADDP Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vpaddq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpaddq_u8)

## vpadds_f32

`vpadds_f32`

float32_t vpadds_f32 (float32x2_t a)
A64: FADDP Sd, Vn.2S


Instruction Documentation: [vpadds_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpadds_f32)

## vpmaxnm_f32

`vpmaxnm_f32`

float32x2_t vpmaxnm_f32 (float32x2_t a, float32x2_t b)
A64: FMAXNMP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpmaxnm_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxnm_f32)

## vpmaxnmq_f32

`vpmaxnmq_f32`

float32x4_t vpmaxnmq_f32 (float32x4_t a, float32x4_t b)
A64: FMAXNMP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpmaxnmq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxnmq_f32)

## vpmaxnmq_f64

`vpmaxnmq_f64`

float64x2_t vpmaxnmq_f64 (float64x2_t a, float64x2_t b)
A64: FMAXNMP Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vpmaxnmq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxnmq_f64)

## vpmaxnmqd_f64

`vpmaxnmqd_f64`

float64_t vpmaxnmqd_f64 (float64x2_t a)
A64: FMAXNMP Dd, Vn.2D


Instruction Documentation: [vpmaxnmqd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxnmqd_f64)

## vpmaxnms_f32

`vpmaxnms_f32`

float32_t vpmaxnms_f32 (float32x2_t a)
A64: FMAXNMP Sd, Vn.2S


Instruction Documentation: [vpmaxnms_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxnms_f32)

## vpmaxq_f32

`vpmaxq_f32`

float32x4_t vpmaxq_f32 (float32x4_t a, float32x4_t b)
A64: FMAXP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpmaxq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxq_f32)

## vpmaxq_f64

`vpmaxq_f64`

float64x2_t vpmaxq_f64 (float64x2_t a, float64x2_t b)
A64: FMAXP Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vpmaxq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxq_f64)

## vpmaxq_s16

`vpmaxq_s16`

int16x8_t vpmaxq_s16 (int16x8_t a, int16x8_t b)
A64: SMAXP Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vpmaxq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxq_s16)

## vpmaxq_s32

`vpmaxq_s32`

int32x4_t vpmaxq_s32 (int32x4_t a, int32x4_t b)
A64: SMAXP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpmaxq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxq_s32)

## vpmaxq_s8

`vpmaxq_s8`

int8x16_t vpmaxq_s8 (int8x16_t a, int8x16_t b)
A64: SMAXP Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vpmaxq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxq_s8)

## vpmaxq_u16

`vpmaxq_u16`

uint16x8_t vpmaxq_u16 (uint16x8_t a, uint16x8_t b)
A64: UMAXP Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vpmaxq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxq_u16)

## vpmaxq_u32

`vpmaxq_u32`

uint32x4_t vpmaxq_u32 (uint32x4_t a, uint32x4_t b)
A64: UMAXP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpmaxq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxq_u32)

## vpmaxq_u8

`vpmaxq_u8`

uint8x16_t vpmaxq_u8 (uint8x16_t a, uint8x16_t b)
A64: UMAXP Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vpmaxq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxq_u8)

## vpmaxqd_f64

`vpmaxqd_f64`

float64_t vpmaxqd_f64 (float64x2_t a)
A64: FMAXP Dd, Vn.2D


Instruction Documentation: [vpmaxqd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxqd_f64)

## vpmaxs_f32

`vpmaxs_f32`

float32_t vpmaxs_f32 (float32x2_t a)
A64: FMAXP Sd, Vn.2S


Instruction Documentation: [vpmaxs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmaxs_f32)

## vpminnm_f32

`vpminnm_f32`

float32x2_t vpminnm_f32 (float32x2_t a, float32x2_t b)
A64: FMINNMP Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vpminnm_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminnm_f32)

## vpminnmq_f32

`vpminnmq_f32`

float32x4_t vpminnmq_f32 (float32x4_t a, float32x4_t b)
A64: FMINNMP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpminnmq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminnmq_f32)

## vpminnmq_f64

`vpminnmq_f64`

float64x2_t vpminnmq_f64 (float64x2_t a, float64x2_t b)
A64: FMINNMP Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vpminnmq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminnmq_f64)

## vpminnmqd_f64

`vpminnmqd_f64`

float64_t vpminnmqd_f64 (float64x2_t a)
A64: FMINNMP Dd, Vn.2D


Instruction Documentation: [vpminnmqd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminnmqd_f64)

## vpminnms_f32

`vpminnms_f32`

float32_t vpminnms_f32 (float32x2_t a)
A64: FMINNMP Sd, Vn.2S


Instruction Documentation: [vpminnms_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminnms_f32)

## vpminq_f32

`vpminq_f32`

float32x4_t vpminq_f32 (float32x4_t a, float32x4_t b)
A64: FMINP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpminq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminq_f32)

## vpminq_f64

`vpminq_f64`

float64x2_t vpminq_f64 (float64x2_t a, float64x2_t b)
A64: FMINP Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vpminq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminq_f64)

## vpminq_s16

`vpminq_s16`

int16x8_t vpminq_s16 (int16x8_t a, int16x8_t b)
A64: SMINP Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vpminq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminq_s16)

## vpminq_s32

`vpminq_s32`

int32x4_t vpminq_s32 (int32x4_t a, int32x4_t b)
A64: SMINP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpminq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminq_s32)

## vpminq_s8

`vpminq_s8`

int8x16_t vpminq_s8 (int8x16_t a, int8x16_t b)
A64: SMINP Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vpminq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminq_s8)

## vpminq_u16

`vpminq_u16`

uint16x8_t vpminq_u16 (uint16x8_t a, uint16x8_t b)
A64: UMINP Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vpminq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminq_u16)

## vpminq_u32

`vpminq_u32`

uint32x4_t vpminq_u32 (uint32x4_t a, uint32x4_t b)
A64: UMINP Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vpminq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminq_u32)

## vpminq_u8

`vpminq_u8`

uint8x16_t vpminq_u8 (uint8x16_t a, uint8x16_t b)
A64: UMINP Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vpminq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminq_u8)

## vpminqd_f64

`vpminqd_f64`

float64_t vpminqd_f64 (float64x2_t a)
A64: FMINP Dd, Vn.2D


Instruction Documentation: [vpminqd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpminqd_f64)

## vpmins_f32

`vpmins_f32`

float32_t vpmins_f32 (float32x2_t a)
A64: FMINP Sd, Vn.2S


Instruction Documentation: [vpmins_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vpmins_f32)

## vqabsb_s8

`vqabsb_s8`

int8_t vqabsb_s8 (int8_t a)
A64: SQABS Bd, Bn


Instruction Documentation: [vqabsb_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabsb_s8)

## vqabsd_s64

`vqabsd_s64`

int64_t vqabsd_s64 (int64_t a)
A64: SQABS Dd, Dn


Instruction Documentation: [vqabsd_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabsd_s64)

## vqabsh_s16

`vqabsh_s16`

int16_t vqabsh_s16 (int16_t a)
A64: SQABS Hd, Hn


Instruction Documentation: [vqabsh_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabsh_s16)

## vqabsq_s64

`vqabsq_s64`

int64x2_t vqabsq_s64 (int64x2_t a)
A64: SQABS Vd.2D, Vn.2D


Instruction Documentation: [vqabsq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabsq_s64)

## vqabss_s32

`vqabss_s32`

int32_t vqabss_s32 (int32_t a)
A64: SQABS Sd, Sn


Instruction Documentation: [vqabss_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqabss_s32)

## vqaddb_s8

`vqaddb_s8`

int8_t vqaddb_s8 (int8_t a, int8_t b)
A64: SQADD Bd, Bn, Bm


Instruction Documentation: [vqaddb_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddb_s8)

## vqaddb_u8

`vqaddb_u8`

uint8_t vqaddb_u8 (uint8_t a, uint8_t b)
A64: UQADD Bd, Bn, Bm


Instruction Documentation: [vqaddb_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddb_u8)

## vqaddh_s16

`vqaddh_s16`

int16_t vqaddh_s16 (int16_t a, int16_t b)
A64: SQADD Hd, Hn, Hm


Instruction Documentation: [vqaddh_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddh_s16)

## vqaddh_u16

`vqaddh_u16`

uint16_t vqaddh_u16 (uint16_t a, uint16_t b)
A64: UQADD Hd, Hn, Hm


Instruction Documentation: [vqaddh_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqaddh_u16)

## vqadds_s32

`vqadds_s32`

int32_t vqadds_s32 (int32_t a, int32_t b)
A64: SQADD Sd, Sn, Sm


Instruction Documentation: [vqadds_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadds_s32)

## vqadds_u32

`vqadds_u32`

uint32_t vqadds_u32 (uint32_t a, uint32_t b)
A64: UQADD Sd, Sn, Sm


Instruction Documentation: [vqadds_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqadds_u32)

## vqnegb_s8

`vqnegb_s8`

int8_t vqnegb_s8 (int8_t a)
A64: SQNEG Bd, Bn


Instruction Documentation: [vqnegb_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqnegb_s8)

## vqnegd_s64

`vqnegd_s64`

int64_t vqnegd_s64 (int64_t a)
A64: SQNEG Dd, Dn


Instruction Documentation: [vqnegd_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqnegd_s64)

## vqnegh_s16

`vqnegh_s16`

int16_t vqnegh_s16 (int16_t a)
A64: SQNEG Hd, Hn


Instruction Documentation: [vqnegh_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqnegh_s16)

## vqnegq_s64

`vqnegq_s64`

int64x2_t vqnegq_s64 (int64x2_t a)
A64: SQNEG Vd.2D, Vn.2D


Instruction Documentation: [vqnegq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqnegq_s64)

## vqnegs_s32

`vqnegs_s32`

int32_t vqnegs_s32 (int32_t a)
A64: SQNEG Sd, Sn


Instruction Documentation: [vqnegs_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqnegs_s32)

## vqrshlb_s8

`vqrshlb_s8`

int8_t vqrshlb_s8 (int8_t a, int8_t b)
A64: SQRSHL Bd, Bn, Bm


Instruction Documentation: [vqrshlb_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlb_s8)

## vqrshlb_u8

`vqrshlb_u8`

uint8_t vqrshlb_u8 (uint8_t a, int8_t b)
A64: UQRSHL Bd, Bn, Bm


Instruction Documentation: [vqrshlb_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlb_u8)

## vqrshlh_s16

`vqrshlh_s16`

int16_t vqrshlh_s16 (int16_t a, int16_t b)
A64: SQRSHL Hd, Hn, Hm


Instruction Documentation: [vqrshlh_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlh_s16)

## vqrshlh_u16

`vqrshlh_u16`

uint16_t vqrshlh_u16 (uint16_t a, int16_t b)
A64: UQRSHL Hd, Hn, Hm


Instruction Documentation: [vqrshlh_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshlh_u16)

## vqrshls_s32

`vqrshls_s32`

int32_t vqrshls_s32 (int32_t a, int32_t b)
A64: SQRSHL Sd, Sn, Sm


Instruction Documentation: [vqrshls_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshls_s32)

## vqrshls_u32

`vqrshls_u32`

uint32_t vqrshls_u32 (uint32_t a, int32_t b)
A64: UQRSHL Sd, Sn, Sm


Instruction Documentation: [vqrshls_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshls_u32)

## vqrshrnd_n_s64

`vqrshrnd_n_s64`

int32_t vqrshrnd_n_s64 (int64_t a, const int n)
A64: SQRSHRN Sd, Dn, #n


Instruction Documentation: [vqrshrnd_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrnd_n_s64)

## vqrshrnd_n_u64

`vqrshrnd_n_u64`

uint32_t vqrshrnd_n_u64 (uint64_t a, const int n)
A64: UQRSHRN Sd, Dn, #n


Instruction Documentation: [vqrshrnd_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrnd_n_u64)

## vqrshrnh_n_s16

`vqrshrnh_n_s16`

int8_t vqrshrnh_n_s16 (int16_t a, const int n)
A64: SQRSHRN Bd, Hn, #n


Instruction Documentation: [vqrshrnh_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrnh_n_s16)

## vqrshrnh_n_u16

`vqrshrnh_n_u16`

uint8_t vqrshrnh_n_u16 (uint16_t a, const int n)
A64: UQRSHRN Bd, Hn, #n


Instruction Documentation: [vqrshrnh_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrnh_n_u16)

## vqrshrns_n_s32

`vqrshrns_n_s32`

int16_t vqrshrns_n_s32 (int32_t a, const int n)
A64: SQRSHRN Hd, Sn, #n


Instruction Documentation: [vqrshrns_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrns_n_s32)

## vqrshrns_n_u32

`vqrshrns_n_u32`

uint16_t vqrshrns_n_u32 (uint32_t a, const int n)
A64: UQRSHRN Hd, Sn, #n


Instruction Documentation: [vqrshrns_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrns_n_u32)

## vqrshrund_n_s64

`vqrshrund_n_s64`

uint32_t vqrshrund_n_s64 (int64_t a, const int n)
A64: SQRSHRUN Sd, Dn, #n


Instruction Documentation: [vqrshrund_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrund_n_s64)

## vqrshrunh_n_s16

`vqrshrunh_n_s16`

uint8_t vqrshrunh_n_s16 (int16_t a, const int n)
A64: SQRSHRUN Bd, Hn, #n


Instruction Documentation: [vqrshrunh_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshrunh_n_s16)

## vqrshruns_n_s32

`vqrshruns_n_s32`

uint16_t vqrshruns_n_s32 (int32_t a, const int n)
A64: SQRSHRUN Hd, Sn, #n


Instruction Documentation: [vqrshruns_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqrshruns_n_s32)

## vqshlb_n_s8

`vqshlb_n_s8`

int8_t vqshlb_n_s8 (int8_t a, const int n)
A64: SQSHL Bd, Bn, #n


Instruction Documentation: [vqshlb_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlb_n_s8)

## vqshlb_n_u8

`vqshlb_n_u8`

uint8_t vqshlb_n_u8 (uint8_t a, const int n)
A64: UQSHL Bd, Bn, #n


Instruction Documentation: [vqshlb_n_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlb_n_u8)

## vqshlb_s8

`vqshlb_s8`

int8_t vqshlb_s8 (int8_t a, int8_t b)
A64: SQSHL Bd, Bn, Bm


Instruction Documentation: [vqshlb_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlb_s8)

## vqshlb_u8

`vqshlb_u8`

uint8_t vqshlb_u8 (uint8_t a, int8_t b)
A64: UQSHL Bd, Bn, Bm


Instruction Documentation: [vqshlb_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlb_u8)

## vqshlh_n_s16

`vqshlh_n_s16`

int16_t vqshlh_n_s16 (int16_t a, const int n)
A64: SQSHL Hd, Hn, #n


Instruction Documentation: [vqshlh_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlh_n_s16)

## vqshlh_n_u16

`vqshlh_n_u16`

uint16_t vqshlh_n_u16 (uint16_t a, const int n)
A64: UQSHL Hd, Hn, #n


Instruction Documentation: [vqshlh_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlh_n_u16)

## vqshlh_s16

`vqshlh_s16`

int16_t vqshlh_s16 (int16_t a, int16_t b)
A64: SQSHL Hd, Hn, Hm


Instruction Documentation: [vqshlh_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlh_s16)

## vqshlh_u16

`vqshlh_u16`

uint16_t vqshlh_u16 (uint16_t a, int16_t b)
A64: UQSHL Hd, Hn, Hm


Instruction Documentation: [vqshlh_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlh_u16)

## vqshls_n_s32

`vqshls_n_s32`

int32_t vqshls_n_s32 (int32_t a, const int n)
A64: SQSHL Sd, Sn, #n


Instruction Documentation: [vqshls_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshls_n_s32)

## vqshls_n_u32

`vqshls_n_u32`

uint32_t vqshls_n_u32 (uint32_t a, const int n)
A64: UQSHL Sd, Sn, #n


Instruction Documentation: [vqshls_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshls_n_u32)

## vqshls_s32

`vqshls_s32`

int32_t vqshls_s32 (int32_t a, int32_t b)
A64: SQSHL Sd, Sn, Sm


Instruction Documentation: [vqshls_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshls_s32)

## vqshls_u32

`vqshls_u32`

uint32_t vqshls_u32 (uint32_t a, int32_t b)
A64: UQSHL Sd, Sn, Sm


Instruction Documentation: [vqshls_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshls_u32)

## vqshlub_n_s8

`vqshlub_n_s8`

uint8_t vqshlub_n_s8 (int8_t a, const int n)
A64: SQSHLU Bd, Bn, #n


Instruction Documentation: [vqshlub_n_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlub_n_s8)

## vqshluh_n_s16

`vqshluh_n_s16`

uint16_t vqshluh_n_s16 (int16_t a, const int n)
A64: SQSHLU Hd, Hn, #n


Instruction Documentation: [vqshluh_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshluh_n_s16)

## vqshlus_n_s32

`vqshlus_n_s32`

uint32_t vqshlus_n_s32 (int32_t a, const int n)
A64: SQSHLU Sd, Sn, #n


Instruction Documentation: [vqshlus_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshlus_n_s32)

## vqshrnd_n_s64

`vqshrnd_n_s64`

int32_t vqshrnd_n_s64 (int64_t a, const int n)
A64: SQSHRN Sd, Dn, #n


Instruction Documentation: [vqshrnd_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrnd_n_s64)

## vqshrnd_n_u64

`vqshrnd_n_u64`

uint32_t vqshrnd_n_u64 (uint64_t a, const int n)
A64: UQSHRN Sd, Dn, #n


Instruction Documentation: [vqshrnd_n_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrnd_n_u64)

## vqshrnh_n_s16

`vqshrnh_n_s16`

int8_t vqshrnh_n_s16 (int16_t a, const int n)
A64: SQSHRN Bd, Hn, #n


Instruction Documentation: [vqshrnh_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrnh_n_s16)

## vqshrnh_n_u16

`vqshrnh_n_u16`

uint8_t vqshrnh_n_u16 (uint16_t a, const int n)
A64: UQSHRN Bd, Hn, #n


Instruction Documentation: [vqshrnh_n_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrnh_n_u16)

## vqshrns_n_s32

`vqshrns_n_s32`

int16_t vqshrns_n_s32 (int32_t a, const int n)
A64: SQSHRN Hd, Sn, #n


Instruction Documentation: [vqshrns_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrns_n_s32)

## vqshrns_n_u32

`vqshrns_n_u32`

uint16_t vqshrns_n_u32 (uint32_t a, const int n)
A64: UQSHRN Hd, Sn, #n


Instruction Documentation: [vqshrns_n_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrns_n_u32)

## vqshrund_n_s64

`vqshrund_n_s64`

uint32_t vqshrund_n_s64 (int64_t a, const int n)
A64: SQSHRUN Sd, Dn, #n


Instruction Documentation: [vqshrund_n_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrund_n_s64)

## vqshrunh_n_s16

`vqshrunh_n_s16`

uint8_t vqshrunh_n_s16 (int16_t a, const int n)
A64: SQSHRUN Bd, Hn, #n


Instruction Documentation: [vqshrunh_n_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshrunh_n_s16)

## vqshruns_n_s32

`vqshruns_n_s32`

uint16_t vqshruns_n_s32 (int32_t a, const int n)
A64: SQSHRUN Hd, Sn, #n


Instruction Documentation: [vqshruns_n_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqshruns_n_s32)

## vqsubb_s8

`vqsubb_s8`

int8_t vqsubb_s8 (int8_t a, int8_t b)
A64: SQSUB Bd, Bn, Bm


Instruction Documentation: [vqsubb_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubb_s8)

## vqsubb_u8

`vqsubb_u8`

uint8_t vqsubb_u8 (uint8_t a, uint8_t b)
A64: UQSUB Bd, Bn, Bm


Instruction Documentation: [vqsubb_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubb_u8)

## vqsubh_s16

`vqsubh_s16`

int16_t vqsubh_s16 (int16_t a, int16_t b)
A64: SQSUB Hd, Hn, Hm


Instruction Documentation: [vqsubh_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubh_s16)

## vqsubh_u16

`vqsubh_u16`

uint16_t vqsubh_u16 (uint16_t a, uint16_t b)
A64: UQSUB Hd, Hn, Hm


Instruction Documentation: [vqsubh_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubh_u16)

## vqsubs_s32

`vqsubs_s32`

int32_t vqsubs_s32 (int32_t a, int32_t b)
A64: SQSUB Sd, Sn, Sm


Instruction Documentation: [vqsubs_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubs_s32)

## vqsubs_u32

`vqsubs_u32`

uint32_t vqsubs_u32 (uint32_t a, uint32_t b)
A64: UQSUB Sd, Sn, Sm


Instruction Documentation: [vqsubs_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqsubs_u32)

## vqvtbl1q_s8

`vqvtbl1q_s8`

int8x16_t vqvtbl1q_s8(int8x16_t t, uint8x16_t idx)
A64: TBL Vd.16B, {Vn.16B}, Vm.16B


Instruction Documentation: [vqvtbl1q_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqvtbl1q_s8)

## vqvtbl1q_u8

`vqvtbl1q_u8`

uint8x16_t vqvtbl1q_u8(uint8x16_t t, uint8x16_t idx)
A64: TBL Vd.16B, {Vn.16B}, Vm.16B


Instruction Documentation: [vqvtbl1q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqvtbl1q_u8)

## vqvtbx1q_s8

`vqvtbx1q_s8`

int8x16_t vqvtbx1q_s8(int8x16_t r, int8x16_t t, uint8x16_t idx)
A64: TBX Vd.16B, {Vn.16B}, Vm.16B


Instruction Documentation: [vqvtbx1q_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqvtbx1q_s8)

## vqvtbx1q_u8

`vqvtbx1q_u8`

uint8x16_t vqvtbx1q_u8(uint8x16_t r, int8x16_t t, uint8x16_t idx)
A64: TBX Vd.16B, {Vn.16B}, Vm.16B


Instruction Documentation: [vqvtbx1q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vqvtbx1q_u8)

## vrbit_s8

`vrbit_s8`

int8x8_t vrbit_s8 (int8x8_t a)
A64: RBIT Vd.8B, Vn.8B


Instruction Documentation: [vrbit_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrbit_s8)

## vrbit_u8

`vrbit_u8`

uint8x8_t vrbit_u8 (uint8x8_t a)
A64: RBIT Vd.8B, Vn.8B


Instruction Documentation: [vrbit_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrbit_u8)

## vrbitq_s8

`vrbitq_s8`

int8x16_t vrbitq_s8 (int8x16_t a)
A64: RBIT Vd.16B, Vn.16B


Instruction Documentation: [vrbitq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrbitq_s8)

## vrbitq_u8

`vrbitq_u8`

uint8x16_t vrbitq_u8 (uint8x16_t a)
A64: RBIT Vd.16B, Vn.16B


Instruction Documentation: [vrbitq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrbitq_u8)

## vrecpe_f64

`vrecpe_f64`

float64x1_t vrecpe_f64 (float64x1_t a)
A64: FRECPE Dd, Dn


Instruction Documentation: [vrecpe_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpe_f64)

## vrecpeq_f64

`vrecpeq_f64`

float64x2_t vrecpeq_f64 (float64x2_t a)
A64: FRECPE Vd.2D, Vn.2D


Instruction Documentation: [vrecpeq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpeq_f64)

## vrecpes_f32

`vrecpes_f32`

float32_t vrecpes_f32 (float32_t a)
A64: FRECPE Sd, Sn


Instruction Documentation: [vrecpes_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpes_f32)

## vrecps_f64

`vrecps_f64`

float64x1_t vrecps_f64 (float64x1_t a, float64x1_t b)
A64: FRECPS Dd, Dn, Dm


Instruction Documentation: [vrecps_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecps_f64)

## vrecpsq_f64

`vrecpsq_f64`

float64x2_t vrecpsq_f64 (float64x2_t a, float64x2_t b)
A64: FRECPS Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vrecpsq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpsq_f64)

## vrecpss_f32

`vrecpss_f32`

float32_t vrecpss_f32 (float32_t a, float32_t b)
A64: FRECPS Sd, Sn, Sm


Instruction Documentation: [vrecpss_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpss_f32)

## vrecpxd_f64

`vrecpxd_f64`

float64_t vrecpxd_f64 (float64_t a)
A64: FRECPX Dd, Dn


Instruction Documentation: [vrecpxd_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpxd_f64)

## vrecpxs_f32

`vrecpxs_f32`

float32_t vrecpxs_f32 (float32_t a)
A64: FRECPX Sd, Sn


Instruction Documentation: [vrecpxs_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrecpxs_f32)

## vrndaq_f64

`vrndaq_f64`

float64x2_t vrndaq_f64 (float64x2_t a)
A64: FRINTA Vd.2D, Vn.2D


Instruction Documentation: [vrndaq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndaq_f64)

## vrndmq_f64

`vrndmq_f64`

float64x2_t vrndmq_f64 (float64x2_t a)
A64: FRINTM Vd.2D, Vn.2D


Instruction Documentation: [vrndmq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndmq_f64)

## vrndnq_f64

`vrndnq_f64`

float64x2_t vrndnq_f64 (float64x2_t a)
A64: FRINTN Vd.2D, Vn.2D


Instruction Documentation: [vrndnq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndnq_f64)

## vrndpq_f64

`vrndpq_f64`

float64x2_t vrndpq_f64 (float64x2_t a)
A64: FRINTP Vd.2D, Vn.2D


Instruction Documentation: [vrndpq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndpq_f64)

## vrndq_f64

`vrndq_f64`

float64x2_t vrndq_f64 (float64x2_t a)
A64: FRINTZ Vd.2D, Vn.2D


Instruction Documentation: [vrndq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrndq_f64)

## vrsqrte_f64

`vrsqrte_f64`

float64x1_t vrsqrte_f64 (float64x1_t a)
A64: FRSQRTE Dd, Dn


Instruction Documentation: [vrsqrte_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrte_f64)

## vrsqrteq_f64

`vrsqrteq_f64`

float64x2_t vrsqrteq_f64 (float64x2_t a)
A64: FRSQRTE Vd.2D, Vn.2D


Instruction Documentation: [vrsqrteq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrteq_f64)

## vrsqrtes_f32

`vrsqrtes_f32`

float32_t vrsqrtes_f32 (float32_t a)
A64: FRSQRTE Sd, Sn


Instruction Documentation: [vrsqrtes_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrtes_f32)

## vrsqrts_f64

`vrsqrts_f64`

float64x1_t vrsqrts_f64 (float64x1_t a, float64x1_t b)
A64: FRSQRTS Dd, Dn, Dm


Instruction Documentation: [vrsqrts_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrts_f64)

## vrsqrtsq_f64

`vrsqrtsq_f64`

float64x2_t vrsqrtsq_f64 (float64x2_t a, float64x2_t b)
A64: FRSQRTS Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vrsqrtsq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrtsq_f64)

## vrsqrtss_f32

`vrsqrtss_f32`

float32_t vrsqrtss_f32 (float32_t a, float32_t b)
A64: FRSQRTS Sd, Sn, Sm


Instruction Documentation: [vrsqrtss_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vrsqrtss_f32)

## vsqadd_u16

`vsqadd_u16`

uint16x4_t vsqadd_u16 (uint16x4_t a, int16x4_t b)
A64: USQADD Vd.4H, Vn.4H


Instruction Documentation: [vsqadd_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqadd_u16)

## vsqadd_u32

`vsqadd_u32`

uint32x2_t vsqadd_u32 (uint32x2_t a, int32x2_t b)
A64: USQADD Vd.2S, Vn.2S


Instruction Documentation: [vsqadd_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqadd_u32)

## vsqadd_u64

`vsqadd_u64`

uint64x1_t vsqadd_u64 (uint64x1_t a, int64x1_t b)
A64: USQADD Dd, Dn


Instruction Documentation: [vsqadd_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqadd_u64)

## vsqadd_u8

`vsqadd_u8`

uint8x8_t vsqadd_u8 (uint8x8_t a, int8x8_t b)
A64: USQADD Vd.8B, Vn.8B


Instruction Documentation: [vsqadd_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqadd_u8)

## vsqaddb_u8

`vsqaddb_u8`

uint8_t vsqaddb_u8 (uint8_t a, int8_t b)
A64: USQADD Bd, Bn


Instruction Documentation: [vsqaddb_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqaddb_u8)

## vsqaddh_u16

`vsqaddh_u16`

uint16_t vsqaddh_u16 (uint16_t a, int16_t b)
A64: USQADD Hd, Hn


Instruction Documentation: [vsqaddh_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqaddh_u16)

## vsqaddq_u16

`vsqaddq_u16`

uint16x8_t vsqaddq_u16 (uint16x8_t a, int16x8_t b)
A64: USQADD Vd.8H, Vn.8H


Instruction Documentation: [vsqaddq_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqaddq_u16)

## vsqaddq_u32

`vsqaddq_u32`

uint32x4_t vsqaddq_u32 (uint32x4_t a, int32x4_t b)
A64: USQADD Vd.4S, Vn.4S


Instruction Documentation: [vsqaddq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqaddq_u32)

## vsqaddq_u64

`vsqaddq_u64`

uint64x2_t vsqaddq_u64 (uint64x2_t a, int64x2_t b)
A64: USQADD Vd.2D, Vn.2D


Instruction Documentation: [vsqaddq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqaddq_u64)

## vsqaddq_u8

`vsqaddq_u8`

uint8x16_t vsqaddq_u8 (uint8x16_t a, int8x16_t b)
A64: USQADD Vd.16B, Vn.16B


Instruction Documentation: [vsqaddq_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqaddq_u8)

## vsqadds_u32

`vsqadds_u32`

uint32_t vsqadds_u32 (uint32_t a, int32_t b)
A64: USQADD Sd, Sn


Instruction Documentation: [vsqadds_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqadds_u32)

## vsqrt_f32

`vsqrt_f32`

float32x2_t vsqrt_f32 (float32x2_t a)
A64: FSQRT Vd.2S, Vn.2S


Instruction Documentation: [vsqrt_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqrt_f32)

## vsqrtq_f32

`vsqrtq_f32`

float32x4_t vsqrtq_f32 (float32x4_t a)
A64: FSQRT Vd.4S, Vn.4S


Instruction Documentation: [vsqrtq_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqrtq_f32)

## vsqrtq_f64

`vsqrtq_f64`

float64x2_t vsqrtq_f64 (float64x2_t a)
A64: FSQRT Vd.2D, Vn.2D


Instruction Documentation: [vsqrtq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsqrtq_f64)

## vsubq_f64

`vsubq_f64`

float64x2_t vsubq_f64 (float64x2_t a, float64x2_t b)
A64: FSUB Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vsubq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsubq_f64)

## vtrn1_f32

`vtrn1_f32`

float32x2_t vtrn1_f32(float32x2_t a, float32x2_t b)
A64: TRN1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vtrn1_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1_f32)

## vtrn1_s16

`vtrn1_s16`

int16x4_t vtrn1_s16(int16x4_t a, int16x4_t b)
A64: TRN1 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vtrn1_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1_s16)

## vtrn1_s32

`vtrn1_s32`

int32x2_t vtrn1_s32(int32x2_t a, int32x2_t b)
A64: TRN1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vtrn1_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1_s32)

## vtrn1_s8

`vtrn1_s8`

int8x8_t vtrn1_s8(int8x8_t a, int8x8_t b)
A64: TRN1 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vtrn1_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1_s8)

## vtrn1_u16

`vtrn1_u16`

uint16x4_t vtrn1_u16(uint16x4_t a, uint16x4_t b)
A64: TRN1 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vtrn1_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1_u16)

## vtrn1_u32

`vtrn1_u32`

uint32x2_t vtrn1_u32(uint32x2_t a, uint32x2_t b)
A64: TRN1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vtrn1_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1_u32)

## vtrn1_u8

`vtrn1_u8`

uint8x8_t vtrn1_u8(uint8x8_t a, uint8x8_t b)
A64: TRN1 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vtrn1_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1_u8)

## vtrn1q_f32

`vtrn1q_f32`

float32x4_t vtrn1q_f32(float32x4_t a, float32x4_t b)
A64: TRN1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vtrn1q_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_f32)

## vtrn1q_f64

`vtrn1q_f64`

float64x2_t vtrn1q_f64(float64x2_t a, float64x2_t b)
A64: TRN1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vtrn1q_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_f64)

## vtrn1q_s16

`vtrn1q_s16`

int16x8_t vtrn1q_s16(int16x8_t a, int16x8_t b)
A64: TRN1 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vtrn1q_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_s16)

## vtrn1q_s32

`vtrn1q_s32`

int32x4_t vtrn1q_s32(int32x4_t a, int32x4_t b)
A64: TRN1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vtrn1q_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_s32)

## vtrn1q_s64

`vtrn1q_s64`

int64x2_t vtrn1q_s64(int64x2_t a, int64x2_t b)
A64: TRN1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vtrn1q_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_s64)

## vtrn1q_u16

`vtrn1q_u16`

uint16x8_t vtrn1q_u16(uint16x8_t a, uint16x8_t b)
A64: TRN1 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vtrn1q_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_u16)

## vtrn1q_u32

`vtrn1q_u32`

uint32x4_t vtrn1q_u32(uint32x4_t a, uint32x4_t b)
A64: TRN1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vtrn1q_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_u32)

## vtrn1q_u64

`vtrn1q_u64`

uint64x2_t vtrn1q_u64(uint64x2_t a, uint64x2_t b)
A64: TRN1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vtrn1q_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_u64)

## vtrn1q_u8

`vtrn1q_u8`

uint8x16_t vtrn1q_u8(uint8x16_t a, uint8x16_t b)
A64: TRN1 Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vtrn1q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn1q_u8)

## vtrn2_f32

`vtrn2_f32`

float32x2_t vtrn2_f32(float32x2_t a, float32x2_t b)
A64: TRN2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vtrn2_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2_f32)

## vtrn2_s16

`vtrn2_s16`

int16x4_t vtrn2_s16(int16x4_t a, int16x4_t b)
A64: TRN2 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vtrn2_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2_s16)

## vtrn2_s32

`vtrn2_s32`

int32x2_t vtrn2_s32(int32x2_t a, int32x2_t b)
A64: TRN2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vtrn2_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2_s32)

## vtrn2_s8

`vtrn2_s8`

int8x8_t vtrn2_s8(int8x8_t a, int8x8_t b)
A64: TRN2 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vtrn2_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2_s8)

## vtrn2_u16

`vtrn2_u16`

uint16x4_t vtrn2_u16(uint16x4_t a, uint16x4_t b)
A64: TRN2 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vtrn2_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2_u16)

## vtrn2_u32

`vtrn2_u32`

uint32x2_t vtrn2_u32(uint32x2_t a, uint32x2_t b)
A64: TRN2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vtrn2_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2_u32)

## vtrn2_u8

`vtrn2_u8`

uint8x8_t vtrn2_u8(uint8x8_t a, uint8x8_t b)
A64: TRN2 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vtrn2_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2_u8)

## vtrn2q_f32

`vtrn2q_f32`

float32x4_t vtrn2q_f32(float32x4_t a, float32x4_t b)
A64: TRN2 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vtrn2q_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2q_f32)

## vtrn2q_f64

`vtrn2q_f64`

float64x2_t vtrn2q_f64(float64x2_t a, float64x2_t b)
A64: TRN2 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vtrn2q_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2q_f64)

## vtrn2q_s16

`vtrn2q_s16`

int16x8_t vtrn2q_s16(int16x8_t a, int16x8_t b)
A64: TRN2 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vtrn2q_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2q_s16)

## vtrn2q_s32

`vtrn2q_s32`

int32x4_t vtrn2q_s32(int32x4_t a, int32x4_t b)
A64: TRN2 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vtrn2q_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2q_s32)

## vtrn2q_s64

`vtrn2q_s64`

int64x2_t vtrn2q_s64(int64x2_t a, int64x2_t b)
A64: TRN2 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vtrn2q_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2q_s64)

## vtrn2q_u16

`vtrn2q_u16`

uint16x8_t vtrn2q_u16(uint16x8_t a, uint16x8_t b)
A64: TRN2 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vtrn2q_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2q_u16)

## vtrn2q_u8

`vtrn2q_u8`

uint8x16_t vtrn2q_u8(uint8x16_t a, uint8x16_t b)
A64: TRN2 Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vtrn2q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtrn2q_u8)

## vtst_f64

`vtst_f64`

uint64x1_t vtst_f64 (float64x1_t a, float64x1_t b)
A64: CMTST Dd, Dn, Dm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vtst_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_f64)

## vtst_s64

`vtst_s64`

uint64x1_t vtst_s64 (int64x1_t a, int64x1_t b)
A64: CMTST Dd, Dn, Dm


Instruction Documentation: [vtst_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_s64)

## vtst_u64

`vtst_u64`

uint64x1_t vtst_u64 (uint64x1_t a, uint64x1_t b)
A64: CMTST Dd, Dn, Dm


Instruction Documentation: [vtst_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtst_u64)

## vtstq_f64

`vtstq_f64`

uint64x2_t vtstq_f64 (float64x2_t a, float64x2_t b)
A64: CMTST Vd.2D, Vn.2D, Vm.2D The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.


Instruction Documentation: [vtstq_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_f64)

## vtstq_s64

`vtstq_s64`

uint64x2_t vtstq_s64 (int64x2_t a, int64x2_t b)
A64: CMTST Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vtstq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_s64)

## vtstq_u64

`vtstq_u64`

uint64x2_t vtstq_u64 (uint64x2_t a, uint64x2_t b)
A64: CMTST Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vtstq_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vtstq_u64)

## vuqadd_s16

`vuqadd_s16`

int16x4_t vuqadd_s16 (int16x4_t a, uint16x4_t b)
A64: SUQADD Vd.4H, Vn.4H


Instruction Documentation: [vuqadd_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqadd_s16)

## vuqadd_s32

`vuqadd_s32`

int32x2_t vuqadd_s32 (int32x2_t a, uint32x2_t b)
A64: SUQADD Vd.2S, Vn.2S


Instruction Documentation: [vuqadd_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqadd_s32)

## vuqadd_s64

`vuqadd_s64`

int64x1_t vuqadd_s64 (int64x1_t a, uint64x1_t b)
A64: SUQADD Dd, Dn


Instruction Documentation: [vuqadd_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqadd_s64)

## vuqadd_s8

`vuqadd_s8`

int8x8_t vuqadd_s8 (int8x8_t a, uint8x8_t b)
A64: SUQADD Vd.8B, Vn.8B


Instruction Documentation: [vuqadd_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqadd_s8)

## vuqaddb_s8

`vuqaddb_s8`

int8_t vuqaddb_s8 (int8_t a, uint8_t b)
A64: SUQADD Bd, Bn


Instruction Documentation: [vuqaddb_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqaddb_s8)

## vuqaddh_s16

`vuqaddh_s16`

int16_t vuqaddh_s16 (int16_t a, uint16_t b)
A64: SUQADD Hd, Hn


Instruction Documentation: [vuqaddh_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqaddh_s16)

## vuqaddq_s16

`vuqaddq_s16`

int16x8_t vuqaddq_s16 (int16x8_t a, uint16x8_t b)
A64: SUQADD Vd.8H, Vn.8H


Instruction Documentation: [vuqaddq_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqaddq_s16)

## vuqaddq_s32

`vuqaddq_s32`

int32x4_t vuqaddq_s32 (int32x4_t a, uint32x4_t b)
A64: SUQADD Vd.4S, Vn.4S


Instruction Documentation: [vuqaddq_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqaddq_s32)

## vuqaddq_s64

`vuqaddq_s64`

int64x2_t vuqaddq_s64 (int64x2_t a, uint64x2_t b)
A64: SUQADD Vd.2D, Vn.2D


Instruction Documentation: [vuqaddq_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqaddq_s64)

## vuqaddq_s8

`vuqaddq_s8`

int8x16_t vuqaddq_s8 (int8x16_t a, uint8x16_t b)
A64: SUQADD Vd.16B, Vn.16B


Instruction Documentation: [vuqaddq_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqaddq_s8)

## vuqadds_s32

`vuqadds_s32`

int32_t vuqadds_s32 (int32_t a, uint32_t b)
A64: SUQADD Sd, Sn


Instruction Documentation: [vuqadds_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuqadds_s32)

## vuzp1_f32

`vuzp1_f32`

float32x2_t vuzp1_f32(float32x2_t a, float32x2_t b)
A64: UZP1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vuzp1_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1_f32)

## vuzp1_s16

`vuzp1_s16`

int16x4_t vuzp1_s16(int16x4_t a, int16x4_t b)
A64: UZP1 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vuzp1_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1_s16)

## vuzp1_s32

`vuzp1_s32`

int32x2_t vuzp1_s32(int32x2_t a, int32x2_t b)
A64: UZP1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vuzp1_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1_s32)

## vuzp1_s8

`vuzp1_s8`

int8x8_t vuzp1_s8(int8x8_t a, int8x8_t b)
A64: UZP1 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vuzp1_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1_s8)

## vuzp1_u16

`vuzp1_u16`

uint16x4_t vuzp1_u16(uint16x4_t a, uint16x4_t b)
A64: UZP1 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vuzp1_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1_u16)

## vuzp1_u32

`vuzp1_u32`

uint32x2_t vuzp1_u32(uint32x2_t a, uint32x2_t b)
A64: UZP1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vuzp1_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1_u32)

## vuzp1_u8

`vuzp1_u8`

uint8x8_t vuzp1_u8(uint8x8_t a, uint8x8_t b)
A64: UZP1 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vuzp1_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1_u8)

## vuzp1q_f32

`vuzp1q_f32`

float32x4_t vuzp1q_f32(float32x4_t a, float32x4_t b)
A64: UZP1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vuzp1q_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_f32)

## vuzp1q_f64

`vuzp1q_f64`

float64x2_t vuzp1q_f64(float64x2_t a, float64x2_t b)
A64: UZP1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vuzp1q_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_f64)

## vuzp1q_s16

`vuzp1q_s16`

int16x8_t vuzp1q_s16(int16x8_t a, int16x8_t b)
A64: UZP1 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vuzp1q_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_s16)

## vuzp1q_s32

`vuzp1q_s32`

int32x4_t vuzp1q_s32(int32x4_t a, int32x4_t b)
A64: UZP1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vuzp1q_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_s32)

## vuzp1q_s64

`vuzp1q_s64`

int64x2_t vuzp1q_s64(int64x2_t a, int64x2_t b)
A64: UZP1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vuzp1q_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_s64)

## vuzp1q_u16

`vuzp1q_u16`

uint16x8_t vuzp1q_u16(uint16x8_t a, uint16x8_t b)
A64: UZP1 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vuzp1q_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_u16)

## vuzp1q_u32

`vuzp1q_u32`

uint32x4_t vuzp1q_u32(uint32x4_t a, uint32x4_t b)
A64: UZP1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vuzp1q_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_u32)

## vuzp1q_u64

`vuzp1q_u64`

uint64x2_t vuzp1q_u64(uint64x2_t a, uint64x2_t b)
A64: UZP1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vuzp1q_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_u64)

## vuzp1q_u8

`vuzp1q_u8`

uint8x16_t vuzp1q_u8(uint8x16_t a, uint8x16_t b)
A64: UZP1 Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vuzp1q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp1q_u8)

## vuzp2_f32

`vuzp2_f32`

float32x2_t vuzp2_f32(float32x2_t a, float32x2_t b)
A64: UZP2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vuzp2_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2_f32)

## vuzp2_s16

`vuzp2_s16`

int16x4_t vuzp2_s16(int16x4_t a, int16x4_t b)
A64: UZP2 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vuzp2_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2_s16)

## vuzp2_s32

`vuzp2_s32`

int32x2_t vuzp2_s32(int32x2_t a, int32x2_t b)
A64: UZP2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vuzp2_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2_s32)

## vuzp2_s8

`vuzp2_s8`

int8x8_t vuzp2_s8(int8x8_t a, int8x8_t b)
A64: UZP2 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vuzp2_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2_s8)

## vuzp2_u16

`vuzp2_u16`

uint16x4_t vuzp2_u16(uint16x4_t a, uint16x4_t b)
A64: UZP2 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vuzp2_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2_u16)

## vuzp2_u32

`vuzp2_u32`

uint32x2_t vuzp2_u32(uint32x2_t a, uint32x2_t b)
A64: UZP2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vuzp2_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2_u32)

## vuzp2_u8

`vuzp2_u8`

uint8x8_t vuzp2_u8(uint8x8_t a, uint8x8_t b)
A64: UZP2 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vuzp2_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2_u8)

## vuzp2q_f64

`vuzp2q_f64`

float64x2_t vuzp2q_f64(float64x2_t a, float64x2_t b)
A64: UZP2 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vuzp2q_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2q_f64)

## vuzp2q_s16

`vuzp2q_s16`

int16x8_t vuzp2q_s16(int16x8_t a, int16x8_t b)
A64: UZP2 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vuzp2q_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2q_s16)

## vuzp2q_s32

`vuzp2q_s32`

int32x4_t vuzp2q_s32(int32x4_t a, int32x4_t b)
A64: UZP2 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vuzp2q_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2q_s32)

## vuzp2q_s64

`vuzp2q_s64`

int64x2_t vuzp2q_s64(int64x2_t a, int64x2_t b)
A64: UZP2 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vuzp2q_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2q_s64)

## vuzp2q_u16

`vuzp2q_u16`

uint16x8_t vuzp2q_u16(uint16x8_t a, uint16x8_t b)
A64: UZP2 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vuzp2q_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2q_u16)

## vuzp2q_u32

`vuzp2q_u32`

uint32x4_t vuzp2q_u32(uint32x4_t a, uint32x4_t b)
A64: UZP2 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vuzp2q_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2q_u32)

## vuzp2q_u64

`vuzp2q_u64`

uint64x2_t vuzp2q_u64(uint64x2_t a, uint64x2_t b)
A64: UZP2 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vuzp2q_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2q_u64)

## vuzp2q_u8

`vuzp2q_u8`

uint8x16_t vuzp2q_u8(uint8x16_t a, uint8x16_t b)
A64: UZP2 Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vuzp2q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vuzp2q_u8)

## vzip1_f32

`vzip1_f32`

float32x2_t vzip1_f32(float32x2_t a, float32x2_t b)
A64: ZIP1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vzip1_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1_f32)

## vzip1_s16

`vzip1_s16`

int16x4_t vzip1_s16(int16x4_t a, int16x4_t b)
A64: ZIP1 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vzip1_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1_s16)

## vzip1_s32

`vzip1_s32`

int32x2_t vzip1_s32(int32x2_t a, int32x2_t b)
A64: ZIP1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vzip1_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1_s32)

## vzip1_s8

`vzip1_s8`

int8x8_t vzip1_s8(int8x8_t a, int8x8_t b)
A64: ZIP1 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vzip1_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1_s8)

## vzip1_u16

`vzip1_u16`

uint16x4_t vzip1_u16(uint16x4_t a, uint16x4_t b)
A64: ZIP1 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vzip1_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1_u16)

## vzip1_u32

`vzip1_u32`

uint32x2_t vzip1_u32(uint32x2_t a, uint32x2_t b)
A64: ZIP1 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vzip1_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1_u32)

## vzip1_u8

`vzip1_u8`

uint8x8_t vzip1_u8(uint8x8_t a, uint8x8_t b)
A64: ZIP1 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vzip1_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1_u8)

## vzip1q_f32

`vzip1q_f32`

float32x4_t vzip1q_f32(float32x4_t a, float32x4_t b)
A64: ZIP1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vzip1q_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_f32)

## vzip1q_f64

`vzip1q_f64`

float64x2_t vzip1q_f64(float64x2_t a, float64x2_t b)
A64: ZIP1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vzip1q_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_f64)

## vzip1q_s16

`vzip1q_s16`

int16x8_t vzip1q_s16(int16x8_t a, int16x8_t b)
A64: ZIP1 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vzip1q_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_s16)

## vzip1q_s32

`vzip1q_s32`

int32x4_t vzip1q_s32(int32x4_t a, int32x4_t b)
A64: ZIP1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vzip1q_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_s32)

## vzip1q_s64

`vzip1q_s64`

int64x2_t vzip1q_s64(int64x2_t a, int64x2_t b)
A64: ZIP1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vzip1q_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_s64)

## vzip1q_u16

`vzip1q_u16`

uint16x8_t vzip1q_u16(uint16x8_t a, uint16x8_t b)
A64: ZIP1 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vzip1q_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_u16)

## vzip1q_u32

`vzip1q_u32`

uint32x4_t vzip1q_u32(uint32x4_t a, uint32x4_t b)
A64: ZIP1 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vzip1q_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_u32)

## vzip1q_u64

`vzip1q_u64`

uint64x2_t vzip1q_u64(uint64x2_t a, uint64x2_t b)
A64: ZIP1 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vzip1q_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_u64)

## vzip1q_u8

`vzip1q_u8`

uint8x16_t vzip1q_u8(uint8x16_t a, uint8x16_t b)
A64: ZIP1 Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vzip1q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip1q_u8)

## vzip2_f32

`vzip2_f32`

float32x2_t vzip2_f32(float32x2_t a, float32x2_t b)
A64: ZIP2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vzip2_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2_f32)

## vzip2_s16

`vzip2_s16`

int16x4_t vzip2_s16(int16x4_t a, int16x4_t b)
A64: ZIP2 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vzip2_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2_s16)

## vzip2_s32

`vzip2_s32`

int32x2_t vzip2_s32(int32x2_t a, int32x2_t b)
A64: ZIP2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vzip2_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2_s32)

## vzip2_s8

`vzip2_s8`

int8x8_t vzip2_s8(int8x8_t a, int8x8_t b)
A64: ZIP2 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vzip2_s8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2_s8)

## vzip2_u16

`vzip2_u16`

uint16x4_t vzip2_u16(uint16x4_t a, uint16x4_t b)
A64: ZIP2 Vd.4H, Vn.4H, Vm.4H


Instruction Documentation: [vzip2_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2_u16)

## vzip2_u32

`vzip2_u32`

uint32x2_t vzip2_u32(uint32x2_t a, uint32x2_t b)
A64: ZIP2 Vd.2S, Vn.2S, Vm.2S


Instruction Documentation: [vzip2_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2_u32)

## vzip2_u8

`vzip2_u8`

uint8x8_t vzip2_u8(uint8x8_t a, uint8x8_t b)
A64: ZIP2 Vd.8B, Vn.8B, Vm.8B


Instruction Documentation: [vzip2_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2_u8)

## vzip2q_f32

`vzip2q_f32`

float32x4_t vzip2q_f32(float32x4_t a, float32x4_t b)
A64: ZIP2 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vzip2q_f32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_f32)

## vzip2q_f64

`vzip2q_f64`

float64x2_t vzip2q_f64(float64x2_t a, float64x2_t b)
A64: ZIP2 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vzip2q_f64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_f64)

## vzip2q_s16

`vzip2q_s16`

int16x8_t vzip2q_s16(int16x8_t a, int16x8_t b)
A64: ZIP2 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vzip2q_s16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_s16)

## vzip2q_s32

`vzip2q_s32`

int32x4_t vzip2q_s32(int32x4_t a, int32x4_t b)
A64: ZIP2 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vzip2q_s32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_s32)

## vzip2q_s64

`vzip2q_s64`

int64x2_t vzip2q_s64(int64x2_t a, int64x2_t b)
A64: ZIP2 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vzip2q_s64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_s64)

## vzip2q_u16

`vzip2q_u16`

uint16x8_t vzip2q_u16(uint16x8_t a, uint16x8_t b)
A64: ZIP2 Vd.8H, Vn.8H, Vm.8H


Instruction Documentation: [vzip2q_u16](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_u16)

## vzip2q_u32

`vzip2q_u32`

uint32x4_t vzip2q_u32(uint32x4_t a, uint32x4_t b)
A64: ZIP2 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vzip2q_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_u32)

## vzip2q_u64

`vzip2q_u64`

uint64x2_t vzip2q_u64(uint64x2_t a, uint64x2_t b)
A64: ZIP2 Vd.2D, Vn.2D, Vm.2D


Instruction Documentation: [vzip2q_u64](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_u64)

## vzip2q_u8

`vzip2q_u8`

uint8x16_t vzip2q_u8(uint8x16_t a, uint8x16_t b)
A64: ZIP2 Vd.16B, Vn.16B, Vm.16B


Instruction Documentation: [vzip2q_u8](https://developer.arm.com/architectures/instruction-sets/intrinsics/vzip2q_u8)
