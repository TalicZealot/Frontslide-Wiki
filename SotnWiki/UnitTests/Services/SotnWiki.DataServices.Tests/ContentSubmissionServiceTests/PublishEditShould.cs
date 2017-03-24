using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using System;

namespace SotnWiki.DataServices.Tests.ContentSubmissionServiceTests
{
    [TestFixture]
    public class PublishEditShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenTitleArgumentIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            string expectedExceptionMessage = "title";
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => submissionServiceUnderTest.PublishEdit(null, "", Guid.NewGuid()));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ClearThePageEditForeignKeyOfThePageContentSubmission()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var page = new Page()
            {
                Content = "page old content",
                LastEdit = null,
            };
            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageEdit = page,
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);
            mockedPageEfRepository.Setup(x => x.GetPageEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.PublishEdit("title", "new content", Guid.NewGuid());

            //Assert
            Assert.AreEqual(null, edit.PageEdit);
        }

        [Test]
        public void AddPageHistoryForeignKeyToThePageContentSubmissionPointingToTheCorrectPage()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var page = new Page()
            {
                Content = "page old content",
                LastEdit = null,
            };
            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageEdit = page,
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);
            mockedPageEfRepository.Setup(x => x.GetPageEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.PublishEdit("title", "new content", Guid.NewGuid());

            //Assert
            Assert.AreEqual(page, edit.PageHistory);
        }

        [Test]
        public void UpdateTheContentOfThePageContentSubmissionToTheInitialPageContent()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var expectedPageContent = "new content";
            var expectedEditContent = "page old content";
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };
            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageEdit = page,
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);
            mockedPageEfRepository.Setup(x => x.GetPageEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.PublishEdit("title", expectedPageContent, Guid.NewGuid());

            //Assert
            Assert.AreEqual(expectedEditContent, edit.Content);
        }

        [Test]
        public void UpdateTheContentOfThePageToTheSubmittedContent()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var expectedPageContent = "new content";
            var expectedEditContent = "page old content";
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };
            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageEdit = page,
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);
            mockedPageEfRepository.Setup(x => x.GetPageEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.PublishEdit("title", expectedPageContent, Guid.NewGuid());

            //Assert
            Assert.AreEqual(expectedPageContent, page.Content);
        }

        [Test]
        public void UpdateThePageLastEditedDate()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var expectedPageContent = "new content";
            var expectedEditContent = "page old content";
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };
            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageEdit = page,
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);
            mockedPageEfRepository.Setup(x => x.GetPageEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.PublishEdit("title", expectedPageContent, Guid.NewGuid());

            //Assert
            Assert.IsNotNull(page.LastEdit);
        }

        [Test]
        public void CallUpdateMethodOfPageEfRepository()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var expectedPageContent = "new content";
            var expectedEditContent = "page old content";
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };
            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageEdit = page,
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);
            mockedPageEfRepository.Setup(x => x.GetPageEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.PublishEdit("title", expectedPageContent, Guid.NewGuid());

            //Assert
            mockedPageEfRepository.Verify(m => m.Update(It.IsAny<Page>()), Times.Once());
        }

        [Test]
        public void CallUpdateMethodOfPageContentSubmissionRepository()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var expectedPageContent = "new content";
            var expectedEditContent = "page old content";
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };
            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageEdit = page,
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);
            mockedPageEfRepository.Setup(x => x.GetPageEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.PublishEdit("title", expectedPageContent, Guid.NewGuid());

            //Assert
            mockedPageContentSubmissionRepository.Verify(m => m.Update(It.IsAny<PageContentSubmission>()), Times.Once());
        }

        [Test]
        public void CallCommitMethodOfUnitOfWork()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var expectedPageContent = "new content";
            var expectedEditContent = "page old content";
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };
            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageEdit = page,
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);
            mockedPageEfRepository.Setup(x => x.GetPageEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.PublishEdit("title", expectedPageContent, Guid.NewGuid());

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }
    }
}
