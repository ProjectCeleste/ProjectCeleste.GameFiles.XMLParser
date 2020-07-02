#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EffectTypeEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("Data")] [EnumMember(Value = "Data")] Data = 1
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EffectUnitTypeEnum
    {
        [XmlEnum("Invalid")] [EnumMember(Value = "Invalid")] Invalid = 0,
        [XmlEnum("AbstractArcher")] [EnumMember(Value = "AbstractArcher")] AbstractArcher = 1,
        [XmlEnum("AbstractCavalry")] [EnumMember(Value = "AbstractCavalry")] AbstractCavalry = 2,
        [XmlEnum("AbstractDock")] [EnumMember(Value = "AbstractDock")] AbstractDock = 3,
        [XmlEnum("AbstractFarm")] [EnumMember(Value = "AbstractFarm")] AbstractFarm = 4,
        [XmlEnum("AbstractFish")] [EnumMember(Value = "AbstractFish")] AbstractFish = 5,
        [XmlEnum("AbstractFruit")] [EnumMember(Value = "AbstractFruit")] AbstractFruit = 6,
        [XmlEnum("AbstractInfantry")] [EnumMember(Value = "AbstractInfantry")] AbstractInfantry = 7,
        [XmlEnum("AbstractTownCenter")] [EnumMember(Value = "AbstractTownCenter")] AbstractTownCenter = 8,
        [XmlEnum("ActionBuild")] [EnumMember(Value = "ActionBuild")] ActionBuild = 9,
        [XmlEnum("ActionTrain")] [EnumMember(Value = "ActionTrain")] ActionTrain = 10,
        [XmlEnum("Building")] [EnumMember(Value = "Building")] Building = 11,
        [XmlEnum("ConvertableCavalry")] [EnumMember(Value = "ConvertableCavalry")] ConvertableCavalry = 12,
        [XmlEnum("ConvertableInfantry")] [EnumMember(Value = "ConvertableInfantry")] ConvertableInfantry = 13,
        [XmlEnum("ConvertableSiege")] [EnumMember(Value = "ConvertableSiege")] ConvertableSiege = 14,
        [XmlEnum("Dropsite")] [EnumMember(Value = "Dropsite")] Dropsite = 15,
        [XmlEnum("Fish")] [EnumMember(Value = "Fish")] Fish = 16,
        [XmlEnum("Gold")] [EnumMember(Value = "Gold")] Gold = 17,
        [XmlEnum("Herdable")] [EnumMember(Value = "Herdable")] Herdable = 18,
        [XmlEnum("Huntable")] [EnumMember(Value = "Huntable")] Huntable = 19,
        [XmlEnum("LogicalTypeHealed")] [EnumMember(Value = "LogicalTypeHealed")] LogicalTypeHealed = 20,
        [XmlEnum("Ship")] [EnumMember(Value = "Ship")] Ship = 21,
        [XmlEnum("Stone")] [EnumMember(Value = "Stone")] Stone = 22,
        [XmlEnum("Tree")] [EnumMember(Value = "Tree")] Tree = 23,
        [XmlEnum("UnitTypeBldgWatchPost")] [EnumMember(Value = "UnitTypeBldgWatchPost")] UnitTypeBldgWatchPost = 24
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EffectSubTypeEnum
    {
        //[XmlEnum("Invalid")] [EnumMember(Value = "Invalid")] Invalid = 0,
        [XmlEnum("ActionEnable")] [EnumMember(Value = "ActionEnable")] ActionEnable = 1,
        [XmlEnum("AreaDamageReduction")] [EnumMember(Value = "AreaDamageReduction")] AreaDamageReduction = 2,
        [XmlEnum("Armor")] [EnumMember(Value = "Armor")] Armor = 3,
        [XmlEnum("BuildingWorkRate")] [EnumMember(Value = "BuildingWorkRate")] BuildingWorkRate = 4,
        [XmlEnum("BuildPoints")] [EnumMember(Value = "BuildPoints")] BuildPoints = 5,
        [XmlEnum("CarryCapacity")] [EnumMember(Value = "CarryCapacity")] CarryCapacity = 6,
        [XmlEnum("ConvertResist")] [EnumMember(Value = "ConvertResist")] ConvertResist = 7,
        [XmlEnum("CostAll")] [EnumMember(Value = "CostAll")] CostAll = 8,
        [XmlEnum("Damage")] [EnumMember(Value = "Damage")] Damage = 9,
        [XmlEnum("DamageBonus")] [EnumMember(Value = "DamageBonus")] DamageBonus = 10,
        [XmlEnum("DamageBonusReduction")] [EnumMember(Value = "DamageBonusReduction")] DamageBonusReduction = 11,
        [XmlEnum("HitPercent")] [EnumMember(Value = "HitPercent")] HitPercent = 12,
        [XmlEnum("Hitpoints")] [EnumMember(Value = "Hitpoints")] Hitpoints = 13,
        [XmlEnum("LOS")] [EnumMember(Value = "LOS")] Los = 14,
        [XmlEnum("MaximumRange")] [EnumMember(Value = "MaximumRange")] MaximumRange = 15,
        [XmlEnum("MaximumVelocity")] [EnumMember(Value = "MaximumVelocity")] MaximumVelocity = 16,
        [XmlEnum("TargetSpeedBoost")] [EnumMember(Value = "TargetSpeedBoost")] TargetSpeedBoost = 17,
        [XmlEnum("TargetSpeedBoostResist")] [EnumMember(Value = "TargetSpeedBoostResist")] TargetSpeedBoostResist = 18,
        [XmlEnum("TrainPoints")] [EnumMember(Value = "TrainPoints")] TrainPoints = 19,
        [XmlEnum("WorkRate")] [EnumMember(Value = "WorkRate")] WorkRate = 20
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EffectActionTypeEnum
    {
        [XmlEnum("Invalid")] [EnumMember(Value = "Invalid")] Invalid = 0,
        [XmlEnum("Build")] [EnumMember(Value = "Build")] Build = 1,
        [XmlEnum("Convert")] [EnumMember(Value = "Convert")] Convert = 2,
        [XmlEnum("Empower")] [EnumMember(Value = "Empower")] Empower = 3,
        [XmlEnum("FishGather")] [EnumMember(Value = "FishGather")] FishGather = 4,
        [XmlEnum("Gather")] [EnumMember(Value = "Gather")] Gather = 5,
        [XmlEnum("Heal")] [EnumMember(Value = "Heal")] Heal = 6,
        [XmlEnum("MeleeAttack")] [EnumMember(Value = "MeleeAttack")] MeleeAttack = 7,
        [XmlEnum("RangedAttack")] [EnumMember(Value = "RangedAttack")] RangedAttack = 8,
        [XmlEnum("SelfHeal")] [EnumMember(Value = "SelfHeal")] SelfHeal = 9,
        [XmlEnum("Trade")] [EnumMember(Value = "Trade")] Trade = 10,
        [XmlEnum("AreaHeal")] [EnumMember(Value = "AreaHeal")] AreaHeal = 11
    }
}