#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "reward")]
    public class MilestoneRewardDataXmlReward
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "largeicon")]
        public string Largeicon { get; set; }

        [XmlElement(ElementName = "smallicon")]
        public string Smallicon { get; set; }

        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }
    }

    [XmlRoot(ElementName = "rewards")]
    public class MilestoneRewardDataXmlRewards
    {
        [XmlElement(ElementName = "reward")]
        public List<MilestoneRewardDataXmlReward> Reward { get; set; }
    }

    [XmlRoot(ElementName = "rewardids")]
    public class MilestoneRewardDataXmlRewardIds
    {
        [XmlElement(ElementName = "id")]
        public List<string> Id { get; set; }
    }

    [XmlRoot(ElementName = "tier")]
    public class MilestoneRewardDataXmlTier
    {
        [XmlElement(ElementName = "civid")]
        public CivilizationEnum Civid { get; set; }

        [XmlElement(ElementName = "level")]
        public int Level { get; set; }

        [XmlElement(ElementName = "rewardids")]
        public MilestoneRewardDataXmlRewardIds Rewardids { get; set; }
    }

    [XmlRoot(ElementName = "tiers")]
    public class MilestoneRewardDataXmlTiers
    {
        [XmlElement(ElementName = "tier")]
        public List<MilestoneRewardDataXmlTier> Tier { get; set; }
    }

    [XmlRoot(ElementName = "milestonerewarddata")]
    public class MilestoneRewardDataXml
    {
        [XmlIgnore]
        public Dictionary<string, MilestoneRewardDataXmlReward> Rewards { get; } =
            new Dictionary<string, MilestoneRewardDataXmlReward>(StringComparer.OrdinalIgnoreCase);

        [XmlElement(ElementName = "rewards")]
        public MilestoneRewardDataXmlRewards ListRewards
        {
            get => new MilestoneRewardDataXmlRewards {Reward = Rewards.Values.ToList()};
            set
            {
                Rewards.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value.Reward)
                    try
                    {
                        Rewards.Add(item.Id, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Reward '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [XmlElement(ElementName = "tiers")]
        public MilestoneRewardDataXmlTiers Tiers { get; set; }


        public static MilestoneRewardDataXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<MilestoneRewardDataXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}