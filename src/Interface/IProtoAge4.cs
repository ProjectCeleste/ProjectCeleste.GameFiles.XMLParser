#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IProtoAge4 : IDictionaryContainer<string, ProtoAge4XmlUnit>
    {
        int Version { get; set; }
    }

    public interface IProtoAge4ReadOnly : IReadOnlyContainer<string, ProtoAge4XmlUnit>
    {
        int Version { get; }
    }
}