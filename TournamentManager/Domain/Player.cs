using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        //Information about player
        public int PlayerId { get; set; }
        [Required, MaxLength(128)]
        public string FirstName { get; set; }
        [Required, MaxLength(128)]
        public string NickName { get; set; }
        [Required, MaxLength(128)]
        public string LastName { get; set; }
        
        //Information about win/lose rate
        public int? AllTimeWins { get; set; }
        public int? CurrentWins { get; set; }
        public int? AllTimeLost { get; set; }
        public int? CurrentLost { get; set; }

        //Information about computer and game specifications
        public virtual List<ComputerSpecification> ComputerSpecifications { get; set; } = new List<ComputerSpecification>();
        public virtual List<GameSpecification> GameSpecifications { get; set; } = new List<GameSpecification>();

        //Info about team
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
