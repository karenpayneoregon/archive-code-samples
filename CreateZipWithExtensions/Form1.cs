using System;
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
    }
}
