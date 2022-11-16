---
title: Arm Sha1 Intrinsics
url: /doc/api/arm/sha1/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Sha1` features.

{{end}}


## vsha1cq_u32

`vsha1cq_u32`

uint32x4_t vsha1cq_u32 (uint32x4_t hash_abcd, uint32_t hash_e, uint32x4_t wk)
A32: SHA1C.32 Qd, Qn, Qm
A64: SHA1C Qd, Sn, Vm.4S


Instruction Documentation: [vsha1cq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsha1cq_u32)

## vsha1h_u32

`vsha1h_u32`

uint32_t vsha1h_u32 (uint32_t hash_e)
A32: SHA1H.32 Qd, Qm
A64: SHA1H Sd, Sn


Instruction Documentation: [vsha1h_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsha1h_u32)

## vsha1mq_u32

`vsha1mq_u32`

uint32x4_t vsha1mq_u32 (uint32x4_t hash_abcd, uint32_t hash_e, uint32x4_t wk)
A32: SHA1M.32 Qd, Qn, Qm
A64: SHA1M Qd, Sn, Vm.4S


Instruction Documentation: [vsha1mq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsha1mq_u32)

## vsha1pq_u32

`vsha1pq_u32`

uint32x4_t vsha1pq_u32 (uint32x4_t hash_abcd, uint32_t hash_e, uint32x4_t wk)
A32: SHA1P.32 Qd, Qn, Qm
A64: SHA1P Qd, Sn, Vm.4S


Instruction Documentation: [vsha1pq_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsha1pq_u32)

## vsha1su0q_u32

`vsha1su0q_u32`

uint32x4_t vsha1su0q_u32 (uint32x4_t w0_3, uint32x4_t w4_7, uint32x4_t w8_11)
A32: SHA1SU0.32 Qd, Qn, Qm
A64: SHA1SU0 Vd.4S, Vn.4S, Vm.4S


Instruction Documentation: [vsha1su0q_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsha1su0q_u32)

## vsha1su1q_u32

`vsha1su1q_u32`

uint32x4_t vsha1su1q_u32 (uint32x4_t tw0_3, uint32x4_t w12_15)
A32: SHA1SU1.32 Qd, Qm
A64: SHA1SU1 Vd.4S, Vn.4S


Instruction Documentation: [vsha1su1q_u32](https://developer.arm.com/architectures/instruction-sets/intrinsics/vsha1su1q_u32)
