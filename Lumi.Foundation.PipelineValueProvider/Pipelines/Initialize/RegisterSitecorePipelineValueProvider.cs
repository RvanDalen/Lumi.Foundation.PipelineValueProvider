using System.Linq;
using Lumi.Foundation.PipelineValueProvider.Mvc;
using Sitecore.Pipelines;

namespace Lumi.Foundation.PipelineValueProvider.Pipelines.Initialize
{
	public class RegisterPipelineValueProvider
	{
		public void Process(PipelineArgs args)
		{
			var index = System.Web.Mvc.ValueProviderFactories.Factories.FirstOrDefault(f => f is System.Web.Mvc.ChildActionValueProviderFactory);
			if (index != null)
			{
				System.Web.Mvc.ValueProviderFactories.Factories.Insert(System.Web.Mvc.ValueProviderFactories.Factories.IndexOf(index) + 1, new PipelineValueProviderFactory());
			}
			else
			{
				System.Web.Mvc.ValueProviderFactories.Factories.Add(new PipelineValueProviderFactory());
			}
		}
	}
}
