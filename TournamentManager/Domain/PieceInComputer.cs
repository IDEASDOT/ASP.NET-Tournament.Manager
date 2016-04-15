using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PieceInComputer
    {
        public int PieceInComputerId { get; set; }
        [Display(Name = nameof(Resources.Domain.Quantity), ResourceType = typeof(Resources.Domain))]
        public int Quantity { get; set; }

        public int ProductSelectorId { get; set; }
        public virtual ProductSelector ProductSelector { get; set; }

        public int CompSpecId { get; set; }
        public ComputerSpecification ComputerSpecification { get; set; }

    }
}
