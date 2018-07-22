using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class HomeViewModel
    {
        private ApplicationDbContext _context;
        public HomeViewModel()
        {
            _context = new ApplicationDbContext();
            Users = _context.Users.ToList();
            Invitations = _context.ClubInvitations.ToList();
        }

        public List<ApplicationUser> Users { get; set; }
        public List<ClubInvitation> Invitations { get; set; }

    }
}