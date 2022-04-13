using Nuke.Common.ProjectModel;
using Serilog;
using System;
using System.IO;

namespace DarkNukeExtensions
{
    public static class FileSystemTasks
    {
        public static void DeleteBinAndObjDirectories(Project project, int retryCount = 3)
        {
            //TODO guard inputs

            TryDeleteDirectory(project.Directory / "bin", retryCount);
            TryDeleteDirectory(project.Directory / "obj", retryCount);
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
