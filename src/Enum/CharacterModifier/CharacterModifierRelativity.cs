#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum.CharacterModifier
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CharacterModifierRelativityEnum
    {
        [XmlEnum("eNone")] [EnumMember(Value = "eNone")] ENone = 0,
        [XmlEnum("ePercentage")] [EnumMember(Value = "ePercentage")] EPercentage = 1,
        [XmlEnum("eAssignHighest")] [EnumMember(Value = "eAssignHighest")] EAssignHighest = 2
    }
}