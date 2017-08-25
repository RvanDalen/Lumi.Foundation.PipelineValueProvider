using Sitecore.Mvc.Presentation;

namespace Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider
{
	public class ResolveRenderingParameters : GenericValueProviderProcessor<RenderingParameters>
	{
		public override object GetResult(ValueProviderArgs args)
		{
			return RenderingContext.CurrentOrNull?.Rendering.Parameters;
		}
	}
}