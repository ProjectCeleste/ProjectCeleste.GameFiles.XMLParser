#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EconConsumableTypeEnum
    {
        [XmlEnum("Client")] [EnumMember(Value = "Client")] Client = 0,
        [XmlEnum("Server")] [EnumMember(Value = "Server")] Server = 1
    }
}