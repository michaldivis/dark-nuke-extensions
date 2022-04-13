using DarkNukeExtensions;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;
using static DarkNukeExtensions.FileSystemTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;

[CheckBuildProjectConfigurations]
class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Mobile);

    [Solution] readonly Solution Solution;

    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    private const string Configuration = "Release";

    #region Utils

    Target Clean => _ => _
        .Executes(() =>
        {
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    #endregion

    #region Libs

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target CompileLib => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution.GetProject("SampleApp"))
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    #endregion

    #region Android

    Target CleanAndroid => _ => _
        .Executes(() =>
        {
            DeleteBinAndObjDirectories(Solution.GetProject("SampleApp.Android"), retryCount: 3);
        });

    Target Android => _ => _
       .DependsOn(CleanAndroid)
       .DependsOn(CompileLib)
       .Executes(() =>
       {
           MSBuild(o => o.PublishAndroidApp(new AndroidPublishSettings
           {
               TargetPath = Solution.GetProject("SampleApp.Android"),
               OutDir = ArtifactsDirectory / "App_Android",
               Configuration = Configuration,
               Verbosity = Verbosity.ToMSBuildVerbosity()
           }));
       });

    #endregion

    #region iOS

    Target CleaniOS => _ => _
        .Executes(() =>
        {
            DeleteBinAndObjDirectories(Solution.GetProject("SampleApp.iOS"), retryCount: 3);
        });

    Target iOS => _ => _
        .DependsOn(CleaniOS)
        .DependsOn(CompileLib)
        .Executes(() =>
        {
            MSBuild(o => o.PublishIosApp(new IosPublishSettings
            {
                TargetPath = Solution.GetProject("SampleApp.iOS"),
                OutDir = ArtifactsDirectory / "App_iOS",
                Configuration = Configuration,
                Verbosity = Verbosity.ToMSBuildVerbosity(),
                PackageName = "SampleApp",
                MacServerAddress = "{MyMacAddress}",
                MacServerUser = "{MyMacUser}",
                MacServerPassword = "{MyMacPassword}"
            }));
        });

    #endregion

    Target Mobile => _ => _
        .DependsOn(Android)
        .DependsOn(iOS);
}
