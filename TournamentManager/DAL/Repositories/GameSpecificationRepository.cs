using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class GameSpecificationRepository : EFRepository<GameSpecification>, IGameSpecificationRepository
    {
        public GameSpecificationRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
