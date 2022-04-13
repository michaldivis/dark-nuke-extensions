using FluentAssertions;
using Nuke.Common.Tools.MSBuild;
using System;
using Xunit;

namespace DarkNukeExtensions;

public class MSBuildSettingsExtensionsTests
{
    private const string _validConfiguration = "Release";
    private readonly MSBuildVerbosity _validVerbosity = MSBuildVerbosity.Normal;
    private const string _validTargetPath = @"C:/Projects/Something/Something.csproj";
    private const string _validOutDir = @"C:/Projects/Something/artifacts";
    private const string _validPackageName = "MyApp"; 
    private const string _validMacAddress = "MacAddress";
    private const string _validMacUsername = "MacUsername";
    private const string _validMacPassword = "MacPassword";

    #region PublishAndroidApp

    [Fact]
    public void PublishAndroidApp_ShouldNotThrow_WhenSettingsValid()
    {
        Action act = () => new MSBuildSettings().PublishAndroidApp(new AndroidPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir
        });
        act.Should().NotThrow();
    }

    [Fact]
    public void PublishAndroidApp_ShouldThrow_WhenSettingsEmpty()
    {
        Action act = () => new MSBuildSettings().PublishAndroidApp(new AndroidPublishSettings());
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishAndroidApp_ShouldThrow_WhenConfigurationEmpty()
    {
        Action act = () => new MSBuildSettings().PublishAndroidApp(new AndroidPublishSettings
        {
            Configuration = string.Empty,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishAndroidApp_ShouldThrow_WhenVerbosityNull()
    {
        Action act = () => new MSBuildSettings().PublishAndroidApp(new AndroidPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = null!,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishAndroidApp_ShouldThrow_WhenTargetPathEmpty()
    {
        Action act = () => new MSBuildSettings().PublishAndroidApp(new AndroidPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = string.Empty,
            OutDir = _validOutDir
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishAndroidApp_ShouldThrow_WhenTargetPathInvalid()
    {
        Action act = () => new MSBuildSettings().PublishAndroidApp(new AndroidPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = @"C:/Invalid/Path/Example.pdf",
            OutDir = _validOutDir
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishAndroidApp_ShouldThrow_WhenOutDirEmpty()
    {
        Action act = () => new MSBuildSettings().PublishAndroidApp(new AndroidPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = string.Empty
        });
        act.Should().Throw<SettingsValidationException>();
    }

    #endregion

    #region PublishIosApp

    [Fact]
    public void PublishIosApp_ShouldNotThrow_WhenSettingsValid()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir,
            PackageName = _validPackageName,
            MacServerAddress = _validMacAddress,
            MacServerUser = _validMacUsername,
            MacServerPassword = _validMacPassword
        });
        act.Should().NotThrow();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenSettingsEmpty()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings());
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenConfigurationEmpty()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = string.Empty,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir,
            PackageName = _validPackageName,
            MacServerAddress = _validMacAddress,
            MacServerUser = _validMacUsername,
            MacServerPassword = _validMacPassword
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenVerbosityNull()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = null!,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir,
            PackageName = _validPackageName,
            MacServerAddress = _validMacAddress,
            MacServerUser = _validMacUsername,
            MacServerPassword = _validMacPassword
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenTargetPathEmpty()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = string.Empty,
            OutDir = _validOutDir,
            PackageName = _validPackageName,
            MacServerAddress = _validMacAddress,
            MacServerUser = _validMacUsername,
            MacServerPassword = _validMacPassword
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenTargetPathInvalid()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = @"C:/Invalid/Path/Example.pdf",
            OutDir = _validOutDir,
            PackageName = _validPackageName,
            MacServerAddress = _validMacAddress,
            MacServerUser = _validMacUsername,
            MacServerPassword = _validMacPassword
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenOutDirEmpty()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = string.Empty,
            PackageName = _validPackageName,
            MacServerAddress = _validMacAddress,
            MacServerUser = _validMacUsername,
            MacServerPassword = _validMacPassword
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenPackageNameEmpty()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir,
            PackageName = string.Empty,
            MacServerAddress = _validMacAddress,
            MacServerUser = _validMacUsername,
            MacServerPassword = _validMacPassword
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenMacAddressEmpty()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir,
            PackageName = _validPackageName,
            MacServerAddress = string.Empty,
            MacServerUser = _validMacUsername,
            MacServerPassword = _validMacPassword
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenMacUsernameEmpty()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir,
            PackageName = _validPackageName,
            MacServerAddress = _validMacAddress,
            MacServerUser = string.Empty,
            MacServerPassword = _validMacPassword
        });
        act.Should().Throw<SettingsValidationException>();
    }

    [Fact]
    public void PublishIosApp_ShouldThrow_WhenMacPasswordEmpty()
    {
        Action act = () => new MSBuildSettings().PublishIosApp(new IosPublishSettings
        {
            Configuration = _validConfiguration,
            Verbosity = _validVerbosity,
            TargetPath = _validTargetPath,
            OutDir = _validOutDir,
            PackageName = _validPackageName,
            MacServerAddress = _validMacAddress,
            MacServerUser = _validMacUsername,
            MacServerPassword = string.Empty
        });
        act.Should().Throw<SettingsValidationException>();
    }

    #endregion
}