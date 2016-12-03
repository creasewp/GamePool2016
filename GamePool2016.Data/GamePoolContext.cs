using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class GamePoolContext : DbContext
    {
        public  GamePoolContext() : base("name=MS_TableConnectionString") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GamePoolContext, GamePool2016.Data.Migrations.Configuration>());
        }

        public DbSet<Pool> Pools { get; set; }
        public DbSet<PoolGame> PoolGames { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerPool> PlayerPools { get; set; }
        public DbSet<PlayerPoolGame> PlayerPoolGames { get; set; }
    }
}
