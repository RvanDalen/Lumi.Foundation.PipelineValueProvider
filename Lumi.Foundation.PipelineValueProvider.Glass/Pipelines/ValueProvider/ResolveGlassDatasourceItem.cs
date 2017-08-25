using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;
using Sitecore.Mvc.Presentation;

namespace Lumi.Foundation.PipelineValueProvider.Glass.Pipelines.ValueProvider
{
	public class ResolveGlassDatasourceItem : GlassValueProviderProcessor
	{
		private readonly ISitecoreContext _sitecoreContext;

		public ResolveGlassDatasourceItem()
		{
			_sitecoreContext = SitecoreContextFactory.Default.GetSitecoreContext();
		}

		public ResolveGlassDatasourceItem(ISitecoreContext sitecoreContext)
		{
			_sitecoreContext = sitecoreContext;
		}

		public override object GetResult(ValueProviderArgs args)
		{
			var renderingContext = RenderingContext.CurrentOrNull;
			if (string.IsNullOrEmpty(renderingContext?.Rendering.DataSource)) return null;

			return _sitecoreContext.CreateType(args.RequestedType, renderingContext.Rendering.Item, true, true, null, null);
		}
	}
}
