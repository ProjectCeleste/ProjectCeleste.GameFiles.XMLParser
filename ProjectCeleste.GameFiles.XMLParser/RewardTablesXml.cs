#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "rewards", Description = "")]
    [XmlRoot(ElementName = "rewards")]
    public class RewardTableXmlRewards
    {
        public RewardTableXmlRewards()
        {
        }

        [JsonConstructor]
        public RewardTableXmlRewards(
            [JsonProperty(PropertyName = "minlevel", Required = Required.Always, Order = 1)] int minlevel,
            [JsonProperty(PropertyName = "maxlevel", Required = Required.Always, Order = 2)] int maxlevel,
            [JsonProperty(PropertyName = "xp", DefaultValueHandling = DefaultValueHandling.Ignore, Order = 3)] int xp,
            [JsonProperty(PropertyName = "capitalresource", DefaultValueHandling = DefaultValueHandling.Ignore,
                Order = 4)] RewardTableXmlRewardsCapitalResource capitalResource)
        {
            Minlevel = minlevel;
            Maxlevel = maxlevel;
            Xp = xp;
            CapitalResource = capitalResource;
        }

        [Key]
        [JsonIgnore]
        [XmlIgnore]
        internal string Key => $"{Minlevel}-{Maxlevel}";

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "minlevel", Required = Required.Always, Order = 1)]
        [XmlAttribute(AttributeName = "minlevel")]
        public int Minlevel { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "maxlevel", Required = Required.Always, Order = 2)]
        [XmlAttribute(AttributeName = "maxlevel")]
        public int Maxlevel { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "xp", DefaultValueHandling = DefaultValueHandling.Ignore, Order = 3)]
        [XmlElement(ElementName = "xp")]
        public int Xp { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "capitalresource", DefaultValueHandling = DefaultValueHandling.Ignore, Order = 4)]
        [XmlElement(ElementName = "capitalresource")]
        public RewardTableXmlRewardsCapitalResource CapitalResource { get; set; }
    }

    [JsonObject(Title = "rewardtable", Description = "")]
    [XmlRoot(ElementName = "rewardtable")]
    public class RewardTableXml
    {
        public RewardTableXml()
        {
            Rewards = new Dictionary<string, RewardTableXmlRewards>(StringComparer.OrdinalIgnoreCase);
        }

        public RewardTableXml(string name, IDictionary<string, RewardTableXmlRewards> rewards)
        {
            Name = name;
            Rewards = new Dictionary<string, RewardTableXmlRewards>(rewards, StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public RewardTableXml([JsonProperty(PropertyName = "name", Required = Required.Always, Order = 1)] string name,
            [JsonProperty(PropertyName = "rewards", Required = Required.Always, Order = 2)]
            IEnumerable<RewardTableXmlRewards> rewards)
        {
            Name = name;
            Rewards = rewards.ToDictionary(key => key.Key, StringComparer.OrdinalIgnoreCase);
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always, Order = 1)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<string, RewardTableXmlRewards> Rewards { get; }

        /// <summary>
        ///     Use Rewards Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "rewards", Required = Required.Always, Order = 2)]
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

    [JsonObject(Title = "capitalresource", Description = "")]
    [XmlRoot(ElementName = "capitalresource")]
    public class RewardTableXmlRewardsCapitalResource
    {
        public RewardTableXmlRewardsCapitalResource()
        {
        }

        [JsonConstructor]
        public RewardTableXmlRewardsCapitalResource(
            [JsonProperty(PropertyName = "visible", Required = Required.Always, Order = 1)] bool isVisible,
            [JsonProperty(PropertyName = "capitalresource", Required = Required.Always, Order = 2)]
            CapitalResourceTypeEnum capitalresource,
            [JsonProperty(PropertyName = "amount", Required = Required.Always, Order = 3)] double amount)
        {
            IsVisible = isVisible;
            Capitalresource = capitalresource;
            Amount = amount;
        }

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
        [JsonProperty(PropertyName = "visible", Required = Required.Always, Order = 1)]
        public bool IsVisible { get; set; }

        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "capitalresource", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "capitalresource")]
        public CapitalResourceTypeEnum Capitalresource { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [JsonProperty(PropertyName = "amount", Required = Required.Always, Order = 3)]
        [XmlElement(ElementName = "amount")]
        public double Amount { get; set; }
    }

    [JsonObject(Title = "rewardtables", Description = "")]
    [XmlRoot(ElementName = "rewardtables")]
    public class RewardTablesXml
    {
        public RewardTablesXml()
        {
            RewardTable = new Dictionary<string, RewardTableXml>(StringComparer.OrdinalIgnoreCase);
        }

        public RewardTablesXml(IDictionary<string, RewardTableXml> rewardTable)
        {
            RewardTable = new Dictionary<string, RewardTableXml>(rewardTable, StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public RewardTablesXml(IEnumerable<RewardTableXml> rewardTable)
        {
            RewardTable = rewardTable.ToDictionary(key => key.Name, StringComparer.OrdinalIgnoreCase);
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<string, RewardTableXml> RewardTable { get; }

        /// <summary>
        ///     Use RewardTable Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "rewardtable", Required = Required.Always, Order = 1)]
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

        public static RewardTablesXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<RewardTablesXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}