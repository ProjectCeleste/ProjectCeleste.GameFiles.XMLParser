#region Using directives

using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model.Common;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconConsumable
    {
        HashSet<EAllianceEnum> Alliance { get; }
        string CharacterModifier { get; }
        ECivilizationEnum CivMatchingType { get; }
        bool Destroyable { get; }
        int DisplayNameId { get; }
        EventEnum Event { get; }
        string Icon { get; }
        int ItemLevel { get; }
        string Name { get; }
        EOfferTypeEnum OfferType { get; }
        string Power { get; }
        CRarityEnum Rarity { get; }
        int RollOverTextId { get; }
        bool Sellable { get; }
        IItemCost SellCostOverride { get; }
        string Stackable { get; }
        int StackSize { get; }
        bool Tradeable { get; }
        EconConsumableTypeEnum Type { get; }
        HashSet<EconConsumableUsableEnum> Usable { get; }

        void SetSellCostOverride(CapitalResourceTypeEnum type, double amount);
        void SetSellCostOverride(GameCurrencyTypeEnum type, double amount);
        void SetSellCostOverride(IItemCost cost);
        void RemoveSellCostOverride();
    }

    public interface IEconConsumables : IDictionaryContainer<string, IEconConsumable>
    {
    }

    public interface IEconConsumablesXml : IEconConsumables
    {
        void SaveToXmlFile(string file);
    }
}