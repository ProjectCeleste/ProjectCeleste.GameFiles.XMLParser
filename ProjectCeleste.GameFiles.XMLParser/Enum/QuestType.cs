#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestTypeEnum
    {
        [EnumMember(Value = "Invalid")] [XmlEnum("Invalid")] Invalid = 0,
        [EnumMember(Value = "Global")] [XmlEnum("Global")] Global = 1,
        [EnumMember(Value = "CapitolCity")] [XmlEnum("CapitolCity")] CapitolCity = 2,
        [EnumMember(Value = "RandomMap")] [XmlEnum("RandomMap")] RandomMap = 3,
        [EnumMember(Value = "PvP")] [XmlEnum("PvP")] PvP = 4
    }
}