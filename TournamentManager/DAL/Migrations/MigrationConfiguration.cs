using Domain;

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MigrationConfiguration : DbMigrationsConfiguration<DAL.DataBaseContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "DAL.DataBaseContext";
        }

        protected override void Seed(DAL.DataBaseContext context)
        {
            /*context.MapPools.AddOrUpdate(
                mp => mp.MapName,
                new MapPool { MapName = "de_nuke" },
                new MapPool { MapName = "de_mirage" },
                new MapPool { MapName = "de_cbble" },
                new MapPool { MapName = "de_overpass" },
                new MapPool { MapName = "de_cache" }
            );

            context.Players.AddOrUpdate(
                new Player { FirstName = "Egert", NickName = "etgre", LastName = "Aia", FavouriteMap = new MapPool { MapName = "de_inferno" },
                 AllTimeWins = 1, AllTimeLost = 0, CurrentWins = 1, CurrentLost = 0, Team = new Team { TeamName = "Ninjas In Pyjamas", TeamAbbreviation = "NIP" } },
                 new Player
                 {
                     FirstName = "Andres",
                     NickName = "akaver",
                     LastName = "Käver",
                     FavouriteMap = new MapPool { MapName = "de_dust2" },
                     AllTimeWins = 0,
                     AllTimeLost = 1,
                     CurrentWins = 0,
                     CurrentLost = 1,
                     Team = new Team { TeamName = "Virtus Pro", TeamAbbreviation = "VP" }
                 },
                 new Player
                 {
                     FirstName = "Mait",
                     NickName = "minamait",
                     LastName = "Poska",
                     FavouriteMap = new MapPool { MapName = "de_train" },
                     AllTimeWins = 0,
                     AllTimeLost = 0,
                     CurrentWins = 0,
                     CurrentLost = 0,
                     Team = new Team { TeamName = "Meet Your Makers", TeamAbbreviation = "MYM" }
                 }
            );*/
        }
    }
}
