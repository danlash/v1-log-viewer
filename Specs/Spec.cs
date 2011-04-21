using MbUnit.Framework;

namespace VersionOne.LogViewer.Specs
{
	public abstract class Spec
	{
		[SetUp]
		public abstract void context();
	}
}