using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class DismissSubmissionShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenTitleIsNull()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.DismissSubmission(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenTitleIsEmpty()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.DismissSubmission(""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowNullReferenceExceptionWhenPageIsNotFound()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "Page not found!";
            var queryResult = new List<Page>();
            mockedPageRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Page, bool>>>())).Returns(queryResult);

            //Act
            var exc = Assert.Throws<NullReferenceException>(() => pageServiceUnderTest.DismissSubmission("aa"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallsCommitMethodOfUnitOfWork()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryResult = new List<Page>();
            var page = new Page()
            {
                Content = "iii",
                LastEdit = null,
            };
            queryResult.Add(page);
            mockedPageRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Page, bool>>>())).Returns(queryResult);

            //Act
            pageServiceUnderTest.DismissSubmission("aa");

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void CallsDeleteMethodOfPageRepository()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryResult = new List<Page>();
            var page = new Page()
            {
                Content = "iii",
                LastEdit = null,
            };
            queryResult.Add(page);
            mockedPageRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Page, bool>>>())).Returns(queryResult);

            //Act
            pageServiceUnderTest.DismissSubmission("aa");

            //Assert
            mockedPageRepository.Verify(m => m.Delete(It.IsAny<Page>()), Times.Once());
        }
    }
}
