#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuildingLimitTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Inventory")] [EnumMember(Value = "Inventory")] Inventory = 1,
        [XmlEnum("WorkShopBasic")] [EnumMember(Value = "WorkShopBasic")] WorkShopBasic = 2,
        [XmlEnum("WorkShopAdvanced")] [EnumMember(Value = "WorkShopAdvanced")] WorkShopAdvanced = 3
    }
}