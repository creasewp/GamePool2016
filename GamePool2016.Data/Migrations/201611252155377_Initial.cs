namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        HomeTeamId = c.String(maxLength: 128),
                        AwayTeamId = c.String(maxLength: 128),
                        HomeScore = c.Byte(nullable: false),
                        AwayScore = c.Byte(nullable: false),
                        GameDateTime = c.String(),
                        Network = c.String(),
                        IsGameFinished = c.Boolean(nullable: false),
                        HomeSelectedCount = c.Int(nullable: false),
                        AwaySelectedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerPoolGames",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PlayerPoolId = c.String(maxLength: 128),
                        PoolGameId = c.String(maxLength: 128),
                        Confidence = c.Int(nullable: false),
                        WinnerTeamId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlayerPools", t => t.PlayerPoolId)
                .ForeignKey("dbo.PoolGames", t => t.PoolGameId)
                .Index(t => t.PlayerPoolId)
                .Index(t => t.PoolGameId);
            
            CreateTable(
                "dbo.PlayerPools",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PlayerId = c.String(maxLength: 128),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsSysadmin = c.Boolean(nullable: false),
                        Email = c.String(),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        IsLocked = c.Boolean(nullable: false),
                        IsEligible = c.Boolean(nullable: false),
                        PoolScore = c.Int(nullable: false),
                        LostPoints = c.Int(nullable: false),
                        PossiblePoints = c.Int(nullable: false),
                        WinPercent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PoolGames",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PoolId = c.String(maxLength: 128),
                        GameId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId)
                .ForeignKey("dbo.Pools", t => t.PoolId)
                .Index(t => t.PoolId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Pools",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerPoolGames", "PoolGameId", "dbo.PoolGames");
            DropForeignKey("dbo.PoolGames", "PoolId", "dbo.Pools");
            DropForeignKey("dbo.PoolGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.PlayerPools", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerPoolGames", "PlayerPoolId", "dbo.PlayerPools");
            DropForeignKey("dbo.Games", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "AwayTeamId", "dbo.Teams");
            DropIndex("dbo.PoolGames", new[] { "GameId" });
            DropIndex("dbo.PoolGames", new[] { "PoolId" });
            DropIndex("dbo.PlayerPools", new[] { "PlayerId" });
            DropIndex("dbo.PlayerPoolGames", new[] { "PoolGameId" });
            DropIndex("dbo.PlayerPoolGames", new[] { "PlayerPoolId" });
            DropIndex("dbo.Games", new[] { "AwayTeamId" });
            DropIndex("dbo.Games", new[] { "HomeTeamId" });
            DropTable("dbo.Pools");
            DropTable("dbo.PoolGames");
            DropTable("dbo.Players");
            DropTable("dbo.PlayerPools");
            DropTable("dbo.PlayerPoolGames");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
        }
    }
}
