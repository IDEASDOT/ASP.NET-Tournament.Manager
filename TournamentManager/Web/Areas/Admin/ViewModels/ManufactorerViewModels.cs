using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class ManufactorerIndexViewModel
    {
        public List<Manufactorer> Manufactorers { get; set; }
    }
    public class ManufactorerCreateEditViewModel
    {
        public Manufactorer Manufactorer { get; set; }
    }
}