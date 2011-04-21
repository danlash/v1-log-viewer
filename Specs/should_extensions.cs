using System;
using MbUnit.Framework;

namespace VersionOne.LogViewer.Specs
{
	public static class should_extensions
	{
		public static void should_not_be_null(this object obj)
		{
			Assert.IsNotNull(obj);
		}

		public static void should_be(this string actual, string expected)
		{
			Assert.AreEqual(expected, actual);
		}

		public static void should_be(this DateTime actual, DateTime expected)
		{
			Assert.AreEqual(expected, actual);
		}
	}
}