using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ModelSerieType
    {
        public int ModelSerieTypeId { get; set; }
        [Required]
        [MaxLength(128, ErrorMessageResourceName = "ModelSerieTypeNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "ModelSerieTypeNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.ModelSerieType), ResourceType = typeof(Resources.Domain))]
        public string ModelSerieTypeName { get; set; }
    }
}
