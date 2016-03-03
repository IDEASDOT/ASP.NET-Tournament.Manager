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
        public IEFRepository<MapPool> MapPools => GetStandardRepo<MapPool>();
        public IEFRepository<ModelSerie> ModelSeries => GetStandardRepo<ModelSerie>();
        public IEFRepository<ModelSerieType> ModelSerieTypes => GetStandardRepo<ModelSerieType>();
        public IEFRepository<ProductSelector> ProductSelectors => GetStandardRepo<ProductSelector>();
        public IEFRepository<Team> Teams => GetStandardRepo<Team>();

        // repo with custom methods
        // add it also in EFRepositoryFactories.cs, in method GetCustomFactories
        //public IPersonRepository Persons => GetRepo<IPersonRepository>();

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