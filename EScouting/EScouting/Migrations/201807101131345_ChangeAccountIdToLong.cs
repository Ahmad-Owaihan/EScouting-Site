namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAccountIdToLong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "currentAccountId", c => c.Long(nullable: false));
            AlterColumn("dbo.Players", "accountId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "accountId", c => c.Double(nullable: false));
            AlterColumn("dbo.Players", "currentAccountId", c => c.Double(nullable: false));
        }
    }
}
