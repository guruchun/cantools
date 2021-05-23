using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace FcpUtils
{
    [XmlRoot("memMap")]
    public class MemoryMap
    {
        public class AddressGroup
        {
            [XmlAttribute("type")]
            public string RegType { get; set; }
            [XmlAttribute("section")]
            public string Section { get; set; }
            [XmlAttribute("baseAddress")]
            public int BaseAddress { get; set; }

            [XmlElement("register")]
            public List<AddressInfo> Register { get; set; }

            public AddressGroup()
            {
                Register = new List<AddressInfo>();
            }
        }
        public class AddressInfo
        {
            [XmlAttribute("address")]
            public int Address { get; set; }
            [XmlAttribute("access")]
            public string Access { get; set; }
            [XmlAttribute("tag")]
            public string Tag { get; set; }
            [XmlAttribute("value")]
            public string Value { get; set; }
            [XmlAttribute("scale")]
            public int Scale { get; set; }
            [XmlAttribute("unit")]
            public string Unit { get; set; }
            [XmlAttribute("dataType")]
            public string DataType { get; set; }
            [XmlAttribute("format")]
            public string Format { get; set; }
            [XmlAttribute("description")]
            public string Description { get; set; }

            public AddressInfo()
            {
                this.Tag = "";
                this.Description = "";
                this.Value = "";
                this.Scale = 1;
            }
        }

        //[XmlArrayItem(ElementName = "registers")]
        [XmlElement]
        public List<AddressGroup> registers = new List<AddressGroup>();
    }
}
