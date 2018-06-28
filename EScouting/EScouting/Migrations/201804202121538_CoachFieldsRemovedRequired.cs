namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoachFieldsRemovedRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            AlterColumn("dbo.AspNetUsers", "SummonerName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Region_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            AlterColumn("dbo.AspNetUsers", "Region_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "SummonerName", c => c.String(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id", cascadeDelete: true);
        }
    }
}
