#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RelativityEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Percent")] [EnumMember(Value = "Percent")] Percent = 1,
        [XmlEnum("Assign")] [EnumMember(Value = "Assign")] Assign = 2,
        [XmlEnum("Absolute")] [EnumMember(Value = "Absolute")] Absolute = 3
    }
}