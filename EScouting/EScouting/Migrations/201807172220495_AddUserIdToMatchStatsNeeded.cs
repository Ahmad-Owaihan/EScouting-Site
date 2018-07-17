namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToMatchStatsNeeded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MatchStatsNeededs", "UserId", c => c.String());
            DropColumn("dbo.MatchStatsNeededs", "AccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MatchStatsNeededs", "AccountId", c => c.Long(nullable: false));
            DropColumn("dbo.MatchStatsNeededs", "UserId");
        }
    }
}
