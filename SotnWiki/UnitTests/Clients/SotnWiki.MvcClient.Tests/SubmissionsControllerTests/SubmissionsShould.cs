using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.SubmissionsControllerTests
{
    [TestFixture]
    public class SubmissionsShould
    {
        private SubmissionsController controllerUnderTest;
        private Mock<IPageService> mockedPageService;
        private Mock<IContentSubmissionService> mockedContentSubmissionService;

        [SetUp]
        public void Setup()
        {
            mockedPageService = new Mock<IPageService>();
            mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            controllerUnderTest = new SubmissionsController(mockedPageService.Object, mockedContentSubmissionService.Object);
        }

        [Test]
        public void ShouldRenderDefaultViewWithModelSubmissionsViewModel()
        {

            //Act & Assert
            controllerUnderTest.WithModelErrors().WithCallTo(c => c.Submissions())
                .ShouldRenderDefaultView()
                .WithModel<SubmissionsViewModel>();
        }
    }
}
