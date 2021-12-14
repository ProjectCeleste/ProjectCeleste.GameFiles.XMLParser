#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "equipment", Description = "")]
    [XmlRoot(ElementName = "equipment")]
    public class EquipmentDataXmlEquipment : IEquipment
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "version", Required = Required.Always)]
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlElement(ElementName = "civ")]
        public string CivilizationStr
        {
            get => $"{Civilization}";
            set => Civilization = (CivilizationEnum) System.Enum.Parse(typeof(CivilizationEnum), value, true);
        }

        [JsonProperty(PropertyName = "civ", Required = Required.Always)]
        [XmlIgnore]
        public CivilizationEnum Civilization { get; set; }

        [JsonProperty(PropertyName = "maxrank", Required = Required.Always)]
        [XmlElement(ElementName = "maxrank")]
        public int MaxRank { get; set; }

        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "largeicon", Required = Required.Always)]
        [XmlElement(ElementName = "largeicon")]
        public bool LargeIcon { get; set; }

        [JsonProperty(PropertyName = "bldorunit", Required = Required.Always)]
        [XmlElement(ElementName = "bldorunit")]
        public bool BldOrUnit { get; set; }

        [JsonProperty(PropertyName = "questreward", Required = Required.Always)]
        [XmlElement(ElementName = "questreward")]
        public bool QuestReward { get; set; }

        [JsonProperty(PropertyName = "suppresseffects", Required = Required.Always)]
        [XmlElement(ElementName = "suppresseffects")]
        public bool SuppressEffects { get; set; }

        [JsonProperty(PropertyName = "displaynameid", Required = Required.Always)]
        [XmlElement(ElementName = "displaynameid")]
        public int DisplaynameId { get; set; }

        [JsonProperty(PropertyName = "uipanel", Required = Required.Always)]
        [XmlElement(ElementName = "uipanel")]
        public string UiPanel { get; set; }

        [JsonProperty(PropertyName = "uirow", Required = Required.Always)]
        [XmlElement(ElementName = "uirow")]
        public double Uirow { get; set; }

        [JsonProperty(PropertyName = "uicol", Required = Required.Always)]
        [XmlElement(ElementName = "uicol")]
        public double UiCol { get; set; }

        [JsonProperty(PropertyName = "agerequirement", Required = Required.Always)]
        [XmlElement(ElementName = "agerequirement")]
        public int AgeRequirement { get; set; }

        [JsonProperty(PropertyName = "grantedatlevel", Required = Required.Always)]
        [XmlElement(ElementName = "grantedatlevel")]
        public bool GrantedAtLevel { get; set; }

        [JsonProperty(PropertyName = "grantinglevel", Required = Required.Always)]
        [XmlElement(ElementName = "grantinglevel")]
        public int GrantingLevel { get; set; }

        [JsonProperty(PropertyName = "reward", Required = Required.Always)]
        [XmlElement(ElementName = "ranks")]
        public EquipmentDataXmlRanks Ranks { get; set; }

        [DefaultValue(-1)]
        [JsonProperty(PropertyName = "prereq", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "prereq")]
        public int Prereq { get; set; } = -1;
    }

    [JsonObject(Title = "ranks", Description = "")]
    [XmlRoot(ElementName = "ranks")]
    public class EquipmentDataXmlRanks : DictionaryContainer<int, EquipmentDataXmlEqRank>
    {
        public EquipmentDataXmlRanks() : base(key => key.DescId)
        {
        }

        [JsonConstructor]
        public EquipmentDataXmlRanks(
            [JsonProperty(PropertyName = "rank", Required = Required.Always)]
            IEnumerable<EquipmentDataXmlEqRank> ranks) : base(ranks, key => key.DescId)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "rank", Required = Required.Always)]
        [XmlElement(ElementName = "rank")]
        public EquipmentDataXmlEqRank[] RankArray
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

        [JsonProperty(PropertyName = "cost", Required = Required.Always)]
        [XmlAttribute(AttributeName = "cost")]
        public int Cost { get; set; }

        [JsonProperty(PropertyName = "descid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "descid")]
        public int DescId { get; set; }
    }

    [JsonObject(Title = "equipmentdata", Description = "")]
    [XmlRoot(ElementName = "equipmentdata")]
    public class EquipmentDataXml : DictionaryContainer<int, EquipmentDataXmlEquipment, IEquipment>, IEquipmentDataXml
    {
        public EquipmentDataXml() : base(key => key.Id)
        {
        }

        [JsonConstructor]
        public EquipmentDataXml(
            [JsonProperty(PropertyName = "equipment", Required = Required.Always)]
            IEnumerable<EquipmentDataXmlEquipment> equipments) : base(equipments, key => key.Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "equipment", Required = Required.Always)]
        [XmlElement(ElementName = "equipment")]
        public EquipmentDataXmlEquipment[] EquipmentArray
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
                        excs.Add(new Exception($"Equipment '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static IEquipmentDataXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<EquipmentDataXml>(file);
        }
    }
}