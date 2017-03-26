using AutoMapper;
using NUnit.Framework;
using SotnWiki.Data;
using SotnWiki.MvcClient.App_Start.AutomapperProfiles;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SotnWiki.DataServices.IntegrationTests
{
    [SetUpFixture]
    public class TestsInitializer
    {
        [OneTimeSetUp]
        public void AssemblyInit()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SotnWikiDbContext, TestDbConfiguration>());
            Mapper.Initialize(AddProfilesToAutomapperConfig);
        }

        private static void AddProfilesToAutomapperConfig(IMapperConfigurationExpression config)
        {
            config.AddProfile(new PageViewsProfile());
            config.AddProfile(new EditViewsProfile());
            config.AddProfile(new RunViewsProfile());
        }
    }

    public sealed class TestDbConfiguration : DbMigrationsConfiguration<SotnWikiDbContext>
    {
        public TestDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
