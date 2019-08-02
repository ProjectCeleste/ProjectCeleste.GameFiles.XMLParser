#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconLootRoll
    {
        EAllianceEnum Alliance { get; }
        int DisplayNameId { get; }
        EventEnum Event { get; }
        string Icon { get; }
        int ItemLevel { get; }
        LootTableEnum LootTable { get; }
        string Name { get; }
        CRarityEnum Rarity { get; }
        int RollOverTextId { get; }
    }

    public interface IEconLootRolls : IDictionaryContainer<string, IEconLootRoll>
    {
    }

    public interface IEconLootRollsXml : IEconLootRolls
    {
        void SaveToXmlFile(string file);
    }
}