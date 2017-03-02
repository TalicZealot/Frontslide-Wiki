using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.PendingEdits;
using System;
using System.Collections.Generic;

namespace SotnWiki.Mvp.Tests.PendingEditsPresenterTests
{
    [TestFixture]
    public class View_OnGetPendingEditsShould
    {
        [Test]
        public void UpdateSubmissionsOfViewModelWithResult()
        {
            //Arrange
            var mockedView = new Mock<IPendingEditsView>();
            mockedView.Setup(v => v.Model).Returns(new PendingEditsViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var pendingEditsPresenterUnderTest = new PendingEditsPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            var result = new List<PageContentSubmission>()
            {
                new PageContentSubmission() { Id = Guid.NewGuid() },
                new PageContentSubmission() { Id = Guid.NewGuid() }
            };
            mockedContentSubmissionService.Setup(x => x.GetSubmissions(It.IsAny<string>())).Returns(result);

            //Act
            mockedView.Raise(v => v.OnGetPendingEdits += null, new PageEventArgs(""));

            //Assert
            CollectionAssert.AreEquivalent(result, mockedView.Object.Model.Results);
        }
    }
}
