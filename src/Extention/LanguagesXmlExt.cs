#region Using directives

using System;
using System.ComponentModel.DataAnnotations;
using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class LanguagesXmlExt
    {
        public static string GetAgeLocalizedString(LanguagesXml languages, [Range(0, 3)] int age,
            string language = "English")
        {
            switch (age)
            {
                case 0:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[63902].Text}";
                case 1:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[63903].Text}";
                case 2:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[63904].Text}";
                case 3:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[63905].Text}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(age), age, null);
            }
        }

        public static string ToLocalizedString(this ResourceTypeEnum type, LanguagesXml languages,
            string language = "English")
        {
            switch (type)
            {
                case ResourceTypeEnum.Wood:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[18899].Text}";
                case ResourceTypeEnum.Food:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[18900].Text}";
                case ResourceTypeEnum.Stone:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[28529].Text}";
                case ResourceTypeEnum.Gold:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[18129].Text}";
                case ResourceTypeEnum.SkillPoints:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[28530].Text}";
                case ResourceTypeEnum.Xp:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[31117].Text}";
                case ResourceTypeEnum.Ships:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[31818].Text}";
                case ResourceTypeEnum.Invalid:
                    return "Invalid!";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string ToLocalizedString(this InventoryItemTypeEnum type, LanguagesXml languages,
            string language = "English")
        {
            switch (type)
            {
                case InventoryItemTypeEnum.Material:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52890].Text}";
                case InventoryItemTypeEnum.Blueprint:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52887].Text}";
                case InventoryItemTypeEnum.Trait:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[63898].Text}";
                case InventoryItemTypeEnum.Design:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52888].Text}";
                case InventoryItemTypeEnum.Resource:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[36059].Text}";
                case InventoryItemTypeEnum.Advisor:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[63901].Text}";
                case InventoryItemTypeEnum.Consumable:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52891].Text}";
                case InventoryItemTypeEnum.LootRoll:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[57460].Text}";
                case InventoryItemTypeEnum.Quest:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[53219].Text}";
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

        public static string ToLocalizedString(this RarityEnum rarity, LanguagesXml languages,
            string language = "English")
        {
            return ToLocalizedString((CRarityEnum) rarity, languages, language);
        }

        public static string ToLocalizedString(this CRarityEnum rarity, LanguagesXml languages,
            string language = "English")
        {
            switch (rarity)
            {
                case CRarityEnum.Junk:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52993].Text}";
                case CRarityEnum.Common:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52994].Text}";
                case CRarityEnum.Uncommon:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52995].Text}";
                case CRarityEnum.Rare:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52996].Text}";
                case CRarityEnum.Epic:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[52997].Text}";
                case CRarityEnum.Legendary:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[53075].Text}";
                case CRarityEnum.All:
                    return "All";
                default:
                    throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null);
            }
        }

        public static string ToLocalizedString(this GameCurrencyTypeEnum type, LanguagesXml languages,
            string language = "English")
        {
            switch (type)
            {
                case GameCurrencyTypeEnum.EmpirePoints:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55403].Text}";
                case GameCurrencyTypeEnum.None:
                    throw new InvalidOperationException("Invalid GameCurrency");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string ToLocalizedString(this CapitalResourceTypeEnum type, LanguagesXml languages,
            string language = "English")
        {
            switch (type)
            {
                case CapitalResourceTypeEnum.cCapResCoin:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55395].Text}";
                case CapitalResourceTypeEnum.cCapResWorkers:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55396].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints1:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55397].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints2:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55398].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints3:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55399].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints4:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55400].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints5:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55401].Text}";
                case CapitalResourceTypeEnum.cCapResFactionPoints6:
                    return
                        $"{languages["stringtablex"].Language[language].LanguageString[55402].Text}";
                case CapitalResourceTypeEnum.None:
                    throw new InvalidOperationException("Invalid CapitalResource");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}