#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "equipment")]
    public class EquipmentDataXmlEquipment
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [XmlElement(ElementName = "civ")]
        public string CivilizationStr
        {
            get
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (Civilization)
                {
                    case CivilizationEnum.Greek:
                        return "greek";
                    case CivilizationEnum.Egypt:
                        return "egyptian";
                    case CivilizationEnum.Celt:
                        return "celt";
                    case CivilizationEnum.Persia:
                        return "persian";
                    case CivilizationEnum.Babylonian:
                        return "babylonian";
                    case CivilizationEnum.Norse:
                        return "norse";
                    case CivilizationEnum.Roman:
                        return "roman";
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

        [XmlIgnore]
        public CivilizationEnum Civilization { get; set; }

        [XmlElement(ElementName = "maxrank")]
        public int Maxrank { get; set; }

        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [XmlElement(ElementName = "largeicon")]
        public string Largeicon { get; set; }

        [XmlElement(ElementName = "bldorunit")]
        public bool BldOrUnit { get; set; }

        [XmlElement(ElementName = "questreward")]
        public bool QuestReward { get; set; }

        [XmlElement(ElementName = "suppresseffects")]
        public string Suppresseffects { get; set; }

        [XmlElement(ElementName = "displaynameid")]
        public string Displaynameid { get; set; }

        [XmlElement(ElementName = "uipanel")]
        public string Uipanel { get; set; }

        [XmlElement(ElementName = "uirow")]
        public double Uirow { get; set; }

        [XmlElement(ElementName = "uicol")]
        public double Uicol { get; set; }

        [XmlElement(ElementName = "agerequirement")]
        public int AgeRequirement { get; set; }

        [XmlElement(ElementName = "grantedatlevel")]
        public bool GrantedAtLevel { get; set; }

        [XmlElement(ElementName = "grantinglevel")]
        public int GrantingLevel { get; set; }

        [XmlElement(ElementName = "ranks")]
        public EquipmentDataXmlRanks Ranks { get; set; }

        [XmlElement(ElementName = "prereq")]
        public int Prereq { get; set; }
    }

    [XmlRoot(ElementName = "ranks")]
    public class EquipmentDataXmlRanks
    {
        [XmlIgnore]
        public Dictionary<int, EquipmentDataXmlEqRank> Rank { get; } = new Dictionary<int, EquipmentDataXmlEqRank>();

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

    [XmlRoot(ElementName = "rank")]
    public class EquipmentDataXmlEqRank
    {
        [XmlAttribute(AttributeName = "tech")]
        public string Tech { get; set; }

        [XmlAttribute(AttributeName = "cost")]
        public int Cost { get; set; }

        [XmlAttribute(AttributeName = "descid")]
        public int DescId { get; set; }
    }

    [XmlRoot(ElementName = "equipmentdata")]
    public class EquipmentDataXml
    {
        [XmlIgnore]
        public Dictionary<int, EquipmentDataXmlEquipment> Equipments { get; } =
            new Dictionary<int, EquipmentDataXmlEquipment>();

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

        public static EquipmentDataXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<EquipmentDataXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}