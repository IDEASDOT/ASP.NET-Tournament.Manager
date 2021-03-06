﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class PlayerIndexViewModel
    {
        public List<Player> Players { get; set; }
         
    }

    public class PlayerCreateEditViewModel
    {
        public Player Player { get; set; }
        public SelectList MapSelectList { get; set; }
        public SelectList TeamSelectList { get; set; }

    }
}