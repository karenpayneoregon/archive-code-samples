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
using FormsLibrary.Classes;
using FormsLibrary.Extensions;
using LogLibrary;
using WK.Libraries.BetterFolderBrowserNS;

namespace UserDocumentControl
{
    public partial class UserSettingsForm : Form
    {

        public UserSettingsForm()
        {
            InitializeComponent();
            Shown += OnShown;
            ArchiveFileNameTextBox.Leave += ArchiveFileNameTextBoxOnLeave;
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
        }

        private void SaveFoldersButton_Click(object sender, EventArgs e)
        {
            var results = ItemOperations.ProcessCheckBoxItems(FoldersCheckListBox.CheckedList(), FoldersCheckListBox.NotCheckedList());
            ItemOperations.SaveItems(results);
        }

        private async void button1_Click(object sender, EventArgs e)
        { 
            FoldersCheckListBox.Items.Clear();
            await Task.Delay(1000);

            var (hasItems, backupItems) = ItemOperations.ReadItems();
            if (hasItems)
            {
                FoldersCheckListBox.Items.Clear();

                for (int index = 0; index < backupItems.Count; index++)
                {
                    FoldersCheckListBox.Items.Add(backupItems[index].DirectoryName);
                    FoldersCheckListBox.SetItemCheckState(index, backupItems[index].IncludeFolder ?
                        CheckState.Checked :
                        CheckState.Unchecked);
                }
            }
        }
        private void RemoveCurrentFolderButton_Click(object sender, EventArgs e)
        {
            var index = FoldersCheckListBox.SelectedIndex;
            if (index > -1)
            {
                if (Dialogs.Question($"Remove {FoldersCheckListBox.Text}"))
                {
                    FoldersCheckListBox.RemoveBackItem(index);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void SelectArchiveFolderButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new BetterFolderBrowser() {Multiselect = false})
            {
                // TODO - make this remember from json setting file
                dialog.RootFolder = @"C:\OED";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ArchiveFolderNameTextBox.Text = dialog.SelectedFolder;
                }
            }
        }

        private void SaveZipSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.TextBoxesHaveValues())
            {
                ConfigurationOperations.Save(new Configuration() 
                    { ArchiveFolder = ArchiveFolderNameTextBox.Text, ArchiveFileName = ArchiveFileNameTextBox.Text });
            }
            else
            {
                MessageBox.Show($"Please select a folder and file name");
            }
        }
    }
}
