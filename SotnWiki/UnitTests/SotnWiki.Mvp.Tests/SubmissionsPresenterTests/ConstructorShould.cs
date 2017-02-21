using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.Submissions;
using SotnWiki.TextManipulation.Contracts;
using System;

namespace SotnWiki.Mvp.Tests.SubmissionsPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<ISubmissionsView>();
            var mockedMarkupConverter = new Mock<IMarkupConverter>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new SubmissionsPresenter(mockedView.Object, null, mockedMarkupConverter.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenMarkupConverterIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IMarkupConverter";
            var mockedView = new Mock<ISubmissionsView>();
            var mockedPageService = new Mock<IPageService>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new SubmissionsPresenter(mockedView.Object, mockedPageService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
