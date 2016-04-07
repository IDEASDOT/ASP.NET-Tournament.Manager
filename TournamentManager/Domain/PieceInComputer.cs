using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PieceInComputer
    {
        public int PieceInComputerId { get; set; }
        public int Quantity { get; set; }

        public int ProductSelectorId { get; set; }
        public virtual ProductSelector ProductSelector { get; set; }

        public int CompSpecId { get; set; }
        public ComputerSpecification ComputerSpecification { get; set; }

    }
}
