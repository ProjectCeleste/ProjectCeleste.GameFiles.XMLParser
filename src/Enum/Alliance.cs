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
    public enum EAllianceEnum
    {
        [XmlEnum("eAllianceNone")] [EnumMember(Value = "eAllianceNone")] None = AllianceEnum.None - 1,

        [XmlEnum("eAllianceLegionOfCarthage")] [EnumMember(Value = "eAllianceLegionOfCarthage")] LegionOfCarthage =
            AllianceEnum.LegionOfCarthage - 1,

        [XmlEnum("eAllianceDelianLeague")] [EnumMember(Value = "eAllianceDelianLeague")] DelianLeague =
            AllianceEnum.DelianLeague - 1,

        [XmlEnum("eAllianceCouncilOfImhotep")] [EnumMember(Value = "eAllianceCouncilOfImhotep")] CouncilOfImhotep =
            AllianceEnum.CouncilOfImhotep - 1
    }
}