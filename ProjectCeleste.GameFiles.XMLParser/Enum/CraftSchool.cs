#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CraftSchoolEnum
    {
        [XmlEnum("All")] [EnumMember(Value = "All")] All = -1,
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Construction")] [EnumMember(Value = "Construction")] Construction = 1,
        [XmlEnum("Craftsmen")] [EnumMember(Value = "Craftsmen")] Craftsmen = 2,
        [XmlEnum("Engineering")] [EnumMember(Value = "Engineering")] Engineering = 3,
        [XmlEnum("HorseBreeding")] [EnumMember(Value = "HorseBreeding")] HorseBreeding = 4,
        [XmlEnum("Metalworking")] [EnumMember(Value = "Metalworking")] Metalworking = 5,
        [XmlEnum("MilitaryCollege")] [EnumMember(Value = "MilitaryCollege")] MilitaryCollege = 6,
        [XmlEnum("Religion")] [EnumMember(Value = "Religion")] Religion = 7,
        [XmlEnum("Woodscraft")] [EnumMember(Value = "Woodscraft")] Woodscraft = 8
    }
}