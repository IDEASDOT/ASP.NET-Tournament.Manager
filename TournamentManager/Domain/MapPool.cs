using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MapPool
    {
        [Key]
        public int MapId { get; set; }
        [Required, MaxLength(128)]
        public string MapName { get; set; }
    }
}
