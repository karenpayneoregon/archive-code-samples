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
;
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            Configuration configuration = new Configuration() { ArchiveFileName = @"C:\OED\Backup.zip", LastBackup = DateTime.Now };
            ConfigurationOperations.Save(configuration);
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
            var scn = Screen.FromPoint(Location);
            if (Snap(Left, scn.WorkingArea.Left)) Left = scn.WorkingArea.Left;
            if (Snap(Top, scn.WorkingArea.Top)) Top = scn.WorkingArea.Top;
            if (Snap(scn.WorkingArea.Right, Right)) Left = scn.WorkingArea.Right - Width;
            if (Snap(scn.WorkingArea.Bottom, Bottom)) Top = scn.WorkingArea.Bottom - Height;
        }

        #endregion
    }
}
