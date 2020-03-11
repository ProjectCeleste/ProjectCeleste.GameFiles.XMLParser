using System;
using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Model;

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IContestData
    {
        List<ContestDataXmlContest> Contests { get; }
        TimeSpan ParticipationBonusTime { get; }
    }

    public interface IContestDataXml : IContestData
    {
        void SaveToXmlFile(string file);
    }
}