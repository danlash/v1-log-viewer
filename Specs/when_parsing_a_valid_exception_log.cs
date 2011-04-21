using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace VersionOne.LogViewer.Specs
{
	public class when_parsing_an_empty_exception_log_file
	{
		private ExceptionLog _log;

		[SetUp]
		public void context()
		{
			IExceptionLogParser parser = new ExceptionLogParser();

			_log = parser.Parse("".ToStream());
		}
		
		public void it_produces_an_empty_log()
		{
			_log.should_not_be_null();
		}
	}

	public static class extensions
	{
		public static Stream ToStream(this object obj)
		{
			var stream = new MemoryStream();
			var writer = new StreamWriter(stream);
			writer.Write(obj);
			return stream;
		}
	}

	public static class should_extensions
	{
		public static void should_not_be_null(this object obj)
		{
			Assert.IsNotNull(obj);
		}
	}
}

