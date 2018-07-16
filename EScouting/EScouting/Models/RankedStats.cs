using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class RankedStats
    {
        public int Id { get; set; }
        public string QueueType { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Rank { get; set; }
        public string LeagueId { get; set; }
        public string Tier { get; set; }
        public int LeaguePoints { get; set; }
        public string PlayerOrTeamId { get; set; }
    }
}