﻿#region Using directives

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
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "reward", Description = "")]
    [XmlRoot(ElementName = "reward")]
    public class MilestoneRewardDataXmlReward
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "largeicon", Required = Required.Always)]
        [XmlElement(ElementName = "largeicon")]
        public string LargeIcon { get; set; }

        [JsonProperty(PropertyName = "smallicon", Required = Required.Always)]
        [XmlElement(ElementName = "smallicon")]
        public string SmallIcon { get; set; }

        [JsonProperty(PropertyName = "tech", Required = Required.Always)]
        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }
    }

    [JsonObject(Title = "rewards", Description = "")]
    [XmlRoot(ElementName = "rewards")]
    public class MilestoneRewardDataXmlRewards : DictionaryContainer<string, MilestoneRewardDataXmlReward>,
        IMilestoneRewardDataRewards
    {
        public MilestoneRewardDataXmlRewards() : base(key => key.Id, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public MilestoneRewardDataXmlRewards(
            [JsonProperty(PropertyName = "reward", Required = Required.Always)]
            IEnumerable<MilestoneRewardDataXmlReward> rewards) : base(rewards, key => key.Id,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "reward", Required = Required.Always)]
        [XmlElement(ElementName = "reward")]
        public MilestoneRewardDataXmlReward[] ModifierArrayDoNotUse
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
                        excs.Add(new Exception($"Item '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "rewardids", Description = "")]
    [XmlRoot(ElementName = "rewardids")]
    public class MilestoneRewardDataXmlRewardIds
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public HashSet<string> Id { get; set; }
    }

    [JsonObject(Title = "tier", Description = "")]
    [XmlRoot(ElementName = "tier")]
    public class MilestoneRewardDataXmlTier
    {
        [JsonProperty(PropertyName = "civid", Required = Required.Always)]
        [XmlElement(ElementName = "civid")]
        public CivilizationEnum CivId { get; set; }

        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlElement(ElementName = "level")]
        public int Level { get; set; }

        [JsonProperty(PropertyName = "rewardids", Required = Required.Always)]
        [XmlElement(ElementName = "rewardids")]
        public MilestoneRewardDataXmlRewardIds RewardIds { get; set; }
    }

    [JsonObject(Title = "tiers", Description = "")]
    [XmlRoot(ElementName = "tiers")]
    public class MilestoneRewardDataXmlTiers : DictionaryContainer<string, MilestoneRewardDataXmlTier>,
        IMilestoneRewardDataTiers
    {
        public MilestoneRewardDataXmlTiers() : base(key => $"{key.CivId}-{key.Level}", StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public MilestoneRewardDataXmlTiers(
            [JsonProperty(PropertyName = "tier", Required = Required.Always)]
            IEnumerable<MilestoneRewardDataXmlTier> tier) : base(tier, key => $"{key.CivId}-{key.Level}",
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "tier", Required = Required.Always)]
        [XmlElement(ElementName = "tier")]
        public MilestoneRewardDataXmlTier[] TierArrayDoNotUse
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
                        excs.Add(new Exception($"Item '{item.CivId}-{item.Level}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "milestonerewarddata", Description = "")]
    [XmlRoot(ElementName = "milestonerewarddata")]
    public class MilestoneRewardDataXml : IMilestoneRewardDataXml
    {
        [JsonProperty(PropertyName = "rewards", Required = Required.Always)]
        [XmlElement(ElementName = "rewards")]
        public MilestoneRewardDataXmlRewards Rewards { get; set; }

        [JsonProperty(PropertyName = "tiers", Required = Required.Always)]
        [XmlElement(ElementName = "tiers")]
        public MilestoneRewardDataXmlTiers Tiers { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        IMilestoneRewardDataRewards IMilestoneRewardData.Rewards => Rewards;

        [JsonIgnore]
        [XmlIgnore]
        IMilestoneRewardDataTiers IMilestoneRewardData.Tiers => Tiers;

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static IMilestoneRewardDataXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<MilestoneRewardDataXml>(file);
        }
    }
}