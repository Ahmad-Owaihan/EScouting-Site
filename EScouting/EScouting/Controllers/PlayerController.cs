using EScouting.Models;
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
            var key = Global.Key;
            var url = "https://euw1.api.riotgames.com/lol/match/v3/matchlists/by-account/28396725" + "?api_key=" + key;

            var playerMatches = Global._download_serialized_json_data<PlayerAllMatches>(url);

            var players = _context.Users.Where(u => u.UserTypeId == UserType.Player);
            return View(players);
        }

        public ActionResult Details(string id)
        {
            var user = _context.Users.Include(u => u.Region).SingleOrDefault(u => u.Id == id);
            return View(user);
        }
    }
}