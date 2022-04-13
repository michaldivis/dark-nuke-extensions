using Nuke.Common.Tools.MSBuild;

namespace DarkNukeExtensions;

public class IosPublishSettings
{
    /// <summary>
    /// Target project path
    /// </summary>
    public string TargetPath { get; init; }

    /// <summary>
    /// Output directory the app bundle will be published to
    /// </summary>
    public string OutDir { get; init; }

    /// <summary>
    /// Build configuration, defaults to Release
    /// </summary>
    public string Configuration { get; init; } = "Release";

    /// <summary>
    /// Build verbosity, defaults to <see cref="MSBuildVerbosity.Normal" />
    /// </summary>
    public MSBuildVerbosity Verbosity { get; init; } = MSBuildVerbosity.Normal;

    /// <summary>
    /// IPA package name, example: "MyAppPackage" will result in "MyAppPackage.ipa"
    /// </summary>
    public string PackageName { get; init; }

    /// <summary>
    /// IP address of the MAC used to build the app
    /// </summary>
    public string MacServerAddress { get; init; }

    /// <summary>
    /// Username of the MAC used to build the app
    /// </summary>
    public string MacServerUser { get; init; }

    /// <summary>
    /// User password of the MAC used to build the app
    /// </summary>
    public string MacServerPassword { get; init; }
}
