using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

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
            [JsonProperty(PropertyName = "level", Required = Required.Always)]
            int level)
        {
            Tech = tech;
            TechStatus = techStatus;
            PersistentCityTechStatus = persistentCityTechStatus;
            Level = level;
        }

        [JsonProperty(PropertyName = "tech", Required = Required.Always)]
        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }

        [JsonProperty(PropertyName = "techstatus", Required = Required.Always)]
        [XmlElement(ElementName = "techstatus")]
        public TechStatusEnum TechStatus { get; set; }

        [JsonProperty(PropertyName = "persistentcitytechstatus", Required = Required.Always)]
        [XmlElement(ElementName = "persistentcitytechstatus")]
        public TechStatusEnum PersistentCityTechStatus { get; set; }

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
            Passives = new DictionaryContainer<string, AllianceXmlPassive>(key => key.Tech,
                StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public AllianceXmlRank(
            [JsonProperty(PropertyName = "percentileindex", Required = Required.Always)]
            int percentileIndex,
            [JsonProperty(PropertyName = "titleid", Required = Required.Always)]
            string titleId,
            [JsonProperty(PropertyName = "iconpath", Required = Required.Always)]
            string iconPath,
            [JsonProperty(PropertyName = "passives", Required = Required.Always)]
            IEnumerable<AllianceXmlPassive> passives)
        {
            PercentileIndex = percentileIndex;
            TitleId = titleId;
            IconPath = iconPath;
            Passives = new DictionaryContainer<string, AllianceXmlPassive>(passives, key => key.Tech,
                StringComparer.OrdinalIgnoreCase);
        }

        [JsonProperty(PropertyName = "percentileindex", Required = Required.Always)]
        [XmlAttribute(AttributeName = "percentileindex")]
        public int PercentileIndex { get; set; }

        [JsonProperty(PropertyName = "titleid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "titleid")]
        public string TitleId { get; set; }

        [JsonProperty(PropertyName = "iconpath", Required = Required.Always)]
        [XmlAttribute(AttributeName = "iconpath")]
        public string IconPath { get; set; }

        [JsonIgnore] [XmlIgnore] public IDictionaryContainer<string, AllianceXmlPassive> Passives { get; }

        [JsonIgnore] [XmlIgnore] IReadOnlyContainer<string, IAlliancePassive> IAllianceRank.Passives => Passives;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "passives", Required = Required.Always)]
        [XmlArray("passives")]
        [XmlArrayItem("passive", typeof(AllianceXmlPassive))]
        public AllianceXmlPassive[] PassivesXmlArray
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
            Ranks = new DictionaryContainer<int, AllianceXmlRank>(key => key.PercentileIndex);
        }

        [JsonConstructor]
        public AllianceXml(
            [JsonProperty(PropertyName = "alliancetype", Required = Required.Always)]
            EAllianceEnum allianceType,
            [JsonProperty(PropertyName = "chatchannelinternalname", Required = Required.Always)]
            string chatChannelInternalName,
            [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
            int displayNameId,
            [JsonProperty(PropertyName = "descriptionid", Required = Required.Always)]
            int descriptionId,
            [JsonProperty(PropertyName = "homeregionid", Required = Required.Always)]
            int homeRegionId,
            [JsonProperty(PropertyName = "leadernameid", Required = Required.Always)]
            int leaderNameId,
            [JsonProperty(PropertyName = "ranks", Required = Required.Always)]
            IEnumerable<AllianceXmlRank> ranks)
        {
            AllianceType = allianceType;
            ChatChannelInternalName = chatChannelInternalName;
            DisplayNameId = displayNameId;
            DescriptionId = descriptionId;
            HomeRegionId = homeRegionId;
            LeaderNameId = leaderNameId;
            Ranks = new DictionaryContainer<int, AllianceXmlRank>(ranks, key => key.PercentileIndex);
        }

        [JsonProperty(PropertyName = "alliancetype", Required = Required.Always)]
        [XmlElement(ElementName = "alliancetype")]
        public EAllianceEnum AllianceType { get; set; }

        [JsonProperty(PropertyName = "chatchannelinternalname", Required = Required.Always)]
        [XmlElement(ElementName = "chatchannelinternalname")]
        public string ChatChannelInternalName { get; set; }

        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [JsonProperty(PropertyName = "descriptionid", Required = Required.Always)]
        [XmlElement(ElementName = "descriptionid")]
        public int DescriptionId { get; set; }

        [JsonProperty(PropertyName = "homeregionid", Required = Required.Always)]
        [XmlElement(ElementName = "homeregionid")]
        public int HomeRegionId { get; set; }

        [JsonProperty(PropertyName = "leadernameid", Required = Required.Always)]
        [XmlElement(ElementName = "leadernameid")]
        public int LeaderNameId { get; set; }

        [JsonIgnore] [XmlIgnore] public IDictionaryContainer<int, AllianceXmlRank> Ranks { get; }

        [JsonIgnore] [XmlIgnore] IReadOnlyContainer<int, IAllianceRank> IAlliance.Ranks => Ranks;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "ranks", Required = Required.Always)]
        [XmlArray("ranks")]
        [XmlArrayItem("rank", typeof(AllianceXmlRank))]
        public AllianceXmlRank[] RanksXmlArray
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
            [JsonProperty(PropertyName = "minapcontribution", Required = Required.Always)]
            int minApContribution)
        {
            ExpiryTime = expiryTime;
            CalculationInterval = calculationInterval;
            MinApContribution = minApContribution;
        }

        [JsonProperty(PropertyName = "expirytime", Required = Required.Always)]
        [XmlElement(ElementName = "expirytime", Type = typeof(XmlTimeSpan))]
        public XmlTimeSpan ExpiryTime { get; set; }

        [JsonProperty(PropertyName = "calculationinterval", Required = Required.Always)]
        [XmlElement(ElementName = "calculationinterval", Type = typeof(XmlTimeSpan))]
        public XmlTimeSpan CalculationInterval { get; set; }

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
            [JsonProperty(PropertyName = "mincharacterlevel", Required = Required.Always)]
            int minCharacterLevel,
            [JsonProperty(PropertyName = "rankdata", Required = Required.Always)]
            AllianceDataXmlRank rankData,
            [JsonProperty(PropertyName = "alliances", Required = Required.Always)]
            IEnumerable<AllianceXml> alliances) : base(alliances, key => key.AllianceType)
        {
            MinCharacterLevel = minCharacterLevel;
            RankData = rankData;
        }

        [JsonProperty(PropertyName = "mincharacterlevel", Required = Required.Always)]
        [XmlElement(ElementName = "mincharacterlevel")]
        public int MinCharacterLevel { get; set; }

        [JsonProperty(PropertyName = "rankdata", Required = Required.Always)]
        [XmlElement("rankdata", typeof(AllianceDataXmlRank))]
        public AllianceDataXmlRank RankData { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        IAllianceDataRank IAllianceData.RankData => RankData;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "alliances", Required = Required.Always)]
        [XmlArray("alliances")]
        [XmlArrayItem("alliance", typeof(AllianceXml))]
        public AllianceXml[] AlliancesXmlArray
        {
            get => Gets().Cast<AllianceXml>().ToArray();
            set
            {
                Clear();
                Add(value);
            }
        }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static IAllianceDataXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<AllianceDataXml>(file);
        }
    }
}