using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using System;
using SotnWiki.Data.Common;
using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Tests.ContentSubmissionServiceTests
{
    [TestFixture]
    public class SubmitEditShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenTitleArgumentIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IRepository<PageContentSubmission>>();
            var mockedPageRepository = new Mock<IRepository<Page>>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "title";
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => submissionServiceUnderTest.SubmitEdit("", null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenTitleArgumentIsEmptyString()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IRepository<PageContentSubmission>>();
            var mockedPageRepository = new Mock<IRepository<Page>>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "title";
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);

            //Act
            var exc = Assert.Throws<ArgumentException>(() => submissionServiceUnderTest.SubmitEdit("", ""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void AddPageContentSubmissionToRepositoryWithCorrectContent()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IRepository<PageContentSubmission>>();
            var mockedPageRepository = new Mock<IRepository<Page>>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            var edits = new List<PageContentSubmission>();
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            mockedPageContentSubmissionRepository.Setup(x => x.Add(It.IsAny<PageContentSubmission>())).Callback<PageContentSubmission>(
                x => {
                    edits.Add(x);
                });
            string expectedContent = "test content";

            //Act
            submissionServiceUnderTest.SubmitEdit(expectedContent, "test_title");
            var edit = edits[0];

            //Assert
            Assert.AreEqual(expectedContent, edit.Content);
        }
    }
}
