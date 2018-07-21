using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> Members { get; set; }
    }
}