using Moq;
using NUnit.Framework;
using SotnWiki.Mvp.NewPage;
using System;

namespace SotnWiki.Mvp.Tests.NewPagePresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<INewPageView>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new NewPagePresenter(mockedView.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
