namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteLeagueTableWhichDoesNotExist : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        leagueId = c.String(nullable: false, maxLength: 128),
                        queueType = c.String(),
                        hotStreak = c.Boolean(nullable: false),
                        miniSeries_wins = c.Int(nullable: false),
                        miniSeries_losses = c.Int(nullable: false),
                        miniSeries_target = c.Int(nullable: false),
                        miniSeries_progress = c.String(),
                        wins = c.Int(nullable: false),
                        veteran = c.Boolean(nullable: false),
                        losses = c.Int(nullable: false),
                        playerOrTeamId = c.String(),
                        leagueName = c.String(),
                        playerOrTeamName = c.String(),
                        inactive = c.Boolean(nullable: false),
                        rank = c.String(),
                        freshBlood = c.Boolean(nullable: false),
                        tier = c.String(),
                        leaguePoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.leagueId);
            
        }
    }
}
