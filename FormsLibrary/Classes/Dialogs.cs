using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.MessageBox;

namespace FormsLibrary.Classes
{
    public static class Dialogs
    {
        [DebuggerStepThrough]
        public static bool Question(string text) =>
            (Show(text, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes);

        [DebuggerStepThrough]
        public static void InformationDialog(string message, string title) =>
            Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        [DebuggerStepThrough]
        public static void ErrorDialog(string message) =>
            Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

    }
}
