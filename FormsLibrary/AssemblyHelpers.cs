using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FormsLibrary
{
    public class AssemblyHelpers
    {
        /// <summary>
        /// Get calling program 
        /// </summary>
        /// <returns></returns>
        public static string CallingNamespace()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            // ReSharper disable once AssignNullToNotNullAttribute
            var callerAssemblies = new StackTrace().GetFrames()
                // ReSharper disable once PossibleNullReferenceException
                .Select(sf => sf.GetMethod().ReflectedType.Assembly)
                .Distinct()
                .Where(assembly => assembly.GetReferencedAssemblies()
                    .Any(assemblyName => assemblyName.FullName == currentAssembly.FullName));

            return callerAssemblies.Last().Location;
        }

        /// <summary>
        /// Experiment in tangent with <see cref="Classes.EnvironmentHelpers.IsNetCore"/> to determine if caller is
        /// .net classic or .net executable.
        /// </summary>
        /// <returns></returns>
        public static bool IsExecutable()
        {
            var appPathName = CallingNamespace();
            if (Path.GetExtension(appPathName).ToLower() == ".dll")
            {
                return File.Exists(Path.ChangeExtension(appPathName, ".exe"));
            }
            else if (Path.GetExtension(appPathName) == ".exe")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}