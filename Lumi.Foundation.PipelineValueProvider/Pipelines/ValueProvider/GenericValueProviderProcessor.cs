using Sitecore.Diagnostics;

namespace Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider
{
	public abstract class GenericValueProviderProcessor<T> : ValueProviderProcessor
	{
		public override void Process(ValueProviderArgs args)
		{
			//make sure we're all good
			Assert.IsNotNull(args, typeof(ValueProviderArgs));

			//stop if we cannot serve the requested type
			if (args.RequestedType != typeof(T)) return;

			base.Process(args);
		}
	}
}