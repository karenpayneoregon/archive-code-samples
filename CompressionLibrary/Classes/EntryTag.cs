namespace CompressionLibrary.Classes
{
    /// <summary>
    /// Used for obtaining current item information in a ListView current item
    /// </summary>
    public class EntryTag
    {
        public string FileName { get; set; }
        public bool IsDirectory { get; set; }
        public int Length { get; set; }
        public string Password { get; set; }
        public string IsFolder { get; set; }
        public string Comment { get; set; }
    }
}