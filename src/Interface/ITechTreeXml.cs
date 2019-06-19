#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ITechTree : IDictionaryContainer<string, TechTreeXmlTech>
    {
        int Version { get; set; }
    }

    public interface ITechTreeReadOnly : IReadOnlyContainer<string, TechTreeXmlTech>
    {
        int Version { get; }
    }
}