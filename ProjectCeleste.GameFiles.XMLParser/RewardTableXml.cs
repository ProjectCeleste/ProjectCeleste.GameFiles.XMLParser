#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "rewards")]
    public class RewardTableXmlRewards
    {
        [Key]
        [JsonIgnore]
        [XmlIgnore]
        public string Key => $"{Minlevel}-{Maxlevel}";

        [XmlElement(ElementName = "xp")]
        public int Xp { get; set; }

        [XmlAttribute(AttributeName = "minlevel")]
        public int Minlevel { get; set; }

        [XmlAttribute(AttributeName = "maxlevel")]
        public int Maxlevel { get; set; }

        [XmlElement(ElementName = "capitalresource")]
        public RewardTableXmlRewardsCapitalResource CapitalResource { get; set; }
    }

    [XmlRoot(ElementName = "rewardtable")]
    public class RewardTableXml
    {
        [Key]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "rewards", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, RewardTableXmlRewards> Rewards { get; } =
            new Dictionary<string, RewardTableXmlRewards>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Rewards Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "rewards")]
        public RewardTableXmlRewards[] RewardTableArrayDoNotUse
        {
            get => Rewards.Values.ToArray();
            set
            {
                Rewards.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Rewards.Add(item.Key, item);
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

    [XmlRoot(ElementName = "capitalresource")]
    public class RewardTableXmlRewardsCapitalResource
    {
        /// <summary>
        ///     Use IsVisible Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlAttribute(AttributeName = "visible")]
        public string VisibleStrDoNotUse
        {
            get => IsVisible ? "true" : "false";
            set => IsVisible = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [XmlIgnore]
        [JsonProperty(PropertyName = "visible", Required = Required.Always)]
        public bool IsVisible { get; set; }

        [Key]
        [XmlElement(ElementName = "capitalresource")]
        public CapitalResourceTypeEnum Capitalresource { get; set; }

        [XmlElement(ElementName = "amount")]
        public double Amount { get; set; }
    }

    [XmlRoot(ElementName = "rewardtables")]
    public class RewardTablesXml
    {
        [Required]
        [JsonProperty(PropertyName = "rewardtable", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, RewardTableXml> RewardTable { get; } =
            new Dictionary<string, RewardTableXml>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use RewardTable Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "rewardtable")]
        public RewardTableXml[] RewardTableArrayDoNotUse
        {
            get => RewardTable.Values.ToArray();
            set
            {
                RewardTable.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        RewardTable.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static RewardTablesXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<RewardTablesXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}