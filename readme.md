# kalk [![code](https://github.com/xoofx/kalk/actions/workflows/code.yml/badge.svg)](https://github.com/xoofx/kalk/actions/workflows/code.yml) [![site](https://github.com/xoofx/kalk/actions/workflows/site.yml/badge.svg)](https://github.com/xoofx/kalk/actions/workflows/site.yml) [![NuGet](https://img.shields.io/nuget/v/kalk.svg)](https://www.nuget.org/packages/kalk/)

<img align="right" width="160px" height="160px" src="https://raw.githubusercontent.com/xoofx/kalk/master/img/kalk.png">

This is the repository of [kalk](https://kalk.dev), a powerful command line **calculator app** for developers.

## Supported Platforms

- Windows x64
- Linux x64 (Debian derivatives - e.g Ubuntu - and distributions supporting RPM packages)
- macOS (High Sierra and higher)

## Download

Visit the [Download](https://kalk.dev/download) section.

## How to Build?

You need to install the [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0).

Then from the root folder:

```console
$ dotnet build src -c Release
```

Alternatively, you can install latest Visual Studio 2022 and open the `src/kalk.sln` solution.

## License

This software is released under the [BSD-Clause 2 license](https://opensource.org/licenses/BSD-2-Clause). 

## Author

Alexandre Mutel aka [xoofx](https://xoofx.github.io).
