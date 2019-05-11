#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BluePrintTagEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] Invalid = 0,
        [XmlEnum("Blueprint")] [EnumMember(Value = "Blueprint")] Blueprint = 1
    }
}