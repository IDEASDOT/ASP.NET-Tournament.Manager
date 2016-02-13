using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ComputerSpecification
    {

        //Primary key
        public int CompSpecId { get; set; }

        //Computer Specifications
        public string ProcessorName { get; set; }
        public string GraphicName { get; set; }
        public string StorageName { get; set; }
        public string RamName { get; set; }
        public string OsName { get; set; }

        //Mouse&Keyboard&Headset Specifications
        public string MouseName { get; set; }
        public string MousePadName { get; set; }
        public string HeadsetName { get; set; }
        public string KeyboardName { get; set; }

        //One computerspec one player
        public virtual Player Player { get; set; }


    }
}
