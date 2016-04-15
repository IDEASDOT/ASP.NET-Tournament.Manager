using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ModelSerieTypeRepository : EFRepository<ModelSerieType>, IModelSerieTypeRepository
    {
        public ModelSerieTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
