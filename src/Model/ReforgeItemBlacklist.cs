using ProjectCeleste.GameFiles.XMLParser.Helpers;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [XmlRoot(ElementName = "ReforgeBlacklistTrait")]
    public class ReforgeBlacklistTrait
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "ReforgeItemBlacklist")]
    public class ReforgeItemBlacklist
    {
        [XmlElement(ElementName = "ReforgeBlacklistTrait")]
        public List<ReforgeBlacklistTrait> ReforgeBlacklistTrait { get; set; }

        public static ReforgeItemBlacklist FomXmlFile(string xmlLocation)
        {
            return XmlUtils.FromXmlFile<ReforgeItemBlacklist>(xmlLocation);
        }
    }
}
