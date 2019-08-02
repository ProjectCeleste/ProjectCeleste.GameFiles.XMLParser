#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;
using ProjectCeleste.GameFiles.XMLParser.Model.Common;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconAdvisor
    {
        int Age { get; }
        EAllianceEnum Alliance { get; }
        ECivilizationEnum Civilization { get; }
        bool Destroyable { get; }
        int DisplayDescriptionId { get; }
        int DisplayNameId { get; }
        EventEnum Event { get; }
        int GroupId { get; }
        string Icon { get; }
        string IconTextureCoords { get; }
        bool IsSpecialBorder { get; }
        int ItemLevel { get; }
        int Minlevel { get; }
        string Name { get; }
        EOfferTypeEnum OfferType { get; }
        RarityEnum Rarity { get; }
        string RollOverTextId { get; }
        bool Sellable { get; }
        IItemCost SellCostOverride { get; }
        int ShortDescriptionId { get; }
        EconAdvisorTechsXml Techs { get; }
        bool Tradeable { get; }

        void SetSellCostOverride(CapitalResourceTypeEnum type, double amount);
        void SetSellCostOverride(GameCurrencyTypeEnum type, double amount);
        void SetSellCostOverride(IItemCost cost);
        void RemoveSellCostOverride();
    }

    public interface IEconAdvisors : IDictionaryContainer<string, IEconAdvisor>
    {
    }

    public interface IEconAdvisorsXml : IEconAdvisors
    {
        void SaveToXmlFile(string file);
    }
}