using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsLibrary.Classes
{
    public static class EnvironmentHelpers
    {
        /// <summary>
        /// Get user document folder
        /// In rare cases a runtime exception might be thrown so in this case default to root of C.
        /// </summary>
        /// <returns></returns>
        public static string DocumentFolder()
        {
            try
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            catch
            {
                return "C:\\";
            }
        }
    }
}
