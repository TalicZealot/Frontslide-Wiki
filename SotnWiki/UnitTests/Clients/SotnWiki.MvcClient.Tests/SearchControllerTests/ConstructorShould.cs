using NUnit.Framework;
using SotnWiki.MvcClient.Controllers;
using System;

namespace SotnWiki.MvcClient.Tests.SearchControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new SearchController(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
