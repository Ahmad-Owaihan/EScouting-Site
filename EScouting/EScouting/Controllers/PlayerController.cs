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

            var role = _context.Roles.SingleOrDefault(x => x.Id == user.RoleId);
            //get average stats
            var list = matches.GroupBy(x => x.ChampionId).OrderByDescending(x => x.Count()).Take(5);

            //calculate EP for player
            if (user.EPoints == 0)
            {
                if (list.Count() >= 5)
                {
                    // 2 dimentional array { champ id, kills, deaths, assists, minionskilled, visionScore }
                    int[,] topArray = new int[5, 6]
                    {
                {list.ElementAt(0).Key, 0, 0, 0, 0, 0 },
                {list.ElementAt(1).Key, 0, 0, 0, 0, 0 },
                {list.ElementAt(2).Key, 0, 0, 0, 0, 0 },
                {list.ElementAt(3).Key, 0, 0, 0, 0, 0 },
                {list.ElementAt(4).Key, 0, 0, 0, 0, 0 }
                    };
                    var d = 0;
                    // iterate and increment stats
                    foreach (var champ in matches)
                    {
                        if (list.Where(x => x.Key == champ.ChampionId) != null)
                        {
                            for (var i = 0; i < topArray.GetLength(0); i++)
                            {
                                if (topArray[i, 0] == champ.ChampionId)
                                {
                                    topArray[i, 1] += champ.Kills;
                                    topArray[i, 2] += champ.Deaths;
                                    topArray[i, 3] += champ.Assists;
                                    topArray[i, 4] += champ.TotalMinionsKilled;
                                    topArray[i, 5] += champ.VisionScore;
                                }
                            }
                        }
                    }
                    // array contains average EPs {kills, assists, deaths, cs, vision }
                    float[] aStats = new float[] { 0, 0, 0, 0, 0 };
                    //create average stats
                    foreach (var item in list)
                    {
                        float aKills = (float)topArray[d, 1] / item.Count();
                        float aDeaths = (float)topArray[d, 2] / item.Count();
                        float aAssists = (float)topArray[d, 3] / item.Count();
                        float aMinionsKilled = (float)topArray[d, 4] / item.Count();
                        float aVision = (float)topArray[d, 5] / item.Count();

                        //get EP for this champ
                        var ep = Global.GetEPoints(role.Name, aKills, aAssists, aDeaths, aMinionsKilled, aVision);

                        //add it to array
                        aStats[d] = ep;
                        d++;
                    }
                    //back to 0 for next time
                    d = 0;

                    //get average EP
                    float totalEP = 0;
                    float EP;
                    for (var x = 0; x < aStats.Length; x++)
                    {
                        totalEP += aStats[x];
                    }
                    EP = totalEP / 5;
                    user.EPoints = EP;
                }
            }

            //view model
            var viewModel = new SummonerViewModel()
            {
                SummonerName = user.SummonerName,
                SoloQueue = soloQueue,
                FlexQueue = flexQueue,
                matches = matches,
                MainRole = mainRole.Name,
                Champions = champions,
                EP = user.EPoints
            };

            _context.SaveChanges();
            return View(viewModel);
        }
    }
}