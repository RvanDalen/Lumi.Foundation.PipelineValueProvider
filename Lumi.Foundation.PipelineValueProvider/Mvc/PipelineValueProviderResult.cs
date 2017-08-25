using System;
using System.Globalization;
using System.Web.Mvc;
using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;
using Sitecore.Pipelines;

namespace Lumi.Foundation.PipelineValueProvider.Mvc
{
	public class PipelineValueProviderResult : ValueProviderResult
	{
		private readonly string _pipelineName;

		public PipelineValueProviderResult(string pipelineName)
		{
			_pipelineName = pipelineName;
		}

		public override object ConvertTo(Type type, CultureInfo culture)
		{
			var args = new ValueProviderArgs(type);
			CorePipeline.Run($"mvc.valueprovider.{_pipelineName}", args);

			return args.Result ?? base.ConvertTo(type, culture);
		}
	}
}
