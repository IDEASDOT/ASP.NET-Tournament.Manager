﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using DataAnnotations;
using DAL.EFConfiguration;
using DAL.Helpers;
using DAL.Interfaces;
using Domain;
using Domain.Identity;
using Ninject;
using NLog;

namespace DAL
{
    public class DataBaseContext:DbContext, IDbContext
    {
        private readonly NLog.ILogger _logger;
        private readonly string _instanceId = Guid.NewGuid().ToString();

        [Inject]
        public DataBaseContext(ILogger logger) : base ("name = TournamentDBConnection")
        {
            
            _logger = logger;
            _logger.Debug("InstanceId: " + _instanceId);


            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext,MigrationConfiguration>());
            Database.SetInitializer(new DatabaseInitializer());

#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
            this.Database.Log = s => _logger.Info((s.Contains("SELECT") || s.Contains("UPDATE") || s.Contains("DELETE") || s.Contains("INSERT")) ? "\n" + s.Trim() : s.Trim());
        }


        //hack for mvc scaffolding, paramaterles constructor is required
        public DataBaseContext() : this(NLog.LogManager.GetCurrentClassLogger())
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<ComputerSpecification> ComputerSpecifications { get; set; }
        public DbSet<GameSpecification> GameSpecifications { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MapInfo> MapInfos { get; set; } 

        public DbSet<Manufactorer> Manufactorers { get; set; }
        public DbSet<ManufactorerType> ManufactorerTypes { get; set; }
        public DbSet<ModelSerie> ModelSeries { get; set; }
        public DbSet<ModelSerieType> ModelSerieTypes { get; set; }
        public DbSet<ProductSelector> ProductSelectors { get; set; }
        public DbSet<PieceInComputer> PieceInComputers { get; set; }

        public IDbSet<Article> Articles { get; set; }
        public IDbSet<MultiLangString> MultiLangStrings { get; set; }
        public IDbSet<Translation> Translations { get; set; }


        // Identity tables, PK - string
        //public IDbSet<Role> Roles { get; set; }
        //public IDbSet<UserClaim> UserClaims { get; set; }
        //public IDbSet<UserLogin> UserLogins { get; set; }
        //public IDbSet<User> Users { get; set; }
        //public IDbSet<UserRole> UserRoles { get; set; }

        // Identity tables, PK - int
        public IDbSet<RoleInt> RolesInt { get; set; }
        public IDbSet<UserClaimInt> UserClaimsInt { get; set; }
        public IDbSet<UserLoginInt> UserLoginsInt { get; set; }
        public IDbSet<UserInt> UsersInt { get; set; }
        public IDbSet<UserRoleInt> UserRolesInt { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // remove tablename pluralizing
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // remove cascade delete
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Identity, PK - string 
            //modelBuilder.Configurations.Add(new RoleMap());
            //modelBuilder.Configurations.Add(new UserClaimMap());
            //modelBuilder.Configurations.Add(new UserLoginMap());
            //modelBuilder.Configurations.Add(new UserMap());
            //modelBuilder.Configurations.Add(new UserRoleMap());

            // Identity, PK - int 
            modelBuilder.Configurations.Add(new RoleIntMap());
            modelBuilder.Configurations.Add(new UserClaimIntMap());
            modelBuilder.Configurations.Add(new UserLoginIntMap());
            modelBuilder.Configurations.Add(new UserIntMap());
            modelBuilder.Configurations.Add(new UserRoleIntMap());

            Precision.ConfigureModelBuilder(modelBuilder);

            // convert all datetime and datetime? properties to datetime2 in ms sql
            // ms sql datetime has min value of 1753-01-01 00:00:00.000
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            // use Date type in ms sql, where [DataType(DataType.Date)] attribute is used
            modelBuilder.Properties<DateTime>()
           .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
           .Any(a => a.DataType == DataType.Date))
           .Configure(c => c.HasColumnType("date"));


        }

        public override int SaveChanges()
        {
            // or watch this inside exception ((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _logger.Info("Disposing: " + disposing + " _instanceId: " + _instanceId);
            base.Dispose(disposing);
        }

    }
}
