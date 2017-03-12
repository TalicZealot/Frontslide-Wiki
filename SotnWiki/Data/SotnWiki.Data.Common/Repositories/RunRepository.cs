using Bytes2you.Validation;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System;
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

            return this.DbSet.Where(x => x.Category.ToString() == categoryName).ToList();
        }

        public Run GetWorldRecordInCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => x.Category.ToString() == categoryName).OrderByDescending(r => r.Time).FirstOrDefault();
        }

        public IEnumerable<Run> GetCvsRuns()
        {
            return this.DbSet.Where(x => (int)x.Category > 9).ToList();
        }

        public IEnumerable<Run> GetSrComRuns()
        {
            return this.DbSet.Where(x => (int)x.Category < 10).ToList();
        }
    }
}
