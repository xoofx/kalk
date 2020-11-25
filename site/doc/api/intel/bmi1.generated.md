---
title: Intel Bmi1 Intrinsics
url: /doc/api/intel/bmi1/
---

## andn_u32

`andn_u32`

unsigned int _andn_u32 (unsigned int a, unsigned int b)
ANDN r32a, r32b, reg/m32

## bextr2_u32

`bextr2_u32`

unsigned int _bextr2_u32 (unsigned int a, unsigned int control)
BEXTR r32a, reg/m32, r32b

## bextr_u32

`bextr_u32`

unsigned int _bextr_u32 (unsigned int a, unsigned int start, unsigned int len)
BEXTR r32a, reg/m32, r32b

## blsi_u32

`blsi_u32`

unsigned int _blsi_u32 (unsigned int a)
BLSI reg, reg/m32

## blsmsk_u32

`blsmsk_u32`

unsigned int _blsmsk_u32 (unsigned int a)
BLSMSK reg, reg/m32

## blsr_u32

`blsr_u32`

unsigned int _blsr_u32 (unsigned int a)
BLSR reg, reg/m32

## mm_tzcnt_32

`mm_tzcnt_32`

int _mm_tzcnt_32 (unsigned int a)
TZCNT reg, reg/m32
