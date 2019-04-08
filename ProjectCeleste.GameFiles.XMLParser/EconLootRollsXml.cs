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
    [JsonObject(Title = "lootroll", Description = "")]
    [XmlRoot(ElementName = "lootroll")]
    public class EconLootRollXml
    {
        public EconLootRollXml()
        {
        }

        [JsonConstructor]
        public EconLootRollXml([JsonProperty(PropertyName = "name", Required = Required.Always)] string name,
            [JsonProperty(PropertyName = "icon", Required = Required.Always)] string icon,
            [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)] int rollOverTextId,
            [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)] int displayNameId,
            [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)] int itemLevel,
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "rarity", Required = Required.Always)] CRarityEnum rarity,
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "loottable", Required = Required.Always)] LootTableEnum lootTable,
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EAllianceEnum alliance,
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)] EventEnum @event)
        {
            Name = name;
            Icon = icon;
            RollOverTextId = rollOverTextId;
            DisplayNameId = displayNameId;
            ItemLevel = itemLevel;
            Rarity = rarity;
            LootTable = lootTable;
            Alliance = alliance;
            Event = @event;
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public int RollOverTextId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)]
        [XmlElement(ElementName = "itemlevel")]
        public int ItemLevel { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public CRarityEnum Rarity { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "loottable", Required = Required.Always)]
        [XmlElement(ElementName = "loottable")]
        public LootTableEnum LootTable { get; set; }

        [DefaultValue(EAllianceEnum.None)]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; } = EAllianceEnum.None;

        [DefaultValue(EventEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; } = EventEnum.None;
    }

    [JsonObject(Title = "lootrolls", Description = "")]
    [XmlRoot(ElementName = "lootrolls")]
    public class EconLootRollsXml
    {
        [JsonProperty(PropertyName = "lootroll", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, EconLootRollXml> LootRoll { get; } =
            new Dictionary<string, EconLootRollXml>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use LootRoll Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "lootroll")]
        public EconLootRollXml[] EconLootRollArrayDoNotUse
        {
            get => LootRoll.Values.ToArray();
            set
            {
                LootRoll.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        LootRoll.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static EconLootRollsXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<EconLootRollsXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}