﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class ClubViewModel : HomeViewModel
    {
        public string CoachName { get; set; }
        public string CoachId { get; set; }
        public Club Club { get; set; }
        public bool HasClub { get; set; }
        public List<ApplicationUser> Members { get; set; }
        public string UserId { get; set; }
        public int ClubId { get; set; }
    }
}