using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        //Information about player
        public int PlayerId { get; set; }
        [Required, MaxLength(128, ErrorMessage = "Your Name cannot be longer than 128 characters"), MinLength(3, ErrorMessage = "Your Name cannot be less than 3 characters")]
        public string FirstName { get; set; }
        [Required, MaxLength(128), MinLength(3, ErrorMessage = "Your nickname cannot be less than 3 characters")]
        public string NickName { get; set; }
        [Required, MaxLength(128, ErrorMessage = "Your last name cannot be longer than 128 characters"), MinLength(3, ErrorMessage = "Your last name cannot be less than 3 characters")]
        public string LastName { get; set; }

        //Favourite Map of Player + FK
        public int MapId { get; set; }
        public virtual MapPool FavouriteMap { get; set; }
        
        //Information about win/lose rate
        public int? AllTimeWins { get; set; }
        public int? CurrentWins { get; set; }
        public int? AllTimeLost { get; set; }
        public int? CurrentLost { get; set; }

        //Information about computer and game specifications

        public virtual List<ComputerSpecification> ComputerSpecifications { get; set; } = new List<ComputerSpecification>();
        public virtual List<GameSpecification> GameSpecifications { get; set; } = new List<GameSpecification>();

        //Info about team (one player - one team)
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }



        #region NotMapped

        public string FullName => FirstName + " '" + NickName + "' " + LastName;
        public string FirstLastName => FirstName + " " + LastName;
        public string LastFirstName => LastName + " " + FirstName;

        public string CurrentWinLose => "W:" + CurrentWins + "/L:" + CurrentLost;
        public string AllTimeWinLose => "W:" + AllTimeWins + "/L:" + AllTimeLost;

        #endregion
    }
}
