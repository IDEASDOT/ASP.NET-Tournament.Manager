using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ComputerSpecificationRepository : EFRepository<ComputerSpecification>, IComputerSpecificationRepository
    {
        public ComputerSpecificationRepository(IDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
