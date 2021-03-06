﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Match
    {
        //Primary key for a match
        public int MatchId { get; set; }
        //FK for first team
        [Display(Name = nameof(Resources.Domain.FirstTeamId), ResourceType = typeof(Resources.Domain))]
        public int FirstTeamId { get; set; }
        [ForeignKey("FirstTeamId")]
        public virtual Team FirstTeam { get; set; }
        //FK for second team
        [Display(Name = nameof(Resources.Domain.SecondTeamId), ResourceType = typeof(Resources.Domain))]
        public int SecondTeamId { get; set; }

        [ForeignKey("SecondTeamId")]
        
        public virtual Team SecondTeam { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = nameof(Resources.Domain.DateTime), ResourceType = typeof(Resources.Domain))]
        public DateTime DateTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = nameof(Resources.Domain.Date), ResourceType = typeof(Resources.Domain))]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = nameof(Resources.Domain.Time), ResourceType = typeof(Resources.Domain))]
        public DateTime Time { get; set; }


        //Information about the maps played
        public virtual List<MapInfo> MapInfos { get; set; }


        #region NotMapped
        [Display(Name = nameof(Resources.Domain.MatchFullName), ResourceType = typeof(Resources.Domain))]
        public string FullName => FirstTeam.TeamName + " vs " + SecondTeam.TeamName;

        #endregion
    }
}
