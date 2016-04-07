using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ComputerSpecification
    {

        //Primary key ffor computer specification key
        [Key]
        public int CompSpecId { get; set; }

        //Computer Specifications
        
        public virtual List<PieceInComputer> PieceInComputers { get; set; } 

        [MaxLength(128)]
        public string OsName { get; set; }


        //One computerspec one player
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        //Win / Lose rate

        public int? CompWins { get; set; }
        public int? CompLost { get; set; }
            


    }
}
