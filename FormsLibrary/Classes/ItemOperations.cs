using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FormsLibrary.Classes
{
    public class ItemOperations
    {

        public static string JsonFileName => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FolderSelections.json");
        public static bool JsonFileExists => File.Exists(JsonFileName);

        /// <summary>
        /// Remember user directory directory selections
        /// </summary>
        /// <param name="includeFolderList">Directories to process</param>
        /// <param name="excludeFolderList">Directories not to process</param>
        /// <returns>list of include and exclude directories</returns>
        public static List<BackupItem> ProcessCheckBoxItems(List<string> includeFolderList, List<string> excludeFolderList)
        {
            List<BackupItem> list = new List<BackupItem>();

            if (includeFolderList.Count > 0)
            {
                List<BackupItem> addItems = includeFolderList.Select(x => new BackupItem() { IncludeFolder = true, DirectoryName = x }).ToList();
                list.AddRange(addItems);
            }

            if (excludeFolderList.Count > 0)
            {
                List<BackupItem> excludeItems = excludeFolderList.Select(x => new BackupItem() { IncludeFolder = false, DirectoryName = x }).ToList();
                list.AddRange(excludeItems);
            }

            return list;
        }

        /// <summary>
        /// Save current selections to <see cref="JsonFileName"/>
        /// </summary>
        public static void SaveItems(List<BackupItem> source)
        {
            if (source.Count <= 0) return;
            var json = JsonConvert.SerializeObject(source, Formatting.Indented);
            File.WriteAllText(JsonFileName, json);

        }

        /// <summary>
        /// Read <see cref="BackupItem"/> list from <see cref="JsonFileName"/>
        /// </summary>
        /// <remarks>
        /// If <see cref="JsonFileName"/> does not exists, an empty list is returned
        /// </remarks>
        public static (bool hasItems, List<BackupItem> backupItems) ReadItems()
        {
            if (JsonFileExists)
            {
                var json = File.ReadAllText(JsonFileName);

                return (true, JsonConvert.DeserializeObject<List<BackupItem>>(json));
            }

            return (false, new List<BackupItem>());
        }

    }
}
