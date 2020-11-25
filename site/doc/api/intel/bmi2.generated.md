---
title: Intel Bmi2 Intrinsics
url: /doc/api/intel/bmi2/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Bmi2` features.

{{end}}


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
