using System;
namespace CompressionLibrary
{
    public partial class ZipPasswordTester
    {
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
