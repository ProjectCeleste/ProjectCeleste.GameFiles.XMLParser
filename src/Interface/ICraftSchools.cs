#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ICraftSchool
    {
        CraftschoolAllowedCapitalsXml AllowedCapitals { get; }
        string CraftingSound { get; }
        int Description { get; }
        string Design { get; }
        int DisplayName { get; }
        CraftSchoolGearIconsXml GearIcons { get; }
        string Icon { get; }
        CraftSchoolItemsXml Items { get; }
        string StartingBlueprint { get; }
        CraftSchoolEnum Tag { get; }
    }

    public interface ICraftSchools : IDictionaryContainer<CraftSchoolEnum, ICraftSchool>
    {
    }

    public interface ICraftSchoolsXml : ICraftSchools
    {
        void SaveToXmlFile(string file);
    }
}