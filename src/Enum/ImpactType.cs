#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImpactTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Animal")] [EnumMember(Value = "Animal")] Animal = 1,
        [XmlEnum("Flesh")] [EnumMember(Value = "Flesh")] Flesh = 2,
        [XmlEnum("Stone")] [EnumMember(Value = "Stone")] Stone = 3,
        [XmlEnum("Wood")] [EnumMember(Value = "Wood")] Wood = 4
    }
}