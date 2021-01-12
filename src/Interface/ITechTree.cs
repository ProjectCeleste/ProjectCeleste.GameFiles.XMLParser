#region Using directives

using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ITechTreeTech
    {
        int ContentPack { get; }
        List<TechTreeXmCost> Cost { get; }
        int Dbid { get; }
        string DisplayNameId { get; }
        TechTreeXmlEffects Effects { get; }
        HashSet<string> Flag { get; }
        string Icon { get; }
        string Name { get; }
        TechTreeXmlPreReqs PreReqs { get; }
        double ResearchPoints { get; }
        int RolloverTextId { get; }
        TechStatusEnumUpper Status { get; }
        string Type { get; }
    }

    public interface ITechTree : IDictionaryContainer<string, ITechTreeTech>
    {
        int Version { get; }
    }

    public interface ITechTreeXml : ITechTree
    {
        void SaveToXmlFile(string file);
    }
}