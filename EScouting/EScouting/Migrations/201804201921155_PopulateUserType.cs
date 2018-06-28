namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserType : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT UserTypes ON");
            Sql("INSERT INTO UserTypes (Id, Name) VALUES (1, 'Player')");
            Sql("INSERT INTO UserTypes (Id, Name) VALUES (2, 'Coach')");
            Sql("SET IDENTITY_INSERT UserTypes OFF");
        }

        public override void Down()
        {
        }
    }
}
