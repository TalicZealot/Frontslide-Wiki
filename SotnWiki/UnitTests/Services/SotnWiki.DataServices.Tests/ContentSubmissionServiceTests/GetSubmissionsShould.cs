using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Tests.ContentSubmissionServiceTests
{
    [TestFixture]
    public class GetSubmissionsShould
    {
        [Test]
        public void ReturnCorrectCollection()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IRepository<PageContentSubmission>>();
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var expectedEditContent = "page old content";
            var pendingEdits = new List<PageContentSubmission>();
            var edit1 = new PageContentSubmission()
            {
                Content = "edit1",
                PageHistory = null
            };
            var edit2 = new PageContentSubmission()
            {
                Content = "edit2",
                PageHistory = null
            };
            pendingEdits.Add(edit1);
            pendingEdits.Add(edit2);

            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
                Pending = pendingEdits
            };

            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = submissionServiceUnderTest.GetSubmissions("tuturutka");

            //Assert
            CollectionAssert.AreEqual(pendingEdits, result);
        }
    }
}
