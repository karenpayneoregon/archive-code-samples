using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.UtilityApiLibrary;


namespace FormsLibrary.Classes
{
    public class BackupItem
    {
        public bool IncludeFolder { get; set; }
        public string DirectoryName { get; set; }
        public string ShortName => PathHelpers.GetShortPath(DirectoryName);
        public override string ToString() => DirectoryName;

    }
}
