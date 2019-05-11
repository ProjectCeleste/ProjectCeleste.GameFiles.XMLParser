#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RarityEnum
    {
        [XmlEnum("all")] [EnumMember(Value = "all")] All = -1,
        [XmlEnum("junk")] [EnumMember(Value = "junk")] Junk = 0,
        [XmlEnum("common")] [EnumMember(Value = "common")] Common = 1,
        [XmlEnum("uncommon")] [EnumMember(Value = "uncommon")] Uncommon = 2,
        [XmlEnum("rare")] [EnumMember(Value = "rare")] Rare = 3,
        [XmlEnum("epic")] [EnumMember(Value = "epic")] Epic = 4,
        [XmlEnum("legendary")] [EnumMember(Value = "legendary")] Legendary = 5
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CRarityEnum
    {
        [XmlEnum("none")] [EnumMember(Value = "none")] All = RarityEnum.All,
        [XmlEnum("cRarityJunk")] [EnumMember(Value = "cRarityJunk")] Junk = RarityEnum.Junk,
        [XmlEnum("cRarityCommon")] [EnumMember(Value = "cRarityCommon")] Common = RarityEnum.Common,
        [XmlEnum("cRarityUncommon")] [EnumMember(Value = "cRarityUncommon")] Uncommon = RarityEnum.Uncommon,
        [XmlEnum("cRarityRare")] [EnumMember(Value = "cRarityRare")] Rare = RarityEnum.Rare,
        [XmlEnum("cRarityEpic")] [EnumMember(Value = "cRarityEpic")] Epic = RarityEnum.Epic,
        [XmlEnum("cRarityLegendary")] [EnumMember(Value = "cRarityLegendary")] Legendary = RarityEnum.Legendary
    }
}