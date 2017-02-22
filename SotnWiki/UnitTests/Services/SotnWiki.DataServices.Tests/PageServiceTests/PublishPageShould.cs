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
    public class PublishPageShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenEditedContentArgumentIsNull()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "editedContent";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.PublishPage(null, "aa"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenEditedContentArgumentIsEmpty()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "editedContent";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.PublishPage("", "aa"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

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
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.PublishPage("aa", null));

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
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.PublishPage("aa", ""));

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
            var expectedEditContent = "page old content";
            var queryResult = new List<Page>();
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };
            queryResult.Add(page);
            mockedPageRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Page, bool>>>())).Returns(queryResult);

            //Act
            pageServiceUnderTest.PublishPage("aa", "aa");

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void CallsUpdateMethodOfPageRepository()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedEditContent = "page old content";
            var queryResult = new List<Page>();
            var page = new Page()
            {
                Content = expectedEditContent,
                LastEdit = null,
            };
            queryResult.Add(page);
            mockedPageRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Page, bool>>>())).Returns(queryResult);

            //Act
            pageServiceUnderTest.PublishPage("aa", "aa");

            //Assert
            mockedPageRepository.Verify(m => m.Update(It.IsAny<Page>()), Times.Once());
        }

        [Test]
        public void UpdatePageContent()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedContent = "new content";
            var queryResult = new List<Page>();
            var page = new Page()
            {
                Content = "old page content",
                LastEdit = null,
            };
            queryResult.Add(page);
            mockedPageRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Page, bool>>>())).Returns(queryResult);

            //Act
            pageServiceUnderTest.PublishPage(expectedContent, "aa");

            //Assert
            Assert.AreEqual(expectedContent, page.Content);
        }
    }
}
