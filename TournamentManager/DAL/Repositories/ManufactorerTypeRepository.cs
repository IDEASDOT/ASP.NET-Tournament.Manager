using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ManufactorerTypeRepository:EFRepository<ManufactorerType>, IManufactorerTypeRepository
    {
        public ManufactorerTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
