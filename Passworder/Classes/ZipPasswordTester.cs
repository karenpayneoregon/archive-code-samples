using System;
using System.Threading.Tasks;
using Ionic.Zip;

namespace TestBedProject.Classes
{
    public static class ZipPasswordTester
    {

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
        public static bool CheckPassword(Ionic.Zip.ZipEntry entry, string password)
        {
            try
            {
                using (var s = new PasswordCheckStream())
                {
                    entry.ExtractWithPassword(s, password);
                }
                return true;
            }
            catch (Ionic.Zip.BadPasswordException)
            {
                return false;
            }
            catch (PasswordCheckStream.GoodPasswordException)
            {
                return true;
            }
        }

        private class PasswordCheckStream : System.IO.MemoryStream
        {
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new GoodPasswordException();
            }

            public class GoodPasswordException : Exception { }
        }
    }
}
