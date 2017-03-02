using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.NewPage;
using SotnWiki.Mvp.Page;
using SotnWiki.TextManipulation.Contracts;
using System;

namespace SotnWiki.Mvp.Tests.PagePresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<IPageView>();
            var mockedConverter = new Mock<IMarkupConverter>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new PagePresenter(mockedView.Object, null, mockedConverter.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenMarkupConverterIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IMarkupConverter";
            var mockedView = new Mock<IPageView>();
            var mockedPageService = new Mock<IPageService>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new PagePresenter(mockedView.Object, mockedPageService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
