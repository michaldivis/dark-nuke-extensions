using Nuke.Common;
using Nuke.Common.Tools.MSBuild;

namespace DarkNukeExtensions
{
    public static class VerbosityExtensions
    {
        /// <summary>
        /// Map the <see cref="Verbosity" /> to <see cref="MSBuildVerbosity" />
        /// </summary>
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
