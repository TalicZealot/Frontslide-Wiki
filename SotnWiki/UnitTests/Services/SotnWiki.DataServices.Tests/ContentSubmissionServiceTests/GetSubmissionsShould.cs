using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
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
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
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

            mockedPageContentSubmissionRepository.Setup(x => x.GetSubmissions(It.IsAny<string>())).Returns(pendingEdits);

            //Act
            var result = submissionServiceUnderTest.GetSubmissions("tuturutka");

            //Assert
            CollectionAssert.AreEqual(pendingEdits, result);
        }
    }
}
