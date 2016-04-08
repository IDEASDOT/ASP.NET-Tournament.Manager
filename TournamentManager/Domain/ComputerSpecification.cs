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

        [MaxLength(128, ErrorMessageResourceName = "OsNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "OsNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.OsName), ResourceType = typeof(Resources.Domain))]
        public string OsName { get; set; }


        //One computerspec one player
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        //Win / Lose rate
        [Display(Name = nameof(Resources.Domain.CompWins), ResourceType = typeof(Resources.Domain))]
        public int? CompWins { get; set; }
        [Display(Name = nameof(Resources.Domain.CompLost), ResourceType = typeof(Resources.Domain))]
        public int? CompLost { get; set; }
            


    }
}
