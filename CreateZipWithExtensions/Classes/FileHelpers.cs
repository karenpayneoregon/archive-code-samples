using System.IO;
using static System.DateTime;

namespace CreateZipWithExtensions.Classes
{
    public static class FileHelpers
    {
        /// <summary>
        /// Generate a unique file name place one folder under the application path
        /// </summary>
        /// <remarks>
        /// Archives folder is created in post build event
        /// </remarks>
        public static string ZipFileName => Path.Combine("Archives", $"{Now:yyyy-dd-M--HH-mm-ss-ms}.zip");
    }
}
