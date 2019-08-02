#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Model
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
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
    public class RewardTableXml : IRewardTable
    {
        public RewardTableXml()
        {
            Rewards = new DictionaryContainer<string, RewardTableXmlRewards>(key => key.Key,
                StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public RewardTableXml([JsonProperty(PropertyName = "name", Required = Required.Always, Order = 1)] string name,
            [JsonProperty(PropertyName = "rewards", Required = Required.Always, Order = 2)]
            IEnumerable<RewardTableXmlRewards> rewards)
        {
            Name = name;
            Rewards = new DictionaryContainer<string, RewardTableXmlRewards>(rewards, key => key.Key,
                StringComparer.OrdinalIgnoreCase);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "rewards", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "rewards")]
        public RewardTableXmlRewards[] RewardArray
        {
            get => Rewards.Gets().ToArray();
            set
            {
                Rewards.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Rewards.Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Key}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always, Order = 1)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, RewardTableXmlRewards> Rewards { get; }
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
            Visible = isVisible;
            Capitalresource = capitalresource;
            Amount = amount;
        }

        [Required]
        [JsonProperty(PropertyName = "visible", Required = Required.Always, Order = 1)]
        [XmlAttribute(AttributeName = "visible")]
        public bool Visible { get; set; }

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
    public class RewardTablesXml : DictionaryContainer<string, RewardTableXml, IRewardTable>, IRewardTablesXml
    {
        public RewardTablesXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public RewardTablesXml(
            [JsonProperty(PropertyName = "rewardtable", Required = Required.Always)]
            IEnumerable<RewardTableXml> rewardtable) : base(rewardtable, key => key.Name,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "rewardtable", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "rewardtable")]
        public RewardTableXml[] RewardTableArray
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
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }

        public static IRewardTablesXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<RewardTablesXml>(file);
        }
    }
}