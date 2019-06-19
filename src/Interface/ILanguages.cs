#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ILanguages : IDictionaryContainer<string, StringTableXml>
    {
    }

    public interface ILanguagesReadOnly : IReadOnlyContainer<string, StringTableXml>
    {
    }
}