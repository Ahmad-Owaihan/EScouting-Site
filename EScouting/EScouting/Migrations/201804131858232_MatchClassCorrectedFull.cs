namespace EScouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchClassCorrectedFull : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        pickTurn = c.Int(nullable: false),
                        championId = c.Int(nullable: false),
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
                "dbo.Participantidentities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        participantId = c.Int(nullable: false),
                        player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.player_Id)
                .Index(t => t.player_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        currentPlatformId = c.String(),
                        summonerName = c.String(),
                        matchHistoryUri = c.String(),
                        platformId = c.String(),
                        currentAccountId = c.Int(nullable: false),
                        profileIcon = c.Int(nullable: false),
                        summonerId = c.Int(nullable: false),
                        accountId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stats", t => t.stats_Id)
                .ForeignKey("dbo.Timelines", t => t.timeline_Id)
                .Index(t => t.stats_Id)
                .Index(t => t.timeline_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Creepspermindeltas", t => t.creepsPerMinDeltas_Id)
                .ForeignKey("dbo.Csdiffpermindeltas", t => t.csDiffPerMinDeltas_Id)
                .ForeignKey("dbo.Damagetakendiffpermindeltas", t => t.damageTakenDiffPerMinDeltas_Id)
                .ForeignKey("dbo.Damagetakenpermindeltas", t => t.damageTakenPerMinDeltas_Id)
                .ForeignKey("dbo.Goldpermindeltas", t => t.goldPerMinDeltas_Id)
                .ForeignKey("dbo.Xpdiffpermindeltas", t => t.xpDiffPerMinDeltas_Id)
                .ForeignKey("dbo.Xppermindeltas", t => t.xpPerMinDeltas_Id)
                .Index(t => t.creepsPerMinDeltas_Id)
                .Index(t => t.csDiffPerMinDeltas_Id)
                .Index(t => t.damageTakenDiffPerMinDeltas_Id)
                .Index(t => t.damageTakenPerMinDeltas_Id)
                .Index(t => t.goldPerMinDeltas_Id)
                .Index(t => t.xpDiffPerMinDeltas_Id)
                .Index(t => t.xpPerMinDeltas_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "timeline_Id", "dbo.Timelines");
            DropForeignKey("dbo.Timelines", "xpPerMinDeltas_Id", "dbo.Xppermindeltas");
            DropForeignKey("dbo.Timelines", "xpDiffPerMinDeltas_Id", "dbo.Xpdiffpermindeltas");
            DropForeignKey("dbo.Timelines", "goldPerMinDeltas_Id", "dbo.Goldpermindeltas");
            DropForeignKey("dbo.Timelines", "damageTakenPerMinDeltas_Id", "dbo.Damagetakenpermindeltas");
            DropForeignKey("dbo.Timelines", "damageTakenDiffPerMinDeltas_Id", "dbo.Damagetakendiffpermindeltas");
            DropForeignKey("dbo.Timelines", "csDiffPerMinDeltas_Id", "dbo.Csdiffpermindeltas");
            DropForeignKey("dbo.Timelines", "creepsPerMinDeltas_Id", "dbo.Creepspermindeltas");
            DropForeignKey("dbo.Participants", "stats_Id", "dbo.Stats");
            DropForeignKey("dbo.Participantidentities", "player_Id", "dbo.Players");
            DropIndex("dbo.Timelines", new[] { "xpPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "xpDiffPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "goldPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "damageTakenPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "damageTakenDiffPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "csDiffPerMinDeltas_Id" });
            DropIndex("dbo.Timelines", new[] { "creepsPerMinDeltas_Id" });
            DropIndex("dbo.Participants", new[] { "timeline_Id" });
            DropIndex("dbo.Participants", new[] { "stats_Id" });
            DropIndex("dbo.Participantidentities", new[] { "player_Id" });
            DropTable("dbo.Teams");
            DropTable("dbo.Xppermindeltas");
            DropTable("dbo.Xpdiffpermindeltas");
            DropTable("dbo.Timelines");
            DropTable("dbo.Stats");
            DropTable("dbo.Participants");
            DropTable("dbo.Players");
            DropTable("dbo.Participantidentities");
            DropTable("dbo.Goldpermindeltas");
            DropTable("dbo.Damagetakenpermindeltas");
            DropTable("dbo.Damagetakendiffpermindeltas");
            DropTable("dbo.Csdiffpermindeltas");
            DropTable("dbo.Creepspermindeltas");
            DropTable("dbo.Bans");
        }
    }
}
