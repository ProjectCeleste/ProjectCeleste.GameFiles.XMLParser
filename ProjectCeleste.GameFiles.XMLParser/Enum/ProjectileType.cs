#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectileTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Proj_Arrow")] [EnumMember(Value = "Proj_Arrow")] ProjArrow = 1,
        [XmlEnum("Proj_ArrowFire")] [EnumMember(Value = "Proj_ArrowFire")] ProjArrowFire = 2,
        [XmlEnum("Proj_Bolt")] [EnumMember(Value = "Proj_Bolt")] ProjBolt = 3,
        [XmlEnum("Proj_BoltCluster")] [EnumMember(Value = "Proj_BoltCluster")] ProjBoltCluster = 4,
        [XmlEnum("Proj_BoltClusterFire")] [EnumMember(Value = "Proj_BoltClusterFire")] ProjBoltClusterFire = 5,
        [XmlEnum("Proj_CatRock")] [EnumMember(Value = "Proj_CatRock")] ProjCatRock = 6,
        [XmlEnum("Proj_Firepot")] [EnumMember(Value = "Proj_Firepot")] ProjFirepot = 7,
        [XmlEnum("Proj_Hammer")] [EnumMember(Value = "Proj_Hammer")] ProjHammer = 8,
        [XmlEnum("Proj_HelepolisArrow")] [EnumMember(Value = "Proj_HelepolisArrow")] ProjHelepolisArrow = 9,
        [XmlEnum("Proj_Log")] [EnumMember(Value = "Proj_Log")] ProjLog = 10,
        [XmlEnum("Proj_SlingRock")] [EnumMember(Value = "Proj_SlingRock")] ProjSlingRock = 11,
        [XmlEnum("Proj_SpearPeltast")] [EnumMember(Value = "Proj_SpearPeltast")] ProjSpearPeltast = 12,
        [XmlEnum("Proj_Axe")] [EnumMember(Value = "Proj_Axe")] ProjAxe = 13,
        [XmlEnum("Proj_BoltSmallFire")] [EnumMember(Value = "Proj_BoltSmallFire")] ProjBoltSmallFire = 14,
        [XmlEnum("Proj_CatRock_Giant")] [EnumMember(Value = "Proj_CatRock_Giant")] ProjCatRockGiant = 15,

        [XmlEnum("Proj_SpearCelticWarChariot")] [EnumMember(Value = "Proj_SpearCelticWarChariot")]
        ProjSpearCelticWarChariot = 16,
        [XmlEnum("Proj_SpearChef")] [EnumMember(Value = "Proj_SpearChef")] ProjSpearChef = 17,
        [XmlEnum("Proj_SpearGaesatae")] [EnumMember(Value = "Proj_SpearGaesatae")] ProjSpearGaesatae = 18,
        [XmlEnum("Proj_SpearVillager")] [EnumMember(Value = "Proj_SpearVillager")] ProjSpearVillager = 19,
        [XmlEnum("Proj_TridentArchimedes")] [EnumMember(Value = "Proj_TridentArchimedes")] ProjTridentArchimedes = 20
    }
}