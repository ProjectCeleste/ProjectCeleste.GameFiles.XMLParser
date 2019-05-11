#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayerType
    {
        [EnumMember(Value = "Unknow")] [XmlEnum("Unknow")] Unknow = 0,
        [EnumMember(Value = "Human")] [XmlEnum("Human")] Human = 1,
        [EnumMember(Value = "Computer")] [XmlEnum("Computer")] Computer = 2
    }
}