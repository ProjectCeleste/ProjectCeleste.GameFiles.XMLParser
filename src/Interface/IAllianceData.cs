using System;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IAlliancePassive
    {
        int Level { get; }
        TechStatusEnum PersistentCityTechStatus { get; }
        string Tech { get; }
        TechStatusEnum TechStatus { get; }
    }

    public interface IAllianceRank
    {
        int PercentileIndex { get; }
        string TitleId { get; }
        string IconPath { get; }
        IReadOnlyContainer<string, IAlliancePassive> Passives { get; }
    }

    public interface IAlliance
    {
        EAllianceEnum AllianceType { get; }
        string ChatChannelInternalName { get; }
        int DescriptionId { get; }
        int DisplayNameId { get; }
        int HomeRegionId { get; }
        int LeaderNameId { get; }
        IReadOnlyContainer<int, IAllianceRank> Ranks { get; }
    }

    public interface IAllianceDataRank
    {
        XmlTimeSpan CalculationInterval { get; }
        XmlTimeSpan ExpiryTime { get; }
        int MinApContribution { get; }
    }

    public interface IAllianceData : IReadOnlyContainer<EAllianceEnum, IAlliance>
    {
        int MinCharacterLevel { get; }

        IAllianceDataRank RankData { get; }
    }

    public interface IAllianceDataXml : IAllianceData
    {
        void SaveToXmlFile(string file);
    }
}