using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsLibrary.Classes
{
    public static class EnvironmentHelpers
    {
        public static string DocumentFolder()
        {
            try
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            catch (Exception e)
            {
                return "C:\\";
            }
        }
    }
}
