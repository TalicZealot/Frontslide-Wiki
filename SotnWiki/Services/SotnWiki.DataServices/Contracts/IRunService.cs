using SotnWiki.DTOs.RunViewsDTOs;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Contracts
{
    public interface IRunService
    {
        IEnumerable<LeaderboardRunDTO> GetRunsInCategory(string categoryName);

        LeaderboardRunDTO GetWorldRecordInCategory(string categoryName);
    }
}
