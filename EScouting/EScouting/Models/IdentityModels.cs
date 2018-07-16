using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using EScouting.Models.Validation;
using System.Collections.Generic;

namespace EScouting.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "User Type")]
        public UserType UserType { get; set; }

        [Display(Name= "Type of User")]
        public int UserTypeId { get; set; }

        [CheckPlayerRegion]
        public Region Region { get; set; }
        
        [Display(Name="Region")]
        public int? RegionId { get; set; }

        [Display(Name="Nationality")]
        public Country Country { get; set; }

        [Display(Name="Country")]
        public int CountryId { get; set; }

        [CheckPlayerSummonerName]
        [Display(Name ="Summoner Name")]
        public string SummonerName { get; set; }

        public IEnumerable<Match> Matches { get; set; }

        public float EPoints { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<RankedStats> RankedStats { get; set; }
        public DbSet<MatchStatsNeeded> MatchStatsNeeded { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Participantidentity> ParticipantIdentities { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<Timeline> TimeLines { get; set; }
        public DbSet<Csdiffpermindeltas> Csdiffpermindeltas { get; set; }
        public DbSet<Goldpermindeltas> Goldpermindeltas { get; set; }
        public DbSet<Xpdiffpermindeltas> Xpdiffpermindeltas { get; set; }
        public DbSet<Creepspermindeltas> Creepspermindeltas { get; set; }
        public DbSet<Xppermindeltas> Xppermindeltas { get; set; }
        public DbSet<Damagetakendiffpermindeltas> Damagetakendiffpermindeltas { get; set; }
        public DbSet<Damagetakenpermindeltas> Damagetakenpermindeltas { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}