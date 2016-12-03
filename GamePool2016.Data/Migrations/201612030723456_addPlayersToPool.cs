namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPlayersToPool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Pool_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Players", "Pool_Id");
            AddForeignKey("dbo.Players", "Pool_Id", "dbo.Pools", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Pool_Id", "dbo.Pools");
            DropIndex("dbo.Players", new[] { "Pool_Id" });
            DropColumn("dbo.Players", "Pool_Id");
        }
    }
}
