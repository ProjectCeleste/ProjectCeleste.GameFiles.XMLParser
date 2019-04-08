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

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "Cost")]
    public class TechTreeXmCost
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "resourcetype", Required = Required.Always)]
        [XmlAttribute(AttributeName = "resourcetype")]
        public ResourceTypeFixEnum ResourceType { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        [XmlText]
        public double Value { get; set; }
    }

    [XmlRoot(ElementName = "Effect")]
    public class TechTreeXmEffect
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlElement(ElementName = "Target")]
        public TechTreeXmlEffectTarget Target { get; set; }

        [XmlAttribute(AttributeName = "amount")]
        public string Amount { get; set; }

        [XmlAttribute(AttributeName = "scaling")]
        public string Scaling { get; set; }

        [XmlAttribute(AttributeName = "subtype")]
        public string Subtype { get; set; }

        [XmlAttribute(AttributeName = "allactions")]
        public string Allactions { get; set; }

        [XmlAttribute(AttributeName = "relativity")]
        public string Relativity { get; set; }

        [XmlAttribute(AttributeName = "action")]
        public string Action { get; set; }

        [XmlAttribute(AttributeName = "unittype")]
        public string Unittype { get; set; }

        [XmlAttribute(AttributeName = "damagetype")]
        public string Damagetype { get; set; }

        [XmlAttribute(AttributeName = "proto")]
        public string Proto { get; set; }

        [XmlAttribute(AttributeName = "culture")]
        public string Culture { get; set; }

        [XmlAttribute(AttributeName = "newName")]
        public string NewName { get; set; }

        [XmlAttribute(AttributeName = "resource")]
        public string Resource { get; set; }

        [XmlAttribute(AttributeName = "component")]
        public string Component { get; set; }

        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
    }

    [XmlRoot(ElementName = "Target")]
    public class TechTreeXmlEffectTarget
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Effects")]
    public class TechTreeXmlEffects
    {
        [XmlElement(ElementName = "Effect")]
        public List<TechTreeXmEffect> Effect { get; set; }
    }

    [XmlRoot(ElementName = "TechStatus")]
    public class TechTreeXmlPreReqsTechStatus
    {
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Prereqs")]
    public class TechTreeXmlPreReqs
    {
        [XmlElement(ElementName = "TechStatus")]
        public List<TechTreeXmlPreReqsTechStatus> TechStatus { get; set; }

        [XmlElement(ElementName = "SpecificAge")]
        public string SpecificAge { get; set; }

        [XmlElement(ElementName = "TypeCount")]
        public TechTreeXmlPreReqsTypeCount TypeCount { get; set; }
    }

    [XmlRoot(ElementName = "TypeCount")]
    public class TechTreeXmlPreReqsTypeCount
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }

        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }

        [XmlAttribute(AttributeName = "operator")]
        public string Operator { get; set; }
    }

    [XmlRoot(ElementName = "Tech")]
    public class TechTreeXmlTech
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DBID", Required = Required.Always)]
        [XmlElement(ElementName = "DBID")]
        public int Dbid { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DisplayNameID", Required = Required.Always)]
        [XmlElement(ElementName = "DisplayNameID")]
        public string DisplayNameId { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Cost", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlIgnore]
        public Dictionary<ResourceTypeFixEnum, TechTreeXmCost> Cost { get; set; }

        /// <summary>
        ///     Use Cost Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue(null)]
        [JsonIgnore]
        [XmlElement(ElementName = "Cost")]
        public TechTreeXmCost[] TechArrayDoNotUse
        {
            get => Cost?.Count > 0 ? Cost.Values.ToArray() : null;
            set
            {
                if (value == null)
                {
                    Cost = null;
                    return;
                }

                if (Cost == null)
                    Cost = new Dictionary<ResourceTypeFixEnum, TechTreeXmCost>();
                else
                    Cost.Clear();

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Cost.Add(item.ResourceType, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.ResourceType}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "ResearchPoints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ResearchPoints")]
        public double ResearchPoints { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "Status", Required = Required.Always)]
        [XmlElement(ElementName = "Status")]
        public TechStatusEnumUpper Status { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "Icon", Required = Required.Always)]
        [XmlElement(ElementName = "Icon")]
        public string Icon { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "RolloverTextID", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "RolloverTextID")]
        public int RolloverTextId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "ContentPack", Required = Required.Always)]
        [XmlElement(ElementName = "ContentPack")]
        public int ContentPack { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Flag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Flag")]
        public HashSet<string> Flag { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Effects", Required = Required.Always)]
        [XmlElement(ElementName = "Effects")]
        public TechTreeXmlEffects Effects { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Prereqs", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Prereqs")]
        public TechTreeXmlPreReqs PreReqs { get; set; }
    }

    [XmlRoot(ElementName = "TechTree")]
    public class TechTreeXml
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "version", Required = Required.Always)]
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Tech", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, TechTreeXmlTech> Tech { get; } =
            new Dictionary<string, TechTreeXmlTech>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Tech Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "Tech")]
        public TechTreeXmlTech[] TechArrayDoNotUse
        {
            get => Tech.Values.ToArray();
            set
            {
                Tech.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Tech.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static TechTreeXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<TechTreeXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}