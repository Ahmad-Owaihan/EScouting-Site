using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class UserType
    {
        [Display(Name="User Type")]
        public int Id { get; set; }
        public string Name { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte Player = 1;
        public static readonly byte Coach = 2;
    }
}