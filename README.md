<img src="https://github.com/michaldivis/dark-nuke-extensions/blob/v0.1.0-alpha/assets/icon.png?raw=true" width="100">

# Dark NUKE Extensions

A set of helper methods for publishing [Xamarin.Forms](https://xamarin.com/forms) Android and iOS apps using the [NUKE build system](https://nuke.build/).

## Nuget
[![Nuget](https://img.shields.io/nuget/v/divis.darknukeextensions?label=Divis.DarkNukeExtensions)](https://www.nuget.org/packages/Divis.DarkNukeExtensions/)

## Simplified Android and iOS builds
I've copy and pasted the same MSBuild configuration code for Android and iOS app for the longest time, but not anymore! This library is just a few methods to help streamline that syntax and keep from repeating it everywhere.

Publish an Android app
```csharp
using DarkNukeExtensions;

MSBuild(o => o.PublishAndroidApp(new AndroidPublishSettings
    {
        TargetPath = Solution.GetProject("SampleApp.Android"),
        OutDir = ArtifactsDirectory / "App_Android",
        Configuration = Configuration,
        Verbosity = Verbosity.ToMSBuildVerbosity()
    }));
```

Publish an iOS app
```csharp
using DarkNukeExtensions;

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
```

## Cleaning the `bin` and `obj` folders
For whatever reason, the Xamarin.Android `bin` and `obj` folders would sometimes fail to be deleted when using the regular methods for deleting directories provided by Nuke. This method is a simple hard delete with a retry policy and it seems to work better for this purpose.

```csharp
using static DarkNukeExtensions.FileSystemTasks;

DeleteBinAndObjDirectories(Solution.GetProject("SampleApp.Android").Directory, retryCount: 3);
```

## Verbosity mapping
Simple mapping of the Nuke `Verbosity` enum to `MSBuildVerbosity`. Nuke accepts a verbosity parameter by default, that parameter is stored in the `Verbosity` property. Use this method in order to pass the verbosity setting to MSBuild.

```csharp
using DarkNukeExtensions;

Verbosity verbosity = Verbosity.Normal;
MSBuildVerbosity msBuildVerbosity = verbosity.ToMSBuildVerbosity();
```