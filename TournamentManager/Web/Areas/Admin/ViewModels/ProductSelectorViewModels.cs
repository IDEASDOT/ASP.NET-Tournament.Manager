using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class ProductSelectorIndexViewModel
    {
        public List<ProductSelector> ProductSelectors { get; set; }
    }

    public class ProductSelectorCreateEditViewModel
    {
        public ProductSelector ProductSelector { get; set; }
        public SelectList ManufactorerSelectList { get; set; }
        public SelectList ManufactorerTypeSelectList { get; set; }
        public SelectList  ModelSerieSelectList { get; set; }
        public SelectList ModelSerieTypeSelectList { get; set; }
               
    }
}