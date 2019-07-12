#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IAiCharacters : IDictionaryContainer<string, AiCharacterXml>
    {
    }

    public interface IAiCharactersReadOnly : IReadOnlyContainer<string, AiCharacterXml>
    {
    }
}