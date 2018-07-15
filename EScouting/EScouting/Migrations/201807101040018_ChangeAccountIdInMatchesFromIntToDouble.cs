namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAccountIdInMatchesFromIntToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "currentAccountId", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "currentAccountId", c => c.Int(nullable: false));
        }
    }
}
