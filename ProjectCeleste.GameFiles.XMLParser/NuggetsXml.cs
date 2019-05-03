#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
//TODO JsonProperty
//TODO C# Attribute
namespace ProjectCeleste.GameFiles.XMLParser
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
            Guardianunit = new Dictionary<string, NuggetXmlAnimNuggetGuardianUnit>(StringComparer.OrdinalIgnoreCase);
        }

        [XmlElement(ElementName = "nuggetunit")]
        public string Nuggetunit { get; set; }

        [XmlElement(ElementName = "guardianrevivaltime")]
        public double Guardianrevivaltime { get; set; }

        [Required]
        [JsonProperty(PropertyName = "guardianunit", Required = Required.Always)]
        [XmlIgnore]
        public IDictionary<string, NuggetXmlAnimNuggetGuardianUnit> Guardianunit { get; }

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "guardianunit")]
        public NuggetXmlAnimNuggetGuardianUnit[] GuardianunitList
        {
            get => Guardianunit.Values.ToArray();
            set
            {
                Guardianunit.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Guardianunit.Add(item.Attachdummy, item);
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

    [XmlRoot(ElementName = "questlevel")]
    public class NuggetLogicXmlQuestlevel
    {
        [Key]
        [JsonIgnore]
        [XmlIgnore]
        public string Key => $"{Minlevel}-{Maxlevel}";

        [XmlElement(ElementName = "nuggetref")]
        public HashSet<int> Nuggetref { get; set; } = new HashSet<int>();

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
            Questlevel = new Dictionary<string, NuggetLogicXmlQuestlevel>(StringComparer.OrdinalIgnoreCase);
        }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "questlevel", Required = Required.Always)]
        [XmlIgnore]
        public IDictionary<string, NuggetLogicXmlQuestlevel> Questlevel { get; }

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "questlevel")]
        public NuggetLogicXmlQuestlevel[] NuggetList
        {
            get => Questlevel.Values.ToArray();
            set
            {
                Questlevel.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Questlevel.Add(item.Key, item);
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
        [Required]
        [JsonProperty(PropertyName = "weight", Required = Required.Always)]
        [XmlAttribute(AttributeName = "weight")]
        public int Weight { get; set; }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [Required]
        [XmlIgnore]
        [JsonProperty(PropertyName = "isBoss", Required = Required.Always)]
        public bool IsBoss { get; set; }

        /// <summary>
        ///     Use IsBoss Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlAttribute(AttributeName = "isBoss")]
        public string IsBossStrDoNotUse
        {
            get => IsBoss ? "true" : "false";
            set => IsBoss = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }
    }

    [XmlRoot(ElementName = "eventnuggetoverride")]
    public class NuggetLogicXmlEventNuggetOverride
    {
        public NuggetLogicXmlEventNuggetOverride()
        {
            NuggetOverride =
                new Dictionary<string, NuggetLogicXmlEventNuggetOverrideOverride>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonIgnore]
        [XmlIgnore]
        public string Key => $"{Event}-{Rewardloottable}";

        [XmlAttribute(AttributeName = "event")]
        public EventEnum Event { get; set; }

        [XmlAttribute(AttributeName = "rewardloottable")]
        public LootTableEnum Rewardloottable { get; set; }

        [Required]
        [JsonProperty(PropertyName = "nuggetoverride", Required = Required.Always)]
        [XmlIgnore]
        public IDictionary<string, NuggetLogicXmlEventNuggetOverrideOverride> NuggetOverride { get; }

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "nuggetoverride")]
        public NuggetLogicXmlEventNuggetOverrideOverride[] NuggetOverrideArray
        {
            get => NuggetOverride.Values.ToArray();
            set
            {
                NuggetOverride.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        NuggetOverride.Add(item.Id, item);
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

    [XmlRoot(ElementName = "nuggets")]
    public class NuggetsXml
    {
        public NuggetsXml()
        {
            Nugget = new Dictionary<int, NuggetXml>();
        }

        [Required]
        [JsonProperty(PropertyName = "nugget", Required = Required.Always)]
        [XmlIgnore]
        public IDictionary<int, NuggetXml> Nugget { get; }

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "nugget")]
        public NuggetXml[] NuggetList
        {
            get => Nugget.Values.ToArray();
            set
            {
                Nugget.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Nugget.Add(item.Dbid, item);
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

    [XmlRoot(ElementName = "nuggetlogic")]
    public class NuggetLogicXml
    {
        public NuggetLogicXml()
        {
            RandomMapRegion = new Dictionary<string, NuggetLogicXmlRandomMapRegion>(StringComparer.OrdinalIgnoreCase);
            EventNuggetOverride =
                new Dictionary<string, NuggetLogicXmlEventNuggetOverride>(StringComparer.OrdinalIgnoreCase);
        }

        [Required]
        [JsonProperty(PropertyName = "randommapregion", Required = Required.Always)]
        [XmlIgnore]
        public IDictionary<string, NuggetLogicXmlRandomMapRegion> RandomMapRegion { get; }

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "randommapregion")]
        public NuggetLogicXmlRandomMapRegion[] List
        {
            get => RandomMapRegion.Values.ToArray();
            set
            {
                RandomMapRegion.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        RandomMapRegion.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"RandomMapRegion '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [Required]
        [JsonProperty(PropertyName = "eventnuggetoverride", Required = Required.Always)]
        [XmlIgnore]
        public IDictionary<string, NuggetLogicXmlEventNuggetOverride> EventNuggetOverride { get; }

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "eventnuggetoverride")]
        public NuggetLogicXmlEventNuggetOverride[] EventNuggetOverrideList
        {
            get => EventNuggetOverride.Values.ToArray();
            set
            {
                EventNuggetOverride.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        EventNuggetOverride.Add(item.Key, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"EventNuggetOverride '{item.Key}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [XmlRoot(ElementName = "nuggetdata")]
    public class NuggetDataXml
    {
        [XmlElement(ElementName = "nuggets")]
        public NuggetsXml Nuggets { get; set; }

        [XmlElement(ElementName = "nuggetlogic")]
        public NuggetLogicXml Nuggetlogic { get; set; }

        public static NuggetDataXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<NuggetDataXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}