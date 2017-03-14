using NUnit.Framework;
using SotnWiki.MvcClient.Controllers;
using System;

namespace SotnWiki.MvcClient.Tests.ApiControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenRunServiceIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IRunService";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new ApiController(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
