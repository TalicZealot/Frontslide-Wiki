using Bytes2you.Validation;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices
{
    public class RunService : IRunService
    {
        private readonly IRunRepository runRepository;
        private readonly Func<IUnitOfWork> unitOfWorkFactory;

        public RunService(IRunRepository runRepository, Func<IUnitOfWork> unitOfWorkFactory)
        {
            Guard.WhenArgument(runRepository, nameof(IRunRepository)).IsNull().Throw();
            Guard.WhenArgument(unitOfWorkFactory, nameof(Func<IUnitOfWork>)).IsNull().Throw();

            this.runRepository = runRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<Run> GetRunsInCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();

            return this.runRepository.GetRunsInCategory(categoryName);
        }

        public Run GetWorldRecordInCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();

            return this.runRepository.GetWorldRecordInCategory(categoryName);
        }

        public IEnumerable<Run> GetCvsRuns()
        {
            return this.runRepository.GetCvsRuns();
        }

        public IEnumerable<Run> GetSrComRuns()
        {
            return this.runRepository.GetSrComRuns();
        }
    }
}
