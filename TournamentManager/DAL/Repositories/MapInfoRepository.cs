using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class MapInfoRepository : EFRepository<MapInfo>, IMapInfoRepository
    {
        public MapInfoRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
