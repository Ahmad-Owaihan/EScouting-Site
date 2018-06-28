namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSummonerClassAndPropertiesToIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "AccountId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "SummonerName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Region_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            CreateIndex("dbo.AspNetUsers", "UserType_Id");
            AddForeignKey("dbo.AspNetUsers", "UserType_Id", "dbo.UserTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.AspNetUsers", "UserType_Id", "dbo.UserTypes");
            DropIndex("dbo.AspNetUsers", new[] { "UserType_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            AlterColumn("dbo.AspNetUsers", "Region_Id", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "SummonerName", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserType_Id");
            DropColumn("dbo.AspNetUsers", "AccountId");
            DropTable("dbo.UserTypes");
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id");
        }
    }
}
