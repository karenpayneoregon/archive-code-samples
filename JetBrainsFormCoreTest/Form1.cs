using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetBrainsFormCoreTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += OnShown;
        }

        private void OnShown(object? sender, EventArgs e)
        {
            amountNumericUpDown1.Controls[0].Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{specialNumericUpDown1.AsInteger}");
        }
    }
}
