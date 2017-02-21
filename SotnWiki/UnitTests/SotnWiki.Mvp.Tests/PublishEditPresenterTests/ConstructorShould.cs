using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.PublishEdit;
using System;

namespace SotnWiki.Mvp.Tests.PublishEditPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<IPublishEditView>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new PublishEditPresenter(mockedView.Object, null, mockedContentSubmissionService.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenContentSubmissionServiceIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IContentSubmissionService";
            var mockedView = new Mock<IPublishEditView>();
            var mockedPageService = new Mock<IPageService>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new PublishEditPresenter(mockedView.Object, mockedPageService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
