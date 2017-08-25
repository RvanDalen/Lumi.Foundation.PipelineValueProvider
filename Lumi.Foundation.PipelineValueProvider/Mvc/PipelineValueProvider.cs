using System;
using System.Web.Mvc;

namespace Lumi.Foundation.PipelineValueProvider.Mvc
{
	public class PipelineValueProvider : IValueProvider
	{
		public bool ContainsPrefix(string prefix)
		{
			return "contextitem".Equals(prefix, StringComparison.OrdinalIgnoreCase)
			       || "datasource".Equals(prefix, StringComparison.OrdinalIgnoreCase)
			       || "renderingparameters".Equals(prefix, StringComparison.OrdinalIgnoreCase);
		}

		public ValueProviderResult GetValue(string key)
		{
			var keyValues = key.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
			var prefix = keyValues[0];

			return new PipelineValueProviderResult(prefix.ToLowerInvariant());
		}
	}
}
