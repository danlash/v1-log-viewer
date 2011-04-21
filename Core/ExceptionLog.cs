using System;

namespace VersionOne.LogViewer
{
	public class ExceptionLog
	{
		public ExceptionLog(string virtualDirectory)
		{
			VirtualDirectory = virtualDirectory;
		}

		public string VirtualDirectory { get; private set; }
	}
}