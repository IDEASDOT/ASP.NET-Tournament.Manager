using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Map
    {
        public int MapId { get; set; }
        //Required, maxLength 128 chars name for the map
        [Required]
        [MaxLength(64, ErrorMessageResourceName = "MapNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "MapNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.MapName), ResourceType = typeof(Resources.Domain))]
        public string MapName { get; set; }

        public virtual List<MapInfo> MapInfos { get; set; }

    }
}
