using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopBuilds.Domain
{
    public class Ram
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Frequency { get; set; }
        public string Generation { get; set; }
    }
}
