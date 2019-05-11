#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DamageFlagTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("GaiaEnemy")] [EnumMember(Value = "GaiaEnemy")] GaiaEnemy = 1,
        [XmlEnum("Gaia Enemy")] [EnumMember(Value = "Gaia Enemy")] GaiaEnemy2 = 2
    }
}