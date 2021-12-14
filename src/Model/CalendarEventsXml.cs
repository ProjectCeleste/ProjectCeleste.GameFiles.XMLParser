#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
//TODO JsonProperty
//TODO C# Attribute
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [XmlRoot(ElementName = "endafter")]
    public class EndAfterXOccurrences : IEndDate
    {
        [XmlElement(ElementName = "occurrences")]
        public int Occurrences { get; set; }
    }

    [XmlRoot(ElementName = "endby")]
    public class EndBy : IEndDate
    {
        [XmlElement(ElementName = "date")]
        public DateTime Date { get; set; }
    }

    [XmlRoot(ElementName = "range")]
    public class CalendarEventXmlRange
    {
        [XmlElement(ElementName = "startdate")]
        public string StartDate { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "endafter", Type = typeof(EndAfterXOccurrences))]
        [XmlElement(ElementName = "endby", Type = typeof(EndBy))]
        public IEndDate EndDate { get; set; }
    }

    [XmlRoot(ElementName = "repeatyearly")]
    public class CalendarEventXmlRepeatYearly : ICalendarRecurrencePattern
    {
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }

        [XmlElement(ElementName = "everyxyears")]
        public int EveryXYears { get; set; }
    }

    [XmlRoot(ElementName = "repeatmonthly")]
    public class CalendarEventXmlRepeatMonthly : ICalendarRecurrencePattern
    {
        [XmlElement(ElementName = "dayofmonth")]
        public int DayOfMonth { get; set; }

        [XmlElement(ElementName = "everyxmonths")]
        public int EveryXMonths { get; set; }
    }

    [XmlRoot(ElementName = "repeatdaily")]
    public class CalendarEventXmlRepeatDaily : ICalendarRecurrencePattern
    {
        [XmlElement(ElementName = "everyxdays")]
        public string EveryXDays { get; set; }
    }

    [XmlRoot(ElementName = "repeathourly")]
    public class CalendarEventXmlRepeatHourly : ICalendarRecurrencePattern
    {
        [XmlElement(ElementName = "everyxhours")]
        public string EveryXHours { get; set; }
    }

    [XmlRoot(ElementName = "calendarevent")]
    public class CalendarEventXml : ICalendarEvent
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "starttime")]
        public TimeSpan StartTime { get; set; }

        [XmlElement(ElementName = "duration")]
        public TimeSpan Duration { get; set; }

        [DefaultValue(true)]
        [XmlElement(ElementName = "overridable")]
        public bool Overridable { get; set; } = true;

        [XmlElement(ElementName = "range")]
        public CalendarEventXmlRange Range { get; set; }

        [XmlElement(ElementName = "repeathourly", Type = typeof(CalendarEventXmlRepeatHourly))]
        [XmlElement(ElementName = "repeatdaily", Type = typeof(CalendarEventXmlRepeatDaily))]
        [XmlElement(ElementName = "repeatmonthly", Type = typeof(CalendarEventXmlRepeatMonthly))]
        [XmlElement(ElementName = "repeatyearly", Type = typeof(CalendarEventXmlRepeatYearly))]
        public ICalendarRecurrencePattern Repeat { get; set; }
    }

    [XmlRoot(ElementName = "calendarevents")]
    public class CalendarEventsXml : DictionaryContainer<string, CalendarEventXml, ICalendarEvent>, ICalendarEventsXml
    {
        public CalendarEventsXml() : base(key => key.Id, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "calendarevent", Required = Required.Always)]
        [XmlElement(ElementName = "calendarevent")]
        public CalendarEventXml[] CalendarEvent
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static CalendarEventsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<CalendarEventsXml>(file);
        }
    }
}