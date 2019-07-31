#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IQuestGiverManager
    {
        IQuestGivers QuestGivers { get; }
    }

    public interface IQuestGivers : IDictionaryContainer<string, QuestGiverXml>
    {
    }
}