using System;
using System.IO;

namespace DarkNukeExtensions;

internal static class FileSystemValidations
{
    public static bool IsValidCsprojFilePath(string? path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return false;
        }

        var extension = Path.GetExtension(path);

        if (string.IsNullOrEmpty(extension))
        {
            return false;
        }

        return extension.ToLower().Equals(".csproj");
    }

    public static bool IsValidDirectoryPath(string? path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return false;
        }

        try
        {
            Path.GetFullPath(path);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
