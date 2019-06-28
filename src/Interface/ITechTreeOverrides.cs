#region Using directives

using System;
using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ITechTreeOverridesTech : ITechTreeOverridesTechReadOnly
    {
        //void SetName(string name);
        void SetOverride(string @override);
    }

    public interface ITechTreeOverridesTechReadOnly
    {
        string Name { get; }
        string Override { get; }
    }

    public interface ITechTreeOverridesXml : ITechTreeOverrides
    {
        void SaveToXmlFile(string file);
    }

    public interface ITechTreeOverrides : IDictionaryContainer<string, ITechTreeOverridesTech>,
        ITechTreeOverridesReadOnly
    {
        new ITechTreeOverridesTech this[string key] { get; }
        new int Count { get; }
        new bool ContainsKey(string key);
        new ITechTreeOverridesTech Get(Func<ITechTreeOverridesTech, bool> critera);
        new ITechTreeOverridesTech Get(string key);
        new IEnumerable<ITechTreeOverridesTech> Gets();
        new IEnumerable<ITechTreeOverridesTech> Gets(Func<ITechTreeOverridesTech, bool> critera);
        new bool TryGet(string key, out ITechTreeOverridesTech value);

        void SetMaxAge(int maxAge);
        void SetUnlockFullTechTree(bool unlockFullTechTree);
    }

    public interface ITechTreeOverridesReadOnly : IReadOnlyContainer<string, ITechTreeOverridesTechReadOnly>
    {
        int MaxAge { get; }
        bool UnlockFullTechTree { get; }
    }
}