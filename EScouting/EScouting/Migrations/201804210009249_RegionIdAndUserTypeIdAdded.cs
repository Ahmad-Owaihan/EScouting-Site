namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionIdAndUserTypeIdAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Region_Id", newName: "RegionId");
            RenameColumn(table: "dbo.AspNetUsers", name: "UserType_Id", newName: "UserTypeId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_UserType_Id", newName: "IX_UserTypeId");
            AlterColumn("dbo.AspNetUsers", "RegionId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "RegionId");
            AddForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Regions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "RegionId" });
            AlterColumn("dbo.AspNetUsers", "RegionId", c => c.Int());
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_UserTypeId", newName: "IX_UserType_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "UserTypeId", newName: "UserType_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "RegionId", newName: "Region_Id");
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id");
        }
    }
}
