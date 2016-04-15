using System.Collections.Generic;
using Domain;

namespace DAL.Interfaces
{
    public interface IPlayerRepository : IEFRepository<Player>
    {

        List<Player> GetAllForUser(int userId);

        Player GetForUser(int personId, int userId);
    }
}