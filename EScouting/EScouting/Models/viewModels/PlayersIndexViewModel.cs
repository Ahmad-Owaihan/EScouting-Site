using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class PlayersIndexViewModel : HomeViewModel
    {
        public List<Country> Countries { get; set; }
        public List<ApplicationUser> Players { get; set; }
        public List<Region> Regions { get; set; }
        public List<Role> Roles { get; set; }
    }
}