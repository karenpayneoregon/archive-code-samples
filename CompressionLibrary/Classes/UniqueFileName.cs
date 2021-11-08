using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionLibrary.Classes
{
    /// <summary>
    /// Container for reading information from a unique file name
    /// </summary>
    public class UniqueFileName
    {
        /// <summary>
        /// Unique file name from <see cref="FileHelpers.UniqueFileName"/>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// DateTime from <see cref="FileHelpers.DateTimeFromFileName"/>
        /// </summary>
        public DateTime DateTime { get; set; }
        public override string ToString() => Name;

    }
}
