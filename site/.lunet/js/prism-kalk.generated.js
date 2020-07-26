Prism.languages.kalk.function = /\b(?:parse_csv|load_csv|currencies|currency|file_exists|directory_exists|dir|load_text|load_bytes|load_lines|save_lines|save_text|save_bytes|config|aliases|units|shortcuts|clipboard|display|echo|print|printh|help|reset|version|list|del|exit|history|eval|load|clear|cls|out|out2clipboard|shortcut|alias|kind|to|unit|nan|inf|pi|e|fib|i|all|any|abs|rnd|seed|modf|radians|degrees|sign|cos|acos|cosh|acosh|sin|asin|sinh|asinh|tan|atan|tanh|atanh|atan2|fmod|frac|rsqrt|sqrt|log|log2|log10|exp|exp2|pow|round|floor|ceil|trunc|saturate|min|max|step|smoothstep|lerp|clamp|real|imag|phase|isfinite|isinf|isnan|sum|malloc|bitcast|asbytes|countbits|firstbithigh|firstbitlow|reversebits|asdouble|asfloat|aslong|asulong|asint|asuint|bytebuffer|date|ascii|keys|guid|size|values|hex|bin|utf8|utf16|utf32|insert_at|remove_at|contains|replace|slice|lines|colors|escape|capitalize|capitalize_words|downcase|upcase|endswith|handleize|lstrip|pluralize|rstrip|split|startswith|strip|strip_newlines|pad_left|pad_right|regex_escape|regex_match|regex_matches|regex_replace|regex_split|regex_unescape|length|normalize|dot|cross|byte|sbyte|short|ushort|uint|int|ulong|long|bool|float|double|byte16|byte32|byte64|sbyte16|sbyte32|sbyte64|short2|short4|short8|short16|short32|ushort2|ushort4|ushort8|ushort16|ushort32|int2|int3|int4|int8|int16|uint2|uint3|uint4|uint8|uint16|long2|long3|long4|long8|ulong2|ulong3|ulong4|ulong8|bool2|bool3|bool4|bool8|bool16|float2|float3|float4|float8|float16|double2|double3|double4|double8|vector|rgb|rgba|bool2x2|bool2x3|bool2x4|bool3x2|bool3x3|bool3x4|bool4x2|bool4x3|bool4x4|int2x2|int2x3|int2x4|int3x2|int3x3|int3x4|int4x2|int4x3|int4x4|float2x2|float2x3|float2x4|float3x2|float3x3|float3x4|float4x2|float4x3|float4x4|double2x2|double2x3|double2x4|double3x2|double3x3|double3x4|double4x2|double4x3|double4x4|transpose|identity|determinant|inverse|diag|matrix|row|col|mul|url_encode|url_decode|url_escape|html_encode|html_decode|json|html_strip|wget|mm_aesdec_si128|mm_aesdeclast_si128|mm_aesenc_si128|mm_aesenclast_si128|mm_aesimc_si128|mm_aeskeygenassist_si128|mm_broadcast_ss|mm_cmp_ps|mm_cmp_sd|mm_maskload_ps|mm_maskstore_ps|mm_permute_ps|mm_permutevar_ps|mm_testc_ps|mm_testnzc_ps|mm_testz_ps|mm256_add_ps|mm256_addsub_ps|mm256_and_ps|mm256_andnot_ps|mm256_blend_ps|mm256_blendv_ps|mm256_broadcast_ps|mm256_broadcast_ss|mm256_ceil_ps|mm256_cvtepi32_ps|mm256_cvtpd_epi32|mm256_cvtpd_ps|mm256_cvtps_epi32|mm256_cvtps_pd|mm256_cvttpd_epi32|mm256_cvttps_epi32|mm256_div_ps|mm256_dp_ps|mm256_extractf128_si256|mm256_floor_ps|mm256_hadd_ps|mm256_hsub_ps|mm256_insertf128_si256|mm256_lddqu_si256|mm256_load_si256|mm256_loadu_si256|mm256_max_ps|mm256_min_ps|mm256_movehdup_ps|mm256_moveldup_ps|mm256_movemask_ps|mm256_mul_ps|mm256_or_ps|mm256_permute2f128_si256|mm256_rcp_ps|mm256_round_ps|mm256_round_ps_to_nearest_integer|mm256_round_ps_to_negative_infinity|mm256_round_ps_to_positive_infinity|mm256_round_ps_to_zero|mm256_rsqrt_ps|mm256_shuffle_ps|mm256_sqrt_ps|mm256_store_si256|mm256_storeu_si256|mm256_stream_si256|mm256_sub_ps|mm256_unpackhi_ps|mm256_unpacklo_ps|mm256_xor_ps|mm_blend_epi32|mm_broadcastb_epi8|mm_i32gather_epi32|mm_mask_i32gather_epi32|mm_maskload_epi32|mm_maskstore_epi32|mm256_abs_epi8|mm256_add_epi8|mm256_adds_epi8|mm256_alignr_epi8|mm256_and_si256|mm256_andnot_si256|mm256_avg_epu8|mm256_blendv_epi8|mm256_broadcastb_epi8|mm256_broadcastsi128_si256|mm256_bslli_epi128|mm256_bsrli_epi128|mm256_cmpeq_epi8|mm256_cmpgt_epi8|mm256_cvtepi8_epi16|mm256_cvtepi8_epi32|mm256_cvtepi8_epi64|mm256_cvtsi256_si32|mm256_extracti128_si256|mm256_hadd_epi16|mm256_hadds_epi16|mm256_hsub_epi16|mm256_hsubs_epi16|mm256_i32gather_epi32|mm256_inserti128_si256|mm256_madd_epi16|mm256_mask_i32gather_epi32|mm256_max_epi8|mm256_min_epi8|mm256_movemask_epi8|mm256_mpsadbw_epu8|mm256_mul_epi32|mm256_mulhi_epi16|mm256_mulhrs_epi16|mm256_mullo_epi16|mm256_or_si256|mm256_packs_epi16|mm256_packus_epi16|mm256_permute2x128_si256|mm256_permute4x64_epi64|mm256_permutevar8x32_epi32|mm256_sad_epu8|mm256_shuffle_epi8|mm256_shufflehi_epi16|mm256_shufflelo_epi16|mm256_sign_epi8|mm256_sll_epi16|mm256_sllv_epi32|mm256_srav_epi32|mm256_srl_epi16|mm256_srlv_epi32|mm256_stream_load_si256|mm256_sub_epi8|mm256_subs_epi8|mm256_unpackhi_epi8|mm256_unpacklo_epi8|mm256_xor_si256|andn_u32|bextr_u32|bextr2_u32|blsi_u32|blsmsk_u32|blsr_u32|mm_tzcnt_32|andn_u64|bextr_u64|bextr2_u64|blsi_u64|blsmsk_u64|blsr_u64|mm_tzcnt_64|bzhi_u32|mulx_u32|pdep_u32|pext_u32|bzhi_u64|mulx_u64|pdep_u64|pext_u64|mm_add_ps|mm_add_ss|mm_and_ps|mm_andnot_ps|mm_cmpeq_ps|mm_cmpeq_ss|mm_cmpge_ps|mm_cmpge_ss|mm_cmpgt_ps|mm_cmpgt_ss|mm_cmple_ps|mm_cmple_ss|mm_cmplt_ps|mm_cmplt_ss|mm_cmpneq_ps|mm_cmpneq_ss|mm_cmpnge_ps|mm_cmpnge_ss|mm_cmpngt_ps|mm_cmpngt_ss|mm_cmpnle_ps|mm_cmpnle_ss|mm_cmpnlt_ps|mm_cmpnlt_ss|mm_cmpord_ps|mm_cmpord_ss|mm_cmpunord_ps|mm_cmpunord_ss|mm_comieq_ss|mm_comige_ss|mm_comigt_ss|mm_comile_ss|mm_comilt_ss|mm_comineq_ss|mm_cvtsi32_ss|mm_cvtss_si32|mm_cvttss_si32|mm_div_ps|mm_div_ss|mm_load_ps|mm_load_ss|mm_loadh_pi|mm_loadl_pi|mm_loadu_ps|mm_max_ps|mm_max_ss|mm_min_ps|mm_min_ss|mm_move_ss|mm_movehl_ps|mm_movelh_ps|mm_movemask_ps|mm_mul_ps|mm_mul_ss|mm_or_ps|mm_prefetch0|mm_prefetch1|mm_prefetch2|mm_prefetchnta|mm_rcp_ps|mm_rcp_ss|mm_rcp_ss1|mm_rsqrt_ps|mm_rsqrt_ss|mm_rsqrt_ss1|mm_shuffle_ps|mm_sqrt_ps|mm_sqrt_ss|mm_sqrt_ss1|mm_store_ps|mm_store_ss|mm_storeh_pi|mm_storel_pi|mm_storeu_ps|mm_stream_ps|mm_sub_ps|mm_sub_ss|mm_ucomieq_ss|mm_ucomige_ss|mm_ucomigt_ss|mm_ucomile_ss|mm_ucomilt_ss|mm_ucomineq_ss|mm_unpackhi_ps|mm_unpacklo_ps|mm_xor_ps|mm_add_epi8|mm_add_sd|mm_adds_epi8|mm_and_si128|mm_andnot_si128|mm_avg_epu8|mm_bslli_si128|mm_bsrli_si128|mm_cmpeq_epi8|mm_cmpeq_sd|mm_cmpge_pd|mm_cmpge_sd|mm_cmpgt_epi8|mm_cmpgt_sd|mm_cmple_pd|mm_cmple_sd|mm_cmplt_epi8|mm_cmplt_sd|mm_cmpneq_pd|mm_cmpneq_sd|mm_cmpnge_pd|mm_cmpnge_sd|mm_cmpngt_pd|mm_cmpngt_sd|mm_cmpnle_pd|mm_cmpnle_sd|mm_cmpnlt_pd|mm_cmpnlt_sd|mm_cmpord_pd|mm_cmpord_sd|mm_cmpunord_pd|mm_cmpunord_sd|mm_comieq_sd|mm_comige_sd|mm_comigt_sd|mm_comile_sd|mm_comilt_sd|mm_comineq_sd|mm_cvtepi32_pd|mm_cvtepi32_ps|mm_cvtps_epi32|mm_cvtsd_si32|mm_cvtsd_ss|mm_cvtsi128_si32|mm_cvtsi32_sd|mm_cvtsi32_si128|mm_cvttps_epi32|mm_cvttsd_si32|mm_div_pd|mm_div_sd|mm_extract_epi16|mm_insert_epi16|mm_load_sd|mm_load_si128|mm_loadh_pd|mm_loadl_pd|mm_loadu_si128|mm_madd_epi16|mm_maskmoveu_si128|mm_max_epu8|mm_max_sd|mm_min_epu8|mm_min_sd|mm_move_epi64|mm_move_sd|mm_movemask_epi8|mm_mul_epu32|mm_mul_sd|mm_mulhi_epi16|mm_mullo_epi16|mm_or_si128|mm_packs_epi16|mm_packus_epi16|mm_sad_epu8|mm_shuffle_epi32|mm_shuffle_pd|mm_shufflehi_epi16|mm_shufflelo_epi16|mm_sll_epi16|mm_sqrt_pd|mm_sqrt_sd|mm_sqrt_sd1|mm_sra_epi16|mm_srl_epi16|mm_store_sd|mm_store_si128|mm_storeh_pd|mm_storel_pd|mm_storeu_si128|mm_stream_si128|mm_stream_si32|mm_sub_epi8|mm_sub_sd|mm_subs_epi8|mm_ucomieq_sd|mm_ucomige_sd|mm_ucomigt_sd|mm_ucomile_sd|mm_ucomilt_sd|mm_ucomineq_sd|mm_unpackhi_epi8|mm_unpacklo_epi8|mm_xor_si128|mm_cvtsd_si64|mm_cvtsi128_si64|mm_cvtsi64_sd|mm_cvtsi64_si128|mm_cvttsd_si64|mm_stream_si64|mm_addsub_ps|mm_hadd_ps|mm_hsub_ps|mm_lddqu_si128|mm_loaddup_pd|mm_movedup_pd|mm_movehdup_ps|mm_moveldup_ps|mm_blend_epi16|mm_blendv_epi8|mm_ceil_ps|mm_ceil_sd|mm_ceil_sd1|mm_cmpeq_epi64|mm_cvtepi8_epi16|mm_cvtepi8_epi32|mm_cvtepi8_epi64|mm_dp_ps|mm_extract_epi8|mm_floor_ps|mm_floor_sd|mm_floor_sd1|mm_insert_epi8|mm_max_epi8|mm_min_epi8|mm_minpos_epu16|mm_mpsadbw_epu8|mm_mul_epi32|mm_mullo_epi32|mm_packus_epi32|mm_round_ps|mm_round_ps_to_nearest_integer|mm_round_ps_to_negative_infinity|mm_round_ps_to_positive_infinity|mm_round_ps_to_zero|mm_round_sd|mm_round_sd_to_nearest_integer_scalar|mm_round_sd_to_negative_infinity_scalar|mm_round_sd_to_positive_infinity_scalar|mm_round_sd_to_zero_scalar|mm_round_sd1|mm_round_sd1_to_nearest_integer_scalar|mm_round_sd1_to_negative_infinity_scalar|mm_round_sd1_to_positive_infinity_scalar|mm_round_sd1_to_zero_scalar|mm_stream_load_si128|mm_testc_si128|mm_testnzc_si128|mm_testz_si128|mm_extract_epi64|mm_insert_epi64|mm_cmpgt_epi64|mm_crc32_u8|mm_crc32_u64|mm_cvtsi64_ss|mm_cvtss_si64|mm_cvttss_si64|mm_abs_epi8|mm_alignr_epi8|mm_hadd_epi16|mm_hadds_epi16|mm_hsub_epi16|mm_hsubs_epi16|mm_maddubs_epi16|mm_mulhrs_epi16|mm_shuffle_epi8|mm_sign_epi8|null|true|false|All|Csv|Currencies|Files|HardwareIntrinsics|StandardUnits|Strings|Web)\b/;
