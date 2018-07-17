namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToRankedStats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RankedStats", "UserId", c => c.String());
            DropColumn("dbo.RankedStats", "PlayerOrTeamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RankedStats", "PlayerOrTeamId", c => c.String());
            DropColumn("dbo.RankedStats", "UserId");
        }
    }
}
