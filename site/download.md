---
title: Download
---
{{~ kalk_version = site.data.kalk.version ~}}
# Download

<img align="right" width="120px" height="120px" src="/img/kalk-logo-large.png">

`kalk` is supported on the following platforms:

- Windows x64
- Linux x64 (Debian derivatives - e.g Ubuntu and Redhat)
- macOS

{{NOTE do}}
The current stable version: **`{{ kalk_version }}`**
{{end}}

## Windows

The easiest and preferred way to install `kalk` is **available on the Windows Store**. This version can be updated automatically. (TODO: add link once available)

You can also download a zip archive [kalk.{{kalk_version}}.win-x64.zip]({{site.github_repo_url}}/releases/download/{{kalk_version}}/kalk.{{kalk_version}}.win-x64.zip)

## Linux

On Ubuntu and all Debian derivatives

```shell-session
$ wget {{site.github_repo_url}}/releases/download/{{kalk_version}}/kalk.{{kalk_version}}.linux-x64.deb
$ sudo apt install kalk.{{kalk_version}}.linux-x64.deb
```

On CentOS, RHEL & Fedora (RPM)

```shell-session
$ wget {{site.github_repo_url}}/releases/download/{{kalk_version}}/kalk.{{kalk_version}}.linux-x64.rpm
$ sudo rpm –i kalk.{{kalk_version}}.linux-x64.rpm
```

## macOS

You can install `kalk` with [homebrew](https://brew.sh/)

```shell-session
$ brew tap xoofx/kalk 
$ brew install kalk
```

You can also download a tar.gz archive [kalk.{{kalk_version}}.osx-x64.tar.gz]({{site.github_repo_url}}/releases/download/{{kalk_version}}/kalk.{{kalk_version}}.osx-x64.tar.gz)

## Installation with .NET

Alternatively, if you have [.NET 5.0 SDK installed](https://dotnet.microsoft.com/download/dotnet/5.0), you can install `kalk` as a .NET global tool:

```shell-session
$ dotnet tool install --global kalk --version {{kalk_version}}
```
