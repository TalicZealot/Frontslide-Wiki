using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.Default;
using SotnWiki.TextManipulation.Contracts;
using System;

namespace SotnWiki.Mvp.Tests.DefaultPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<IDefaultView>();
            var mockedConverter = new Mock<IMarkupConverter>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new DefaultPresenter(mockedView.Object, null, mockedConverter.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenMarkupConverterIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IMarkupConverter";
            var mockedView = new Mock<IDefaultView>();
            var mockedPageService = new Mock<IPageService>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new DefaultPresenter(mockedView.Object, mockedPageService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
