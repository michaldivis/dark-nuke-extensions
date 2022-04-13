using Nuke.Common.Tools.MSBuild;

namespace DarkNukeExtensions
{
    public class AndroidPublishSettings
    {
        public string TargetPath { get; init; }
        public string OutDir { get; init; }
        public string Configuration { get; init; }
        public MSBuildVerbosity Verbosity { get; init; }
    }
}
