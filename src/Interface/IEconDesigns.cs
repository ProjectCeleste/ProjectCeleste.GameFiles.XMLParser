#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;
using ProjectCeleste.GameFiles.XMLParser.Model.Common;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconDesign
    {
        bool Advanced { get; }
        EAllianceEnum Alliance { get; }
        bool AutoLearn { get; }
        bool AutoRepeat { get; }
        double BudgetModifier { get; }
        bool Destroyable { get; }
        int DisplayNameId { get; }
        EventEnum Event { get; }
        string Icon { get; }
        bool IgnoreSchool { get; }
        EconDesignXmlInput Input { get; }
        int ItemLevel { get; }
        string Name { get; }
        EOfferTypeEnum OfferType { get; }
        EconDesignXmlOutput Output { get; }
        int OutputTraitLevel { get; }
        double ProductionPoints { get; }
        CRarityEnum Rarity { get; }
        int RollOverTextId { get; }
        bool Sellable { get; }
        IItemCost SellCostOverride { get; }
        int StackSize { get; }
        SchoolTagEnum Tag { get; }
        bool ToHopper { get; }
        bool Tradeable { get; }

        void SetSellCostOverride(CapitalResourceTypeEnum type, double amount);
        void SetSellCostOverride(GameCurrencyTypeEnum type, double amount);
        void SetSellCostOverride(IItemCost cost);
        void RemoveSellCostOverride();
    }

    public interface IEconDesigns : IDictionaryContainer<string, IEconDesign>
    {
    }

    public interface IEconDesignsXml : IEconDesigns
    {
        void SaveToXmlFile(string file);
    }
}