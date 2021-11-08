using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompressionLibrary;
using CompressionLibrary.Classes;

namespace CreatePasswordedZipFromFolders
{
    public partial class ViewZipFileForm : Form
    {
        private readonly List<Entry> _entries;

        public ViewZipFileForm()
        {
            InitializeComponent();
        }
        public ViewZipFileForm(List<Entry> entries, string fileName)
        {
            InitializeComponent();

            _entries = entries;
            Shown += OnShown;
            Text = fileName;
        }

        private void OnShown(object sender, EventArgs e)
        {
            ZipFileListView.BeginUpdate();
            foreach (var entry in _entries)
            {

                ZipFileListView.Items.Add(
                    new ListViewItem(entry.ItemArray)
                    {
                        Tag = entry.Tag
                    });

            }

            ZipFileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            ZipFileListView.EndUpdate();
            ZipFileListView.Items[0].Selected = true;
            ZipFileListView.EnsureVisible(0);
            ActiveControl = ZipFileListView;

            ZipFileListView.MouseDoubleClick += ZipFileListViewOnMouseDoubleClick;

            //var test = _entries.Max(x => x.Length);
            
        }

        private void ZipFileListViewOnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ZipFileListView.SelectedItems.Count != 1) return;

            var entryTag = (EntryTag) ZipFileListView.SelectedItems[0].Tag;

            var information = entryTag.IsDirectory ? "Directory name " : "File name ";
            information += $": {entryTag.FileName}\nLength: {entryTag.Length}";

            MessageBox.Show(information);
        }
    }
}
