#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconLootRolls : IDictionaryContainer<string, EconLootRollXml>
    {
    }

    public interface IEconLootRollsReadOnly : IReadOnlyContainer<string, EconLootRollXml>
    {
    }
}