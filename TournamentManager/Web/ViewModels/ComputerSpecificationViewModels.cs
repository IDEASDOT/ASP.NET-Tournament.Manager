using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
	public class ComputerSpecificationIndexViewModel
	{
	    public List<ComputerSpecification> ComputerSpecifications { get; set; }
	}

    public class ComputerSpecificationCreateEditViewModel
    {
        public ComputerSpecification ComputerSpecification { get; set; }
        public SelectList PlayerSelectList { get; set; }
    }
}