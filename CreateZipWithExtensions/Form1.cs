using System;
using System.IO;
using System.Windows.Forms;
using CreateZipWithExtensions.Classes;

namespace CreateZipWithExtensions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CreateZipWithOneFileButton.DataBindings.Add("Enabled", CreateZipFromFolderButton, "Enabled");

        }

        private async void CreateZipWithOneFileButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\OED\\Documents"))
            {
                MessageBox.Show("Invalid path");
                return;
            }

            CreateZipFromFolderButton.Enabled = false;
            pictureBox1.Visible = true;

            try
            {
                var (success, exception) = await ZipHelpers.CreateEntryFromAnyAsync("C:\\OED\\Documents\\SpreadsheetLight.chm", FileHelpers.ZipFileName);
                if (success == false)
                {
                    MessageBox.Show($"Failed\n{exception.Message}");
                }
            }
            finally
            {
                CreateZipFromFolderButton.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        private async void CreateZipFromFolderButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\OED\\Documents"))
            {
                MessageBox.Show("Invalid path");
                return;
            }

            CreateZipFromFolderButton.Enabled = false;
            pictureBox1.Visible = true;
            
            try
            {
                var (success, exception) = await ZipHelpers.CreateEntryFromAnyAsync("C:\\OED\\Documents", FileHelpers.ZipFileName);
                if (success == false)
                {
                    MessageBox.Show($"Failed\n{exception.Message}");
                }
            }
            finally
            {
                CreateZipFromFolderButton.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        /// <summary>
        /// Example with a pre-done zip file as this means no need to pick a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtractButton_Click(object sender, EventArgs e)
        {
            var zipName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Archives", "assets.zip");
            if (File.Exists(zipName))
            {
                var (_, exception) = ZipHelpers.Unzip(zipName, ".\\");
                MessageBox.Show(exception is null ? "Done" : exception.Message);
            }
            else
            {
                MessageBox.Show($"Missing {zipName}");
            }

        }
    }
}
