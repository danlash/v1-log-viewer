using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace VersionOne.LogViewer.Specs
{
	public class when_parsing_an_empty_exception_log_file : spec
	{
		private IEnumerable<ExceptionLog> _logs;

		public override void context()
		{
			IExceptionLogParser parser = new ExceptionLogParser();

			_logs = parser.Parse("".ToStream());
		}
		
		[Test]
		public void it_produces_an_empty_log_list()
		{
			_logs.should_not_be_null();
		}

		[Test]
		public void there_should_be_no_logs()
		{
			_logs.Count().should_be(0);
		}
	}
}

