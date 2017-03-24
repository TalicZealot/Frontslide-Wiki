using Moq;
using NUnit.Framework;
using SotnWiki.TextManipulation.Contracts;
using System;

namespace SotnWiki.TextManipulation.Tests.TextileConverterWithDivsTests
{
    [TestFixture]
    public class ScriptToHtmlShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenContextIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "script";
            var mockedBaseConverter = new Mock<IMarkupConverter>();
            var converterUnderTest = new TextileConverterWithDivs(mockedBaseConverter.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => converterUnderTest.ScriptToHtml(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentException_WhenContextIsEmptyString()
        {
            //Arrange
            string expectedExceptionMessage = "script";
            var mockedBaseConverter = new Mock<IMarkupConverter>();
            var converterUnderTest = new TextileConverterWithDivs(mockedBaseConverter.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentException>(() => converterUnderTest.ScriptToHtml(""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CorrectlyTranslateDivs()
        {
            //Arrange
            var mockedBaseConverter = new Mock<IMarkupConverter>();
            var converterUnderTest = new TextileConverterWithDivs(mockedBaseConverter.Object);
            mockedBaseConverter.Setup(c => c.ScriptToHtml(It.IsAny<string>())).Returns<string>(x => x);
            string markup =
                @"div.
Voodoo
enddiv.
";
            //Act
            string result = converterUnderTest.ScriptToHtml(markup);

            //Assert
            StringAssert.Contains("<div>", result);
            StringAssert.Contains("Voodoo", result);
            StringAssert.Contains("</div>", result);
        }

        [Test]
        public void CorrectlyTranslateDivsWithClass()
        {
            //Arrange
            var mockedBaseConverter = new Mock<IMarkupConverter>();
            var converterUnderTest = new TextileConverterWithDivs(mockedBaseConverter.Object);
            mockedBaseConverter.Setup(c => c.ScriptToHtml(It.IsAny<string>())).Returns<string>(x => x);
            string markup =
                @"div(classydiv).
Voodoo
enddiv.
";

            //Act
            string result = converterUnderTest.ScriptToHtml(markup);

            //Assert
            StringAssert.Contains("<div class=\"classydiv\">", result);
            StringAssert.Contains("Voodoo", result);
            StringAssert.Contains("</div>", result);
        }

        [Test]
        public void CallScriptToHtmlMethodOfBaseClass()
        {
            //Arrange
            var mockedBaseConverter = new Mock<IMarkupConverter>();
            var converterUnderTest = new TextileConverterWithDivs(mockedBaseConverter.Object);
            mockedBaseConverter.Setup(c => c.ScriptToHtml(It.IsAny<string>())).Returns<string>(x => x);

            //Act
            string result = converterUnderTest.ScriptToHtml("helllo?");

            //Assert
            mockedBaseConverter.Verify(m => m.ScriptToHtml("helllo?"), Times.Once());
        }
    }
}
