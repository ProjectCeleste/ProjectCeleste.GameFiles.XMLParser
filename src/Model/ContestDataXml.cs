using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "reward", Description = "")]
    [XmlRoot(ElementName = "reward")]
    public class Reward
    {
        [Key]
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "placement", Required = Required.Always)]
        [XmlAttribute(AttributeName = "placement")]
        public int Placement { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "baseep", Required = Required.Always)]
        [XmlAttribute(AttributeName = "baseep")]
        public int BaseEp { get; set; }
    }

    [JsonObject(Title = "scaledreward", Description = "")]
    [XmlRoot(ElementName = "scaledreward")]
    public class ScaledReward
    {
        [Key]
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "percentileasindex", Required = Required.Always)]
        [XmlAttribute(AttributeName = "percentileasindex")]
        public int PercentileAsIndex { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "ep", Required = Required.Always)]
        [XmlAttribute(AttributeName = "ep")]
        public int Ep { get; set; }
    }

    [JsonObject(Title = "contest", Description = "")]
    [XmlRoot(ElementName = "contest")]
    public class Contest
    {
        [Key]
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [Required]
        [JsonProperty(PropertyName = "runningtime", Required = Required.Always)]
        [XmlElement(ElementName = "runningtime", Type = typeof(XmlTimeSpan))]
        public TimeSpan RunningTime { get; set; }

        [Required]
        [JsonProperty(PropertyName = "downtime", Required = Required.Always)]
        [XmlElement(ElementName = "downtime", Type = typeof(XmlTimeSpan))]
        public TimeSpan Downtime { get; set; }

        [Required]
        [JsonProperty(PropertyName = "expiretime", Required = Required.Always)]
        [XmlElement(ElementName = "expiretime", Type = typeof(XmlTimeSpan))]
        public TimeSpan ExpireTime { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "minimumap", Required = Required.Always)]
        [XmlElement(ElementName = "minimumap")]
        public int MinImuMap { get; set; }

        [Required]
        [JsonProperty(PropertyName = "rewards", Required = Required.Always)]
        [XmlArray("rewards")]
        [XmlArrayItem("reward")]
        public List<Reward> Rewards { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "scaledrewards", Required = Required.Always)]
        [XmlArray("scaledrewards")]
        [XmlArrayItem("scaledreward")]
        public List<ScaledReward> ScaledRewards { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "names", Required = Required.Always)]
        [XmlArray("names")]
        [XmlArrayItem("nameindex")]
        public List<int> Names { get; set; }
    }

    [JsonObject(Title = "contestdata", Description = "")]
    [XmlRoot(ElementName = "contestdata")]
    public class ContestData
    {
        [Required]
        [JsonProperty(PropertyName = "participationbonustime", Required = Required.Always)]
        [XmlElement(ElementName = "participationbonustime", Type = typeof(XmlTimeSpan))]
        public TimeSpan ParticipationBonusTime { get; set; }

        [Required]
        [JsonProperty(PropertyName = "contests", Required = Required.Always)]
        [XmlArray("contests")]
        [XmlArrayItem("contest")]
        public List<Contest> Contests { get; set; }
    }
}