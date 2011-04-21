using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VersionOne.LogViewer
{
	public interface IExceptionLogParser
	{
		ExceptionLog Parse(Stream log);
	}

	public class ExceptionLogParser  : IExceptionLogParser
	{
		public ExceptionLog Parse(Stream log)
		{
			return new ExceptionLog();
		}
	}
}
