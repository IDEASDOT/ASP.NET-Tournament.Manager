using System.Collections.Generic;

namespace Domain
{
    public class ProductSelector
    {
        public int ProductSelectorId { get; set; }
        
        //ForeignKeys
        //EG: Processor
        public int ManufactorerTypeId { get; set; }
        public virtual ManufactorerType ManufactorerType { get; set; }

        //EG: Intel
        public int ManufactorerId { get; set; }
        public virtual Manufactorer Manufactorer { get; set; }

        //EG: Xeon® E7
        public int ModelSerieTypeId { get; set; }
        public virtual ModelSerieType ModelSerieType { get; set; }

        //EG: 4850 v3
        public int ModelSerieId { get; set; }
        public virtual ModelSerie ModelSerie { get; set; }

        public virtual List<PieceInComputer> PieceInComputers { get; set; }

        #region NotMapped
        public string FullName => ManufactorerType.ManufactorerTypeName + ": " + Manufactorer.ManufactorerName + " " + ModelSerieType.ModelSerieTypeName + " " + ModelSerie.ModelSerieName;
        #endregion
    }
}
