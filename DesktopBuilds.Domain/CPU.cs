using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopBuilds.Domain
{
    public class CPU
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public float DefaultFrequency { get; set; }
        public float MaxFrequency { get; set; }
        public int Cache { get; set; }
    }
}
