#region Using directives

using System;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEndDate
    {
    }

    public interface ICalendarRecurrencePattern
    {
    }

    public interface ICalendarEvent
    {
        TimeSpan Duration { get; }
        string Id { get; }
        bool Overridable { get; }
        CalendarEventXmlRange Range { get; }
        ICalendarRecurrencePattern Repeat { get; }
        TimeSpan StartTime { get; }
    }

    public interface ICalendarEventsXml : ICalendarEvents
    {
        void SaveToXmlFile(string file);
    }

    public interface ICalendarEvents : IDictionaryContainer<string, ICalendarEvent>
    {
    }
}