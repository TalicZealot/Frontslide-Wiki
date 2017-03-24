using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.EditViewsDTOs;
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
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var submissionServiceUnderTest = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            var pendingEdits = new List<EditsViewDTO>();
            var edit1 = new EditsViewDTO()
            {
                Content = "edit1"
            };
            var edit2 = new EditsViewDTO()
            {
                Content = "edit2"
            };
            pendingEdits.Add(edit1);
            pendingEdits.Add(edit2);

            mockedPageContentSubmissionRepository.Setup(x => x.GetEdits(It.IsAny<string>())).Returns(pendingEdits);

            //Act
            var result = submissionServiceUnderTest.GetEdits("tuturutka");

            //Assert
            CollectionAssert.AreEqual(pendingEdits, result);
        }
    }
}
