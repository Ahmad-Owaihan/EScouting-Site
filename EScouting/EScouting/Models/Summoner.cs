using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{

    public class Summoner
    {
        public int profileIconId { get; set; }
        public string name { get; set; }
        public int summonerLevel { get; set; }
        public long accountId { get; set; }
        public int id { get; set; }
        public long revisionDate { get; set; }
    }

}