using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Lumi.Foundation.PipelineValueProvider.Tests.Pipelines
{
	[TestClass]
	public class PipelinesTests
	{
		[TestMethod]
		public void ValueProviderProcessor_Stops_If_There_Already_Is_A_Result()
		{
			//Arrange
			var expectedResult = new RenderingParameters("?a=b");
			var processor = new MockValueProviderProcessor<RenderingParameters>(new RenderingParameters("?c=d"));
			var args = new ValueProviderArgs(typeof(RenderingParameters))
			{
				Result = expectedResult
			};

			//Act
			processor.Process(args);

			//Assert
			Assert.AreSame(expectedResult, args.Result);
		}

		[TestMethod]
		public void ValueProviderProcessor_Stops_If_RequestedType_Is_Not_Equal_To_SupportedType()
		{
			//Arrange
			var processor = new MockValueProviderProcessor<RenderingParameters>(new RenderingParameters(string.Empty));
			var args = new ValueProviderArgs(typeof(Item));

			//Act
			processor.Process(args);

			//Assert
			Assert.IsNull(args.Result);
		}

		[TestMethod]
		public void ValueProviderProcessor_Sets_The_ArgsResults_When_Retrieved()
		{
			//Arrange
			var expectedResult = new RenderingParameters("?c=d");
			var processor = new MockValueProviderProcessor<RenderingParameters>(expectedResult);
			var args = new ValueProviderArgs(typeof(RenderingParameters));

			//Act
			processor.Process(args);

			//Assert
			Assert.AreSame(expectedResult, args.Result);
		}

		[TestMethod]
		public void ValueProviderProcessor_Aborts_The_Pipeline_If_Result_Is_Retrieved()
		{
			//Arrange
			var result = new RenderingParameters("?c=d");
			var processor = new MockValueProviderProcessor<RenderingParameters>(result);
			var args = new ValueProviderArgs(typeof(RenderingParameters));

			//Act
			processor.Process(args);

			//Assert
			Assert.IsTrue(args.Aborted);
		}
	}
}
