using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompressionLibrary.Classes;
using Ionic.Zip;

namespace CompressionLibrary
{
    public class ZipOperations
    {
        public delegate void SaveProgress(object sender);
        /// <summary>
        /// Provides notification creation of zip has completed
        /// </summary>
        public  event SaveProgress SavedDoneHandler;

        public delegate void ProgressUpdate(object sender, ExtractProgressEventArgs args);

        public event ProgressUpdate SendProgressUpdate;

        public delegate void ZipError(object sender, ZipErrorEventArgs e);
        /// <summary>
        /// Provide details when an exception occurs
        /// </summary>
        public  event ZipError ZipErrorHandler;

        public delegate void ExtractFinished(object sender);
        /// <summary>
        /// Provides notification when extraction process has completed
        /// </summary>
        public  event ExtractFinished ExtractFinishedHandler;

        public delegate void OnError(Exception sender);
        /// <summary>
        /// Provides notification for general exceptions
        /// </summary>
        public  event OnError ErrorHandler;

        /// <summary>
        /// Container for remembering temp folder name used to create zip file with multiple folders
        /// </summary>
        private static string _uniqueTempDirectory;

        /// <summary>
        /// Location to unzip a zip file
        /// </summary>
        public string UnZipFolderName { get; set; }
        /// <summary>
        /// List of directories to zip into a single zip file
        /// </summary>
        public List<string> AddDirectoryList { get; set; }
        /// <summary>
        /// File entries to exclude from zipping operation
        /// </summary>
        public List<string> RemoveSelectedEntryList { get; set; }

        /// <summary>
        /// Indicates the file is to be encrypted with a password
        /// </summary>
        public bool UsePassword { get; set; }
        /// <summary>
        /// Password to encrypt <see cref="ZipFileName"/>
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Encrypt zip file
        /// </summary>
        public bool UseEncryption { get; set; }

        /// <summary>
        /// Save zip file to path\file name
        /// </summary>
        public string ZipFileName { get; set; }

        /// <summary>
        /// Zip file comment
        /// </summary>
        public string ZipFileComment { get; set; }

        /// <summary>
        /// instantiate list for add direction list and remove entry list
        /// </summary>
        public ZipOperations()
        {
            AddDirectoryList = new List<string>();

            RemoveSelectedEntryList = new List<string>();
        }

        /// <summary>
        /// Unzip archive files to a new directory that is time stamped
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="destinationFileName"></param>
        /// <returns></returns>
        public async Task DecompressNoPasswordTask(string fileName, string destinationFileName = "")
        {

            if (!string.IsNullOrWhiteSpace(destinationFileName))
            {
                UnZipFolderName = destinationFileName;
            }

            // ReSharper disable once NotAccessedVariable - Karen says BS
            ZipEntry currentEntry = new ZipEntry();

            var baseFolder = @"C:\OED\DumpZipFiles";
            string extractPath = Path.Combine(baseFolder, $"{DateTime.Now:HH-mm-ss-fff}");
            
            Directory.CreateDirectory(extractPath);



            if (Directory.Exists(extractPath))
            {
                var di = new DirectoryInfo(extractPath);
                FileHelpers.SetReadOnlyFlagForAllFiles(di, false);

                if (Directory.Exists(extractPath))
                {
                    Directory.Delete(extractPath, true);
                }
            }

            await Task.Run(async () =>
            {

                using (var zip = ZipFile.Read(fileName))
                {
                    zip.ExtractProgress += ZipOnExtractProgress;

                    var selection = from zipEntry in zip.Entries select zipEntry;

                    try
                    {
                        foreach (ZipEntry entry in selection)
                        {
                            currentEntry = entry;
                            entry.Extract(extractPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO
                    }
                }

                /*
                 * arbitrary time done with experimentation 
                 */
                await Task.Delay(500);

            });
        }

        private void ZipOnExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            SendProgressUpdate?.Invoke(sender, e);
        }


        /// <summary>
        /// Unzip a zip file with password
        /// </summary>
        /// <param name="fileName">zip file to read</param>
        /// <param name="password">optional password</param>
        /// <param name="destinationFileName">unzip too</param>
        /// <returns></returns>
        public async Task DecompressWithPasswordTask(string fileName, string password, string destinationFileName = "")
        {

            if (!string.IsNullOrWhiteSpace(destinationFileName))
            {
                UnZipFolderName = destinationFileName;
            }

            await Task.Run(async () =>
            {
                using (var zip = ZipFile.Read(fileName))
                {

                    zip.ExtractProgress += ExtractProgress;
                    
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        zip.Password = password;
                    }

                    zip.ExtractAll(UnZipFolderName, ExtractExistingFileAction.OverwriteSilently);

                    zip.Dispose();

                }

                /*
                 * arbitrary time done with experimentation 
                 */
                await Task.Delay(500);

            });
        }

        /// <summary>
        /// View specific details of entries in a zip file
        /// </summary>
        /// <param name="fileName">Existing zip file not passworded</param>
        /// <returns>contents of zip file</returns>
        /// <remarks>
        /// TODO Work in password
        /// </remarks>
        public List<Entry> ViewZipFileContents(string fileName)
        {
            var entries = new List<Entry>();

            if (Directory.Exists(UnZipFolderName))
            {
                Directory.Delete(UnZipFolderName, true);
            }

            //var header = true;

            using (var zip = ZipFile.Read(fileName))
            {
                foreach (ZipEntry entry in zip)
                {
                    //DebugView1(header, zip, entry);

                    entries.Add(new Entry(entry));
                }
            }

            return entries;
        }

        #region Entry helpers

        /// <summary>
        /// Find <see cref="Entry"/> by file name
        /// </summary>
        /// <param name="fileName">zip file name</param>
        /// <param name="entryFileName">file name to find in fileName</param>
        /// <returns></returns>
        public Entry FindEntry(string fileName, string entryFileName) =>
            ViewZipFileContents(fileName).FirstOrDefault(item => item.FileName == entryFileName);

        /// <summary>
        /// Determine if a file name exists in a .zip file
        /// </summary>
        /// <param name="fileName">zip file to check</param>
        /// <param name="entryFileName">file name in .zip file to find</param>
        /// <returns></returns>
        public bool ContainsEntry(string fileName, string entryFileName)
        {
            using (var zip = ZipFile.Read(fileName))
            {
                return zip.Any(entry => entry.FileName == entryFileName);
            }
        }

        #endregion

        #region Debug assistance

        /// <summary>
        /// Visual assistance for debug purposes
        /// </summary>
        /// <param name="header">Use to write column headers</param>
        /// <param name="zip">Archive file object</param>
        /// <param name="entry">ZipEntry</param>
        private static void DebugView1(bool header, ZipFile zip, ZipEntry entry)
        {
            if (header)
            {
                Console.WriteLine("Zipfile: {0}", zip.Name);
                if ((zip.Comment != null) && (zip.Comment != ""))
                {
                    Console.WriteLine("Comment: {0}", zip.Comment);
                }

                Console.WriteLine("\n{7,-10}{6,-11}{1,-22} {2,8}  {3,5}   {4,8}  {5,3} {0}", "Filename", "Modified", "Size", "Ratio", "Packed", "pw?", "Dir", "Length");
                Console.WriteLine(new string('-', 72));
                header = false;
            }

            Console.WriteLine("{7,-10}{6,-10}{1,-22:yyyy-MM-dd HH:mm:ss} {2,8} {3,5:F0}%   {4,8}  {5,3} {0}",
                entry.FileName,
                entry.LastModified,
                entry.UncompressedSize,
                entry.CompressionRatio,
                entry.CompressedSize,
                (entry.UsesEncryption) ? "Y" : "N",
                entry.IsDirectory ? "Folder" : "File",
                entry.FileName.Length
            );

        }

        #endregion

        /// <summary>
        /// Create zip file of one or more directories
        /// </summary>
        /// <returns>n/a</returns>
        public async Task CreateWithOptionalPasswordTask()
        {
            var fileName = ZipFileName;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // ensure folder exists 
            var directoryNameFromFileName = Path.GetDirectoryName(fileName);

            if (!Directory.Exists(directoryNameFromFileName))
            {
                try
                {
                    Directory.CreateDirectory(directoryNameFromFileName);
                }
                catch (Exception ex)
                {
                    ErrorHandler?.Invoke(ex);
                }
            }

            await Task.Run(async () =>
            {
                await Task.Delay(1);

                using (var zip = new ZipFile())
                {
                    zip.ZipError += OnZipError;
                    zip.SaveProgress += ZipOnSaveProgress;
                    
                    if (UsePassword && !string.IsNullOrWhiteSpace(Password))
                    {
                        zip.Password = Password;

                        if (UseEncryption)
                        {
                            zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        }
                        
                    }

                    if (AddDirectoryList.Count >1)
                    {
                        var (folderName, exception) = FileHelpers.CreateUniqueTempDirectory();

                        /*
                         * Insufficient permissions to create temp folder
                         */
                        if (exception != null)
                        {
                            throw exception;
                        }

                        _uniqueTempDirectory = folderName;

                        foreach (var directoryName in AddDirectoryList)
                        {
                            // create folder under temporary directory
                            Directory.CreateDirectory(Path.Combine(folderName, Path.GetFileName(directoryName)));

                            // copy folder with sub-directories
                            FileHelpers.CopyFilesRecursively(directoryName, Path.Combine(folderName, Path.GetFileName(directoryName)));
                        }

                    }
                    else
                    {
                        zip.AddDirectory(AddDirectoryList.FirstOrDefault());
                    }

                    // remove any exclusion folders
                    if (RemoveSelectedEntryList.Count > 0)
                    {
                        RemoveSelectedEntryList.ForEach(entry => zip.RemoveSelectedEntries(entry));
                    }

                    if (!string.IsNullOrWhiteSpace(ZipFileComment))
                    {
                        zip.Comment = ZipFileComment;
                    }

                    try
                    {
                        
                        if (File.Exists(ZipFileName))
                        {
                            File.Delete(ZipFileName);
                        }

                    }
                    catch (Exception ex)
                    {
                        ErrorHandler?.Invoke(ex);
                    }

                    try
                    {
                        // Single directory
                        if (string.IsNullOrWhiteSpace(_uniqueTempDirectory))
                        {
                            zip.Save(ZipFileName);
                        }
                        else
                        {
                            // add unique temporary directory containing multiple folders
                            zip.AddDirectory(_uniqueTempDirectory);

                            foreach (var entry in zip.Entries)
                            {
                                if (!string.IsNullOrWhiteSpace(zip.Comment))
                                {
                                    entry.Comment = zip.Comment;
                                }
                            }
                            zip.Save(ZipFileName);

                            // remove temporary directory
                            var (_, exception) = FileHelpers.RemoveUniqueTempDirectory(_uniqueTempDirectory);
                            if (exception != null)
                            {
                                ErrorHandler?.Invoke(exception);
                            }
                            zip.Dispose();

                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler?.Invoke(ex);
                    }
                }
            });
        }

        /// <summary>
        /// Add files to zip file without their original paths
        /// To include original paths exclude second parameter to Add method
        /// </summary>
        /// <param name="fileList">list of files to include in zip file</param>
        /// <param name="zipFileName">Create this file</param>
        /// <param name="directoryPathInArchive">Override original path</param>
        public Exception CreateFromSingleFolder(List<string> fileList, string zipFileName, string directoryPathInArchive = "")
        {
            try
            {
                if (File.Exists(zipFileName))
                {
                    File.Delete(zipFileName);
                }

                using (var zip = new ZipFile())
                {
                    foreach (var fileName in fileList)
                    {
                        zip.AddFile(fileName, directoryPathInArchive);
                    }

                    zip.Save(zipFileName);
                }

                return null;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public void RemoveSingleFileFromFile(Entry entry, string zipFileName)
        {

            using (var zip = ZipFile.Read(zipFileName))
            {
                //Console.WriteLine(zip.EntryFileNames.Contains(entry.FileName));
                if (zip.EntryFileNames.Contains(entry.FileName))
                {
                    zip.RemoveEntry(entry);
                    zip.Save();
                }

            }
        }

        #region Events

        private void OnZipError(object sender, ZipErrorEventArgs e)
        {
            ZipErrorHandler?.Invoke(sender, e);
        }

        /// <summary>
        /// Use to get which file was just extracted from archive 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtractProgress(object sender, ExtractProgressEventArgs e)
        {

            if (e.EventType == ZipProgressEventType.Extracting_AfterExtractEntry)
            {
                try
                {

                    if (e.CurrentEntry != null)
                    {
                        Console.WriteLine(e.CurrentEntry.FileName);
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        /// <summary>
        /// Signal save operation has completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZipOnSaveProgress(object sender, SaveProgressEventArgs e)
        {

            if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                SavedDoneHandler?.Invoke(sender);
            }
        }

        #endregion
    }
}
