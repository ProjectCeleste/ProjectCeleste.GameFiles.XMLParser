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
        [XmlEnum("Transform")] [EnumMember(Value = "Transform")] Transform = 35
    }
}