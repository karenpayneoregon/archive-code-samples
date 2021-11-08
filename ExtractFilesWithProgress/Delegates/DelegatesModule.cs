using ExtractFilesWithProgress.Classes.Classes;

namespace ExtractFilesWithProgress.Delegates
{
	namespace Delegates
	{
		/// <summary>
		/// Delegate used for passing timely data from extraction
		/// of files from a compressed file.
		/// </summary>
		public static class DelegatesModule
		{
			public delegate void ZipEventHandler(object sender, ZipArgs e);
		}
	}
}