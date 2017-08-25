using System;
using Sitecore.Pipelines;

namespace Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider
{
	public class ValueProviderArgs : PipelineArgs
	{
		public Type RequestedType { get; }

		public object Result { get; set; }

		public ValueProviderArgs(Type requestedType)
		{
			RequestedType = requestedType;
		}
	}
}
