using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.ViewModels
{
    public class TeamIndexViewModel
    {
        public List<Team> Teams { get; set; }
    }

    public class TeamCreateEditViewModel
    {
        public Team Team { get; set; }
    }
}