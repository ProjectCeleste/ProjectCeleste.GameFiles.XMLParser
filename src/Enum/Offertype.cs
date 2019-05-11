#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EOfferTypeEnum
    {
        [XmlEnum("eOfferCelesteDev")] [EnumMember(Value = "eOfferCelesteDev")] EOfferCelesteDev = 48,
        [XmlEnum("eOfferCeleste1")] [EnumMember(Value = "eOfferCeleste1")] EOfferCeleste1 = 47,
        [XmlEnum("eOfferEnd")] [EnumMember(Value = "eOfferEnd")] EOfferEnd = 46,
        [XmlEnum("eOfferSteamSpecial6")] [EnumMember(Value = "eOfferSteamSpecial6")] EOfferSteamSpecial6 = 45,
        [XmlEnum("eOfferSteamSpecial5")] [EnumMember(Value = "eOfferSteamSpecial5")] EOfferSteamSpecial5 = 44,
        [XmlEnum("eOfferSteamSpecial4")] [EnumMember(Value = "eOfferSteamSpecial4")] EOfferSteamSpecial4 = 43,
        [XmlEnum("eOfferSteamSpecial3")] [EnumMember(Value = "eOfferSteamSpecial3")] EOfferSteamSpecial3 = 42,
        [XmlEnum("eOfferSteamSpecial2")] [EnumMember(Value = "eOfferSteamSpecial2")] EOfferSteamSpecial2 = 41,
        [XmlEnum("eOfferSteamSpecial1")] [EnumMember(Value = "eOfferSteamSpecial1")] EOfferSteamSpecial1 = 40,
        [XmlEnum("eOfferEmpireInventory")] [EnumMember(Value = "eOfferEmpireInventory")] EOfferEmpireInventory = 39,
        [XmlEnum("eOfferBundle6")] [EnumMember(Value = "eOfferBundle6")] EOfferBundle6 = 38,
        [XmlEnum("eOfferBundle5")] [EnumMember(Value = "eOfferBundle5")] EOfferBundle5 = 37,
        [XmlEnum("eOfferBundle4")] [EnumMember(Value = "eOfferBundle4")] EOfferBundle4 = 36,
        [XmlEnum("eOfferBundle3")] [EnumMember(Value = "eOfferBundle3")] EOfferBundle3 = 35,
        [XmlEnum("eOfferBundle2")] [EnumMember(Value = "eOfferBundle2")] EOfferBundle2 = 34,
        [XmlEnum("eOfferBundle1")] [EnumMember(Value = "eOfferBundle1")] EOfferBundle1 = 33,
        [XmlEnum("eOfferRetailStore2")] [EnumMember(Value = "eOfferRetailStore2")] EOfferRetailStore2 = 32,
        [XmlEnum("eOfferRetailStore1")] [EnumMember(Value = "eOfferRetailStore1")] EOfferRetailStore1 = 31,
        [XmlEnum("eOfferVanity12")] [EnumMember(Value = "eOfferVanity12")] EOfferVanity12 = 30,
        [XmlEnum("eOfferVanity11")] [EnumMember(Value = "eOfferVanity11")] EOfferVanity11 = 29,
        [XmlEnum("eOfferVanity10")] [EnumMember(Value = "eOfferVanity10")] EOfferVanity10 = 28,
        [XmlEnum("eOfferVanity9")] [EnumMember(Value = "eOfferVanity9")] EOfferVanity9 = 27,
        [XmlEnum("eOfferVanity8")] [EnumMember(Value = "eOfferVanity8")] EOfferVanity8 = 26,
        [XmlEnum("eOfferVanity7")] [EnumMember(Value = "eOfferVanity7")] EOfferVanity7 = 25,
        [XmlEnum("eOfferVanity6")] [EnumMember(Value = "eOfferVanity6")] EOfferVanity6 = 24,
        [XmlEnum("eOfferVanity5")] [EnumMember(Value = "eOfferVanity5")] EOfferVanity5 = 23,
        [XmlEnum("eOfferGreekVanity2")] [EnumMember(Value = "eOfferGreekVanity2")] EOfferGreekVanity2 = 22,
        [XmlEnum("eOfferGreekVanity1")] [EnumMember(Value = "eOfferGreekVanity1")] EOfferGreekVanity1 = 21,
        [XmlEnum("eOfferEgyptianVanity2")] [EnumMember(Value = "eOfferEgyptianVanity2")] EOfferEgyptianVanity2 = 20,
        [XmlEnum("eOfferEgyptianVanity1")] [EnumMember(Value = "eOfferEgyptianVanity1")] EOfferEgyptianVanity1 = 19,
        [XmlEnum("eOfferBooster9")] [EnumMember(Value = "eOfferBooster9")] EOfferBooster9 = 18,
        [XmlEnum("eOfferBooster8")] [EnumMember(Value = "eOfferBooster8")] EOfferBooster8 = 17,
        [XmlEnum("eOfferBooster7")] [EnumMember(Value = "eOfferBooster7")] EOfferBooster7 = 16,
        [XmlEnum("eOfferBooster6")] [EnumMember(Value = "eOfferBooster6")] EOfferBooster6 = 15,
        [XmlEnum("eOfferBooster5")] [EnumMember(Value = "eOfferBooster5")] EOfferBooster5 = 14,
        [XmlEnum("eOfferBooster4")] [EnumMember(Value = "eOfferBooster4")] EOfferBooster4 = 13,
        [XmlEnum("eOfferBooster3")] [EnumMember(Value = "eOfferBooster3")] EOfferBooster3 = 12,
        [XmlEnum("eOfferBooster2")] [EnumMember(Value = "eOfferBooster2")] EOfferBooster2 = 11,
        [XmlEnum("eOfferBooster1")] [EnumMember(Value = "eOfferBooster1")] EOfferBooster1 = 10,
        [XmlEnum("eOfferCivMoreThan1")] [EnumMember(Value = "eOfferCivMoreThan1")] EOfferCivMoreThan1 = 9,
        [XmlEnum("eOfferCivMatching")] [EnumMember(Value = "eOfferCivMatching")] EOfferCivMatching = 8,
        [XmlEnum("eOfferCivNorse")] [EnumMember(Value = "eOfferCivNorse")] EOfferCivNorse = 7,
        [XmlEnum("eOfferCivBabylonian")] [EnumMember(Value = "eOfferCivBabylonian")] EOfferCivBabylonian = 6,
        [XmlEnum("eOfferCivRoman")] [EnumMember(Value = "eOfferCivRoman")] EOfferCivRoman = 5,
        [XmlEnum("eOfferCivPersian")] [EnumMember(Value = "eOfferCivPersian")] EOfferCivPersian = 4,
        [XmlEnum("eOfferCivCeltic")] [EnumMember(Value = "eOfferCivCeltic")] EOfferCivCeltic = 3,
        [XmlEnum("eOfferCivEgyptian")] [EnumMember(Value = "eOfferCivEgyptian")] EOfferCivEgyptian = 2,
        [XmlEnum("eOfferCivGreek")] [EnumMember(Value = "eOfferCivGreek")] EOfferCivGreek = 1,
        [XmlEnum("eOfferNone")] [EnumMember(Value = "eOfferNone")] EOfferNone = 0
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum COfferTypeEnum
    {
        [XmlEnum("cOfferCivNorse")] [EnumMember(Value = "cOfferCivNorse")] COfferCivNorse =
            EOfferTypeEnum.EOfferCivNorse,

        [XmlEnum("cOfferCivBabylonian")] [EnumMember(Value = "cOfferCivBabylonian")] COfferCivBabylonian =
            EOfferTypeEnum.EOfferCivBabylonian,

        [XmlEnum("cOfferCivRoman")] [EnumMember(Value = "cOfferCivRoman")] COfferCivRoman =
            EOfferTypeEnum.EOfferCivRoman,

        [XmlEnum("cOfferCivPersian")] [EnumMember(Value = "cOfferCivPersian")] COfferCivPersian =
            EOfferTypeEnum.EOfferCivPersian,

        [XmlEnum("cOfferCivCeltic")] [EnumMember(Value = "cOfferCivCeltic")] COfferCivCeltic =
            EOfferTypeEnum.EOfferCivCeltic,

        [XmlEnum("cOfferCivEgyptian")] [EnumMember(Value = "cOfferCivEgyptian")] COfferCivEgyptian =
            EOfferTypeEnum.EOfferCivEgyptian,

        [XmlEnum("cOfferCivGreek")] [EnumMember(Value = "cOfferCivGreek")] COfferCivGreek =
            EOfferTypeEnum.EOfferCivGreek,
        [XmlEnum("cOfferNone")] [EnumMember(Value = "cOfferNone")] COfferNone = EOfferTypeEnum.EOfferNone
    }
}