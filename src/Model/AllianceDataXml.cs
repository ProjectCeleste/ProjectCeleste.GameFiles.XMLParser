using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "rankdata", Description = "")]
    [XmlRoot(ElementName = "rankdata")]
    public class AllianceDataXmlRankData
    {
        [Required]
        [JsonProperty(PropertyName = "expirytime", Required = Required.Always)]
        [XmlElement(ElementName = "expirytime", Type = typeof(XmlTimeSpan))]
        public TimeSpan ExpiryTime { get; set; }

        [Required]
        [JsonProperty(PropertyName = "calculationinterval", Required = Required.Always)]
        [XmlElement(ElementName = "calculationinterval", Type = typeof(XmlTimeSpan))]
        public TimeSpan CalculationInterval { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "minapcontribution", Required = Required.Always)]
        [XmlElement(ElementName = "minapcontribution")]
        public int MinApContribution { get; set; }
    }

    [JsonObject(Title = "passive", Description = "")]
    [XmlRoot(ElementName = "passive")]
    public class AllianceDataXmlPassive
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "tech", Required = Required.Always)]
        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }

        [Required]
        [JsonProperty(PropertyName = "techstatus", Required = Required.Always)]
        [XmlElement(ElementName = "techstatus")]
        public TechStatusEnum TechStatus { get; set; }

        [Required]
        [JsonProperty(PropertyName = "persistentcitytechstatus", Required = Required.Always)]
        [XmlElement(ElementName = "persistentcitytechstatus")]
        public TechStatusEnum PersistentCityTechStatus { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlElement(ElementName = "level")]
        public int Level { get; set; }
    }

    [JsonObject(Title = "rank", Description = "")]
    [XmlRoot(ElementName = "rank")]
    public class AllianceDataXmlRank
    {
        [Key]
        [Required]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "percentileindex", Required = Required.Always)]
        [XmlAttribute(AttributeName = "percentileindex")]
        public int PercentileIndex { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "titleid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "titleid")]
        public string TitleId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "iconpath", Required = Required.Always)]
        [XmlAttribute(AttributeName = "iconpath")]
        public string IconPath { get; set; }

        [Required]
        [JsonProperty(PropertyName = "passives", Required = Required.Always)]
        [XmlArray("passives")]
        [XmlArrayItem("passive")]
        public List<AllianceDataXmlPassive> Passives { get; set; }
    }

    [JsonObject(Title = "alliance", Description = "")]
    [XmlRoot(ElementName = "alliance")]
    public class AllianceDataXmlAlliance
    {
        [Key]
        [Required]
        [JsonProperty(PropertyName = "alliancetype", Required = Required.Always)]
        [XmlElement(ElementName = "alliancetype")]
        public EAllianceEnum AllianceType { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "chatchannelinternalname", Required = Required.Always)]
        [XmlElement(ElementName = "chatchannelinternalname")]
        public string ChatChannelInternalName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "descriptionid", Required = Required.Always)]
        [XmlElement(ElementName = "descriptionid")]
        public int DescriptionId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "homeregionid", Required = Required.Always)]
        [XmlElement(ElementName = "homeregionid")]
        public int HomeRegionId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "leadernameid", Required = Required.Always)]
        [XmlElement(ElementName = "leadernameid")]
        public int LeaderNameId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "ranks", Required = Required.Always)]
        [XmlArray("ranks")]
        [XmlArrayItem("rank")]
        public List<AllianceDataXmlRank> Ranks { get; set; }
    }

    [JsonObject(Title = "alliancedata", Description = "")]
    [XmlRoot(ElementName = "alliancedata")]
    public class AllianceDataXml : IAllianceDataXml
    {
        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "mincharacterlevel", Required = Required.Always)]
        [XmlElement(ElementName = "mincharacterlevel")]
        public int MinCharacterLevel { get; set; }


        [Required]
        [JsonProperty(PropertyName = "rankdata", Required = Required.Always)]
        [XmlElement("rankdata")]
        public AllianceDataXmlRankData RankData { get; set; }

        [Required]
        [JsonProperty(PropertyName = "alliances", Required = Required.Always)]
        [XmlArray("alliances")]
        [XmlArrayItem("alliance")]
        public List<AllianceDataXmlAlliance> Alliances { get; set; }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }

        public static IAllianceDataXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<AllianceDataXml>(file);
        }
    }
}