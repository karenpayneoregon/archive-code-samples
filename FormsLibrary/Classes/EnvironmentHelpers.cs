using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
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
        /// <returns>users document folder or if there is an exception the root of C</returns>
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
        /// <summary>
        /// Open folder using windows explorer
        /// </summary>
        /// <param name="folder">folder to open</param>
        /// <remarks>
        /// when using .net core the executable must be specified
        /// </remarks>
        public static void OpenWithExplorer(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder)) return;
            if (Directory.Exists(folder))
            {
                if (IsNetCore())
                {
                    Process.Start("explorer.exe", folder);
                }
                else
                {
                    Process.Start( folder);
                }
            }
        }

        /// <summary>
        /// Determine if .NET Framework or .NET Core Framework at runtime
        /// </summary>
        /// <returns>true if core, false if classic framework</returns>
        public static bool IsNetCore()
        {
            var value = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName.Contains("Core");
            if (value.HasValue)
            {
                return value.Value;
            }
            else
            {
                throw new Exception($"{nameof(IsNetCore)} failed to determine runtime framework.");
            }

        }
    }
}
