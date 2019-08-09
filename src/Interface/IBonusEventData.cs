#region Using directives

using System;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IGlobalBonusEvent
    {
        BonusEventDataXmlAnnouncementInfo AnnouncementInfo { get; }
        string CalendarId { get; }
        EventEnum Id { get; }
        int PercentChanceToPick { get; }
    }

    public interface IBonusEvents : IDictionaryContainer<EventEnum, IGlobalBonusEvent>
    {
    }

    public interface IWeight
    {
        string Category { get; }
        TimeSpan MaxCooldown { get; }
        TimeSpan MinCooldown { get; }
        int Weight { get; }
    }

    public interface ICategoryWeights : IDictionaryContainer<string, IWeight>
    {
    }

    public interface IBonusEventDataXml : IBonusEventData
    {
        void SaveToXmlFile(string file);
    }

    public interface IBonusEventData
    {
        IBonusEvents BonusEvents { get; }
        ICategoryWeights CategoryWeights { get; }
    }
}