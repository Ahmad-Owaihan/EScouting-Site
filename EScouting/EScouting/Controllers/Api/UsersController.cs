using EScouting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EScouting.Controllers.Api
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;
        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Users
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        // GET /api/Users/1
        public ApplicationUser GetUser(string id)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return user;
        }

        // Delete /api/Users
        [HttpDelete]
        public void DeleteUsers()
        {
            var matches = _context.MatchStatsNeeded.ToList();
            var ranked = _context.RankedStats.ToList();
            var users = _context.Users.ToList();

            if (matches != null)
            {
                foreach (var match in matches)
                {
                    _context.MatchStatsNeeded.Remove(match);
                }
            }

            if (ranked != null)
            {
                foreach (var rank in ranked)
                {
                    _context.RankedStats.Remove(rank);
                }
            }

            if (users != null)
            {
                foreach (var user in users)
                {
                    _context.Users.Remove(user);
                }
            }
            _context.SaveChanges();
        }

        // Delete /api/Users/1
        [HttpDelete]
        public void DeleteUser(string id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var matches = _context.MatchStatsNeeded.Where(m => m.UserId == id).ToList();
            var ranked = _context.RankedStats.Where(r => r.UserId == id).ToList();

            if (matches != null)
            {
                foreach (var match in matches)
                {
                    _context.MatchStatsNeeded.Remove(match);
                }
            }

            if (ranked != null)
            {
                foreach (var rank in ranked)
                {
                    _context.RankedStats.Remove(rank);
                }
            }

            _context.Users.Remove(userInDb);
            _context.SaveChanges();
        }
    }
}
