﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ModelSerieRepository : EFRepository<ModelSerie>, IModelSerieRepository
    {
        public ModelSerieRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}