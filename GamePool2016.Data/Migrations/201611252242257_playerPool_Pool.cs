namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerPool_Pool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerPools", "PoolId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PlayerPools", "PoolId");
            AddForeignKey("dbo.PlayerPools", "PoolId", "dbo.Pools", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerPools", "PoolId", "dbo.Pools");
            DropIndex("dbo.PlayerPools", new[] { "PoolId" });
            DropColumn("dbo.PlayerPools", "PoolId");
        }
    }
}
