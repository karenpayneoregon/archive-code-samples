using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

//using Microsoft.Extensions.FileSystemGlobbing;
//using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace WinApp2.Classes
{
    /// <summary>
    /// 
    /// Entering uncharted territory for alternate methods to
    /// get files in a folder.
    ///
    /// Pretty much zero out there on the web.
    ///
    /// Why present this?
    /// Because many developers never explore new ways to code.
    ///
    /// Delegates/events
    /// Show one of several ways to raise events while novice developer will pass controls
    /// or objects to work on where this is bad form.
    /// 
    /// </summary>
    public class GlobbingOperations
    {
        public delegate void OnTraverse(string sender);
        public static event OnTraverse TraverseHandler;

        public delegate void OnDone();

        public static event OnDone Done;

        public static IEnumerable<string> IncludePatterns;
        public static IEnumerable<string>[] ExcludePatterns;
        
        /// <summary>
        /// Searches the file system for files with names that match specified patterns.
        /// </summary>
        /// <param name="searchFolder">Existing folder to search</param>
        /// <remarks>
        /// See the following for patterns
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.filesystemglobbing.matcher?view=dotnet-plat-ext-5.0#remarks
        /// </remarks>
        public static void Sample1(string searchFolder)
        {
            if (!Directory.Exists(searchFolder))
            {
                TraverseHandler?.Invoke("Folder does not exists");
                return;
            }

            Matcher matcher = new Matcher();
            matcher.AddIncludePatterns(new[] { "*.pdf", "**/*.ico" });
            
            PatternMatchingResult matchingResult = matcher.Execute(
                new DirectoryInfoWrapper(new DirectoryInfo(searchFolder)));
            
            if (matchingResult.HasMatches)
            {

                foreach (var file in matchingResult.Files)
                {
                    TraverseHandler?.Invoke(file.Path);
                }

                TraverseHandler?.Invoke($"Match count {matchingResult.Files.Count()}");
                Done?.Invoke();

            }

        }
        public static PatternMatchingResult Sample2(DirectoryInfoBase directoryInfo)
        {
            var files = new List<FilePatternMatch>();

            foreach (var includePattern in IncludePatterns)
            {
                Matcher matcher = new Matcher();

                matcher.AddInclude(includePattern);
                if (ExcludePatterns != null)
                {
                    matcher.AddExcludePatterns(ExcludePatterns);
                }
                
                var matchingResult = matcher.Execute(directoryInfo);

                if (matchingResult.Files.Any())
                {
                    files.AddRange(matchingResult.Files);
                }
            }

            return new PatternMatchingResult(files);
        }
    }
}