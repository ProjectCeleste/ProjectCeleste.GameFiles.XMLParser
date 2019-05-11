﻿#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GamesFiles.XMLParser.Container;
using ProjectCeleste.GamesFiles.XMLParser.Enum;
using ProjectCeleste.GamesFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GamesFiles.XMLParser
{
    [JsonObject(Title = "consumable", Description = "")]
    [XmlRoot(ElementName = "consumable")]
    public class EconConsumableXml
    {
        public EconConsumableXml()
        {
            Event = EventEnum.None;
            Type = EconConsumableTypeEnum.Client;
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [DefaultValue(EconConsumableTypeEnum.Client)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "type")]
        public EconConsumableTypeEnum Type { get; set; }

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

        [Required]
        [JsonProperty(PropertyName = "sellable", Required = Required.Always)]
        [XmlIgnore]
        public bool IsSellable { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "sellable")]
        public string SellableStrDoNotUse
        {
            get => IsSellable ? "true" : "false";
            set => IsSellable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "tradeable", Required = Required.Always)]
        [XmlIgnore]
        public bool IsTradeable { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "tradeable")]
        public string TradeableStrDoNotUse
        {
            get => IsTradeable ? "true" : "false";
            set => IsTradeable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "destroyable", Required = Required.Always)]
        [XmlIgnore]
        public bool IsDestroyable { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "destroyable")]
        public string DestroyableStrDoNotUse
        {
            get => IsDestroyable ? "true" : "false";
            set => IsDestroyable = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "sellcostoverride", Required = Required.AllowNull)]
        [XmlElement(ElementName = "sellcostoverride")]
        public ItemCostXml SellCostOverride { get; set; }

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
        public EventEnum Event { get; set; }
    }

    [JsonObject(Title = "consumables", Description = "")]
    [XmlRoot(ElementName = "consumables")]
    public class EconConsumablesXml : DictionaryContainer<string, EconConsumableXml>
    {
        public EconConsumablesXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }
        
        [JsonConstructor]
        public EconConsumablesXml(
            [JsonProperty(PropertyName = "consumable", Required = Required.Always)]
            IEnumerable<EconConsumableXml> consumables) : base(consumables, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "consumable", Required = Required.Always)]
        [XmlElement(ElementName = "consumable")]
        public EconConsumableXml[] ConsumableArray
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                if (value == null) return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static EconConsumablesXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<EconConsumablesXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}