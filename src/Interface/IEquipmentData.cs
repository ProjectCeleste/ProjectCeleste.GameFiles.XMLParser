#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEquipment
    {
        int AgeRequirement { get; }
        bool BldOrUnit { get; }
        CivilizationEnum Civilization { get; }
        string CivilizationStr { get; }
        int DisplaynameId { get; }
        bool GrantedAtLevel { get; }
        int GrantingLevel { get; }
        string Icon { get; }
        int Id { get; }
        bool LargeIcon { get; }
        int MaxRank { get; }
        int Prereq { get; }
        bool QuestReward { get; }
        EquipmentDataXmlRanks Ranks { get; }
        bool SuppressEffects { get; }
        double UiCol { get; }
        string UiPanel { get; }
        double Uirow { get; }
        int Version { get; }
    }

    public interface IEquipmentData : IDictionaryContainer<int, IEquipment>
    {
    }

    public interface IEquipmentDataXml : IEquipmentData
    {
        void SaveToXmlFile(string file);
    }
}