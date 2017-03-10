using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SotnWiki.Data.Common
{
    public interface IEfGenericRepository<T>
        where T: class
    {
        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
