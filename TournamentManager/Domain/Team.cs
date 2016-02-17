using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required, MaxLength(128)]
        public string TeamName { get; set; }
        [Required, MaxLength(128)]
        public string TeamMoto { get; set; }

        public byte[] TeamLogo { get; set; }
   

        //forignkey + players
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public virtual List<Player> Players { get; set; } = new List<Player>();
    }
}
