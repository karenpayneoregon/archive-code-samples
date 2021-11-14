using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace CreateZipWithExtensions.Classes
{
    public static class ZipHelpers
    {
        /// <summary>
        /// Create an archive/zip file from either a directory or single file
        /// </summary>
        /// <param name="sourceName">Folder or file to create zip file for</param>
        /// <param name="zipFileName">Name of zip file which can include a path\file name</param>
        /// <returns>success and exception if a runtime exception was raised</returns>
        public static async Task<(bool success, Exception exception)> CreateEntryFromAnyAsync(string sourceName, string zipFileName)
        {
            
            var result =  await Task.Run(async () =>
            {
                await Task.Delay(0);

                try
                {

                    if (File.GetAttributes(sourceName).HasFlag(FileAttributes.Directory))
                    {
                        ZipFile.CreateFromDirectory(sourceName, zipFileName);
                    }
                    else
                    {
                        using (var zipFile = new ZipArchive(File.Create(zipFileName), ZipArchiveMode.Create))
                        {
                            zipFile.CreateEntryFromFile(sourceName, Path.GetFileName(sourceName));
                        }
                    }

                    return (true, null);

                }
                catch (Exception ex)
                {
                    return (false, ex);
                }
            });

            return result;

        }

        /// <summary>
        /// Extract a folder under a folder in the application path
        /// </summary>
        /// <param name="zipFileName">Zip file to extract from</param>
        /// <param name="unzipPath">Where to extract to</param>
        /// <returns>success and if an exception return it</returns>
        /// <remarks>If the unzipPath exists delete it else an exception is thrown indicating one or more files exists. If there are a lot of files consider using a Task</remarks>
        public static (bool success, Exception exception) Unzip(string zipFileName, string unzipPath)
        {
            try
            {
                var folderName = Path.GetFileNameWithoutExtension(zipFileName);

                if (Directory.Exists(folderName))
                {
                    Directory.Delete(folderName,true);
                }

                ZipFile.ExtractToDirectory(zipFileName, unzipPath);

                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex);
            }
        }
    }
}
