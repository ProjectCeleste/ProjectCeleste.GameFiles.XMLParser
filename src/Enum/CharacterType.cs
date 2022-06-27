#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CharacterTypeEnum : byte
    {
        [XmlEnum("cCharTypeInvalid")] [EnumMember(Value = "cCharTypeInvalid")] Invalid = 0,
        [XmlEnum("cCharTypeNormal")] [EnumMember(Value = "cCharTypeNormal")] Normal = 1,
        [XmlEnum("cCharTypeSkipTutorial")] [EnumMember(Value = "cCharTypeSkipTutorial")] SkipTutorial = 2,
        [XmlEnum("cCharTypePro")] [EnumMember(Value = "cCharTypePro")] Pro = 3,
        [XmlEnum("cCharTypeFullLvl40 ")][EnumMember(Value = "cCharTypeFullLvl40 ")] FullLvl40 = 4,
    }
}