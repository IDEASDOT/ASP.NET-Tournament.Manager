using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class TeamRepository : EFRepository<Team>, ITeamRepository
    {
        public TeamRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
