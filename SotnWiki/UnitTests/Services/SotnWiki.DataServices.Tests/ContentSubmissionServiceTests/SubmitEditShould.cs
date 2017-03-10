﻿using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using System;
using SotnWiki.Data.Common;
using SotnWiki.Models;
using System.Collections.Generic;
using SotnWiki.Data.Common.Contracts;

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
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "title";
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => submissionServiceUnderTest.SubmitEdit("", null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenTitleArgumentIsEmptyString()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "title";
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);

            //Act
            var exc = Assert.Throws<ArgumentException>(() => submissionServiceUnderTest.SubmitEdit("", ""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowNullReferenceExceptionWhenPageIsNotFound()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            var edits = new List<PageContentSubmission>();
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            mockedPageContentSubmissionRepository.Setup(x => x.Add(It.IsAny<PageContentSubmission>())).Callback<PageContentSubmission>(
                x => {
                    edits.Add(x);
                });
            string expectedContent = "test content";
            var expectedExceptionMessage = "Page not found!";

            //Act
            var exc = Assert.Throws<NullReferenceException>(() => submissionServiceUnderTest.SubmitEdit(expectedContent, "test_title"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallCommitMethodOfUnitOfWork()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            var edits = new List<PageContentSubmission>();
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            mockedPageContentSubmissionRepository.Setup(x => x.Add(It.IsAny<PageContentSubmission>())).Callback<PageContentSubmission>(
                x => {
                    edits.Add(x);
                });
            string expectedContent = "test content";
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            mockedPageService.Setup(r => r.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.SubmitEdit(expectedContent, "test_title");
            var edit = edits[0];

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void AddPageContentSubmissionToRepositoryWithCorrectContent()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            var edits = new List<PageContentSubmission>();
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            mockedPageContentSubmissionRepository.Setup(x => x.Add(It.IsAny<PageContentSubmission>())).Callback<PageContentSubmission>(
                x => {
                    edits.Add(x);
                });
            string expectedContent = "test content";
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            mockedPageService.Setup(r => r.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            submissionServiceUnderTest.SubmitEdit(expectedContent, "test_title");
            var edit = edits[0];

            //Assert
            Assert.AreEqual(expectedContent, edit.Content);
        }
    }
}
