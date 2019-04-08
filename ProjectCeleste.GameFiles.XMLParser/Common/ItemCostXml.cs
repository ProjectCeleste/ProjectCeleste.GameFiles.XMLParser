#region Using directives

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Common
{
    [JsonObject(Title = "gamecurrency", Description = "")]
    [XmlRoot(ElementName = "gamecurrency")]
    public class ItemCostGameCurrency
    {
        public ItemCostGameCurrency()
        {
        }

        [JsonConstructor]
        public ItemCostGameCurrency(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] GameCurrencyTypeEnum type,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] double quantity)
        {
            Type = type;
            Quantity = quantity;
        }

        [Required]
        [Range(0, double.MaxValue)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public double Quantity { get; set; }

        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlText]
        public GameCurrencyTypeEnum Type { get; set; }
    }

    [JsonObject(Title = "capitalresource", Description = "")]
    [XmlRoot(ElementName = "capitalresource")]
    public class ItemCostCapitalResource
    {
        public ItemCostCapitalResource()
        {
        }

        [JsonConstructor]
        public ItemCostCapitalResource(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] CapitalResourceTypeEnum type,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] double quantity)
        {
            Type = type;
            Quantity = quantity;
        }

        [Required]
        [Range(0, double.MaxValue)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public double Quantity { get; set; }

        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlText]
        public CapitalResourceTypeEnum Type { get; set; }
    }

    [JsonObject(Title = "Cost", Description = "")]
    [XmlRoot(ElementName = "Cost")]
    public class ItemCost
    {
        public ItemCost()
        {
            CapitalResource = null;
            GameCurrency = null;
        }

        public ItemCost(CapitalResourceTypeEnum capitalResource, double quantity)
        {
            CapitalResource = new ItemCostCapitalResource(capitalResource, quantity);
            GameCurrency = null;
        }

        public ItemCost(GameCurrencyTypeEnum gameCurrency, double quantity)
        {
            CapitalResource = null;
            GameCurrency = new ItemCostGameCurrency(gameCurrency, quantity);
        }

        [JsonConstructor]
        public ItemCost(
            [JsonProperty(PropertyName = "capitalresource", DefaultValueHandling = DefaultValueHandling.Ignore)]
            ItemCostCapitalResource capitalResource,
            [JsonProperty(PropertyName = "gamecurrency", DefaultValueHandling = DefaultValueHandling.Ignore)]
            ItemCostGameCurrency gameCurrency)
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
        public ItemCostCapitalResource CapitalResource { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "gamecurrency", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "gamecurrency")]
        public ItemCostGameCurrency GameCurrency { get; set; }
    }
}