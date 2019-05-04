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
    [JsonObject(Title = "visualfactor", Description = "")]
    [XmlRoot(ElementName = "visualfactor")]
    public class TraitXmlVisualFactor
    {
        public TraitXmlVisualFactor()
        {
        }

        [JsonConstructor]
        public TraitXmlVisualFactor(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] VisualFactorEnum type,
            [JsonProperty(PropertyName = "factor", Required = Required.Always)] double factor)
        {
            if (type == VisualFactorEnum.None)
                throw new ArgumentOutOfRangeException(nameof(type), type, string.Empty);

            Type = type;
            Factor = factor;
        }

        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public VisualFactorEnum Type { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [JsonProperty(PropertyName = "factor", Required = Required.Always)]
        [XmlAttribute(AttributeName = "factor")]
        public double Factor { get; set; }
    }

    [JsonObject(Title = "target", Description = "")]
    [XmlRoot(ElementName = "target")]
    public class TraitXmlEffectTarget
    {
        public TraitXmlEffectTarget()
        {
        }

        [JsonConstructor]
        public TraitXmlEffectTarget(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] TargetTypeEnum type)
        {
            if (type == TargetTypeEnum.None)
                throw new ArgumentOutOfRangeException(nameof(type), type, string.Empty);

            Type = type;
        }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public TargetTypeEnum Type { get; set; }
    }

    [JsonObject(Title = "effect", Description = "")]
    [XmlRoot(ElementName = "effect")]
    public class TraitXmlEffect
    {
        public TraitXmlEffect()
        {
            Resource = ResourceTypeEnum.Invalid;
            UnitType = EffectUnitTypeEnum.Invalid;
            DamageType = DamageTypeEnum.None;
            Action = EffectActionTypeEnum.Invalid;
        }

        [Required]
        [JsonProperty(PropertyName = "target", Required = Required.Always)]
        [XmlElement(ElementName = "target")]
        public TraitXmlEffectTarget Target { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public EffectTypeEnum Type { get; set; }

        [Required]
        [JsonProperty(PropertyName = "bonus", Required = Required.Always)]
        [XmlIgnore]
        public bool IsBonus { get; set; }

        /// <summary>
        ///     Use IsBonus Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlAttribute(AttributeName = "bonus")]
        public string BonusStrDoNotUse
        {
            get => IsBonus ? "true" : "false";
            set => IsBonus = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [DefaultValue(EffectActionTypeEnum.Invalid)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "action", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "action")]
        public EffectActionTypeEnum Action { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        [XmlAttribute(AttributeName = "amount")]
        public double Amount { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [JsonProperty(PropertyName = "scaling", Required = Required.Always)]
        [XmlAttribute(AttributeName = "scaling")]
        public double Scaling { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "subtype", Required = Required.Always)]
        [XmlAttribute(AttributeName = "subtype")]
        public EffectSubTypeEnum SubType { get; set; }

        [Required]
        [JsonProperty(PropertyName = "visible", Required = Required.Always)]
        [XmlIgnore]
        public bool IsVisible { get; set; }

        /// <summary>
        ///     Use IsVisible Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlAttribute(AttributeName = "visible")]
        public string VisibleStrDoNotUse
        {
            get => IsVisible ? "true" : "false";
            set => IsVisible = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [DefaultValue(DamageTypeEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "damagetype", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "damagetype")]
        public DamageTypeEnum DamageType { get; set; }

        [DefaultValue(EffectUnitTypeEnum.Invalid)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "unittype", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "unittype")]
        public EffectUnitTypeEnum UnitType { get; set; }

        [DefaultValue(0)]
        [Range(0, 1)]
        [JsonProperty(PropertyName = "allactions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "allactions")]
        public int AllActions { get; set; }

        [DefaultValue(ResourceTypeEnum.Invalid)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "resource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "resource")]
        public ResourceTypeEnum Resource { get; set; }

        [DefaultValue(0)]
        [Range(0, 4)]
        [JsonProperty(PropertyName = "seedoffset", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "seedoffset")]
        public int SeedOffset { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "relativity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "relativity")]
        public RelativityEnum Relativity { get; set; }
    }

    [JsonObject(Title = "effects", Description = "")]
    [XmlRoot(ElementName = "effects")]
    public class TraitXmlEffects
    {
        public TraitXmlEffects()
        {
        }

        [JsonConstructor]
        public TraitXmlEffects(
            [JsonProperty(PropertyName = "effect", Required = Required.Always)] IEnumerable<TraitXmlEffect> effect)
        {
            Effect = effect.ToList();
        }

        [Required]
        [JsonProperty(PropertyName = "effect", Required = Required.Always)]
        [XmlElement(ElementName = "effect")]
        public List<TraitXmlEffect> Effect { get; set; }
    }

    [JsonObject(Title = "trait", Description = "")]
    [XmlRoot(ElementName = "trait")]
    public class TraitXml
    {
        public TraitXml()
        {
            Event = EventEnum.None;
            ItemLevels = new HashSet<int>();
            VisualFactor = new Dictionary<VisualFactorEnum, TraitXmlVisualFactor>();
            Alliance = EAllianceEnum.None;
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "dbid", Required = Required.Always)]
        [XmlElement(ElementName = "dbid")]
        public int Dbid { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "traittype", Required = Required.Always)]
        [XmlElement(ElementName = "traittype")]
        public TraitTypeEnum TraitType { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public RarityEnum Rarity { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [Required]
        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public int RollOverTextId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [DefaultValue(EAllianceEnum.None)]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "offertype", Required = Required.Always)]
        [XmlElement(ElementName = "offertype")]
        public EOfferTypeEnum OfferType { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public IDictionary<VisualFactorEnum, TraitXmlVisualFactor> VisualFactor { get; }

        /// <summary>
        ///     Use VisualFactor Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "visualfactor", Required = Required.Always)]
        [XmlElement(ElementName = "visualfactor")]
        public TraitXmlVisualFactor[] VisualFactorArrayDoNotUse
        {
            get => VisualFactor.Values.ToArray();
            set
            {
                VisualFactor.Clear();
                if (value == null)
                    return;

                foreach (var item in value)
                    VisualFactor.Add(item.Type, item);
            }
        }

        [Required]
        [JsonProperty(PropertyName = "itemlevels", Required = Required.Always)]
        [XmlIgnore]
        public HashSet<int> ItemLevels { get; set; }

        /// <summary>
        ///     Use ItemLevels HashSet Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue(null)]
        [JsonIgnore]
        [XmlElement(ElementName = "itemlevels")]
        public string ItemLevelsListDoNotUse
        {
            get
            {
                if (ItemLevels == null || ItemLevels.Count < 1)
                    return string.Empty;

                var list = ItemLevels.Aggregate(string.Empty, (current, key) => current + key + ",");
                if (list.EndsWith(","))
                    list = list.Substring(0, list.Length - 1);
                return list;
            }
            set
            {
                ItemLevels.Clear();

                if (string.IsNullOrWhiteSpace(value))
                    return;

                foreach (var item in value.Split(','))
                    if (!string.IsNullOrWhiteSpace(item))
                        ItemLevels.Add(Convert.ToInt32(item));
            }
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "equipsoundset", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "equipsoundset")]
        public string EquipSoundSet { get; set; }

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
            get => IsSellable ? "1" : "0";
            set => IsSellable = string.Equals(value, "1", StringComparison.OrdinalIgnoreCase);
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
            get => IsTradeable ? "1" : "0";
            set => IsTradeable = string.Equals(value, "1", StringComparison.OrdinalIgnoreCase);
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
            get => IsDestroyable ? "1" : "0";
            set => IsDestroyable = string.Equals(value, "1", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "canbestoredingearhall", Required = Required.Always)]
        [XmlIgnore]
        public bool CanBeStoredInGearHall { get; set; }

        /// <summary>
        ///     Use CanBeStoredInGearHall Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "canbestoredingearhall")]
        public string CanBeStoredInGearHallStrDoNotUse
        {
            get => CanBeStoredInGearHall ? "1" : "0";
            set => CanBeStoredInGearHall = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase) ||
                                           string.Equals(value, "1", StringComparison.Ordinal);
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "effects", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "effects")]
        public TraitXmlEffects Effects { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; }
    }

    [JsonObject(Title = "trait", Description = "")]
    [XmlRoot(ElementName = "traits")]
    public class TraitsXml
    {
        public TraitsXml()
        {
            Trait = new Dictionary<string, TraitXml>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<string, TraitXml> Trait { get; }

        /// <summary>
        ///     Use Trait Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "trait", Required = Required.Always)]
        [XmlElement(ElementName = "trait")]
        public TraitXml[] TraitArrayDoNotUse
        {
            get => Trait.Values.ToArray();
            set
            {
                Trait.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Trait.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static TraitsXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<TraitsXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}