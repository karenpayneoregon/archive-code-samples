using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.Windows.Zip;
using Telerik.Windows.Zip.Extensions;

namespace TelerikZipCodeSamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateZipPasswordButton_Click(object sender, EventArgs e)
        {
            

            using (Stream stream = File.Open("demo.zip", FileMode.Create))
            {
                DefaultEncryptionSettings encryptionSettings = new DefaultEncryptionSettings
                {
                    Password = "password"
                };

                using (var archive1 = new ZipArchive(stream, ZipArchiveMode.Create, false, null, null, encryptionSettings))
                {
                    using (ZipArchiveEntry textFileEntry = archive1.CreateEntry("text.txt"))
                    {
                        StreamWriter writer = new StreamWriter(textFileEntry.Open());
                        writer.WriteLine("Hello world!");
                        writer.Flush();
                    }

                    archive1.CreateEntryFromFile("Doc1.docx", "doc.docx", CompressionLevel.Best);
                    
                }
            }
        }

        private async void FromFolderWithPasswordButton_Click(object sender, EventArgs e)
        {
            await ZipOperations.CreateEncryptedZipFileFromDirectory(
                @"C:\Documents", 
                "Folders.zip", 
                "@password1");

            Console.WriteLine("Done");
        }

        private async void FromFolderRecursiveButton_Click(object sender, EventArgs e)
        {
            var (success, exception) = await ZipOperations.FromDirectory(@"C:\Documents", "dump.zip");

            MessageBox.Show(success ? "Done" : $"Encountered an issue\n{exception.Message}");
        }
    }
}
