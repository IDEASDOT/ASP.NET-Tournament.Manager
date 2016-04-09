using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IPlayerRepository : IEFRepository<Player>
    {

        List<Player> GetAllForUser(int userId);

        Player GetForUser(int personId, int userId);
    }
}