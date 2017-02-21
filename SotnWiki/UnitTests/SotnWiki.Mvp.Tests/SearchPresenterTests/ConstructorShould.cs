using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.Search;
using System;

namespace SotnWiki.Mvp.Tests.SearchPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<ISearchView>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new SearchPresenter(mockedView.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
