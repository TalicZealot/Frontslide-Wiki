using Bytes2you.Validation;
using System;
using System.Data.Entity;

namespace SotnWiki.Data
{
    public class EfRepository<T> where T : class
    {
        private readonly ISotnWikiDbContext context;
        private readonly IDbSet<T> dbSet;

        public EfRepository(ISotnWikiDbContext context)
        {
            Guard.WhenArgument(context, nameof(ISotnWikiDbContext)).IsNull().Throw();
            this.context = context;
            this.dbSet = this.context.Set<T>();

            if (this.dbSet == null)
            {
                throw new ArgumentException("DbContext does not contain DbSet<{0}>", typeof(T).Name);
            }
        }

        protected IDbSet<T> DbSet
        {
            get
            {
                return this.dbSet;
            }
        }

        public void Add(T entity)
        {
            Guard.WhenArgument(entity, "entity").IsNull().Throw();
            var entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            Guard.WhenArgument(entity, "entity").IsNull().Throw();
            var entry = this.context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entity);
                this.dbSet.Remove(entity);
            }
        }

        public T GetById(object id)
        {
            Guard.WhenArgument(id, "id").IsNull().Throw();
            return this.dbSet.Find(id);
        }

        public void Update(T entity)
        {
            Guard.WhenArgument(entity, "entity").IsNull().Throw();
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }
    }
}
