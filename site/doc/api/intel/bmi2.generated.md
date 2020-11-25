---
title: Intel Bmi2 Intrinsics
url: /doc/api/intel/bmi2/
---

## bzhi_u32

`bzhi_u32`

unsigned int _bzhi_u32 (unsigned int a, unsigned int index)
BZHI r32a, reg/m32, r32b

## mulx_u32

`mulx_u32`

unsigned int _mulx_u32 (unsigned int a, unsigned int b, unsigned int* hi)
MULX r32a, r32b, reg/m32

## pdep_u32

`pdep_u32`

unsigned int _pdep_u32 (unsigned int a, unsigned int mask)
PDEP r32a, r32b, reg/m32

## pext_u32

`pext_u32`

unsigned int _pext_u32 (unsigned int a, unsigned int mask)
PEXT r32a, r32b, reg/m32
