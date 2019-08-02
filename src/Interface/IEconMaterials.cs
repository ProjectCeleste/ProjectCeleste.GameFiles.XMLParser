#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model.Common;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconMaterial
    {
        EAllianceEnum Alliance { get; }
        int BudgetCost { get; }
        int ContentPack { get; }
        bool Destroyable { get; }
        int DisplayNameId { get; }
        EventEnum Event { get; }
        string Icon { get; }
        int ItemLevel { get; }
        string Name { get; }
        EOfferTypeEnum OfferType { get; }
        CRarityEnum Rarity { get; }
        int RollOverTextId { get; }
        bool Sellable { get; }
        IItemCost SellCostOverride { get; }
        string Stackable { get; }
        int StackSize { get; }
        bool Tradeable { get; }

        void SetSellCostOverride(CapitalResourceTypeEnum type, double amount);
        void SetSellCostOverride(GameCurrencyTypeEnum type, double amount);
        void SetSellCostOverride(IItemCost cost);
        void RemoveSellCostOverride();
    }

    public interface IEconMaterials : IDictionaryContainer<string, IEconMaterial>
    {
    }

    public interface IEconMaterialsXml : IEconMaterials
    {
        void SaveToXmlFile(string file);
    }
}