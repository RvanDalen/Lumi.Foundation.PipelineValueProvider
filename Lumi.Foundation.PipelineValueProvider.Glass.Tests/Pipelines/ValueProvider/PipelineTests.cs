using Glass.Mapper;
using Glass.Mapper.IoC;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using Lumi.Foundation.PipelineValueProvider.Pipelines.ValueProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lumi.Foundation.PipelineValueProvider.Glass.Tests.Pipelines.ValueProvider
{
	[TestClass]
	public class PipelineTests
	{
		[TestMethod]
		public void GlassValueProviderProcessor_Gets_Results_If_RequestedType_Is_In_TypeConfigurations()
		{
			//Arrange
			var depenencyResolver = new Mock<IDependencyResolver>();
			var glassContext = Context.Create(depenencyResolver.Object);
			glassContext.TypeConfigurations.AddOrUpdate(typeof(string), type => new SitecoreTypeConfiguration(), (type, configuration) => configuration);

			var sitecoreContext = new Mock<ISitecoreContext>();
			sitecoreContext.Setup(ctx => ctx.GlassContext).Returns(glassContext);

			var processor = new MockGlassValueProviderProcessor(sitecoreContext.Object, "something not null");
			var args = new ValueProviderArgs(typeof(string));

			//Act
			processor.Process(args);

			//Assert
			Assert.AreEqual(args.Result, "something not null");
		}

		[TestMethod]
		public void GlassValueProviderProcessor_Stops_If_RequestedType_Is_Not_In_TypeConfigurations()
		{
			//Arrange
			var depenencyResolver = new Mock<IDependencyResolver>();
			var glassContext = Context.Create(depenencyResolver.Object);
			var sitecoreContext = new Mock<ISitecoreContext>();
			sitecoreContext.Setup(ctx => ctx.GlassContext).Returns(glassContext);

			var processor = new MockGlassValueProviderProcessor(sitecoreContext.Object, "something not null");
			var args = new ValueProviderArgs(typeof(MockGlassValueProviderProcessor));

			//Act
			processor.Process(args);

			//Assert
			Assert.IsNull(args.Result);
		}

		[TestMethod]
		public void GlassValueProviderProcessor_Skips_TypeConfiguration_Check_If_Disabled()
		{
			//Arrange
			var depenencyResolver = new Mock<IDependencyResolver>();
			var glassContext = Context.Create(depenencyResolver.Object);
			var sitecoreContext = new Mock<ISitecoreContext>();
			sitecoreContext.Setup(ctx => ctx.GlassContext).Returns(glassContext);

			var processor = new MockGlassValueProviderProcessor(sitecoreContext.Object, "something not null")
			{
				DisableTypeConfigurationCheck = true
			};
			var args = new ValueProviderArgs(typeof(MockGlassValueProviderProcessor));

			//Act
			processor.Process(args);

			//Assert
			Assert.AreEqual(args.Result, "something not null");
		}
	}
}
