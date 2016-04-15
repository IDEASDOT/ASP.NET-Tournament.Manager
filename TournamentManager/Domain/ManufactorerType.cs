using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ManufactorerType
    {
        public int ManufactorerTypeId { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "ManufactorerTypeNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "ManufactorerTypeNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.ManufactorerType), ResourceType = typeof(Resources.Domain))]
        public string ManufactorerTypeName { get; set; }
    }
}
