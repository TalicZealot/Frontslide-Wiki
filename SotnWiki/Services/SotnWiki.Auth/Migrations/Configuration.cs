using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SotnWiki.Auth.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SotnWiki.Auth.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SotnWiki.Auth.ApplicationDbContext context)
        {
            IList<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = "Admin"},
                new IdentityRole { Name = "Editor"}
            };

            context.Roles.AddOrUpdate(roles.ToArray());
        }
    }
}
