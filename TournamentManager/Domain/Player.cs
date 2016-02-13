using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        //Information about player
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }
        
        //Information about win/lose rate
        public int AllTimeWins { get; set; }
        public int CurrentWins { get; set; }
        public int AllTimeLost { get; set; }
        public int CurrentLost { get; set; }

        //Information about computer and game specifications
        public virtual List<ComputerSpecification> ComputerSpecifications { get; set; }
        public virtual List<GameSpecification> GameSpecifications { get; set; }


        #region NotMapped

        public string FullName => FirstName + " '" + NickName + "' " + LastName;
        public string FirstLastName => FirstName + " " + LastName;
        public string LastFirstName => LastName + " " + FirstName;

        #endregion
    }
}
