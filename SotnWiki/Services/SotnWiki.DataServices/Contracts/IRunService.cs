using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Contracts
{
    public interface IRunService
    {
        IEnumerable<Run> getRunsInCategory(string categoryName);

        Run getWorldRecordInCategory(string categoryName);
    }
}
