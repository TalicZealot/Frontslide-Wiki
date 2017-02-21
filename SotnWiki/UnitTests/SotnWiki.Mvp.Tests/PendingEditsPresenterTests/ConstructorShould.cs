using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.PendingEdits;
using System;

namespace SotnWiki.Mvp.Tests.PendingEditsPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<IPendingEditsView>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new PendingEditsPresenter(mockedView.Object, null, mockedContentSubmissionService.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenContentSubmissionServiceIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IContentSubmissionService";
            var mockedView = new Mock<IPendingEditsView>();
            var mockedPageService = new Mock<IPageService>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new PendingEditsPresenter(mockedView.Object, mockedPageService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
