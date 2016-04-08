﻿using System;
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
        [MaxLength(128, ErrorMessageResourceName = "ModelSerieNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "ModelSerieNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.ModelSerie), ResourceType = typeof(Resources.Domain))]
        public string ModelSerieName { get; set; }
    }
}
