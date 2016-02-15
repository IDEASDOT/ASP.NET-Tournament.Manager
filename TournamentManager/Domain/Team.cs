using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamMoto { get; set; }
   
        //each team has many players
        public virtual List<Player> Players { get; set; } = new List<Player>();
    }
}
