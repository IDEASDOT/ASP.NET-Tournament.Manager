using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class DataBaseContext:DbContext
    {

        public DataBaseContext() : base ("name = TournamentDBConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext,MigrationConfiguration>());
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<ComputerSpecification> ComputerSpecifications { get; set; }
        public DbSet<GameSpecification> GameSpecifications { get; set; }
        public DbSet<MapPool> MapPools { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        public System.Data.Entity.DbSet<Domain.Manufactorer> Manufactorers { get; set; }

        public System.Data.Entity.DbSet<Domain.ManufactorerType> ManufactorerTypes { get; set; }

        public System.Data.Entity.DbSet<Domain.ModelSerie> ModelSeries { get; set; }

        public System.Data.Entity.DbSet<Domain.ModelSerieType> ModelSerieTypes { get; set; }

        public System.Data.Entity.DbSet<Domain.ProductSelector> ProductSelectors { get; set; }
    }
}
