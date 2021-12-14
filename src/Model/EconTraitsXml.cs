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
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "visualfactor", Description = "")]
    [XmlRoot(ElementName = "visualfactor")]
    public class EconTraitXmlVisualFactor
    {
        public EconTraitXmlVisualFactor()
        {
        }

        [JsonConstructor]
        public EconTraitXmlVisualFactor(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] VisualFactorEnum type,
            [JsonProperty(PropertyName = "factor", Required = Required.Always)] double factor)
        {
            if (type == VisualFactorEnum.None)
                throw new ArgumentOutOfRangeException(nameof(type), type, string.Empty);

            Type = type;
            Factor = factor;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public VisualFactorEnum Type { get; set; }

        [JsonProperty(PropertyName = "factor", Required = Required.Always)]
        [XmlAttribute(AttributeName = "factor")]
        public double Factor { get; set; }
    }

    [JsonObject(Title = "target", Description = "")]
    [XmlRoot(ElementName = "target")]
    public class EconTraitXmlEffectTarget
    {
        public EconTraitXmlEffectTarget()
        {
        }

        [JsonConstructor]
        public EconTraitXmlEffectTarget(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] TargetTypeEnum type)
        {
            if (type == TargetTypeEnum.None)
                throw new ArgumentOutOfRangeException(nameof(type), type, string.Empty);

            Type = type;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public TargetTypeEnum Type { get; set; }
    }

    [JsonObject(Title = "effect", Description = "")]
    [XmlRoot(ElementName = "effect")]
    public class EconTraitXmlEffect
    {
        public EconTraitXmlEffect()
        {
            Resource = ResourceTypeEnum.Invalid;
            UnitType = EffectUnitTypeEnum.Invalid;
            DamageType = DamageTypeEnum.None;
            Action = EffectActionTypeEnum.Invalid;
        }

        [JsonProperty(PropertyName = "target", Required = Required.Always)]
        [XmlElement(ElementName = "target")]
        public EconTraitXmlEffectTarget Target { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public EffectTypeEnum Type { get; set; }

        [JsonProperty(PropertyName = "bonus", Required = Required.Always)]
        [XmlIgnore]
        public bool IsBonus { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        [XmlAttribute(AttributeName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "scaling", Required = Required.Always)]
        [XmlAttribute(AttributeName = "scaling")]
        public double Scaling { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "subtype", Required = Required.Always)]
        [XmlAttribute(AttributeName = "subtype")]
        public EffectSubTypeEnum SubType { get; set; }

        [JsonProperty(PropertyName = "visible", Required = Required.Always)]
        [XmlAttribute(AttributeName = "visible")]
        public bool Visible { get; set; }

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
        [JsonProperty(PropertyName = "allactions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "allactions")]
        public int AllActions { get; set; }

        [DefaultValue(ResourceTypeEnum.Invalid)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "resource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "resource")]
        public ResourceTypeEnum Resource { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "seedoffset", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "seedoffset")]
        public int SeedOffset { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "relativity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "relativity")]
        public RelativityEnum Relativity { get; set; }
    }

    [JsonObject(Title = "effects", Description = "")]
    [XmlRoot(ElementName = "effects")]
    public class EconTraitXmlEffects
    {
        public EconTraitXmlEffects()
        {
        }

        [JsonConstructor]
        public EconTraitXmlEffects(
            [JsonProperty(PropertyName = "effect", Required = Required.Always)] IEnumerable<EconTraitXmlEffect> effect)
        {
            Effect = effect.ToList();
        }

        [JsonProperty(PropertyName = "effect", Required = Required.Always)]
        [XmlElement(ElementName = "effect")]
        public List<EconTraitXmlEffect> Effect { get; set; }
    }

    [JsonObject(Title = "trait", Description = "")]
    [XmlRoot(ElementName = "trait")]
    public class EconTraitXml : IEconTrait
    {
        public EconTraitXml()
        {
            Event = EventEnum.None;
            ItemLevels = new HashSet<int>();
            VisualFactor = new DictionaryContainer<VisualFactorEnum, EconTraitXmlVisualFactor>(key => key.Type);
            Alliance = EAllianceEnum.None;
        }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "dbid", Required = Required.Always)]
        [XmlElement(ElementName = "dbid")]
        public int Dbid { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "traittype", Required = Required.Always)]
        [XmlElement(ElementName = "traittype")]
        public TraitTypeEnum TraitType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public RarityEnum Rarity { get; set; }

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public int RollOverTextId { get; set; }

        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [DefaultValue(EAllianceEnum.None)]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "offertype", Required = Required.Always)]
        [XmlElement(ElementName = "offertype")]
        public EOfferTypeEnum OfferType { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public IDictionaryContainer<VisualFactorEnum, EconTraitXmlVisualFactor> VisualFactor { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "visualfactor", Required = Required.Always)]
        [XmlElement(ElementName = "visualfactor")]
        public EconTraitXmlVisualFactor[] VisualFactorArray
        {
            get => VisualFactor.Gets().ToArray();
            set
            {
                VisualFactor.Clear();
                if (value == null)
                    return;

                foreach (var item in value)
                    VisualFactor.Add(item);
            }
        }

        [JsonProperty(PropertyName = "itemlevels", Required = Required.Always)]
        [XmlIgnore]
        public HashSet<int> ItemLevels { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        [JsonIgnore]
        [XmlElement(ElementName = "itemlevels")]
        public string ItemLevelsStr
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

        [JsonProperty(PropertyName = "sellable", Required = Required.Always)]
        [XmlIgnore]
        public bool IsSellable { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlElement(ElementName = "sellable")]
        public string SellableStr
        {
            get => IsSellable ? "1" : "0";
            set => IsSellable = string.Equals(value, "1", StringComparison.Ordinal) ||
                                string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [JsonProperty(PropertyName = "tradeable", Required = Required.Always)]
        [XmlIgnore]
        public bool IsTradeable { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlElement(ElementName = "tradeable")]
        public string TradeableStr
        {
            get => IsTradeable ? "1" : "0";
            set => IsTradeable = string.Equals(value, "1", StringComparison.Ordinal) ||
                                 string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [JsonProperty(PropertyName = "destroyable", Required = Required.Always)]
        [XmlIgnore]
        public bool IsDestroyable { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlElement(ElementName = "destroyable")]
        public string DestroyableStr
        {
            get => IsDestroyable ? "1" : "0";
            set => IsDestroyable = string.Equals(value, "1", StringComparison.Ordinal) ||
                                   string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [JsonProperty(PropertyName = "canbestoredingearhall", Required = Required.Always)]
        [XmlIgnore]
        public bool CanBeStoredInGearHall { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlElement(ElementName = "canbestoredingearhall")]
        public string CanBeStoredInGearHallStr
        {
            get => CanBeStoredInGearHall ? "1" : "0";
            set => CanBeStoredInGearHall = string.Equals(value, "1", StringComparison.Ordinal) ||
                                           string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "effects", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "effects")]
        public EconTraitXmlEffects Effects { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; }
    }

    [JsonObject(Title = "trait", Description = "")]
    [XmlRoot(ElementName = "traits")]
    public class EconTraitsXml : DictionaryContainer<string, EconTraitXml, IEconTrait>, IEconTraitsXml
    {
        public EconTraitsXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconTraitsXml(
            [JsonProperty(PropertyName = "trait", Required = Required.Always)] IEnumerable<EconTraitXml> traits) : base(
            traits, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "trait", Required = Required.Always)]
        [XmlElement(ElementName = "trait")]
        public EconTraitXml[] TraitArray
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

        public static IEconTraitsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<EconTraitsXml>(file);
        }
    }
}