using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class MatchIndexViewModel
    {
        public List<Match> Matches { get; set; }
    }

    public class MatchCreateEditViewModel
    {
        public Match Match { get; set; }
        public SelectList FirstTeamSelectList { get; set; }
        public SelectList SecondTeamSelectList { get; set; }

    }
}