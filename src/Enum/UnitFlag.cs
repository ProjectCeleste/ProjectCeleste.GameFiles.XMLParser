#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnitFlagEnum
    {
        [XmlEnum("AdjustPositionOnTerrainCollision")] [EnumMember(Value = "AdjustPositionOnTerrainCollision")]
        AdjustPositionOnTerrainCollision = 0,
        [XmlEnum("AdvisorUnit")] [EnumMember(Value = "AdvisorUnit")] AdvisorUnit = 1,
        [XmlEnum("AllowAutoGarrison")] [EnumMember(Value = "AllowAutoGarrison")] AllowAutoGarrison = 2,

        [XmlEnum("AlwaysFullColorAsCursor")] [EnumMember(Value = "AlwaysFullColorAsCursor")] AlwaysFullColorAsCursor =
            3,
        [XmlEnum("ApplyHandicapTraining")] [EnumMember(Value = "ApplyHandicapTraining")] ApplyHandicapTraining = 4,
        [XmlEnum("AttackBuildingsFirst")] [EnumMember(Value = "AttackBuildingsFirst")] AttackBuildingsFirst = 5,
        [XmlEnum("AutoGatherFromSocket")] [EnumMember(Value = "AutoGatherFromSocket")] AutoGatherFromSocket = 6,
        [XmlEnum("AutoProduction")] [EnumMember(Value = "AutoProduction")] AutoProduction = 7,
        [XmlEnum("BringsUpAllianceDialog")] [EnumMember(Value = "BringsUpAllianceDialog")] BringsUpAllianceDialog = 8,
        [XmlEnum("BringsUpArenaDialog")] [EnumMember(Value = "BringsUpArenaDialog")] BringsUpArenaDialog = 9,
        [XmlEnum("BringsUpEquipmentUI")] [EnumMember(Value = "BringsUpEquipmentUI")] BringsUpEquipmentUi = 10,
        [XmlEnum("BringsUpMailDialog")] [EnumMember(Value = "BringsUpMailDialog")] BringsUpMailDialog = 11,
        [XmlEnum("BringsUpPDLCDialog")] [EnumMember(Value = "BringsUpPDLCDialog")] BringsUpPdlcDialog = 12,
        [XmlEnum("BringsUpPvPDialog")] [EnumMember(Value = "BringsUpPvPDialog")] BringsUpPvPDialog = 13,
        [XmlEnum("BringsUpQuestProTip")] [EnumMember(Value = "BringsUpQuestProTip")] BringsUpQuestProTip = 14,
        [XmlEnum("BringsUpTraitDialog")] [EnumMember(Value = "BringsUpTraitDialog")] BringsUpTraitDialog = 15,
        [XmlEnum("BringsUpTreasuryDialog")] [EnumMember(Value = "BringsUpTreasuryDialog")] BringsUpTreasuryDialog = 16,
        [XmlEnum("BringsUpVendorDialog")] [EnumMember(Value = "BringsUpVendorDialog")] BringsUpVendorDialog = 17,

        [XmlEnum("BringsUpWarehouseDialog")] [EnumMember(Value = "BringsUpWarehouseDialog")] BringsUpWarehouseDialog =
            18,
        [XmlEnum("Burnable")] [EnumMember(Value = "Burnable")] Burnable = 19,
        [XmlEnum("CanAutoHeal")] [EnumMember(Value = "CanAutoHeal")] CanAutoHeal = 20,

        [XmlEnum("CollidesWithProjectiles")] [EnumMember(Value = "CollidesWithProjectiles")] CollidesWithProjectiles =
            21,
        [XmlEnum("ColonyBuilding")] [EnumMember(Value = "ColonyBuilding")] ColonyBuilding = 22,
        [XmlEnum("ColonyPlacementCenter")] [EnumMember(Value = "ColonyPlacementCenter")] ColonyPlacementCenter = 23,
        [XmlEnum("ConstrainOrientation")] [EnumMember(Value = "ConstrainOrientation")] ConstrainOrientation = 24,
        [XmlEnum("CraftingBuilding")] [EnumMember(Value = "CraftingBuilding")] CraftingBuilding = 25,
        [XmlEnum("CraftSchoolBuilding")] [EnumMember(Value = "CraftSchoolBuilding")] CraftSchoolBuilding = 26,

        [XmlEnum("DeadReplacementWhenDestroyed")] [EnumMember(Value = "DeadReplacementWhenDestroyed")]
        DeadReplacementWhenDestroyed = 27,

        [XmlEnum("DecalStickToWaterSurface")] [EnumMember(Value = "DecalStickToWaterSurface")]
        DecalStickToWaterSurface = 28,
        [XmlEnum("DestroyProjectile")] [EnumMember(Value = "DestroyProjectile")] DestroyProjectile = 29,
        [XmlEnum("DestroyUnderBuilding")] [EnumMember(Value = "DestroyUnderBuilding")] DestroyUnderBuilding = 30,
        [XmlEnum("DieAtZeroResources")] [EnumMember(Value = "DieAtZeroResources")] DieAtZeroResources = 31,

        [XmlEnum("DisplayAdvisorVendorIcon")] [EnumMember(Value = "DisplayAdvisorVendorIcon")]
        DisplayAdvisorVendorIcon = 32,

        [XmlEnum("DisplayArmorShieldVendorIcon")] [EnumMember(Value = "DisplayArmorShieldVendorIcon")]
        DisplayArmorShieldVendorIcon = 33,

        [XmlEnum("DisplayConstructionHammerVendorIcon")] [EnumMember(Value = "DisplayConstructionHammerVendorIcon")]
        DisplayConstructionHammerVendorIcon = 34,

        [XmlEnum("DisplayConstructionSawVendorIcon")] [EnumMember(Value = "DisplayConstructionSawVendorIcon")]
        DisplayConstructionSawVendorIcon = 35,

        [XmlEnum("DisplayConsumableVendorIcon")] [EnumMember(Value = "DisplayConsumableVendorIcon")]
        DisplayConsumableVendorIcon = 36,

        [XmlEnum("DisplayEmpirePointVendorIcon")] [EnumMember(Value = "DisplayEmpirePointVendorIcon")]
        DisplayEmpirePointVendorIcon = 37,

        [XmlEnum("DisplayGeneralVendorIcon")] [EnumMember(Value = "DisplayGeneralVendorIcon")]
        DisplayGeneralVendorIcon = 38,

        [XmlEnum("DisplayRareLootVendorIcon")] [EnumMember(Value = "DisplayRareLootVendorIcon")]
        DisplayRareLootVendorIcon = 39,

        [XmlEnum("DisplayVanityVendorIcon")] [EnumMember(Value = "DisplayVanityVendorIcon")] DisplayVanityVendorIcon =
            40,

        [XmlEnum("DisplayWeaponStaffVendorIcon")] [EnumMember(Value = "DisplayWeaponStaffVendorIcon")]
        DisplayWeaponStaffVendorIcon = 41,

        [XmlEnum("DisplayWeaponSwordVendorIcon")] [EnumMember(Value = "DisplayWeaponSwordVendorIcon")]
        DisplayWeaponSwordVendorIcon = 42,
        [XmlEnum("DoesNotAutoAttack")] [EnumMember(Value = "DoesNotAutoAttack")] DoesNotAutoAttack = 43,

        [XmlEnum("DoNotCreateUnitGroupAutomatically")] [EnumMember(Value = "DoNotCreateUnitGroupAutomatically")]
        DoNotCreateUnitGroupAutomatically = 44,

        [XmlEnum("DoNotDieAtZeroHitpoints")] [EnumMember(Value = "DoNotDieAtZeroHitpoints")] DoNotDieAtZeroHitpoints =
            45,
        [XmlEnum("DoNotShowOnMiniMap")] [EnumMember(Value = "DoNotShowOnMiniMap")] DoNotShowOnMiniMap = 46,

        [XmlEnum("DoNotValidateResourceInventory")] [EnumMember(Value = "DoNotValidateResourceInventory")]
        DoNotValidateResourceInventory = 47,
        [XmlEnum("DontFlattenGround")] [EnumMember(Value = "DontFlattenGround")] DontFlattenGround = 48,
        [XmlEnum("DontRotateObstruction")] [EnumMember(Value = "DontRotateObstruction")] DontRotateObstruction = 49,
        [XmlEnum("Doppled")] [EnumMember(Value = "Doppled")] Doppled = 50,
        [XmlEnum("DoppleOnlyWhenDead")] [EnumMember(Value = "DoppleOnlyWhenDead")] DoppleOnlyWhenDead = 51,
        [XmlEnum("FlattenGround")] [EnumMember(Value = "FlattenGround")] FlattenGround = 52,
        [XmlEnum("FlyingUnit")] [EnumMember(Value = "FlyingUnit")] FlyingUnit = 53,
        [XmlEnum("ForceToGaia")] [EnumMember(Value = "ForceToGaia")] ForceToGaia = 54,
        [XmlEnum("FromBlueprint")] [EnumMember(Value = "FromBlueprint")] FromBlueprint = 55,
        [XmlEnum("GivesLOSToAll")] [EnumMember(Value = "GivesLOSToAll")] GivesLosToAll = 56,
        [XmlEnum("HasGatherPoint")] [EnumMember(Value = "HasGatherPoint")] HasGatherPoint = 57,
        [XmlEnum("HideAggressiveMoveCmd")] [EnumMember(Value = "HideAggressiveMoveCmd")] HideAggressiveMoveCmd = 58,
        [XmlEnum("HideFromHelp")] [EnumMember(Value = "HideFromHelp")] HideFromHelp = 59,
        [XmlEnum("IgnoreFormation")] [EnumMember(Value = "IgnoreFormation")] IgnoreFormation = 60,
        [XmlEnum("Immoveable")] [EnumMember(Value = "Immoveable")] Immoveable = 61,
        [XmlEnum("InvasionBldg")] [EnumMember(Value = "InvasionBldg")] InvasionBldg = 62,
        [XmlEnum("Invulnerable")] [EnumMember(Value = "Invulnerable")] Invulnerable = 63,
        [XmlEnum("InvulnerableIfGaia")] [EnumMember(Value = "InvulnerableIfGaia")] InvulnerableIfGaia = 64,
        [XmlEnum("NeverShowButton")] [EnumMember(Value = "NeverShowButton")] NeverShowButton = 65,
        [XmlEnum("NoBloodOnDeath")] [EnumMember(Value = "NoBloodOnDeath")] NoBloodOnDeath = 66,
        [XmlEnum("NoFadeOnDeath")] [EnumMember(Value = "NoFadeOnDeath")] NoFadeOnDeath = 67,
        [XmlEnum("NoHPBar")] [EnumMember(Value = "NoHPBar")] NoHpBar = 68,
        [XmlEnum("NoIdleActions")] [EnumMember(Value = "NoIdleActions")] NoIdleActions = 69,
        [XmlEnum("NonAutoFormedUnit")] [EnumMember(Value = "NonAutoFormedUnit")] NonAutoFormedUnit = 70,
        [XmlEnum("NonCollideable")] [EnumMember(Value = "NonCollideable")] NonCollideable = 71,
        [XmlEnum("NonSolid")] [EnumMember(Value = "NonSolid")] NonSolid = 72,
        [XmlEnum("NotCommandable")] [EnumMember(Value = "NotCommandable")] NotCommandable = 73,
        [XmlEnum("NotDeleteable")] [EnumMember(Value = "NotDeleteable")] NotDeleteable = 74,
        [XmlEnum("NoTieToGround")] [EnumMember(Value = "NoTieToGround")] NoTieToGround = 75,

        [XmlEnum("NotObscuredByUnitsAsFoundation")] [EnumMember(Value = "NotObscuredByUnitsAsFoundation")]
        NotObscuredByUnitsAsFoundation = 76,
        [XmlEnum("NotPlayerPlaceable")] [EnumMember(Value = "NotPlayerPlaceable")] NotPlayerPlaceable = 77,
        [XmlEnum("NotRotateable")] [EnumMember(Value = "NotRotateable")] NotRotateable = 78,
        [XmlEnum("NotSearchable")] [EnumMember(Value = "NotSearchable")] NotSearchable = 79,
        [XmlEnum("NotSelectable")] [EnumMember(Value = "NotSelectable")] NotSelectable = 80,
        [XmlEnum("NoUnitAI")] [EnumMember(Value = "NoUnitAI")] NoUnitAi = 81,
        [XmlEnum("Nugget")] [EnumMember(Value = "Nugget")] Nugget = 82,
        [XmlEnum("ObscuredByUnits")] [EnumMember(Value = "ObscuredByUnits")] ObscuredByUnits = 83,
        [XmlEnum("ObscuresUnits")] [EnumMember(Value = "ObscuresUnits")] ObscuresUnits = 84,
        [XmlEnum("OnlyInEditor")] [EnumMember(Value = "OnlyInEditor")] OnlyInEditor = 85,
        [XmlEnum("OrientUnitWithGround")] [EnumMember(Value = "OrientUnitWithGround")] OrientUnitWithGround = 86,

        [XmlEnum("PaintTextureWhenPlacing")] [EnumMember(Value = "PaintTextureWhenPlacing")] PaintTextureWhenPlacing =
            87,
        [XmlEnum("PlaceAnywhere")] [EnumMember(Value = "PlaceAnywhere")] PlaceAnywhere = 88,
        [XmlEnum("PlaceAsFoundation")] [EnumMember(Value = "PlaceAsFoundation")] PlaceAsFoundation = 89,
        [XmlEnum("PlayerOwnsObstruction")] [EnumMember(Value = "PlayerOwnsObstruction")] PlayerOwnsObstruction = 90,
        [XmlEnum("ProductionBuilding")] [EnumMember(Value = "ProductionBuilding")] ProductionBuilding = 91,
        [XmlEnum("ProductionToHopper")] [EnumMember(Value = "ProductionToHopper")] ProductionToHopper = 92,
        [XmlEnum("Projectile")] [EnumMember(Value = "Projectile")] Projectile = 93,
        [XmlEnum("QuestGiver")] [EnumMember(Value = "QuestGiver")] QuestGiver = 94,
        [XmlEnum("RevealFoundation")] [EnumMember(Value = "RevealFoundation")] RevealFoundation = 95,
        [XmlEnum("RMCanRotate")] [EnumMember(Value = "RMCanRotate")] RmCanRotate = 96,
        [XmlEnum("RotateInPlace")] [EnumMember(Value = "RotateInPlace")] RotateInPlace = 97,
        [XmlEnum("SelectWithObstruction")] [EnumMember(Value = "SelectWithObstruction")] SelectWithObstruction = 98,
        [XmlEnum("SelfHeal")] [EnumMember(Value = "SelfHeal")] SelfHeal = 99,
        [XmlEnum("ShowGarrisonButton")] [EnumMember(Value = "ShowGarrisonButton")] ShowGarrisonButton = 100,
        [XmlEnum("SkirmishHallBuilding")] [EnumMember(Value = "SkirmishHallBuilding")] SkirmishHallBuilding = 101,
        [XmlEnum("SnapPlacement")] [EnumMember(Value = "SnapPlacement")] SnapPlacement = 102,
        [XmlEnum("SocketOnPlacement")] [EnumMember(Value = "SocketOnPlacement")] SocketOnPlacement = 103,
        [XmlEnum("StartingColonyBuilding")] [EnumMember(Value = "StartingColonyBuilding")] StartingColonyBuilding = 104,
        [XmlEnum("StartOnNoUpdate")] [EnumMember(Value = "StartOnNoUpdate")] StartOnNoUpdate = 105,
        [XmlEnum("StartsAtFullEfficiency")] [EnumMember(Value = "StartsAtFullEfficiency")] StartsAtFullEfficiency = 106,

        [XmlEnum("TieAnimTimeToBuildPercent")] [EnumMember(Value = "TieAnimTimeToBuildPercent")]
        TieAnimTimeToBuildPercent = 107,
        [XmlEnum("TieToWaterSurface")] [EnumMember(Value = "TieToWaterSurface")] TieToWaterSurface = 108,
        [XmlEnum("TileAlignPlacement")] [EnumMember(Value = "TileAlignPlacement")] TileAlignPlacement = 109,
        [XmlEnum("Tracked")] [EnumMember(Value = "Tracked")] Tracked = 110,
        [XmlEnum("TransformableToGate")] [EnumMember(Value = "TransformableToGate")] TransformableToGate = 111,
        [XmlEnum("UnlimitedSupply")] [EnumMember(Value = "UnlimitedSupply")] UnlimitedSupply = 112,

        [XmlEnum("UseAlignedObstructionOnMinimap")] [EnumMember(Value = "UseAlignedObstructionOnMinimap")]
        UseAlignedObstructionOnMinimap = 113,
        [XmlEnum("VariationLocked")] [EnumMember(Value = "VariationLocked")] VariationLocked = 114,
        [XmlEnum("VictoryBuilding")] [EnumMember(Value = "VictoryBuilding")] VictoryBuilding = 115,
        [XmlEnum("VisibleUnderFog")] [EnumMember(Value = "VisibleUnderFog")] VisibleUnderFog = 116,
        [XmlEnum("VisibleUnderFogIfGaia")] [EnumMember(Value = "VisibleUnderFogIfGaia")] VisibleUnderFogIfGaia = 117,

        [XmlEnum("VisibleUnderFogOnlyAfterSeen")] [EnumMember(Value = "VisibleUnderFogOnlyAfterSeen")]
        VisibleUnderFogOnlyAfterSeen = 118,
        [XmlEnum("wallBuild")] [EnumMember(Value = "wallBuild")] WallBuild = 119,
        [XmlEnum("Wanders")] [EnumMember(Value = "Wanders")] Wanders = 120
    }
}