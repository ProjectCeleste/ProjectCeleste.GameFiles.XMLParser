#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IRandomMapSet
    {
        bool CannotReplace { get; }
        int DisplayNameId { get; }
        int HelpTextId { get; }
        string Id { get; }
        string ImagePath { get; }
        IDictionaryContainer<string, RandomMapSetXmlMap> Map { get; }
    }

    public interface IRandomMapSets : IDictionaryContainer<string, IRandomMapSet>
    {
    }

    public interface IRandomMapSetsXml : IRandomMapSets
    {
        void SaveToXmlFile(string id, string file);
    }
}