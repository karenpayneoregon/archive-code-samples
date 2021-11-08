using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionLibrary
{
    /// <summary>
    /// Asynchronously Enumerate Folders
    /// </summary>
    public class FileSystemCrawler
    {
        public int FolderCount { get; set; }
        public readonly ConcurrentQueue<DirectoryInfo> folderQueue = new ConcurrentQueue<DirectoryInfo>();
        private readonly ConcurrentBag<Task> tasks = new ConcurrentBag<Task>();

        public void CollectFolders(string path)
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tasks.Add(Task.Run(() => CrawlFolder(directoryInfo)));

            while (tasks.TryTake(out var taskToWaitFor))
            {
                taskToWaitFor.Wait();
            }
        }

        private void CrawlFolder(DirectoryInfo directorySource)
        {
            try
            {
                DirectoryInfo[] directoryInfos = directorySource.GetDirectories();

                foreach (DirectoryInfo childInfo in directoryInfos)
                {
                    // here may be dragons using enumeration variable as closure!!
                    DirectoryInfo di = childInfo;
                    folderQueue.Enqueue(di);
                    tasks.Add(Task.Run(() => CrawlFolder(di)));

                }

                /*
                 * TODO
                 * $"{dir.FullName}
                 */
                FolderCount++;
            }
            catch (Exception exception)
            {
                /*
                 * TODO
                 */
                while (exception != null)
                {
                    Console.WriteLine($"{exception.GetType()} {exception.Message}\n{exception.StackTrace}");
                    exception = exception.InnerException;
                }
            }
        }
    }
}
