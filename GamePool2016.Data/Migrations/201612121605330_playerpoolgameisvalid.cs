namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerpoolgameisvalid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerPoolGames", "IsValid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerPoolGames", "IsValid");
        }
    }
}
