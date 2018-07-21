namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClubsToDBAndRemoveUneccessaryTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Participantidentities", "player_Id", "dbo.Players");
            DropForeignKey("dbo.Participants", "stats_Id", "dbo.Stats");
            DropForeignKey("dbo.Timelines", "creepsPerMinDeltas_Id", "dbo.Creepspermindeltas");
            DropForeignKey("dbo.Timelines", "csDiffPerMinDeltas_Id", "dbo.Csdiffpermindeltas");
            DropForeignKey("dbo.Timelines", "damageTakenDiffPerMinDeltas_Id", "dbo.Damagetakendiffpermindeltas");
            DropForeignKey("dbo.Timelines", "damageTakenPerMinDeltas_Id", "dbo.Damagetakenpermindeltas");
            DropForeignKey("dbo.Timelines", "goldPerMinDeltas_Id", "dbo.Goldpermindeltas");
            DropForeignKey("dbo.Timelines", "xpDiffPerMinDeltas_Id", "dbo.Xpdiffpermindeltas");
            DropForeignKey("dbo.Timelines", "xpPerMinDeltas_Id", "dbo.Xppermindeltas");
            DropForeignKey("dbo.Participants", "timeline_Id", "dbo.Timelines");
            DropIndex("dbo.Participantidentities", new[] { "player_Id" });
            DropIndex("dbo.Participants", new[] { "stats_Id" });
            DropIndex("dbo.Participants", new[] { "timeline_Id" });
            DropIndex("dbo.Timelines", new[] { "creepsPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "csDiffPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "damageTakenDiffPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "damageTakenPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "goldPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "xpDiffPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "xpPerMinDeltas_Id" });
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Club_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Club_Id");
            AddForeignKey("dbo.AspNetUsers", "Club_Id", "dbo.Clubs", "Id");
            DropTable("dbo.Bans");
            DropTable("dbo.Creepspermindeltas");
            DropTable("dbo.Csdiffpermindeltas");
            DropTable("dbo.Damagetakendiffpermindeltas");
            DropTable("dbo.Damagetakenpermindeltas");
            DropTable("dbo.Goldpermindeltas");
            DropTable("dbo.Participantidentities");
            DropTable("dbo.Players");
            DropTable("dbo.Participants");
            DropTable("dbo.Stats");
            DropTable("dbo.Timelines");
            DropTable("dbo.Xpdiffpermindeltas");
            DropTable("dbo.Xppermindeltas");
            DropTable("dbo.Teams");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstDragon = c.Boolean(nullable: false),
                        firstInhibitor = c.Boolean(nullable: false),
                        win = c.String(),
                        firstRiftHerald = c.Boolean(nullable: false),
                        firstBaron = c.Boolean(nullable: false),
                        baronKills = c.Int(nullable: false),
                        riftHeraldKills = c.Int(nullable: false),
                        firstBlood = c.Boolean(nullable: false),
                        teamId = c.Int(nullable: false),
                        firstTower = c.Boolean(nullable: false),
                        vilemawKills = c.Int(nullable: false),
                        inhibitorKills = c.Int(nullable: false),
                        towerKills = c.Int(nullable: false),
                        dominionVictoryScore = c.Int(nullable: false),
                        dragonKills = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Xppermindeltas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _30end = c.Single(nullable: false),
                        _2030 = c.Single(nullable: false),
                        _010 = c.Single(nullable: false),
                        _1020 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Xpdiffpermindeltas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _30end = c.Single(nullable: false),
                        _2030 = c.Single(nullable: false),
                        _010 = c.Single(nullable: false),
                        _1020 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Timelines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        lane = c.String(),
                        participantId = c.Int(nullable: false),
                        role = c.String(),
                        creepsPerMinDeltas_Id = c.Int(),
                        csDiffPerMinDeltas_Id = c.Int(),
                        damageTakenDiffPerMinDeltas_Id = c.Int(),
                        damageTakenPerMinDeltas_Id = c.Int(),
                        goldPerMinDeltas_Id = c.Int(),
                        xpDiffPerMinDeltas_Id = c.Int(),
                        xpPerMinDeltas_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        neutralMinionsKilledTeamJungle = c.Int(nullable: false),
                        visionScore = c.Int(nullable: false),
                        magicDamageDealtToChampions = c.Int(nullable: false),
                        largestMultiKill = c.Int(nullable: false),
                        totalTimeCrowdControlDealt = c.Int(nullable: false),
                        longestTimeSpentLiving = c.Int(nullable: false),
                        perk1Var1 = c.Int(nullable: false),
                        perk1Var3 = c.Int(nullable: false),
                        perk1Var2 = c.Int(nullable: false),
                        tripleKills = c.Int(nullable: false),
                        perk5 = c.Int(nullable: false),
                        perk4 = c.Int(nullable: false),
                        playerScore9 = c.Int(nullable: false),
                        playerScore8 = c.Int(nullable: false),
                        kills = c.Int(nullable: false),
                        playerScore1 = c.Int(nullable: false),
                        playerScore0 = c.Int(nullable: false),
                        playerScore3 = c.Int(nullable: false),
                        playerScore2 = c.Int(nullable: false),
                        playerScore5 = c.Int(nullable: false),
                        playerScore4 = c.Int(nullable: false),
                        playerScore7 = c.Int(nullable: false),
                        playerScore6 = c.Int(nullable: false),
                        perk5Var1 = c.Int(nullable: false),
                        perk5Var3 = c.Int(nullable: false),
                        perk5Var2 = c.Int(nullable: false),
                        totalScoreRank = c.Int(nullable: false),
                        neutralMinionsKilled = c.Int(nullable: false),
                        damageDealtToTurrets = c.Int(nullable: false),
                        physicalDamageDealtToChampions = c.Int(nullable: false),
                        damageDealtToObjectives = c.Int(nullable: false),
                        perk2Var2 = c.Int(nullable: false),
                        perk2Var3 = c.Int(nullable: false),
                        totalUnitsHealed = c.Int(nullable: false),
                        perk2Var1 = c.Int(nullable: false),
                        perk4Var1 = c.Int(nullable: false),
                        totalDamageTaken = c.Int(nullable: false),
                        perk4Var3 = c.Int(nullable: false),
                        wardsKilled = c.Int(nullable: false),
                        largestCriticalStrike = c.Int(nullable: false),
                        largestKillingSpree = c.Int(nullable: false),
                        quadraKills = c.Int(nullable: false),
                        magicDamageDealt = c.Int(nullable: false),
                        firstBloodAssist = c.Boolean(nullable: false),
                        item2 = c.Int(nullable: false),
                        item3 = c.Int(nullable: false),
                        item0 = c.Int(nullable: false),
                        item1 = c.Int(nullable: false),
                        item6 = c.Int(nullable: false),
                        item4 = c.Int(nullable: false),
                        item5 = c.Int(nullable: false),
                        perk1 = c.Int(nullable: false),
                        perk0 = c.Int(nullable: false),
                        perk3 = c.Int(nullable: false),
                        perk2 = c.Int(nullable: false),
                        perk3Var3 = c.Int(nullable: false),
                        perk3Var2 = c.Int(nullable: false),
                        perk3Var1 = c.Int(nullable: false),
                        damageSelfMitigated = c.Int(nullable: false),
                        magicalDamageTaken = c.Int(nullable: false),
                        perk0Var2 = c.Int(nullable: false),
                        firstInhibitorKill = c.Boolean(nullable: false),
                        trueDamageTaken = c.Int(nullable: false),
                        assists = c.Int(nullable: false),
                        perk4Var2 = c.Int(nullable: false),
                        goldSpent = c.Int(nullable: false),
                        trueDamageDealt = c.Int(nullable: false),
                        participantId = c.Int(nullable: false),
                        physicalDamageDealt = c.Int(nullable: false),
                        sightWardsBoughtInGame = c.Int(nullable: false),
                        totalDamageDealtToChampions = c.Int(nullable: false),
                        physicalDamageTaken = c.Int(nullable: false),
                        totalPlayerScore = c.Int(nullable: false),
                        win = c.Boolean(nullable: false),
                        objectivePlayerScore = c.Int(nullable: false),
                        totalDamageDealt = c.Int(nullable: false),
                        neutralMinionsKilledEnemyJungle = c.Int(nullable: false),
                        deaths = c.Int(nullable: false),
                        wardsPlaced = c.Int(nullable: false),
                        perkPrimaryStyle = c.Int(nullable: false),
                        perkSubStyle = c.Int(nullable: false),
                        turretKills = c.Int(nullable: false),
                        firstBloodKill = c.Boolean(nullable: false),
                        trueDamageDealtToChampions = c.Int(nullable: false),
                        goldEarned = c.Int(nullable: false),
                        killingSprees = c.Int(nullable: false),
                        unrealKills = c.Int(nullable: false),
                        firstTowerAssist = c.Boolean(nullable: false),
                        firstTowerKill = c.Boolean(nullable: false),
                        champLevel = c.Int(nullable: false),
                        doubleKills = c.Int(nullable: false),
                        inhibitorKills = c.Int(nullable: false),
                        firstInhibitorAssist = c.Boolean(nullable: false),
                        perk0Var1 = c.Int(nullable: false),
                        combatPlayerScore = c.Int(nullable: false),
                        perk0Var3 = c.Int(nullable: false),
                        visionWardsBoughtInGame = c.Int(nullable: false),
                        pentaKills = c.Int(nullable: false),
                        totalHeal = c.Int(nullable: false),
                        totalMinionsKilled = c.Int(nullable: false),
                        timeCCingOthers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        spell1Id = c.Int(nullable: false),
                        participantId = c.Int(nullable: false),
                        highestAchievedSeasonTier = c.String(),
                        spell2Id = c.Int(nullable: false),
                        teamId = c.Int(nullable: false),
                        championId = c.Int(nullable: false),
                        stats_Id = c.Int(),
                        timeline_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        currentPlatformId = c.String(),
                        summonerName = c.String(),
                        matchHistoryUri = c.String(),
                        platformId = c.String(),
                        currentAccountId = c.Long(nullable: false),
                        profileIcon = c.Int(nullable: false),
                        summonerId = c.Int(nullable: false),
                        accountId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participantidentities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        participantId = c.Int(nullable: false),
                        player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goldpermindeltas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _30end = c.Single(nullable: false),
                        _2030 = c.Single(nullable: false),
                        _010 = c.Single(nullable: false),
                        _1020 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Damagetakenpermindeltas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _30end = c.Single(nullable: false),
                        _2030 = c.Single(nullable: false),
                        _010 = c.Single(nullable: false),
                        _1020 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Damagetakendiffpermindeltas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _30end = c.Single(nullable: false),
                        _2030 = c.Single(nullable: false),
                        _010 = c.Single(nullable: false),
                        _1020 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Csdiffpermindeltas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _30end = c.Single(nullable: false),
                        _2030 = c.Single(nullable: false),
                        _010 = c.Single(nullable: false),
                        _1020 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Creepspermindeltas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _30end = c.Single(nullable: false),
                        _2030 = c.Single(nullable: false),
                        _010 = c.Single(nullable: false),
                        _1020 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        pickTurn = c.Int(nullable: false),
                        championId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUsers", "Club_Id", "dbo.Clubs");
            DropIndex("dbo.AspNetUsers", new[] { "Club_Id" });
            DropColumn("dbo.AspNetUsers", "Club_Id");
            DropTable("dbo.Clubs");
            CreateIndex("dbo.Timelines", "xpPerMinDeltas_Id");
            CreateIndex("dbo.Timelines", "xpDiffPerMinDeltas_Id");
            CreateIndex("dbo.Timelines", "goldPerMinDeltas_Id");
            CreateIndex("dbo.Timelines", "damageTakenPerMinDeltas_Id");
            CreateIndex("dbo.Timelines", "damageTakenDiffPerMinDeltas_Id");
            CreateIndex("dbo.Timelines", "csDiffPerMinDeltas_Id");
            CreateIndex("dbo.Timelines", "creepsPerMinDeltas_Id");
            CreateIndex("dbo.Participants", "timeline_Id");
            CreateIndex("dbo.Participants", "stats_Id");
            CreateIndex("dbo.Participantidentities", "player_Id");
            AddForeignKey("dbo.Participants", "timeline_Id", "dbo.Timelines", "Id");
            AddForeignKey("dbo.Timelines", "xpPerMinDeltas_Id", "dbo.Xppermindeltas", "Id");
            AddForeignKey("dbo.Timelines", "xpDiffPerMinDeltas_Id", "dbo.Xpdiffpermindeltas", "Id");
            AddForeignKey("dbo.Timelines", "goldPerMinDeltas_Id", "dbo.Goldpermindeltas", "Id");
            AddForeignKey("dbo.Timelines", "damageTakenPerMinDeltas_Id", "dbo.Damagetakenpermindeltas", "Id");
            AddForeignKey("dbo.Timelines", "damageTakenDiffPerMinDeltas_Id", "dbo.Damagetakendiffpermindeltas", "Id");
            AddForeignKey("dbo.Timelines", "csDiffPerMinDeltas_Id", "dbo.Csdiffpermindeltas", "Id");
            AddForeignKey("dbo.Timelines", "creepsPerMinDeltas_Id", "dbo.Creepspermindeltas", "Id");
            AddForeignKey("dbo.Participants", "stats_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.Participantidentities", "player_Id", "dbo.Players", "Id");
        }
    }
}
