using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class GetSubmissionsShould
    {
        [Test]
        public void CallGetSubmissionsMethodOfPageRepository()
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
            pageServiceUnderTest.GetSubmissions();

            //Assert
            mockedPageRepository.Verify(m => m.GetSubmissions(), Times.Once());
        }
    }
}
