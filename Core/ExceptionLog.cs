using System;

namespace VersionOne.LogViewer
{
	public class ExceptionLog
	{
		public ExceptionLog(string virtualDirectory, DateTime occurredAt, Version version)
		{
			VirtualDirectory = virtualDirectory;
			OccurredAt = occurredAt;
			Version = version;
		}

		public string VirtualDirectory { get; private set; }
		public DateTime OccurredAt { get; private set; }
		public Version Version { get; private set; }
	}
}