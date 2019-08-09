#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "weight", Description = "")]
    [XmlRoot(ElementName = "weight")]
    public class BonusEventDataXmlWeight
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "category", Required = Required.Always)]
        [XmlAttribute(AttributeName = "category")]
        public string Category { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "weight", Required = Required.Always)]
        [XmlElement(ElementName = "weight")]
        public int Weight { get; set; }

        [Required]
        [JsonProperty(PropertyName = "mincooldown", Required = Required.Always)]
        [XmlElement(ElementName = "mincooldown")]
        public TimeSpan MinCooldown { get; set; }

        [Required]
        [JsonProperty(PropertyName = "maxcooldown", Required = Required.Always)]
        [XmlElement(ElementName = "maxcooldown")]
        public TimeSpan MaxCooldown { get; set; }
    }

    [JsonObject(Title = "categoryweights", Description = "")]
    [XmlRoot(ElementName = "categoryweights")]
    public class BonusEventDataXmlCategoryWeights
    {
        [Required]
        [JsonProperty(PropertyName = "weight", Required = Required.Always)]
        [XmlElement(ElementName = "weight")]
        public List<BonusEventDataXmlWeight> Weight { get; set; }
    }

    [JsonObject(Title = "announcementinfo", Description = "")]
    [XmlRoot(ElementName = "announcementinfo")]
    public class BonusEventDataXmlAnnouncementInfo
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "eventstartedid", Required = Required.Always)]
        [XmlElement(ElementName = "eventstartedid")]
        public int EventStartedId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "eventinprogressid", Required = Required.Always)]
        [XmlElement(ElementName = "eventinprogressid")]
        public int EventInprogressId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "eventendedid", Required = Required.Always)]
        [XmlElement(ElementName = "eventendedid")]
        public int EventEndedId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "eventprotip", Required = Required.Always)]
        [XmlElement(ElementName = "eventprotip")]
        public string EventProtip { get; set; }
    }

    [JsonObject(Title = "globalbonusevent", Description = "")]
    [XmlRoot(ElementName = "globalbonusevent")]
    public class BonusEventDataXmlGlobalBonusEvent
    {
        [Key]
        [Required]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public EventEnum Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "calendarid", Required = Required.Always)]
        [XmlElement(ElementName = "calendarid")]
        public string CalendarId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "announcementinfo", Required = Required.Always)]
        [XmlElement(ElementName = "announcementinfo")]
        public BonusEventDataXmlAnnouncementInfo AnnouncementInfo { get; set; }

        [Required]
        [Range(0, 100)]
        [JsonProperty(PropertyName = "percentchancetopick", Required = Required.Always)]
        [XmlElement(ElementName = "percentchancetopick")]
        public int PercentChanceToPick { get; set; }
    }

    [JsonObject(Title = "bonusevents", Description = "")]
    [XmlRoot(ElementName = "bonusevents")]
    public class BonusEventDataXmlBonusEvents : DictionaryContainer<EventEnum, BonusEventDataXmlGlobalBonusEvent>
    {
        public BonusEventDataXmlBonusEvents() : base(key => key.Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "globalbonusevent", Required = Required.Always)]
        [XmlElement(ElementName = "globalbonusevent")]
        public BonusEventDataXmlGlobalBonusEvent[] Characters
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
    }

    [JsonObject(Title = "bonuseventdata", Description = "")]
    [XmlRoot(ElementName = "bonuseventdata")]
    public class BonusEventDataXml : IBonusEventDataXml
    {
        [XmlElement(ElementName = "categoryweights")]
        public BonusEventDataXmlCategoryWeights CategoryWeights { get; set; }

        [XmlElement(ElementName = "bonusevents")]
        public BonusEventDataXmlBonusEvents BonusEvents { get; set; }


        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }

        public static IBonusEventDataXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<BonusEventDataXml>(file);
        }
    }
}