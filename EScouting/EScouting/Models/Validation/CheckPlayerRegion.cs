using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EScouting.Models;

namespace EScouting.Models.Validation
{
    public class CheckPlayerRegion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (ApplicationUser)validationContext.ObjectInstance;

            // if user selects coach then no need for summoner name
            if (user.UserTypeId == UserType.Coach)
                return ValidationResult.Success;

            if (user.RegionId == null)
                return new ValidationResult("Please Select Region/Server");

            return ValidationResult.Success;
        }
    }
}