#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnitCommandEnum
    {
        [XmlEnum("AutoGather")] [EnumMember(Value = "AutoGather")] AutoGather = 0,
        [XmlEnum("Delete")] [EnumMember(Value = "Delete")] Delete = 1,
        [XmlEnum("Eject")] [EnumMember(Value = "Eject")] Eject = 2,
        [XmlEnum("Garrison")] [EnumMember(Value = "Garrison")] Garrison = 3,
        [XmlEnum("MarketBuy1")] [EnumMember(Value = "MarketBuy1")] MarketBuy1 = 4,
        [XmlEnum("MarketBuy2")] [EnumMember(Value = "MarketBuy2")] MarketBuy2 = 5,
        [XmlEnum("MarketBuy3")] [EnumMember(Value = "MarketBuy3")] MarketBuy3 = 6,
        [XmlEnum("MarketSell1")] [EnumMember(Value = "MarketSell1")] MarketSell1 = 7,
        [XmlEnum("MarketSell2")] [EnumMember(Value = "MarketSell2")] MarketSell2 = 8,
        [XmlEnum("MarketSell3")] [EnumMember(Value = "MarketSell3")] MarketSell3 = 9,

        [XmlEnum("NorthernHero01_Action01")] [EnumMember(Value = "NorthernHero01_Action01")] NorthernHero01Action01 =
            10,

        [XmlEnum("NorthernHero01_Action02")] [EnumMember(Value = "NorthernHero01_Action02")] NorthernHero01Action02 =
            11,

        [XmlEnum("NorthernHero02_Action01")] [EnumMember(Value = "NorthernHero02_Action01")] NorthernHero02Action01 =
            12,

        [XmlEnum("NorthernHero02_Action02")] [EnumMember(Value = "NorthernHero02_Action02")] NorthernHero02Action02 =
            13,
        [XmlEnum("PVP_TogglePaidLabor")] [EnumMember(Value = "PVP_TogglePaidLabor")] PvpTogglePaidLabor = 14,
        [XmlEnum("Repair")] [EnumMember(Value = "Repair")] Repair = 15,
        [XmlEnum("RepairColonyWall")] [EnumMember(Value = "RepairColonyWall")] RepairColonyWall = 16,
        [XmlEnum("ReturnToWork")] [EnumMember(Value = "ReturnToWork")] ReturnToWork = 17,
        [XmlEnum("Sacrifice1")] [EnumMember(Value = "Sacrifice1")] Sacrifice1 = 18,
        [XmlEnum("Sacrifice2")] [EnumMember(Value = "Sacrifice2")] Sacrifice2 = 19,
        [XmlEnum("Sacrifice3")] [EnumMember(Value = "Sacrifice3")] Sacrifice3 = 20,
        [XmlEnum("Sacrifice4")] [EnumMember(Value = "Sacrifice4")] Sacrifice4 = 21,
        [XmlEnum("SetGatherPointEconomy")] [EnumMember(Value = "SetGatherPointEconomy")] SetGatherPointEconomy = 22,
        [XmlEnum("SetGatherPointMilitary")] [EnumMember(Value = "SetGatherPointMilitary")] SetGatherPointMilitary = 23,
        [XmlEnum("SpawnRaven")] [EnumMember(Value = "SpawnRaven")] SpawnRaven = 24,
        [XmlEnum("Stance1")] [EnumMember(Value = "Stance1")] Stance1 = 25,
        [XmlEnum("Stance3")] [EnumMember(Value = "Stance3")] Stance3 = 26,
        [XmlEnum("Stop")] [EnumMember(Value = "Stop")] Stop = 27,
        [XmlEnum("Tactic3")] [EnumMember(Value = "Tactic3")] Tactic3 = 28,
        [XmlEnum("Tactic4")] [EnumMember(Value = "Tactic4")] Tactic4 = 29,
        [XmlEnum("TogglePaidLabor")] [EnumMember(Value = "TogglePaidLabor")] TogglePaidLabor = 30,
        [XmlEnum("ToggleRigorousTraining")] [EnumMember(Value = "ToggleRigorousTraining")] ToggleRigorousTraining = 31,
        [XmlEnum("ToggleSuperTraining")] [EnumMember(Value = "ToggleSuperTraining")] ToggleSuperTraining = 32,
        [XmlEnum("ToggleTributeDialog")] [EnumMember(Value = "ToggleTributeDialog")] ToggleTributeDialog = 33,
        [XmlEnum("TownBell")] [EnumMember(Value = "TownBell")] TownBell = 34,
        [XmlEnum("Transform")] [EnumMember(Value = "Transform")] Transform = 35,
        [XmlEnum("Tactic5")] [EnumMember(Value = "Tactic5")] Tactic5 = 36,
        [XmlEnum("Tactic6")] [EnumMember(Value = "Tactic6")] Tactic5 = 37,
        [XmlEnum("Tactic7")] [EnumMember(Value = "Tactic7")] Tactic5 = 38,
        [XmlEnum("Tactic8")] [EnumMember(Value = "Tactic8")] Tactic5 = 39,
        [XmlEnum("Tactic9")] [EnumMember(Value = "Tactic9")] Tactic5 = 40,
        [XmlEnum("Tactic10")] [EnumMember(Value = "Tactic10")] Tactic5 = 41,
        [XmlEnum("Tactic11")] [EnumMember(Value = "Tactic11")] Tactic5 = 42,
        [XmlEnum("Tactic12")] [EnumMember(Value = "Tactic12")] Tactic5 = 43,
        [XmlEnum("Tactic13")] [EnumMember(Value = "Tactic13")] Tactic5 = 44,
        [XmlEnum("Tactic14")] [EnumMember(Value = "Tactic14")] Tactic5 = 45,
        [XmlEnum("Tactic15")] [EnumMember(Value = "Tactic15")] Tactic5 = 46,
        [XmlEnum("Tactic16")] [EnumMember(Value = "Tactic16")] Tactic5 = 47,
        [XmlEnum("Tactic17")] [EnumMember(Value = "Tactic17")] Tactic5 = 48,
        [XmlEnum("Tactic18")] [EnumMember(Value = "Tactic18")] Tactic5 = 49,
        [XmlEnum("Tactic19")] [EnumMember(Value = "Tactic19")] Tactic5 = 50,
        [XmlEnum("Tactic20")] [EnumMember(Value = "Tactic20")] Tactic5 = 51,
        [XmlEnum("Tactic21")] [EnumMember(Value = "Tactic21")] Tactic5 = 52,
        [XmlEnum("Tactic22")] [EnumMember(Value = "Tactic22")] Tactic5 = 53,
        [XmlEnum("Tactic23")] [EnumMember(Value = "Tactic23")] Tactic5 = 54,
        [XmlEnum("Tactic24")] [EnumMember(Value = "Tactic24")] Tactic5 = 55,
        [XmlEnum("Tactic25")] [EnumMember(Value = "Tactic25")] Tactic5 = 56,
        [XmlEnum("Tactic26")] [EnumMember(Value = "Tactic26")] Tactic5 = 57,
        [XmlEnum("Tactic27")] [EnumMember(Value = "Tactic27")] Tactic5 = 58,
        [XmlEnum("Tactic28")] [EnumMember(Value = "Tactic28")] Tactic5 = 59,
        [XmlEnum("Tactic29")] [EnumMember(Value = "Tactic29")] Tactic5 = 60,
        [XmlEnum("Tactic30")] [EnumMember(Value = "Tactic30")] Tactic5 = 61,
        [XmlEnum("Tactic31")] [EnumMember(Value = "Tactic31")] Tactic5 = 62,
        [XmlEnum("Tactic32")] [EnumMember(Value = "Tactic32")] Tactic5 = 63
    }
}