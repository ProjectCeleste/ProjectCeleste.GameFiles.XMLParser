#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser
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
    public class EconDesignXmlInput
    {
        public EconDesignXmlInput()
        {
            Material = new Dictionary<string, EconDesignXmlMaterial>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public EconDesignXmlInput(
            [JsonProperty(PropertyName = "material", Required = Required.Always)]
            IEnumerable<EconDesignXmlMaterial> econDesignsXmlMaterials)
        {
            Material = econDesignsXmlMaterials.ToDictionary(key => key.Id, StringComparer.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public IDictionary<string, EconDesignXmlMaterial> Material { get; }

        /// <summary>
        ///     Use Material Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "material", Required = Required.Always)]
        [XmlElement(ElementName = "material")]
        public EconDesignXmlMaterial[] TechArrayDoNotUse
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
        public EconDesignXml()
        {
            Alliance = EAllianceEnum.None;
            Event = EventEnum.None;
        }

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

        [Required]
        [JsonProperty(PropertyName = "sellable", Required = Required.Always)]
        [XmlIgnore]
        public bool IsSellable { get; set; }

        /// <summary>
        ///     Use IsSellable Bool Instead! Only only used for xml parsing.
        /// </summary>
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

        /// <summary>
        ///     Use IsTradeable Bool Instead! Only only used for xml parsing.
        /// </summary>
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

        /// <summary>
        ///     Use IsDestroyable Bool Instead! Only only used for xml parsing.
        /// </summary>
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

        [Required]
        [JsonProperty(PropertyName = "productionpoints", Required = Required.Always)]
        [Range(0, double.MaxValue)]
        [XmlElement(ElementName = "productionpoints")]
        public double ProductionPoints { get; set; }

        [Required]
        [JsonProperty(PropertyName = "input", Required = Required.Always)]
        [XmlElement(ElementName = "input")]
        public EconDesignXmlInput Input { get; set; }

        [Required]
        [JsonProperty(PropertyName = "output", Required = Required.Always)]
        [XmlElement(ElementName = "output")]
        public EconDesignXmlOutput Output { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "outputtraitlevel", Required = Required.Always)]
        [XmlElement(ElementName = "outputtraitlevel")]
        public int OutputTraitLevel { get; set; }

        [Required]
        [JsonProperty(PropertyName = "autolearn", Required = Required.Always)]
        [XmlIgnore]
        public bool IsAutoLearn { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "autolearn")]
        public string AutoLearnStrDoNotUse
        {
            get => IsAutoLearn ? "true" : "false";
            set => IsAutoLearn = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "autorepeat", Required = Required.Always)]
        [XmlIgnore]
        public bool IsAutoRepeat { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "autorepeat")]
        public string AutoRepeatStrDoNotUse
        {
            get => IsAutoRepeat ? "true" : "false";
            set => IsAutoRepeat = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "tohopper", Required = Required.Always)]
        [XmlIgnore]
        public bool IsToHopper { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "tohopper")]
        public string ToHopperStrDoNotUse
        {
            get => IsToHopper ? "true" : "false";
            set => IsToHopper = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "ignoreschool", Required = Required.Always)]
        [XmlIgnore]
        [JsonIgnore]
        public bool IsIgnoreSchool { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "ignoreschool")]
        public string IgnoreSchoolStrDoNotUse
        {
            get => IsIgnoreSchool ? "true" : "false";
            set => IsIgnoreSchool = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "advanced", Required = Required.Always)]
        [XmlIgnore]
        public bool IsAdvanced { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
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
        public EventEnum Event { get; set; }

        [DefaultValue(EAllianceEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; }
    }

    [JsonObject(Title = "econdesigns", Description = "")]
    [XmlRoot(ElementName = "econdesigns")]
    public class EconDesignsXml
    {
        public EconDesignsXml()
        {
            Design = new Dictionary<string, EconDesignXml>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<string, EconDesignXml> Design { get; }

        /// <summary>
        ///     Use Design Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "econdesign", Required = Required.Always)]
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

        public static EconDesignsXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<EconDesignsXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}