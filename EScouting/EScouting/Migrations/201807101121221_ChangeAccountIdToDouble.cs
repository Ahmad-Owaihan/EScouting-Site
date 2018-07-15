namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAccountIdToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "accountId", c => c.Double(nullable: false));
            DropColumn("dbo.AspNetUsers", "AccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "accountId", c => c.Int(nullable: false));
        }
    }
}
