#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ILanguageString
    {
        int LocId { get; }
        string Comment { get; }
        string Symbol { get; }
        string Text { get; }

        void SetLocId(int locId);
        void SetComment(string comment = null);
        void SetSymbol(string symbol = null);
        void SetText(string text = null);
    }

    public interface ILanguage : IDictionaryContainer<int, ILanguageString>
    {
        string Name { get; }
        void SetName(string name);
    }

    public interface IStringTable : IDictionaryContainer<string, ILanguage>
    {
        string Id { get; }
        int LocCurrent { get; }
        int LocEnd { get; }
        int LocStart { get; }
        int Version { get; }
        void SetId(string id);
        void SetLocCurrent(int locCurrent);
        void SetLocEnd(int locEnd);
        void SetLocStart(int locStart);
        void SetVersion(int version);
    }

    public interface ILanguages : IDictionaryContainer<string, IStringTable>
    {
    }

    public interface ILanguagesXml : ILanguages
    {
    }
}