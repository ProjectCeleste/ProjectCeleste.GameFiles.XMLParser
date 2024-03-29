﻿#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "lootroll", Description = "")]
    [XmlRoot(ElementName = "lootroll")]
    public class EconLootRollXml : IEconLootRoll
    {
        public EconLootRollXml()
        {
            Event = EventEnum.None;
            Alliance = EAllianceEnum.None;
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

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public int RollOverTextId { get; set; }

        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)]
        [XmlElement(ElementName = "itemlevel")]
        public int ItemLevel { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public CRarityEnum Rarity { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "loottable", Required = Required.Always)]
        [XmlElement(ElementName = "loottable")]
        public LootTableEnum LootTable { get; set; }

        [DefaultValue(EAllianceEnum.None)]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; }
    }

    [JsonObject(Title = "lootrolls", Description = "")]
    [XmlRoot(ElementName = "lootrolls")]
    public class EconLootRollsXml : DictionaryContainer<string, EconLootRollXml, IEconLootRoll>, IEconLootRollsXml
    {
        public EconLootRollsXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconLootRollsXml(
            [JsonProperty(PropertyName = "lootroll", Required = Required.Always)]
            IEnumerable<EconLootRollXml> lootrolls) : base(lootrolls, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "lootroll", Required = Required.Always)]
        [XmlElement(ElementName = "lootroll")]
        public EconLootRollXml[] LootRollArray
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
            this.SerializeToXmlFile(file);
        }

        public static IEconLootRollsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<EconLootRollsXml>(file);
        }
    }
}