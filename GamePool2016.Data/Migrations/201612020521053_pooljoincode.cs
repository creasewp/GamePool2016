namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pooljoincode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pools", "JoinCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pools", "JoinCode");
        }
    }
}
