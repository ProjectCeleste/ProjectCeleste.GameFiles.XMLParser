﻿#region Using directives

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
using ProjectCeleste.GameFiles.XMLParser.Model.Common;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "consumable", Description = "")]
    [XmlRoot(ElementName = "consumable")]
    public class EconConsumableXml : IEconConsumable
    {
        public EconConsumableXml()
        {
            Event = EventEnum.None;
            Type = EconConsumableTypeEnum.Client;
        }

        [JsonProperty(PropertyName = "tradeable", Required = Required.Always)]
        [XmlElement(ElementName = "tradeable")]
        public bool Tradeable { get; set; } = true;

        [JsonProperty(PropertyName = "destroyable", Required = Required.Always)]
        [XmlElement(ElementName = "destroyable")]
        public bool Destroyable { get; set; } = true;

        [JsonProperty(PropertyName = "sellcostoverride", Required = Required.AllowNull)]
        [XmlElement(ElementName = "sellcostoverride")]
        public ItemCostXml SellCostOverride { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [DefaultValue(EconConsumableTypeEnum.Client)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "type")]
        public EconConsumableTypeEnum Type { get; set; }

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public int RollOverTextId { get; set; }

        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [JsonProperty(PropertyName = "stackable", Required = Required.Always)]
        [XmlElement(ElementName = "stackable")]
        public string Stackable { get; set; }

        [JsonProperty(PropertyName = "stacksize", Required = Required.Always)]
        [XmlElement(ElementName = "stacksize")]
        public int StackSize { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "offertype", Required = Required.Always)]
        [XmlElement(ElementName = "offertype")]
        public EOfferTypeEnum OfferType { get; set; }

        [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)]
        [XmlElement(ElementName = "itemlevel")]
        public int ItemLevel { get; set; }

        [JsonProperty(PropertyName = "sellable", Required = Required.Always)]
        [XmlElement(ElementName = "sellable")]
        public bool Sellable { get; set; } = true;

        [JsonIgnore]
        [XmlIgnore]
        IItemCost IEconConsumable.SellCostOverride => SellCostOverride;

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public CRarityEnum Rarity { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "power", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "power")]
        public string Power { get; set; }

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

        public void SetSellCostOverride(CapitalResourceTypeEnum type, double amount)
        {
            SellCostOverride = new ItemCostXml(type, amount);
        }

        public void SetSellCostOverride(GameCurrencyTypeEnum type, double amount)
        {
            SellCostOverride = new ItemCostXml(type, amount);
        }

        public void RemoveSellCostOverride()
        {
            SellCostOverride = null;
        }

        public void SetSellCostOverride(IItemCost cost)
        {
            if (cost == null)
                RemoveSellCostOverride();
            else if (cost.CapitalResource?.Quantity >= 0)
                SetSellCostOverride(cost.CapitalResource.Type, cost.CapitalResource.Quantity);
            else if (cost.GameCurrency?.Quantity >= 0)
                SetSellCostOverride(cost.GameCurrency.Type, cost.GameCurrency.Quantity);
            else
                throw new ArgumentException("Invalid Cost ", nameof(cost));
        }
    }

    [JsonObject(Title = "consumables", Description = "")]
    [XmlRoot(ElementName = "consumables")]
    public class EconConsumablesXml : DictionaryContainer<string, EconConsumableXml, IEconConsumable>,
        IEconConsumablesXml
    {
        public EconConsumablesXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconConsumablesXml(
            [JsonProperty(PropertyName = "consumable", Required = Required.Always)]
            IEnumerable<EconConsumableXml> consumables) : base(consumables, key => key.Name,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                        if (!Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static IEconConsumablesXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<EconConsumablesXml>(file);
        }
    }
}