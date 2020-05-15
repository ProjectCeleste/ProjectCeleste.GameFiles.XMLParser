#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProtoActionNameEnum
    {
        [XmlEnum("Aura")] [EnumMember(Value = "Aura")] Aura = 0,
        [XmlEnum("AutoGather")] [EnumMember(Value = "AutoGather")] AutoGather = 1,
        [XmlEnum("Build")] [EnumMember(Value = "Build")] Build = 2,
        [XmlEnum("BuildingAttack")] [EnumMember(Value = "BuildingAttack")] BuildingAttack = 3,
        [XmlEnum("BurningAttack")] [EnumMember(Value = "BurningAttack")] BurningAttack = 4,
        [XmlEnum("Charge")] [EnumMember(Value = "Charge")] Charge = 5,
        [XmlEnum("ChopAttack")] [EnumMember(Value = "ChopAttack")] ChopAttack = 6,
        [XmlEnum("Convert")] [EnumMember(Value = "Convert")] Convert = 7,
        [XmlEnum("Empower")] [EnumMember(Value = "Empower")] Empower = 8,
        [XmlEnum("FishGather")] [EnumMember(Value = "FishGather")] FishGather = 9,
        [XmlEnum("Gather")] [EnumMember(Value = "Gather")] Gather = 10,
        [XmlEnum("Heal")] [EnumMember(Value = "Heal")] Heal = 11,
        [XmlEnum("Hunting")] [EnumMember(Value = "Hunting")] Hunting = 12,
        [XmlEnum("MeleeAttack")] [EnumMember(Value = "MeleeAttack")] MeleeAttack = 13,
        [XmlEnum("MeleeAttack2")] [EnumMember(Value = "MeleeAttack2")] MeleeAttack2 = 14,
        [XmlEnum("PoisonAttack")] [EnumMember(Value = "PoisonAttack")] PoisonAttack = 15,
        [XmlEnum("RangedAttack")] [EnumMember(Value = "RangedAttack")] RangedAttack = 16,
        [XmlEnum("Repair")] [EnumMember(Value = "Repair")] Repair = 17,
        [XmlEnum("Sacrifice")] [EnumMember(Value = "Sacrifice")] Sacrifice = 18,
        [XmlEnum("SelfHeal")] [EnumMember(Value = "SelfHeal")] SelfHeal = 19,
        [XmlEnum("Trade")] [EnumMember(Value = "Trade")] Trade = 20,
        [XmlEnum("AreaHeal")] [EnumMember(Value = "AreaHeal")] AreaHeal = 21
    }
}