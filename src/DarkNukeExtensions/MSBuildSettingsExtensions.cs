using Nuke.Common.Tools.MSBuild;

namespace DarkNukeExtensions
{
    public static class MSBuildSettingsExtensions
    {
        private static AndroidPublishSettingsValidator? _androidPublishSettingsValidator;
        private static AndroidPublishSettingsValidator GetAndroidPublishSettingsValidator() => _androidPublishSettingsValidator ??= new AndroidPublishSettingsValidator();

        /// <summary>
        /// Publish an Android app bundle
        /// </summary>
        /// <exception cref="SettingsValidationException" />
        public static MSBuildSettings PublishAndroidApp(this MSBuildSettings o, AndroidPublishSettings settings)
        {
            var validation = GetAndroidPublishSettingsValidator().Validate(settings);

            if (!validation.IsValid)
            {
                throw new SettingsValidationException(validation.Errors);
            }

            return o
               .SetTargetPath(settings.TargetPath)
               .EnableRestore()
               .SetVerbosity(settings.Verbosity)
               .SetTargets("SignAndroidPackage")
               .SetOutDir(settings.OutDir)
               .SetConfiguration(settings.Configuration);
        }

        private static IosPublishSettingsValidator? _iosPublishSettingsValidator;
        private static IosPublishSettingsValidator GetIosPublishSettingsValidator() => _iosPublishSettingsValidator ??= new IosPublishSettingsValidator();

        /// <summary>
        /// Publish an iOS IPA package
        /// </summary>
        /// <exception cref="SettingsValidationException" />
        public static MSBuildSettings PublishIosApp(this MSBuildSettings o, IosPublishSettings settings)
        {
            var validation = GetIosPublishSettingsValidator().Validate(settings);

            if (!validation.IsValid)
            {
                throw new SettingsValidationException(validation.Errors);
            }

            return o
                .SetTargetPath(settings.TargetPath)
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
        }
    }
}
