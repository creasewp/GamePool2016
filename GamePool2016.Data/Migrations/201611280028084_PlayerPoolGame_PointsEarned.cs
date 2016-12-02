namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerPoolGame_PointsEarned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerPoolGames", "PointsEarned", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerPoolGames", "PointsEarned");
        }
    }
}
