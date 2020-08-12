using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DesktopBuilds.Domain
{
    public class GraphicCard
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public int Memory { get; set; }
        public int Frequency { get; set; }
    }
}
