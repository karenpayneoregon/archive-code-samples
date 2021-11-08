using System.Threading.Tasks;
using Ionic.Zip;
namespace CompressionLibrary
{
    public partial class ZipPasswordTester
    {
        /// <summary>
        /// Check if password for file is valid
        /// </summary>
        /// <param name="fileName">file compressed with password using DotNetZip</param>
        /// <param name="password">Password to validate</param>
        /// <returns>true if valid password, false if password is invalid</returns>
        /// <remarks>
        /// Must run async as CheckZipPassword takes time to run.
        /// </remarks>
        public static async Task<bool> IsValidFilePassword(string fileName, string password)
        {
            var result = false;

            await Task.Run(async () =>
            {
                await Task.Delay(10);
                result = ZipFile.CheckZipPassword(fileName, password);
            });

            return result;

        }
        /// <summary>
        /// Validate password for <see cref="ZipEntry"/>
        /// </summary>
        /// <param name="entry">Entity to check</param>
        /// <param name="password">Password to validate</param>
        /// <returns>true if valid, false if invalid password</returns>
        public static bool CheckPassword(ZipEntry entry, string password)
        {
            try
            {
                using (var itemCheckStream = new PasswordCheckStream())
                {
                    entry.ExtractWithPassword(itemCheckStream, password);
                }

                return true;
            }
            catch (BadPasswordException)
            {
                return false;
            }
            catch (PasswordCheckStream.GoodPasswordException)
            {
                return true;
            }
        }
    }
}
