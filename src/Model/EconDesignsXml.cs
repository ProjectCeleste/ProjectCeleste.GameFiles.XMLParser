#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
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
    [JsonObject(Title = "output", Description = "")]
    [XmlRoot(ElementName = "output")]
    public class EconDesignXmlOutput
    {
        public EconDesignXmlOutput()
        {
        }

        public EconDesignXmlOutput(EconDesignXmlTrait trait)
        {
            Trait = trait;
        }

        public EconDesignXmlOutput(EconDesignXmlConsumable consumable)
        {
            Consumable = consumable;
        }

        public EconDesignXmlOutput(EconDesignXmlMaterial material)
        {
            Material = material;
        }

        public EconDesignXmlOutput(EconDesignXmlBlueprint blueprint)
        {
            Blueprint = blueprint;
        }

        public EconDesignXmlOutput(EconDesignXmlAdvisor advisor)
        {
            Advisor = advisor;
        }

        [JsonConstructor]
        public EconDesignXmlOutput(
            [JsonProperty(PropertyName = "material", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignXmlMaterial material,
            [JsonProperty(PropertyName = "trait", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignXmlTrait trait,
            [JsonProperty(PropertyName = "consumable", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignXmlConsumable consumable,
            [JsonProperty(PropertyName = "advisor", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignXmlAdvisor advisor,
            [JsonProperty(PropertyName = "blueprint", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignXmlBlueprint blueprint)
        {
            Trait = trait;
            Consumable = consumable;
            Material = material;
            Advisor = advisor;
            Blueprint = blueprint;
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "material", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "material")]
        public EconDesignXmlMaterial Material { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "trait", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "trait")]
        public EconDesignXmlTrait Trait { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "consumable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "consumable")]
        public EconDesignXmlConsumable Consumable { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "advisor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "advisor")]
        public EconDesignXmlAdvisor Advisor { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "blueprint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "blueprint")]
        public EconDesignXmlBlueprint Blueprint { get; set; }
    }

    [JsonObject(Title = "blueprint", Description = "")]
    [XmlRoot(ElementName = "blueprint")]
    public class EconDesignXmlBlueprint
    {
        public EconDesignXmlBlueprint()
        {
        }

        [JsonConstructor]
        public EconDesignXmlBlueprint([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity != 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity can be only 1!");

            Id = id;
            Quantity = quantity;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "advisor", Description = "")]
    [XmlRoot(ElementName = "advisor")]
    public class EconDesignXmlAdvisor
    {
        public EconDesignXmlAdvisor()
        {
        }

        [JsonConstructor]
        public EconDesignXmlAdvisor([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity != 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity can be only 1!");

            Id = id;
            Quantity = quantity;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "trait", Description = "")]
    [XmlRoot(ElementName = "trait")]
    public class EconDesignXmlTrait
    {
        public EconDesignXmlTrait()
        {
        }

        [JsonConstructor]
        public EconDesignXmlTrait([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity,
            [JsonProperty(PropertyName = "level", Required = Required.Always)] int level)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity != 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity can be only 1!");

            if (level < 1 || level > 99)
                throw new ArgumentOutOfRangeException(nameof(level), level, string.Empty);

            Id = id;
            Quantity = quantity;
            Level = level;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlAttribute(AttributeName = "level")]
        public int Level { get; set; }
    }

    [JsonObject(Title = "consumable", Description = "")]
    [XmlRoot(ElementName = "consumable")]
    public class EconDesignXmlConsumable
    {
        public EconDesignXmlConsumable()
        {
        }

        [JsonConstructor]
        public EconDesignXmlConsumable([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity != 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity can be only 1!");

            Id = id;
            Quantity = quantity;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "material", Description = "")]
    [XmlRoot(ElementName = "material")]
    public class EconDesignXmlMaterial
    {
        public EconDesignXmlMaterial()
        {
        }

        public EconDesignXmlMaterial([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, string.Empty);

            Id = id;
            Quantity = quantity;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "input", Description = "")]
    [XmlRoot(ElementName = "input")]
    public class EconDesignXmlInput
    {
        public EconDesignXmlInput()
        {
            Material = new DictionaryContainer<string, EconDesignXmlMaterial>(key => key.Id,
                StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public EconDesignXmlInput(
            [JsonProperty(PropertyName = "material", Required = Required.Always)]
            IEnumerable<EconDesignXmlMaterial> materials)
        {
            Material = new DictionaryContainer<string, EconDesignXmlMaterial>(materials, key => key.Id,
                StringComparer.OrdinalIgnoreCase);
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, EconDesignXmlMaterial> Material { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "material", Required = Required.Always)]
        [XmlElement(ElementName = "material")]
        public EconDesignXmlMaterial[] MaterialArray
        {
            get => Material.Gets().ToArray();
            set
            {
                Material.Clear();
                if (value == null)
                    return;
                foreach (var item in value)
                    Material.Add(item);
            }
        }
    }

    [JsonObject(Title = "econdesign", Description = "")]
    [XmlRoot(ElementName = "econdesign")]
    public class EconDesignXml : IEconDesign
    {
        public EconDesignXml()
        {
            Alliance = EAllianceEnum.None;
            Event = EventEnum.None;
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

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public int RollOverTextId { get; set; }

        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

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
        IItemCost IEconDesign.SellCostOverride => SellCostOverride;

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public CRarityEnum Rarity { get; set; }

        [JsonProperty(PropertyName = "productionpoints", Required = Required.Always)]
        [XmlElement(ElementName = "productionpoints")]
        public double ProductionPoints { get; set; }

        [JsonProperty(PropertyName = "input", Required = Required.Always)]
        [XmlElement(ElementName = "input")]
        public EconDesignXmlInput Input { get; set; }

        [JsonProperty(PropertyName = "output", Required = Required.Always)]
        [XmlElement(ElementName = "output")]
        public EconDesignXmlOutput Output { get; set; }

        [JsonProperty(PropertyName = "outputtraitlevel", Required = Required.Always)]
        [XmlElement(ElementName = "outputtraitlevel")]
        public int OutputTraitLevel { get; set; }

        [JsonProperty(PropertyName = "autolearn", Required = Required.Always)]
        [XmlElement(ElementName = "autolearn")]
        public bool AutoLearn { get; set; }

        [JsonProperty(PropertyName = "autorepeat", Required = Required.Always)]
        [XmlElement(ElementName = "autorepeat")]
        public bool AutoRepeat { get; set; }

        [JsonProperty(PropertyName = "tohopper", Required = Required.Always)]
        [XmlElement(ElementName = "tohopper")]
        public bool ToHopper { get; set; }

        [JsonProperty(PropertyName = "ignoreschool", Required = Required.Always)]
        [XmlElement(ElementName = "ignoreschool")]
        public bool IgnoreSchool { get; set; }

        [JsonProperty(PropertyName = "advanced", Required = Required.Always)]
        [XmlElement(ElementName = "advanced")]
        public bool Advanced { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "tag", Required = Required.Always)]
        [XmlElement(ElementName = "tag")]
        public SchoolTagEnum Tag { get; set; }

        [JsonProperty(PropertyName = "budgetmodifier", Required = Required.Always)]
        [XmlElement(ElementName = "budgetmodifier")]
        public double BudgetModifier { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; }

        [DefaultValue(EAllianceEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; }

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

    [JsonObject(Title = "econdesigns", Description = "")]
    [XmlRoot(ElementName = "econdesigns")]
    public class EconDesignsXml : DictionaryContainer<string, EconDesignXml, IEconDesign>, IEconDesignsXml
    {
        public EconDesignsXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconDesignsXml(
            [JsonProperty(PropertyName = "econdesign", Required = Required.Always)]
            IEnumerable<EconDesignXml> econdesigns) : base(econdesigns, key => key.Name,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "econdesign", Required = Required.Always)]
        [XmlElement(ElementName = "econdesign")]
        public EconDesignXml[] DesignArray
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

        public static IEconDesignsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<EconDesignsXml>(file);
        }
    }
}