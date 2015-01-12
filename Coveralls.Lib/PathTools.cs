using System;
using System.IO;

namespace Coveralls.Lib
{
    public static class PathTools
    {
        public static string ToUnixPath(this string path)
        {
            return path.Replace('\\', '/');
        }

        public static string ToRelativePath(this string fullPath, string baseFolder)
        {
            var pathUri = new Uri(fullPath);

            if (!baseFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                baseFolder += Path.DirectorySeparatorChar;
            }
            var folderUri = new Uri(baseFolder);

            var relativeUri = folderUri.MakeRelativeUri(pathUri);
            var relativePath = relativeUri.ToString().Replace('/', Path.DirectorySeparatorChar);

            return Uri.UnescapeDataString(relativePath);
        }
    }
}