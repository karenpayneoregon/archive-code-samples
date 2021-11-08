using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompressionLibrary;
using FormsLibrary.Classes;
using FormsLibrary.Extensions;
using Ionic.Zip;

namespace CreatePasswordedZipFromFolders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SelectedFoldersCheckListBox.AllowDrop = true;
            SelectedFoldersCheckListBox.DragDrop += SelectedFoldersCheckListBoxOnDragDrop;
            SelectedFoldersCheckListBox.DragEnter += SelectedFoldersCheckListBoxOnDragEnter;

            PasswordTextBox.ToggleShow(false);

            CueBannerTextCode.SetCueText(PasswordTextBox, "Enter a password");

            // Disable create zip button until there are folders added
            CreateZipButton.Enabled = false;
        }

        private void SelectedFoldersCheckListBoxOnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Accept folders from windows explorer
        /// </summary>
        private void SelectedFoldersCheckListBoxOnDragDrop(object sender, DragEventArgs e)
        {
            var droppedData = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var item in droppedData)
            {
                if (!Directory.Exists(item)) continue;

                var index = SelectedFoldersCheckListBox.FindString(item);

                // Disallow duplicates 
                if (index == -1)
                {
                    SelectedFoldersCheckListBox.AddAsChecked(item);
                }
                else
                {
                    SelectedFoldersCheckListBox.SelectedIndex = index;
                }
            }

            CreateZipButton.Enabled = SelectedFoldersCheckListBox.Items.Count > 0;
        }

        private void ViewZipContentsButton_Click(object sender, EventArgs e)
        {

            if (!File.Exists(SaveFileNameTextBox.Text))
            {
                MessageBox.Show($"{SaveFileNameTextBox.Text} not found.");
                return;
            }

            //using (var dialog = new BetterFolderBrowser() { RootFolder = "C:\\OED\\Dotnetland", Title = "Solution folder" })
            //{
            //    if (dialog.ShowDialog() != DialogResult.OK) return;
            //    Console.WriteLine(dialog.SelectedFolder);
            //}

            //CheckedListBox.CheckedItemCollection checkedItems = SelectedFoldersCheckListBox.CheckedItems;
            //var notCheckedItems = SelectedFoldersCheckListBox.NotCheckedList();

            //Console.WriteLine(ZipOperations.CreateUniqueTempDirectory());
            //ZipOperations.RemoveUniqueTempDirectory();

            var ops = new ZipOperations() { UnZipFolderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extracted") };
            
            var form = new ViewZipFileForm(ops.ViewZipFileContents(SaveFileNameTextBox.Text), SaveFileNameTextBox.Text);

            try
            {
                form.ShowDialog();
            }
            finally
            {
                form.Dispose();
            }
        }

        /// <summary>
        /// Prompt for path and file name to create zip file
        /// </summary>
        private void SaveFileNameButton_Click(object sender, EventArgs e)
        {

            var initialPath = "C:\\OED\\Dotnetland";

            if (!Directory.Exists(initialPath))
            {
                initialPath = "C:\\";
            }

            if (!string.IsNullOrWhiteSpace(SaveFileNameTextBox.Text))
            {
                initialPath = Path.GetDirectoryName(SaveFileNameTextBox.Text);
            }

            using (var dialog = new SaveFileDialog() { InitialDirectory = initialPath, DefaultExt = "zip", Filter = "zip file|zip", OverwritePrompt = true })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFileNameTextBox.Text = dialog.FileName;
                }
            }
        }

        /// <summary>
        /// Toggle view of password
        /// </summary>
        private void ShowPassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.ToggleShow(ShowPassCheckBox.Checked);
        }

        /// <summary>
        /// Create a new zip file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateZipButton_Click(object sender, EventArgs e)
        {
            // There is assertion in SelectedFoldersCheckListBoxOnDragDrop, this is a double check
            if (SelectedFoldersCheckListBox.Items.Count == 0)
            {
                MessageBox.Show("Please add files or folders");
                return;
            }

            // Disallow multiple creations while one is running
            CreateZipButton.Enabled = false;

            var zipOperations = new ZipOperations
            {
                AddDirectoryList = SelectedFoldersCheckListBox.CheckedList(), 
                UsePassword = UsePasswordCheckBox.Checked, 
                Password = PasswordTextBox.Text, 
                UseEncryption = EncryptionCheckBox.Checked,
                ZipFileName = SaveFileNameTextBox.Text
            };

            zipOperations.SavedDoneHandler += ZipOperationsOnSavedDoneHandler;
            zipOperations.ErrorHandler += ZipOperationsOnErrorHandler;

            try
            {
                await zipOperations.CreateWithPasswordTask();
            }
            finally
            {
                zipOperations.SavedDoneHandler -= ZipOperationsOnSavedDoneHandler;
                zipOperations.ErrorHandler -= ZipOperationsOnErrorHandler;
            }


        }

        private void ZipOperationsOnErrorHandler(Exception sender)
        {
            MessageBox.Show($"{sender.Message}");
        }

        /// <summary>
        /// Fired when create zip operation has completed w/o error
        /// </summary>
        private void ZipOperationsOnSavedDoneHandler(object sender)
        {
            CreateZipButton.InvokeIfRequired(button => button.Enabled = true);
        }

        /// <summary>
        /// Karen's note:
        /// As coded, the path to extract can cause 'path not found' errors.
        /// To eliminate this keep the extraction path close to the root of the drive and/or
        /// manipulate the paths in the zip file if they are long.
        ///
        /// Root cause:
        /// The exception that is thrown when a path or fully qualified file name is longer than the system-defined maximum length.
        ///
        /// Solutions
        ///  - tweak the registry, not acceptable
        ///  - reconsider business logic
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UnzipButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(SaveFileNameTextBox.Text))
            {
                MessageBox.Show("Zip file does not exists");
                return;
            }
            UnzipButton.Enabled = false;
            progressBar1.Visible = true;
            CurrentExtractonLabel.Visible = true;

            var zipOperations = new ZipOperations
            {
                Password = PasswordTextBox.Text,
                UnZipFolderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extracted")
            };

            zipOperations.ExtractFinishedHandler += ZipOperationsOnExtractFinishedHandler;
            zipOperations.SendProgressUpdate += ZipOperationsOnSendProgressUpdate;

            try
            {
                await zipOperations.DecompressNoPasswordTask(SaveFileNameTextBox.Text, @"C:\OED\DumpZipFiles");
            }
            finally
            {
                UnzipButton.Enabled = true;
                await Task.Delay(500);
                progressBar1.Visible = false;
                CurrentExtractonLabel.Visible = false;
            }

            zipOperations.ExtractFinishedHandler -= ZipOperationsOnExtractFinishedHandler;

        }

        #region Extraction process update

        /// <summary>
        /// Prevent cross-threading
        /// </summary>
        private void ZipOperationsOnSendProgressUpdate(object sender, ExtractProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, ExtractProgressEventArgs>(UpdateProgress), sender, e);
            }
        }
        /// <summary>
        /// Super simple report progress on archive extraction
        /// </summary>
        private void UpdateProgress(object arg1, ExtractProgressEventArgs e)
        {

            if (e.TotalBytesToTransfer <= 0) return;

            progressBar1.Value = Convert.ToInt32(100 * e.BytesTransferred / e.TotalBytesToTransfer);
            CurrentExtractonLabel.Text = e.CurrentEntry.FileName;

        }
        #endregion

        /// <summary>
        /// Fired once un-compress finishes
        /// </summary>
        private void ZipOperationsOnExtractFinishedHandler(object sender)
        {
            UnzipButton.InvokeIfRequired(button => button.Enabled = true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var baseFolder = @"C:\OED\DumpZipFiles";
            
            Directory.CreateDirectory(Path.Combine(baseFolder, $"{DateTime.Now:HH-mm-ss-fff}"));
        }
    }
}
