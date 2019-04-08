#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CivilizationEnum
    {
        [XmlEnum("0")] [EnumMember(Value = "0")] Any = 0,
        [XmlEnum("1")] [EnumMember(Value = "1")] Greek = 1,
        [XmlEnum("3")] [EnumMember(Value = "3")] Egypt = 3,
        [XmlEnum("6")] [EnumMember(Value = "6")] Celt = 6,
        [XmlEnum("8")] [EnumMember(Value = "8")] Persia = 8,
        [XmlEnum("22")] [EnumMember(Value = "22")] Babylonian = 22,
        [XmlEnum("24")] [EnumMember(Value = "24")] Norse = 24,
        [XmlEnum("11")] [EnumMember(Value = "11")] Roman = 11
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ECivilizationEnum
    {
        [XmlEnum("eCivMatchingTypeAny")] [EnumMember(Value = "eCivMatchingTypeAny")] Any = CivilizationEnum.Any,
        [XmlEnum("eCivMatchingTypeGreek")] [EnumMember(Value = "eCivMatchingTypeGreek")] Greek = CivilizationEnum.Greek,

        [XmlEnum("eCivMatchingTypeEgyptian")] [EnumMember(Value = "eCivMatchingTypeEgyptian")] Egypt =
            CivilizationEnum.Egypt,
        [XmlEnum("eCivMatchingTypeCeltic")] [EnumMember(Value = "eCivMatchingTypeCeltic")] Celt = CivilizationEnum.Celt,

        [XmlEnum("eCivMatchingTypePersian")] [EnumMember(Value = "eCivMatchingTypePersian")] Persia =
            CivilizationEnum.Persia,

        [XmlEnum("eCivMatchingTypeBabylonian")] [EnumMember(Value = "eCivMatchingTypeBabylonian")] Babylonian =
            CivilizationEnum.Babylonian,
        [XmlEnum("eCivMatchingTypeNorse")] [EnumMember(Value = "eCivMatchingTypeNorse")] Norse = CivilizationEnum.Norse,
        [XmlEnum("eCivMatchingTypeRoman")] [EnumMember(Value = "eCivMatchingTypeRoman")] Roman = CivilizationEnum.Roman
    }
}