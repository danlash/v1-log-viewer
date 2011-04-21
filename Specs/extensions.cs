using System.IO;

namespace VersionOne.LogViewer.Specs
{
	public static class extensions
	{
		public static Stream ToStream(this object obj)
		{
			var stream = new MemoryStream();
			var writer = new StreamWriter(stream);
			writer.Write(obj);
			writer.Flush();
			stream.Position = 0;

			return stream;
		}
	}
}