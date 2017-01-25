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

        public DbSet<Page> Pages { get; set; }

        public DbSet<Submit> Submits { get; set; }

        public DbSet<CvsBackup> CvsBackups { get; set; }

        public DbSet<SrComBackup> SrComBackups { get; set; }
    }
}
