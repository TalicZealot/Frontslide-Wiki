using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Contracts
{
    public interface IRunService
    {
        IEnumerable<Run> GetRunsInCategory(string categoryName);

        Run GetWorldRecordInCategory(string categoryName);

        IEnumerable<Run> GetCvsRuns();

        IEnumerable<Run> GetSrComRuns();
    }
}
