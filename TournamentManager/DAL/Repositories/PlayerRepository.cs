using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class PlayerRepository: EFRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(IDbContext dbContext) : base(dbContext)
        {
            
        }
        public List<Player> GetAllForUser(int userId)
        {
            return DbSet.Where(p => p.UserId == userId).OrderBy(o => o.LastName).ThenBy(o => o.FirstName).Include(c => c.ComputerSpecifications).
            Include(d => d.GameSpecifications).Include(e => e.Team).Include(g => g.FavouriteMap).ToList();
        }

        public Player GetForUser(int personId, int userId)
        {
            return DbSet.FirstOrDefault(a => a.PlayerId == personId && a.UserId == userId);
        }
    }
}
