using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;

namespace Lumi.Foundation.PipelineValueProvider.Glass.Pipelines.ValueProvider
{
	public class ResolveGlassContextItem : GlassValueProviderProcessor
	{
		private readonly ISitecoreContext _sitecoreContext;

		public ResolveGlassContextItem()
		{
			_sitecoreContext = SitecoreContextFactory.Default.GetSitecoreContext();
		}

		public ResolveGlassContextItem(ISitecoreContext sitecoreContext)
		{
			_sitecoreContext = sitecoreContext;
		}

		public override object GetResult(ValueProviderArgs args)
		{
			return _sitecoreContext.GetCurrentItem(args.RequestedType, true, true);
		}
	}
}
