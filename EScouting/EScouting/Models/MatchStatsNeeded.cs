using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class MatchStatsNeeded
    {
        public int Id { get; set; }
        public long MatchId { get; set; }
        public string UserId { get; set; }
        public int ChampionId { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int TotalMinionsKilled { get; set; }
        public int VisionScore { get; set; }
    }
}