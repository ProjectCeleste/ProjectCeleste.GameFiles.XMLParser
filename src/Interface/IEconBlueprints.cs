#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;
using ProjectCeleste.GameFiles.XMLParser.Model.Common;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconBlueprint
    {
        EAllianceEnum Alliance { get; }
        EconBluePrintXmlCost Cost { get; }
        bool Destroyable { get; }
        int DisplayNameId { get; }
        EventEnum Event { get; }
        string Icon { get; }
        int ItemLevel { get; }
        string Name { get; }
        EOfferTypeEnum OfferType { get; }
        string ProtoUnit { get; }
        CRarityEnum Rarity { get; }
        int RollOverTextId { get; }
        bool Sellable { get; }
        IItemCost SellCostOverride { get; }
        int StackSize { get; }
        BluePrintTagEnum Tag { get; }
        bool Tradeable { get; }

        void SetSellCostOverride(CapitalResourceTypeEnum type, double amount);
        void SetSellCostOverride(GameCurrencyTypeEnum type, double amount);
        void SetSellCostOverride(IItemCost cost);
        void RemoveSellCostOverride();
    }

    public interface IEconBlueprints : IDictionaryContainer<string, IEconBlueprint>
    {
    }

    public interface IEconBlueprintsXml : IEconBlueprints
    {
        void SaveToXmlFile(string file);
    }
}