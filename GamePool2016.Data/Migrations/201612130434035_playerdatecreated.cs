namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerdatecreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "DateCreated");
        }
    }
}
