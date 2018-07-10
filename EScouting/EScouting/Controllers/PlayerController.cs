using EScouting.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EScouting.Controllers
{
    public class PlayerController : Controller
    {
        private ApplicationDbContext _context;
        public PlayerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Player
        public ActionResult Index()
        {
            var players = _context.Users.Where(u => u.UserTypeId == UserType.Player);



            return View(players);
        }

        public ActionResult Details(string id)
        {
            var user = _context.Users.Include(u => u.Region).SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            var key = Global.Key;
            var regionObj = _context.Regions.Single(r => r.Id == user.RegionId);
            var region = regionObj.Value;

            //use summoner name to access accountId and SummonerId
            var summonerUrl = "https://" + region + ".api.riotgames.com/lol/summoner/v3/summoners/by-name/" + user.SummonerName + "?api_key=" + key;

            var summoner = Global._download_serialized_json_data<Summoner>(summonerUrl);

            //use summonerId to get League information such as Solo queue rank and Flexed rank
            var leagueUrl = "https://" + region + ".api.riotgames.com/lol/league/v3/positions/by-summoner/" + summoner.id + "?api_key=" + key;

            var league = Global._download_serialized_json_data_array<League>(leagueUrl);

            var matchesUrl = "https://" + region + ".api.riotgames.com/lol/match/v3/matchlists/by-account/"+ summoner.accountId + "?api_key=" + key;

            var matches = Global._download_serialized_json_data<PlayerAllMatches>(matchesUrl);

            //view model
            var viewModel = new SummonerViewModel()
            {
                Summoner = summoner,
                League = league,
                Matches = matches
            };

            return View(viewModel);
        }
    }
}