#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Common;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EconConsumableUsableEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("CapitalCity")] [EnumMember(Value = "CapitalCity")] CapitalCity = 1,
        [XmlEnum("PVP")] [EnumMember(Value = "PVP")] Pvp = 2,
        [XmlEnum("Quest")] [EnumMember(Value = "Quest")] Quest = 3,
        [XmlEnum("SharedRegions")] [EnumMember(Value = "SharedRegions")] SharedRegions = 4
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EconConsumableTypeEnum
    {
        [XmlEnum("Client")] [EnumMember(Value = "Client")] Client = 0,
        [XmlEnum("Server")] [EnumMember(Value = "Server")] Server = 1
    }

    [JsonObject(Title = "consumable", Description = "")]
    [XmlRoot(ElementName = "consumable")]
    public class EconConsumableXml
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [DefaultValue(EconConsumableTypeEnum.Client)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "type")]
        public EconConsumableTypeEnum Type { get; set; } = EconConsumableTypeEnum.Client;

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public int RollOverTextId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [Required(AllowEmptyStrings = true)]
        [JsonProperty(PropertyName = "stackable", Required = Required.Always)]
        [XmlElement(ElementName = "stackable")]
        public string Stackable { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "stacksize", Required = Required.Always)]
        [XmlElement(ElementName = "stacksize")]
        public int StackSize { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "offertype", Required = Required.Always)]
        [XmlElement(ElementName = "offertype")]
        public EOfferTypeEnum OfferType { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)]
        [XmlElement(ElementName = "itemlevel")]
        public int ItemLevel { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsSellable { get; set; }

        /// <summary>
        ///     Use IsSellable Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "sellable", Required = Required.Always)]
        [XmlElement(ElementName = "sellable")]
        public string SellableStrDoNotUse
        {
            get => IsSellable ? "true" : "false";
            set => IsSellable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsTradeable { get; set; }

        /// <summary>
        ///     Use IsTradeable Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "tradeable", Required = Required.Always)]
        [XmlElement(ElementName = "tradeable")]
        public string TradeableStrDoNotUse
        {
            get => IsTradeable ? "true" : "false";
            set => IsTradeable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsDestroyable { get; set; }

        /// <summary>
        ///     Use IsDestroyable Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "destroyable", Required = Required.Always)]
        [XmlElement(ElementName = "destroyable")]
        public string DestroyableStrDoNotUse
        {
            get => IsDestroyable ? "true" : "false";
            set => IsDestroyable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "sellcostoverride", Required = Required.AllowNull)]
        [XmlElement(ElementName = "sellcostoverride")]
        public ItemCost SellCostOverride { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public CRarityEnum Rarity { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "power", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "power")]
        public string Power { get; set; }

        [Required]
        [JsonProperty(PropertyName = "civmatchingtype", Required = Required.Always)]
        [XmlElement(ElementName = "civmatchingtype")]
        public ECivilizationEnum CivMatchingType { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "charactermodifier", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "charactermodifier")]
        public string CharacterModifier { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "usable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "usable")]
        public HashSet<EconConsumableUsableEnum> Usable { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public HashSet<EAllianceEnum> Alliance { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;
    }

    [JsonObject(Title = "consumables", Description = "")]
    [XmlRoot(ElementName = "consumables")]
    public class EconConsumablesXml
    {
        [JsonProperty(PropertyName = "consumable", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, EconConsumableXml> Consumable { get; } =
            new Dictionary<string, EconConsumableXml>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Consumable Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "consumable")]
        public EconConsumableXml[] ConsumableArrayDoNotUse
        {
            get => Consumable.Values.ToArray();
            set
            {
                Consumable.Clear();
                if (value == null) return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Consumable.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static EconConsumablesXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<EconConsumablesXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}