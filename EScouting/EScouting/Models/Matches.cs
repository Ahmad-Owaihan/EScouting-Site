using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{

    public class PlayerAllMatches
    {
        public PlayerMatch[] matches { get; set; }
        public int endIndex { get; set; }
        public int startIndex { get; set; }
        public int totalGames { get; set; }
    }

    public class PlayerMatch
    {
        public string lane { get; set; }
        public long gameId { get; set; }
        public int champion { get; set; }
        public string platformId { get; set; }
        public long timestamp { get; set; }
        public int queue { get; set; }
        public string role { get; set; }
        public int season { get; set; }
    }

}