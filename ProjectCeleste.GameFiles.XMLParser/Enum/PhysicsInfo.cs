#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PhysicsInfoEnum
    {
        [XmlEnum("none")] [EnumMember(Value = "none")] None = 0,
        [XmlEnum("dude")] [EnumMember(Value = "dude")] Dude = 1,
        [XmlEnum("house")] [EnumMember(Value = "house")] House = 2,
        [XmlEnum("mill")] [EnumMember(Value = "mill")] Mill = 3
    }
}