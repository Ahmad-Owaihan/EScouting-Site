using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models.viewModels
{
    public class CoachesViewModel : HomeViewModel
    {
        public List<ApplicationUser> Coaches { get; set; }
    }
}