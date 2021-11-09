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
    public partial class Form1 : Form
    {
        private List<BackupItem> _includeBackupItemsList = new List<BackupItem>();

        public Form1()
        {
            InitializeComponent();

            Shown += OnShown;

        }

        private void OnShown(object sender, EventArgs e)
        {
            SelectedFoldersCheckListBox.AllowDrop = true;
            SelectedFoldersCheckListBox.DragDrop += SelectedFoldersCheckListBoxOnDragDrop;
            SelectedFoldersCheckListBox.DragEnter += SelectedFoldersCheckListBoxOnDragEnter;
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

        }

        /// <summary>
        /// Save user selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            var includeList = SelectedFoldersCheckListBox.CheckedList();
            var excludeList = SelectedFoldersCheckListBox.NotCheckedList();

            var results = ItemOperations.ProcessCheckBoxItems(includeList, excludeList);
            ItemOperations.SaveItems(results);
        }
    }
}
