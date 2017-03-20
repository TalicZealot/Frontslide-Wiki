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
    public class GetPageContentSubmissionByIdShould
    {
        [Test]
        public void CallGetByIdMethodOfPageContentSubmissionRepository()
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

            //Act
            submissionServiceUnderTest.GetPageContentSubmissionById(Guid.NewGuid());

            //Assert
            mockedPageContentSubmissionRepository.Verify(m => m.GetByIdProjected(It.IsAny<Guid>()), Times.Once());
        }
    }
}
