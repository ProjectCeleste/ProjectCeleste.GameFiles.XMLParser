#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IQuestGiver
    {
        int AltRegion { get; set; }
        string ArtSet { get; set; }
        QuestGiverXmlSpawnTrigger DespawnTrigger { get; set; }
        EventEnum Event { get; set; }
        string FarewellSoundSet { get; set; }
        string GreetingSoundSet { get; set; }
        int GreetingStringId { get; set; }
        QuestGiverXmlLocation Location { get; set; }
        string MapType { get; set; }
        string Name { get; set; }
        QuestGiverXmlOverrides Overrides { get; set; }
        string PlaceUnitType { get; set; }
        int Region { get; set; }
        QuestGiverXmlSpawnTrigger SpawnTrigger { get; set; }
        string Status { get; set; }
    }

    public interface IQuestGiverManager
    {
        IQuestGivers QuestGivers { get; }
    }

    public interface IQuestGivers : IDictionaryContainer<string, IQuestGiver>
    {
    }

    public interface IQuestGiverManagerXml : IQuestGiverManager
    {
        void SaveToXmlFile(string file);
    }
}