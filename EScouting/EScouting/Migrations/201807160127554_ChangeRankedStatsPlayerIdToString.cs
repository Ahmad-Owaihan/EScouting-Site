namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRankedStatsPlayerIdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RankedStats", "PlayerOrTeamId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RankedStats", "PlayerOrTeamId", c => c.Long(nullable: false));
        }
    }
}
