---
title: Intel Bmi1X64 Intrinsics
url: /doc/api/intel/bmi1x64/
---

## andn_u64

`andn_u64`

unsigned __int64 _andn_u64 (unsigned __int64 a, unsigned __int64 b)
ANDN r64a, r64b, reg/m64

## bextr2_u64

`bextr2_u64`

unsigned __int64 _bextr2_u64 (unsigned __int64 a, unsigned __int64 control)
BEXTR r64a, reg/m64, r64b

## bextr_u64

`bextr_u64`

unsigned __int64 _bextr_u64 (unsigned __int64 a, unsigned int start, unsigned int len)
BEXTR r64a, reg/m64, r64b

## blsi_u64

`blsi_u64`

unsigned __int64 _blsi_u64 (unsigned __int64 a)
BLSI reg, reg/m64

## blsmsk_u64

`blsmsk_u64`

unsigned __int64 _blsmsk_u64 (unsigned __int64 a)
BLSMSK reg, reg/m64

## blsr_u64

`blsr_u64`

unsigned __int64 _blsr_u64 (unsigned __int64 a)
BLSR reg, reg/m64

## mm_tzcnt_64

`mm_tzcnt_64`

__int64 _mm_tzcnt_64 (unsigned __int64 a)
TZCNT reg, reg/m64
