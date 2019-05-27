#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TechStatusEnumUpper
    {
        [XmlEnum("INVALID")] [EnumMember(Value = "INVALID")] Invalid = TechStatusEnum.Invalid,
        [XmlEnum("UNOBTAINABLE")] [EnumMember(Value = "UNOBTAINABLE")] Unobtainable = TechStatusEnum.Unobtainable,
        [XmlEnum("OBTAINABLE")] [EnumMember(Value = "OBTAINABLE")] Obtainable = TechStatusEnum.Obtainable,
        [XmlEnum("ACTIVE")] [EnumMember(Value = "ACTIVE")] Active = TechStatusEnum.Active
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TechStatusEnum
    {
        [XmlEnum("Invalid")] [EnumMember(Value = "Invalid")] Invalid = 0,
        [XmlEnum("Unobtainable")] [EnumMember(Value = "Unobtainable")] Unobtainable = 1,
        [XmlEnum("Obtainable")] [EnumMember(Value = "Obtainable")] Obtainable = 2,
        [XmlEnum("Active")] [EnumMember(Value = "Active")] Active = 3
    }
}