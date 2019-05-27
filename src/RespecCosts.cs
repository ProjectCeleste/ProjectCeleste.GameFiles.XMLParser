#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    public class RarityInfo
    {
        public RarityInfo(RarityEnum rarity, double factor)
        {
            Rarity = rarity;
            Factor = factor;
        }

        public RarityEnum Rarity { get; }

        public double Factor { get; }
    }

    public class ItemBudgetInfo
    {
        public ItemBudgetInfo(InventoryItemTypeEnum inventoryItemType, double budgetModifier)
        {
            InventoryItemType = inventoryItemType;
            BudgetModifier = budgetModifier;
        }

        public InventoryItemTypeEnum InventoryItemType { get; }

        public double BudgetModifier { get; }
    }

    public class RespecCostsLevel
    {
        public RespecCostsLevel(int levelMin, int levelMax, double cost)
        {
            Cost = cost;
            LevelMin = levelMin;
            LevelMax = levelMax;
        }

        public double Cost { get; }

        public int LevelMin { get; }

        public int LevelMax { get; }
    }

    public static class RespecCosts
    {
        private static readonly ReadOnlyCollection<RespecCostsLevel> RespecCostsLevel;

        private static readonly ReadOnlyCollection<ItemBudgetInfo> ItemBudgetInfo;

        private static readonly ReadOnlyCollection<RarityInfo> RarityInfo;

        static RespecCosts()
        {
            var itemBudgetInfo = new List<ItemBudgetInfo>
            {
                new ItemBudgetInfo(InventoryItemTypeEnum.Trait, 10),
                new ItemBudgetInfo(InventoryItemTypeEnum.Advisor, 30)
            };
            ItemBudgetInfo = new ReadOnlyCollection<ItemBudgetInfo>(itemBudgetInfo);

            var respecCostsLevel = new List<RespecCostsLevel>
            {
                new RespecCostsLevel(0, 2, 0.0),
                new RespecCostsLevel(3, 4, 1.0),
                new RespecCostsLevel(5, 7, 5.0),
                new RespecCostsLevel(8, 10, 10.0),
                new RespecCostsLevel(11, 20, 50.0),
                new RespecCostsLevel(21, 30, 100.0),
                new RespecCostsLevel(31, 99, 250.0)
            };
            RespecCostsLevel = new ReadOnlyCollection<RespecCostsLevel>(respecCostsLevel);

            var rarityInfo = new List<RarityInfo>
            {
                new RarityInfo(RarityEnum.Junk, 1.0),
                new RarityInfo(RarityEnum.Common, 1.0),
                new RarityInfo(RarityEnum.Uncommon, 1.0),
                new RarityInfo(RarityEnum.Rare, 2.0),
                new RarityInfo(RarityEnum.Epic, 4.0),
                new RarityInfo(RarityEnum.Legendary, 6.0)
            };
            RarityInfo = new ReadOnlyCollection<RarityInfo>(rarityInfo);
        }

        public static ItemCostXml GetSellCostOverride(InventoryItemTypeEnum inventoryItemType, int itemLvl,
            RarityEnum itemRarity)
        {
            var lvlRange = RespecCostsLevel.FirstOrDefault(key => key.LevelMin <= itemLvl && itemLvl <= key.LevelMax);

            if (lvlRange == null)
                return new ItemCostXml(CapitalResourceTypeEnum.cCapResCoin, 0);

            var result = lvlRange.Cost;
            var budgetInfo = ItemBudgetInfo.FirstOrDefault(key => key.InventoryItemType == inventoryItemType);

            if (budgetInfo != null)
            {
                var budgetModifier = budgetInfo.BudgetModifier;
                var rarityInfo = RarityInfo.FirstOrDefault(key => key.Rarity == itemRarity);
                result = lvlRange.Cost + budgetModifier * rarityInfo?.Factor ?? lvlRange.Cost + budgetModifier;
            }

            if (result < 0)
                result = 0;

            return new ItemCostXml(CapitalResourceTypeEnum.cCapResCoin, result);
        }

        public static ItemCostXml GetSellCostOverride(object econItem)
        {
            InventoryItemTypeEnum inventoryItemType;
            int itemLvl;
            RarityEnum itemRarity;
            switch (econItem)
            {
                case EconAdvisorXml item:
                    inventoryItemType = InventoryItemTypeEnum.Advisor;
                    itemLvl = item.ItemLevel;
                    itemRarity = item.Rarity;
                    break;
                case EconBlueprintXml item:
                    inventoryItemType = InventoryItemTypeEnum.Blueprint;
                    itemLvl = item.ItemLevel;
                    itemRarity = (RarityEnum) item.Rarity;
                    break;
                case EconConsumableXml item:
                    inventoryItemType = InventoryItemTypeEnum.Consumable;
                    itemLvl = item.ItemLevel;
                    itemRarity = (RarityEnum) item.Rarity;
                    break;
                case EconMaterialXml item:
                    inventoryItemType = InventoryItemTypeEnum.Material;
                    itemLvl = item.ItemLevel;
                    itemRarity = (RarityEnum) item.Rarity;
                    break;
                case EconDesignXml item:
                    inventoryItemType = InventoryItemTypeEnum.Design;
                    itemLvl = item.ItemLevel;
                    itemRarity = (RarityEnum) item.Rarity;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(econItem), econItem, null);
            }

            return GetSellCostOverride(inventoryItemType, itemLvl, itemRarity);
        }

        public static void FixSellCostOverride(object econItem, ref ItemCostXml sellCostOverride)
        {
            InventoryItemTypeEnum inventoryItemType;
            int itemLvl;
            bool isSellable;
            RarityEnum itemRarity;
            switch (econItem)
            {
                case EconAdvisorXml item:
                    inventoryItemType = InventoryItemTypeEnum.Advisor;
                    itemLvl = item.ItemLevel;
                    isSellable = item.Sellable;
                    itemRarity = item.Rarity;
                    break;
                case EconBlueprintXml item:
                    inventoryItemType = InventoryItemTypeEnum.Blueprint;
                    itemLvl = item.ItemLevel;
                    isSellable = item.Sellable;
                    itemRarity = (RarityEnum) item.Rarity;
                    break;
                case EconConsumableXml item:
                    inventoryItemType = InventoryItemTypeEnum.Consumable;
                    itemLvl = item.ItemLevel;
                    isSellable = item.Sellable;
                    itemRarity = (RarityEnum) item.Rarity;
                    break;
                case EconMaterialXml item:
                    inventoryItemType = InventoryItemTypeEnum.Material;
                    itemLvl = item.ItemLevel;
                    isSellable = item.Sellable;
                    itemRarity = (RarityEnum) item.Rarity;
                    break;
                case EconDesignXml item:
                    inventoryItemType = InventoryItemTypeEnum.Design;
                    itemLvl = item.ItemLevel;
                    isSellable = item.Sellable;
                    itemRarity = (RarityEnum) item.Rarity;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(econItem), econItem, null);
            }

            ItemCostXml itemCost;
            if ((sellCostOverride == null || sellCostOverride.CapitalResource == null &&
                 sellCostOverride.GameCurrency == null) && isSellable)
                itemCost = GetSellCostOverride(inventoryItemType, itemLvl, itemRarity);
            else
                itemCost = sellCostOverride;

            sellCostOverride = itemCost != null &&
                               (itemCost.CapitalResource?.Quantity > 0 ||
                                itemCost.GameCurrency?.Quantity > 0)
                ? itemCost
                : new ItemCostXml(CapitalResourceTypeEnum.cCapResCoin, 0);
        }
    }
}