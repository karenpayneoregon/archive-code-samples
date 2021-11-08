using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionLibrary
{
    public static class FileHelpers
    {
        /// <summary>
        /// Copy files in parent and child folders. Caller is an async task
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        /// <summary>
        /// Format int as readable file size
        /// </summary>
        /// <param name="value">value to format</param>
        /// <param name="decimalPlaces">decimal places, default is 1</param>
        /// <returns></returns>
        public static string SizeSuffix(long value, int decimalPlaces = 1)
        {

            if (value < 0)
            {
                return "-" + SizeSuffix(-value);
            }

            int size = 0;
            var dValue = (decimal)value;

            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024M;
                size += 1;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[size]);

        }

        /// <summary>
        /// Creates the unique temporary directory.
        /// </summary>
        /// <returns>
        /// Directory path.
        /// </returns>
        public static (string folderName, Exception exception) CreateUniqueTempDirectory()
        {
            var uniqueTempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            try
            {
                Directory.CreateDirectory(uniqueTempDir);
                return (uniqueTempDir, null);
            }
            catch (Exception exception)
            {
                return (null, exception);
            }

        }

        /// <summary>
        /// Clean up
        /// </summary>
        /// <param name="tempDirectory"></param>
        /// <returns></returns>
        public static (bool success, Exception exception) RemoveUniqueTempDirectory(string tempDirectory)
        {
            if (string.IsNullOrWhiteSpace(tempDirectory)) return (true, null);

            var di = new DirectoryInfo(tempDirectory);

            try
            {

                if (Directory.Exists(tempDirectory))
                {
                    SetReadOnlyFlagForAllFiles(di, false);
                    Directory.Delete(tempDirectory, true);
                }

                return (true, null);

            }
            catch (Exception exception)
            {
                return (false, exception);
            }

        }

        /// <summary>
        /// Set read-only attribute for each file in a folder
        /// </summary>
        /// <param name="directoryInfo">Directory to recursively iterate to set file attribute to false or true</param>
        /// <param name="readOnlyValue">True to set, false to remove</param>
        public static void SetReadOnlyFlagForAllFiles(DirectoryInfo directoryInfo, bool readOnlyValue)
        {
            // Iterate over ALL files using "*" wildcard and choosing to search all directories.
            foreach (FileInfo fileInfo in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
            {
                fileInfo.IsReadOnly = readOnlyValue;
            }
        }

        /// <summary>
        /// Recursively set file attributes to <see cref="FileAttributes.Normal"/>
        /// </summary>
        /// <param name="parentDirectory"></param>
        /// <code>
        ///  DirectoryInfo parentDirectoryInfo = new DirectoryInfo(@"C:\OED");
        ///  ClearReadOnly(parentDirectoryInfo);
        /// </code>
        public static void ClearReadOnly(DirectoryInfo parentDirectory)
        {
            if (parentDirectory == null) return;

            parentDirectory.Attributes = FileAttributes.Normal;

            foreach (FileInfo fileInfo in parentDirectory.GetFiles())
            {
                fileInfo.Attributes = FileAttributes.Normal;
            }

            foreach (DirectoryInfo directoryInfo in parentDirectory.GetDirectories())
            {
                ClearReadOnly(directoryInfo);
            }

        }

        /// <summary>
        /// Create a unique file name
        /// </summary>
        /// <param name="useGuid">true to include Guid, false to exclude Guid</param>
        /// <param name="extension">File extension with period, if not specified .zip is used</param>
        /// <returns>unique file name</returns>
        /// <remarks>
        ///  -- is used to separate date part from time part, feel free to change this
        /// Change this methods logic the method <see cref="DateTimeFromFileName"/> must be altered
        /// </remarks>
        public static string UniqueFileName(bool useGuid,string extension = ".zip") => useGuid ? 
            $"{DateTime.Now:yyyy-dd-M--HH-mm-ss-ms}{Guid.NewGuid()}{extension}" : 
            $"{DateTime.Now:yyyy-dd-M--HH-mm-ss-ms}{extension}";


        /// <summary>
        /// Helper for <see cref="UniqueFileName"/> to split out date time from file name
        /// </summary>
        /// <param name="source">Created with <see cref="UniqueFileName"/></param>
        /// <returns>DateTime</returns>
        /// <returns>DateTime</returns>
        public static DateTime DateTimeFromFileName(string source)
        {
            /*
             * Can split easily when we have -- and - in the string so change -- to ~ and remove the extension
             */
            var sanitized = source.Replace("--", "~").Replace(".zip", "").Split('~');

            /*
             * Since replacing -- with ~ we can properly get time element
             */
            var parts = sanitized[1].Split('-');

            /*
             * Combine data part (element 0) with time part (element 1)
             * and create our date time
             */
            var thisTime = $"{parts[0]}:{parts[1]}:{parts[2]}";

            return Convert.ToDateTime($"{sanitized[0]} {thisTime}", CultureInfo.InvariantCulture);
        }
    }
}
