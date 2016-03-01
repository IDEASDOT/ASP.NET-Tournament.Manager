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
        [Required, MaxLength(64)]
        public string ManufactorerTypeName { get; set; }
    }
}
