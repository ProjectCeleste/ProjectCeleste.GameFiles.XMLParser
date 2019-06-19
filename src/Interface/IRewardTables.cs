﻿#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IRewardTables : IDictionaryContainer<string, RewardTableXml>
    {
    }

    public interface IRewardTablesReadOnly : IReadOnlyContainer<string, RewardTableXml>
    {
    }
}