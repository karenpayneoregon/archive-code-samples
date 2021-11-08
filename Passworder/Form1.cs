using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using TestBedProject.Classes;


namespace TestBedProject
{
    public partial class Form1 : Form
    {
        private static string TargetFolder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ZipPasswordedFolder");
        private static string _password => "payne";

        public Form1()
        {
            InitializeComponent();

            RemoveFolder();
        }

        private void RemoveFolder()
        {
            if (Directory.Exists(TargetFolder))
            {
                Directory.Delete(TargetFolder, true);
            }
        }

        private void CompressFolderButton_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(@"C:\oed\ColdFusionSolutions");
                zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                zip.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Zip1.zip"));
            }

            MessageBox.Show("Done");
        }

        private async void CompressFolderWithPasswordButton_Click(object sender, EventArgs e)
        {
            CompressFolderWithPasswordButton.Enabled = false;
            await CreateZipWithPasswordTask();
            CompressFolderWithPasswordButton.Enabled = true;
            MessageBox.Show("Done");
            
        }

        public async Task CreateZipWithPasswordTask()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ZipPassworded.zip");
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            await Task.Run(async () =>
            {
                await Task.Delay(10);
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddProgress += ZipOnAddProgress;
                    zip.Password = _password;
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    zip.AddDirectory(@"C:\OED\Dotnetland\VS2019\LearningVisualStudio\DebuggingSolution");
                    zip.RemoveSelectedEntries(".git/*");
                    zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                    zip.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ZipPassworded.zip"));
                }

            });
        }

        private void ZipOnAddProgress(object sender, AddProgressEventArgs e)
        {
            if (e.CurrentEntry != null)
            {
                InformationLabel.InvokeIfRequired(label => InformationLabel.Text = e.CurrentEntry.FileName);
            }
            else
            {
                InformationLabel.InvokeIfRequired(label => InformationLabel.Text = "");
            }

        }
        private async void CheckPasswordButton_Click(object sender, EventArgs e)
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ZipPassworded.zip");

            //await Task.Run(async () =>
            //{
            //    await Task.Delay(10);
            //    var correctPassword = ZipFile.CheckZipPassword(fileName, _password);
            //    Console.WriteLine(correctPassword);

            //    var incorrectPassword = ZipFile.CheckZipPassword(fileName, "Wrong");
            //    Console.WriteLine(incorrectPassword);


            //});

            var isValidPassword = await ZipPasswordTester.IsValidFilePassword(fileName, _password);
            Console.WriteLine(isValidPassword);

            isValidPassword = await ZipPasswordTester.IsValidFilePassword(fileName, "_password");
            Console.WriteLine(isValidPassword);

        }

        public static async Task DecompressZipWithPasswordTask()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ZipPassworded.zip");

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }
            
            await Task.Run(async () =>
            {
                await Task.Delay(10);
                using (ZipFile zip = ZipFile.Read(fileName))
                {
                    zip.Password = _password;
                    zip.ExtractAll(TargetFolder, ExtractExistingFileAction.OverwriteSilently);
                    zip.Dispose();
                }

            });
        }
        private async void UnCompressButton_Click(object sender, EventArgs e)
        {

            UnCompressButton.Enabled = false;

            try
            {
                await DecompressZipWithPasswordTask();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex is FileNotFoundException ? 
                    $"Missing\n{ex.Message}" : 
                    $"Well that was unexpected\n{ex.Message}");

            }
            finally
            {
                UnCompressButton.Enabled = true;
            }
           
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
    //public static class Dialogs
    //{
    //    [DebuggerStepThrough]
    //    public static bool Question(string text) => 
    //        (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
    //    [DebuggerStepThrough]
    //    public static bool Question(string text, MessageBoxIcon icon) => 
    //        (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo, icon, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
    //    [DebuggerStepThrough]
    //    public static void InformationDialog(string message, string title) => 
    //        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    [DebuggerStepThrough]
    //    public static void InformationDialog(string message, string title, MessageBoxIcon icon) => 
    //        MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
    //}

}
