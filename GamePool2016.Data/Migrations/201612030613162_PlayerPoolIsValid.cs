namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerPoolIsValid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerPools", "IsValid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerPools", "IsValid");
        }
    }
}
