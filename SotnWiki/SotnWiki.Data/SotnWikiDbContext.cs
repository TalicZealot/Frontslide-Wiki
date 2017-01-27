using System;
using SotnWiki.Models;
using System.Data.Entity;

namespace SotnWiki.Data
{
    public class SotnWikiDbContext : DbContext, ISotnWikiDbContext
    {
        public SotnWikiDbContext()
            :base("SotnWikiDb")
        {
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<PageType> PageTypes { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<CvsBackup> CvsBackups { get; set; }

        public DbSet<SrComBackup> SrComBackups { get; set; }
    }
}
