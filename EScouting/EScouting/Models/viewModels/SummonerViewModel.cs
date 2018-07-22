using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class SummonerViewModel : HomeViewModel
    {
        public string MainRole { get; set; }
        public string SummonerName { get; set; }
        public RankedStats SoloQueue { get; set; }
        public RankedStats FlexQueue { get; set; }
        public List<MatchStatsNeeded> matches { get; set; }
        public List<Champion> Champions { get; set; }
        public float EP { get; set; }
        public string UserId { get; set; }
        public string coachId { get; set; }
        public List<ClubInvitation> Invitations { get; set; }
    }
}