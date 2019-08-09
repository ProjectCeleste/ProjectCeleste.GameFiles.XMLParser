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
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

//TODO ORDER
//TODO JsonConstructor
//TODO JsonProperty
//TODO C# Attribute
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [XmlRoot(ElementName = "guardianunit")]
    public class NuggetXmlAnimNuggetGuardianUnit
    {
        [XmlElement(ElementName = "unit")]
        public string Unit { get; set; }

        [Key]
        [XmlElement(ElementName = "attachdummy")]
        public string Attachdummy { get; set; }
    }

    [XmlRoot(ElementName = "animnugget")]
    public class NuggetXmlAnimNugget
    {
        public NuggetXmlAnimNugget()
        {
            GuardianUnit =
                new DictionaryContainer<string, NuggetXmlAnimNuggetGuardianUnit>(key => key.Attachdummy,
                    StringComparer.OrdinalIgnoreCase);
        }

        [Required]
        [XmlElement(ElementName = "nuggetunit")]
        public string Nuggetunit { get; set; }

        [XmlElement(ElementName = "guardianrevivaltime")]
        public double Guardianrevivaltime { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, NuggetXmlAnimNuggetGuardianUnit> GuardianUnit { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "guardianunit", Required = Required.Always)]
        [XmlElement(ElementName = "guardianunit")]
        public NuggetXmlAnimNuggetGuardianUnit[] GuardianUnitArray
        {
            get => GuardianUnit.Gets().ToArray();
            set
            {
                GuardianUnit.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!GuardianUnit.Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Guardianunit '{item.Attachdummy}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [DefaultValue(0)]
        [XmlElement(ElementName = "stringid")]
        public int Stringid { get; set; }

        [DefaultValue(0)]
        [XmlElement(ElementName = "rolloverstringid")]
        public int Rolloverstringid { get; set; }
    }

    [XmlRoot(ElementName = "nugget")]
    public class NuggetXml
    {
        [Key]
        [XmlElement(ElementName = "dbid")]
        public int Dbid { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "weight")]
        public int Weight { get; set; }

        [DefaultValue(EventEnum.None)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;

        [XmlElement(ElementName = "rewardloottable")]
        public LootTableEnum Rewardloottable { get; set; }

        [XmlElement(ElementName = "animnugget")]
        public NuggetXmlAnimNugget Animnugget { get; set; }
    }

    [XmlRoot(ElementName = "nuggets")]
    public class NuggetsXml : DictionaryContainer<int, NuggetXml>, INuggets
    {
        public NuggetsXml() : base(key => key.Dbid)
        {
        }

        [JsonConstructor]
        public NuggetsXml(
            [JsonProperty(PropertyName = "nugget", Required = Required.Always)]
            IEnumerable<NuggetXml> nugget) : base(nugget, key => key.Dbid)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "nugget", Required = Required.Always)]
        [XmlElement(ElementName = "nugget")]
        public NuggetXml[] NuggetArray
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
                        excs.Add(new Exception($"Nugget '{item.Dbid}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [XmlRoot(ElementName = "questlevel")]
    public class NuggetLogicXmlQuestlevel
    {
        [Key]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlIgnore]
        public string Key => $"{Minlevel}-{Maxlevel}";

        [XmlElement(ElementName = "nuggetref")]
        public HashSet<int> Nuggetref { get; set; }

        [XmlAttribute(AttributeName = "minlevel")]
        public int Minlevel { get; set; }

        [XmlAttribute(AttributeName = "maxlevel")]
        public int Maxlevel { get; set; }
    }

    [XmlRoot(ElementName = "randommapregion")]
    public class NuggetLogicXmlRandomMapRegion
    {
        public NuggetLogicXmlRandomMapRegion()
        {
            QuestLevel =
                new DictionaryContainer<string, NuggetLogicXmlQuestlevel>(key => key.Key,
                    StringComparer.OrdinalIgnoreCase);
        }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, NuggetLogicXmlQuestlevel> QuestLevel { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "questlevel", Required = Required.Always)]
        [XmlElement(ElementName = "questlevel")]
        public NuggetLogicXmlQuestlevel[] QuestLevelArray
        {
            get => QuestLevel.Gets().ToArray();
            set
            {
                QuestLevel.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!QuestLevel.Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Questlevel '{item.Key}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [XmlRoot(ElementName = "override")]
    public class NuggetLogicXmlEventNuggetOverrideOverride
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "isBoss", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "isBoss")]
        public bool IsBoss { get; set; }

        [Required]
        [JsonProperty(PropertyName = "weight", Required = Required.Always)]
        [XmlAttribute(AttributeName = "weight")]
        public int Weight { get; set; }
    }

    [XmlRoot(ElementName = "eventnuggetoverride")]
    public class NuggetLogicXmlEventNuggetOverride
    {
        public NuggetLogicXmlEventNuggetOverride()
        {
            NuggetOverride =
                new DictionaryContainer<string, NuggetLogicXmlEventNuggetOverrideOverride>(key => key.Id,
                    StringComparer.OrdinalIgnoreCase);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlIgnore]
        public string Key => $"{Event}-{Rewardloottable}";

        [JsonProperty(PropertyName = "event", Required = Required.Always)]
        [XmlAttribute(AttributeName = "event")]
        public EventEnum Event { get; set; }

        [JsonProperty(PropertyName = "rewardloottable", Required = Required.Always)]
        [XmlAttribute(AttributeName = "rewardloottable")]
        public LootTableEnum Rewardloottable { get; set; }

        [Required]
        [Range(0.0, 1.0)]
        [JsonProperty(PropertyName = "chance", Required = Required.Always)]
        [XmlAttribute(AttributeName = "chance")]
        public double OverrideChance { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, NuggetLogicXmlEventNuggetOverrideOverride> NuggetOverride { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "nuggetoverride", Required = Required.Always)]
        [XmlElement(ElementName = "nuggetoverride")]
        public NuggetLogicXmlEventNuggetOverrideOverride[] NuggetOverrideArray
        {
            get => NuggetOverride.Gets().ToArray();
            set
            {
                NuggetOverride.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!NuggetOverride.Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Questlevel '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }
    
    [XmlRoot(ElementName = "nuggetlogic")]
    public class NuggetLogicXml : INuggetLogic
    {
        public NuggetLogicXml()
        {
            RandomMapRegion =
                new DictionaryContainer<string, NuggetLogicXmlRandomMapRegion>(key => key.Name,
                    StringComparer.OrdinalIgnoreCase);
            EventNuggetOverride =
                new DictionaryContainer<string, NuggetLogicXmlEventNuggetOverride>(key => key.Key,
                    StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public NuggetLogicXml(
            [JsonProperty(PropertyName = "randommapregion", Required = Required.Always)]
            IEnumerable<NuggetLogicXmlRandomMapRegion> list,
            [JsonProperty(PropertyName = "eventnuggetoverride", Required = Required.Always)]
            IEnumerable<NuggetLogicXmlEventNuggetOverride> eventNuggetOverrideList)
        {
            RandomMapRegion =
                new DictionaryContainer<string, NuggetLogicXmlRandomMapRegion>(list, key => key.Name,
                    StringComparer.OrdinalIgnoreCase);

            EventNuggetOverride =
                new DictionaryContainer<string, NuggetLogicXmlEventNuggetOverride>(eventNuggetOverrideList,
                    key => key.Key, StringComparer.OrdinalIgnoreCase);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "randommapregion", Required = Required.Always)]
        [XmlElement(ElementName = "randommapregion")]
        public NuggetLogicXmlRandomMapRegion[] RandomMapRegionArray
        {
            get => RandomMapRegion.Gets().ToArray();
            set
            {
                RandomMapRegion.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!RandomMapRegion.Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"RandomMapRegion '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "eventnuggetoverride", Required = Required.Always)]
        [XmlElement(ElementName = "eventnuggetoverride")]
        public NuggetLogicXmlEventNuggetOverride[] EventNuggetOverrideArray
        {
            get => EventNuggetOverride.Gets().ToArray();
            set
            {
                EventNuggetOverride.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!EventNuggetOverride.Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"EventNuggetOverride '{item.Key}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, NuggetLogicXmlRandomMapRegion> RandomMapRegion { get; }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, NuggetLogicXmlEventNuggetOverride> EventNuggetOverride { get; }

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<string, NuggetLogicXmlEventNuggetOverride> INuggetLogic.EventNuggetOverride =>
            EventNuggetOverride;

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<string, NuggetLogicXmlRandomMapRegion> INuggetLogic.RandomMapRegion => RandomMapRegion;
    }

    [XmlRoot(ElementName = "nuggetdata")]
    public class NuggetDataXml : INuggetDataXml
    {
        public NuggetDataXml()
        {
            Nuggets = new NuggetsXml();
            NuggetLogic = new NuggetLogicXml();
        }

        [JsonConstructor]
        public NuggetDataXml(
            [JsonProperty(PropertyName = "nuggets", Required = Required.Always, Order = 1)] NuggetsXml nuggets,
            [JsonProperty(PropertyName = "nuggetlogic", Required = Required.Always, Order = 2)]
            NuggetLogicXml nuggetLogic)
        {
            Nuggets = nuggets ?? throw new ArgumentNullException(nameof(nuggets));
            NuggetLogic = nuggetLogic ?? throw new ArgumentNullException(nameof(nuggetLogic));
        }

        [Required]
        [JsonProperty(PropertyName = "nuggets", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "nuggets")]
        public NuggetsXml Nuggets { get; set; }

        [Required]
        [JsonProperty(PropertyName = "nuggetlogic", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "nuggetlogic")]
        public NuggetLogicXml NuggetLogic { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        INuggets INuggetData.Nuggets => Nuggets;

        [JsonIgnore]
        [XmlIgnore]
        INuggetLogic INuggetData.NuggetLogic => NuggetLogic;

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }

        public static INuggetDataXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<NuggetDataXml>(file);
        }
    }
}