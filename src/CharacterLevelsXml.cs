#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "gamecurrencyeffect", Description = "")]
    [XmlRoot(ElementName = "gamecurrencyeffect")]
    public class CharacterLevelXmlGameCurrencyEffect
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "empirepoints", Required = Required.Always)]
        [XmlElement(ElementName = "empirepoints")]
        public int EmpirePoints { get; set; }
    }

    [JsonObject(Title = "level", Description = "")]
    [XmlRoot(ElementName = "level")]
    public class CharacterLevelXml
    {
        [Key]
        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlIgnore]
        public int Level { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "xp", Required = Required.Always)]
        [XmlElement(ElementName = "xp")]
        public int Xp { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "gamecurrencyeffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "gamecurrencyeffect")]
        public CharacterLevelXmlGameCurrencyEffect GameCurrencyEffect { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "skillpointseffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "skillpointseffect")]
        public CharacterLevelXmlSkillPointsEffect SkillPointsEffect { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "ageupeffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ageupeffect")]
        public CharacterLevelXmlAgeUpEffect AgeUpEffect { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "unlockregioneffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "unlockregioneffect")]
        public HashSet<CharacterLevelXmlUnlockRegionEffect> UnlockRegionEffect { get; set; }
    }

    [JsonObject(Title = "skillpointseffect", Description = "")]
    [XmlRoot(ElementName = "skillpointseffect")]
    public class CharacterLevelXmlSkillPointsEffect
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "skillpoints", Required = Required.Always)]
        [XmlElement(ElementName = "skillpoints")]
        public int SkillPoints { get; set; }
    }

    [JsonObject(Title = "ageupeffect", Description = "")]
    [XmlRoot(ElementName = "ageupeffect")]
    public class CharacterLevelXmlAgeUpEffect
    {
        [Required]
        [Range(0, 4)]
        [JsonProperty(PropertyName = "enableage", Required = Required.Always)]
        [XmlElement(ElementName = "enableage")]
        public int EnableAge { get; set; }
    }

    [JsonObject(Title = "unlockregioneffect", Description = "")]
    [XmlRoot(ElementName = "unlockregioneffect")]
    public class CharacterLevelXmlUnlockRegionEffect
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }

    [JsonObject(Title = "xplevels", Description = "")]
    [XmlRoot(ElementName = "xplevels")]
    public class CharacterLevelsXml : DictionaryContainer<int, CharacterLevelXml>
    {
        public CharacterLevelsXml() : base(key => key.Level)
        {
        }

        [JsonConstructor]
        public CharacterLevelsXml([JsonProperty(PropertyName = "maxlevel", Required = Required.Always)] int maxLevel,
            [JsonProperty(PropertyName = "level", Required = Required.Always)]
            IEnumerable<CharacterLevelXml> levels) : base(levels, key => key.Level)
        {
            MaxLevel = maxLevel;
        }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "maxlevel", Required = Required.Always)]
        [XmlElement(ElementName = "maxlevel")]
        public int MaxLevel { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlElement(ElementName = "level")]
        public CharacterLevelXml[] Level
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                for (var index = 0; index < value.Length; index++)
                {
                    var item = value[index];
                    try
                    {
                        item.Level = index;
                        if (!Add(item))
                            throw new Exception("Add fail");
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

        public static CharacterLevelsXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<CharacterLevelsXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}