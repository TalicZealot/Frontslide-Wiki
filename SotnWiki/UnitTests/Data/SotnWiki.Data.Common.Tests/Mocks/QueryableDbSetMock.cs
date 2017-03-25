using System.Data.Entity;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System;

namespace SotnWiki.Data.Common.Tests.Mocks
{
    public class QueryableDbSetMock
    {
        public static DbSet<T> GetQueryableMockDbSet<T>(IEnumerable<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            dbSet.Setup(s => s.Find(It.IsAny<Guid>())).Returns(sourceList.FirstOrDefault());

            return dbSet.Object;
        }
    }
}
