using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace CreateZipWithExtensions.Classes
{
    public static class ZipHelpers
    {

        public static async Task<(bool success, Exception exception)> CreateEntryFromAnyAsync(string sourceName, string zipFileName)
        {
            
            var results =  await Task.Run(async () =>
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

            return results;

        }
    }
}
