namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoleIdFromStringToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.Roles");
            DropIndex("dbo.AspNetUsers", new[] { "Role_Id" });
            DropColumn("dbo.AspNetUsers", "RoleId");
            RenameColumn(table: "dbo.AspNetUsers", name: "Role_Id", newName: "RoleId");
            AlterColumn("dbo.AspNetUsers", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "RoleId");
            AddForeignKey("dbo.AspNetUsers", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RoleId", "dbo.Roles");
            DropIndex("dbo.AspNetUsers", new[] { "RoleId" });
            AlterColumn("dbo.AspNetUsers", "RoleId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "RoleId", c => c.String());
            RenameColumn(table: "dbo.AspNetUsers", name: "RoleId", newName: "Role_Id");
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.String());
            CreateIndex("dbo.AspNetUsers", "Role_Id");
            AddForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
