using SotnWiki.DTOs.RunViewsDTOs;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Contracts
{
    public interface IRunRepository
    {
        IEnumerable<LeaderboardRunDTO> GetRunsInCategory(string categoryName);

        LeaderboardRunDTO GetWorldRecordInCategory(string categoryName);
    }
}
