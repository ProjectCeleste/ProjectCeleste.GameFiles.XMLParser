#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Model.Common
{
    public interface IItemCostCapitalResource
    {
        double Quantity { get; }
        CapitalResourceTypeEnum Type { get; }
    }

    public interface IItemCostGameCurrency
    {
        double Quantity { get; }
        GameCurrencyTypeEnum Type { get; }
    }

    public interface IItemCost
    {
        IItemCostCapitalResource CapitalResource { get; }
        IItemCostGameCurrency GameCurrency { get; }
    }
}