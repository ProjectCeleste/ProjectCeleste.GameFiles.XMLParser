#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "gear", Description = "")]
    [XmlRoot(ElementName = "gear")]
    public class CraftSchoolGearXml
    {
        [JsonProperty(PropertyName = "stringid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "stringid")]
        public int StringId { get; set; }

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlText]
        public string Icon { get; set; }
    }

    [JsonObject(Title = "gearicons", Description = "")]
    [XmlRoot(ElementName = "gearicons")]
    public class CraftSchoolGearIconsXml
    {
        [JsonProperty(PropertyName = "gear", Required = Required.Always)]
        [XmlElement(ElementName = "gear")]
        public List<CraftSchoolGearXml> Gear { get; set; }
    }

    [JsonObject(Title = "items", Description = "")]
    [XmlRoot(ElementName = "items")]
    public class CraftSchoolItemsXml
    {
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "consumable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "consumable")]
        public HashSet<string> Consumable { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "advisor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "advisor")]
        public HashSet<string> Advisor { get; set; }
    }

    [JsonObject(Title = "school", Description = "")]
    [XmlRoot(ElementName = "school")]
    public class CraftSchoolXml : ICraftSchool
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "tag", Required = Required.Always)]
        [XmlElement(ElementName = "tag")]
        public CraftSchoolEnum Tag { get; set; }

        [JsonProperty(PropertyName = "displayname", Required = Required.Always)]
        [XmlElement(ElementName = "displayname")]
        public int DisplayName { get; set; }

        [JsonProperty(PropertyName = "description", Required = Required.Always)]
        [XmlElement(ElementName = "description")]
        public int Description { get; set; }

        [JsonProperty(PropertyName = "startingblueprint", Required = Required.Always)]
        [XmlElement(ElementName = "startingblueprint")]
        public string StartingBlueprint { get; set; }

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "gearicons", Required = Required.Always)]
        [XmlElement(ElementName = "gearicons")]
        public CraftSchoolGearIconsXml GearIcons { get; set; }

        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        [XmlElement(ElementName = "items")]
        public CraftSchoolItemsXml Items { get; set; }

        [JsonProperty(PropertyName = "design", Required = Required.Always)]
        [XmlElement(ElementName = "design")]
        public string Design { get; set; }

        [JsonProperty(PropertyName = "craftingsound", Required = Required.Always)]
        [XmlElement(ElementName = "craftingsound")]
        public string CraftingSound { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "allowedcapitals", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "allowedcapitals")]
        public CraftschoolAllowedCapitalsXml AllowedCapitals { get; set; }
    }

    [JsonObject(Title = "allowedcapitals", Description = "")]
    [XmlRoot(ElementName = "allowedcapitals")]
    public class CraftschoolAllowedCapitalsXml
    {
        [JsonProperty(PropertyName = "capital", Required = Required.Always)]
        [XmlElement(ElementName = "capital")]
        public string Capital { get; set; }
    }

    [JsonObject(Title = "craftschools", Description = "")]
    [XmlRoot(ElementName = "craftschools")]
    public class CraftSchoolsXml : DictionaryContainer<CraftSchoolEnum, CraftSchoolXml, ICraftSchool>, ICraftSchoolsXml
    {
        public CraftSchoolsXml() : base(key => key.Tag)
        {
        }

        [JsonConstructor]
        public CraftSchoolsXml(
            [JsonProperty(PropertyName = "school", Required = Required.Always)]
            IEnumerable<CraftSchoolXml> school) : base(school, key => key.Tag)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "school", Required = Required.Always)]
        [XmlElement(ElementName = "school")]
        public CraftSchoolXml[] SchoolArray
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Tag}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static ICraftSchoolsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<CraftSchoolsXml>(file);
        }
    }
}