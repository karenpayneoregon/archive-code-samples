using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace UtilityApiLibrary
    {
        public class PathHelpers
        {
            const int MAX_PATH = 255;
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetLongPathName(
                [MarshalAs(UnmanagedType.LPTStr)] string path, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder longPath, int longPathLength);
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetShortPathName([MarshalAs(UnmanagedType.LPTStr)] string path, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder shortPath, int shortPathLength);
            /// <summary>
            /// Get Windows short path for a folder. If the folder name length is greater than <see cref="MAX_PATH"/> then
            /// the original path is returned as <see cref="GetShortPathName"/> does not work well in these cases.
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public static string GetShortPath(string source)
            {
                if (source.Length > MAX_PATH)
                {
                    return source;
                }
                else
                {
                    var shortPath = new StringBuilder(255);
                    GetShortPathName(source, shortPath, shortPath.Capacity);
                    return shortPath.ToString();
                }
            }
        }
    }
}
