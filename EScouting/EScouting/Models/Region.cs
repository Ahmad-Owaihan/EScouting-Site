using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EScouting.Models
{
    public class Region
    {
        [Display(Name="Region/Server")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}