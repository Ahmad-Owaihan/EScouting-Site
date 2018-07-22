using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class ClubInvitation
    {
        public int Id { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
    }
}