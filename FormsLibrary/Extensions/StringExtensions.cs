using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsLibrary.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Given a TextBox accepting a file name, ensure the extension is .zip
        /// </summary>
        /// <param name="source"></param>
        public static void EnsureZipExtension(this TextBox source)
        {
            if (!string.IsNullOrWhiteSpace(source.Text))
            {
                var current = Path.GetExtension(source.Text).ToLower();
                if (current != ".zip")
                {
                    source.Text = $"{Path.GetFileNameWithoutExtension(source.Text)}.zip";

                }
            }
        }
        /// <summary>
        /// Determine if string is empty
        /// </summary>
        /// <param name="sender">String to test if null or whitespace</param>
        /// <returns>true if empty or false if not empty</returns>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string sender) => string.IsNullOrWhiteSpace(sender);

    }
}
