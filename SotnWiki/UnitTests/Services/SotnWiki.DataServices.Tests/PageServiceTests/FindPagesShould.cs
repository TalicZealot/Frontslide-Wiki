using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class FindPagesShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenTextArgumentIsNull()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "text";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.FindPages(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenTextArgumentIsEmpty()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "text";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.FindPages(""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallGetPageByTitleMethodOfPageRepository()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            Expression<Func<Page, bool>> filter = (Page model) => !model.IsPublished;
            Expression<Func<Page, Type>> select = (Page model) => model.GetType();

            //Act
            pageServiceUnderTest.FindPages("asdasd");

            //Assert
            mockedPageRepository.Verify(m => m.GetPageByTitle(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CallFindPagesMethodOfPageRepositoryIfPageIsNotFound()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            Expression<Func<Page, bool>> filter = (Page model) => !model.IsPublished;
            Expression<Func<Page, Type>> select = (Page model) => model.GetType();

            //Act
            pageServiceUnderTest.FindPages("asdasd");

            //Assert
            mockedPageRepository.Verify(m => m.FindPages(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ReturnResultOfTypeIenumerableOfPageSearchDTO()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            Expression<Func<Page, bool>> filter = (Page model) => !model.IsPublished;
            Expression<Func<Page, Type>> select = (Page model) => model.GetType();

            //Act
            var result = pageServiceUnderTest.FindPages("asdasd");

            //Assert
            Assert.IsInstanceOf<IEnumerable<PageSearchDTO>>(result);
        }
    }
}
