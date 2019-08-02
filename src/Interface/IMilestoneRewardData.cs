#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IMilestoneRewardData
    {
        IMilestoneRewardDataRewards Rewards { get; }
        IMilestoneRewardDataTiers Tiers { get; }
    }

    public interface IMilestoneRewardDataRewards : IDictionaryContainer<string, MilestoneRewardDataXmlReward>
    {
    }

    public interface IMilestoneRewardDataTiers : IDictionaryContainer<string, MilestoneRewardDataXmlTier>
    {
    }

    public interface IMilestoneRewardDataXml : IMilestoneRewardData
    {
        void SaveToXmlFile(string file);
    }
}