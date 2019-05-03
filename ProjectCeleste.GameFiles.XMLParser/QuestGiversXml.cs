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
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "override", Description = "")]
    [XmlRoot(ElementName = "override")]
    public class QuestGiverXmlOverride
    {
        public QuestGiverXmlOverride()
        {
        }

        [JsonConstructor]
        public QuestGiverXmlOverride(
            [JsonProperty(PropertyName = "key", Required = Required.Always, Order = 1)] string key,
            [JsonProperty(PropertyName = "value", Required = Required.Always, Order = 2)] string value)
        {
            Key = !string.IsNullOrWhiteSpace(key) ? key : throw new ArgumentNullException(nameof(key));
            Value = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException(nameof(value));
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "key", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "key", Order = 1)]
        public string Key { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "value", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "value", Order = 2)]
        public string Value { get; set; }
    }

    [JsonObject(Title = "overrides", Description = "")]
    [XmlRoot(ElementName = "overrides")]
    public class QuestGiverXmlOverrides
    {
        public QuestGiverXmlOverrides()
        {
            Override = new Dictionary<string, QuestGiverXmlOverride>(StringComparer.OrdinalIgnoreCase);
        }

        public QuestGiverXmlOverrides(IDictionary<string, QuestGiverXmlOverride> @override)
        {
            Override = new Dictionary<string, QuestGiverXmlOverride>(@override, StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public QuestGiverXmlOverrides(
            [JsonProperty(PropertyName = "override", Required = Required.Always, Order = 1)]
            IEnumerable<QuestGiverXmlOverride> @override)
        {
            Override = @override.ToDictionary(key => key.Key, StringComparer.OrdinalIgnoreCase);
        }

        [XmlIgnore]
        [JsonIgnore]
        public IDictionary<string, QuestGiverXmlOverride> Override { get; }

        /// <summary>
        ///     Use RandomMaps Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "override", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "override", Order = 1)]
        public QuestGiverXmlOverride[] OverrideArrayDoNotUse
        {
            get => Override.Values.ToArray();
            set
            {
                Override.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Override.Add(item.Key, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Key}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "nearbuilding", Description = "")]
    [XmlRoot(ElementName = "nearbuilding")]
    public class QuestGiverXmlNearBuilding
    {
        public QuestGiverXmlNearBuilding()
        {
        }

        [JsonConstructor]
        public QuestGiverXmlNearBuilding(
            [JsonProperty(PropertyName = "nearunittype", Required = Required.Always, Order = 1)] string nearUnitType,
            [JsonProperty(PropertyName = "preferredoffset", Required = Required.Always, Order = 2)]
            string preferredOffset,
            [JsonProperty(PropertyName = "radius", Required = Required.Always, Order = 3)] int radius,
            [JsonProperty(PropertyName = "useboneposition", Required = Required.Always, Order = 4)]
            bool isUseBonePosition)
        {
            NearUnitType = nearUnitType ?? throw new ArgumentNullException(nameof(nearUnitType));
            PreferredOffset = preferredOffset ?? throw new ArgumentNullException(nameof(preferredOffset));
            Radius = radius;
            IsUseBonePosition = isUseBonePosition;
        }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "nearunittype", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "nearunittype", Order = 1)]
        public string NearUnitType { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "preferredoffset", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "preferredoffset", Order = 2)]
        public string PreferredOffset { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "radius", Required = Required.Always, Order = 3)]
        [XmlElement(ElementName = "radius", Order = 3)]
        public int Radius { get; set; }

        [Required]
        [JsonProperty(PropertyName = "useboneposition", Required = Required.Always, Order = 4)]
        [XmlIgnore]
        public bool IsUseBonePosition { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "useboneposition", Order = 4)]
        public string UseBonePositionStrDoNotUse
        {
            get => IsUseBonePosition ? "true" : "false";
            set => IsUseBonePosition = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }
    }

    [JsonObject(Title = "location", Description = "")]
    [XmlRoot(ElementName = "location")]
    public class QuestGiverXmlLocation
    {
        public QuestGiverXmlLocation()
        {
        }

        [JsonConstructor]
        public QuestGiverXmlLocation(
            [JsonProperty(PropertyName = "nearbuilding", Required = Required.Always, Order = 1)]
            QuestGiverXmlNearBuilding nearbuilding)
        {
            NearBuilding = nearbuilding ?? throw new ArgumentNullException(nameof(nearbuilding));
        }

        [Required]
        [JsonProperty(PropertyName = "nearbuilding", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "nearbuilding", Order = 1)]
        public QuestGiverXmlNearBuilding NearBuilding { get; set; }
    }

    [JsonObject(Title = "onunitcount", Description = "")]
    [XmlRoot(ElementName = "onunitcount")]
    public class QuestGiversXmlOnunitcount
    {
        public QuestGiversXmlOnunitcount()
        {
        }

        [JsonConstructor]
        public QuestGiversXmlOnunitcount(
            [JsonProperty(PropertyName = "countunittype", Required = Required.Always, Order = 1)] string countunittype,
            [JsonProperty(PropertyName = "comparetype", Required = Required.Always, Order = 2)] string comparetype,
            [JsonProperty(PropertyName = "count", Required = Required.Always, Order = 3)] int count)
        {
            CountUnitType = !string.IsNullOrWhiteSpace(countunittype)
                ? countunittype
                : throw new ArgumentNullException(nameof(countunittype));
            CompareType = !string.IsNullOrWhiteSpace(comparetype)
                ? comparetype
                : throw new ArgumentNullException(nameof(comparetype));
            Count = count;
        }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "countunittype", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "countunittype", Order = 1)]
        public string CountUnitType { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "comparetype", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "comparetype", Order = 2)]
        public string CompareType { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "count", Required = Required.Always, Order = 3)]
        [XmlElement(ElementName = "count", Order = 3)]
        public int Count { get; set; }
    }

    [JsonObject(Title = "onquest", Description = "")]
    [XmlRoot(ElementName = "onquest")]
    public class QuestGiversXmlOnQuest
    {
        public QuestGiversXmlOnQuest()
        {
        }

        [JsonConstructor]
        public QuestGiversXmlOnQuest([JsonProperty(PropertyName = "id", Required = Required.Always)] int id)
        {
            Id = id;
        }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }

    [JsonObject(Title = "spawntrigger", Description = "")]
    [XmlRoot(ElementName = "spawntrigger")]
    public class QuestGiverXmlSpawnTrigger
    {
        public QuestGiverXmlSpawnTrigger()
        {
        }

        [JsonConstructor]
        public QuestGiverXmlSpawnTrigger(
            [JsonProperty(PropertyName = "onunitcount", DefaultValueHandling = DefaultValueHandling.Ignore)]
            QuestGiversXmlOnunitcount onunitcount,
            [JsonProperty(PropertyName = "onquest", DefaultValueHandling = DefaultValueHandling.Ignore)]
            QuestGiversXmlOnQuest onquest)
        {
            OnUnitCount = onunitcount;
            OnQuest = onquest;
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "onunitcount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "onunitcount")]
        public QuestGiversXmlOnunitcount OnUnitCount { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "onquest", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "onquest")]
        public QuestGiversXmlOnQuest OnQuest { get; set; }
    }

    [JsonObject(Title = "questgiver", Description = "")]
    [XmlRoot(ElementName = "questgiver")]
    public class QuestGiverXml
    {
        public QuestGiverXml()
        {
        }

        [JsonConstructor]
        public QuestGiverXml(
            [JsonProperty(PropertyName = "name", Required = Required.Always)] string name,
            [JsonProperty(PropertyName = "placeunittype", Required = Required.Always)] string placeunittype,
            [JsonProperty(PropertyName = "status", Required = Required.Always)] string status,
            [JsonProperty(PropertyName = "maptype", Required = Required.Always)] string maptype,
            [JsonProperty(PropertyName = "overrides", Required = Required.Always)] QuestGiverXmlOverrides overrides,
            [JsonProperty(PropertyName = "location", Required = Required.Always)] QuestGiverXmlLocation location,
            [JsonProperty(PropertyName = "spawntrigger", Required = Required.AllowNull)]
            QuestGiverXmlSpawnTrigger spawntrigger,
            [JsonProperty(PropertyName = "despawntrigger", Required = Required.AllowNull)]
            QuestGiverXmlSpawnTrigger despawntrigger,
            [JsonProperty(PropertyName = "greetingstringid", Required = Required.Always)] int greetingstringid,
            [JsonProperty(PropertyName = "greetingsoundset", Required = Required.Always)] string greetingsoundset,
            [JsonProperty(PropertyName = "farewellsoundset", Required = Required.Always)] string farewellsoundset,
            [JsonProperty(PropertyName = "artset", Required = Required.Always)] string artset,
            [JsonProperty(PropertyName = "region", Required = Required.Always)] int region,
            [JsonProperty(PropertyName = "altregion", Required = Required.Always)] int altregion,
            [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)] EventEnum @event)
        {
            Name = name;
            PlaceUnitType = placeunittype;
            Status = status;
            MapType = maptype;
            Overrides = overrides;
            Location = location;
            SpawnTrigger = spawntrigger;
            DespawnTrigger = despawntrigger;
            GreetingStringId = greetingstringid;
            GreetingSoundSet = greetingsoundset;
            FarewellSoundSet = farewellsoundset;
            ArtSet = artset;
            Region = region;
            AltRegion = altregion;
            Event = @event;
        }

        [Required]
        [JsonProperty(PropertyName = "region", Required = Required.Always)]
        [XmlAttribute(AttributeName = "region")]
        public int Region { get; set; }

        [Required]
        [JsonProperty(PropertyName = "altregion", Required = Required.Always)]
        [XmlAttribute(AttributeName = "altregion")]
        public int AltRegion { get; set; }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "placeunittype", Required = Required.Always)]
        [XmlElement(ElementName = "placeunittype")]
        public string PlaceUnitType { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "maptype", Required = Required.Always)]
        [XmlElement(ElementName = "maptype")]
        public string MapType { get; set; }

        [Required]
        [JsonProperty(PropertyName = "overrides", Required = Required.Always)]
        [XmlElement(ElementName = "overrides")]
        public QuestGiverXmlOverrides Overrides { get; set; }

        [Required]
        [JsonProperty(PropertyName = "location", Required = Required.Always)]
        [XmlElement(ElementName = "location")]
        public QuestGiverXmlLocation Location { get; set; }

        [Required]
        [JsonProperty(PropertyName = "spawntrigger", Required = Required.AllowNull)]
        [XmlElement(ElementName = "spawntrigger")]
        public QuestGiverXmlSpawnTrigger SpawnTrigger { get; set; }

        [Required]
        [JsonProperty(PropertyName = "despawntrigger", Required = Required.AllowNull)]
        [XmlElement(ElementName = "despawntrigger")]
        public QuestGiverXmlSpawnTrigger DespawnTrigger { get; set; }

        [Required]
        [JsonProperty(PropertyName = "greetingstringid", Required = Required.Always)]
        [XmlElement(ElementName = "greetingstringid")]
        public int GreetingStringId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "greetingsoundset", Required = Required.Always)]
        [XmlElement(ElementName = "greetingsoundset")]
        public string GreetingSoundSet { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "farewellsoundset", Required = Required.Always)]
        [XmlElement(ElementName = "farewellsoundset")]
        public string FarewellSoundSet { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "artset", Required = Required.Always)]
        [XmlElement(ElementName = "artset")]
        public string ArtSet { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;
    }

    [JsonObject(Title = "questgivers", Description = "")]
    [XmlRoot(ElementName = "questgivers")]
    public class QuestGiversXml
    {
        public QuestGiversXml()
        {
            QuestGiver = new Dictionary<string, QuestGiverXml>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public QuestGiversXml(
            [JsonProperty(PropertyName = "questgiver", Required = Required.Always, Order = 1)]
            IEnumerable<QuestGiverXml> questGiver)
        {
            QuestGiver = questGiver.ToDictionary(key => key.Name, StringComparer.OrdinalIgnoreCase);
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<string, QuestGiverXml> QuestGiver { get; }

        /// <summary>
        ///     Use QuestGiver Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "questgiver", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "questgiver", Order = 1)]
        public QuestGiverXml[] QuestGiverArrayDoNotUse
        {
            get => QuestGiver.Values.ToArray();
            set
            {
                QuestGiver.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        QuestGiver.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "questgivermanager", Description = "")]
    [XmlRoot(ElementName = "questgivermanager")]
    public class QuestGiverXmlManager
    {
        public QuestGiverXmlManager()
        {
        }

        [JsonConstructor]
        public QuestGiverXmlManager(
            [JsonProperty(PropertyName = "questgivers", Required = Required.Always, Order = 1)]
            QuestGiversXml questgivers)
        {
            QuestGivers = questgivers ?? throw new ArgumentNullException(nameof(questgivers));
        }

        [Required]
        [JsonProperty(PropertyName = "questgivertemplates", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "questgivertemplates", Order = 1)]
        public string QuestGiverTemplates { get; set; }

        [Required]
        [JsonProperty(PropertyName = "questgivers", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "questgivers", Order = 2)]
        public QuestGiversXml QuestGivers { get; set; }

        public static QuestGiverXmlManager FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<QuestGiverXmlManager>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}