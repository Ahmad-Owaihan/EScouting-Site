namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchClassCorrected : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        seasonId = c.Int(nullable: false),
                        queueId = c.Int(nullable: false),
                        gameId = c.Long(nullable: false),
                        gameVersion = c.String(),
                        platformId = c.String(),
                        gameMode = c.String(),
                        mapId = c.Int(nullable: false),
                        gameType = c.String(),
                        gameDuration = c.Int(nullable: false),
                        gameCreation = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Matches");
        }
    }
}
