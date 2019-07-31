#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IProtoUnitOverridesXml : IProtoUnitOverrides
    {
        void SaveToXmlFile(string file);
    }

    public interface IProtoUnitOverrides : IDictionaryContainer<string, IProtoAge4Unit>
    {
    }
}