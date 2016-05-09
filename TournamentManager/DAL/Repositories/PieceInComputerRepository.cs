using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class PieceInComputerRepository : EFRepository<PieceInComputer>, IPieceInComputerRepository
    {
        public PieceInComputerRepository(IDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
