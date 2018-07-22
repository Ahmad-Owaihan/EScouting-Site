namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClubInvitationsDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClubInvitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromId = c.String(),
                        ToId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClubInvitations");
        }
    }
}
