#region Using directives

#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

// ReSharper disable InconsistentNaming

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CapitalResourceTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("cCapResCoin")] [EnumMember(Value = "cCapResCoin")] cCapResCoin = 1,
        [XmlEnum("cCapResWorkers")] [EnumMember(Value = "cCapResWorkers")] cCapResWorkers = 2,
        [XmlEnum("cCapResFactionPoints1")] [EnumMember(Value = "cCapResFactionPoints1")] cCapResFactionPoints1 = 3,
        [XmlEnum("cCapResFactionPoints2")] [EnumMember(Value = "cCapResFactionPoints2")] cCapResFactionPoints2 = 4,
        [XmlEnum("cCapResFactionPoints3")] [EnumMember(Value = "cCapResFactionPoints3")] cCapResFactionPoints3 = 5,
        [XmlEnum("cCapResFactionPoints4")] [EnumMember(Value = "cCapResFactionPoints4")] cCapResFactionPoints4 = 6,
        [XmlEnum("cCapResFactionPoints5")] [EnumMember(Value = "cCapResFactionPoints5")] cCapResFactionPoints5 = 7,
        [XmlEnum("cCapResFactionPoints6")] [EnumMember(Value = "cCapResFactionPoints6")] cCapResFactionPoints6 = 8,
        [XmlEnum("cCapResFactionPoints7")] [EnumMember(Value = "cCapResFactionPoints7")] cCapResFactionPoints7 = 9
    }
}