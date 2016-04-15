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
