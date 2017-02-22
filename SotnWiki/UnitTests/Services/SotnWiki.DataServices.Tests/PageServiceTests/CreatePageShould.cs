using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class CreatePageShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenCharacterNameArgumentIsNull()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "characterName";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.CreatePage(null, "aa", "aa", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenCharacterNameArgumentIsEmpty()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "characterName";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.CreatePage("", "aa", "aa", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenTypeArgumentIsNull()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "type";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.CreatePage("aa", null, "aa", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenTypeArgumentIsEmpty()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "type";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.CreatePage("aa", "", "aa", "aa", true));

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
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.CreatePage("aa", "aa", null, "aa", true));

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
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.CreatePage("aa", "aa", "", "aa", true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenContentArgumentIsNull()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "content";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.CreatePage("aa", "aa", "aa", null, true));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenContentArgumentIsEmpty()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "content";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.CreatePage("aa", "aa", "aa", "", true));

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
                Content = "aa",
                LastEdit = null,
            };
            queryResult.Add(page);

            //Act
            pageServiceUnderTest.CreatePage("aa", "aa", "aa", "aa", false);

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void CallsAddMethodOfPageRepository()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            var character = new Character()
            {
                Id = Guid.NewGuid(),
                Name = "aa"
            };
            queryPageResult.Add(page);
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(character);

            //Act
            pageServiceUnderTest.CreatePage("aa", "General", "aa", "aa", false);

            //Assert
            mockedPageRepository.Verify(m => m.Add(It.IsAny<Page>()), Times.Once());
        }

        [Test]
        public void CreatePageWithGeneralCharacterPropertyWhenTypeParameterIsGeneral()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = Guid.NewGuid(),
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(character);
            mockedPageRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));

            //Act
            pageServiceUnderTest.CreatePage("aa", "General", "aa", "aa", false);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(character, page.GeneralCharacter);
        }

        [Test]
        public void CreatePageWithCategoryCharacterPropertyWhenTypeParameterIsCategory()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = Guid.NewGuid(),
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(character);
            mockedPageRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));

            //Act
            pageServiceUnderTest.CreatePage("aa", "Category", "aa", "aa", false);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(character, page.CategoryCharacter);
        }

        [Test]
        public void CreatePageWithGlitchCharacterPropertyWhenTypeParameterIsGlitch()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = Guid.NewGuid(),
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(character);
            mockedPageRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));

            //Act
            pageServiceUnderTest.CreatePage("aa", "Glitch", "aa", "aa", false);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(character, page.GlitchCharacter);
        }

        [Test]
        public void CreatePageWithCorrectTitle()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = Guid.NewGuid(),
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(character);
            mockedPageRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));
            string characterName = "Alucard";
            string type = "Category";
            string title = "Alucard Any%";
            string content = "stuff";
            bool published = false;

            //Act
            pageServiceUnderTest.CreatePage(characterName, type, title, content, published);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(title, page.Title);
        }

        [Test]
        public void CreatePageWithCorrectContent()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = Guid.NewGuid(),
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(character);
            mockedPageRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));
            string characterName = "Alucard";
            string type = "Category";
            string title = "Alucard Any%";
            string content = "stuff";
            bool published = false;

            //Act
            pageServiceUnderTest.CreatePage(characterName, type, title, content, published);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(content, page.Content);
        }

        [Test]
        public void CreatePageWithCorrectIsPublishedValue()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var queryPageResult = new List<Page>();
            var character = new Character()
            {
                Id = Guid.NewGuid(),
                Name = "aa"
            };
            mockedCharacterRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(character);
            mockedPageRepository.Setup(x => x.Add(It.IsAny<Page>())).Callback<Page>(y => queryPageResult.Add(y));
            string characterName = "Alucard";
            string type = "Category";
            string title = "Alucard Any%";
            string content = "stuff";
            bool published = false;

            //Act
            pageServiceUnderTest.CreatePage(characterName, type, title, content, published);
            Page page = queryPageResult[0];

            //Assert
            Assert.AreEqual(published, page.IsPublished);
        }
    }
}
