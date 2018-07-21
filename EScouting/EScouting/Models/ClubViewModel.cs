using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class ClubViewModel
    {
        public string Name { get; set; }
        public bool HasClub { get; set; }
        public List<ApplicationUser> Members { get; set; }
    }
}