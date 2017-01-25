using System.Collections.Generic;

namespace SotnWiki.Data.Common
{
    public interface IRepository<T>
        where T: class
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
