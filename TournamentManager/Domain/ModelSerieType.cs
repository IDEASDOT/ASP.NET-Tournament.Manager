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
        [Required, MaxLength(64)]
        public string ModelSerieTypeName { get; set; }
    }
}
