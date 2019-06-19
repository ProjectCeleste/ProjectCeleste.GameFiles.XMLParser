#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconBlueprints : IDictionaryContainer<string, EconBlueprintXml>
    {
    }

    public interface IEconBlueprintsReadOnly : IReadOnlyContainer<string, EconBlueprintXml>
    {
    }
}