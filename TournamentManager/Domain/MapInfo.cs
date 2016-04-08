using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MapInfo
    {
        public int MapInfoId { get; set; }

        //FK for Match and Map
        public int MapId { get; set; }
        public virtual Map Map { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }

        [Display(Name = nameof(Resources.Domain.Score), ResourceType = typeof(Resources.Domain))]
        public string Score => FirstTeamScore + ":" + SecondTeamScore;

    }
}
