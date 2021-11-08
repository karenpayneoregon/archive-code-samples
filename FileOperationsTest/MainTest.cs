using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CompressionLibrary;
using CompressionLibrary.Classes;
using FileOperationsTest.Base;
using UtilityLibrary.UtilityApiLibrary;

namespace FileOperationsTest
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// Create zip from list of files with paths, strip paths when creating zip file
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ZipOperations)]
        public void ZipFilesNoPasswordTest()
        {
            var files = GetFiles(ZipFileOnlyFolder, "*.json");
            var zipFileName = Path.Combine(ZipFileOnlyFolder, "Test.zip");
            var results = _zipOperations.CreateFromSingleFolder(files, zipFileName);
            Assert.IsNull(results);

        }

        /// <summary>
        /// Create zip from list of files with paths, strip paths when creating zip file
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ZipOperations)]
        public void ZipFilesNoPasswordTestOverridePath()
        {
            var files = GetFiles(ZipFileOnlyFolder, "*.json");
            var zipFileName = Path.Combine(ZipFileOnlyFolder, "TestNoPath.zip");

            Exception results = _zipOperations.CreateFromSingleFolder(files, zipFileName, @"C:\OED");
            Assert.IsNull(results);

            var list = _zipOperations.ViewZipFileContents(zipFileName);

            var allRoot = list.All(item => item.FileName.StartsWith("OED"));
            Assert.IsTrue(allRoot);
        }

        /// <summary>
        /// Warning, this is method take over four seconds to run.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestTraits(Trait.ZipOperations)]
        public async Task CheckZipFilePasswordTest()
        {
            var isValidPassword = await ZipPasswordTester.IsValidFilePassword(ZipFileName, _password);
            Assert.IsTrue(isValidPassword);
        }

        [TestMethod]
        [TestTraits(Trait.ZipOperations)]
        public async Task UnZipFilesNoPasswordTest()
        {
            string[] expectedFiles = { "ContactDevices.json", "Contacts.json", "Countries.json", "Customers.json" };

            var files = GetFiles(ZipFileOnlyFolder, "*.json");
            await Task.Delay(1);
            var zipFileName = Path.Combine(ZipFileOnlyFolder, "Test.zip");
            var destinationFolderName = Path.Combine(ZipFileOnlyFolder, nameof(UnZipFilesNoPasswordTest));
            _zipOperations.CreateFromSingleFolder(files, zipFileName);

            
            await _zipOperations.DecompressWithPasswordTask(zipFileName, null, destinationFolderName);

            Assert.IsTrue(Directory.Exists(destinationFolderName));

            var jsonFiles = Directory.GetFiles(destinationFolderName).Select(Path.GetFileName).ToArray();

            CollectionAssert.AreEqual(jsonFiles, expectedFiles);

        }

        /// <summary>
        /// Test removing an entry from a zip file w/o password
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ZipOperations)]
        public void RemoveSingleFileFromFileTest()
        {
            /*
             * Arrange - Ensure there is a fresh file since this method deletes an entry
             */
            var files = GetFiles(ZipFileOnlyFolder, "*.json");
            var zipFileName = Path.Combine(ZipFileOnlyFolder, "Test.zip");
            var results = _zipOperations.CreateFromSingleFolder(files, zipFileName);
            Assert.IsNull(results);

            /*
             * Act - find entry then delete entry
             */
            var entry = _zipOperations.FindEntry(zipFileName, "Customers.json");
            _zipOperations.RemoveSingleFileFromFile(entry, zipFileName);

            /*
             * Assert there is one less file. We could iterate the files to ensure
             * that Customers.json was the entry removed if so desire.
             */
            Assert.AreEqual(_zipOperations.ViewZipFileContents(zipFileName).Count, 3);

        }

        /// <summary>
        /// After extraction of passworded zip file validate
        /// all files have been extracted by file count.
        ///
        /// In this case the zip file was created in TestBedProject project
        /// and also extracted in in TestBedProject project followed by
        /// manually copying to the Bin\Debug\Files folder.
        ///
        /// Note the above process can be automated yet see no gains doing this.
        /// </summary>
        /// <remarks>
        /// Validation
        /// - Open Debug folder
        /// - Right click on ZipPasswordedFolder
        /// - Get file and folder counts
        ///
        /// IMPORTANT
        /// You cloned this repository and the test fails.
        /// 
        /// Reason, the <see cref="ZipPassFolder"/> does not exists
        /// To fix, copy this folder from the TestBedProject under Bin\Debug folder
        ///
        /// WHY?
        /// Because there is zero reason to place <see cref="ZipPassFolder"/> folder and files
        /// into the Git repository.
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.ZipOperations)]
        public void ViewZipFileContentsTest()
        {
            var list = _zipOperations.ViewZipFileContents(ZipFileName);

            /*
             * Get folder count extract from the zip file
             */
            var folderCount = list.Count(item => item.IsDirectory);

            Assert.AreEqual(folderCount, 35);

            /*
             * Get count of files in zip file 
             */
            var fileCount = list.Count(item => !item.IsDirectory);

            /*
             * Get count of files and folders in zip file
             */
            var fileAndDirectoriesCount = new DirectoryInfo(ZipPassFolder)
                .EnumerateFileSystemInfos("*", SearchOption.AllDirectories).Count();

            Assert.AreEqual(fileAndDirectoriesCount, fileCount + folderCount);

        }

        [TestMethod]
        [TestTraits(Trait.ZipOperations)]
        public void ContainsEntryTest()
        {
            
            var entryName = "Customers.json";
            var files = GetFiles(ZipFileOnlyFolder, "*.json");
            var zipFileName = Path.Combine(ZipFileOnlyFolder, "Test.zip");
            var results = _zipOperations.CreateFromSingleFolder(files, zipFileName);

            Assert.IsTrue(_zipOperations.ContainsEntry(zipFileName, entryName));

        }


        /// <summary>
        /// Validate creation of a temp folder
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.FileOperations)]
        public void CreateUniqueTempDirectoryTest()
        {
            
            var (folderName, exception) = FileHelpers.CreateUniqueTempDirectory();
            Assert.IsNull(exception);
            Assert.IsTrue(Directory.Exists(folderName));
            
            var ( _ , exception1) = FileHelpers.RemoveUniqueTempDirectory(folderName);
            Assert.IsNull(exception1);

        }

        /// <summary>
        ///
        /// Lengthy test time wise as there is a pause to ensure
        /// data is created no less than one second.
        /// 
        /// Test creation of a unique file name and extracted a DateTime from the file name
        /// No assertion, this is a visual inspection
        ///
        /// Expected format month/day/year hour:minutes:seconds
        /// 04/11/2021 05:36:45
        ///
        /// File name includes milliseconds 
        /// </summary>
        /// <returns>n/a</returns>
        [TestMethod]
        [TestTraits(Trait.FileOperations)]
        public async Task UniqueFileNameTest()
        {

            var values = new List<string>();

            List<UniqueFileName> uniqueFileNames = new List<UniqueFileName>();

            for (int index = 0; index < 5; index++)
            {
                values.Add(FileHelpers.UniqueFileName(false));
                await Task.Delay(1000);
            }

            foreach (var source in values)
            {
                uniqueFileNames.Add(new UniqueFileName()
                {
                    Name = source, 
                    DateTime = FileHelpers.DateTimeFromFileName(source)
                });
            }

            foreach (var uniqueFileName in uniqueFileNames)
            {
                Console.WriteLine($"{uniqueFileName.Name, -35}{uniqueFileName.DateTime:MM/dd/yyyy hh:mm:ss}");
            }

        }

        /// <summary>
        /// Work in progress for later use - Lengthy test time wise
        /// Code works but has no value for current archive code
        /// </summary>
        [TestMethod]
        [Ignore]
        [TestTraits(Trait.DirectoryOperations)]
        public void FolderCrawlerTest()
        {
            var operations = new FileSystemCrawler();
            
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // 4.9 seconds - roughly 48,000
            operations.CollectFolders(@"C:\OED\Dotnetland\VS2019");

            Console.WriteLine(operations.FolderCount);
            watch.Stop();

            Console.WriteLine($"Collected {operations.FolderCount:N0} folders in {watch.ElapsedMilliseconds} milliseconds.");
        }

        [TestMethod]
        [TestTraits(Trait.API)]
        public void LongToShortPathTest()
        {
            var userName = Environment.UserName;

            string longPath = $@"C:\Users\{userName}\AppData\Local\Microsoft\Microsoft SQL Server Data\SQLEXPRESS";

            Assert.AreEqual($@"C:\Users\{userName}\AppData\Local\MICROS~1\MICROS~2\SQLEXP~1", 
                PathHelpers.GetShortPath(longPath));
        }

    }
}
