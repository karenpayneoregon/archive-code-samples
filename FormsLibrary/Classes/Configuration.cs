using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsLibrary.Classes
{
    public class Configuration
    {
        public string ArchiveFolder { get; set; }
        /// <summary>
        /// Archive (.zip) file name
        /// </summary>
        public string ArchiveFileName { get; set; }
        /// <summary>
        /// Last date/time <see cref="ArchiveFileName"/> was created
        /// </summary>
        public DateTime LastBackup { get; set; }
    }
}
