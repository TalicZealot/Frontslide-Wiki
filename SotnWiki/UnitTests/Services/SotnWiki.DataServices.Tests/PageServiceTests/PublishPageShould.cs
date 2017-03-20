using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class PublishPageShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenEditedContentArgumentIsNull()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
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
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
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
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
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
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
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
        public void ThrowNullReferenceExceptionWhenPageIsNotFound()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            mockedPageRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns((Page)null);
            var expectedExceptionMessage = "Page not found!";

            //Act
            var exc = Assert.Throws<NullReferenceException>(() => pageServiceUnderTest.PublishPage("aa", "aa"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallsCommitMethodOfUnitOfWork()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            mockedPageRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.PublishPage("aa", "aa");

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void CallsUpdateMethodOfPageRepository()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            mockedPageRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.PublishPage("aa", "aa");

            //Assert
            mockedPageRepository.Verify(m => m.Update(It.IsAny<Page>()), Times.Once());
        }

        [Test]
        public void UpdatePageContent()
        {
            //Arrange
            var mockedPageRepository = new Mock<IPageRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedContent = "new content";
            var page = new Page()
            {
                Content = expectedContent,
                LastEdit = null,
            };
            mockedPageRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.PublishPage(expectedContent, "aa");

            //Assert
            Assert.AreEqual(expectedContent, page.Content);
        }
    }
}
