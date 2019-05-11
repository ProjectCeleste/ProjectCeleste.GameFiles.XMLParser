﻿#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "reward", Description = "")]
    [XmlRoot(ElementName = "reward")]
    public class MilestoneRewardDataXmlReward
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "largeicon", Required = Required.Always)]
        [XmlElement(ElementName = "largeicon")]
        public string LargeIcon { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "smallicon", Required = Required.Always)]
        [XmlElement(ElementName = "smallicon")]
        public string SmallIcon { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "tech", Required = Required.Always)]
        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }
    }

    [JsonObject(Title = "rewards", Description = "")]
    [XmlRoot(ElementName = "rewards")]
    public class MilestoneRewardDataXmlRewards : DictionaryContainer<string, MilestoneRewardDataXmlReward>
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
        [Required]
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
                        Add(item);
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
        [Required]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public HashSet<string> Id { get; set; }
    }

    [JsonObject(Title = "tier", Description = "")]
    [XmlRoot(ElementName = "tier")]
    public class MilestoneRewardDataXmlTier
    {
        [Required]
        [JsonProperty(PropertyName = "civid", Required = Required.Always)]
        [XmlElement(ElementName = "civid")]
        public CivilizationEnum CivId { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlElement(ElementName = "level")]
        public int Level { get; set; }

        [Required]
        [JsonProperty(PropertyName = "rewardids", Required = Required.Always)]
        [XmlElement(ElementName = "rewardids")]
        public MilestoneRewardDataXmlRewardIds RewardIds { get; set; }
    }

    [JsonObject(Title = "tiers", Description = "")]
    [XmlRoot(ElementName = "tiers")]
    public class MilestoneRewardDataXmlTiers
    {
        [Required]
        [JsonProperty(PropertyName = "tier", Required = Required.Always)]
        [XmlElement(ElementName = "tier")]
        public List<MilestoneRewardDataXmlTier> Tier { get; set; }
    }

    [JsonObject(Title = "milestonerewarddata", Description = "")]
    [XmlRoot(ElementName = "milestonerewarddata")]
    public class MilestoneRewardDataXml
    {
        [Required]
        [JsonProperty(PropertyName = "rewards", Required = Required.Always)]
        [XmlElement(ElementName = "rewards")]
        public MilestoneRewardDataXmlRewards Rewards { get; set; }

        [Required]
        [JsonProperty(PropertyName = "tiers", Required = Required.Always)]
        [XmlElement(ElementName = "tiers")]
        public MilestoneRewardDataXmlTiers Tiers { get; set; }

        public static MilestoneRewardDataXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<MilestoneRewardDataXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}