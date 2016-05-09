using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class ModelSerieTypeIndexViewModel
    {
        public List<ModelSerieType> ModelSerieTypes { get; set; }
    }
    public class ModelSerieTypeCreateEditViewModel
    {
        public ModelSerieType ModelSerieType { get; set; }
    }

    
}