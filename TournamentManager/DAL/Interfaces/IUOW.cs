﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IUOW
    {
        //save pending changes to the data store
        void Commit();

        //get repository for type
        T GetRepository<T>() where T : class;

        //Standard repos, autogenerated
        IEFRepository<Match> Matches { get; }
        IEFRepository<ComputerSpecification> ComputerSpecifications { get; }
        IEFRepository<GameSpecification> GameSpecifications { get; }
        IEFRepository<Manufactorer> Manufactorers { get; }
        IEFRepository<ManufactorerType> ManufactorerTypes { get; }
        IEFRepository<Map> Maps { get; }
        IEFRepository<ModelSerie> ModelSeries { get; }
        IEFRepository<ModelSerieType> ModelSerieTypes { get; }
        IEFRepository<ProductSelector> ProductSelectors { get; }
        IEFRepository<PieceInComputer> PieceInComputers { get; }
         IEFRepository<Team> Teams { get; }
        IEFRepository<MapInfo> MapInfos { get; }
        IEFRepository<MultiLangString> MultiLangStrings { get; }
        IEFRepository<Translation> Translations { get; }

        //Customs repos, manually implemented
        // IPersonRepository Persons { get; }
        IPlayerRepository Players { get; }
        IArticleRepository Articles { get; }
        IUserIntRepository UsersInt { get; }
        IUserRoleIntRepository UserRolesInt { get; }
        IRoleIntRepository RolesInt { get; }
        IUserClaimIntRepository UserClaimsInt { get; }
        IUserLoginIntRepository UserLoginsInt { get; }
    }
}