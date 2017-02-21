using Moq;
using NUnit.Framework;
using SotnWiki.TextManipulation;
using System;


namespace SotnWiki.TextManipulation.Tests.TextileConverterTests
{
    [TestFixture]
    public class ScriptToHtmlShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenContextIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "script";
            var converterUnderTest = new TextileConverter();

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => converterUnderTest.ScriptToHtml(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        /// <summary>
        /// Texstyle specific test
        /// </summary>
        [Test]
        public void TexstyleReturnValidHtml()
        {
            //Arrange
            string expectedExceptionMessage = "<h1>Voodoo</h1>\r\n";
            var converterUnderTest = new TextileConverter();

            //Act
            string result = converterUnderTest.ScriptToHtml("h1. Voodoo");

            //Assert
            Assert.AreEqual(expectedExceptionMessage, result);
        }
    }
}
