#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VisualFactorEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Body")] [EnumMember(Value = "Body")] Body = 1,
        [XmlEnum("Shield")] [EnumMember(Value = "Shield")] Shield = 2,
        [XmlEnum("Weapon")] [EnumMember(Value = "Weapon")] Weapon = 3,
        [XmlEnum("Helmet")] [EnumMember(Value = "Helmet")] Helmet = 4,
        [XmlEnum("Banner")] [EnumMember(Value = "Banner")] Banner = 5,
        [XmlEnum("VanityShield")] [EnumMember(Value = "VanityShield")] VanityShield = 11,
        [XmlEnum("VanityWeapon")] [EnumMember(Value = "VanityWeapon")] VanityWeapon = 12,
        [XmlEnum("VanityHelmet")] [EnumMember(Value = "VanityHelmet")] VanityHelmet = 13
    }
}