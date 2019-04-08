#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "gamecurrencyeffect")]
    public class CharacterLevelXmlGameCurrencyEffect
    {
        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "empirepoints")]
        public int EmpirePoints { get; set; }
    }

    [XmlRoot(ElementName = "level")]
    public class CharacterLevelXml
    {
        [Key]
        [Required]
        [Range(0, 99)]
        [XmlIgnore]
        public int Level { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "xp")]
        public int Xp { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "gamecurrencyeffect")]
        public CharacterLevelXmlGameCurrencyEffect GameCurrencyEffect { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "skillpointseffect")]
        public CharacterLevelXmlSkillPointsEffect SkillPointsEffect { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "ageupeffect")]
        public CharacterLevelAgeUpEffect AgeUpEffect { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "unlockregioneffect")]
        public List<CharacterLevelUnlockRegionEffect> UnlockRegionEffect { get; set; }
    }

    [XmlRoot(ElementName = "skillpointseffect")]
    public class CharacterLevelXmlSkillPointsEffect
    {
        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "skillpoints")]
        public int SkillPoints { get; set; }
    }

    [XmlRoot(ElementName = "ageupeffect")]
    public class CharacterLevelAgeUpEffect
    {
        [Required]
        [Range(0, 4)]
        [XmlElement(ElementName = "enableage")]
        public int EnableAge { get; set; }
    }

    [XmlRoot(ElementName = "unlockregioneffect")]
    public class CharacterLevelUnlockRegionEffect
    {
        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }

    [XmlRoot(ElementName = "xplevels")]
    public class CharacterLevelsXml
    {
        [Required]
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<int, CharacterLevelXml> Level { get; } = new Dictionary<int, CharacterLevelXml>();

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "level")]
        public CharacterLevelXml[] LevelArray
        {
            get => Level.Values.ToArray();
            set
            {
                Level.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                for (var index = 0; index < value.Length; index++)
                {
                    var item = value[index];
                    try
                    {
                        item.Level = index;
                        Level.Add(item.Level, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Level}'", e));
                    }
                }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [Required]
        [Range(0, 99)]
        [XmlElement(ElementName = "maxlevel")]
        public int Maxlevel { get; set; }

        public static CharacterLevelsXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<CharacterLevelsXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}