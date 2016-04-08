using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
