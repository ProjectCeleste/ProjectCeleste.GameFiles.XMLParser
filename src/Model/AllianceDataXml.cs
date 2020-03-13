using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "passive", Description = "")]
    [XmlRoot(ElementName = "passive")]
    public class AllianceXmlPassive : IAlliancePassive
    {
        public AllianceXmlPassive()
        {
        }

        [JsonConstructor]
        public AllianceXmlPassive(
            [JsonProperty(PropertyName = "tech", Required = Required.Always)]
            string tech,
            [JsonProperty(PropertyName = "techstatus", Required = Required.Always)]
            TechStatusEnum techStatus,
            [JsonProperty(PropertyName = "persistentcitytechstatus", Required = Required.Always)]
            TechStatusEnum persistentCityTechStatus,
            [Range(0, 99)] [JsonProperty(PropertyName = "level", Required = Required.Always)]
            int level)
        {
            Tech = tech;
            TechStatus = techStatus;
            PersistentCityTechStatus = persistentCityTechStatus;
            Level = level;
        }

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
    public class AllianceXmlRank : IAllianceRank
    {
        public AllianceXmlRank()
        {
            Passives = new DictionaryContainer<string, IAlliancePassive>(key => key.Tech,
                StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public AllianceXmlRank(
            [Range(-1, int.MaxValue)] [JsonProperty(PropertyName = "percentileindex", Required = Required.Always)]
            int percentileIndex,
            [Range(0, int.MaxValue)] [JsonProperty(PropertyName = "titleid", Required = Required.Always)]
            string titleId,
            [JsonProperty(PropertyName = "iconpath", Required = Required.Always)]
            string iconPath,
            [JsonProperty(PropertyName = "passives", Required = Required.Always)]
            IEnumerable<AllianceXmlPassive> passives)
        {
            PercentileIndex = percentileIndex;
            TitleId = titleId;
            IconPath = iconPath;
            Passives = new DictionaryContainer<string, IAlliancePassive>(passives, key => key.Tech,
                StringComparer.OrdinalIgnoreCase);
        }

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

        [JsonIgnore] [XmlIgnore] public IDictionaryContainer<string, IAlliancePassive> Passives { get; }

        [JsonIgnore] [XmlIgnore] IReadOnlyContainer<string, IAlliancePassive> IAllianceRank.Passives => Passives;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "passives", Required = Required.Always)]
        [XmlArray("passives")]
        [XmlArrayItem("passive", typeof(AllianceXmlPassive))]
        public IAlliancePassive[] PassivesXmlArray
        {
            get => Passives.Gets().ToArray();
            set
            {
                Passives.Clear();
                Passives.Add(value);
            }
        }
    }

    [JsonObject(Title = "alliance", Description = "")]
    [XmlRoot(ElementName = "alliance")]
    public class AllianceXml : IAlliance
    {
        public AllianceXml()
        {
            Ranks = new DictionaryContainer<int, IAllianceRank>(key => key.PercentileIndex);
        }

        [JsonConstructor]
        public AllianceXml(
            [JsonProperty(PropertyName = "alliancetype", Required = Required.Always)]
            EAllianceEnum allianceType,
            [JsonProperty(PropertyName = "chatchannelinternalname", Required = Required.Always)]
            string chatChannelInternalName,
            [Range(0, int.MaxValue)] [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
            int displayNameId,
            [Range(0, int.MaxValue)] [JsonProperty(PropertyName = "descriptionid", Required = Required.Always)]
            int descriptionId,
            [Range(0, int.MaxValue)] [JsonProperty(PropertyName = "homeregionid", Required = Required.Always)]
            int homeRegionId,
            [Range(0, int.MaxValue)] [JsonProperty(PropertyName = "leadernameid", Required = Required.Always)]
            int leaderNameId,
            [JsonProperty(PropertyName = "ranks", Required = Required.Always)]
            IEnumerable<IAllianceRank> ranks)
        {
            AllianceType = allianceType;
            ChatChannelInternalName = chatChannelInternalName;
            DisplayNameId = displayNameId;
            DescriptionId = descriptionId;
            HomeRegionId = homeRegionId;
            LeaderNameId = leaderNameId;
            Ranks = new DictionaryContainer<int, IAllianceRank>(ranks, key => key.PercentileIndex);
        }

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

        [JsonIgnore] [XmlIgnore] public IDictionaryContainer<int, IAllianceRank> Ranks { get; }

        [JsonIgnore] [XmlIgnore] IReadOnlyContainer<int, IAllianceRank> IAlliance.Ranks => Ranks;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "ranks", Required = Required.Always)]
        [XmlArray("ranks")]
        [XmlArrayItem("rank", typeof(AllianceXmlRank))]
        public IAllianceRank[] RanksXmlArray
        {
            get => Ranks.Gets().ToArray();
            set
            {
                Ranks.Clear();
                Ranks.Add(value);
            }
        }
    }

    [JsonObject(Title = "rankdata", Description = "")]
    [XmlRoot(ElementName = "rankdata")]
    public class AllianceDataXmlRank : IAllianceDataRank
    {
        public AllianceDataXmlRank()
        {
        }

        [JsonConstructor]
        public AllianceDataXmlRank(
            [JsonProperty(PropertyName = "expirytime", Required = Required.Always)]
            TimeSpan expiryTime,
            [JsonProperty(PropertyName = "calculationinterval", Required = Required.Always)]
            TimeSpan calculationInterval,
            [Range(0, int.MaxValue)] [JsonProperty(PropertyName = "minapcontribution", Required = Required.Always)]
            int minApContribution)
        {
            ExpiryTime = expiryTime;
            CalculationInterval = calculationInterval;
            MinApContribution = minApContribution;
        }

        [Required]
        [JsonProperty(PropertyName = "expirytime", Required = Required.Always)]
        [XmlElement(ElementName = "expirytime", Type = typeof(XmlTimeSpan))]
        public TimeSpan ExpiryTime { get; set; }

        [Required]
        [JsonProperty(PropertyName = "calculationinterval", Required = Required.Always)]
        [XmlElement(ElementName = "calculationinterval", Type = typeof(XmlTimeSpan))]
        public TimeSpan CalculationInterval { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "minapcontribution", Required = Required.Always)]
        [XmlElement(ElementName = "minapcontribution")]
        public int MinApContribution { get; set; }
    }

    [JsonObject(Title = "alliancedata", Description = "")]
    [XmlRoot(ElementName = "alliancedata")]
    public class AllianceDataXml : DictionaryContainer<EAllianceEnum, IAlliance>, IAllianceDataXml
    {
        public AllianceDataXml() : base(key => key.AllianceType)
        {
        }

        [JsonConstructor]
        public AllianceDataXml(
            [Range(0, 99)] [JsonProperty(PropertyName = "mincharacterlevel", Required = Required.Always)]
            int minCharacterLevel,
            [JsonProperty(PropertyName = "rankdata", Required = Required.Always)]
            AllianceDataXmlRank rankData,
            [JsonProperty(PropertyName = "alliances", Required = Required.Always)]
            IEnumerable<AllianceXml> alliances) : base(alliances, key => key.AllianceType)
        {
            MinCharacterLevel = minCharacterLevel;
            RankData = rankData;
        }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "mincharacterlevel", Required = Required.Always)]
        [XmlElement(ElementName = "mincharacterlevel")]
        public int MinCharacterLevel { get; set; }

        [Required]
        [JsonProperty(PropertyName = "rankdata", Required = Required.Always)]
        [XmlElement("rankdata", typeof(AllianceDataXmlRank))]
        public IAllianceDataRank RankData { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "alliances", Required = Required.Always)]
        [XmlArray("alliances")]
        [XmlArrayItem("alliance", typeof(AllianceXml))]
        public IAlliance[] AlliancesXmlArray
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                Add(value);
            }
        }

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