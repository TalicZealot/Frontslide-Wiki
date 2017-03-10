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
    public class DismissEditShould
    {
        [Test]
        public void CallCommitMethodOfUnitOfWork()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);

            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);

            //Act
            submissionServiceUnderTest.DismissEdit(Guid.NewGuid());

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void CallDeleteMethodOfThePageContentSubmissionRepository()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);

            var edit = new PageContentSubmission()
            {
                Content = "edit old content",
                PageHistory = null
            };

            mockedPageContentSubmissionRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(edit);

            //Act
            submissionServiceUnderTest.DismissEdit(Guid.NewGuid());

            //Assert
            mockedPageContentSubmissionRepository.Verify(m => m.Delete(It.IsAny<PageContentSubmission>()), Times.Once());
        }
    }
}
