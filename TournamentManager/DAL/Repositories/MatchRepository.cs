using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class MatchRepository : EFRepository<Match>, IMatchRepository
    {
        public MatchRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
