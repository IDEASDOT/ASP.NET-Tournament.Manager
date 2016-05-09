using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class MapRepository : EFRepository<Map>, IMapRepository
    {
        public MapRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
