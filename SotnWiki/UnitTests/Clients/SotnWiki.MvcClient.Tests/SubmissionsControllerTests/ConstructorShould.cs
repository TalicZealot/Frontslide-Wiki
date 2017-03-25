using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using System;

namespace SotnWiki.MvcClient.Tests.SubmissionsControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "pageService";
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new SubmissionsController(null, mockedContentSubmissionService.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenContentSubmissionServiceIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "contentSubmissionService";
            var mockedPageService = new Mock<IPageService>();

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new SubmissionsController(mockedPageService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            //Arrange
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var mockedPageService = new Mock<IPageService>();

            //Act
            var result = new SubmissionsController(mockedPageService.Object, mockedContentSubmissionService.Object);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
