#region Using directives

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Model.Common
{
    [JsonObject(Title = "gamecurrency", Description = "")]
    [XmlRoot(ElementName = "gamecurrency")]
    public class ItemCostGameCurrencyXml : IItemCostGameCurrency
    {
        public ItemCostGameCurrencyXml()
        {
        }

        [JsonConstructor]
        public ItemCostGameCurrencyXml(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] GameCurrencyTypeEnum type,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] double quantity)
        {
            Type = type;
            Quantity = quantity;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlText]
        public GameCurrencyTypeEnum Type { get; set; }

        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public double Quantity { get; set; }
    }

    [JsonObject(Title = "capitalresource", Description = "")]
    [XmlRoot(ElementName = "capitalresource")]
    public class ItemCostCapitalResourceXml : IItemCostCapitalResource
    {
        public ItemCostCapitalResourceXml()
        {
        }

        [JsonConstructor]
        public ItemCostCapitalResourceXml(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] CapitalResourceTypeEnum type,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] double quantity)
        {
            Type = type;
            Quantity = quantity;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlText]
        public CapitalResourceTypeEnum Type { get; set; }

        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public double Quantity { get; set; }
    }

    [JsonObject(Title = "Cost", Description = "")]
    [XmlRoot(ElementName = "Cost")]
    public class ItemCostXml : IItemCost
    {
        public ItemCostXml()
        {
            CapitalResource = null;
            GameCurrency = null;
        }

        public ItemCostXml(IItemCost cost)
        {
            CapitalResource = cost?.CapitalResource?.Quantity >= 0
                ? new ItemCostCapitalResourceXml(cost.CapitalResource.Type, cost.CapitalResource.Quantity)
                : null;
            GameCurrency = cost?.GameCurrency?.Quantity >= 0
                ? new ItemCostGameCurrencyXml(cost.GameCurrency.Type, cost.GameCurrency.Quantity)
                : null;

            if (CapitalResource == null && GameCurrency == null)
                throw new ArgumentOutOfRangeException();

            if (CapitalResource != null && GameCurrency != null)
                throw new ArgumentOutOfRangeException();
        }

        public ItemCostXml(CapitalResourceTypeEnum capitalResource, double quantity)
        {
            CapitalResource = new ItemCostCapitalResourceXml(capitalResource, quantity);
            GameCurrency = null;
        }

        public ItemCostXml(GameCurrencyTypeEnum gameCurrency, double quantity)
        {
            CapitalResource = null;
            GameCurrency = new ItemCostGameCurrencyXml(gameCurrency, quantity);
        }

        [JsonConstructor]
        public ItemCostXml(
            [JsonProperty(PropertyName = "capitalresource", DefaultValueHandling = DefaultValueHandling.Ignore)]
            ItemCostCapitalResourceXml capitalResource,
            [JsonProperty(PropertyName = "gamecurrency", DefaultValueHandling = DefaultValueHandling.Ignore)]
            ItemCostGameCurrencyXml gameCurrency)
        {
            if (capitalResource == null && gameCurrency == null)
                throw new ArgumentNullException();

            if (capitalResource != null && gameCurrency != null)
                throw new ArgumentOutOfRangeException();

            CapitalResource = capitalResource;
            GameCurrency = gameCurrency;
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "capitalresource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "capitalresource")]
        public ItemCostCapitalResourceXml CapitalResource { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "gamecurrency", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "gamecurrency")]
        public ItemCostGameCurrencyXml GameCurrency { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        IItemCostCapitalResource IItemCost.CapitalResource => CapitalResource;

        [XmlIgnore]
        [JsonIgnore]
        IItemCostGameCurrency IItemCost.GameCurrency => GameCurrency;
    }
}