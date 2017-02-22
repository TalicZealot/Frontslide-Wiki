using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Models;
using System;
using System.Linq.Expressions;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class GetPageByTitleShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenTitleArgumentIsNull()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.GetPageByTitle(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenTitleArgumentIsEmpty()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.GetPageByTitle(""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallGetAllMethodOfPageRepository()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedEditContent = "page old content";
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };

            //Act
            pageServiceUnderTest.GetPageByTitle("title");

            //Assert
            mockedPageRepository.Verify(m => m.GetAll(It.IsAny<Expression<Func<Page, bool>>>()), Times.Once());
        }
    }
}
