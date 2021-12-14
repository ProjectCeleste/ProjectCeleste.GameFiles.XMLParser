﻿#region Using directives

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
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "gamecurrencyeffect", Description = "")]
    [XmlRoot(ElementName = "gamecurrencyeffect")]
    public class CharacterLevelXmlGameCurrencyEffect : ICharacterLevelGameCurrencyEffect
    {
        public CharacterLevelXmlGameCurrencyEffect()
        {
        }

        [JsonConstructor]
        public CharacterLevelXmlGameCurrencyEffect(
            [JsonProperty(PropertyName = "empirepoints", Required = Required.Always)] int empirePoints)
        {
            SetEmpirePoints(empirePoints);
        }

        [JsonProperty(PropertyName = "empirepoints", Required = Required.Always)]
        [XmlElement(ElementName = "empirepoints")]
        public int EmpirePoints { get; set; }

        public void SetEmpirePoints(int empirePoints)
        {
            EmpirePoints = empirePoints < 0
                ? throw new ArgumentOutOfRangeException(nameof(empirePoints), empirePoints, null)
                : empirePoints;
        }
    }

    [JsonObject(Title = "skillpointseffect", Description = "")]
    [XmlRoot(ElementName = "skillpointseffect")]
    public class CharacterLevelXmlSkillPointsEffect : ICharacterLevelSkillPointsEffect
    {
        public CharacterLevelXmlSkillPointsEffect()
        {
        }

        [JsonConstructor]
        public CharacterLevelXmlSkillPointsEffect(
            [JsonProperty(PropertyName = "skillpoints", Required = Required.Always)] int skillPoints)
        {
            SetSkillPoints(skillPoints);
        }

        [JsonProperty(PropertyName = "skillpoints", Required = Required.Always)]
        [XmlElement(ElementName = "skillpoints")]
        public int SkillPoints { get; set; }

        public void SetSkillPoints(int skillPoints)
        {
            SkillPoints = skillPoints < 0
                ? throw new ArgumentOutOfRangeException(nameof(skillPoints), skillPoints, null)
                : skillPoints;
        }
    }

    [JsonObject(Title = "ageupeffect", Description = "")]
    [XmlRoot(ElementName = "ageupeffect")]
    public class CharacterLevelXmlAgeUpEffect : ICharacterLevelAgeUpEffect
    {
        public CharacterLevelXmlAgeUpEffect()
        {
        }

        [JsonConstructor]
        public CharacterLevelXmlAgeUpEffect(
            [JsonProperty(PropertyName = "enableage", Required = Required.Always)] int enableAge)
        {
            SetEnableAge(enableAge);
        }

        [JsonProperty(PropertyName = "enableage", Required = Required.Always)]
        [XmlElement(ElementName = "enableage")]
        public int EnableAge { get; set; }

        public void SetEnableAge(int age)
        {
            EnableAge = age < 0 || age > 4 ? throw new ArgumentOutOfRangeException(nameof(age), age, null) : age;
        }
    }

    [JsonObject(Title = "unlockregioneffect", Description = "")]
    [XmlRoot(ElementName = "unlockregioneffect")]
    public class CharacterLevelXmlUnlockRegionEffect : ICharacterLevelUnlockRegionEffect
    {
        public CharacterLevelXmlUnlockRegionEffect()
        {
        }

        [JsonConstructor]
        public CharacterLevelXmlUnlockRegionEffect(
            [JsonProperty(PropertyName = "id", Required = Required.Always)] int id)
        {
            SetId(id);
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        public void SetId(int id)
        {
            Id = id < 0 ? throw new ArgumentOutOfRangeException(nameof(id), id, null) : id;
        }
    }

    [JsonObject(Title = "level", Description = "")]
    [XmlRoot(ElementName = "level")]
    public class CharacterLevelXml : ICharacterLevel
    {
        [XmlIgnore] [JsonIgnore] private CharacterLevelXmlGameCurrencyEffect _gameCurrencyEffect;

        [XmlIgnore] [JsonIgnore] private CharacterLevelXmlSkillPointsEffect _skillPointsEffect;

        [XmlIgnore] [JsonIgnore] private HashSet<CharacterLevelXmlUnlockRegionEffect> _unlockRegionEffect;

        public CharacterLevelXml()
        {
        }

        [JsonConstructor]
        public CharacterLevelXml([JsonProperty(PropertyName = "level", Required = Required.Always)] int level,
            [JsonProperty(PropertyName = "xp", Required = Required.Always)] int xp,
            [JsonProperty(PropertyName = "gamecurrencyeffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
            CharacterLevelXmlGameCurrencyEffect gameCurrencyEffect,
            [JsonProperty(PropertyName = "skillpointseffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
            CharacterLevelXmlSkillPointsEffect skillPointsEffect,
            [JsonProperty(PropertyName = "ageupeffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
            CharacterLevelXmlAgeUpEffect ageUpEffect,
            [JsonProperty(PropertyName = "unlockregioneffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
            HashSet<CharacterLevelXmlUnlockRegionEffect> unlockRegionEffect)
        {
            SetLevel(level);
            SetXp(xp);
            GameCurrencyEffect = gameCurrencyEffect;
            SkillPointsEffect = skillPointsEffect;
            AgeUpEffect = ageUpEffect;
            UnlockRegionEffect = unlockRegionEffect;
        }

        [JsonProperty(PropertyName = "xp", Required = Required.Always)]
        [XmlElement(ElementName = "xp")]
        public int Xp { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "gamecurrencyeffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "gamecurrencyeffect")]
        public CharacterLevelXmlGameCurrencyEffect GameCurrencyEffect
        {
            get => _gameCurrencyEffect?.EmpirePoints > 0 ? _gameCurrencyEffect : null;
            set => _gameCurrencyEffect = value;
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "skillpointseffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "skillpointseffect")]
        public CharacterLevelXmlSkillPointsEffect SkillPointsEffect
        {
            get => _skillPointsEffect?.SkillPoints > 0 ? _skillPointsEffect : null;
            set => _skillPointsEffect = value;
        }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "ageupeffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ageupeffect")]
        public CharacterLevelXmlAgeUpEffect AgeUpEffect { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "unlockregioneffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "unlockregioneffect")]
        public HashSet<CharacterLevelXmlUnlockRegionEffect> UnlockRegionEffect
        {
            get => _unlockRegionEffect?.Count > 0 ? _unlockRegionEffect : null;
            set => _unlockRegionEffect = value;
        }

        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlIgnore]
        public int Level { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        ICharacterLevelGameCurrencyEffect ICharacterLevel.GameCurrencyEffect => GameCurrencyEffect;

        [XmlIgnore]
        [JsonIgnore]
        ICharacterLevelSkillPointsEffect ICharacterLevel.SkillPointsEffect => SkillPointsEffect;

        [XmlIgnore]
        [JsonIgnore]
        ICharacterLevelAgeUpEffect ICharacterLevel.AgeUpEffect => AgeUpEffect;

        [XmlIgnore]
        [JsonIgnore]
        IEnumerable<ICharacterLevelUnlockRegionEffect> ICharacterLevel.UnlockRegionEffect => UnlockRegionEffect;

        public void SetXp(int xp)
        {
            Xp = xp < 0 ? throw new ArgumentOutOfRangeException(nameof(xp), xp, null) : xp;
        }

        public void SetGameCurrencyEffect(int empirePoints)
        {
            GameCurrencyEffect = empirePoints > 0 ? new CharacterLevelXmlGameCurrencyEffect(empirePoints) : null;
        }

        public void RemoveGameCurrencyEffect()
        {
            GameCurrencyEffect = null;
        }

        public void SetSkillPointsEffect(int skillPoints)
        {
            SkillPointsEffect = skillPoints > 0 ? new CharacterLevelXmlSkillPointsEffect(skillPoints) : null;
        }

        public void RemoveSkillPointsEffect()
        {
            SkillPointsEffect = null;
        }

        public void SetAgeUpEffect(int age)
        {
            AgeUpEffect = age > 0 ? new CharacterLevelXmlAgeUpEffect(age) : null;
        }

        public void RemoveAgeUpEffect()
        {
            AgeUpEffect = null;
        }

        public void AddUnlockRegionEffect(int regionId)
        {
            if (UnlockRegionEffect == null)
                UnlockRegionEffect = new HashSet<CharacterLevelXmlUnlockRegionEffect>();
            UnlockRegionEffect.Add(new CharacterLevelXmlUnlockRegionEffect(regionId));
        }

        public void RemoveUnlockRegionEffect(int regionId)
        {
            UnlockRegionEffect?.RemoveWhere(key => key.Id == regionId);
        }

        public void RemoveAllUnlockRegionEffect()
        {
            UnlockRegionEffect = null;
        }

        public void SetLevel(int level)
        {
            Level = level < 0 || level > 99 ? throw new ArgumentOutOfRangeException(nameof(level), level, null) : level;
        }
    }

    [JsonObject(Title = "xplevels", Description = "")]
    [XmlRoot(ElementName = "xplevels")]
    public class CharacterLevelsXml :
        DictionaryContainer<int, CharacterLevelXml, ICharacterLevel>, ICharacterLevelsXml
    {
        public CharacterLevelsXml() : base(key => key.Level)
        {
        }

        [JsonConstructor]
        public CharacterLevelsXml([JsonProperty(PropertyName = "maxlevel", Required = Required.Always)] int maxLevel,
            [JsonProperty(PropertyName = "level", Required = Required.Always)]
            IEnumerable<CharacterLevelXml> levels) : base(levels, key => key.Level)
        {
            SetMaxLevel(maxLevel);
        }

        [JsonProperty(PropertyName = "maxlevel", Required = Required.Always)]
        [XmlElement(ElementName = "maxlevel")]
        public int MaxLevel { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        public void SetMaxLevel(int maxLevel)
        {
            if (!TryGet(maxLevel, out _))
                throw new KeyNotFoundException("Level not found");

            MaxLevel = maxLevel < 0 || maxLevel > 99
                ? throw new ArgumentOutOfRangeException(nameof(maxLevel), maxLevel, null)
                : maxLevel;
        }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static ICharacterLevelsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<CharacterLevelsXml>(file);
        }
    }
}