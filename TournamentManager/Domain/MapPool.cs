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
        //Primary key for MapPool
        [Key]
        public int MapId { get; set; }
        //Required, maxLength 128 chars name for the map
        [Required, MaxLength(128)]
        public string MapName { get; set; }
    }
}
