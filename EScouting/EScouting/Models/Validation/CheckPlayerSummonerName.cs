﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EScouting.Models;

namespace EScouting.Models.Validation
{
    public class CheckPlayerSummonerName : ValidationAttribute
    {
        private ApplicationDbContext _context;
        public CheckPlayerSummonerName()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userViewModel = (RegisterViewModel)validationContext.ObjectInstance;
            var user = userViewModel.user;

            // if user selects coach then no need for summoner name
            if (user.UserTypeId == UserType.Coach)
                return ValidationResult.Success;

            //else user is a player
            if (user.SummonerName == null)
                return new ValidationResult("Please Insert your Summoner Name");

            var key = Global.Key;

            // region not selected
            if (user.RegionId == null)
                return new ValidationResult("..");

            var regionObj = _context.Regions.SingleOrDefault(r => r.Id == user.RegionId);
            var region = regionObj.Value;

            var url = "https://" + region + ".api.riotgames.com/lol/summoner/v3/summoners/by-name/" + user.SummonerName + "?api_key=" + key;

            var summoner = Global._download_serialized_json_data<Summoner>(url);

            // if region is selected but user does not exist
            if (summoner.id == 0 && user.RegionId != null)
                return new ValidationResult($"no player with the name {user.SummonerName} exists in {regionObj.Name}.");

            // if region is not selected
            if (summoner.id == 0)
                return new ValidationResult("please pick a region/server");

            //if user exists in region
            var users = _context.Users.ToList().Where(u => u.SummonerName == user.SummonerName && u.RegionId == user.RegionId);
            if (users.Count() >= 1)
                return new ValidationResult("Summoner already exists in this site.");

            // all went well
            return ValidationResult.Success;
        }
    }
}