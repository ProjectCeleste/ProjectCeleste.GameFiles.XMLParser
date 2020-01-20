#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TraitTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,

        [XmlEnum("ArmorBuilding")] [EnumMember(Value = "ArmorBuilding")] ArmorBuilding = 63,
        [XmlEnum("ArmorCloth")] [EnumMember(Value = "ArmorCloth")] ArmorCloth = 64,
        [XmlEnum("ArmorLgt")] [EnumMember(Value = "ArmorLgt")] ArmorLgt = 65,
        [XmlEnum("ArmorMed")] [EnumMember(Value = "ArmorMed")] ArmorMed = 66,
        [XmlEnum("ArmorPlt")] [EnumMember(Value = "ArmorPlt")] ArmorPlt = 67,
        [XmlEnum("Arrows")] [EnumMember(Value = "Arrows")] Arrows = 68,
        [XmlEnum("BallistaArms")] [EnumMember(Value = "BallistaArms")] BallistaArms = 69,
        [XmlEnum("BellyBows")] [EnumMember(Value = "BellyBows")] BellyBows = 70,
        [XmlEnum("Bows")] [EnumMember(Value = "Bows")] Bows = 71,
        [XmlEnum("FireThrowers")] [EnumMember(Value = "FireThrowers")] FireThrowers = 72,
        [XmlEnum("FishingNet")] [EnumMember(Value = "FishingNet")] FishingNet = 73,
        [XmlEnum("Gear")] [EnumMember(Value = "Gear")] Gear = 74,
        [XmlEnum("GearBldg")] [EnumMember(Value = "GearBldg")] GearBldg = 75,
        [XmlEnum("GearBoat")] [EnumMember(Value = "GearBoat")] GearBoat = 76,
        [XmlEnum("GearVill")] [EnumMember(Value = "GearVill")] GearVill = 77,
        [XmlEnum("GearPriest")] [EnumMember(Value = "GearPriest")] GearPriest = 78,
        [XmlEnum("GearSiege")] [EnumMember(Value = "GearSiege")] GearSiege = 79,
        [XmlEnum("Javalins")] [EnumMember(Value = "Javalins")] Javalins = 80,
        [XmlEnum("Merchant")] [EnumMember(Value = "Merchant")] Merchant = 81,
        [XmlEnum("RamHeads")] [EnumMember(Value = "RamHeads")] RamHeads = 82,
        [XmlEnum("Spears1H")] [EnumMember(Value = "Spears1H")] Spears1H = 83,
        [XmlEnum("Spears2H")] [EnumMember(Value = "Spears2H")] Spears2H = 84,
        [XmlEnum("Staffs2H")] [EnumMember(Value = "Staffs2H")] Staffs2H = 85,
        [XmlEnum("Shields")] [EnumMember(Value = "Shields")] Shields = 86,
        [XmlEnum("Swords1H")] [EnumMember(Value = "Swords1H")] Swords1H = 87,
        [XmlEnum("Tools")] [EnumMember(Value = "Tools")] Tools = 88,
        [XmlEnum("Clubs2H")] [EnumMember(Value = "Clubs2H")] Clubs2H = 89,
        [XmlEnum("ScoutSpecial1H")] [EnumMember(Value = "ScoutSpecial1H")] ScoutSpecial1H = 90,
        [XmlEnum("GreatAxe")] [EnumMember(Value = "GreatAxe")] GreatAxe = 91,
        [XmlEnum("Scepter")] [EnumMember(Value = "Scepter")] Scepter = 92,
        [XmlEnum("Sling")] [EnumMember(Value = "Sling")] Sling = 93,

        [XmlEnum("Torc")] [EnumMember(Value = "Torc")] Torc = 133,
        [XmlEnum("War Horn")] [EnumMember(Value = "War Horn")] WarHorn = 134,

        [XmlEnum("Warpaint")] [EnumMember(Value = "Warpaint")] Warpaint = 138,

        [XmlEnum("VanityWeapon")] [EnumMember(Value = "VanityWeapon")] VanityWeapon = 200,
        [XmlEnum("VanityHelm")] [EnumMember(Value = "VanityHelm")] VanityHelm = 201,
        [XmlEnum("VanityShield")] [EnumMember(Value = "VanityShield")] VanityShield = 202,

        [XmlEnum("Banner")] [EnumMember(Value = "Banner")] Banner = 777,
		
        [XmlEnum("Test")] [EnumMember(Value = "Test")] Test = 999
    }
}