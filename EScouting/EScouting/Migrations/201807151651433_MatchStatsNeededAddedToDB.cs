namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchStatsNeededAddedToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchStatsNeededs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchId = c.Long(nullable: false),
                        AccountId = c.Long(nullable: false),
                        ChampionId = c.Int(nullable: false),
                        Kills = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        TotalMinionsKilled = c.Int(nullable: false),
                        VisionScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MatchStatsNeededs");
        }
    }
}
