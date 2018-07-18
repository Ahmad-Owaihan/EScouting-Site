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
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                return HttpNotFound();

            var soloQueue = _context.RankedStats.SingleOrDefault(r => r.UserId == id && r.QueueType == "RANKED_SOLO_5x5");
            var flexQueue = _context.RankedStats.SingleOrDefault(r => r.UserId == id && r.QueueType == "RANKED_FLEX_SR");


            var matches = _context.MatchStatsNeeded.Where(m => m.UserId == id).ToList();

            var mainRole = _context.Roles.SingleOrDefault(r => r.Id == user.RoleId);

            var champions = _context.Champions.ToList();

            //view model
            var viewModel = new SummonerViewModel()
            {
                SummonerName = user.SummonerName,
                SoloQueue = soloQueue,
                FlexQueue = flexQueue,
                matches = matches,
                MainRole = mainRole.Name,
                Champions = champions
            };

            return View(viewModel);
        }
    }
}