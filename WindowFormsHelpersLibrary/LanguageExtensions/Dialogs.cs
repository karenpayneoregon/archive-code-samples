using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.MessageBox;

namespace WindowFormsHelpersLibrary.LanguageExtensions
{
    public static class Dialogs
    {
        [DebuggerStepThrough]
        public static bool Question(string text) =>
            (Show(text, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        
        [DebuggerStepThrough]
        public static bool Question(string text, MessageBoxIcon icon) =>
            (Show(text, Application.ProductName, MessageBoxButtons.YesNo, icon, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes);


        [DebuggerStepThrough]
        public static void InformationDialog(string message, string title) =>
            Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        [DebuggerStepThrough]
        public static void InformationDialog(string message, string title, MessageBoxIcon icon) =>
            Show(message, title, MessageBoxButtons.OK, icon);


        [DebuggerStepThrough]
        public static void ErrorDialog(string message) =>
            Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);


        [DebuggerStepThrough]
        public static void ErrorDialog(string message, string title) =>
            Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);


        [DebuggerStepThrough]
        public static bool MessageBox(string text, MessageBoxIcon icon = MessageBoxIcon.Error) =>
            Show(text, Application.ProductName, MessageBoxButtons.OKCancel, icon) == DialogResult.OK;

        [DebuggerStepThrough]
        public static bool MessageBox(string text,string title, MessageBoxIcon icon = MessageBoxIcon.Error) => 
            Show(text, title, MessageBoxButtons.OKCancel, icon) == DialogResult.OK;
    }
}
