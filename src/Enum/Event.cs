#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Halloween")] [EnumMember(Value = "Halloween")] Halloween = 1,
        [XmlEnum("Winter")] [EnumMember(Value = "Winter")] Winter = 2
    }
}