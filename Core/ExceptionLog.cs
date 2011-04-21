using System;

namespace VersionOne.LogViewer
{
	public class ExceptionLog
	{
		public ExceptionLog(string virtualDirectory, DateTime occurredAt)
		{
			VirtualDirectory = virtualDirectory;
			OccurredAt = occurredAt;
		}

		public string VirtualDirectory { get; private set; }
		public DateTime OccurredAt { get; private set; }
	}
}