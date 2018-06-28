namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionsClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "SummonerName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Region_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            DropColumn("dbo.AspNetUsers", "Region_Id");
            DropColumn("dbo.AspNetUsers", "SummonerName");
            DropTable("dbo.Regions");
        }
    }
}
