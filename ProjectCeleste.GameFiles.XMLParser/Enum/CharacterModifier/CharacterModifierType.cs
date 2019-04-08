#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum.CharacterModifier
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CharacterModifierTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("eAP")] [EnumMember(Value = "eAP")] EAp = 1,
        [XmlEnum("eCoin")] [EnumMember(Value = "eCoin")] ECoin = 2,
        [XmlEnum("eXP")] [EnumMember(Value = "eXP")] EXp = 3,
        [XmlEnum("eLootTableRarity")] [EnumMember(Value = "eLootTableRarity")] ELootTableRarity = 4,
        [XmlEnum("eLootTableCategory")] [EnumMember(Value = "eLootTableCategory")] ELootTableCategory = 5,

        [XmlEnum("eCraftedItemEffectiveness")] [EnumMember(Value = "eCraftedItemEffectiveness")]
        ECraftedItemEffectiveness = 6,
        [XmlEnum("eMaterialCreationRate")] [EnumMember(Value = "eMaterialCreationRate")] EMaterialCreationRate = 7,

        [XmlEnum("eCraftingMaterialRequirement")] [EnumMember(Value = "eCraftingMaterialRequirement")]
        ECraftingMaterialRequirement = 8,
        [XmlEnum("eVendorSellCost")] [EnumMember(Value = "eVendorSellCost")] EVendorSellCost = 9,
        [XmlEnum("eVendorBuyCost")] [EnumMember(Value = "eVendorBuyCost")] EVendorBuyCost = 10
    }
}