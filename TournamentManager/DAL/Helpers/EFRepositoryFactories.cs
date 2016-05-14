﻿using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Repositories;
using NLog;

namespace DAL.Helpers
{
    public class EFRepositoryFactories : IDisposable
    {
        private readonly NLog.ILogger _logger;
        private readonly string _instanceId = Guid.NewGuid().ToString();

        private readonly IDictionary<Type, Func<IDbContext, object>> _repositoryFactories;

        public EFRepositoryFactories(ILogger logger)
        {
            _logger = logger;
            _logger.Debug("InstanceId: " + _instanceId);

            _repositoryFactories = GetCustomFactories();
        }

        //this ctor is for testing only, you can give here an arbitrary list of repos
        public EFRepositoryFactories(IDictionary<Type, Func<IDbContext, object>> factories, ILogger logger)
        {
            _logger = logger;
            _repositoryFactories = factories;

            _logger.Debug("InstanceId: " + _instanceId);
        }
        //special repos with custom interfaces are registered here
        private static IDictionary<Type, Func<IDbContext, object>> GetCustomFactories()
        {
            return new Dictionary<Type, Func<IDbContext, object>>
                {
                    {typeof(IPlayerRepository), dbContext => new PlayerRepository(dbContext)},
                    {typeof (IArticleRepository), dbContext => new ArticleRepository(dbContext)},
                    {typeof (IUserIntRepository), dbContext => new UserIntRepository(dbContext)},
                    {typeof (IUserRoleIntRepository), dbContext => new UserRoleIntRepository(dbContext)},
                    {typeof (IUserClaimIntRepository), dbContext => new UserClaimIntRepository(dbContext)},
                    {typeof (IUserLoginIntRepository), dbContext => new UserLoginIntRepository(dbContext)},
                    {typeof (IRoleIntRepository), dbContext => new RoleIntRepository(dbContext)},
                };
        }

        public Func<IDbContext, object> GetRepositoryFactory<T>()
        {

            Func<IDbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<IDbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            // if we already have this repository in list, return it
            // if not, create new instance of EFRepository
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<IDbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            // create new instance of EFRepository<T>
            return dbContext => new EFRepository<T>(dbContext);
        }

        public void Dispose()
        {
        }

    }
}