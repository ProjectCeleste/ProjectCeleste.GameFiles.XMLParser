#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "equipment", Description = "")]
    [XmlRoot(ElementName = "equipment")]
    public class EquipmentDataXmlEquipment
    {
        [Key]
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "version", Required = Required.Always)]
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "civ")]
        public string CivilizationStr
        {
            get
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (Civilization)
                {
                    case CivilizationEnum.Greek:
                        return "Greek";
                    case CivilizationEnum.Egypt:
                        return "Egyptian";
                    case CivilizationEnum.Celt:
                        return "Celt";
                    case CivilizationEnum.Persia:
                        return "Persian";
                    case CivilizationEnum.Babylonian:
                        return "Babylonian";
                    case CivilizationEnum.Norse:
                        return "Norse";
                    case CivilizationEnum.Roman:
                        return "Roman";
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Civilization), Civilization, string.Empty);
                }
            }
            set
            {
                switch (value.ToLower())
                {
                    case "greek":
                        Civilization = CivilizationEnum.Greek;
                        break;
                    case "egyptian":
                        Civilization = CivilizationEnum.Egypt;
                        break;
                    case "persian":
                        Civilization = CivilizationEnum.Persia;
                        break;
                    case "celtic":
                        Civilization = CivilizationEnum.Celt;
                        break;
                    case "babylonian":
                        Civilization = CivilizationEnum.Babylonian;
                        break;
                    case "norse":
                        Civilization = CivilizationEnum.Norse;
                        break;
                    case "roman":
                        Civilization = CivilizationEnum.Roman;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, string.Empty);
                }
            }
        }

        [Required]
        [JsonProperty(PropertyName = "civ", Required = Required.Always)]
        [XmlIgnore]
        public CivilizationEnum Civilization { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "maxrank", Required = Required.Always)]
        [XmlElement(ElementName = "maxrank")]
        public int MaxRank { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [Required]
        [JsonProperty(PropertyName = "largeicon", Required = Required.Always)]
        [XmlElement(ElementName = "largeicon")]
        public bool LargeIcon { get; set; }

        [Required]
        [JsonProperty(PropertyName = "bldorunit", Required = Required.Always)]
        [XmlElement(ElementName = "bldorunit")]
        public bool BldOrUnit { get; set; }

        [Required]
        [JsonProperty(PropertyName = "questreward", Required = Required.Always)]
        [XmlElement(ElementName = "questreward")]
        public bool QuestReward { get; set; }

        [Required]
        [JsonProperty(PropertyName = "suppresseffects", Required = Required.Always)]
        [XmlElement(ElementName = "suppresseffects")]
        public bool SuppressEffects { get; set; }

        [Required]
        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplaynameId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "uipanel", Required = Required.Always)]
        [XmlElement(ElementName = "uipanel")]
        public string UiPanel { get; set; }

        [Required]
        [JsonProperty(PropertyName = "uirow", Required = Required.Always)]
        [XmlElement(ElementName = "uirow")]
        public double Uirow { get; set; }

        [Required]
        [JsonProperty(PropertyName = "uicol", Required = Required.Always)]
        [XmlElement(ElementName = "uicol")]
        public double UiCol { get; set; }

        [Required]
        [Range(1, 4)]
        [JsonProperty(PropertyName = "agerequirement", Required = Required.Always)]
        [XmlElement(ElementName = "agerequirement")]
        public int AgeRequirement { get; set; }

        [Required]
        [JsonProperty(PropertyName = "grantedatlevel", Required = Required.Always)]
        [XmlElement(ElementName = "grantedatlevel")]
        public bool GrantedAtLevel { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "grantinglevel", Required = Required.Always)]
        [XmlElement(ElementName = "grantinglevel")]
        public int GrantingLevel { get; set; }

        [Required]
        [JsonProperty(PropertyName = "reward", Required = Required.Always)]
        [XmlElement(ElementName = "ranks")]
        public EquipmentDataXmlRanks Ranks { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "prereq", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "prereq")]
        public int Prereq { get; set; } = -1;
    }

    [JsonObject(Title = "ranks", Description = "")]
    [XmlRoot(ElementName = "ranks")]
    public class EquipmentDataXmlRanks
    {
        public EquipmentDataXmlRanks()
        {
            Rank = new Dictionary<int, EquipmentDataXmlEqRank>();
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<int, EquipmentDataXmlEqRank> Rank { get; }

        [Required]
        [JsonProperty(PropertyName = "rank", Required = Required.Always)]
        [XmlElement(ElementName = "rank")]
        public EquipmentDataXmlEqRank[] List
        {
            get => Rank.Values.ToArray();
            set
            {
                Rank.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Rank.Add(item.DescId, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Rank '{item.DescId}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "rank", Description = "")]
    [XmlRoot(ElementName = "rank")]
    public class EquipmentDataXmlEqRank
    {
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "tech", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "tech")]
        public string Tech { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "cost", Required = Required.Always)]
        [XmlAttribute(AttributeName = "cost")]
        public int Cost { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "descid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "descid")]
        public int DescId { get; set; }
    }

    [JsonObject(Title = "equipmentdata", Description = "")]
    [XmlRoot(ElementName = "equipmentdata")]
    public class EquipmentDataXml
    {
        public EquipmentDataXml()
        {
            Equipments = new Dictionary<int, EquipmentDataXmlEquipment>();
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<int, EquipmentDataXmlEquipment> Equipments { get; }

        [Required]
        [JsonProperty(PropertyName = "equipment", Required = Required.Always)]
        [XmlElement(ElementName = "equipment")]
        public EquipmentDataXmlEquipment[] List
        {
            get => Equipments.Values.ToArray();
            set
            {
                Equipments.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Equipments.Add(item.Id, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Equipment '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static EquipmentDataXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<EquipmentDataXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}