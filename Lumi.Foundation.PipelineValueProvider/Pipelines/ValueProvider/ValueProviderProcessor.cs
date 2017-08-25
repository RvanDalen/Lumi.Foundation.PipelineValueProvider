using Sitecore.Diagnostics;

namespace Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider
{
	public abstract class ValueProviderProcessor
	{
		public virtual void Process(ValueProviderArgs args)
		{
			//make sure we're all good
			Assert.IsNotNull(args, typeof(ValueProviderArgs));
			
			//stop if we already have a result
			if (args.Result != null) return;

			//get the result
			args.Result = GetResult(args);

			//abort if result was succesfully retrieved
			if (args.Result != null)
				args.AbortPipeline();
		}

		public abstract object GetResult(ValueProviderArgs args);
	}
}
