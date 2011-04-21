using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace VersionOne.LogViewer.Specs.parser
{
	class when_parsing_a_large_log : spec
	{
		private IEnumerable<ExceptionLog> _logs;

		public override void context()
		{
			IExceptionLogParser parser = new ExceptionLogParser();


			using (var logFile = File.OpenRead("../../data/large_log.txt"))
			{
				_logs = parser.Parse(logFile);
			}
		}

		[Test]
		public void it_should_not_throw()
		{
			_logs.should_not_be_null();
		}
	}
}
