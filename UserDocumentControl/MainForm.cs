using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsLibrary.Classes;

namespace UserDocumentControl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Configuration configuration = new Configuration() { ArchiveFileName = @"C:\OED\Backup.zip", LastBackup = DateTime.Now };
            ConfigurationOperations.Save(configuration);
        }
    }
}
