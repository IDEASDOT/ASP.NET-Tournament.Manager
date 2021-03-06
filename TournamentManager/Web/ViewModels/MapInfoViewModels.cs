﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class MapInfoIndexViewModel
    {
        public List<MapInfo> MapInfos { get; set; }
    }

    public class MapInfoCreateEditViewModel
    {
        public MapInfo MapInfo { get; set; }
        public SelectList MapSelectList { get; set; }
        public SelectList MatchSelectList { get; set; }
    }
}