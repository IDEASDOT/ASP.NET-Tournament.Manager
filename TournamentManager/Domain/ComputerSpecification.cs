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

        //Primary key
        [Key]
        public int CompSpecId { get; set; }

        //Computer Specifications
        [MaxLength(128)]
        public string ProcessorName { get; set; }
        [MaxLength(128)]
        public string GraphicName { get; set; }
        [MaxLength(128)]
        public string StorageName { get; set; }
        [MaxLength(128)]
        public string RamName { get; set; }
        [MaxLength(128)]
        public string OsName { get; set; }

        //Mouse&Keyboard&Headset Specifications
        [MaxLength(128)]
        public string MouseName { get; set; }
        [MaxLength(128)]
        public string MousePadName { get; set; }
        [MaxLength(128)]
        public string HeadsetName { get; set; }
        [MaxLength(128)]
        public string KeyboardName { get; set; }

        //One computerspec one player
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        //Win / Lose rate

        public int? CompWins { get; set; }
        public int? CompLost { get; set; }
            


    }
}
