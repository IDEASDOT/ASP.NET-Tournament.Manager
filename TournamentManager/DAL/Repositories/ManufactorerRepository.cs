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
