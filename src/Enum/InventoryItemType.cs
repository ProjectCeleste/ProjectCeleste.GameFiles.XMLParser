#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InventoryItemTypeEnum
    {
        [XmlEnum("Invalid")] [EnumMember(Value = "Invalid")] Invalid = 0,
        [XmlEnum("Material")] [EnumMember(Value = "Material")] Material = 1,
        [XmlEnum("Blueprint")] [EnumMember(Value = "Blueprint")] Blueprint = 2,
        [XmlEnum("Trait")] [EnumMember(Value = "Trait")] Trait = 3,
        [XmlEnum("Design")] [EnumMember(Value = "Design")] Design = 4,
        [XmlEnum("Resource")] [EnumMember(Value = "Resource")] Resource = 5,
        [XmlEnum("Advisor")] [EnumMember(Value = "Advisor")] Advisor = 6,
        [XmlEnum("CapitalResource")] [EnumMember(Value = "CapitalResource")] CapitalResource = 7,
        [XmlEnum("GameCurrency")] [EnumMember(Value = "GameCurrency")] GameCurrency = 8,
        [XmlEnum("Consumable")] [EnumMember(Value = "Consumable")] Consumable = 9,
        [XmlEnum("LootRoll")] [EnumMember(Value = "LootRoll")] LootRoll = 10,
        [XmlEnum("Quest")] [EnumMember(Value = "Quest")] Quest = 11
    }
}