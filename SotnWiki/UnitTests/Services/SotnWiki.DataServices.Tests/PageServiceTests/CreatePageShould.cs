using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class CreatePageShould
    {
        [Test]
        public void ThrowArgumentOutOfRangeExceptionWhenCharacterNameArgumentIsLessThanOne()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "characterId";

            //Act
            var exc = Assert.Throws<ArgumentOutOfRangeException>(() => pageServiceUnderTest.CreatePage(0, "aa", "aa", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentOutOfRangeExceptionWhenCharacterNameArgumentIsGreaterThanFour()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "characterId";

            //Act
            var exc = Assert.Throws<ArgumentOutOfRangeException>(() => pageServiceUnderTest.CreatePage(5, "aa", "aa", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenTypeArgumentIsNull()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "type";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.CreatePage(1, null, "aa", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenTypeArgumentIsEmpty()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "type";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.CreatePage(1, "", "aa", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenTitleArgumentIsNull()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.CreatePage(1, "aa", null, "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenTitleArgumentIsEmpty()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.CreatePage(1, "aa", "", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenContentArgumentIsNull()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "content";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.CreatePage(1, "aa", "aa", null, true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenContentArgumentIsEmpty()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "content";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.CreatePage(1, "aa", "aa", "", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowNullReferenceExceptionWhenCharacterRepositoryDoesntFindCharacter()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryResult = new List<Page>();
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            queryResult.Add(page);
            mockedCharacterRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns((Character)null);
            var expectedExceptionMessage = "Character not found!";

            //Act
            var exc = Assert.Throws<NullReferenceException>(() => pageServiceUnderTest.CreatePage(1, "aa", "aa", "aa", false));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallCommitMethodOfUnitOfWork()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryResult = new List<Page>();
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            queryResult.Add(page);
            var character = new Character() { Id = 1 };
            mockedCharacterRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(character);

            //Act
            pageServiceUnderTest.CreatePage(1, "aa", "aa", "aa", false);

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void CallsAddMethodOfPageEfRepository()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            var character = new Character()
            {
                Id = 1,
                Name = "aa"
            };
            queryPageResult.Add(page);
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(character);

            //Act
            pageServiceUnderTest.CreatePage(1, "General", "aa", "aa", false);

            //Assert
            mockedPageEfRepository.Verify(m => m.Add(It.IsAny<Page>()), Times.Once());
        }

        [Test]
        public void CreatePageWithGeneralCharacterPropertyWhenTypeParameterIsGeneral()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = 1,
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(character);
            mockedPageEfRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));

            //Act
            pageServiceUnderTest.CreatePage(1, "General", "aa", "aa", false);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(character, page.GeneralCharacter);
        }

        [Test]
        public void CreatePageWithCategoryCharacterPropertyWhenTypeParameterIsCategory()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = 1,
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(character);
            mockedPageEfRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));

            //Act
            pageServiceUnderTest.CreatePage(1, "Category", "aa", "aa", false);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(character, page.CategoryCharacter);
        }

        [Test]
        public void CreatePageWithGlitchCharacterPropertyWhenTypeParameterIsGlitch()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = 1,
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(character);
            mockedPageEfRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));

            //Act
            pageServiceUnderTest.CreatePage(1, "Glitch", "aa", "aa", false);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(character, page.GlitchCharacter);
        }

        [Test]
        public void CreatePageWithCorrectTitle()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = 1,
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(character);
            mockedPageEfRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));
            string type = "Category";
            string title = "Alucard Any%";
            string content = "stuff";
            bool published = false;

            //Act
            pageServiceUnderTest.CreatePage(1, type, title, content, published);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(title, page.Title);
        }

        [Test]
        public void CreatePageWithCorrectContent()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = 1,
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(character);
            mockedPageEfRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));
            string type = "Category";
            string title = "Alucard Any%";
            string content = "stuff";
            bool published = false;

            //Act
            pageServiceUnderTest.CreatePage(1, type, title, content, published);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(content, page.Content);
        }

        [Test]
        public void CreatePageWithCorrectIsPublishedValue()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = 1,
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(character);
            mockedPageEfRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));
            string type = "Category";
            string title = "Alucard Any%";
            string content = "stuff";
            bool published = false;

            //Act
            pageServiceUnderTest.CreatePage(1, type, title, content, published);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(published, page.IsPublished);
        }
    }
}
