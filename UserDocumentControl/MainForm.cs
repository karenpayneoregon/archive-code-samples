using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private Configuration _configuration;
        public MainForm()
        {
            InitializeComponent();
;           Shown += OnShown;

        }

        private void OnShown(object sender, EventArgs e)
        {
            _configuration = ConfigurationOperations.Read();
            LastBackupDateLabel.Text = _configuration.LastBackup == DateTime.MinValue ? "N/A" : $"{_configuration.LastBackup:F}";
            CommentTextBox.Text = _configuration.ArchiveFileComment;
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            //Configuration configuration = new Configuration() { ArchiveFileName = @"C:\OED\Backup.zip", LastBackup = DateTime.Now };
            //ConfigurationOperations.Save(configuration);

            

        }


        #region Snap to edge

        private const int SnapDist = 100;
        private static bool Snap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            var screen = Screen.FromPoint(Location);
            if (Snap(Left, screen.WorkingArea.Left)) Left = screen.WorkingArea.Left;
            if (Snap(Top, screen.WorkingArea.Top)) Top = screen.WorkingArea.Top;
            if (Snap(screen.WorkingArea.Right, Right)) Left = screen.WorkingArea.Right - Width;
            if (Snap(screen.WorkingArea.Bottom, Bottom)) Top = screen.WorkingArea.Bottom - Height;
        }

        #endregion

        private void ConfigurationButton_Click(object sender, EventArgs e)
        {
            UserSettingsForm form = new UserSettingsForm();

            form.SaveChangesHandler += FormOnSaveChangesHandler;

            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
            finally
            {
                form.SaveChangesHandler -= FormOnSaveChangesHandler;
                form.Dispose();
            }
        }

        private void FormOnSaveChangesHandler(Configuration sender)
        {
            Console.WriteLine("Update controls");
        }
    }
}
