using Nuke.Common;
using Nuke.Common.Tools.MSBuild;

namespace DarkNukeExtensions
{
    public static class VerbosityExtensions
    {
        public static MSBuildVerbosity ToMSBuildVerbosity(this Verbosity verbosity)
        {
            return verbosity switch
            {
                Verbosity.Verbose => MSBuildVerbosity.Diagnostic,
                Verbosity.Normal => MSBuildVerbosity.Normal,
                Verbosity.Minimal => MSBuildVerbosity.Minimal,
                Verbosity.Quiet => MSBuildVerbosity.Quiet,
                _ => MSBuildVerbosity.Normal
            };
        }
    }
}
