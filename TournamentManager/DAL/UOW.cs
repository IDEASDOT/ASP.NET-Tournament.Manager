using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL
{
    public class UOW : IUOW, IDisposable
    {

        private IDbContext DbContext { get; set; }
        protected IEFRepositoryProvider RepositoryProvider { get; set; }

        public UOW(IEFRepositoryProvider repositoryProvider, IDbContext dbContext)
        {

            DbContext = dbContext;

            repositoryProvider.DbContext = dbContext;
            RepositoryProvider = repositoryProvider;
        }

        // UoW main feature - atomic commit at the end of work
        public void Commit()
        {
            ((DbContext)DbContext).SaveChanges();
        }


        //standard repos
        public IEFRepository<Player> Players => GetStandardRepo<Player>();
        public IEFRepository<ComputerSpecification> ComputerSpecifications => GetStandardRepo<ComputerSpecification>();
        public IEFRepository<Match> Matches => GetStandardRepo<Match>();
        public IEFRepository<GameSpecification> GameSpecifications => GetStandardRepo<GameSpecification>();
        public IEFRepository<Manufactorer> Manufactorers => GetStandardRepo<Manufactorer>();
        public IEFRepository<ManufactorerType> ManufactorerTypes => GetStandardRepo<ManufactorerType>();
        public IEFRepository<Map> MapPools => GetStandardRepo<Map>();
        public IEFRepository<ModelSerie> ModelSeries => GetStandardRepo<ModelSerie>();
        public IEFRepository<ModelSerieType> ModelSerieTypes => GetStandardRepo<ModelSerieType>();
        public IEFRepository<ProductSelector> ProductSelectors => GetStandardRepo<ProductSelector>();
        public IEFRepository<Team> Teams => GetStandardRepo<Team>();
        public IEFRepository<MapInfo> MapInfos => GetStandardRepo<MapInfo>();

        public IEFRepository<MultiLangString> MultiLangStrings => GetStandardRepo<MultiLangString>();
        public IEFRepository<Translation> Translations => GetStandardRepo<Translation>();

        // repo with custom methods
        // add it also in EFRepositoryFactories.cs, in method GetCustomFactories
        //public IPersonRepository Persons => GetRepo<IPersonRepository>();
        public IArticleRepository Articles => GetRepo<IArticleRepository>();

        public IUserIntRepository UsersInt => GetRepo<IUserIntRepository>();
        public IUserRoleIntRepository UserRolesInt => GetRepo<IUserRoleIntRepository>();
        public IRoleIntRepository RolesInt => GetRepo<IRoleIntRepository>();
        public IUserClaimIntRepository UserClaimsInt => GetRepo<IUserClaimIntRepository>();
        public IUserLoginIntRepository UserLoginsInt => GetRepo<IUserLoginIntRepository>();

        // calling standard EF repo provider
        private IEFRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        // calling custom repo provier
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        // try to find repository for type T
        public T GetRepository<T>() where T : class
        {
            var res = GetRepo<T>() ?? GetStandardRepo<T>() as T;
            if (res == null)
            {
                throw new NotImplementedException("No repository for type, " + typeof(T).FullName);
            }
            return res;
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        #endregion

    }
}