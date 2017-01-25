using SotnWiki.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SotnWiki.Data.Common
{
    public class EfGenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ISotnWikiDbContext context;
        private readonly IDbSet<T> dbSet;

        public EfGenericRepository(ISotnWikiDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("DbContext canot be null!");
            }

            this.context = context;
            this.dbSet = this.context.Set<T>();

            if (this.dbSet == null)
            {
                throw new ArgumentException("DbContext does not contain DbSet<{0}>", typeof(T).Name);
            }
        }

        public void Add(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
