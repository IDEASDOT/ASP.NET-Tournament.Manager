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
        //Primary key for teamID
        public int TeamId { get; set; }
        //Name for the team
        [Required, MaxLength(128, ErrorMessage = "Your team name cannot be more than 128 characters"), MinLength(5, ErrorMessage = "Your team name cannot be less than 5 characters")]
        public string TeamName { get; set; }
        [Required, MinLength(2, ErrorMessage = "Your team abbreviation cannot be less than 2 characters"), MaxLength(10, ErrorMessage = "Your team abbreviation cannot be more than 10 characters")]
        public string TeamAbbreviation { get; set; }
        //teamlogo, notrequired (byte for image)
        public byte[] TeamLogo { get; set; }
   
        //List of players in this specific team
        public virtual List<Player> Players { get; set; } = new List<Player>();
    }
}
