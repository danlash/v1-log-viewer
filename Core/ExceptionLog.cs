using System;

namespace VersionOne.LogViewer
{
	public class ExceptionLog
	{
		public ExceptionLog(string virtualDirectory, DateTime occurredAt, Version version, string exception)
		{
			VirtualDirectory = virtualDirectory;
			OccurredAt = occurredAt;
			Version = version;
			Exception = exception;
		}

		public string VirtualDirectory { get; private set; }
		public DateTime OccurredAt { get; private set; }
		public Version Version { get; private set; }
		public string Exception { get; private set; }
	}
}