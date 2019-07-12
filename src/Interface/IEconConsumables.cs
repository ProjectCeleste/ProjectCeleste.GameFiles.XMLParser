#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconConsumables : IDictionaryContainer<string, EconConsumableXml>
    {
    }

    public interface IEconConsumablesReadOnly : IReadOnlyContainer<string, EconConsumableXml>
    {
    }
}