using System.Data.Entity.Migrations;

namespace SotnWiki.Auth.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SotnWiki.Auth.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SotnWiki.Auth.ApplicationDbContext context)
        {
        }
    }
}
