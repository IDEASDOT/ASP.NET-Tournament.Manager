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
            context.MapPools.AddOrUpdate(
                mp => mp.MapName,
                new MapPool { MapName = "de_inferno" },
                new MapPool { MapName = "de_dust2" },
                new MapPool { MapName = "de_nuke"},
                new MapPool { MapName = "de_mirage" },
                new MapPool { MapName = "de_cbble" },
                new MapPool { MapName = "de_overpass" },
                new MapPool { MapName = "de_cache" },
                new MapPool { MapName = "de_train" }
            );
        }
    }
}
