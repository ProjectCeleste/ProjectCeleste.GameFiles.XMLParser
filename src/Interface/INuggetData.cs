#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface INuggetData
    {
        INuggets Nuggets { get; }
        INuggetLogic NuggetLogic { get; }
    }

    public interface INuggetDataReadOnly
    {
        INuggetsReadOnly Nuggets { get; }
        INuggetLogicReadOnly NuggetLogic { get; }
    }

    public interface INuggets : IDictionaryContainer<int, NuggetXml>
    {
    }

    public interface INuggetsReadOnly : IReadOnlyContainer<int, NuggetXml>
    {
    }

    public interface INuggetLogic
    {
        IDictionaryContainer<string, NuggetLogicXmlEventNuggetOverride> EventNuggetOverride { get; }
        IDictionaryContainer<string, NuggetLogicXmlRandomMapRegion> RandomMapRegion { get; }
    }

    public interface INuggetLogicReadOnly
    {
        IReadOnlyContainer<string, NuggetLogicXmlEventNuggetOverride> EventNuggetOverride { get; }
        IReadOnlyContainer<string, NuggetLogicXmlRandomMapRegion> RandomMapRegion { get; }
    }
}