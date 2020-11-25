---
title: Currencies Functions
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
# Builtin Currencies (Last Update: 08 May 2020)
currency(AUD, 1.6613);      # 1.6613   AUD => 1 EUR
currency(BGN, 1.9558);      # 1.9558   BGN => 1 EUR
currency(BRL, 6.3074);      # 6.3074   BRL => 1 EUR
currency(CAD, 1.5118);      # 1.5118   CAD => 1 EUR
currency(CHF, 1.0529);      # 1.0529   CHF => 1 EUR
currency(CNY, 7.6719);      # 7.6719   CNY => 1 EUR
currency(CZK, 27.251);      # 27.251   CZK => 1 EUR
currency(DKK, 7.4598);      # 7.4598   DKK => 1 EUR
currency(EUR);              # Base currency
currency(GBP, 0.8754);      # 0.8754   GBP => 1 EUR
currency(HKD, 8.4052);      # 8.4052   HKD => 1 EUR
currency(HRK, 7.5573);      # 7.5573   HRK => 1 EUR
currency(HUF, 349.38);      # 349.38   HUF => 1 EUR
currency(IDR, 16229.26);    # 16229.26 IDR => 1 EUR
currency(ILS, 3.8031);      # 3.8031   ILS => 1 EUR
currency(INR, 81.9615);     # 81.9615  INR => 1 EUR
currency(ISK, 158.5);       # 158.5    ISK => 1 EUR
currency(JPY, 115.34);      # 115.34   JPY => 1 EUR
currency(KRW, 1322.41);     # 1322.41  KRW => 1 EUR
currency(MXN, 25.9023);     # 25.9023  MXN => 1 EUR
currency(MYR, 4.6994);      # 4.6994   MYR => 1 EUR
currency(NOK, 11.0695);     # 11.0695  NOK => 1 EUR
currency(NZD, 1.7668);      # 1.7668   NZD => 1 EUR
currency(PHP, 54.681);      # 54.681   PHP => 1 EUR
currency(PLN, 4.5482);      # 4.5482   PLN => 1 EUR
currency(RON, 4.828);       # 4.828    RON => 1 EUR
currency(RUB, 79.8383);     # 79.8383  RUB => 1 EUR
currency(SEK, 10.5875);     # 10.5875  SEK => 1 EUR
currency(SGD, 1.5326);      # 1.5326   SGD => 1 EUR
currency(THB, 34.958);      # 34.958   THB => 1 EUR
currency(TRY, 7.7252);      # 7.7252   TRY => 1 EUR
currency(USD, 1.0843);      # 1.0843   USD => 1 EUR
currency(ZAR, 19.997);      # 19.997   ZAR => 1 EUR
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
currency(USD, 1.0843);      # 1.0843   USD => 1 EUR
>>> 2 USD
# 2 * USD
out = 1.8445079774970026745365673706 * EUR
>>> currency(GBP) # Defines GBP as the default currency instead of EUR
# currency(GBP) # Defines GBP as the default currency instead of EUR
out = GBP
>>> USD
currency(USD, 1.2387);      # 1.2387   USD => 1 GBP
>>> 2 USD |> to EUR # Convert 2 dollars to EUR
# 2 * USD |> to(EUR) # Convert 2 dollars to EUR
out = 1.844507977497004 * EUR
```
