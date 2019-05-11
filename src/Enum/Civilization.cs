#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CivilizationEnum
    {
        [XmlEnum("0")] [EnumMember(Value = "Any")] Any = 0,
        [XmlEnum("1")] [EnumMember(Value = "Greek")] Greek = 1,
        [XmlEnum("3")] [EnumMember(Value = "Egyptian")] Egyptian = 3,
        [XmlEnum("6")] [EnumMember(Value = "Celt")] Celt = 6,
        [XmlEnum("8")] [EnumMember(Value = "Persian")] Persian = 8,
        [XmlEnum("22")] [EnumMember(Value = "Babylonian")] Babylonian = 22,
        [XmlEnum("24")] [EnumMember(Value = "Norse")] Norse = 24,
        [XmlEnum("11")] [EnumMember(Value = "Roman")] Roman = 11
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ECivilizationEnum
    {
        [XmlEnum("eCivMatchingTypeAny")] [EnumMember(Value = "eCivMatchingTypeAny")] Any = CivilizationEnum.Any,
        [XmlEnum("eCivMatchingTypeGreek")] [EnumMember(Value = "eCivMatchingTypeGreek")] Greek = CivilizationEnum.Greek,

        [XmlEnum("eCivMatchingTypeEgyptian")] [EnumMember(Value = "eCivMatchingTypeEgyptian")] Egypt =
            CivilizationEnum.Egyptian,
        [XmlEnum("eCivMatchingTypeCeltic")] [EnumMember(Value = "eCivMatchingTypeCeltic")] Celt = CivilizationEnum.Celt,

        [XmlEnum("eCivMatchingTypePersian")] [EnumMember(Value = "eCivMatchingTypePersian")] Persia =
            CivilizationEnum.Persian,

        [XmlEnum("eCivMatchingTypeBabylonian")] [EnumMember(Value = "eCivMatchingTypeBabylonian")] Babylonian =
            CivilizationEnum.Babylonian,
        [XmlEnum("eCivMatchingTypeNorse")] [EnumMember(Value = "eCivMatchingTypeNorse")] Norse = CivilizationEnum.Norse,
        [XmlEnum("eCivMatchingTypeRoman")] [EnumMember(Value = "eCivMatchingTypeRoman")] Roman = CivilizationEnum.Roman
    }
}