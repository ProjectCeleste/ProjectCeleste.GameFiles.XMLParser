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

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "override")]
    public class QuestGiversXmlOverride
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        [XmlElement(ElementName = "key")]
        public string Key { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "overrides")]
    public class QuestGiversXmlOverrides
    {
        [Required]
        [XmlIgnore]
        [JsonProperty(PropertyName = "override", Required = Required.Always)]
        public Dictionary<string, QuestGiversXmlOverride> Override { get; } =
            new Dictionary<string, QuestGiversXmlOverride>(StringComparer.OrdinalIgnoreCase);

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "override")]
        public QuestGiversXmlOverride[] List
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

    [XmlRoot(ElementName = "nearbuilding")]
    public class QuestGiversXmlNearbuilding
    {
        [Required]
        [JsonProperty(PropertyName = "nearunittype", Required = Required.Always)]
        [XmlElement(ElementName = "nearunittype")]
        public string Nearunittype { get; set; }

        [Required]
        [JsonProperty(PropertyName = "preferredoffset", Required = Required.Always)]
        [XmlElement(ElementName = "preferredoffset")]
        public string Preferredoffset { get; set; }

        [Required]
        [JsonProperty(PropertyName = "radius", Required = Required.Always)]
        [XmlElement(ElementName = "radius")]
        public string Radius { get; set; }

        [Required]
        [JsonProperty(PropertyName = "useboneposition", Required = Required.Always)]
        [XmlElement(ElementName = "useboneposition")]
        public string Useboneposition { get; set; }
    }

    [XmlRoot(ElementName = "location")]
    public class QuestGiversXmlLocation
    {
        [Required]
        [JsonProperty(PropertyName = "nearbuilding", Required = Required.Always)]
        [XmlElement(ElementName = "nearbuilding")]
        public QuestGiversXmlNearbuilding Nearbuilding { get; set; }
    }

    [XmlRoot(ElementName = "onunitcount")]
    public class QuestGiversXmlOnunitcount
    {
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "countunittype", Required = Required.Always)]
        [XmlElement(ElementName = "countunittype")]
        public string Countunittype { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "comparetype", Required = Required.Always)]
        [XmlElement(ElementName = "comparetype")]
        public string Comparetype { get; set; }

        [Required]
        [JsonProperty(PropertyName = "count", Required = Required.Always)]
        [XmlElement(ElementName = "count")]
        public int Count { get; set; }
    }

    [XmlRoot(ElementName = "spawntrigger")]
    public class QuestGiversXmlSpawntrigger
    {
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "onunitcount", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "onunitcount")]
        public QuestGiversXmlOnunitcount Onunitcount { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "onquest", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "onquest")]
        public QuestGiversXmlOnquest Onquest { get; set; }
    }

    [XmlRoot(ElementName = "despawntrigger")]
    public class QuestGiversXmlDespawntrigger
    {
        [Required]
        [JsonProperty(PropertyName = "onunitcount", Required = Required.Always)]
        [XmlElement(ElementName = "onunitcount")]
        public QuestGiversXmlOnunitcount Onunitcount { get; set; }
    }

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
            [JsonProperty(PropertyName = "overrides", Required = Required.Always)] QuestGiversXmlOverrides overrides,
            [JsonProperty(PropertyName = "location", Required = Required.Always)] QuestGiversXmlLocation location,
            [JsonProperty(PropertyName = "spawntrigger", Required = Required.AllowNull)]
            QuestGiversXmlSpawntrigger spawntrigger,
            [JsonProperty(PropertyName = "despawntrigger", Required = Required.AllowNull)]
            QuestGiversXmlDespawntrigger despawntrigger,
            [JsonProperty(PropertyName = "greetingstringid", Required = Required.Always)] int greetingstringid,
            [JsonProperty(PropertyName = "greetingsoundset", Required = Required.Always)] string greetingsoundset,
            [JsonProperty(PropertyName = "farewellsoundset", Required = Required.Always)] string farewellsoundset,
            [JsonProperty(PropertyName = "artset", Required = Required.Always)] string artset,
            [JsonProperty(PropertyName = "region", Required = Required.Always)] int region,
            [JsonProperty(PropertyName = "altregion", Required = Required.Always)] int altregion,
            [JsonProperty(PropertyName = "event", Required = Required.Default,
                DefaultValueHandling = DefaultValueHandling.Ignore)] EventEnum @event)
        {
            Name = name;
            Placeunittype = placeunittype;
            Status = status;
            Maptype = maptype;
            Overrides = overrides;
            Location = location;
            Spawntrigger = spawntrigger;
            Despawntrigger = despawntrigger;
            Greetingstringid = greetingstringid;
            Greetingsoundset = greetingsoundset;
            Farewellsoundset = farewellsoundset;
            Artset = artset;
            Region = region;
            Altregion = altregion;
            Event = @event;
        }

        [Required]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "placeunittype", Required = Required.Always)]
        [XmlElement(ElementName = "placeunittype")]
        public string Placeunittype { get; set; }

        [Required]
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [Required]
        [JsonProperty(PropertyName = "maptype", Required = Required.Always)]
        [XmlElement(ElementName = "maptype")]
        public string Maptype { get; set; }

        [Required]
        [JsonProperty(PropertyName = "overrides", Required = Required.Always)]
        [XmlElement(ElementName = "overrides")]
        public QuestGiversXmlOverrides Overrides { get; set; }

        [Required]
        [JsonProperty(PropertyName = "location", Required = Required.Always)]
        [XmlElement(ElementName = "location")]
        public QuestGiversXmlLocation Location { get; set; }

        [Required]
        [JsonProperty(PropertyName = "spawntrigger", Required = Required.AllowNull)]
        [XmlElement(ElementName = "spawntrigger")]
        public QuestGiversXmlSpawntrigger Spawntrigger { get; set; }

        [Required]
        [JsonProperty(PropertyName = "despawntrigger", Required = Required.AllowNull)]
        [XmlElement(ElementName = "despawntrigger")]
        public QuestGiversXmlDespawntrigger Despawntrigger { get; set; }

        [Required]
        [JsonProperty(PropertyName = "greetingstringid", Required = Required.Always)]
        [XmlElement(ElementName = "greetingstringid")]
        public int Greetingstringid { get; set; }

        [Required]
        [JsonProperty(PropertyName = "greetingsoundset", Required = Required.Always)]
        [XmlElement(ElementName = "greetingsoundset")]
        public string Greetingsoundset { get; set; }

        [Required]
        [JsonProperty(PropertyName = "farewellsoundset", Required = Required.Always)]
        [XmlElement(ElementName = "farewellsoundset")]
        public string Farewellsoundset { get; set; }

        [Required]
        [JsonProperty(PropertyName = "artset", Required = Required.Always)]
        [XmlElement(ElementName = "artset")]
        public string Artset { get; set; }

        [Required]
        [JsonProperty(PropertyName = "region", Required = Required.Always)]
        [XmlAttribute(AttributeName = "region")]
        public int Region { get; set; }

        [Required]
        [JsonProperty(PropertyName = "altregion", Required = Required.Always)]
        [XmlAttribute(AttributeName = "altregion")]
        public int Altregion { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonProperty(PropertyName = "event", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;
    }

    [XmlRoot(ElementName = "onquest")]
    public class QuestGiversXmlOnquest
    {
        [Required]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }

    [XmlRoot(ElementName = "questgivers")]
    public class QuestGiversXml
    {
        [Required]
        [XmlIgnore]
        [JsonProperty(PropertyName = "questgiver", Required = Required.Always)]
        public Dictionary<string, QuestGiverXml> QuestGiver { get; } =
            new Dictionary<string, QuestGiverXml>(StringComparer.OrdinalIgnoreCase);

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "questgiver")]
        public QuestGiverXml[] List
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

    [XmlRoot(ElementName = "questgivermanager")]
    public class QuestGiverXmlManager
    {
        //[Required]
        //[JsonProperty(PropertyName = "questgivertemplates", Required = Required.Always)]
        //[XmlElement(ElementName = "questgivertemplates")]
        //public string Questgivertemplates { get; set; }

        [Required]
        [JsonProperty(PropertyName = "questgivers", Required = Required.Always)]
        [XmlElement(ElementName = "questgivers")]
        public QuestGiversXml Questgivers { get; set; }

        public static QuestGiverXmlManager FromFile(string file)
        {
            return XmlUtils.FromXmlFile<QuestGiverXmlManager>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}