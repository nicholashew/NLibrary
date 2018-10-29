using System;
using System.IO;

namespace NLibrary.Util
{
    public class FileHelper
    {
        public static void CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public static bool IsFileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Converts to human-readable file size for an arbitrary, 64-bit file size 
        /// The default format is "0.### XB", e.g. "4.2 KB" or "1.434 GB"
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string FormatFileSize(long length)
        {
            string size = "0 B";
            if (length >= 1073741824)
                size = String.Format("{0:##.##}", length / 1073741824) + " GB";
            else if (length >= 1048576)
                size = String.Format("{0:##.##}", length / 1048576) + " MB";
            else if (length >= 1024)
                size = String.Format("{0:##.##}", length / 1024) + " KB";
            else
                size = String.Format("{0:##.##}", length) + " B";
            return size;
        }

        /// <summary>
        /// Copy folder to another folder recursively.
        /// http://stackoverflow.com/questions/10389701/how-to-create-a-recursive-function-to-copy-all-files-and-folders
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="destFolder"></param>
        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}
