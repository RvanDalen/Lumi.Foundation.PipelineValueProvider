using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;

namespace Lumi.Foundation.PipelineValueProvider.Glass.Pipelines.ValueProvider
{
	public abstract class GlassValueProviderProcessor : ValueProviderProcessor
	{
		private readonly ISitecoreContext _sitecoreContext;

		public bool DisableTypeConfigurationCheck { get; set; }

		public GlassValueProviderProcessor()
		{
			_sitecoreContext = SitecoreContextFactory.Default.GetSitecoreContext();
		}

		public GlassValueProviderProcessor(ISitecoreContext sitecoreContext)
		{
			_sitecoreContext = sitecoreContext;
		}

		public override void Process(ValueProviderArgs args)
		{
			//Stop if we dont recognize the requested type
			if (!DisableTypeConfigurationCheck && !_sitecoreContext.GlassContext.TypeConfigurations.ContainsKey(args.RequestedType))
				return;

			base.Process(args);
		}
	}
}
