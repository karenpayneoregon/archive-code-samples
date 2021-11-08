using System.Windows.Forms;

namespace ExtractFilesWithProgress.Classes
{
    public static class Dialogs
    {
        /// <summary>
        /// MessageBox wrapper to ask a question with No as the default button
        /// </summary>
        /// <param name="text"></param>
        /// <returns>true if okay to continue, false to abort</returns>
        public static bool Question(string text) => (
            MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
    }

}