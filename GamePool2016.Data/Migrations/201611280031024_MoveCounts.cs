namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveCounts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PoolGames", "HomeSelectedCount", c => c.Int(nullable: false));
            AddColumn("dbo.PoolGames", "AwaySelectedCount", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "HomeSelectedCount");
            DropColumn("dbo.Games", "AwaySelectedCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "AwaySelectedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "HomeSelectedCount", c => c.Int(nullable: false));
            DropColumn("dbo.PoolGames", "AwaySelectedCount");
            DropColumn("dbo.PoolGames", "HomeSelectedCount");
        }
    }
}
