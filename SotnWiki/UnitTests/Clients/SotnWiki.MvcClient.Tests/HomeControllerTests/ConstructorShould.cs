using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.TextManipulation.Contracts;
using System;

namespace SotnWiki.MvcClient.Tests.HomeControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedConverter = new Mock<IMarkupConverter>();

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new HomeController(null, mockedConverter.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenMarkupConverterIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IMarkupConverter";
            var mockedPageService = new Mock<IPageService>();

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new HomeController(mockedPageService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
