#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "protounit")]
    public class ProtoDataXmlProtounit
    {
        [XmlElement(ElementName = "ismaininventory")]
        public string IsMainInventory { get; set; }

        [XmlElement(ElementName = "numinventoryslots")]
        public int NumInventorySlots { get; set; }

        [XmlElement(ElementName = "buildinglimittype")]
        public string BuildingLimitType { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "maxstacksize")]
        public int MaxStackSize { get; set; }
    }


    [XmlRoot(ElementName = "protodata")]
    public class ProtoDataXml
    {
        [XmlIgnore]
        public Dictionary<string, ProtoDataXmlProtounit> ProtoUnit { get; } =
            new Dictionary<string, ProtoDataXmlProtounit>(StringComparer.OrdinalIgnoreCase);

        [XmlElement(ElementName = "protounit")]
        public ProtoDataXmlProtounit[] List
        {
            get => ProtoUnit.Values.ToArray();
            set
            {
                ProtoUnit.Clear();
                if (value == null) return;
                foreach (var item in value)
                    ProtoUnit.Add(item.Name, item);
            }
        }

        public static ProtoDataXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<ProtoDataXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}