#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Autumn")] [EnumMember(Value = "Autumn")] Autumn = 1,
        [XmlEnum("Halloween")] [EnumMember(Value = "Halloween")] Halloween = 2,
        [XmlEnum("Winter")] [EnumMember(Value = "Winter")] Winter = 3,
        [XmlEnum("Spring")] [EnumMember(Value = "Spring")] Spring = 4,
        [XmlEnum("Summer")] [EnumMember(Value = "Summer")] Summer = 5
    }
}