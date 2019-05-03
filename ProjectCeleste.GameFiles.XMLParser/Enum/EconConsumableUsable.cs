#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EconConsumableUsableEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("CapitalCity")] [EnumMember(Value = "CapitalCity")] CapitalCity = 1,
        [XmlEnum("PVP")] [EnumMember(Value = "PVP")] Pvp = 2,
        [XmlEnum("Quest")] [EnumMember(Value = "Quest")] Quest = 3,
        [XmlEnum("SharedRegions")] [EnumMember(Value = "SharedRegions")] SharedRegions = 4
    }
}