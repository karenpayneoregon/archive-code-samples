namespace ExtractFilesWithProgress.LanguageExtensions
{
    public static class Extensions
    {

        /// <summary>
        /// Return current percent from currentValue of
        /// totalValue
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="totalValue"></param>
        /// <returns></returns>
        public static int PercentageOf(this int currentValue, int totalValue)
        {
            return (currentValue * 100) / totalValue;
        }
        /// <summary>
        /// Provides byte abbreviations 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <remarks>
        /// array elements in suffix could be changed to uppercase 
        /// </remarks>
        public static string ToEnglishKb(this long bytes)
        {

            string[] suffix = { "b", "kb", "mb", "gb", "tb" };
            float byteNumber = bytes;

            for (int index = 0; index < suffix.Length; index++)
            {

                if (byteNumber < 1000)
                {
                    return index == 0 ? $"{byteNumber} {suffix[index]}" : $"{byteNumber:0.#0} {suffix[index]}";
                }
                else
                {
                    byteNumber /= 1024;
                }

            }

            return $"{byteNumber:N} {suffix[suffix.Length - 1]}";

        }

    }
}