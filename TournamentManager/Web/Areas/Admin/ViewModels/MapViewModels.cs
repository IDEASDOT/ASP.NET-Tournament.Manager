using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
	public class MapIndexViewModel
	{
	    public List<Map> Maps { get; set; }
	}

    public class MapCreateEditViewModel
    {
        public Map Map { get; set; }
    }
}