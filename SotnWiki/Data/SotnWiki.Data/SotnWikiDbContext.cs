using System;
using SotnWiki.Models;
using System.Data.Entity;

namespace SotnWiki.Data
{
    public class SotnWikiDbContext : DbContext, ISotnWikiDbContext
    {
        public SotnWikiDbContext()
            :base("DefaultConnection")
        {
        }

        public IDbSet<Character> Characters { get; set; }

        public IDbSet<Page> Pages { get; set; }

        public IDbSet<PageContentSubmission> PageContentSubmissions { get; set; }
    }
}
