using System;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
{
    public static class LanguagesExt
    {
        public static string GetAgeLocalizedString(ILanguages languages, int age,
            string language = "English")
        {
            switch (age)
            {
                case 0:
                    return
                        $"{languages["stringtablex"][language][63902].Text}";
                case 1:
                    return
                        $"{languages["stringtablex"][language][63903].Text}";
                case 2:
                    return
                        $"{languages["stringtablex"][language][63904].Text}";
                case 3:
                    return
                        $"{languages["stringtablex"][language][63905].Text}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(age), age, null);
            }
        }

        public static string ToLocalizedString(this ResourceTypeEnum type, ILanguages languages,
            string language = "English")
        {
            switch (type)
            {
                case ResourceTypeEnum.Wood:
                    return
                        $"{languages["stringtablex"][language][18899].Text}";
                case ResourceTypeEnum.Food:
                    return
                        $"{languages["stringtablex"][language][18900].Text}";
                case ResourceTypeEnum.Stone:
                    return
                        $"{languages["stringtablex"][language][28529].Text}";
                case ResourceTypeEnum.Gold:
                    return
                        $"{languages["stringtablex"][language][18129].Text}";
                case ResourceTypeEnum.SkillPoints:
                    return
                        $"{languages["stringtablex"][language][28530].Text}";
                case ResourceTypeEnum.Xp:
                    return
                        $"{languages["stringtablex"][language][31117].Text}";
                case ResourceTypeEnum.Ships:
                    return
                        $"{languages["stringtablex"][language][31818].Text}";
                case ResourceTypeEnum.Invalid:
                    return "Invalid!";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string ToLocalizedString(this InventoryItemTypeEnum type, ILanguages languages,
            string language = "English")
        {
            switch (type)
            {
                case InventoryItemTypeEnum.Material:
                    return
                        $"{languages["stringtablex"][language][52890].Text}";
                case InventoryItemTypeEnum.Blueprint:
                    return
                        $"{languages["stringtablex"][language][52887].Text}";
                case InventoryItemTypeEnum.Trait:
                    return
                        $"{languages["stringtablex"][language][63898].Text}";
                case InventoryItemTypeEnum.Design:
                    return
                        $"{languages["stringtablex"][language][52888].Text}";
                case InventoryItemTypeEnum.Resource:
                    return
                        $"{languages["stringtablex"][language][36059].Text}";
                case InventoryItemTypeEnum.Advisor:
                    return
                        $"{languages["stringtablex"][language][63901].Text}";
                case InventoryItemTypeEnum.Consumable:
                    return
                        $"{languages["stringtablex"][language][52891].Text}";
                case InventoryItemTypeEnum.LootRoll:
                    return
                        $"{languages["stringtablex"][language][57460].Text}";
                case InventoryItemTypeEnum.Quest:
                    return
                        $"{languages["stringtablex"][language][53219].Text}";
                case InventoryItemTypeEnum.CapitalResource:
                    return
                        "Capital Resource";
                case InventoryItemTypeEnum.GameCurrency:
                    return
                        "Game Currency";
                case InventoryItemTypeEnum.Invalid:
                    return
                        "Invalid!";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string ToLocalizedString(this RarityEnum rarity, ILanguages languages,
            string language = "English")
        {
            return ToLocalizedString((CRarityEnum)rarity, languages, language);
        }

        public static string ToLocalizedString(this CRarityEnum rarity, ILanguages languages,
            string language = "English")
        {
            switch (rarity)
            {
                case CRarityEnum.Junk:
                    return
                        $"{languages["stringtablex"][language][52993].Text}";
                case CRarityEnum.Common:
                    return
                        $"{languages["stringtablex"][language][52994].Text}";
                case CRarityEnum.Uncommon:
                    return
                        $"{languages["stringtablex"][language][52995].Text}";
                case CRarityEnum.Rare:
                    return
                        $"{languages["stringtablex"][language][52996].Text}";
                case CRarityEnum.Epic:
                    return
                        $"{languages["stringtablex"][language][52997].Text}";
                case CRarityEnum.Legendary:
                    return
                        $"{languages["stringtablex"][language][53075].Text}";
                case CRarityEnum.All:
                    return "All";
                default:
                    throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null);
            }
        }

        public static string ToLocalizedString(this GameCurrencyTypeEnum type, ILanguages languages,
            string language = "English")
        {
            switch (type)
            {
                case GameCurrencyTypeEnum.EmpirePoints:
                    return
                        $"{languages["stringtablex"][language][55403].Text}";
                case GameCurrencyTypeEnum.None:
                    throw new InvalidOperationException("Invalid GameCurrency");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string ToLocalizedString(this CapitalResourceTypeEnum type, ILanguages languages,
            string language = "English")
        {
            switch (type)
            {
                case CapitalResourceTypeEnum.cCapResCoin:
                    return
                        $"{languages["stringtablex"][language][55395].Text}";
                case CapitalResourceTypeEnum.cCapResWorkers:
                    return
                        $"{languages["stringtablex"][language][55396].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints1:
                    return
                        $"{languages["stringtablex"][language][55397].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints2:
                    return
                        $"{languages["stringtablex"][language][55398].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints3:
                    return
                        $"{languages["stringtablex"][language][55399].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints4:
                    return
                        $"{languages["stringtablex"][language][55400].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints5:
                    return
                        $"{languages["stringtablex"][language][55401].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints6:
                    return
                        $"{languages["stringtablex"][language][55402].Text}";
                case CapitalResourceTypeEnum.None:
                    throw new InvalidOperationException("Invalid CapitalResource");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}