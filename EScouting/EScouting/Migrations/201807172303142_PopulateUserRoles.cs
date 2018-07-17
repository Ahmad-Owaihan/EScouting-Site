namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Roles ON");
            Sql("INSERT INTO ROLES (Id, Name) VALUES (1, 'Mid')");
            Sql("INSERT INTO ROLES (Id, Name) VALUES (2, 'Rop')");
            Sql("INSERT INTO ROLES (Id, Name) VALUES (3, 'Jungler')");
            Sql("INSERT INTO ROLES (Id, Name) VALUES (4, 'Adc')");
            Sql("INSERT INTO ROLES (Id, Name) VALUES (5, 'Support')");
            Sql("SET IDENTITY_INSERT Roles OFF");
        }
        
        public override void Down()
        {
        }
    }
}
