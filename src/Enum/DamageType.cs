#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DamageTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Hand")] [EnumMember(Value = "Hand")] Hand = 1,
        [XmlEnum("Ranged")] [EnumMember(Value = "Ranged")] Ranged = 2,
        [XmlEnum("Cavalry")] [EnumMember(Value = "Cavalry")] Cavalry = 3,
        [XmlEnum("Siege")] [EnumMember(Value = "Siege")] Siege = 4
    }
}