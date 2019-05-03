#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "gear", Description = "")]
    [XmlRoot(ElementName = "gear")]
    public class CraftSchoolGearXml
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "stringid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "stringid")]
        public int StringId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlText]
        public string Icon { get; set; }
    }

    [JsonObject(Title = "gearicons", Description = "")]
    [XmlRoot(ElementName = "gearicons")]
    public class CraftSchoolGearIconsXml
    {
        [Required]
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
    public class CraftSchoolXml
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
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

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "startingblueprint", Required = Required.Always)]
        [XmlElement(ElementName = "startingblueprint")]
        public string StartingBlueprint { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [Required]
        [JsonProperty(PropertyName = "gearicons", Required = Required.Always)]
        [XmlElement(ElementName = "gearicons")]
        public CraftSchoolGearIconsXml GearIcons { get; set; }

        [Required]
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        [XmlElement(ElementName = "items")]
        public CraftSchoolItemsXml Items { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "design", Required = Required.Always)]
        [XmlElement(ElementName = "design")]
        public string Design { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "craftingsound", Required = Required.Always)]
        [XmlElement(ElementName = "craftingsound")]
        public string CraftingSound { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "allowedcapitals", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "allowedcapitals")]
        public CraftschoolAllowedCapitalsXml AllowedCapitals { get; set; }
    }

    [JsonObject(Title = "trait", Description = "")]
    [XmlRoot(ElementName = "allowedcapitals")]
    public class CraftschoolAllowedCapitalsXml
    {
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "capital", Required = Required.Always)]
        [XmlElement(ElementName = "capital")]
        public string Capital { get; set; }
    }

    [JsonObject(Title = "craftschools", Description = "")]
    [XmlRoot(ElementName = "craftschools")]
    public class CraftSchoolsXml
    {
        public CraftSchoolsXml()
        {
            School = new Dictionary<CraftSchoolEnum, CraftSchoolXml>();
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<CraftSchoolEnum, CraftSchoolXml> School { get; }

        /// <summary>
        ///     Use School Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "school", Required = Required.Always)]
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

        public static CraftSchoolsXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<CraftSchoolsXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}