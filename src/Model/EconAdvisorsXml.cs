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
using ProjectCeleste.GameFiles.XMLParser.Model.Common;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "techs", Description = "")]
    [XmlRoot(ElementName = "techs")]
    public class EconAdvisorTechsXml
    {
        public EconAdvisorTechsXml()
        {
        }

        [JsonConstructor]
        public EconAdvisorTechsXml([JsonProperty(PropertyName = "tech", Required = Required.Always)] string tech)
        {
            if (string.IsNullOrWhiteSpace(tech))
                throw new ArgumentNullException(nameof(tech));

            Tech = tech;
        }

        [JsonProperty(PropertyName = "tech", Required = Required.Always)]
        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }
    }

    [JsonObject(Title = "advisor", Description = "")]
    [XmlRoot(ElementName = "advisor")]
    public class EconAdvisorXml : IEconAdvisor
    {
        [JsonProperty(PropertyName = "displaydescriptionid", Required = Required.Always)]
        [XmlElement(ElementName = "displaydescriptionid")]
        public int DisplayDescriptionId { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "shortdescriptionid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "shortdescriptionid")]
        public int ShortDescriptionId { get; set; }

        [JsonProperty(PropertyName = "sellcostoverride", Required = Required.AllowNull)]
        [XmlElement(ElementName = "sellcostoverride")]
        public ItemCostXml SellCostOverride { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "groupid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "groupid")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "age", Required = Required.Always)]
        [XmlElement(ElementName = "age")]
        public int Age { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public RarityEnum Rarity { get; set; }

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "icontexturecoords", Required = Required.Always)]
        [XmlElement(ElementName = "icontexturecoords")]
        public string IconTextureCoords { get; set; }

        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public string RollOverTextId { get; set; }

        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        IItemCost IEconAdvisor.SellCostOverride => SellCostOverride;

        [JsonProperty(PropertyName = "minlevel", Required = Required.Always)]
        [XmlElement(ElementName = "minlevel")]
        public int Minlevel { get; set; }

        [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)]
        [XmlElement(ElementName = "itemlevel")]
        public int ItemLevel { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "offertype", Required = Required.Always)]
        [XmlElement(ElementName = "offertype")]
        public EOfferTypeEnum OfferType { get; set; }

        [JsonProperty(PropertyName = "techs", Required = Required.Always)]
        [XmlElement(ElementName = "techs")]
        public EconAdvisorTechsXml Techs { get; set; }

        [JsonProperty(PropertyName = "sellable", Required = Required.Always)]
        [XmlElement(ElementName = "sellable")]
        public bool Sellable { get; set; } = true;

        [JsonProperty(PropertyName = "tradeable", Required = Required.Always)]
        [XmlElement(ElementName = "tradeable")]
        public bool Tradeable { get; set; } = true;

        [JsonProperty(PropertyName = "destroyable", Required = Required.Always)]
        [XmlElement(ElementName = "destroyable")]
        public bool Destroyable { get; set; } = true;

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "specialborder", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "specialborder")]
        public bool IsSpecialBorder { get; set; }

        [DefaultValue(ECivilizationEnum.Any)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "civilization", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "civilization")]
        public ECivilizationEnum Civilization { get; set; } = ECivilizationEnum.Any;

        [DefaultValue(EventEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;

        [DefaultValue(EAllianceEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; } = EAllianceEnum.None;

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

    [JsonObject(Title = "advisors", Description = "")]
    [XmlRoot(ElementName = "advisors")]
    public class EconAdvisorsXml : DictionaryContainer<string, EconAdvisorXml, IEconAdvisor>, IEconAdvisorsXml
    {
        public EconAdvisorsXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconAdvisorsXml(
            [JsonProperty(PropertyName = "advisor", Required = Required.Always)] IEnumerable<EconAdvisorXml> advisor) :
            base(advisor, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "advisor", Required = Required.Always)]
        [XmlElement(ElementName = "advisor")]
        public EconAdvisorXml[] AdvisorArray
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

        public static IEconAdvisorsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<EconAdvisorsXml>(file);
        }
    }
}