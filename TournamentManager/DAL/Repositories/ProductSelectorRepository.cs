using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ProductSelectorRepository : EFRepository<ProductSelector>, IProductSelectorRepository
    {
        public ProductSelectorRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
