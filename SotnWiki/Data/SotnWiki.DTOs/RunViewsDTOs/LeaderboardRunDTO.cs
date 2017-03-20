using System;

namespace SotnWiki.DTOs.RunViewsDTOs
{
    public class LeaderboardRunDTO
    {
        public string Runner { get; set; }

        public string Time { get; set; }

        public DateTime? Date { get; set; }

        public string Url { get; set; }

        public string Platform { get; set; }
    }
}
