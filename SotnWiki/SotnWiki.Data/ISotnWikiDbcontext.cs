using SotnWiki.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SotnWiki.Data
{
    public interface ISotnWikiDbContext
    {
        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Page> Pages { get; set; }

        DbSet<Submit> Submits { get; set; }

        DbSet<CvsBackup> CvsBackups { get; set; }

        DbSet<SrComBackup> SrComBackups { get; set; }

        int SaveChanges();
    }
}
