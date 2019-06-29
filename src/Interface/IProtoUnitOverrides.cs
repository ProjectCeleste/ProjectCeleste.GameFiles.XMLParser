#region Using directives

using System;
using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IProtoUnitOverridesXml : IProtoUnitOverrides
    {
        void SaveToXmlFile(string file);
    }

    public interface IProtoUnitOverrides : IDictionaryContainer<string, IProtoAge4Unit>, IProtoUnitOverridesReadOnly
    {
        new IProtoAge4Unit this[string key] { get; }
        new int Count { get; }
        new bool ContainsKey(string key);
        new IProtoAge4Unit Get(Func<IProtoAge4Unit, bool> critera);
        new IProtoAge4Unit Get(string key);
        new IEnumerable<IProtoAge4Unit> Gets();
        new IEnumerable<IProtoAge4Unit> Gets(Func<IProtoAge4Unit, bool> critera);
        new bool TryGet(string key, out IProtoAge4Unit value);
    }

    public interface IProtoUnitOverridesReadOnly : IReadOnlyContainer<string, IProtoAge4UnitReadOnly>
    {
    }
}