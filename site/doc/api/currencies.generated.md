---
title: Currencies Module
url: /doc/api/currencies/
---



In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import Currencies
```

## currencies

`currencies`

Gets all the defined currencies. The default base currency is EUR.

### Returns

All the defined currencies.

### Example

```kalk
>>> currencies
# Builtin Currencies (Last Update: 06 Mar 2022)
currency(AED, 4.1321);      # 4.1321   AED => 1 EUR
currency(AFN, 101.9887);    # 101.9887 AFN => 1 EUR
currency(ALL, 122.7378);    # 122.7378 ALL => 1 EUR
currency(AMD, 547.57);      # 547.57   AMD => 1 EUR
currency(ANG, 1.991);       # 1.991    ANG => 1 EUR
currency(AOA, 556.8346);    # 556.8346 AOA => 1 EUR
currency(ARS, 119.7553);    # 119.7553 ARS => 1 EUR
currency(AUD, 1.5035);      # 1.5035   AUD => 1 EUR
currency(AWG, 2.0255);      # 2.0255   AWG => 1 EUR
currency(AZN, 1.9218);      # 1.9218   AZN => 1 EUR
currency(BAM, 1.9793);      # 1.9793   BAM => 1 EUR
currency(BBD, 2.2596);      # 2.2596   BBD => 1 EUR
currency(BDT, 97.0603);     # 97.0603  BDT => 1 EUR
currency(BGN, 1.9434);      # 1.9434   BGN => 1 EUR
currency(BHD, 0.4176);      # 0.4176   BHD => 1 EUR
currency(BIF, 2237.6264);   # 2237.6264 BIF => 1 EUR
currency(BND, 1.521);       # 1.521    BND => 1 EUR
currency(BOB, 7.637);       # 7.637    BOB => 1 EUR
currency(BRL, 5.7249);      # 5.7249   BRL => 1 EUR
currency(BSD, 1.1188);      # 1.1188   BSD => 1 EUR
currency(BWP, 13.0967);     # 13.0967  BWP => 1 EUR
currency(BYN, 3.0139);      # 3.0139   BYN => 1 EUR
currency(BZD, 2.2559);      # 2.2559   BZD => 1 EUR
currency(CAD, 1.4037);      # 1.4037   CAD => 1 EUR
currency(CDF, 2239.6954);   # 2239.6954 CDF => 1 EUR
currency(CHF, 1.0139);      # 1.0139   CHF => 1 EUR
currency(CLP, 883.8071);    # 883.8071 CLP => 1 EUR
currency(CNY, 6.9712);      # 6.9712   CNY => 1 EUR
currency(COP, 4286.4925);   # 4286.4925 COP => 1 EUR
currency(CRC, 716.9159);    # 716.9159 CRC => 1 EUR
currency(CUP, 1.1188);      # 1.1188   CUP => 1 EUR
currency(CVE, 111.8813);    # 111.8813 CVE => 1 EUR
currency(CZK, 25.0893);     # 25.0893  CZK => 1 EUR
currency(DJF, 199.2294);    # 199.2294 DJF => 1 EUR
currency(DKK, 7.4076);      # 7.4076   DKK => 1 EUR
currency(DOP, 60.9968);     # 60.9968  DOP => 1 EUR
currency(DZD, 158.8736);    # 158.8736 DZD => 1 EUR
currency(EGP, 17.3547);     # 17.3547  EGP => 1 EUR
currency(ERN, 16.8738);     # 16.8738  ERN => 1 EUR
currency(ETB, 57.3988);     # 57.3988  ETB => 1 EUR
currency(EUR);              # Base currency
currency(FJD, 2.3779);      # 2.3779   FJD => 1 EUR
currency(GBP, 0.8274);      # 0.8274   GBP => 1 EUR
currency(GEL, 3.4675);      # 3.4675   GEL => 1 EUR
currency(GHS, 7.7215);      # 7.7215   GHS => 1 EUR
currency(GIP, 0.834);       # 0.834    GIP => 1 EUR
currency(GMD, 59.7344);     # 59.7344  GMD => 1 EUR
currency(GNF, 10050.7494);  # 10050.7494 GNF => 1 EUR
currency(GTQ, 8.64);        # 8.64     GTQ => 1 EUR
currency(GYD, 234.1451);    # 234.1451 GYD => 1 EUR
currency(HKD, 8.6189);      # 8.6189   HKD => 1 EUR
currency(HNL, 27.5567);     # 27.5567  HNL => 1 EUR
currency(HRK, 7.502);       # 7.502    HRK => 1 EUR
currency(HTG, 116.6989);    # 116.6989 HTG => 1 EUR
currency(HUF, 371.8363);    # 371.8363 HUF => 1 EUR
currency(IDR, 15844.3432);  # 15844.3432 IDR => 1 EUR
currency(ILS, 3.5775);      # 3.5775   ILS => 1 EUR
currency(INR, 83.7335);     # 83.7335  INR => 1 EUR
currency(IQD, 1653.9687);   # 1653.9687 IQD => 1 EUR
currency(IRR, 47584.1953);  # 47584.1953 IRR => 1 EUR
currency(ISK, 145.4218);    # 145.4218 ISK => 1 EUR
currency(JMD, 173.0165);    # 173.0165 JMD => 1 EUR
currency(JOD, 0.7851);      # 0.7851   JOD => 1 EUR
currency(JPY, 127.1764);    # 127.1764 JPY => 1 EUR
currency(KES, 127.469);     # 127.469  KES => 1 EUR
currency(KGS, 96.0913);     # 96.0913  KGS => 1 EUR
currency(KHR, 4548.7899);   # 4548.7899 KHR => 1 EUR
currency(KMF, 494.4337);    # 494.4337 KMF => 1 EUR
currency(KRW, 1336.5796);   # 1336.5796 KRW => 1 EUR
currency(KWD, 0.3362);      # 0.3362   KWD => 1 EUR
currency(KZT, 488.6859);    # 488.6859 KZT => 1 EUR
currency(LAK, 12816.035);   # 12816.035 LAK => 1 EUR
currency(LBP, 1701.7387);   # 1701.7387 LBP => 1 EUR
currency(LKR, 224.4293);    # 224.4293 LKR => 1 EUR
currency(LRD, 172.4008);    # 172.4008 LRD => 1 EUR
currency(LSL, 17.3326);     # 17.3326  LSL => 1 EUR
currency(LYD, 5.2191);      # 5.2191   LYD => 1 EUR
currency(MAD, 10.7205);     # 10.7205  MAD => 1 EUR
currency(MDL, 19.921);      # 19.921   MDL => 1 EUR
currency(MGA, 4469.0602);   # 4469.0602 MGA => 1 EUR
currency(MKD, 62.1946);     # 62.1946  MKD => 1 EUR
currency(MMK, 1990.3292);   # 1990.3292 MMK => 1 EUR
currency(MNT, 3229.6408);   # 3229.6408 MNT => 1 EUR
currency(MOP, 9.013);       # 9.013    MOP => 1 EUR
currency(MRO, 40.1478);     # 40.1478  MRO => 1 EUR
currency(MRU, 40.7098);     # 40.7098  MRU => 1 EUR
currency(MUR, 49.6868);     # 49.6868  MUR => 1 EUR
currency(MVR, 17.3016);     # 17.3016  MVR => 1 EUR
currency(MWK, 913.7045);    # 913.7045 MWK => 1 EUR
currency(MXN, 22.8123);     # 22.8123  MXN => 1 EUR
currency(MYR, 4.6522);      # 4.6522   MYR => 1 EUR
currency(MZN, 71.7698);     # 71.7698  MZN => 1 EUR
currency(NAD, 17.3264);     # 17.3264  NAD => 1 EUR
currency(NGN, 462.1707);    # 462.1707 NGN => 1 EUR
currency(NIO, 40.0038);     # 40.0038  NIO => 1 EUR
currency(NOK, 9.8676);      # 9.8676   NOK => 1 EUR
currency(NPR, 135.0813);    # 135.0813 NPR => 1 EUR
currency(NZD, 1.6167);      # 1.6167   NZD => 1 EUR
currency(OMR, 0.4266);      # 0.4266   OMR => 1 EUR
currency(PAB, 1.111);       # 1.111    PAB => 1 EUR
currency(PEN, 4.1375);      # 4.1375   PEN => 1 EUR
currency(PGK, 3.8901);      # 3.8901   PGK => 1 EUR
currency(PHP, 57.3084);     # 57.3084  PHP => 1 EUR
currency(PKR, 199.6326);    # 199.6326 PKR => 1 EUR
currency(PLN, 4.6972);      # 4.6972   PLN => 1 EUR
currency(PYG, 7755.7086);   # 7755.7086 PYG => 1 EUR
currency(QAR, 4.0413);      # 4.0413   QAR => 1 EUR
currency(RON, 4.9172);      # 4.9172   RON => 1 EUR
currency(RSD, 119.3434);    # 119.3434 RSD => 1 EUR
currency(RUB, 112.2525);    # 112.2525 RUB => 1 EUR
currency(RWF, 1135.3319);   # 1135.3319 RWF => 1 EUR
currency(SAR, 4.1418);      # 4.1418   SAR => 1 EUR
currency(SBD, 9.1509);      # 9.1509   SBD => 1 EUR
currency(SCR, 16.116);      # 16.116   SCR => 1 EUR
currency(SDG, 499.429);     # 499.429  SDG => 1 EUR
currency(SEK, 10.7168);     # 10.7168  SEK => 1 EUR
currency(SGD, 1.4967);      # 1.4967   SGD => 1 EUR
currency(SLL, 13022.7453);  # 13022.7453 SLL => 1 EUR
currency(SOS, 647.3956);    # 647.3956 SOS => 1 EUR
currency(SRD, 22.9053);     # 22.9053  SRD => 1 EUR
currency(SSP, 481.2219);    # 481.2219 SSP => 1 EUR
currency(STN, 24.9843);     # 24.9843  STN => 1 EUR
currency(SVC, 9.7967);      # 9.7967   SVC => 1 EUR
currency(SYP, 2849.6831);   # 2849.6831 SYP => 1 EUR
currency(SZL, 17.3326);     # 17.3326  SZL => 1 EUR
currency(THB, 36.5233);     # 36.5233  THB => 1 EUR
currency(TJS, 12.8);        # 12.8     TJS => 1 EUR
currency(TMT, 3.9647);      # 3.9647   TMT => 1 EUR
currency(TND, 3.2868);      # 3.2868   TND => 1 EUR
currency(TOP, 2.544);       # 2.544    TOP => 1 EUR
currency(TRY, 15.584);      # 15.584   TRY => 1 EUR
currency(TTD, 7.5908);      # 7.5908   TTD => 1 EUR
currency(TWD, 31.0675);     # 31.0675  TWD => 1 EUR
currency(TZS, 2592.0071);   # 2592.0071 TZS => 1 EUR
currency(UAH, 32.6392);     # 32.6392  UAH => 1 EUR
currency(UGX, 3954.6622);   # 3954.6622 UGX => 1 EUR
currency(USD, 1.1033);      # 1.1033   USD => 1 EUR
currency(UYU, 47.3672);     # 47.3672  UYU => 1 EUR
currency(UZS, 12247.9056);  # 12247.9056 UZS => 1 EUR
currency(VES, 4.855);       # 4.855    VES => 1 EUR
currency(VND, 25428.9059);  # 25428.9059 VND => 1 EUR
currency(VUV, 126.043);     # 126.043  VUV => 1 EUR
currency(WST, 2.8821);      # 2.8821   WST => 1 EUR
currency(XAF, 662.6246);    # 662.6246 XAF => 1 EUR
currency(XCD, 3.0335);      # 3.0335   XCD => 1 EUR
currency(XOF, 662.8467);    # 662.8467 XOF => 1 EUR
currency(XPF, 120.3832);    # 120.3832 XPF => 1 EUR
currency(YER, 280.0428);    # 280.0428 YER => 1 EUR
currency(ZAR, 16.8689);     # 16.8689  ZAR => 1 EUR
currency(ZMW, 19.9607);     # 19.9607  ZMW => 1 EUR
```

## currency

`currency(name?,value?)`

Gets or sets the default currency. The default base currency is EUR.

- `name`: If not null, name of the currency to set.
- `value`: If name is not null, value of the currency

### Returns

The default defined currency.

### Example

```kalk
>>> USD
currency(USD, 1.1033);      # 1.1033   USD => 1 EUR
>>> 2 USD
# 2 * USD
out = 1.8127918828265197793338250828 * EUR
>>> currency(GBP) # Defines GBP as the default currency instead of EUR
# currency(GBP) # Defines GBP as the default currency instead of EUR
out = GBP
>>> USD
currency(USD, 1.3334);      # 1.3334   USD => 1 GBP
>>> 2 USD |> to EUR # Convert 2 dollars to EUR
# 2 * USD |> to(EUR) # Convert 2 dollars to EUR
out = 1.8127918828265266 * EUR
```
