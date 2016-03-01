using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Manufactorer
    {
        public int ManufactorerId { get; set; }
        [Required, MaxLength(64)]
        public string ManufactorerName { get; set; }
    }
}
