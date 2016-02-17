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
        [Key]
        public int GameSpecId { get; set; }

        [MaxLength(4)]
        public int? DpiValue { get; set; }
        [MaxLength(5)]
        public double? SensitivityValue { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int? GameWins { get; set; }
        public int? GameLost { get; set; }


    }
}
