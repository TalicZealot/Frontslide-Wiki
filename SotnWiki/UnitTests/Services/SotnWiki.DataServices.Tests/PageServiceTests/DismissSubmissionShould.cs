using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.Models;
using System;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class DismissSubmissionShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenTitleIsNull()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.DismissSubmission(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentException_WhenTitleIsEmpty()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.DismissSubmission(""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowNullReferenceException_WhenPageIsNotFound()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "Page not found!";
            mockedPageEfRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns((Page)null);

            //Act
            var exc = Assert.Throws<NullReferenceException>(() => pageServiceUnderTest.DismissSubmission("aa"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallsCommitMethodOfUnitOfWork()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var page = new Page()
            {
                Content = "iii",
                LastEdit = null,
            };
            mockedPageEfRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.DismissSubmission("aa");

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void CallsDeleteMethodOfPageEfRepository()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var page = new Page()
            {
                Content = "iii",
                LastEdit = null,
            };
            mockedPageEfRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.DismissSubmission("aa");

            //Assert
            mockedPageEfRepository.Verify(m => m.Delete(It.IsAny<Page>()), Times.Once());
        }
    }
}
