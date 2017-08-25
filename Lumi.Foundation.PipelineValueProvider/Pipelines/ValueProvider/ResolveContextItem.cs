using Sitecore.Data.Items;

namespace Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider
{
	public class ResolveContextItem : GenericValueProviderProcessor<Item>
	{
		public override object GetResult(ValueProviderArgs args)
		{
			return Sitecore.Context.Item;
		}
	}
}