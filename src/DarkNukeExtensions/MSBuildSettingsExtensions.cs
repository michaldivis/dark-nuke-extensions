using Nuke.Common.Tools.MSBuild;

namespace DarkNukeExtensions
{
    public static class MSBuildSettingsExtensions
    {
        public static MSBuildSettings PublishAndroidApp(this MSBuildSettings o, AndroidPublishSettings settings)
        {
            //TODO validate settings

            o.SetTargetPath(settings.TargetPath)
               .EnableRestore()
               .SetVerbosity(settings.Verbosity)
               .SetTargets("SignAndroidPackage")
               .SetOutDir(settings.OutDir)
               .SetConfiguration(settings.Configuration);
            return o;
        }

        public static MSBuildSettings PublishIosApp(this MSBuildSettings o, IosPublishSettings settings)
        {
            //TODO validate settings

            o.SetTargetPath(settings.TargetPath)
                .EnableRestore()
                .SetVerbosity(settings.Verbosity)
                .AddProperty("Platform", "iPhone")
                .AddProperty("BuildIpa", "true")
                .AddProperty("IpaPackageDir", settings.OutDir)
                .AddProperty("IpaPackageName", $"{settings.PackageName}.ipa")
                .AddProperty("ServerAddress", settings.MacServerAddress)
                .AddProperty("ServerUser", settings.MacServerUser)
                .AddProperty("ServerPassword", settings.MacServerPassword)
                .AddProperty("ContinueOnDisconnected", "false")
                .SetTargets("Build")
                .SetConfiguration(settings.Configuration);
            return o;
        }
    }
}
