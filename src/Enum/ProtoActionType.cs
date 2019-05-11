#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProtoActionTypeEnum
    {
        [XmlEnum("AutoGather")] [EnumMember(Value = "AutoGather")] AutoGather = 0,
        [XmlEnum("Build")] [EnumMember(Value = "Build")] Build = 1,
        [XmlEnum("Repair")] [EnumMember(Value = "Repair")] Repair = 2
    }
}