using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using Mono.Options;
using Octokit;

namespace Kalk.Releaser
{
    /// <summary>
    /// Packager App for Kalk:
    /// 
    /// - Update release from changelog
    /// 
    /// - Build NuGet package
    /// - Build single exe file with archive for:
    ///   - linux-x64/deb
    ///   - linux-x64/rpm
    ///   - win-x64/zip
    ///   - osx-x64/tar.gz
    /// - All build artifacts are in the build folder
    /// - Update Release on GitHub with all assets
    /// - Update xoofx/homebrew-kalk
    /// - Push the NuGet package
    /// </summary>
    class ReleaserApp
    {
        private readonly string _user;
        private readonly string _repo;
        private readonly string _rootFolder;
        private readonly string _srcFolder;
        private readonly string _baseConsoleAppFolder;
        private readonly string _baseConsoleNet5ReleaseFolder;
        private readonly string _buildFolder;
        private readonly ILogger _log;
        private bool _hasErrors = false;
        private int _logId;

        public ReleaserApp()
        {
            _user = "xoofx";
            _repo = "kalk";
            _rootFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            _srcFolder = Path.Combine(_rootFolder, "src");
            _buildFolder = Path.Combine(_rootFolder, "build");
            _baseConsoleAppFolder = Path.Combine(_srcFolder, "Kalk.ConsoleApp");
            _baseConsoleNet5ReleaseFolder = Path.Combine(_baseConsoleAppFolder, "bin", "Release", "net5.0");
            // Create our log
            _log = LoggerFactory.Create(builder =>
            {
                builder.AddSimpleConsole(configure: options =>
                {
                    //options.SingleLine = true;
                });
            }).CreateLogger("krel");
        }

        public async Task<int> Run(string[] args)
        {
            bool showHelp = false;
            var _ = string.Empty;
            string githubApiToken = null;
            string nugetApiToken = null;
            var options = new OptionSet
            {
                "kalk release app",
                _,
                "Usage: krel [options]",
                _,
                "## Options",
                _,
                {"h|help", "Show this message and exit", (bool v) => showHelp = v},
                {"g|github=", "GitHub Api Token", v => githubApiToken = v},
                {"n|nuget=", "NuGet Api Token", v => nugetApiToken = v},
            };

            options.OptionWidth = 40;
            options.LineWidth = 100;
            options.ShiftNewLine = 0;
            try
            {
                var arguments = options.Parse(args);

                if (showHelp)
                {
                    options.WriteOptionDescriptions(Console.Out);
                    return 0;
                }

                if (githubApiToken == null)
                {
                    throw new OptionException("Missing GitHub Api Token", "github");
                }
                if (nugetApiToken == null)
                {
                    throw new OptionException("Missing NuGet Api Token", "nuget");
                }
            }
            catch (OptionException exception)
            {
                var backColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync($"{exception.Message}. Option --{exception.OptionName}");
                Console.ForegroundColor = backColor;
                await Console.Out.WriteLineAsync("See --help for usage");
                Environment.ExitCode = 1;
                return Environment.ExitCode;
            }

            var packageInfo = LoadPackageInfo();
            var version = LoadVersion();
            packageInfo.Version = version;
            var changelog = await LoadChangeLog(version);

            // Make sure that release folder is deleted before building/packaging
            if (Directory.Exists(_baseConsoleNet5ReleaseFolder))
            {
                Directory.Delete(_baseConsoleNet5ReleaseFolder, true);
            }

            // Create the build folder
            if (!Directory.Exists(_buildFolder))
            {
                Directory.CreateDirectory(_buildFolder);
            }
            else
            {
                // TODO: option to force cleanup?
            }

            // Build NuGet
            BuildNuGet(packageInfo);

            // Build Appx
            BuildAppx(packageInfo);

            // Build all archives
            var win64Zip =  PackPlatform("win-x64", version, PackageKind.Zip);
            var linux64DebAndRpm = PackPlatform("linux-x64", version, PackageKind.Deb, PackageKind.Rpm);
            var macOSTarGz = PackPlatform("osx-x64", version, PackageKind.TarBall);

            var entries = win64Zip.Concat(linux64DebAndRpm).Concat(macOSTarGz).ToList();

            Info("Connecting to GitHub");

            var github = new GitHubClient(new ProductHeaderValue("krel"));

            var tokenAuth = new Credentials(githubApiToken); // NOTE: not real token
            github.Credentials = tokenAuth;

            var releases = await github.Repository.Release.GetAll(_user, _repo);
            var release = releases.FirstOrDefault(releaseCheck => releaseCheck.TagName == version) ??
                          await github.Repository.Release.Create(_user, _repo, new NewRelease(version));

            Info($"Loading release tag {release.TagName}");

            ReleaseUpdate releaseUpdate = null;
            if (release.Body != changelog)
            {
                releaseUpdate = release.ToUpdate();
                releaseUpdate.Body = changelog;
            }

            // Update the body if necessary
            if (releaseUpdate != null)
            {
                Info($"Updating release {release.TagName} with new changelog");
                release = await github.Repository.Release.Edit(_user, _repo, release.Id, releaseUpdate);
            }

            var assets = await github.Repository.Release.GetAllAssets(_user, _repo, release.Id, ApiOptions.None);

            foreach (var entry in entries)
            {
                var filename = Path.GetFileName(entry.Path);
                if (assets.Any(x=> x.Name == filename))
                {
                    Info($"No need to update {entry.Path} on GitHub. Already uploaded.");
                    continue;
                }

                const int maxHttpRetry = 10;
                for (int i = 0; i < maxHttpRetry; i++)
                {
                    try
                    {
                        Info($"{(i > 0 ? $"Retry ({{i}}/{maxHttpRetry-1}) ":"")}Uploading {filename} to GitHub Release: {version} (Size: {new FileInfo(entry.Path).Length / (1024 * 1024)}MB)");
                        // Upload assets
                        using (var stream = File.OpenRead(entry.Path))
                        {
                            await github.Repository.Release.UploadAsset(release, new ReleaseAssetUpload(filename, entry.Mime, stream, new TimeSpan(0, 5, 0)));
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        // In case of a failure to upload try to delete the asset
                        try
                        {
                            assets = await github.Repository.Release.GetAllAssets(_user, _repo, release.Id, ApiOptions.None);
                            var assetToDelete = assets.FirstOrDefault(x => x.Name == filename);
                            await github.Repository.Release.DeleteAsset(_user, _repo, assetToDelete.Id);

                            // Refresh the list of the assets
                            assets = await github.Repository.Release.GetAllAssets(_user, _repo, release.Id, ApiOptions.None);
                        }
                        catch
                        {
                            Error($"Failure to delete the remote asset: {filename}");
                            // ignored
                        }

                        if (i + 1 == maxHttpRetry)
                        {
                            Error($"Upload failed: {ex} after {maxHttpRetry} retries.");
                        }
                        else
                        {
                            const int millisecondsDelay = 100;
                            Warning($"Upload failed: {ex.Message}. Retrying after {millisecondsDelay}ms...");
                            await Task.Delay(millisecondsDelay);
                        }
                    }
                }
            }

            // Update homebrew
            await UploadBrewFormula(github, macOSTarGz[0], packageInfo);

            // Publish NuGet - last
            PublishNuGet(packageInfo, nugetApiToken);

            Environment.ExitCode = _hasErrors ? 1 : 0;
            return Environment.ExitCode;
        }

        private void BuildAppx(PackageInfo packageInfo)
        {
            Info($"Building Appx {packageInfo.Version}");
            var storeAppFolder = Path.Combine(_srcFolder, "Kalk.StoreApp");
            var storeAppBinFolder = Path.Combine(storeAppFolder, "bin", "Release");
            if (Directory.Exists(storeAppBinFolder))
            {
                Directory.Delete(storeAppBinFolder, true);
            }
            var storeAppFile = Path.Combine(storeAppBinFolder, $"kalk.{packageInfo.Version}.win-x64.appx");
            var program = new DotNetProgram("publish")
            {
                Arguments =
                {
                    "-c Release"
                },
                WorkingDirectory = storeAppFolder
            };
            program.Run();

            if (!File.Exists(storeAppFile))
            {
                Error($"Unable to find generated Appx file {storeAppFile}");
                return;
            }

            File.Copy(storeAppFile, Path.Combine(_buildFolder, Path.GetFileName(storeAppFile)), true);
        }
        
        private void PublishNuGet(PackageInfo packageInfo, string nugetSecretKey)
        {
            try
            {
                var program = new DotNetProgram("nuget")
                {
                    Arguments =
                    {
                        "push",
                        "*.nupkg",
                        "-s https://api.nuget.org/v3/index.json",
                        $"-k {nugetSecretKey}"
                    },
                    WorkingDirectory = _buildFolder
                };
                program.Run();
            }
            catch (Exception ex)
            {
                var message = ex.Message.Replace(nugetSecretKey, "**********");
                Error($"Failing to push nuget package. Reason: {message}");
            }
        }
        
        private void BuildNuGet(PackageInfo packageInfo)
        {
            Info($"Building NuGet {packageInfo.Version}");
            var nugetPath = Path.Combine(_baseConsoleAppFolder, "bin", "Release", $"{_repo}.{packageInfo.Version}.nupkg");
            if (File.Exists(nugetPath))
            {
                File.Delete(nugetPath);
            }

            var program = new DotNetProgram("pack")
            {
                Arguments =
                {
                    "-c Release",
                },
            };
            program.WorkingDirectory = _baseConsoleAppFolder;
            program.Run();

            if (!File.Exists(nugetPath))
            {
                Error($"Unable to find generated NuGet file {nugetPath}");
                return;
            }

            File.Copy(nugetPath, Path.Combine(_buildFolder, Path.GetFileName(nugetPath)), true);
        }

        private async Task UploadBrewFormula(GitHubClient github, PackageEntry entry, PackageInfo packageInfo)
        {
            var homebrew = $"homebrew-{_repo}";
            var filePath = $"Formula/{_repo}.rb";
            var stringFormula = $@"class Kalk < Formula
  desc ""{EscapeRuby(packageInfo.Description)}""
  homepage ""https://github.com/{_user}/{_repo}""
  url ""https://github.com/{_user}/{_repo}/releases/download/{packageInfo.Version}/{Path.GetFileName(entry.Path)}""
  sha256 ""{entry.Sha256}""
  license ""{packageInfo.License}""
  version ""{packageInfo.Version}""

  def install
    bin.install ""kalk""
  end
end
".Replace("\r\n", "\n"); // replace with \n only

            var result = await github.Repository.Content.GetAllContents(_user, homebrew, filePath);
            if (result.Count != 1)
            {
                Error($"Unable to find file {filePath} on {_user}/{homebrew}");
                return;
            }

            var file = result[0];
            if (file.Content != stringFormula)
            {
                Info($"Updating Homebrew Formula {_user}/{homebrew}");
                await github.Repository.Content.UpdateFile(_user, homebrew, filePath, new UpdateFileRequest($"{packageInfo.Version}", stringFormula, file.Sha));
            }
            else
            {
                Info($"No need to update Homebrew Formula {_user}/{homebrew}. Already up-to-date.");
            }
        }

        private static string EscapeRuby(string text)
        {
            return text.Replace("\"", @"\""");
        }

        private void Info(string message)
        {
            _log.LogInformation(new EventId(_logId++), message);
        }

        private void Warning(string message)
        {
            _log.LogWarning(new EventId(_logId++), message);
        }

        private void Error(string message)
        {
            _hasErrors = true;
            _log.LogError(new EventId(_logId++), message);
        }

        private string LoadVersion()
        {
            var path = Path.Combine(_srcFolder, "Version.props");
            var doc = XElement.Load(path);

            var versionPrefix = doc.Descendants("VersionPrefix").First().Value;
            var versionSuffix = doc.Descendants("VersionSuffix").First().Value;

            var version = $"{versionPrefix}";
            if (!string.IsNullOrEmpty(versionSuffix))
            {
                version = $"{version}-{versionSuffix}";
            }

            return version;
        }

        private PackageInfo LoadPackageInfo()
        {
            var path = Path.Combine(_baseConsoleAppFolder, "Kalk.props");
            var doc = XElement.Load(path);
            var info = new PackageInfo();
            info.Description = doc.Descendants("Description").FirstOrDefault()?.Value;
            if (info.Description == null)
            {
                Error($"Unable to load package description from {path}");
            }
            info.License = doc.Descendants("PackageLicenseExpression").FirstOrDefault()?.Value;
            if (info.License == null)
            {
                Error($"Unable to load package license from {path}");
            }
            return info;
        }

        private enum PackageKind
        {
            Zip,
            TarBall,
            Deb,
            Rpm,
        }

        private class PackageInfo
        {
            public string Version { get; set; }

            public string Description { get; set; }

            public string License { get; set; }
        }

        private List<PackageEntry> PackPlatform(string rid, string version, params PackageKind[] kinds)
        {

            var program = new DotNetProgram("publish")
            {
                Arguments =
                {
                    "-c Release",
                    $"-r {rid}",
                },
                Properties =
                {
                    {"PublishTrimmed", true},
                    {"TrimMode", "Link"},
                    {"PublishSingleFile", true},
                    {"SelfContained", true},
                    {"CopyOutputSymbolsToPublishDirectory", false},
                    {"SkipCopyingSymbolsToOutputDirectory", true}
                }
            };

            var entries = new List<PackageEntry>();
            bool hasTargetToBuild = false;
            foreach (var kind in kinds)
            {
                string target = null;
                string ext;
                string mime;
                switch (kind)
                {
                    case PackageKind.Deb:
                        target = "CreateDeb";
                        ext = "deb";
                        mime = "application/vnd.debian.binary-package";
                        break;
                    case PackageKind.Rpm:
                        target = "CreateRpm";
                        ext = "rpm";
                        mime = "application/x-rpm";
                        break;
                    case PackageKind.Zip:
                        target = "CreateZip";
                        ext = "zip";
                        mime = "application/zip";
                        break;
                    case PackageKind.TarBall:
                        target = "CreateTarball";
                        ext = "tar.gz";
                        mime = "application/gzip";
                        break;
                    default:
                        throw new ArgumentException($"Invalid kind {kind}", nameof(kind));
                }

                var file = Path.Combine(_baseConsoleNet5ReleaseFolder, rid, $"kalk.{version}.{rid}.{ext}");

                var buildFile = Path.Combine(_buildFolder, $"kalk.{version}.{rid}.{ext}");


                Info($"Building {Path.GetFileName(file)}");
                var entry = new PackageEntry()
                {
                    Kind = kind,
                    Path = file,
                    RuntimeId = rid,
                    Mime = mime
                };
                entries.Add(entry);

                if (File.Exists(buildFile))
                {
                    entry.Path = buildFile;
                    continue;
                }

                program.Arguments.Add($"-t:{target}");
                hasTargetToBuild = true;
            }

            // Build only if required
            if (hasTargetToBuild)
            {
                program.WorkingDirectory = _baseConsoleAppFolder;
                program.Run();
            }

            foreach (var entry in entries)
            {
                if (!File.Exists(entry.Path))
                {
                    throw new InvalidOperationException($"Cannot find the generatd file: {entry.Path}");
                }

                // Copy the result of the build to if necessary
                var buildPath = Path.Combine(_buildFolder, Path.GetFileName(entry.Path));
                if (buildPath != entry.Path)
                {
                    File.Copy(entry.Path, buildPath);
                    entry.Path = buildPath;
                }

                if (entry.Kind == PackageKind.TarBall)
                {
                    entry.ComputeSha256();
                }
            }

            return entries;
        }

        private class PackageEntry
        {
            public string RuntimeId { get; set; }

            public PackageKind Kind { get; set; }

            public string Path { get; set; }

            public string Mime { get; set; }

            public string Sha256 { get; set; }

            public void ComputeSha256()
            {
                Sha256 = string.Join("", SHA256.HashData(File.ReadAllBytes(Path)).Select(x => x.ToString("x2")));
            }
        }

        private async Task<string> LoadChangeLog(string version)
        {
            var lines = await File.ReadAllLinesAsync(Path.Combine(_rootFolder, "changelog.md"));

            var versionMark = $"## {version}";

            var builder = new StringBuilder();

            bool versionFound = false;
            foreach (var line in lines)
            {
                if (line == versionMark)
                {
                    versionFound = true;
                }
                else if (line.StartsWith("## "))
                {
                    continue;
                }
                else if (versionFound)
                {
                    builder.AppendLine(line);
                }
            }

            if (!versionFound)
            {
                throw new InvalidOperationException($"Unable to find version {version} from changelog.md");
            }

            return builder.ToString().Trim();
        }
    }
}
