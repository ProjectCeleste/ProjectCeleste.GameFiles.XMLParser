#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ICivilizations : IDictionaryContainer<CivilizationEnum, CivilizationXml>
    {
    }

    public interface ICivilizationsReadOnly : IReadOnlyContainer<CivilizationEnum, CivilizationXml>
    {
    }
}