using Glass.Mapper.Sc;
using Lumi.Foundation.PipelineValueProvider.Glass.Pipelines.ValueProvider;
using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;

namespace Lumi.Foundation.PipelineValueProvider.Glass.Tests.Pipelines.ValueProvider
{
	public class MockGlassValueProviderProcessor : GlassValueProviderProcessor
	{
		private readonly object _result;

		public MockGlassValueProviderProcessor(ISitecoreContext sitecoreContext, object result = null) : base(sitecoreContext)
		{
			_result = result;
		}

		public override object GetResult(ValueProviderArgs args)
		{
			return _result;
		}
	}
}
