﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductSelector
    {
        public int ProductSelectorId { get; set; }
        
        //ForeignKeys
        public int ManufactorerTypeId { get; set; }
        public virtual ManufactorerType ManufactorerType { get; set; }

        public int ManufactorerId { get; set; }
        public virtual Manufactorer Manufactorer { get; set; }

        public int ModelSerieId { get; set; }
        public virtual ModelSerie ModelSerie { get; set; }

        public int ModelSerieTypeId { get; set; }
        public virtual ModelSerieType ModelSerieType { get; set; }

        public virtual List<PieceInComputer> PieceInComputers { get; set; }

        #region NotMapped

        public string FullName => ManufactorerType.ManufactorerTypeName + ": " + Manufactorer.ManufactorerName + " " + ModelSerieType.ModelSerieTypeName + " " + ModelSerie.ModelSerieName;
        #endregion
    }
}
