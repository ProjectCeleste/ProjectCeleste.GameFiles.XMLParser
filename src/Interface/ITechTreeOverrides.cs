#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ITechTreeOverridesTech
    {
        string Name { get; }
        string Override { get; }

        //void SetName(string name);
        void SetOverride(string @override);
    }

    public interface ITechTreeOverridesXml : ITechTreeOverrides
    {
        void SaveToXmlFile(string file);
    }

    public interface ITechTreeOverrides : IDictionaryContainer<string, ITechTreeOverridesTech>
    {
        int MaxAge { get; }
        bool UnlockFullTechTree { get; }
        void SetMaxAge(int maxAge);
        void SetUnlockFullTechTree(bool unlockFullTechTree);
    }
}