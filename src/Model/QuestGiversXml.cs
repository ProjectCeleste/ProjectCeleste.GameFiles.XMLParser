#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
namespace ProjectCeleste.GameFiles.XMLParser.Model
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

        [JsonProperty(PropertyName = "key", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "value", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [JsonObject(Title = "overrides", Description = "")]
    [XmlRoot(ElementName = "overrides")]
    public class QuestGiverXmlOverrides : DictionaryContainer<string, QuestGiverXmlOverride>
    {
        public QuestGiverXmlOverrides() : base(key => key.Key, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public QuestGiverXmlOverrides(
            [JsonProperty(PropertyName = "override", Required = Required.Always, Order = 1)]
            IEnumerable<QuestGiverXmlOverride> @override) : base(@override, key => key.Key,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "override", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "override")]
        public QuestGiverXmlOverride[] OverrideArray
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
                        Add(item);
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

        [JsonProperty(PropertyName = "nearunittype", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "nearunittype")]
        public string NearUnitType { get; set; }

        [JsonProperty(PropertyName = "preferredoffset", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "preferredoffset")]
        public string PreferredOffset { get; set; }

        [JsonProperty(PropertyName = "radius", Required = Required.Always, Order = 3)]
        [XmlElement(ElementName = "radius")]
        public int Radius { get; set; }

        [JsonProperty(PropertyName = "useboneposition", Required = Required.Always, Order = 4)]
        [XmlElement(ElementName = "useboneposition")]
        public bool IsUseBonePosition { get; set; }
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
            [JsonProperty(PropertyName = "nearbuilding", Required = Required.AllowNull, Order = 1)]
            QuestGiverXmlNearBuilding nearbuilding)
        {
            NearBuilding = nearbuilding;
        }

        [JsonProperty(PropertyName = "nearbuilding", Required = Required.AllowNull, Order = 1)]
        [XmlElement(ElementName = "nearbuilding")]
        public QuestGiverXmlNearBuilding NearBuilding { get; set; }
    }

    [JsonObject(Title = "onunitcount", Description = "")]
    [XmlRoot(ElementName = "onunitcount")]
    public class QuestGiversXmlOnUnitCount
    {
        public QuestGiversXmlOnUnitCount()
        {
        }

        [JsonConstructor]
        public QuestGiversXmlOnUnitCount(
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

        [JsonProperty(PropertyName = "countunittype", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "countunittype")]
        public string CountUnitType { get; set; }

        [JsonProperty(PropertyName = "comparetype", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "comparetype")]
        public string CompareType { get; set; }

        [JsonProperty(PropertyName = "count", Required = Required.Always, Order = 3)]
        [XmlElement(ElementName = "count")]
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
            QuestGiversXmlOnUnitCount onunitcount,
            [JsonProperty(PropertyName = "onquest", DefaultValueHandling = DefaultValueHandling.Ignore)]
            QuestGiversXmlOnQuest onquest)
        {
            OnUnitCount = onunitcount;
            OnQuest = onquest;
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "onunitcount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "onunitcount")]
        public QuestGiversXmlOnUnitCount OnUnitCount { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "onquest", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "onquest")]
        public QuestGiversXmlOnQuest OnQuest { get; set; }
    }

    [JsonObject(Title = "questgiver", Description = "")]
    [XmlRoot(ElementName = "questgiver")]
    public class QuestGiverXml : IQuestGiver
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
            [JsonProperty(PropertyName = "greetingsoundset", Required = Required.AllowNull)] string greetingsoundset,
            [JsonProperty(PropertyName = "farewellsoundset", Required = Required.AllowNull)] string farewellsoundset,
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

        [JsonProperty(PropertyName = "region", Required = Required.Always)]
        [XmlAttribute(AttributeName = "region")]
        public int Region { get; set; }

        [JsonProperty(PropertyName = "altregion", Required = Required.Always)]
        [XmlAttribute(AttributeName = "altregion")]
        public int AltRegion { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "placeunittype", Required = Required.Always)]
        [XmlElement(ElementName = "placeunittype")]
        public string PlaceUnitType { get; set; }

        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "maptype", Required = Required.Always)]
        [XmlElement(ElementName = "maptype")]
        public string MapType { get; set; }

        [JsonProperty(PropertyName = "overrides", Required = Required.Always)]
        [XmlElement(ElementName = "overrides")]
        public QuestGiverXmlOverrides Overrides { get; set; }

        [JsonProperty(PropertyName = "location", Required = Required.Always)]
        [XmlElement(ElementName = "location")]
        public QuestGiverXmlLocation Location { get; set; }

        [JsonProperty(PropertyName = "spawntrigger", Required = Required.AllowNull)]
        [XmlElement(ElementName = "spawntrigger")]
        public QuestGiverXmlSpawnTrigger SpawnTrigger { get; set; }

        [JsonProperty(PropertyName = "despawntrigger", Required = Required.AllowNull)]
        [XmlElement(ElementName = "despawntrigger")]
        public QuestGiverXmlSpawnTrigger DespawnTrigger { get; set; }

        [JsonProperty(PropertyName = "greetingstringid", Required = Required.Always)]
        [XmlElement(ElementName = "greetingstringid")]
        public int GreetingStringId { get; set; }

        [JsonProperty(PropertyName = "greetingsoundset", Required = Required.AllowNull)]
        [XmlElement(ElementName = "greetingsoundset")]
        public string GreetingSoundSet { get; set; }

        [JsonProperty(PropertyName = "farewellsoundset", Required = Required.AllowNull)]
        [XmlElement(ElementName = "farewellsoundset")]
        public string FarewellSoundSet { get; set; }

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
    public class QuestGiversXml : DictionaryContainer<string, QuestGiverXml, IQuestGiver>, IQuestGivers
    {
        public QuestGiversXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public QuestGiversXml(
            [JsonProperty(PropertyName = "questgiver", Required = Required.Always, Order = 1)]
            IEnumerable<QuestGiverXml> questgiver) : base(questgiver, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "questgiver", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "questgiver")]
        public QuestGiverXml[] QuestGiverArrayDoNotUse
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
    }

    [JsonObject(Title = "questgivermanager", Description = "")]
    [XmlRoot(ElementName = "questgivermanager")]
    public class QuestGiverManagerXml : IQuestGiverManagerXml
    {
        public QuestGiverManagerXml()
        {
        }

        [JsonConstructor]
        public QuestGiverManagerXml(
            [JsonProperty(PropertyName = "questgivers", Required = Required.Always, Order = 1)]
            QuestGiversXml questgivers)
        {
            QuestGivers = questgivers ?? throw new ArgumentNullException(nameof(questgivers));
        }

        //[Required]
        //[JsonProperty(PropertyName = "questgivertemplates", Required = Required.Always, Order = 1)]
        //[XmlElement(ElementName = "questgivertemplates")]
        //public string QuestGiverTemplates { get;  set;}

        [JsonProperty(PropertyName = "questgivers", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "questgivers")]
        public QuestGiversXml QuestGivers { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        IQuestGivers IQuestGiverManager.QuestGivers => QuestGivers;

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static IQuestGiverManagerXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<QuestGiverManagerXml>(file);
        }
    }
}