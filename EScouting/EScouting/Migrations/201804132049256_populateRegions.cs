namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateRegions : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Regions ON");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (1, 'Russia', 'RU')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (2, 'Brazil', 'BR1')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (3, 'Europe Nordic & East', 'EUN1')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (4, 'Europe West', 'EUW1')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (5, 'Latin America North', 'LA1')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (6, 'Latin America South', 'LA2')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (7, 'North America', 'NA1')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (8, 'Oceania', 'OC1')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (9, 'Turkey', 'TR1')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (10, 'Japan', 'JP1')");
            Sql("INSERT INTO Regions (Id, Name, Value) VALUES (11, 'Korea', 'KR')");
            Sql("SET IDENTITY_INSERT Regions OFF");
        }

        public override void Down()
        {
        }
    }
}
