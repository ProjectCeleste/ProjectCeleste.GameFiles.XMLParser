#region Using directives

using System;
using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ILanguageString : ILanguageStringReadOnly
    {
        void SetLocId(int locId);
        void SetComment(string comment = null);
        void SetSymbol(string symbol = null);
        void SetText(string text = null);
    }

    public interface ILanguageStringReadOnly
    {
        int LocId { get; }
        string Comment { get; }
        string Symbol { get; }
        string Text { get; }
    }

    public interface ILanguage : IDictionaryContainer<int, ILanguageString>, ILanguageReadOnly
    {
        new ILanguageString this[int key] { get; }
        new int Count { get; }
        new bool ContainsKey(int key);
        new ILanguageString Get(Func<ILanguageString, bool> critera);
        new ILanguageString Get(int key);
        new IEnumerable<ILanguageString> Gets();
        new IEnumerable<ILanguageString> Gets(Func<ILanguageString, bool> critera);
        new bool TryGet(int key, out ILanguageString value);
        void SetName(string name);
    }

    public interface ILanguageReadOnly : IReadOnlyContainer<int, ILanguageStringReadOnly>
    {
        string Name { get; }
    }

    public interface IStringTable : IDictionaryContainer<string, ILanguage>, IStringTableReadOnly
    {
        new ILanguage this[string key] { get; }
        new int Count { get; }
        new bool ContainsKey(string key);
        new ILanguage Get(Func<ILanguage, bool> critera);
        new ILanguage Get(string key);
        new IEnumerable<ILanguage> Gets();
        new IEnumerable<ILanguage> Gets(Func<ILanguage, bool> critera);
        new bool TryGet(string key, out ILanguage value);
        void SetId(string id);
        void SetLocCurrent(int locCurrent);
        void SetLocEnd(int locEnd);
        void SetLocStart(int locStart);
        void SetVersion(int version);
    }

    public interface IStringTableReadOnly : IReadOnlyContainer<string, ILanguageReadOnly>
    {
        string Id { get; }
        int LocCurrent { get; }
        int LocEnd { get; }
        int LocStart { get; }
        int Version { get; }
    }

    public interface ILanguages : IDictionaryContainer<string, IStringTable>, ILanguagesReadOnly
    {
        new IStringTable this[string key] { get; }
        new int Count { get; }
        new bool ContainsKey(string key);
        new IStringTable Get(Func<IStringTable, bool> critera);
        new IStringTable Get(string key);
        new IEnumerable<IStringTable> Gets();
        new IEnumerable<IStringTable> Gets(Func<IStringTable, bool> critera);
        new bool TryGet(string key, out IStringTable value);
    }

    public interface ILanguagesReadOnly : IReadOnlyContainer<string, IStringTableReadOnly>
    {
    }

    public interface ILanguagesXml : ILanguages
    {
    }
}