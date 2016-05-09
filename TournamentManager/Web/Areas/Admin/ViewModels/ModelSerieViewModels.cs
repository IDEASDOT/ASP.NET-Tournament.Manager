using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class ModelSerieIndexViewModel
    {
        public List<ModelSerie> ModelSeries { get; set; }
    }

    public class ModelSerieCreateEditViewModel
    {
        public ModelSerie ModelSerie { get; set; }
    }
}