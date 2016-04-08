using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Match
    {
        //Primary key for a match
        public int MatchId { get; set; }
        //FK for first team
        public int FirstTeamId { get; set; }
        [Required, ForeignKey("FirstTeamId")]
        public virtual Team FirstTeam { get; set; }
        //FK for second team
        public int SecondTeamId { get; set; }
        
        [Required, ForeignKey("SecondTeamId")]
        public virtual Team SecondTeam { get; set; }

        [Display(Name = nameof(Resources.Domain.DateTime), ResourceType = typeof(Resources.Domain))]
        public DateTime DateTime { get; set; }
        [Display(Name = nameof(Resources.Domain.Date), ResourceType = typeof(Resources.Domain))]
        public DateTime Date { get; set; }
        [Display(Name = nameof(Resources.Domain.Time), ResourceType = typeof(Resources.Domain))]
        public DateTime Time { get; set; }


        //Information about the maps played
        public virtual List<MapInfo> MapInfos { get; set; }
                
    }
}
