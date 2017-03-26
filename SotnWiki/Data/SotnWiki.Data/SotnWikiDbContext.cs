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

        public bool SetAdded(object entity)
        {
            var entry = this.Entry(entity);
            if (entry.State != EntityState.Added)
            {
                entry.State = EntityState.Added;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetDeleted(object entity)
        {
            var entry = this.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetModified(object entity)
        {
            var entry = this.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Modified;
                return true;
            }
            else
            {
                return false;
            }
        }

        public IDbSet<Character> Characters { get; set; }

        public IDbSet<Page> Pages { get; set; }

        public IDbSet<PageContentSubmission> PageContentSubmissions { get; set; }

        public IDbSet<Run> Runs { get; set; }
    }
}
