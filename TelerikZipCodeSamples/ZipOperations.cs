using System;
using System.IO;
using System.Threading.Tasks;
using Telerik.Windows.Zip;
using Telerik.Windows.Zip.Extensions;

namespace TelerikZipCodeSamples
{
    public class ZipOperations
    {
        /// <summary>
        /// Example for creating a .zip (archive) file from a folder where
        /// all sub-folders and files will be included.
        /// </summary>
        /// <param name="folder">Root folder</param>
        /// <param name="zipName">Zip file name, may include a path</param>
        /// <returns></returns>
        public static async Task<(bool success, Exception exception)> FromDirectory(string folder, string zipName)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(1);

                try
                {
                    if (File.Exists(zipName))
                    {
                        File.Delete(zipName);
                    }

                    ZipFile.CreateFromDirectory(folder, zipName);

                    return (true, null);

                }
                catch (Exception ex)
                {
                    return (false, ex);
                }
                
            });
        }

        /// <summary>
        /// Create a .zip (archive file) with password
        /// </summary>
        /// <param name="sourceDirectoryName"></param>
        /// <param name="destinationArchiveFileName"></param>
        /// <param name="password">Password for archive file</param>
        /// <returns></returns>
        public static async Task<bool> CreateEncryptedZipFileFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, string password)
        {
            return await Task.Run(() =>
            {
                char[] directorySeparatorChar =
                {
                    Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar
                };

                if (!string.IsNullOrWhiteSpace(sourceDirectoryName))
                {
                    using (FileStream archiveStream = File.Open(destinationArchiveFileName, FileMode.Create))
                    {
                        // Set password to protect ZIP archive
                        DefaultEncryptionSettings encryptionSettings = new DefaultEncryptionSettings
                        {
                            Password = password
                        };

                        using (ZipArchive archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true, null, null, encryptionSettings))
                        {
                            foreach (string fileName in Directory.GetFiles(sourceDirectoryName))
                            {
                                using (FileStream file = File.OpenRead(fileName))
                                {
                                    int length = fileName.Length - sourceDirectoryName.Length;
                                    string entryName = fileName.Substring(sourceDirectoryName.Length, length);
                                    entryName = entryName.TrimStart(directorySeparatorChar);

                                    using (ZipArchiveEntry entry = archive.CreateEntry(entryName))
                                    {
                                        using (Stream entryStream = entry.Open())
                                        {
                                            file.CopyTo(entryStream);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }

            });
        }
    }
}