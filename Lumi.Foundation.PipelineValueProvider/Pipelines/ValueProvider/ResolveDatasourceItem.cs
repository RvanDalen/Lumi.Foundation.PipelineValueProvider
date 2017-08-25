using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider
{
	public class ResolveDatasourceItem : GenericValueProviderProcessor<Item>
	{
		public override object GetResult(ValueProviderArgs args)
		{
			var renderingContext = RenderingContext.CurrentOrNull;

			//stop if we have no rendering context or we have no datasource for the current rendering
			if (string.IsNullOrEmpty(renderingContext?.Rendering.DataSource))
				return null;

			return renderingContext.Rendering.Item;
		}
	}
}
