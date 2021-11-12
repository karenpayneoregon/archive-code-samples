using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileOperationsTest.CustomAsserts
{
    internal static class CustomerAsserts
    {
        /// <summary>
        /// Compare case insensitive 
        /// </summary>
        /// <param name="assert"></param>
        /// <param name="expected">Expected result</param>
        /// <param name="actual">Test value</param>
        public static void InsensitiveStringEquals(this Assert assert, string expected, string actual)
        {

            if (string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            throw new AssertFailedException(GetMessage(expected, actual));
        }
        public static void NotStringEquals(this Assert assert, string expected, string actual)
        {

            if (string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (expected != actual)
            {
                return;
            }

            throw new AssertFailedException(GetMessage(expected, actual));
        }
        private static string GetMessage(string expected, string actual)
        {
            var expectedFormat = ReplaceInvisibleCharacters(expected);
            var actualFormat = ReplaceInvisibleCharacters(actual);

            // Get the index of the first different character
            var index = expectedFormat.Zip(actualFormat, (c1, c2) => c1 == c2).TakeWhile(b => b).Count();
            var caret = new string(' ', index) + "^";

            return $@"Strings are different.
Expect: <{expectedFormat}>
Actual: <{actualFormat}>
         {caret}";
        }

        private static string ReplaceInvisibleCharacters(string value)
        {
            return value
                .Replace(' ', '·')
                .Replace('\t', '→')
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
        }
    }
}