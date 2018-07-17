﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using EScouting.Models;
using System.Threading.Tasks;

namespace EScouting.Models
{
    public class Global
    {
        public static string Key = "RGAPI-5434df27-9b8f-41be-8ccd-847b0f0fd386";

        // methods

        // method used to get JSON data from the web deserialize it to  .net class             source: "https://www.codeproject.com/Tips/397574/Use-Csharp-to-get-JSON-Data-from-the-Web-and-Map-i"
        public static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        // same method but for array of JSON objects (fix for League api)
        public static List<T> _download_serialized_json_data_array<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<List<T>>(json_data) : new List<T>();
            }
        }

        // method used to get list of countries        source: "https://forums.asp.net/t/2090553.aspx?Creating+a+country+dropdown+list+"
        public static Dictionary<string, string> CountryList()
        {
            //Creating Dictionary
            Dictionary<string, string> cultureList = new Dictionary<string, string>();

            //getting the specific CultureInfo from CultureInfo class
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                //creating the object of RegionInfo class
                RegionInfo getRegionInfo = new RegionInfo(getCulture.LCID);
                //adding each country Name into the Dictionary
                if (!(cultureList.ContainsKey(getRegionInfo.Name)))
                {
                    cultureList.Add(getRegionInfo.Name, getRegionInfo.EnglishName);
                }
            }
            //returning country list
            return cultureList;
        }

        public static void AddStats(ApplicationDbContext _context, RegisterViewModel model)
        {
            var userTypeInDb = _context.UserTypes.Single(u => u.Id == model.user.UserTypeId);
            var countryInDb = _context.Countries.Single(c => c.Id == model.user.CountryId);
            var regionInDb = new Region();
            if (model.user.UserTypeId == UserType.Player)
            {
                regionInDb = _context.Regions.Single(u => u.Id == model.user.RegionId);
            }
            else
            {
                regionInDb = new Region { Id = 1 };
            }

            var key = Global.Key;
            var region = regionInDb.Value;

            //use summoner name to access accountId and SummonerId 
            var url = "https://" + region + ".api.riotgames.com/lol/summoner/v3/summoners/by-name/" + model.user.SummonerName + "?api_key=" + key;

            var summoner = Global._download_serialized_json_data<Summoner>(url);

            //use accountId to get list of matches 
            var matchesUrl = "https://" + region + ".api.riotgames.com/lol/match/v3/matchlists/by-account/" + summoner.accountId + "?api_key=" + key;

            var matches = Global._download_serialized_json_data<PlayerAllMatches>(matchesUrl);

            //use summonerId to get Solo queue rank and Flexed rank
            var leagueUrl = "https://" + region + ".api.riotgames.com/lol/league/v3/positions/by-summoner/" + summoner.id + "?api_key=" + key;

            var league = Global._download_serialized_json_data_array<League>(leagueUrl);
            foreach (var l in league)
            {
                _context.RankedStats.Add(new RankedStats()
                {
                    QueueType = l.queueType,
                    Wins = l.wins,
                    Losses = l.losses,
                    Rank = l.rank,
                    LeagueId = l.leagueId,
                    Tier = l.tier,
                    LeaguePoints = l.leaguePoints,
                    PlayerOrTeamId = l.playerOrTeamId
                });
            }


            //use matchId to get match results and stats
            if (matches.matches != null)
            {
                var li = matches.matches.ToList();

                //use Parallel for performance
                Parallel.ForEach(li, x =>
                {
                    var matchesWithStatsUrl = "https://" + region + ".api.riotgames.com/lol/match/v3/matches/" + x.gameId + "?api_key=" + key;
                    var match = Global._download_serialized_json_data<Match>(matchesWithStatsUrl);
                    if (match != null && match.participants != null)
                    {
                        //get stats I need and add it to MatchStatsNeeded
                        var participantIdentity = match.participantIdentities.SingleOrDefault(p => p.player.currentAccountId == summoner.accountId);
                        var participant = match.participants.SingleOrDefault(p => p.participantId == participantIdentity.participantId);
                        var playerStats = participant.stats;

                        var matchStats = new MatchStatsNeeded()
                        {
                            MatchId = match.gameId,
                            AccountId = summoner.accountId,
                            ChampionId = participant.championId,
                            Kills = playerStats.kills,
                            Deaths = playerStats.deaths,
                            Assists = playerStats.assists,
                            TotalMinionsKilled = playerStats.totalMinionsKilled,
                            VisionScore = playerStats.visionScore
                        };
                        try
                        {
                            _context.MatchStatsNeeded.Add(matchStats);
                        }
                        catch (Exception) { }
                    }
                });
                _context.SaveChanges();
            }
        }
    }
}