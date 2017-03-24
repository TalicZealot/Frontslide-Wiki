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
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
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
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "text";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.FindPages(""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallGetPageByTitleMethodOfPageEfRepository()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            Expression<Func<Page, bool>> filter = (Page model) => !model.IsPublished;
            Expression<Func<Page, Type>> select = (Page model) => model.GetType();

            //Act
            pageServiceUnderTest.FindPages("asdasd");

            //Assert
            mockedPageEfRepository.Verify(m => m.GetPageByTitle(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CallFindPagesMethodOfPageEfRepositoryIfPageIsNotFound()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            Expression<Func<Page, bool>> filter = (Page model) => !model.IsPublished;
            Expression<Func<Page, Type>> select = (Page model) => model.GetType();

            //Act
            pageServiceUnderTest.FindPages("asdasd");

            //Assert
            mockedPageEfRepository.Verify(m => m.FindPages(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ReturnResultOfTypeIenumerableOfPageSearchDTO()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            Expression<Func<Page, bool>> filter = (Page model) => !model.IsPublished;
            Expression<Func<Page, Type>> select = (Page model) => model.GetType();

            //Act
            var result = pageServiceUnderTest.FindPages("asdasd");

            //Assert
            Assert.IsInstanceOf<IEnumerable<PageSearchDTO>>(result);
        }
    }
}
