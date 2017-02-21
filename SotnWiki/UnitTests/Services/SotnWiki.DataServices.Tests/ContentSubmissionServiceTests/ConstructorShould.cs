using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using System;
using SotnWiki.Data.Common;
using SotnWiki.Models;

namespace SotnWiki.DataServices.Tests.ContentSubmissionServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            var mockedPageContentSubmissionRepository = new Mock<IRepository<PageContentSubmission>>();
            var mockedPageRepository = new Mock<IRepository<Page>>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object;};
            string expectedExceptionMessage = "IPageService";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, mockedUnitOfWorkFactory, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenPageContentSubmissionRepositoryIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageRepository = new Mock<IRepository<Page>>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "IRepository";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new ContentSubmissionService(null, mockedPageRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenPageRepositoryIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IRepository<PageContentSubmission>>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "IRepository";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, null, mockedUnitOfWorkFactory, mockedPageService.Object);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenUnitOfWorkFactoryIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IRepository<PageContentSubmission>>();
            var mockedPageRepository = new Mock<IRepository<Page>>();
            string expectedExceptionMessage = "Func";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageRepository.Object, null, mockedPageService.Object);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
