using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompressionLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;


// ReSharper disable once CheckNamespace
namespace FileOperationsTest
{
    public partial class MainTest
    {

        public string ZipFileName => Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Files", "ZipPassworded.zip");
        // ReSharper disable once AssignNullToNotNullAttribute
        public string ZipPassFolder => Path.Combine(Path.GetDirectoryName(ZipFileName), "ZipPasswordedFolder");
        // ReSharper disable once AssignNullToNotNullAttribute
        public string ZipFileOnlyFolder => Path.Combine(Path.GetDirectoryName(ZipFileName), "AddFilesNoPassword");

        private static string _password => "payne";


        private List<string> GetFiles(string path, string extension) => Directory.GetFiles(path, extension).ToList();

        private ZipOperations _zipOperations;

        [TestInitialize]
        public void Initialization()
        {
            if (TestContext.TestName == nameof(ViewZipFileContentsTest))
            {
                if (!Directory.Exists(ZipPassFolder))
                {
                    throw new Exception($"Read comments in {nameof(ViewZipFileContentsTest)}");
                }
            }

            if (TestContext.TestName == nameof(UnZipFilesNoPasswordTest))
            {
                var unZipPathFileName = Path.Combine(ZipFileOnlyFolder, nameof(UnZipFilesNoPasswordTest));

                if (Directory.Exists(unZipPathFileName))
                {
                    Directory.Delete(unZipPathFileName, true);
                }
            }

            // ensure a fresh instance for each test
            _zipOperations = new ZipOperations();

        }

        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }

    }

}