using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "reward", Description = "")]
    [XmlRoot(ElementName = "reward")]
    public class AllianceContestXmlReward : IAllianceContestReward
    {
        public AllianceContestXmlReward()
        {
        }

        [JsonConstructor]
        public AllianceContestXmlReward(
            [JsonProperty(PropertyName = "placement", Required = Required.Always)]
            int placement,
            [JsonProperty(PropertyName = "baseep", Required = Required.Always)]
            int baseEp)
        {
            Placement = placement;
            BaseEp = baseEp;
        }

        [JsonProperty(PropertyName = "placement", Required = Required.Always)]
        [XmlAttribute(AttributeName = "placement")]
        public int Placement { get; set; }

        [JsonProperty(PropertyName = "baseep", Required = Required.Always)]
        [XmlAttribute(AttributeName = "baseep")]
        public int BaseEp { get; set; }
    }

    [JsonObject(Title = "scaledreward", Description = "")]
    [XmlRoot(ElementName = "scaledreward")]
    public class AllianceContestXmlScaledReward : IAllianceContestScaledReward
    {
        public AllianceContestXmlScaledReward()
        {
        }

        [JsonConstructor]
        public AllianceContestXmlScaledReward(
            [JsonProperty(PropertyName = "percentileasindex", Required = Required.Always)]
            int percentileAsIndex,
            [JsonProperty(PropertyName = "ep", Required = Required.Always)]
            int ep)
        {
            PercentileAsIndex = percentileAsIndex;
            Ep = ep;
        }

        [JsonProperty(PropertyName = "percentileasindex", Required = Required.Always)]
        [XmlAttribute(AttributeName = "percentileasindex")]
        public int PercentileAsIndex { get; set; }

        [JsonProperty(PropertyName = "ep", Required = Required.Always)]
        [XmlAttribute(AttributeName = "ep")]
        public int Ep { get; set; }
    }

    [JsonObject(Title = "contest", Description = "")]
    [XmlRoot(ElementName = "contest")]
    public class ContestDataXmlContest
    {
        public ContestDataXmlContest()
        {
        }

        public ContestDataXmlContest(string type,
            TimeSpan runningTime,
            TimeSpan downtime,
            TimeSpan expireTime,
            int minimumAp,
            List<AllianceContestXmlReward> rewards,
            List<AllianceContestXmlScaledReward> scaledRewards,
            HashSet<int> names)
        {
            Type = type;
            RunningTime = runningTime;
            Downtime = downtime;
            ExpireTime = expireTime;
            MinimumAp = minimumAp;
            Rewards = rewards;
            ScaledRewards = scaledRewards;
            Names = names;
        }

        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "runningtime", Required = Required.Always)]
        [XmlElement(ElementName = "runningtime", Type = typeof(XmlTimeSpan))]
        public XmlTimeSpan RunningTime { get; set; }

        [JsonProperty(PropertyName = "downtime", Required = Required.Always)]
        [XmlElement(ElementName = "downtime", Type = typeof(XmlTimeSpan))]
        public XmlTimeSpan Downtime { get; set; }

        [JsonProperty(PropertyName = "expiretime", Required = Required.Always)]
        [XmlElement(ElementName = "expiretime", Type = typeof(XmlTimeSpan))]
        public XmlTimeSpan ExpireTime { get; set; }

        [JsonProperty(PropertyName = "minimumap", Required = Required.Always)]
        [XmlElement(ElementName = "minimumap")]
        public int MinimumAp { get; set; }

        [JsonProperty(PropertyName = "rewards", Required = Required.Always)]
        [XmlArray("rewards")]
        [XmlArrayItem("reward")]
        public List<AllianceContestXmlReward> Rewards { get; set; }

        [JsonProperty(PropertyName = "scaledrewards", Required = Required.Always)]
        [XmlArray("scaledrewards")]
        [XmlArrayItem("scaledreward")]
        public List<AllianceContestXmlScaledReward> ScaledRewards { get; set; }

        [JsonProperty(PropertyName = "names", Required = Required.Always)]
        [XmlArray("names")]
        [XmlArrayItem("nameindex")]
        public HashSet<int> Names { get; set; }
    }

    [JsonObject(Title = "contestdata", Description = "")]
    [XmlRoot(ElementName = "contestdata")]
    public class ContestDataXml : DictionaryContainer<string, ContestDataXmlContest>, IContestDataXml
    {
        public ContestDataXml() : base(key => key.Type, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public ContestDataXml(
            [JsonProperty(PropertyName = "participationbonustime", Required = Required.Always)]
            TimeSpan participationBonusTime,
            [JsonProperty(PropertyName = "contests", Required = Required.Always)]
            IEnumerable<ContestDataXmlContest> contests) : base(contests, key => key.Type, StringComparer.OrdinalIgnoreCase)
        {
            ParticipationBonusTime = participationBonusTime;
        }

        [JsonProperty(PropertyName = "participationbonustime", Required = Required.Always)]
        [XmlElement(ElementName = "participationbonustime", Type = typeof(XmlTimeSpan))]
        public XmlTimeSpan ParticipationBonusTime { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "contests", Required = Required.Always)]
        [XmlArray("contests")]
        [XmlArrayItem("contest", typeof(ContestDataXmlContest))]
        public ContestDataXmlContest[] ContestsXmlArray
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
            this.SerializeToXmlFile(file);
        }

        public static IContestDataXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<ContestDataXml>(file);
        }
    }
}