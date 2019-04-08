#region Using directives

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CraftSchoolEnum
    {
        All = -1,
        None = 0,
        Construction = 1,
        Craftsmen = 2,
        Engineering = 3,
        HorseBreeding = 4,
        Metalworking = 5,
        MilitaryCollege = 6,
        Religion = 7,
        Woodscraft = 8
    }
}