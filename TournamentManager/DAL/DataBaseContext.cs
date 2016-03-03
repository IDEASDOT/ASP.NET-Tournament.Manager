using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class DataBaseContext:DbContext, IDbContext
    {

        public DataBaseContext() : base ("name = TournamentDBConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext,MigrationConfiguration>());
#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<ComputerSpecification> ComputerSpecifications { get; set; }
        public DbSet<GameSpecification> GameSpecifications { get; set; }
        public DbSet<MapPool> MapPools { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Manufactorer> Manufactorers { get; set; }
        public DbSet<ManufactorerType> ManufactorerTypes { get; set; }
        public DbSet<ModelSerie> ModelSeries { get; set; }
        public DbSet<ModelSerieType> ModelSerieTypes { get; set; }
        public DbSet<ProductSelector> ProductSelectors { get; set; }
    }
}
