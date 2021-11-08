using Ionic.Zip;

namespace CompressionLibrary.Classes
{
    /// <summary>
    /// Since ZipEntry is not a partial class we must create our own class
    /// </summary>
    /// <remarks>
    /// The "new" modifier
    /// It's used to tell the compiler that the given C# property, method or member hides a similar
    /// member in the base class, in this case <see cref="ZipEntry"/> in ZipFile class.
    /// </remarks>
    public class Entry : ZipEntry
    {
        public Entry(ZipEntry source)
        {
            FileName = source.FileName;
            UncompressedSize = source.UncompressedSize;
            CompressionRatio = source.CompressionRatio;
            LastModified = source.LastModified;
            UsesEncryption = source.UsesEncryption;
            IsDirectory = source.IsDirectory;
            Length = source.FileName.Length;
            Comment = source.Comment;
        }

        public new long UncompressedSize { get; set; }
        public new double CompressionRatio { get; set; }
        public new bool UsesEncryption { get; set; }
        public new bool IsDirectory { get; set; }
        public int Length { get; set; }

        public EntryTag Tag => new EntryTag()
        {
            FileName = FileName, 
            Length = Length,
            IsDirectory = IsDirectory,
            IsFolder = IsDirectory ? "Yes" : "No",
            Comment = Comment ?? ""
        };

        public string[] ItemArray => new[]
        {
            Tag.IsFolder,
            Length.ToString(),
            FileName,
            $"{LastModified::yyyy-MM-dd HH:mm:ss}",
            FileHelpers.SizeSuffix(UncompressedSize),
            $"{CompressionRatio,5:F0}%"
        };
    }
}
