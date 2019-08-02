#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IAiCharacter
    {
        AiCharacterXmlTechs ActiveTechs { get; }
        AiCharacterXmlAssignedAdvisors AssignedAdvisors { get; }
        AiCharacterXmlAvailableAdvisors AvailableAdvisors { get; }
        CivilizationEnum CivId { get; }
        byte CurrentAge { get; }
        int CurrentRegion { get; }
        string FileName { get; }
        int Level { get; }
        string Name { get; }
        int NextScenarioId { get; }
        AiCharacterXmlProtoUnits ProtoUnits { get; }
        int SkillPoints { get; }
        AiCharacterXmlTraits Traits { get; }
        string UnlockedRegion { get; }
        int Version { get; }
        int Xp { get; }
    }

    public interface IAiCharactersXml : IAiCharacters
    {
        void SaveToXmlFile(string id, string file);
    }

    public interface IAiCharacters : IDictionaryContainer<string, IAiCharacter>
    {
    }
}