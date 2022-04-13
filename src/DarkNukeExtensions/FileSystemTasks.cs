using Nuke.Common.ProjectModel;
using Serilog;
using System;
using System.IO;
using Ardalis.GuardClauses;
using Nuke.Common.IO;

namespace DarkNukeExtensions
{
    public static class FileSystemTasks
    {
        /// <summary>
        /// Tries to delete the bin and obj directories of a project (with retries)
        /// </summary>
        public static void DeleteBinAndObjDirectories(AbsolutePath projectDirectory, int retryCount = 3)
        {
            Guard.Against.NullOrEmpty(projectDirectory);
            Guard.Against.NegativeOrZero(retryCount);

            TryDeleteDirectory(projectDirectory / "bin", retryCount);
            TryDeleteDirectory(projectDirectory / "obj", retryCount);
        }

        private static void TryDeleteDirectory(string dirPath, int retryCount = 3)
        {
            for (var i = 1; i <= retryCount; i++)
            {
                try
                {
                    Log.Information("[attempt {0} of {1}] Trying to delete directory: {2}", i, retryCount, dirPath);
                    Directory.Delete(dirPath, true);
                    break;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to delete a directory: {DirectoryPath}", dirPath);
                }
            }
        }
    }
}
