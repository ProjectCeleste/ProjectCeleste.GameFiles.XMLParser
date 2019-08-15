#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model.Common;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "material", Description = "")]
    [XmlRoot(ElementName = "material")]
    public class EconMaterialXml : IEconMaterial
    {
        [Required]
        [JsonProperty(PropertyName = "tradeable", Required = Required.Always)]
        [XmlElement(ElementName = "tradeable")]
        public bool Tradeable { get; set; }

        [Required]
        [JsonProperty(PropertyName = "destroyable", Required = Required.Always)]
        [XmlElement(ElementName = "destroyable")]
        public bool Destroyable { get; set; }

        [Required]
        [JsonProperty(PropertyName = "sellcostoverride", Required = Required.AllowNull)]
        [XmlElement(ElementName = "sellcostoverride")]
        public ItemCostXml SellCostOverride { get; set; }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

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
        [JsonProperty(PropertyName = "stackable", Required = Required.AllowNull)]
        [XmlElement(ElementName = "stackable")]
        public string Stackable { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "stacksize", Required = Required.Always)]
        [XmlElement(ElementName = "stacksize")]
        public int StackSize { get; set; }

        [Required]
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
        [XmlElement(ElementName = "sellable")]
        public bool Sellable { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        IItemCost IEconMaterial.SellCostOverride => SellCostOverride;

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public CRarityEnum Rarity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "budgetcost", Required = Required.Always)]
        [XmlElement(ElementName = "budgetcost")]
        public int BudgetCost { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "contentpack", Required = Required.Always)]
        [XmlElement(ElementName = "contentpack")]
        public int ContentPack { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;

        [DefaultValue(EAllianceEnum.None)]
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

    [JsonObject(Title = "materials", Description = "")]
    [XmlRoot(ElementName = "materials")]
    public class EconMaterialsXml : DictionaryContainer<string, EconMaterialXml, IEconMaterial>, IEconMaterialsXml
    {
        public EconMaterialsXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconMaterialsXml(
            [JsonProperty(PropertyName = "material", Required = Required.Always)]
            IEnumerable<EconMaterialXml> materials) : base(materials, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "material", Required = Required.Always)]
        [XmlElement(ElementName = "material")]
        public EconMaterialXml[] MaterialArray
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
            this.ToXmlFile(file);
        }

        public static IEconMaterialsXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<EconMaterialsXml>(file);
        }
    }
}