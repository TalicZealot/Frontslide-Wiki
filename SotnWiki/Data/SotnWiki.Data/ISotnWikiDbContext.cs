using SotnWiki.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SotnWiki.Data
{
    public interface ISotnWikiDbContext
    {

        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<Character> Characters { get; set; }

        IDbSet<Page> Pages { get; set; }

        IDbSet<PageContentSubmission> PageContentSubmissions { get; set; }

        IDbSet<Run> Runs { get; set; }

        Database Database { get; }

        int SaveChanges();
    }
}
