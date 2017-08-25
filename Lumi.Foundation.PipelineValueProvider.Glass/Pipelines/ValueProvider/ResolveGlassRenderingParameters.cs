using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;
using Sitecore.Mvc.Presentation;

namespace Lumi.Foundation.PipelineValueProvider.Glass.Pipelines.ValueProvider
{
	public class ResolveGlassRenderingParameters : GlassValueProviderProcessor
	{
		private readonly ISitecoreContext _sitecoreContext;

		public ResolveGlassRenderingParameters()
		{
			_sitecoreContext = SitecoreContextFactory.Default.GetSitecoreContext();
		}

		public ResolveGlassRenderingParameters(ISitecoreContext sitecoreContext)
		{
			_sitecoreContext = sitecoreContext;
		}

		public override object GetResult(ValueProviderArgs args)
		{
			var renderingContext = RenderingContext.CurrentOrNull;
			if (renderingContext?.Rendering.Parameters == null) return null;

			return typeof(IGlassHtml).GetMethod("GetRenderingParameters")
									 .MakeGenericMethod(args.RequestedType)
									 .Invoke(_sitecoreContext.GlassHtml, new object[] { renderingContext.Rendering[GlassHtml.Parameters] });
		}
	}
}
