using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Models;
using System;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class GetPageByIdShould
    {
        [Test]
        public void CallGetByIdMethodOfPageRepository()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var page = new Page()
            {
                Content = "page old content",
                LastEdit = null,
            };
            mockedPageRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.GetPageById(Guid.NewGuid());

            //Assert
            mockedPageRepository.Verify(m => m.GetById(It.IsAny<Guid>()), Times.Once());
        }
    }
}
