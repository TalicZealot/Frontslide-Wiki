using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using System;

namespace SotnWiki.MvcClient.Tests.ApiControllerTests
{
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPageServiceIsNull()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            string expectedExceptionMessage = "IPageService";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new ApiController(null, mockedRunService.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenRunServiceIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            string expectedExceptionMessage = "IRunService";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new ApiController(mockedPageService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
