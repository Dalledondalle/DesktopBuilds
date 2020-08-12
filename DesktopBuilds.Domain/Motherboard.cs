using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopBuilds.Domain
{
    public class Motherboard
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Socket { get; set; }
        public int PCIEx16Count { get; set; }
        public int PCIExCount { get; set; }
        public int PCICount { get; set; }
    }
}
