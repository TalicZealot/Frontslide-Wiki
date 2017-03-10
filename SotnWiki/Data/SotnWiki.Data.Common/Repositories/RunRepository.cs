using Bytes2you.Validation;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.Data.Common.Repositories
{
    public class RunRepository : EfGenericRepository<Run>, IRunRepository
    {
        public RunRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Run> GetRunsInCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => string.Equals(x.Category, categoryName)).ToList();
        }

        public Run GetWorldRecordInCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => string.Equals(x.Category, categoryName)).OrderByDescending(r => r.Time).FirstOrDefault();
        }
    }
}
