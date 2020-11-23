using System;
using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Model;

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IAllianceContestReward
    {
        int BaseEp { get; set; }
        int Placement { get; set; }
    }

    public interface IAllianceContestScaledReward
    {
        int Ep { get; set; }
        int PercentileAsIndex { get; set; }
    }

    public interface IContestData : IReadOnlyContainer<string, ContestDataXmlContest>
    {
        XmlTimeSpan ParticipationBonusTime { get; }
    }

    public interface IContestDataXml : IContestData
    {
        void SaveToXmlFile(string file);
    }
}