using Bytes2you.Validation;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.RunViewsDTOs;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices
{
    public class RunService : IRunService
    {
        private readonly IRunRepository runRepository;
        private readonly Func<IEfUnitOfWork> unitOfWorkFactory;

        public RunService(IRunRepository runRepository, Func<IEfUnitOfWork> unitOfWorkFactory)
        {
            Guard.WhenArgument(runRepository, nameof(IRunRepository)).IsNull().Throw();
            Guard.WhenArgument(unitOfWorkFactory, "EfUnitOfWork").IsNull().Throw();

            this.runRepository = runRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<LeaderboardRunDTO> GetRunsInCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();

            return this.runRepository.GetRunsInCategory(categoryName);
        }

        public LeaderboardRunDTO GetWorldRecordInCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();

            return this.runRepository.GetWorldRecordInCategory(categoryName);
        }
    }
}
