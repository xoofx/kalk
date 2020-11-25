---
title: Intel Hardware Intrinsics
---

Module with Intel CPU Hardware intrinsics.

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
Depending on the characteristics of your CPU (e.g `AVX2`, `SSE3`...), this module will import only the intrinsic functions supported by your CPU.
{{end}}