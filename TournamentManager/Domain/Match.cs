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
        [Required]
        [ForeignKey("FirstTeamId")]
        public virtual Team FirstTeam { get; set; }
        [Required]
        public virtual List<Player> FirstTeamPlayers { get; set; }

        //FK for second team
        public int SecondTeamId { get; set; }
        [Required]
        [ForeignKey("SecondTeamId")]
        public virtual Team SecondTeam { get; set; }
        [Required]
        public virtual List<Player> SecondTeamPlayers { get; set; }

        //Information about the match
        public int? NumberOfMapsPlayed  { get; set; }

        public virtual List<MapPool> MapsPlayed { get; set; }

        //Information about maprounds (Max maps 5, thus 5 statistics)
        public int? FirstTeamFirstMapRoundsWon { get; set; }
        public int? SecondTeamFirstMapRoundsWon { get; set; }
        public int? FirstTeamSecondMapRoundsWon { get; set; }
        public int? SecondTeamSecondMapRoundsWon { get; set; }
        public int? FirstTeamThirdMapRoundsWon { get; set; }
        public int? SecondTeamThirdMapRoundsWon { get; set; }
        public int? FirstTeamFourthMapRoundsWon { get; set; }
        public int? SecondTeamFourthMapRoundsWon { get; set; }
        public int? FirstTeamFifthMapRoundsWon { get; set; }
        public int? SecondTeamFifthMapRoundsWon { get; set; }

        #region NotMapped

        public string FirstMap => + FirstTeamFirstMapRoundsWon + ":" + SecondTeamFirstMapRoundsWon;
        public string SecondMap => +FirstTeamSecondMapRoundsWon + ":" + SecondTeamSecondMapRoundsWon;
        public string ThirdMap => +FirstTeamThirdMapRoundsWon + ":" + SecondTeamThirdMapRoundsWon;
        public string FourthMap => +FirstTeamFourthMapRoundsWon + ":" + SecondTeamFourthMapRoundsWon;
        public string FifthMap => +FirstTeamFifthMapRoundsWon + ":" + SecondTeamFifthMapRoundsWon;

        #endregion
    }
}
