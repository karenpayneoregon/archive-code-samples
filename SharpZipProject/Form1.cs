using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace SharpZipProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ZipSingleFileButton_Click(object sender, EventArgs e)
        {

            using (var zip = ZipFile.Create("SingleFile.zip"))
            {
                zip.BeginUpdate();
                zip.Add("Documents.docx", CompressionMethod.Deflated);
                zip.CommitUpdate();
                zip.Close();
            }
        }

    }
}
