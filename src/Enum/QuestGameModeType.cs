#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestGameModeTypeEnum
    {
        [EnumMember(Value = "Normal")] [XmlEnum("Normal")] Normal = 0,
        [EnumMember(Value = "AllianceMode")] [XmlEnum("AllianceMode")] AllianceMode = 1,
        [EnumMember(Value = "SkirmishMode")] [XmlEnum("SkirmishMode")] SkirmishMode = 2,
        [EnumMember(Value = "InvasionMode")] [XmlEnum("InvasionMode")] InvasionMode = 3
    }
}