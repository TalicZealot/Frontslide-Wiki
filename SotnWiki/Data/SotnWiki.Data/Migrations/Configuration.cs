using SotnWiki.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SotnWiki.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SotnWikiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SotnWiki.Data.SotnWikiDbContext context)
        {
            IList<Character> characters = new List<Character>()
            {
                new Character () { Name = "Site"},
                new Character () { Name = "Alucard"},
                new Character () { Name = "Richter"},
                new Character () { Name = "Maria"}
            };

            context.Characters.AddOrUpdate(characters.ToArray());
        }
    }
}
