using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GameSpecification
    {
        //Primary key for Game Specification
        [Key]
        public int GameSpecId { get; set; }

        //Nullable ints for mouse DPI and Ingame sensitivity (user does not need to set it)
        public int? DpiValue { get; set; }
        public double? SensitivityValue { get; set; }

        //Foreign key for Player + instance of player
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        //Nullable game win/lose rate with these settings
        public int? GameWins { get; set; }
        public int? GameLost { get; set; }


    }
}
