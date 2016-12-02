namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovePlayerPoolProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerPools", "IsEligible", c => c.Boolean(nullable: false));
            AddColumn("dbo.PlayerPools", "PoolScore", c => c.Int(nullable: false));
            AddColumn("dbo.PlayerPools", "LostPoints", c => c.Int(nullable: false));
            AddColumn("dbo.PlayerPools", "PossiblePoints", c => c.Int(nullable: false));
            AddColumn("dbo.PlayerPools", "WinPercent", c => c.Double(nullable: false));
            DropColumn("dbo.Players", "IsLocked");
            DropColumn("dbo.Players", "IsEligible");
            DropColumn("dbo.Players", "PoolScore");
            DropColumn("dbo.Players", "LostPoints");
            DropColumn("dbo.Players", "PossiblePoints");
            DropColumn("dbo.Players", "WinPercent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "WinPercent", c => c.Double(nullable: false));
            AddColumn("dbo.Players", "PossiblePoints", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "LostPoints", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "PoolScore", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "IsEligible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "IsLocked", c => c.Boolean(nullable: false));
            DropColumn("dbo.PlayerPools", "WinPercent");
            DropColumn("dbo.PlayerPools", "PossiblePoints");
            DropColumn("dbo.PlayerPools", "LostPoints");
            DropColumn("dbo.PlayerPools", "PoolScore");
            DropColumn("dbo.PlayerPools", "IsEligible");
        }
    }
}
