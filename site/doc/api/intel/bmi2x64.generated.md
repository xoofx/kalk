---
title: Intel Bmi2X64 Intrinsics
url: /doc/api/intel/bmi2x64/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Bmi2X64` features.

{{end}}


## bzhi_u64

`bzhi_u64`

unsigned __int64 _bzhi_u64 (unsigned __int64 a, unsigned int index)
BZHI r64a, reg/m32, r64b

## mulx_u64

`mulx_u64`

unsigned __int64 _mulx_u64 (unsigned __int64 a, unsigned __int64 b, unsigned __int64* hi)
MULX r64a, r64b, reg/m64

## pdep_u64

`pdep_u64`

unsigned __int64 _pdep_u64 (unsigned __int64 a, unsigned __int64 mask)
PDEP r64a, r64b, reg/m64

## pext_u64

`pext_u64`

unsigned __int64 _pext_u64 (unsigned __int64 a, unsigned __int64 mask)
PEXT r64a, r64b, reg/m64
