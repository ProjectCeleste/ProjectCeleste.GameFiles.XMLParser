#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceTypeEnum
    {
        [XmlEnum("Invalid")] [EnumMember(Value = "Invalid")] Invalid = 0,
        [XmlEnum("Wood")] [EnumMember(Value = "Wood")] Wood = 1,
        [XmlEnum("Food")] [EnumMember(Value = "Food")] Food = 2,
        [XmlEnum("Stone")] [EnumMember(Value = "Stone")] Stone = 3,
        [XmlEnum("Gold")] [EnumMember(Value = "Gold")] Gold = 4,
        [XmlEnum("SkillPoints")] [EnumMember(Value = "SkillPoints")] SkillPoints = 5,
        [XmlEnum("XP")] [EnumMember(Value = "XP")] Xp = 6,
        [XmlEnum("Ships")] [EnumMember(Value = "Ships")] Ships = 7
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceSubTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("fish")] [EnumMember(Value = "fish")] Fish = 1,
        [XmlEnum("forage")] [EnumMember(Value = "forage")] Forage = 2,
        [XmlEnum("Food")] [EnumMember(Value = "Food")] Food = 3,
        [XmlEnum("Gold")] [EnumMember(Value = "Gold")] Gold = 4,
        [XmlEnum("grain")] [EnumMember(Value = "grain")] Grain = 5,
        [XmlEnum("meat")] [EnumMember(Value = "meat")] Meat = 6,
        [XmlEnum("Stone")] [EnumMember(Value = "Stone")] Stone = 7,
        [XmlEnum("Wood")] [EnumMember(Value = "Wood")] Wood = 8
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceTypeFixEnum
    {
        [XmlEnum("invalid")] [EnumMember(Value = "invalid")] Invalid = ResourceTypeEnum.Invalid,
        [XmlEnum("Wood")] [EnumMember(Value = "Wood")] Wood = ResourceTypeEnum.Wood,
        [XmlEnum("Food")] [EnumMember(Value = "Food")] Food = ResourceTypeEnum.Food,
        [XmlEnum("stone")] [EnumMember(Value = "stone")] Stone = ResourceTypeEnum.Stone,
        [XmlEnum("Gold")] [EnumMember(Value = "Gold")] Gold = ResourceTypeEnum.Gold,
        [XmlEnum("SkillPoints")] [EnumMember(Value = "SkillPoints")] SkillPoints = ResourceTypeEnum.SkillPoints,
        [XmlEnum("XP")] [EnumMember(Value = "XP")] Xp = ResourceTypeEnum.Xp,
        [XmlEnum("Ships")] [EnumMember(Value = "Ships")] Ships = ResourceTypeEnum.Ships
    }
}