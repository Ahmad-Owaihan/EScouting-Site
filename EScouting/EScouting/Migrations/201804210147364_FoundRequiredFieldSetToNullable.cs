namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoundRequiredFieldSetToNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "RegionId" });
            AlterColumn("dbo.AspNetUsers", "RegionId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "RegionId");
            AddForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Regions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "RegionId" });
            AlterColumn("dbo.AspNetUsers", "RegionId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "RegionId");
            AddForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Regions", "Id", cascadeDelete: true);
        }
    }
}
