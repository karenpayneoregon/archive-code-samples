using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompressionLibrary;
using FormsLibrary.Classes;
using FormsLibrary.Extensions;
using WK.Libraries.BetterFolderBrowserNS;

namespace UserDocumentControl
{
    public partial class UserSettingsForm : Form
    {
        private readonly Configuration _configuration;
        private bool _saveChanges = true;

        public delegate void OnSaveChanges(Configuration sender);
        public event OnSaveChanges SaveChangesHandler;

        public UserSettingsForm()
        {
            InitializeComponent();
            
            Shown += OnShown;

            ArchiveFileNameTextBox.Leave += ArchiveFileNameTextBoxOnLeave;
            SaveFoldersButton.DataBindings.Add("Enabled", RemoveCurrentFolderButton, "Enabled");

            _configuration = ConfigurationOperations.Read();

            ArchiveFolderNameTextBox.Text = _configuration.LastFolderBrowsedIsValid ? _configuration.LastFolderBrowsed : EnvironmentHelpers.DocumentFolder();

            if (_configuration.ArchiveFileNameIsValid)
            {
                ArchiveFileNameTextBox.Text = _configuration.ArchiveFileName;
            }

            CommentTextBox.Text = _configuration.ArchiveFileComment;

            FormClosing += OnFormClosing;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_saveChanges == false)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(ArchiveFileNameTextBox.Text))
            {
                _configuration.ArchiveFileName = ArchiveFileNameTextBox.Text;
            }

            _configuration.ArchiveFileComment = CommentTextBox.Text;

            ConfigurationOperations.Save(_configuration);

            SaveChangesHandler?.Invoke(_configuration);
        }

        private void ArchiveFileNameTextBoxOnLeave(object sender, EventArgs e)
        {
            ArchiveFileNameTextBox.EnsureZipExtension();
        }
        
        private void OnShown(object sender, EventArgs e)
        {
            FoldersCheckListBox.AllowDrop = true;
            FoldersCheckListBox.DragDrop += SelectedFoldersCheckListBoxOnDragDrop;
            FoldersCheckListBox.DragEnter += SelectedFoldersCheckListBoxOnDragEnter;

            LoadFolders();
        }

        private void LoadFolders()
        {
            var (hasItems, list) = ItemOperations.ReadItems();
            if (hasItems)
            {
                for (int index = 0; index < list.Count; index++)
                {
                    FoldersCheckListBox.Items.Add(list[index].DirectoryName);
                    FoldersCheckListBox.SetItemCheckState(index, list[index].IncludeFolder ? CheckState.Checked : CheckState.Unchecked);
                }

                SaveFoldersButton.Enabled = FoldersCheckListBox.Items.Count > 0;
                RemoveCurrentFolderButton.Enabled = SaveFoldersButton.Enabled;
                FoldersCheckListBox.SelectedIndex = 0;
            }
        }

        private void SelectedFoldersCheckListBoxOnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Accept folders from windows explorer, disallows duplicates
        /// </summary>
        private void SelectedFoldersCheckListBoxOnDragDrop(object sender, DragEventArgs e)
        {
            var droppedData = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var item in droppedData)
            {
                if (!Directory.Exists(item)) continue;

                var index = FoldersCheckListBox.FindString(item);

                if (index == -1)
                {
                    FoldersCheckListBox.AddAsChecked(item);
                }
                else
                {
                    FoldersCheckListBox.SelectedIndex = index;
                }
            }

            RemoveCurrentFolderButton.Enabled = FoldersCheckListBox.Items.Count > 0;
            
        }

        private void SaveFoldersButton_Click(object sender, EventArgs e)
        {
            var results = ItemOperations.ProcessCheckBoxItems(FoldersCheckListBox.CheckedList(), FoldersCheckListBox.NotCheckedList());
            ItemOperations.SaveItems(results);
        }
        private void RemoveCurrentFolderButton_Click(object sender, EventArgs e)
        {
            var index = FoldersCheckListBox.SelectedIndex;
            if (index <= -1) return;
            if (Dialogs.Question($"Remove {FoldersCheckListBox.Text}"))
            {
                FoldersCheckListBox.RemoveBackItem(index);
            }
            RemoveCurrentFolderButton.Enabled = FoldersCheckListBox.Items.Count > 0;
        }
        private void SelectArchiveFolderButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new BetterFolderBrowser() {Multiselect = false})
            {
                if (string.IsNullOrWhiteSpace(_configuration.LastFolderBrowsed))
                {
                    _configuration.LastFolderBrowsed = "C:\\";
                }

                dialog.RootFolder = _configuration.LastFolderBrowsed;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ArchiveFolderNameTextBox.Text = dialog.SelectedFolder;
                    _configuration.LastFolderBrowsed = dialog.SelectedFolder;
                }
            }
        }

        private void SaveZipSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.TextBoxesHaveValues())
            {
                ConfigurationOperations.Save(new Configuration() { ArchiveFolder = ArchiveFolderNameTextBox.Text, ArchiveFileName = ArchiveFileNameTextBox.Text });
                Close();
            }
            else
            {
                MessageBox.Show($@"Please select a folder and file name");
            }
        }

        private void CreateUniqueZipFileNameButton_Click(object sender, EventArgs e) => ArchiveFileNameTextBox.Text = FileHelpers.UniqueFileName(false);

        private void CancelSaveButton_Click(object sender, EventArgs e)
        {
            _saveChanges = false;
            Close();
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            _saveChanges = false;
            Close();
        }
    }
}