using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL
{
    public class DataBaseContext:DbContext
    {

        public DataBaseContext() : base ("name = TournamentDBConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<ComputerSpecification> ComputerSpecifications { get; set; }
        public DbSet<GameSpecification> GameSpecifications { get; set; }
        public DbSet<MapPool> MapPools { get; set; }
    }
}
