using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class PieceInComputerIndexViewModel
    {
        public List<PieceInComputer> PieceInComputers { get; set; }
    }

    public class PieceInComputerCreateEditViewModel
    {
        public PieceInComputer PieceInComputer { get; set; }
        public SelectList ComputerSpecificationSelectList { get; set; }
        public SelectList ProductSelectorSelectList { get; set; }

    }
}