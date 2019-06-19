#region Using directives

using System;
using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ICharacterLevelGameCurrencyEffect : ICharacterLevelGameCurrencyEffectReadOnly
    {
        //void SetEmpirePoints(int ep);
    }

    public interface ICharacterLevelGameCurrencyEffectReadOnly
    {
        int EmpirePoints { get; }
    }

    public interface ICharacterLevelSkillPointsEffect : ICharacterLevelSkillPointsEffectReadOnly
    {
        //void SetSkillPoints(int skillPoints);
    }

    public interface ICharacterLevelSkillPointsEffectReadOnly
    {
        int SkillPoints { get; }
    }

    public interface ICharacterLevelAgeUpEffect : ICharacterLevelAgeUpEffectReadOnly
    {
        //void SetEnableAge(int age);
    }

    public interface ICharacterLevelAgeUpEffectReadOnly
    {
        int EnableAge { get; }
    }

    public interface ICharacterLevelUnlockRegionEffect : ICharacterLevelUnlockRegionEffectReadOnly
    {
        //void SetId(int id);
    }

    public interface ICharacterLevelUnlockRegionEffectReadOnly
    {
        int Id { get; }
    }

    public interface ICharacterLevel : ICharacterLevelReadOnly
    {
        new ICharacterLevelGameCurrencyEffect GameCurrencyEffect { get; }
        new ICharacterLevelSkillPointsEffect SkillPointsEffect { get; }
        new ICharacterLevelAgeUpEffect AgeUpEffect { get; }

        new IEnumerable<ICharacterLevelUnlockRegionEffect> UnlockRegionEffect { get; }

        //void SetLevel(int level);
        void SetXp(int xp);

        void SetGameCurrencyEffect(int empirePoints);
        void RemoveGameCurrencyEffect();
        void SetSkillPointsEffect(int skillPoints);
        void RemoveSkillPointsEffect();
        void SetAgeUpEffect(int age);
        void RemoveAgeUpEffect();
        void AddUnlockRegionEffect(int regionId);
        void RemoveUnlockRegionEffect(int regionId);
        void RemoveAllUnlockRegionEffect();
    }

    public interface ICharacterLevelReadOnly
    {
        int Level { get; }
        int Xp { get; }
        ICharacterLevelGameCurrencyEffectReadOnly GameCurrencyEffect { get; }
        ICharacterLevelSkillPointsEffectReadOnly SkillPointsEffect { get; }
        ICharacterLevelAgeUpEffectReadOnly AgeUpEffect { get; }
        IEnumerable<ICharacterLevelUnlockRegionEffectReadOnly> UnlockRegionEffect { get; }
    }

    public interface ICharacterLevels : IDictionaryContainer<int, ICharacterLevel>, ICharacterLevelsReadOnly
    {
        new ICharacterLevel this[int key] { get; }
        new int Count { get; }
        new bool ContainsKey(int key);
        new ICharacterLevel Get(Func<ICharacterLevel, bool> critera);
        new ICharacterLevel Get(int key);
        new IEnumerable<ICharacterLevel> Gets();
        new IEnumerable<ICharacterLevel> Gets(Func<ICharacterLevel, bool> critera);
        new bool TryGet(int key, out ICharacterLevel value);
        void SetMaxLevel(int maxLevel);
    }

    public interface ICharacterLevelsReadOnly : IReadOnlyContainer<int, ICharacterLevelReadOnly>
    {
        int MaxLevel { get; }
    }

    public interface ICharacterLevelsXml : ICharacterLevels
    {
        void SaveToXmlFile(string file);
    }
}