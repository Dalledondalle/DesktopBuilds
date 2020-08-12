using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopBuilds.Domain
{
    public class Desktop
    {
        [XmlIgnore]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public CPU CPU { get; set; }
        public GraphicCard GraphicCard { get; set; }
        public Ram Ram { get; set; }
        public Motherboard Motherboard { get; set; }
    }
}
