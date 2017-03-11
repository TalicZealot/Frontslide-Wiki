using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.MvcClient.Models
{
    public class LeaderboardViewModel
    {
        public List<Run> AlucardAnyNSC { get; set; }

        public List<Run> AlucardAllBosses { get; set; }

        public List<Run> RichterAny { get; set; }

        public List<Run> RichterAllBosses { get; set; }

        public List<Run> MariaAny { get; set; }

        public List<Run> MariaAllBosses { get; set; }
    }
}