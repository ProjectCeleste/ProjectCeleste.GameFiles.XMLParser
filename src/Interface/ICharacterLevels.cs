#region Using directives

using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ICharacterLevelGameCurrencyEffect
    {
        int EmpirePoints { get; }
        //void SetEmpirePoints(int ep);
    }

    public interface ICharacterLevelSkillPointsEffect
    {
        int SkillPoints { get; }
        //void SetSkillPoints(int skillPoints);
    }

    public interface ICharacterLevelAgeUpEffect
    {
        int EnableAge { get; }
        //void SetEnableAge(int age);
    }

    public interface ICharacterLevelUnlockRegionEffect
    {
        int Id { get; }
        //void SetId(int id);
    }

    public interface ICharacterLevel
    {
        int Level { get; }
        int Xp { get; }
        ICharacterLevelGameCurrencyEffect GameCurrencyEffect { get; }
        ICharacterLevelSkillPointsEffect SkillPointsEffect { get; }
        ICharacterLevelAgeUpEffect AgeUpEffect { get; }
        IEnumerable<ICharacterLevelUnlockRegionEffect> UnlockRegionEffect { get; }

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

    public interface ICharacterLevels : IDictionaryContainer<int, ICharacterLevel>
    {
        int MaxLevel { get; }
        void SetMaxLevel(int maxLevel);
    }

    public interface ICharacterLevelsXml : ICharacterLevels
    {
        void SaveToXmlFile(string file);
    }
}