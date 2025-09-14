---
title: Download
---
{{~ 
kalk_version = site.data.kalk.version 
~}}
# Download

<img align="right" width="120px" height="120px" src="/img/kalk-logo-large.png">

`kalk` is supported on the following platforms:

- Windows x64, arm, arm64
- Linux x64, arm64 (Debian derivatives - e.g Ubuntu - and distributions supporting RPM packages)
- macOS x64, arm64 (High Sierra and higher)

{{NOTE do}}
The current stable version: **`{{ kalk_version }}`** ([Release notes]({{site.github_repo_url}}/releases/tag/{{kalk_version}}))

- `kalk` requires a terminal that supports ANSI escape codes. 
- On Windows, `kalk` works best on **Windows 10** which has built-in support for terminal with ANSI escape codes and with the new [Windows Terminal](https://www.microsoft.com/en-us/p/windows-terminal/9n0dx20hk701).
- `kalk` might not work well if your terminal doesn't have the same level of support than the Windows Terminal regarding ANSI escape codes.
{{end}}

## Installation with .NET

If you have [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) already installed, you can then easily install `kalk` as a .NET global tool:

```shell-session
$ dotnet tool install --global kalk
```

If you have already kalk installed, use the update command:

```shell-session
$ dotnet tool update --global kalk
```

## Windows

The easiest way to install `kalk` on Windows is to install it as a .NET global tool as described above.

Alternatively, you can download:

- A simple zip archive [kalk.{{kalk_version}}.win-x64.zip]({{site.github_repo_url}}/releases/download/{{kalk_version}}/kalk.{{kalk_version}}.win-x64.zip)

If you're a [Scoop](https://scoop.sh) user, then you can install `kalk` from the official bucket:

```shell-session
$ scoop install kalk
```

## Linux

On Ubuntu and all Debian derivatives

```shell-session
$ wget {{site.github_repo_url}}/releases/download/{{kalk_version}}/kalk.{{kalk_version}}.linux-x64.deb
$ sudo apt install ./kalk.{{kalk_version}}.linux-x64.deb
```

On CentOS, RHEL & Fedora (RPM)

```shell-session
$ wget {{site.github_repo_url}}/releases/download/{{kalk_version}}/kalk.{{kalk_version}}.linux-x64.rpm
$ sudo rpm –i ./kalk.{{kalk_version}}.linux-x64.rpm
```

## macOS

> `kalk` requires a macOS with High Sierra or higher.

You can install `kalk` with [homebrew](https://brew.sh/)

```shell-session
$ brew tap xoofx/kalk 
$ brew install kalk
```

You can upgrade `kalk` with the following brew command:

```shell-session
$ brew upgrade kalk
```

You can also download a tar.gz archive [kalk.{{kalk_version}}.osx-x64.tar.gz]({{site.github_repo_url}}/releases/download/{{kalk_version}}/kalk.{{kalk_version}}.osx-x64.tar.gz)
