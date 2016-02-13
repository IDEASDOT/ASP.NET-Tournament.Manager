using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GameSpecification
    {
        public int GameSpecId { get; set; }

        public int DpiValue { get; set; }

        public int SensitivityValue { get; set; }

        public virtual Player Player { get; set; }

    }
}
