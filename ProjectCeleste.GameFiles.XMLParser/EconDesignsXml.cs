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
    public enum SchoolTagEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("[WoodDesigns1]")] [EnumMember(Value = "[WoodDesigns1]")] WoodDesigns1 = 1,
        [XmlEnum("[StoneDesigns1]")] [EnumMember(Value = "[StoneDesigns1]")] StoneDesigns1 = 2,
        [XmlEnum("[MetalDesigns1]")] [EnumMember(Value = "[MetalDesigns1]")] MetalDesigns1 = 3,
        [XmlEnum("[LeatherDesigns1]")] [EnumMember(Value = "[LeatherDesigns1]")] LeatherDesigns1 = 4,
        [XmlEnum("[FarmDesigns1]")] [EnumMember(Value = "[FarmDesigns1]")] FarmDesigns1 = 5,
        [XmlEnum("[AlchemyDesigns1]")] [EnumMember(Value = "[AlchemyDesigns1]")] AlchemyDesigns1 = 6,
        [XmlEnum("[ToolDesigns1]")] [EnumMember(Value = "[ToolDesigns1]")] ToolDesigns1 = 7,
        [XmlEnum("[GemDesigns1]")] [EnumMember(Value = "[GemDesigns1]")] GemDesigns1 = 8,
        [XmlEnum("[ClothDesigns1]")] [EnumMember(Value = "[ClothDesigns1]")] ClothDesigns1 = 9,
        [XmlEnum("[LoreDesigns1]")] [EnumMember(Value = "[LoreDesigns1]")] LoreDesigns1 = 10,
        [XmlEnum("Religion")] [EnumMember(Value = "Religion")] Religion = 21,
        [XmlEnum("Craftsmen")] [EnumMember(Value = "Craftsmen")] Craftsmen = 22,
        [XmlEnum("Engineering")] [EnumMember(Value = "Engineering")] Engineering = 23,
        [XmlEnum("Construction")] [EnumMember(Value = "Construction")] Construction = 24,
        [XmlEnum("MilitaryCollege")] [EnumMember(Value = "MilitaryCollege")] MilitaryCollege = 25,
        [XmlEnum("HorseBreeding")] [EnumMember(Value = "HorseBreeding")] HorseBreeding = 26,
        [XmlEnum("Woodscraft")] [EnumMember(Value = "Woodscraft")] WoodsCraft = 27,
        [XmlEnum("Metalworking")] [EnumMember(Value = "Metalworking")] MetalWorking = 28
    }

    [JsonObject(Title = "output", Description = "")]
    [XmlRoot(ElementName = "output")]
    public class EconDesignsXmlOutput
    {
        public EconDesignsXmlOutput()
        {
        }

        public EconDesignsXmlOutput(EconDesignsXmlTrait trait)
        {
            Trait = trait;
        }

        public EconDesignsXmlOutput(EconDesignsXmlConsumable consumable)
        {
            Consumable = consumable;
        }

        public EconDesignsXmlOutput(EconDesignsXmlMaterial material)
        {
            Material = material;
        }

        [JsonConstructor]
        public EconDesignsXmlOutput(
            [JsonProperty(PropertyName = "material", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignsXmlMaterial material,
            [JsonProperty(PropertyName = "trait", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignsXmlTrait trait,
            [JsonProperty(PropertyName = "consumable", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignsXmlConsumable consumable,
            [JsonProperty(PropertyName = "advisor", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignsXmlAdvisor advisor,
            [JsonProperty(PropertyName = "blueprint", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EconDesignsXmlBlueprint blueprint)
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
        public EconDesignsXmlMaterial Material { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "trait", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "trait")]
        public EconDesignsXmlTrait Trait { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "consumable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "consumable")]
        public EconDesignsXmlConsumable Consumable { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "advisor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "advisor")]
        public EconDesignsXmlAdvisor Advisor { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "blueprint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "blueprint")]
        public EconDesignsXmlBlueprint Blueprint { get; set; }
    }

    [JsonObject(Title = "blueprint", Description = "")]
    [XmlRoot(ElementName = "blueprint")]
    public class EconDesignsXmlBlueprint
    {
        public EconDesignsXmlBlueprint()
        {
        }

        [JsonConstructor]
        public EconDesignsXmlBlueprint([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity != 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity can be only 1!");

            Id = id;
            Quantity = quantity;
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [Required]
        [Range(1, 1)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "advisor", Description = "")]
    [XmlRoot(ElementName = "advisor")]
    public class EconDesignsXmlAdvisor
    {
        public EconDesignsXmlAdvisor()
        {
        }

        [JsonConstructor]
        public EconDesignsXmlAdvisor([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity != 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity can be only 1!");

            Id = id;
            Quantity = quantity;
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [Required]
        [Range(1, 1)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "trait", Description = "")]
    [XmlRoot(ElementName = "trait")]
    public class EconDesignsXmlTrait
    {
        public EconDesignsXmlTrait()
        {
        }

        [JsonConstructor]
        public EconDesignsXmlTrait([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
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

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [Required]
        [Range(1, 1)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlAttribute(AttributeName = "level")]
        public int Level { get; set; }
    }

    [JsonObject(Title = "consumable", Description = "")]
    [XmlRoot(ElementName = "consumable")]
    public class EconDesignsXmlConsumable
    {
        public EconDesignsXmlConsumable()
        {
        }

        [JsonConstructor]
        public EconDesignsXmlConsumable([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity != 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity can be only 1!");

            Id = id;
            Quantity = quantity;
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [Required]
        [Range(1, 1)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "material", Description = "")]
    [XmlRoot(ElementName = "material")]
    public class EconDesignsXmlMaterial
    {
        public EconDesignsXmlMaterial()
        {
        }

        public EconDesignsXmlMaterial([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, string.Empty);

            Id = id;
            Quantity = quantity;
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "input", Description = "")]
    [XmlRoot(ElementName = "input")]
    public class EconDesignsXmlInput
    {
        public EconDesignsXmlInput()
        {
        }

        [JsonConstructor]
        public EconDesignsXmlInput(
            [JsonProperty(PropertyName = "material", Required = Required.Always)]
            EconDesignsXmlMaterial[] econDesignsXmlMaterials)
        {
            if (econDesignsXmlMaterials == null)
                return;

            foreach (var item in econDesignsXmlMaterials)
                Material.Add(item.Id, item);
        }

        [XmlIgnore]
        [JsonIgnore]
        public Dictionary<string, EconDesignsXmlMaterial> Material { get; } =
            new Dictionary<string, EconDesignsXmlMaterial>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Material Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "material", Required = Required.Always)]
        [XmlElement(ElementName = "material")]
        public EconDesignsXmlMaterial[] TechArrayDoNotUse
        {
            get => Material.Values.ToArray();
            set
            {
                Material.Clear();
                if (value == null)
                    return;

                foreach (var item in value)
                    Material.Add(item.Id, item);
            }
        }
    }

    [JsonObject(Title = "econdesign", Description = "")]
    [XmlRoot(ElementName = "econdesign")]
    public class EconDesignXml
    {
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

        [Required]
        [JsonProperty(PropertyName = "productionpoints", Required = Required.Always)]
        [Range(0, double.MaxValue)]
        [XmlElement(ElementName = "productionpoints")]
        public double ProductionPoints { get; set; }

        [Required]
        [JsonProperty(PropertyName = "input", Required = Required.Always)]
        [XmlElement(ElementName = "input")]
        public EconDesignsXmlInput Input { get; set; }

        [Required]
        [JsonProperty(PropertyName = "output", Required = Required.Always)]
        [XmlElement(ElementName = "output")]
        public EconDesignsXmlOutput Output { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "outputtraitlevel", Required = Required.Always)]
        [XmlElement(ElementName = "outputtraitlevel")]
        public int OutputTraitLevel { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsAutoLearn { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "autolearn", Required = Required.Always)]
        [XmlElement(ElementName = "autolearn")]
        public string AutoLearnStrDoNotUse
        {
            get => IsAutoLearn ? "true" : "false";
            set => IsAutoLearn = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsAutoRepeat { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "autorepeat", Required = Required.Always)]
        [XmlElement(ElementName = "autorepeat")]
        public string AutoRepeatStrDoNotUse
        {
            get => IsAutoRepeat ? "true" : "false";
            set => IsAutoRepeat = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsToHopper { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "tohopper", Required = Required.Always)]
        [XmlElement(ElementName = "tohopper")]
        public string ToHopperStrDoNotUse
        {
            get => IsToHopper ? "true" : "false";
            set => IsToHopper = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsIgnoreSchool { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "ignoreschool", Required = Required.Always)]
        [XmlElement(ElementName = "ignoreschool")]
        public string IgnoreSchoolStrDoNotUse
        {
            get => IsIgnoreSchool ? "true" : "false";
            set => IsIgnoreSchool = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsAdvanced { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "advanced", Required = Required.Always)]
        [XmlElement(ElementName = "advanced")]
        public string AdvancedStrDoNotUse
        {
            get => IsAdvanced ? "true" : "false";
            set => IsAdvanced = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "tag", Required = Required.Always)]
        [XmlElement(ElementName = "tag")]
        public SchoolTagEnum Tag { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "budgetmodifier", Required = Required.Always)]
        [XmlElement(ElementName = "budgetmodifier")]
        public double BudgetModifier { get; set; }


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
    }

    [JsonObject(Title = "econdesigns", Description = "")]
    [XmlRoot(ElementName = "econdesigns")]
    public class EconDesignsXml
    {
        [JsonProperty(PropertyName = "econdesign", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, EconDesignXml> Design { get; } =
            new Dictionary<string, EconDesignXml>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Design Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "econdesign")]
        public EconDesignXml[] DesignArrayDoNotUse
        {
            get => Design.Values.ToArray();
            set
            {
                Design.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Design.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static EconDesignsXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<EconDesignsXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}