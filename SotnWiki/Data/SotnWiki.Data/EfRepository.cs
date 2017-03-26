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

            var result = this.context.SetAdded(entity);
            if(!result)
            {
                this.dbSet.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            Guard.WhenArgument(entity, "entity").IsNull().Throw();

            var result = this.context.SetDeleted(entity);
            if (!result)
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

            var result = this.context.SetModified(entity);
            if (!result)
            {
                this.dbSet.Attach(entity);
                this.context.SetModified(entity);
            }
        }
    }
}
