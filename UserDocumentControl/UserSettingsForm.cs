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

namespace UserDocumentControl
{
    public partial class UserSettingsForm : Form
    {

        public UserSettingsForm()
        {
            InitializeComponent();

            Shown += OnShown;

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
        /// Accept folders from windows explorer
        /// </summary>
        private void SelectedFoldersCheckListBoxOnDragDrop(object sender, DragEventArgs e)
        {
            var droppedData = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var item in droppedData)
            {
                if (!Directory.Exists(item)) continue;

                var index = FoldersCheckListBox.FindString(item);

                // Disallow duplicates 
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

        /// <summary>
        /// Save user selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            var includeList = FoldersCheckListBox.CheckedList();
            var excludeList = FoldersCheckListBox.NotCheckedList();

            var results = ItemOperations.ProcessCheckBoxItems(includeList, excludeList);
            ItemOperations.SaveItems(results);
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            FoldersCheckListBox.Items.Clear();
        }

        private void RemoveCurrentButton_Click(object sender, EventArgs e)
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
    }
}
