using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
	public class GameSpecificationIndexViewModel
	{
	    public List<GameSpecification> GameSpecifications { get; set; }
	}

    public class GameSpecificationCreateEditViewModel
    {
        public GameSpecification GameSpecification { get; set; }
        public SelectList PlayerSelectList { get; set; }
    }
}