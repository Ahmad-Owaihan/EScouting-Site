using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class SummonerViewModel
    {
        public Summoner Summoner { get; set; }
        public List<League> League { get; set; }
        public PlayerAllMatches Matches { get; set; }
        public List<Match> MathesWithStats { get; set; }
    }
}