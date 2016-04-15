using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Manufactorer
    {
        public int ManufactorerId { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "ManufactorerNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "ManufactorerNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Manufactorer), ResourceType = typeof(Resources.Domain))]
        public string ManufactorerName { get; set; }
    }
}
