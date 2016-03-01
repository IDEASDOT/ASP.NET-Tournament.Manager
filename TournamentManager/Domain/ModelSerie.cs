using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ModelSerie
    {
        public int ModelSerieId { get; set; }
        [Required, MaxLength(64)]
        public string ModelSerieName { get; set; }
    }
}
