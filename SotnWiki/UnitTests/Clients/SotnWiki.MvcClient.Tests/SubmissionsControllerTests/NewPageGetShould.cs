using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.SubmissionsControllerTests
{
    public class NewPageGetShould
    {
        [TestFixture]
        public class SearchShould
        {
            private SubmissionsController controllerUnderTest;

            [SetUp]
            public void Setup()
            {
                var mockedPageService = new Mock<IPageService>();
                var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
                controllerUnderTest = new SubmissionsController(mockedPageService.Object, mockedContentSubmissionService.Object);
            }

            [Test]
            public void ShouldRenderDefaultView()
            {
                //Act & Assert
                controllerUnderTest.WithCallTo(c => c.NewPage())
                    .ShouldRenderDefaultView();
            }
        }
    }
}
