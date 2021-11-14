using System;

namespace ExtractFilesWithProgress.Classes
{
	namespace Classes
	{
		/// <summary>
		/// For ZipEventHandler delegate args
		/// </summary>
		public class ZipArgs : EventArgs
		{
			private string _fileName;
			private int _percentDone;
			private long _fileLength;
			private bool _extracted;

			public ZipArgs(string fileName, long fileLength, int percentDone, bool extracted)
			{

				_fileName = fileName;
				_fileLength = fileLength;
				_percentDone = percentDone;
				_extracted = extracted;
			}
			public string FileName => _fileName;

            public long FileLength => _fileLength;

            public int PercentDone => _percentDone;

            public bool Extracted => _extracted;
        }
	}
}