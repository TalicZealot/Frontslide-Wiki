using Bytes2you.Validation;
using SotnWiki.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SotnWiki.Data.Common
{
    public class EfGenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ISotnWikiDbContext context;
        private readonly IDbSet<T> dbSet;

        public EfGenericRepository(ISotnWikiDbContext context)
        {
            Guard.WhenArgument(context, nameof(ISotnWikiDbContext)).IsNull().Throw();
            this.context = context;
            this.dbSet = this.context.Set<T>();

            if (this.dbSet == null)
            {
                throw new ArgumentException("DbContext does not contain DbSet<{0}>", typeof(T).Name);
            }
        }

        public void Add(T entity)
        {
            Guard.WhenArgument(entity, "entity").IsNull().Throw();
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            Guard.WhenArgument(entity, "entity").IsNull().Throw();
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList(); 
        }

        //public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, int page, int pageSize)
        //{
        //    if (page < 0)
        //    {
        //        throw new ArgumentException("Page must be a value equal to or greater than zero.");
        //    }

        //    if (pageSize < 0)
        //    {
        //        throw new ArgumentException("Page Size must be a value equal to or greater than zero.");
        //    }

        //    if (filter == null)
        //    {
        //        throw new ArgumentNullException(nameof(filter));
        //    }

        //    return this.BuildQuery<int>(filter, page, pageSize).ToList();
        //}

        //private IQueryable<T> BuildQuery<K>(Expression<Func<T, bool>> filter, int page, int pageSize)
        //{
        //    IQueryable<T> queryToExecute = this.dbSet;

        //    if (filter != null)
        //    {
        //        queryToExecute = queryToExecute.Where(filter);
        //    }

        //    queryToExecute = queryToExecute
        //        .Skip(page * pageSize)
        //        .Take(pageSize);

        //    return queryToExecute;
        //}

        public T GetById(object id)
        {
            Guard.WhenArgument(id, "id").IsNull().Throw();
            return this.dbSet.Find(id);
        }

        public void Update(T entity)
        {
            Guard.WhenArgument(entity, "entity").IsNull().Throw();
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
