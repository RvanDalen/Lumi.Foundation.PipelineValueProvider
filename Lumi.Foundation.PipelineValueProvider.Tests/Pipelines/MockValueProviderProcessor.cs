using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;

namespace Lumi.Foundation.PipelineValueProvider.Tests.Pipelines
{
	public class MockValueProviderProcessor<T> : GenericValueProviderProcessor<T>
	{
		private readonly T _result;

		public MockValueProviderProcessor(T result)
		{
			_result = result;
		}

		public override object GetResult(ValueProviderArgs args)
		{
			return _result;
		}
	}
}
