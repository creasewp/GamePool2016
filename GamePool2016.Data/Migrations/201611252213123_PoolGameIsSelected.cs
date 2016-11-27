namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoolGameIsSelected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PoolGames", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PoolGames", "IsSelected");
        }
    }
}
