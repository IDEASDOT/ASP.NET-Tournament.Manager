using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ManufactorerRepository : EFRepository<Manufactorer>, IManufactorerRepository
    {
        public ManufactorerRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
