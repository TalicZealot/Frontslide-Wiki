using NUnit.Framework;
using System;

namespace SotnWiki.TextManipulation.Tests.TextileConverterWithDivsTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenRunRepositoryIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IMarkupConverter";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new TextileConverterWithDivs(null);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
