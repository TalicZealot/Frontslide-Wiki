using Bytes2you.Validation;
using SotnWiki.Data.Common;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using CvSpeedruns.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.DataServices
{
    public class RunService
    {
        private readonly IRepository<Run> runRepository;
        private readonly Func<IUnitOfWork> unitOfWorkFactory;

        public RunService(IRepository<Run> runRepository, Func<IUnitOfWork> unitOfWorkFactory)
        {
            Guard.WhenArgument(runRepository, nameof(IRepository<Page>)).IsNull().Throw();
            Guard.WhenArgument(unitOfWorkFactory, nameof(Func<IUnitOfWork>)).IsNull().Throw();

            this.runRepository = runRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<Run> getRunsInCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();

            return runRepository.GetAll(x => string.Equals(x.Category, categoryName), y => new {y.Runner, y.Time, y.Url, y.Platform})
               .Select(z => new Run {Runner = z.Runner, Time = z.Time, Url = z.Url, Platform = z.Platform}).ToList();
        }
    }
}
