using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using ExtractFilesWithProgress.Classes.Classes;
using ExtractFilesWithProgress.Delegates.Delegates;
using ExtractFilesWithProgress.LanguageExtensions;

namespace ExtractFilesWithProgress
{
	/// <summary>
	/// Formatting may appear messed up when viewing in the GitHub repo, unsure why
	/// </summary>
	public partial class Form1
	{
		/// <summary>
		/// Event for passing information from a Task responsible
		/// for extracting files to the user interface which is
		/// in a different context.
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			Shown += OnShown;
		}

        private void OnShown(object sender, EventArgs e)
        {

            SelectZipFileDialog.InitialDirectory = "C:\\";
            CompressionFileNameTextBox.Text = "";
            ExtractionFolderTextBox.Text = "";

            /*
             * Recommendation for ease of testing mirror this
             * logic for your profile
             */
            if (Environment.UserName == "PayneK")
            {
                SelectZipFileDialog.InitialDirectory = @"C:\OED\Data";
                CompressionFileNameTextBox.Text = @"C:\OED\Data\wpf-advanced-reusable-styles-themes.zip";
                ExtractionFolderTextBox.Text = @"C:\OED\Data\testextract";
            }

            ZipEventHandler += OnZipEventHandler;
        }

        public event DelegatesModule.ZipEventHandler ZipEventHandler;

		private int _extractedCount = 0;
		/// <summary>
		/// Code to select zip file to work with
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SelectZipFileButton_Click(object sender, EventArgs e)
		{

			if (SelectZipFileDialog.ShowDialog() == DialogResult.OK)
			{
				CompressionFileNameTextBox.Text = SelectZipFileDialog.FileName;
			}

		}
		/// <summary>
		/// Code to select folder to extract zip file 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SelectFolderButton_Click(object sender, EventArgs e)
		{

			if (!string.IsNullOrWhiteSpace(CompressionFileNameTextBox.Text))
			{
				if (ExtractFolderBrowser.ShowDialog(this) == DialogResult.OK)
				{
					ExtractionFolderTextBox.Text = ExtractFolderBrowser.SelectedFolder;
				}
			}
			else
			{
				MessageBox.Show("Select a .zip file first");
			}

		}

		private async void ExtractButton_Click(object sender, EventArgs e)
		{

			if (!string.IsNullOrWhiteSpace(CompressionFileNameTextBox.Text) && !string.IsNullOrWhiteSpace(ExtractionFolderTextBox.Text))
			{

				_extractedCount = 0;
				ProgressBar1.Value = 0;

				ExtractButton.Enabled = false;
				ListBox1.Items.Clear();

				await Task.Delay(100);

				try
				{

					if (UseProgressBarCheckBox.Checked)
					{

						ProgressBar1.Visible = true;

						await ExtractAllAsync(CompressionFileNameTextBox.Text, ExtractionFolderTextBox.Text, ProgressBar1);

					}
					else
					{

						ProgressBar1.Visible = false;

						await ExtractAllAsync(CompressionFileNameTextBox.Text, ExtractionFolderTextBox.Text);

					}

				}
				finally
				{
					ExtractButton.Enabled = true;
				}

			}
		}
		/// <summary>
		/// Extract files from a zip file
		/// </summary>
		/// <param name="zipFileName">compressed file with path</param>
		/// <param name="extractPath">folder to extract file too</param>
		/// <param name="progressBar">optional ProgressBar</param>
		/// <returns>Nothing, Task is used to be awaitable</returns>
		private async Task ExtractAllAsync(string zipFileName, string extractPath, ProgressBar progressBar = null)
		{

			try
			{

				int extractCount = 0;
				int skipCount = 0;
				int errorCount = 0;
				int progressValue = 0;

				using (ZipArchive zipZrchive = ZipFile.OpenRead(zipFileName))
				{

					//
					// reset progressbar is used
					//
					if (progressBar != null)
					{
						progressBar.Minimum = 0;
						progressBar.Maximum = zipZrchive.Entries.Count;
					}

					bool extracted = false;

					await Task.Run(() =>
					{
						int count = zipZrchive.Entries.Count;
						string currentFileName = "";
						long currentFileLength = 0;

						//
						// Iterate files in compressed file
						//

						int tempVar = count;
						for (int index = 0; index < tempVar; index++)
						{
							try
							{

								ZipArchiveEntry entry = zipZrchive.Entries[index];
								currentFileName = entry.FullName;

								//
								// Bypass existing file, optional logic can be used
								// to overwrite an existing file
								//
                                var currentEntry = Path.Combine(extractPath, entry.FullName);
								if (!File.Exists(Path.Combine(extractPath, entry.FullName)))
								{
                                    if (currentEntry.EndsWith("/"))
                                    {
                                        var directoryName = currentEntry.TrimEnd('/');
                                        Directory.CreateDirectory(directoryName);
                                    }
                                    else
                                    {
                                        entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));

                                        currentFileLength = entry.Length;
                                        extractCount += 1;
                                        extracted = true;

									}

								}
								else
								{
									extracted = false;
								}

							}
							catch (IOException ioex)
							{
								//
								// By removing the logic above for File.Exists an exception
								// would be thrown. To get around this the file must first
								// be removed
								//
								if (ioex.Message.EndsWith("already exists."))
								{
									skipCount += 1;
								}
								else
								{
									errorCount += 1;
								}
							}
							catch (Exception ex)
							{
								//
								// Unknown error
								// Should not be ignored, for a production app
								// consider writing to a log file
								//
								errorCount += 1;
							}


							progressValue += 1;

							if (progressBar != null)
							{
                                progressBar.InvokeIfRequired(pb => pb.Value += 1);
							}

							Task.Delay(100).Wait(); // REMOVE FOR PRODUCTION

                            //
                            // Pass current file name without path,
                            // file size of current file,
                            // percent done and if the file was extracted
                            //
                            // Room here for customizing what is passed
                            // by modifying ZipArgs class.
                            //

                            ZipEventHandler?.Invoke(
                                this,
                                new ZipArgs(
                                    currentFileName,
                                    currentFileLength,
                                    progressValue.PercentageOf(count),
                                    extracted));
                        }
					});
				}

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "Error Opening Zip File", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}

		}
		
		private void Form1_Load(object sender, EventArgs e) { }

        /// <summary>
        /// Receive information from extraction process. Note use of Invoke
        /// to prevent cross thread violations as the async operations are
        /// performed in a different thread then the calling code in this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private async void OnZipEventHandler(object sender, ZipArgs e)
        {
            if (e.Extracted)
            {
                _extractedCount += 1;

                ListBox1.InvokeIfRequired(listbox => listbox.Items.Add($"{e.FileName}, {e.FileLength.ToEnglishKb()}"));
            }

            if (e.PercentDone == 100)
            {
                await Task.Delay(800); // Ensure progressbar has time to finishing painting
                MessageBox.Show($"Extracted {_extractedCount} files.");
            }
		}

        /// <summary>
		/// Used to delete all files from target extract folder
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PurgeTargetFolderButton_Click(object sender, EventArgs e)
        {
            var extractFolderName = ExtractionFolderTextBox.Text;

			if (!string.IsNullOrWhiteSpace(extractFolderName))
			{

                try
                {
                    if (Directory.Exists(extractFolderName))
                    {
						Directory.Delete(extractFolderName, true);
                        Directory.CreateDirectory(extractFolderName);
                        MessageBox.Show(@"Operation successful");
					}
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Purge failed.\n{exception.Message}");
                }

			}
			else
			{
				MessageBox.Show("Please select a folder first");
			}

		}

        #region Karen note - done when converting from VB.NET
		private static Form1 _DefaultInstance;
        public static Form1 DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null || _DefaultInstance.IsDisposed)
                {
                    _DefaultInstance = new Form1();
                }

                return _DefaultInstance;
            }
        }
        #endregion
    }
}