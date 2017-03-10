using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Contracts
{
    public interface IRunRepository
    {
        IEnumerable<Run> GetRunsInCategory(string categoryName);

        Run GetWorldRecordInCategory(string categoryName);

        IEnumerable<Run> GetCvsRuns();

        IEnumerable<Run> GetSrComRuns();
    }
}
