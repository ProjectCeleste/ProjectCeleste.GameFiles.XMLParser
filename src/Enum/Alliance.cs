#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AllianceEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("LegionOfCarthage")] [EnumMember(Value = "LegionOfCarthage")] LegionOfCarthage = 1,
        [XmlEnum("DelianLeague")] [EnumMember(Value = "DelianLeague")] DelianLeague = 2,
        [XmlEnum("CouncilOfImhotep")] [EnumMember(Value = "CouncilOfImhotep")] CouncilOfImhotep = 3
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AllianceIntEnum
    {
        [XmlEnum(null)] [EnumMember(Value = null)] None = -1,
        [XmlEnum("0")] [EnumMember(Value = "0")] LegionOfCarthage = 0,
        [XmlEnum("1")] [EnumMember(Value = "1")] DelianLeague = 1,
        [XmlEnum("2")] [EnumMember(Value = "2")] CouncilOfImhotep = 2
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EAllianceEnum
    {
        [XmlEnum("eAllianceNone")] [EnumMember(Value = "eAllianceNone")] None = AllianceEnum.None,

        [XmlEnum("eAllianceLegionOfCarthage")] [EnumMember(Value = "eAllianceLegionOfCarthage")] LegionOfCarthage =
            AllianceEnum.LegionOfCarthage,

        [XmlEnum("eAllianceDelianLeague")] [EnumMember(Value = "eAllianceDelianLeague")] DelianLeague =
            AllianceEnum.DelianLeague,

        [XmlEnum("eAllianceCouncilOfImhotep")] [EnumMember(Value = "eAllianceCouncilOfImhotep")] CouncilOfImhotep =
            AllianceEnum.CouncilOfImhotep
    }
}