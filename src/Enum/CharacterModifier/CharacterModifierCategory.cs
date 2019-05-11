#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum.CharacterModifier
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CharacterModifierCategoryEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Consumable")] [EnumMember(Value = "Consumable")] Consumable = 1,
        [XmlEnum("Event")] [EnumMember(Value = "Event")] Event = 2
    }
}