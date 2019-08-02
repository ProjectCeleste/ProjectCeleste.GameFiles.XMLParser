#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconQuest
    {
        EAllianceEnum Alliance { get; }
        int DisplayNameId { get; }
        EventEnum Event { get; }
        string Icon { get; }
        string IconTextureCoords { get; }
        int ItemLevel { get; }
        string Name { get; }
        EOfferTypeEnum OfferType { get; }
        int QuestId { get; }
        CRarityEnum Rarity { get; }
        int RollOverTextId { get; }
        EconQuestXmlSummary Summary { get; }
        int TypeId { get; }
    }

    public interface IEconQuests : IDictionaryContainer<string, IEconQuest>
    {
    }

    public interface IEconQuestsXml : IEconQuests
    {
        void SaveToXmlFile(string file);
    }
}