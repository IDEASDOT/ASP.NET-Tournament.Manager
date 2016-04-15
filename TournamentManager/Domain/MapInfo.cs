using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class MapInfo
    {
        public int MapInfoId { get; set; }

        //FK for Match and Map
        [Display(Name = nameof(Resources.Domain.MapId), ResourceType = typeof(Resources.Domain))]
        public int MapId { get; set; }
        public virtual Map Map { get; set; }

        [Display(Name = nameof(Resources.Domain.MatchId), ResourceType = typeof(Resources.Domain))]
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        [Display(Name = nameof(Resources.Domain.FirstTeamScore), ResourceType = typeof(Resources.Domain))]
        public int FirstTeamScore { get; set; }
        [Display(Name = nameof(Resources.Domain.SecondTeamScore), ResourceType = typeof(Resources.Domain))]
        public int SecondTeamScore { get; set; }

        [Display(Name = nameof(Resources.Domain.Score), ResourceType = typeof(Resources.Domain))]
        public string Score => FirstTeamScore + ":" + SecondTeamScore;

    }
}
