namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "Value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "Value");
        }
    }
}
