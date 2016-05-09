using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class ManufactorerTypeIndexViewModel
    {
        public List<ManufactorerType> ManufactorerTypes { get; set; }
    }
    public class ManufactorerTypeCreateEditViewModel
    {
        public ManufactorerType ManufactorerType { get; set; }
    }
}