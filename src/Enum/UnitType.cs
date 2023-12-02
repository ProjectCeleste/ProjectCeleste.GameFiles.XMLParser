#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnitTypeEnum
    {
        [XmlEnum("AbstractAdvisorHall")] [EnumMember(Value = "AbstractAdvisorHall")] AbstractAdvisorHall = 0,
        [XmlEnum("AbstractAllianceHall")] [EnumMember(Value = "AbstractAllianceHall")] AbstractAllianceHall = 1,
        [XmlEnum("AbstractArcher")] [EnumMember(Value = "AbstractArcher")] AbstractArcher = 2,
        [XmlEnum("AbstractArena")] [EnumMember(Value = "AbstractArena")] AbstractArena = 3,
        [XmlEnum("AbstractArtillery")] [EnumMember(Value = "AbstractArtillery")] AbstractArtillery = 4,
        [XmlEnum("AbstractBear")] [EnumMember(Value = "AbstractBear")] AbstractBear = 5,
        [XmlEnum("AbstractBoar")] [EnumMember(Value = "AbstractBoar")] AbstractBoar = 6,
        [XmlEnum("AbstractCanSeeStealth")] [EnumMember(Value = "AbstractCanSeeStealth")] AbstractCanSeeStealth = 7,
        [XmlEnum("AbstractCavalry")] [EnumMember(Value = "AbstractCavalry")] AbstractCavalry = 8,
        [XmlEnum("AbstractCraftingHall")] [EnumMember(Value = "AbstractCraftingHall")] AbstractCraftingHall = 9,
        [XmlEnum("AbstractCraftingSchool")] [EnumMember(Value = "AbstractCraftingSchool")] AbstractCraftingSchool = 10,
        [XmlEnum("AbstractDock")] [EnumMember(Value = "AbstractDock")] AbstractDock = 11,
        [XmlEnum("AbstractEmbassy")] [EnumMember(Value = "AbstractEmbassy")] AbstractEmbassy = 12,
        [XmlEnum("AbstractEmpireStore")] [EnumMember(Value = "AbstractEmpireStore")] AbstractEmpireStore = 13,
        [XmlEnum("AbstractFarm")] [EnumMember(Value = "AbstractFarm")] AbstractFarm = 14,
        [XmlEnum("AbstractFish")] [EnumMember(Value = "AbstractFish")] AbstractFish = 15,
        [XmlEnum("AbstractFruit")] [EnumMember(Value = "AbstractFruit")] AbstractFruit = 16,
        [XmlEnum("AbstractGearHall")] [EnumMember(Value = "AbstractGearHall")] AbstractGearHall = 17,
        [XmlEnum("AbstractGeneralStore")] [EnumMember(Value = "AbstractGeneralStore")] AbstractGeneralStore = 18,
        [XmlEnum("AbstractHandCavalry")] [EnumMember(Value = "AbstractHandCavalry")] AbstractHandCavalry = 19,
        [XmlEnum("AbstractInfantry")] [EnumMember(Value = "AbstractInfantry")] AbstractInfantry = 20,
        [XmlEnum("AbstractMarket")] [EnumMember(Value = "AbstractMarket")] AbstractMarket = 21,
        [XmlEnum("AbstractMine")] [EnumMember(Value = "AbstractMine")] AbstractMine = 22,
        [XmlEnum("AbstractNPCBoss")] [EnumMember(Value = "AbstractNPCBoss")] AbstractNpcBoss = 23,
        [XmlEnum("AbstractNugget")] [EnumMember(Value = "AbstractNugget")] AbstractNugget = 24,
        [XmlEnum("AbstractNuggetGuard")] [EnumMember(Value = "AbstractNuggetGuard")] AbstractNuggetGuard = 25,
        [XmlEnum("AbstractPalace")] [EnumMember(Value = "AbstractPalace")] AbstractPalace = 26,
        [XmlEnum("AbstractPriest")] [EnumMember(Value = "AbstractPriest")] AbstractPriest = 27,
        [XmlEnum("AbstractPvP")] [EnumMember(Value = "AbstractPvP")] AbstractPvP = 28,
        [XmlEnum("AbstractRangedCavalry")] [EnumMember(Value = "AbstractRangedCavalry")] AbstractRangedCavalry = 29,
        [XmlEnum("AbstractTownCenter")] [EnumMember(Value = "AbstractTownCenter")] AbstractTownCenter = 30,
        [XmlEnum("AbstractTransportable")] [EnumMember(Value = "AbstractTransportable")] AbstractTransportable = 31,
        [XmlEnum("AbstractUniqueUnit")] [EnumMember(Value = "AbstractUniqueUnit")] AbstractUniqueUnit = 32,

        [XmlEnum("AbstractUnitTypeCapDock")] [EnumMember(Value = "AbstractUnitTypeCapDock")] AbstractUnitTypeCapDock =
            33,
        [XmlEnum("AbstractVanityStore")] [EnumMember(Value = "AbstractVanityStore")] AbstractVanityStore = 34,
        [XmlEnum("AbstractVillager")] [EnumMember(Value = "AbstractVillager")] AbstractVillager = 35,
        [XmlEnum("AbstractWall")] [EnumMember(Value = "AbstractWall")] AbstractWall = 36,
        [XmlEnum("AbstractWarehouse")] [EnumMember(Value = "AbstractWarehouse")] AbstractWarehouse = 37,
        [XmlEnum("AbstractWarShip")] [EnumMember(Value = "AbstractWarShip")] AbstractWarShip = 38,
        [XmlEnum("AbstractWolf")] [EnumMember(Value = "AbstractWolf")] AbstractWolf = 39,
        [XmlEnum("AbstractWorkshop")] [EnumMember(Value = "AbstractWorkshop")] AbstractWorkshop = 40,

        [XmlEnum("AbstractWorkShopAdvanced")] [EnumMember(Value = "AbstractWorkShopAdvanced")]
        AbstractWorkShopAdvanced = 41,
        [XmlEnum("AbstractWorkShopBasic")] [EnumMember(Value = "AbstractWorkShopBasic")] AbstractWorkShopBasic = 42,
        [XmlEnum("AffectedByTownBell")] [EnumMember(Value = "AffectedByTownBell")] AffectedByTownBell = 43,
        [XmlEnum("AgeUpBuildingAge2")] [EnumMember(Value = "AgeUpBuildingAge2")] AgeUpBuildingAge2 = 44,
        [XmlEnum("AgeUpBuildingAge3")] [EnumMember(Value = "AgeUpBuildingAge3")] AgeUpBuildingAge3 = 45,
        [XmlEnum("AgeUpBuildingAge4")] [EnumMember(Value = "AgeUpBuildingAge4")] AgeUpBuildingAge4 = 46,
        [XmlEnum("AnimalPrey")] [EnumMember(Value = "AnimalPrey")] AnimalPrey = 47,
        [XmlEnum("Building")] [EnumMember(Value = "Building")] Building = 48,
        [XmlEnum("BuildingClass")] [EnumMember(Value = "BuildingClass")] BuildingClass = 49,
        [XmlEnum("CapCitizen")] [EnumMember(Value = "CapCitizen")] CapCitizen = 50,
        [XmlEnum("CapitalBldgCeltic")] [EnumMember(Value = "CapitalBldgCeltic")] CapitalBldgCeltic = 51,
        [XmlEnum("CapitolBldgAll")] [EnumMember(Value = "CapitolBldgAll")] CapitolBldgAll = 52,
        [XmlEnum("CapitolBldgBabylon")] [EnumMember(Value = "CapitolBldgBabylon")] CapitolBldgBabylon = 53,
        [XmlEnum("CapitolBldgEgypt")] [EnumMember(Value = "CapitolBldgEgypt")] CapitolBldgEgypt = 54,
        [XmlEnum("CapitolBldgGreek")] [EnumMember(Value = "CapitolBldgGreek")] CapitolBldgGreek = 55,
        [XmlEnum("CapitolBldgNorse")] [EnumMember(Value = "CapitolBldgNorse")] CapitolBldgNorse = 56,
        [XmlEnum("CapitolBldgPersia")] [EnumMember(Value = "CapitolBldgPersia")] CapitolBldgPersia = 57,
        [XmlEnum("ColonyBuilding")] [EnumMember(Value = "ColonyBuilding")] ColonyBuilding = 58,
        [XmlEnum("ConvertableBuilding")] [EnumMember(Value = "ConvertableBuilding")] ConvertableBuilding = 59,
        [XmlEnum("ConvertableCavalry")] [EnumMember(Value = "ConvertableCavalry")] ConvertableCavalry = 60,
        [XmlEnum("ConvertableInfantry")] [EnumMember(Value = "ConvertableInfantry")] ConvertableInfantry = 61,
        [XmlEnum("ConvertableSiege")] [EnumMember(Value = "ConvertableSiege")] ConvertableSiege = 62,
        [XmlEnum("ConvertsHerds")] [EnumMember(Value = "ConvertsHerds")] ConvertsHerds = 63,

        [XmlEnum("CountsTowardEconomicScore")] [EnumMember(Value = "CountsTowardEconomicScore")]
        CountsTowardEconomicScore = 64,

        [XmlEnum("CountsTowardMilitaryScore")] [EnumMember(Value = "CountsTowardMilitaryScore")]
        CountsTowardMilitaryScore = 65,
        [XmlEnum("Dropsite")] [EnumMember(Value = "Dropsite")] Dropsite = 66,
        [XmlEnum("Economic")] [EnumMember(Value = "Economic")] Economic = 67,
        [XmlEnum("EmbellishmentClass")] [EnumMember(Value = "EmbellishmentClass")] EmbellishmentClass = 68,
        [XmlEnum("EquipmentFilterEconomy")] [EnumMember(Value = "EquipmentFilterEconomy")] EquipmentFilterEconomy = 69,

        [XmlEnum("EquipmentFilterMilitary")] [EnumMember(Value = "EquipmentFilterMilitary")] EquipmentFilterMilitary =
            70,
        [XmlEnum("EquipmentFilterUtility")] [EnumMember(Value = "EquipmentFilterUtility")] EquipmentFilterUtility = 71,
        [XmlEnum("Fish")] [EnumMember(Value = "Fish")] Fish = 72,
        [XmlEnum("Food")] [EnumMember(Value = "Food")] Food = 73,
        [XmlEnum("Gold")] [EnumMember(Value = "Gold")] Gold = 74,
        [XmlEnum("Herdable")] [EnumMember(Value = "Herdable")] Herdable = 75,
        [XmlEnum("Huntable")] [EnumMember(Value = "Huntable")] Huntable = 76,
        [XmlEnum("HuntedResource")] [EnumMember(Value = "HuntedResource")] HuntedResource = 77,

        [XmlEnum("LogicalTypeAffectedByTownBell")] [EnumMember(Value = "LogicalTypeAffectedByTownBell")]
        LogicalTypeAffectedByTownBell = 78,

        [XmlEnum("LogicalTypeAnimalsAttack")] [EnumMember(Value = "LogicalTypeAnimalsAttack")]
        LogicalTypeAnimalsAttack = 79,

        [XmlEnum("LogicalTypeBuildingsNotWalls")] [EnumMember(Value = "LogicalTypeBuildingsNotWalls")]
        LogicalTypeBuildingsNotWalls = 80,

        [XmlEnum("LogicalTypeCapVillsCanPray")] [EnumMember(Value = "LogicalTypeCapVillsCanPray")]
        LogicalTypeCapVillsCanPray = 81,

        [XmlEnum("LogicalTypeCapVillsCanRake")] [EnumMember(Value = "LogicalTypeCapVillsCanRake")]
        LogicalTypeCapVillsCanRake = 82,

        [XmlEnum("LogicalTypeConvertableBuildings")] [EnumMember(Value = "LogicalTypeConvertableBuildings")]
        LogicalTypeConvertableBuildings = 83,

        [XmlEnum("LogicalTypeEasySelectAvoid")] [EnumMember(Value = "LogicalTypeEasySelectAvoid")]
        LogicalTypeEasySelectAvoid = 84,
        [XmlEnum("LogicalTypeExplorer")] [EnumMember(Value = "LogicalTypeExplorer")] LogicalTypeExplorer = 85,
        [XmlEnum("LogicalTypeFailQuest")] [EnumMember(Value = "LogicalTypeFailQuest")] LogicalTypeFailQuest = 86,

        [XmlEnum("LogicalTypeGarrisonInShips")] [EnumMember(Value = "LogicalTypeGarrisonInShips")]
        LogicalTypeGarrisonInShips = 87,

        [XmlEnum("LogicalTypeHandUnitsAttack")] [EnumMember(Value = "LogicalTypeHandUnitsAttack")]
        LogicalTypeHandUnitsAttack = 88,

        [XmlEnum("LogicalTypeHandUnitsAutoAttack")] [EnumMember(Value = "LogicalTypeHandUnitsAutoAttack")]
        LogicalTypeHandUnitsAutoAttack = 89,
        [XmlEnum("LogicalTypeHealed")] [EnumMember(Value = "LogicalTypeHealed")] LogicalTypeHealed = 90,

        [XmlEnum("LogicalTypeLandMilitary")] [EnumMember(Value = "LogicalTypeLandMilitary")] LogicalTypeLandMilitary =
            91,

        [XmlEnum("LogicalTypeLandPickerChoice")] [EnumMember(Value = "LogicalTypeLandPickerChoice")]
        LogicalTypeLandPickerChoice = 92,

        [XmlEnum("LogicalTypeLandPickerTarget")] [EnumMember(Value = "LogicalTypeLandPickerTarget")]
        LogicalTypeLandPickerTarget = 93,

        [XmlEnum("LogicalTypeMinimapFilterEconomic")] [EnumMember(Value = "LogicalTypeMinimapFilterEconomic")]
        LogicalTypeMinimapFilterEconomic = 94,

        [XmlEnum("LogicalTypeMinimapFilterMilitary")] [EnumMember(Value = "LogicalTypeMinimapFilterMilitary")]
        LogicalTypeMinimapFilterMilitary = 95,

        [XmlEnum("LogicalTypeNeededForVictory")] [EnumMember(Value = "LogicalTypeNeededForVictory")]
        LogicalTypeNeededForVictory = 96,

        [XmlEnum("LogicalTypePriestUnitsAttack")] [EnumMember(Value = "LogicalTypePriestUnitsAttack")]
        LogicalTypePriestUnitsAttack = 97,

        [XmlEnum("LogicalTypeRamUnitsAttack")] [EnumMember(Value = "LogicalTypeRamUnitsAttack")]
        LogicalTypeRamUnitsAttack = 98,

        [XmlEnum("LogicalTypeRamUnitsAutoAttack")] [EnumMember(Value = "LogicalTypeRamUnitsAutoAttack")]
        LogicalTypeRamUnitsAutoAttack = 99,

        [XmlEnum("LogicalTypeRangedUnitsAttack")] [EnumMember(Value = "LogicalTypeRangedUnitsAttack")]
        LogicalTypeRangedUnitsAttack = 100,

        [XmlEnum("LogicalTypeRangedUnitsAutoAttack")] [EnumMember(Value = "LogicalTypeRangedUnitsAutoAttack")]
        LogicalTypeRangedUnitsAutoAttack = 101,
        [XmlEnum("LogicalTypeScout")] [EnumMember(Value = "LogicalTypeScout")] LogicalTypeScout = 102,

        [XmlEnum("LogicalTypeShipsAndBuildings")] [EnumMember(Value = "LogicalTypeShipsAndBuildings")]
        LogicalTypeShipsAndBuildings = 103,

        [XmlEnum("LogicalTypeValidSharpshoot")] [EnumMember(Value = "LogicalTypeValidSharpshoot")]
        LogicalTypeValidSharpshoot = 104,

        [XmlEnum("LogicalTypeValidSPCUnitsDeadCondition")] [EnumMember(Value = "LogicalTypeValidSPCUnitsDeadCondition")]
        LogicalTypeValidSpcUnitsDeadCondition = 105,

        [XmlEnum("LogicalTypeVillagersAttack")] [EnumMember(Value = "LogicalTypeVillagersAttack")]
        LogicalTypeVillagersAttack = 106,

        [XmlEnum("LogicalTypeVillagersRespondToAttack")] [EnumMember(Value = "LogicalTypeVillagersRespondToAttack")]
        LogicalTypeVillagersRespondToAttack = 107,
        [XmlEnum("Military")] [EnumMember(Value = "Military")] Military = 108,
        [XmlEnum("MilitaryBuilding")] [EnumMember(Value = "MilitaryBuilding")] MilitaryBuilding = 109,
        [XmlEnum("MinedResource")] [EnumMember(Value = "MinedResource")] MinedResource = 110,
        [XmlEnum("Nature")] [EnumMember(Value = "Nature")] Nature = 111,
        [XmlEnum("NatureClass")] [EnumMember(Value = "NatureClass")] NatureClass = 112,
        [XmlEnum("NubianUnit")] [EnumMember(Value = "NubianUnit")] NubianUnit = 113,
        [XmlEnum("NuggetSocket")] [EnumMember(Value = "NuggetSocket")] NuggetSocket = 114,
        [XmlEnum("Projectile")] [EnumMember(Value = "Projectile")] Projectile = 115,
        [XmlEnum("QuestAttackable")] [EnumMember(Value = "QuestAttackable")] QuestAttackable = 116,
        [XmlEnum("QuestGiverBldg")] [EnumMember(Value = "QuestGiverBldg")] QuestGiverBldg = 117,
        [XmlEnum("Resource")] [EnumMember(Value = "Resource")] Resource = 118,
        [XmlEnum("RewardDelivery")] [EnumMember(Value = "RewardDelivery")] RewardDelivery = 119,
        [XmlEnum("Ship")] [EnumMember(Value = "Ship")] Ship = 120,
        [XmlEnum("StandardConvertable")] [EnumMember(Value = "StandardConvertable")] StandardConvertable = 121,
        [XmlEnum("Stone")] [EnumMember(Value = "Stone")] Stone = 122,
        [XmlEnum("Temple")] [EnumMember(Value = "Temple")] Temple = 123,
        [XmlEnum("TradeableFrom")] [EnumMember(Value = "TradeableFrom")] TradeableFrom = 124,
        [XmlEnum("TradeableTo")] [EnumMember(Value = "TradeableTo")] TradeableTo = 125,
        [XmlEnum("Transport")] [EnumMember(Value = "Transport")] Transport = 126,
        [XmlEnum("Tree")] [EnumMember(Value = "Tree")] Tree = 127,
        [XmlEnum("Unattackable")] [EnumMember(Value = "Unattackable")] Unattackable = 128,
        [XmlEnum("Unit")] [EnumMember(Value = "Unit")] Unit = 129,
        [XmlEnum("UnitClass")] [EnumMember(Value = "UnitClass")] UnitClass = 130,
        [XmlEnum("UnitTypeArcherAntiArc1")] [EnumMember(Value = "UnitTypeArcherAntiArc1")] UnitTypeArcherAntiArc1 = 131,
        [XmlEnum("UnitTypeArcherAntiInf1")] [EnumMember(Value = "UnitTypeArcherAntiInf1")] UnitTypeArcherAntiInf1 = 132,
        [XmlEnum("UnitTypeArcherBasic1")] [EnumMember(Value = "UnitTypeArcherBasic1")] UnitTypeArcherBasic1 = 133,
        [XmlEnum("UnitTypeBldgAcademy")] [EnumMember(Value = "UnitTypeBldgAcademy")] UnitTypeBldgAcademy = 134,

        [XmlEnum("UnitTypeBldgArcheryRange")] [EnumMember(Value = "UnitTypeBldgArcheryRange")]
        UnitTypeBldgArcheryRange = 135,
        [XmlEnum("UnitTypeBldgArmory")] [EnumMember(Value = "UnitTypeBldgArmory")] UnitTypeBldgArmory = 136,
        [XmlEnum("UnitTypeBldgBandit")] [EnumMember(Value = "UnitTypeBldgBandit")] UnitTypeBldgBandit = 137,
        [XmlEnum("UnitTypeBldgBarracks")] [EnumMember(Value = "UnitTypeBldgBarracks")] UnitTypeBldgBarracks = 138,
        [XmlEnum("UnitTypeBldgDock")] [EnumMember(Value = "UnitTypeBldgDock")] UnitTypeBldgDock = 139,

        [XmlEnum("UnitTypeBldgEmpowerable")] [EnumMember(Value = "UnitTypeBldgEmpowerable")] UnitTypeBldgEmpowerable =
            140,
        [XmlEnum("UnitTypeBldgExtractor")] [EnumMember(Value = "UnitTypeBldgExtractor")] UnitTypeBldgExtractor = 141,
        [XmlEnum("UnitTypeBldgFarm")] [EnumMember(Value = "UnitTypeBldgFarm")] UnitTypeBldgFarm = 142,
        [XmlEnum("UnitTypeBldgFortress")] [EnumMember(Value = "UnitTypeBldgFortress")] UnitTypeBldgFortress = 143,
        [XmlEnum("UnitTypeBldgHouse")] [EnumMember(Value = "UnitTypeBldgHouse")] UnitTypeBldgHouse = 144,
        [XmlEnum("UnitTypeBldgMarket")] [EnumMember(Value = "UnitTypeBldgMarket")] UnitTypeBldgMarket = 145,

        [XmlEnum("UnitTypeBldgSiegeWorkshop")] [EnumMember(Value = "UnitTypeBldgSiegeWorkshop")]
        UnitTypeBldgSiegeWorkshop = 146,
        [XmlEnum("UnitTypeBldgStables")] [EnumMember(Value = "UnitTypeBldgStables")] UnitTypeBldgStables = 147,
        [XmlEnum("UnitTypeBldgStorehouse")] [EnumMember(Value = "UnitTypeBldgStorehouse")] UnitTypeBldgStorehouse = 148,
        [XmlEnum("UnitTypeBldgTemple")] [EnumMember(Value = "UnitTypeBldgTemple")] UnitTypeBldgTemple = 149,
        [XmlEnum("UnitTypeBldgTemple2")] [EnumMember(Value = "UnitTypeBldgTemple2")] UnitTypeBldgTemple2 = 150,
        [XmlEnum("UnitTypeBldgTemple3")] [EnumMember(Value = "UnitTypeBldgTemple3")] UnitTypeBldgTemple3 = 151,
        [XmlEnum("UnitTypeBldgTower")] [EnumMember(Value = "UnitTypeBldgTower")] UnitTypeBldgTower = 152,
        [XmlEnum("UnitTypeBldgTownCenter")] [EnumMember(Value = "UnitTypeBldgTownCenter")] UnitTypeBldgTownCenter = 153,
        [XmlEnum("UnitTypeBldgWall")] [EnumMember(Value = "UnitTypeBldgWall")] UnitTypeBldgWall = 154,
        [XmlEnum("UnitTypeBldgWatchPost")] [EnumMember(Value = "UnitTypeBldgWatchPost")] UnitTypeBldgWatchPost = 155,
        [XmlEnum("UnitTypeBldgWonder")] [EnumMember(Value = "UnitTypeBldgWonder")] UnitTypeBldgWonder = 156,
        [XmlEnum("UnitTypeCaravan1")] [EnumMember(Value = "UnitTypeCaravan1")] UnitTypeCaravan1 = 157,

        [XmlEnum("UnitTypeCavalryAntiArc1")] [EnumMember(Value = "UnitTypeCavalryAntiArc1")] UnitTypeCavalryAntiArc1 =
            158,

        [XmlEnum("UnitTypeCavalryAntiCav1")] [EnumMember(Value = "UnitTypeCavalryAntiCav1")] UnitTypeCavalryAntiCav1 =
            159,

        [XmlEnum("UnitTypeCavalryAntiInf1")] [EnumMember(Value = "UnitTypeCavalryAntiInf1")] UnitTypeCavalryAntiInf1 =
            160,
        [XmlEnum("UnitTypeCavalryBasic1")] [EnumMember(Value = "UnitTypeCavalryBasic1")] UnitTypeCavalryBasic1 = 161,
        [XmlEnum("UnitTypeCavalryRanged1")] [EnumMember(Value = "UnitTypeCavalryRanged1")] UnitTypeCavalryRanged1 = 162,

        [XmlEnum("UnitTypeCityDefenseResourceNode")] [EnumMember(Value = "UnitTypeCityDefenseResourceNode")]
        UnitTypeCityDefenseResourceNode = 163,

        [XmlEnum("UnitTypeCityDefenseVictoryNode")] [EnumMember(Value = "UnitTypeCityDefenseVictoryNode")]
        UnitTypeCityDefenseVictoryNode = 164,
        [XmlEnum("UnitTypeCounter")] [EnumMember(Value = "UnitTypeCounter")] UnitTypeCounter = 165,

        [XmlEnum("UnitTypeInfantryAntiArc1")] [EnumMember(Value = "UnitTypeInfantryAntiArc1")]
        UnitTypeInfantryAntiArc1 = 166,

        [XmlEnum("UnitTypeInfantryAntiCav1")] [EnumMember(Value = "UnitTypeInfantryAntiCav1")]
        UnitTypeInfantryAntiCav1 = 167,

        [XmlEnum("UnitTypeInfantryAntiInf1")] [EnumMember(Value = "UnitTypeInfantryAntiInf1")]
        UnitTypeInfantryAntiInf1 = 168,
        [XmlEnum("UnitTypeInfantryBasic1")] [EnumMember(Value = "UnitTypeInfantryBasic1")] UnitTypeInfantryBasic1 = 169,
        [XmlEnum("UnitTypeInfantryHeavy1")] [EnumMember(Value = "UnitTypeInfantryHeavy1")] UnitTypeInfantryHeavy1 = 170,

        [XmlEnum("UnitTypeMobileStorehouse1")] [EnumMember(Value = "UnitTypeMobileStorehouse1")]
        UnitTypeMobileStorehouse1 = 171,
        [XmlEnum("UnitTypePriest1")] [EnumMember(Value = "UnitTypePriest1")] UnitTypePriest1 = 172,
        [XmlEnum("UnitTypePriest2")] [EnumMember(Value = "UnitTypePriest2")] UnitTypePriest2 = 173,
        [XmlEnum("UnitTypePriest3")] [EnumMember(Value = "UnitTypePriest3")] UnitTypePriest3 = 174,
        [XmlEnum("UnitTypePriest4")] [EnumMember(Value = "UnitTypePriest4")] UnitTypePriest4 = 175,
        [XmlEnum("UnitTypePriest5")] [EnumMember(Value = "UnitTypePriest5")] UnitTypePriest5 = 176,
        [XmlEnum("UnitTypeScout1")] [EnumMember(Value = "UnitTypeScout1")] UnitTypeScout1 = 177,
        [XmlEnum("UnitTypeShipAntiShip1")] [EnumMember(Value = "UnitTypeShipAntiShip1")] UnitTypeShipAntiShip1 = 178,
        [XmlEnum("UnitTypeShipBasic1")] [EnumMember(Value = "UnitTypeShipBasic1")] UnitTypeShipBasic1 = 179,
        [XmlEnum("UnitTypeShipFishing1")] [EnumMember(Value = "UnitTypeShipFishing1")] UnitTypeShipFishing1 = 180,
        [XmlEnum("UnitTypeShipSiege1")] [EnumMember(Value = "UnitTypeShipSiege1")] UnitTypeShipSiege1 = 181,
        [XmlEnum("UnitTypeShipUtility1")] [EnumMember(Value = "UnitTypeShipUtility1")] UnitTypeShipUtility1 = 182,
        [XmlEnum("UnitTypeSiegeBallista1")] [EnumMember(Value = "UnitTypeSiegeBallista1")] UnitTypeSiegeBallista1 = 183,
        [XmlEnum("UnitTypeSiegeCatapult1")] [EnumMember(Value = "UnitTypeSiegeCatapult1")] UnitTypeSiegeCatapult1 = 184,
        [XmlEnum("UnitTypeSiegeRam1")] [EnumMember(Value = "UnitTypeSiegeRam1")] UnitTypeSiegeRam1 = 185,

        [XmlEnum("UnitTypeSiegeTrebuchet1")] [EnumMember(Value = "UnitTypeSiegeTrebuchet1")] UnitTypeSiegeTrebuchet1 =
            186,
        [XmlEnum("UnitTypeTravelShip")] [EnumMember(Value = "UnitTypeTravelShip")] UnitTypeTravelShip = 187,
        [XmlEnum("UnitTypeUniqueUnit1")] [EnumMember(Value = "UnitTypeUniqueUnit1")] UnitTypeUniqueUnit1 = 188,
        [XmlEnum("UnitTypeUniqueUnit2")] [EnumMember(Value = "UnitTypeUniqueUnit2")] UnitTypeUniqueUnit2 = 189,
        [XmlEnum("UnitTypeVillager1")] [EnumMember(Value = "UnitTypeVillager1")] UnitTypeVillager1 = 190,

        [XmlEnum("UnitUpgrade1CraftedUncommon")] [EnumMember(Value = "UnitUpgrade1CraftedUncommon")]
        UnitUpgrade1CraftedUncommon = 191,
        [XmlEnum("UnitUpgrade2Rare")] [EnumMember(Value = "UnitUpgrade2Rare")] UnitUpgrade2Rare = 192,
        [XmlEnum("UnitUpgrade3Epic")] [EnumMember(Value = "UnitUpgrade3Epic")] UnitUpgrade3Epic = 193,
        [XmlEnum("UnitUpgradeAge2")] [EnumMember(Value = "UnitUpgradeAge2")] UnitUpgradeAge2 = 194,
        [XmlEnum("UnitUpgradeAge3")] [EnumMember(Value = "UnitUpgradeAge3")] UnitUpgradeAge3 = 195,
        [XmlEnum("UnitUpgradeAge4")] [EnumMember(Value = "UnitUpgradeAge4")] UnitUpgradeAge4 = 196,
        [XmlEnum("UnitUpgradeLevel13")] [EnumMember(Value = "UnitUpgradeLevel13")] UnitUpgradeLevel13 = 197,
        [XmlEnum("UnitUpgradeLevel23")] [EnumMember(Value = "UnitUpgradeLevel23")] UnitUpgradeLevel23 = 198,
        [XmlEnum("UnitUpgradeLevel33")] [EnumMember(Value = "UnitUpgradeLevel33")] UnitUpgradeLevel33 = 199,
        [XmlEnum("UnitUpgradeLevel43")] [EnumMember(Value = "UnitUpgradeLevel43")] UnitUpgradeLevel43 = 200,
        [XmlEnum("ValidIdleVillager")] [EnumMember(Value = "ValidIdleVillager")] ValidIdleVillager = 201,
        [XmlEnum("Wood")] [EnumMember(Value = "Wood")] Wood = 202,
        [XmlEnum("CapitolBldgRoman")] [EnumMember(Value = "CapitolBldgRoman")] CapitolBldgRoman = 203,
        [XmlEnum("Ro_Civ_Engineer")] [EnumMember(Value = "Ro_Civ_Engineer")] RoCivEngineer = 204,
        [XmlEnum("EtruscanUnit")] [EnumMember(Value = "EtruscanUnit")] EtruscanUnit = 205,
        [XmlEnum("LifespanUnit")] [EnumMember(Value = "LifespanUnit")] LifespanUnit = 206,
        [XmlEnum("InvasionWonderBuilding")] [EnumMember(Value = "InvasionWonderBuilding")] InvasionWonderBuilding = 207,

        [XmlEnum("AbstractPet")] [EnumMember(Value = "AbstractPet")] AbstractPet = 208,
        [XmlEnum("AbstractShrine")] [EnumMember(Value = "AbstractShrine")] AbstractShrine = 209,
        [XmlEnum("CivSpecificText")] [EnumMember(Value = "CivSpecificText")] CivSpecificText = 210
    }
}
