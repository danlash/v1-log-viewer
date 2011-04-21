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
		private ExceptionLog _log;

		public override void context()
		{
			IExceptionLogParser parser = new ExceptionLogParser();

			_log = parser.Parse("".ToStream());
		}
		
		[Test]
		public void it_produces_an_empty_log()
		{
			_log.should_not_be_null();
		}
	}
}

