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
    [JsonObject(Title = "summary", Description = "")]
    [XmlRoot(ElementName = "summary")]
    public class EconQuestXmlSummary
    {
        public EconQuestXmlSummary()
        {
        }

        [JsonConstructor]
        public EconQuestXmlSummary(
            [JsonProperty(PropertyName = "stringid", Required = Required.Always)] HashSet<string> stringId)
        {
            StringId = stringId;
        }

        [JsonProperty(PropertyName = "stringid", Required = Required.Always)]
        [XmlElement(ElementName = "stringid")]
        public HashSet<string> StringId { get; set; }
    }

    [JsonObject(Title = "quest", Description = "")]
    [XmlRoot(ElementName = "quest")]
    public class EconQuestXml : IEconQuest
    {
        public EconQuestXml()
        {
            Event = EventEnum.None;
            Alliance = EAllianceEnum.None;
        }

        [JsonConstructor]
        public EconQuestXml([JsonProperty(PropertyName = "name", Required = Required.Always)] string name,
            [JsonProperty(PropertyName = "questid", Required = Required.Always)] int questId,
            [JsonProperty(PropertyName = "icon", Required = Required.Always)] string icon,
            [JsonProperty(PropertyName = "icontexturecoords", Required = Required.Always)] string iconTextureCoords,
            [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)] int rollOverTextId,
            [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)] int displayNameId,
            [JsonProperty(PropertyName = "typeid", Required = Required.Always)] int typeId,
            [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)] int itemLevel,
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "offertype", Required = Required.Always)] EOfferTypeEnum offerType,
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "rarity", Required = Required.Always)] CRarityEnum rarity,
            [JsonProperty(PropertyName = "summary", Required = Required.Always)] EconQuestXmlSummary summary,
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
            EAllianceEnum alliance,
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)] EventEnum @event)
        {
            Name = name;
            QuestId = questId;
            Icon = icon;
            IconTextureCoords = iconTextureCoords;
            RollOverTextId = rollOverTextId;
            DisplayNameId = displayNameId;
            TypeId = typeId;
            ItemLevel = itemLevel;
            OfferType = offerType;
            Rarity = rarity;
            Summary = summary;
            Alliance = alliance;
            Event = @event;
        }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "questid", Required = Required.Always)]
        [XmlElement(ElementName = "questid")]
        public int QuestId { get; set; }

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "icontexturecoords", Required = Required.Always)]
        [XmlElement(ElementName = "icontexturecoords")]
        public string IconTextureCoords { get; set; }

        [JsonProperty(PropertyName = "rollovertextid", Required = Required.Always)]
        [XmlElement(ElementName = "rollovertextid")]
        public int RollOverTextId { get; set; }

        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplayNameId { get; set; }

        [JsonProperty(PropertyName = "typeid", Required = Required.Always)]
        [XmlElement(ElementName = "typeid")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "itemlevel", Required = Required.Always)]
        [XmlElement(ElementName = "itemlevel")]
        public int ItemLevel { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "offertype", Required = Required.Always)]
        [XmlElement(ElementName = "offertype")]
        public EOfferTypeEnum OfferType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "rarity", Required = Required.Always)]
        [XmlElement(ElementName = "rarity")]
        public CRarityEnum Rarity { get; set; }

        [JsonProperty(PropertyName = "summary", Required = Required.Always)]
        [XmlElement(ElementName = "summary")]
        public EconQuestXmlSummary Summary { get; set; }

        [DefaultValue(EAllianceEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "alliance")]
        public EAllianceEnum Alliance { get; set; }

        [DefaultValue(EventEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "event")]
        public EventEnum Event { get; set; }
    }

    [JsonObject(Title = "quests", Description = "")]
    [XmlRoot(ElementName = "quests")]
    public class EconQuestsXml : DictionaryContainer<string, EconQuestXml, IEconQuest>, IEconQuestsXml
    {
        public EconQuestsXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconQuestsXml(
            [JsonProperty(PropertyName = "quest", Required = Required.Always)] IEnumerable<EconQuestXml> quests) :
            base(quests, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "quest", Required = Required.Always)]
        [XmlElement(ElementName = "quest")]
        public EconQuestXml[] EconQuestArrayDoNotUse
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

        public static IEconQuestsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<EconQuestsXml>(file);
        }
    }
}