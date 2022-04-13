using Nuke.Common.Tools.MSBuild;

namespace DarkNukeExtensions
{
    public class IosPublishSettings
    {
        public string TargetPath { get; init; }
        public string OutDir { get; init; }
        public string Configuration { get; init; }
        public MSBuildVerbosity Verbosity { get; init; }

        public string PackageName { get; init; }
        public string MacServerAddress { get; init; }
        public string MacServerUser { get; init; }
        public string MacServerPassword { get; init; }
    }
}
