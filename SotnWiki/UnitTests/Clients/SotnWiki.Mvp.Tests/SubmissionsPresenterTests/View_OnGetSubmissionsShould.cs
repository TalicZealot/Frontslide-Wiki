using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.Submissions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.Mvp.Tests.SubmissionsPresenterTests
{
    [TestFixture]
    public class View_OnGetSubmissionsShould
    {
        [Test]
        public void CallGetSubmissionsMethodOfPageService()
        {
            //Arrange
            var mockedView = new Mock<ISubmissionsView>();
            mockedView.Setup(v => v.Model).Returns(new SubmissionsViewModel());
            var mockedPageService = new Mock<IPageService>();
            var presenterUnderTest = new SubmissionsPresenter(mockedView.Object, mockedPageService.Object);
            var pages = new List<SotnWiki.Models.Page>()
            {
                new Models.Page() { Title = "t1"},
                new Models.Page() { Title = "t2"}
            };
            mockedPageService.Setup(m => m.FindPages(It.IsAny<string>())).Returns(pages);
            //Act

            mockedView.Raise(v => v.OnGetSubmissions += null, new EventArgs());
            //Assert

            mockedPageService.Verify(x => x.GetSubmissions(), Times.Once);
        }

        [Test]
        public void FillViewModelResultsWithCorrectData()
        {
            //Arrange
            var mockedView = new Mock<ISubmissionsView>();
            mockedView.Setup(v => v.Model).Returns(new SubmissionsViewModel());
            var mockedPageService = new Mock<IPageService>();
            var presenterUnderTest = new SubmissionsPresenter(mockedView.Object, mockedPageService.Object);
            var pages = new List<SotnWiki.Models.Page>()
            {
                new Models.Page() { Title = "t1"},
                new Models.Page() { Title = "t2"}
            };
            mockedPageService.Setup(m => m.GetSubmissions()).Returns(pages);
            //Act

            mockedView.Raise(v => v.OnGetSubmissions += null, new EventArgs());
            //Assert

            CollectionAssert.AreEquivalent(pages.AsQueryable(), mockedView.Object.Model.Results);
        }
    }
}
