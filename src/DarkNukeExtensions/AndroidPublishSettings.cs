using Nuke.Common.Tools.MSBuild;

namespace DarkNukeExtensions;

public class AndroidPublishSettings
{
    /// <summary>
    /// Target project path
    /// </summary>
    public string? TargetPath { get; init; }

    /// <summary>
    /// Output directory the app bundle will be published to
    /// </summary>
    public string? OutDir { get; init; }

    /// <summary>
    /// Build configuration, defaults to Release
    /// </summary>
    public string Configuration { get; init; } = "Release";

    /// <summary>
    /// Build verbosity, defaults to <see cref="MSBuildVerbosity.Normal" />
    /// </summary>
    public MSBuildVerbosity Verbosity { get; init; } = MSBuildVerbosity.Normal;
}
