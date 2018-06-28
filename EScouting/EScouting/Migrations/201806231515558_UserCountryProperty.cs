namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCountryProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CountryId");
            AddForeignKey("dbo.AspNetUsers", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CountryId", "dbo.Countries");
            DropIndex("dbo.AspNetUsers", new[] { "CountryId" });
            DropColumn("dbo.AspNetUsers", "CountryId");
        }
    }
}
