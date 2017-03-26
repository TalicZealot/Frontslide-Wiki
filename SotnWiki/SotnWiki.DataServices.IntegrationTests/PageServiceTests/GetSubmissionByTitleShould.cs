using Ninject;
using NUnit.Framework;
using SotnWiki.Data;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.Models;
using SotnWiki.MvcClient.App_Start;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices.IntegrationTests.PageServiceTests
{
    [TestFixture]
    public class GetSubmissionByTitleShould
    {
        private string defaultPageContent =
@"h1. This page is empty

There is currently no content in this page. Use the edit page button to edit and submit new content. Please adhere to the site templates.


This wiki uses TxStyle markup, for reference visit  ""https://txstyle.org/"":https://txstyle.org/.";

        private List<Character> characters = new List<Character>()
            {
                new Character () { Name = "Site", Id = 0},
                new Character () { Name = "Alucard", Id = 1}
            };

        private List<Page> pages = new List<Page>();

        private static IKernel kernel;

        [SetUp]
        public void Init()
        {
            kernel = NinjectWebCommon.CreateKernel();

            ISotnWikiDbContext dbContext = kernel.Get<ISotnWikiDbContext>();

            dbContext.Characters.Add(characters[0]);
            dbContext.Characters.Add(characters[1]);
            dbContext.SaveChanges();

            var siteEntity = dbContext.Characters.Find(0);
            var alucardEntity = dbContext.Characters.Find(1);
            pages = new List<Page>()
            {
                new Page () { Id = Guid.NewGuid(), IsPublished = false, Title = "Main Page", CreatedOn = DateTime.Now, GeneralCharacter = siteEntity , Content = defaultPageContent},
                new Page () { Id = Guid.NewGuid(), IsPublished = false, Title = "Alucard", CreatedOn = DateTime.Now, GeneralCharacter = alucardEntity , Content = defaultPageContent}
            };

            dbContext.Pages.Add(pages[0]);
            dbContext.Pages.Add(pages[1]);
            dbContext.SaveChanges();
        }

        [TearDown]
        public void Dispose()
        {
            ISotnWikiDbContext dbContext = kernel.Get<ISotnWikiDbContext>();
            dbContext.Database.ExecuteSqlCommand("DELETE FROM [Pages]");
            dbContext.Database.ExecuteSqlCommand("DELETE FROM [Characters]");
        }

        [Test]
        public void ReturnNull_WhenPageSubmissionIsNotFound()
        {
            //Arrange
            IPageService pageService = kernel.Get<IPageService>();

            //Act
            var result = pageService.GetSubmissionByTitle("asasftfd");

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ReturnCorrectProjectedPageSubmission_WhenPageSubmissionIsFound()
        {
            //Arrange
            IPageService pageService = kernel.Get<IPageService>();

            //Act
            var result = pageService.GetSubmissionByTitle("Main Page");

            //Assert
            Assert.IsInstanceOf<PageViewDTO>(result);
            Assert.AreEqual(pages[0].Id, result.Id);
        }
    }
}
