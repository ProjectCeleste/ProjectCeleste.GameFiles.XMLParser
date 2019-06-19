#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconQuests : IDictionaryContainer<string, EconQuestXml>
    {
    }

    public interface IEconQuestsReadOnly : IReadOnlyContainer<string, EconQuestXml>
    {
    }
}