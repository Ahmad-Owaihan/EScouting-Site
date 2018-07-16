namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RankedStatsAddedtoDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RankedStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QueueType = c.String(),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        Rank = c.String(),
                        LeagueId = c.String(),
                        Tier = c.String(),
                        LeaguePoints = c.Int(nullable: false),
                        PlayerOrTeamId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RankedStats");
        }
    }
}
