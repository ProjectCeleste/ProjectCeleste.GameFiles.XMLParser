#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconTraits : IDictionaryContainer<string, EconTraitXml>
    {
    }

    public interface IEconTraitsReadOnly : IReadOnlyContainer<string, EconTraitXml>
    {
    }
}