using System.Web.Mvc;

namespace Lumi.Foundation.PipelineValueProvider.Mvc
{
	public class PipelineValueProviderFactory : ValueProviderFactory
	{
		public override IValueProvider GetValueProvider(ControllerContext controllerContext)
		{
			return new PipelineValueProvider();
		}
	}
}
