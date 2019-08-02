#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IRegion
    {
        bool Alliance { get; }
        string AvatarShield { get; }
        CivilizationEnum CivId { get; }
        int DescriptionStringId { get; }
        int DisplayNameStringId { get; }
        string FileName { get; }
        string FlagIcon { get; }
        bool Hidden { get; }
        int Id { get; }
        string LoadScreen { get; }
        double MapLocationX { get; }
        double MapLocationY { get; }
        string MapMarker { get; }
        string MapName { get; }
        string MapPage { get; }
        string Name { get; }
        string PlayList { get; }
    }

    public interface IRegions : IDictionaryContainer<int, IRegion>
    {
    }

    public interface IRegionsXml : IRegions
    {
        void SaveToXmlFile(int id, string file);
    }
}