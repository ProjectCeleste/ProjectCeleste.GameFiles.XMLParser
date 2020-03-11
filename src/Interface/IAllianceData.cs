using System.Collections.Generic;

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    public interface IAllianceData
    {
        List<AllianceDataXmlAlliance> Alliances { get; }
        int MinCharacterLevel { get; }
        AllianceDataXmlRankData RankData { get; }
    }
    public interface IAllianceDataXml : IAllianceData
    {
        void SaveToXmlFile(string file);
    }
}