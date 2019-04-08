#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "gear")]
    public class CraftSchoolXmlGear
    {
        [XmlAttribute(AttributeName = "stringid")]
        public string Stringid { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gearicons")]
    public class CraftschoolXmlGearIcons
    {
        [XmlElement(ElementName = "gear")]
        public List<CraftSchoolXmlGear> Gear { get; set; }
    }

    [XmlRoot(ElementName = "items")]
    public class CraftSchoolXmlItems
    {
        [XmlElement(ElementName = "consumable")]
        public List<string> Consumable { get; set; }

        [XmlElement(ElementName = "advisor")]
        public List<string> Advisor { get; set; }
    }

    [XmlRoot(ElementName = "school")]
    public class CraftSchoolXml
    {
        [XmlElement(ElementName = "tag")]
        public string Tag { get; set; }

        [XmlElement(ElementName = "displayname")]
        public string Displayname { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "startingblueprint")]
        public string StartingBlueprint { get; set; }

        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [XmlElement(ElementName = "gearicons")]
        public CraftschoolXmlGearIcons Gearicons { get; set; }

        [XmlElement(ElementName = "items")]
        public CraftSchoolXmlItems Items { get; set; }

        [XmlElement(ElementName = "design")]
        public string Design { get; set; }

        [XmlElement(ElementName = "craftingsound")]
        public string Craftingsound { get; set; }

        [XmlElement(ElementName = "allowedcapitals")]
        public CraftschoolXmlAllowedCapitals Allowedcapitals { get; set; }
    }

    [XmlRoot(ElementName = "allowedcapitals")]
    public class CraftschoolXmlAllowedCapitals
    {
        [XmlElement(ElementName = "capital")]
        public string Capital { get; set; }
    }

    [XmlRoot(ElementName = "craftschools")]
    public class CraftSchoolsXml
    {
        /// <summary>
        ///     Use Trait Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, CraftSchoolXml> School { get; } =
            new Dictionary<string, CraftSchoolXml>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use School Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [XmlElement(ElementName = "school")]
        public CraftSchoolXml[] SchoolArrayDoNotUse
        {
            get => School.Values.ToArray();
            set
            {
                School.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        School.Add(item.Tag, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Tag}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static CraftSchoolsXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<CraftSchoolsXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}