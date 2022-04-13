using FluentAssertions;
using Nuke.Common;
using Nuke.Common.IO;
using System;
using Xunit;

namespace DarkNukeExtensions;

public class FileSystemTasksTests
{
    private readonly AbsolutePath _validProjectDirectory = EnvironmentInfo.WorkingDirectory / "MyProject";
    private const int _validRetryCount = 3;

    [Fact]
    public void DeleteBinAndObjDirectories_ShouldNotThrow_WhenParamsValid()
    {
        Action act = () => FileSystemTasks.DeleteBinAndObjDirectories(_validProjectDirectory, _validRetryCount);
        act.Should().NotThrow();
    }

    [Fact]
    public void DeleteBinAndObjDirectories_ShouldThrow_WhenProjectDirectoryNull()
    {
        Action act = () => FileSystemTasks.DeleteBinAndObjDirectories(null!, _validRetryCount);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void DeleteBinAndObjDirectories_ShouldThrow_WhenProjectDirectoryEmpty()
    {
        Action act = () => FileSystemTasks.DeleteBinAndObjDirectories((AbsolutePath)string.Empty, _validRetryCount);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void DeleteBinAndObjDirectories_ShouldThrow_WhenRetryCountNegative()
    {
        Action act = () => FileSystemTasks.DeleteBinAndObjDirectories(_validProjectDirectory, -5);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void DeleteBinAndObjDirectories_ShouldThrow_WhenRetryCountZero()
    {
        Action act = () => FileSystemTasks.DeleteBinAndObjDirectories(_validProjectDirectory, 0);
        act.Should().Throw<ArgumentException>();
    }
}
