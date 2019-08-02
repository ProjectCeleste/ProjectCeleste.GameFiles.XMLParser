#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IRewardTable
    {
        string Name { get; }
        IDictionaryContainer<string, RewardTableXmlRewards> Rewards { get; }
    }

    public interface IRewardTables : IDictionaryContainer<string, IRewardTable>
    {
    }

    public interface IRewardTablesXml : IRewardTables
    {
        void SaveToXmlFile(string file);
    }
}