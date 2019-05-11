#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum.CharacterModifier
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CharacterModifierStackingBehaviorEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("DurationAdd")] [EnumMember(Value = "DurationAdd")] DurationAdd = 1
    }
}