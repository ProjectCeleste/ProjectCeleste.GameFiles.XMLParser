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
    public enum BluePrintTagEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] Invalid = 0,
        [XmlEnum("Blueprint")] [EnumMember(Value = "Blueprint")] Blueprint = 1
    }

    [JsonObject(Title = "material", Description = "")]
    [XmlRoot(ElementName = "material")]
    public class EconBluePrintXmlCostMaterial
    {
        public EconBluePrintXmlCostMaterial()
        {
        }

        [JsonConstructor]
        public EconBluePrintXmlCostMaterial([JsonProperty(PropertyName = "id", Required = Required.Always)] string id,
            [JsonProperty(PropertyName = "quantity", Required = Required.Always)] int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, string.Empty);

            Quantity = quantity;
            Id = id;
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

    [JsonObject(Title = "cost", Description = "")]
    [XmlRoot(ElementName = "cost")]
    public class EconBluePrintXmlCost
    {
        public EconBluePrintXmlCost()
        {
        }

        [JsonConstructor]
        public EconBluePrintXmlCost(
            [JsonProperty(PropertyName = "material", Required = Required.Always)]
            IEnumerable<EconBluePrintXmlCostMaterial> econBluePrintXmlCostMaterials)
        {
            var enumerable = econBluePrintXmlCostMaterials as EconBluePrintXmlCostMaterial[] ??
                             econBluePrintXmlCostMaterials.ToArray();
            if (!enumerable.Any())
                return;
            foreach (var item in enumerable)
                Material.Add(item.Id, item);
        }

        [XmlIgnore]
        [JsonIgnore]
        public Dictionary<string, EconBluePrintXmlCostMaterial> Material { get; } =
            new Dictionary<string, EconBluePrintXmlCostMaterial>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Material Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "material", Required = Required.Always)]
        [XmlElement(ElementName = "material")]
        public EconBluePrintXmlCostMaterial[] MaterialArrayDoNotUse
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

    [JsonObject(Title = "blueprint", Description = "")]
    [XmlRoot(ElementName = "blueprint")]
    public class EconBlueprintXml
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
        [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)]
        [Range(0, int.MaxValue)]
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

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "protounit", Required = Required.Always)]
        [XmlElement(ElementName = "protounit")]
        public string ProtoUnit { get; set; }

        [Required]
        [JsonProperty(PropertyName = "cost", Required = Required.Always)]
        [XmlElement(ElementName = "cost")]
        public EconBluePrintXmlCost Cost { get; set; }

        [DefaultValue(BluePrintTagEnum.Invalid)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "tag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "tag")]
        public BluePrintTagEnum Tag { get; set; }

        [DefaultValue(EAllianceEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; } = EAllianceEnum.None;

        [DefaultValue(EventEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;
    }

    [JsonObject(Title = "blueprints", Description = "")]
    [XmlRoot(ElementName = "blueprints")]
    public class EconBlueprintsXml
    {
        [JsonProperty(PropertyName = "blueprint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlIgnore]
        public Dictionary<string, EconBlueprintXml> Blueprint { get; } =
            new Dictionary<string, EconBlueprintXml>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use BluePrint Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "blueprint")]
        public EconBlueprintXml[] BluePrintArrayDoNotUse
        {
            get => Blueprint.Values.ToArray();
            set
            {
                Blueprint.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Blueprint.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static EconBlueprintsXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<EconBlueprintsXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}