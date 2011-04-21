using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VersionOne.LogViewer
{
	public interface IExceptionLogParser
	{
		ExceptionLog Parse(Stream log);
	}

	public class ExceptionLogParser  : IExceptionLogParser
	{
		private const string LOG_REGEX = @"==== (/.*?) (.*?) ====(.*?)==== Build: (.*?) ====";
/*

^==== (\/.*?) (.*?) ====$
.*
^==== Build: (.*?) ====$
 
*/


		public ExceptionLog Parse(Stream logStream)
		{
			var reader = new StreamReader(logStream);
			var log = reader.ReadToEnd();

			var logRegex = new Regex(LOG_REGEX, RegexOptions.Compiled | RegexOptions.Singleline);

			var matches = logRegex.Matches(log);

			
			foreach (Match match in matches)
			{
				var virtualDirectory = match.Groups[1].Value;
				var dateString = match.Groups[2].Value;
				var date = DateTime.MinValue;
				DateTime.TryParse(dateString, out date);
				var versionString = match.Groups[4].Value;
				var version = new Version(versionString);
				var exception = match.Groups[3].Value.Trim();

				var exceptionLog = new ExceptionLog(virtualDirectory, date, version, exception);
				return exceptionLog;
			}

			return null;
		}
	}
}
