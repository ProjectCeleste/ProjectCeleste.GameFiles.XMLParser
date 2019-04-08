#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Common;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "techs", Description = "")]
    [XmlRoot(ElementName = "techs")]
    public class EconAdvisorXmlTechs
    {
        public EconAdvisorXmlTechs()
        {
        }

        [JsonConstructor]
        public EconAdvisorXmlTechs([JsonProperty(PropertyName = "tech", Required = Required.Always)] string tech)
        {
            if (string.IsNullOrWhiteSpace(tech))
                throw new ArgumentNullException(nameof(tech));

            Tech = tech;
        }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "tech", Required = Required.Always)]
        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }
    }

    [JsonObject(Title = "advisor", Description = "")]
    [XmlRoot(ElementName = "advisor")]
    public class EconAdvisorXml
    {
        [Key]
        [Required]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "groupid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "groupid")]
        public int GroupId { get; set; }

        [Required]
        [Range(0, 3)]
        [JsonProperty(PropertyName = "age", Required = Required.Always)]
        [XmlElement(ElementName = "age")]
        public int Age { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public RarityEnum Rarity { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "icontexturecoords", Required = Required.Always)]
        [XmlElement(ElementName = "icontexturecoords")]
        public string IconTextureCoords { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public string RollOverTextId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displaydescriptionid", Required = Required.Always)]
        [XmlElement(ElementName = "displaydescriptionid")]
        public int DisplayDescriptionId { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "shortdescriptionid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "shortdescriptionid")]
        public string ShortDescriptionId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "sellcostoverride", Required = Required.AllowNull)]
        [XmlElement(ElementName = "sellcostoverride")]
        public ItemCost SellCostOverride { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "minlevel", Required = Required.Always)]
        [XmlElement(ElementName = "minlevel")]
        public int Minlevel { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)]
        [XmlElement(ElementName = "itemlevel")]
        public int ItemLevel { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "offertype", Required = Required.Always)]
        [XmlElement(ElementName = "offertype")]
        public EOfferTypeEnum OfferType { get; set; }

        [Required]
        [JsonProperty(PropertyName = "techs", Required = Required.Always)]
        [XmlElement(ElementName = "techs")]
        public EconAdvisorXmlTechs Techs { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsSellable { get; set; } = true;

        /// <summary>
        ///     Use IsSellable Bool Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "sellable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "sellable")]
        public string SellableStrDoNotUse
        {
            get => IsSellable ? "true" : "false";
            set => IsSellable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsTradeable { get; set; } = true;

        /// <summary>
        ///     Use IsTradeable Bool Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "tradeable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "tradeable")]
        public string TradeableStrDoNotUse
        {
            get => IsTradeable ? "true" : "false";
            set => IsTradeable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsDestroyable { get; set; } = true;

        /// <summary>
        ///     Use IsDestroyable Bool Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "destroyable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "destroyable")]
        public string DestroyableStrDoNotUse
        {
            get => IsDestroyable ? "true" : "false";
            set => IsDestroyable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsSpecialBorder { get; set; }

        /// <summary>
        ///     Use IsSpecialBorder Bool Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue("false")]
        [JsonProperty(PropertyName = "specialborder", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "specialborder")]
        public string SpecialBorderStrDoNotUse
        {
            get => IsSpecialBorder ? "true" : "false";
            set => IsSpecialBorder = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [DefaultValue(ECivilizationEnum.Any)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "civilization", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "civilization")]
        public ECivilizationEnum Civilization { get; set; } = ECivilizationEnum.Any;


        [DefaultValue(EventEnum.None)]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;

        [DefaultValue(EAllianceEnum.None)]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; } = EAllianceEnum.None;
    }

    [JsonObject(Title = "advisors", Description = "")]
    [XmlRoot(ElementName = "advisors")]
    public class EconAdvisorsXml
    {
        [Required]
        [JsonProperty(PropertyName = "advisor", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, EconAdvisorXml> Advisor { get; } =
            new Dictionary<string, EconAdvisorXml>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Advisor Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "advisor")]
        public EconAdvisorXml[] AdvisorArrayDoNotUse
        {
            get => Advisor.Values.ToArray();
            set
            {
                Advisor.Clear();
                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Advisor.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static EconAdvisorsXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<EconAdvisorsXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}