
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
{
    public static class AiCharacterExt
    {
        public static bool AddOrUpdate(this AiCharacterXmlTechs techs, string techId, TechStatusEnum techStatus)
        {
            if (string.IsNullOrWhiteSpace(techId))
                throw new ArgumentNullException(nameof(techId));

            if (techStatus == TechStatusEnum.Invalid)
                throw new ArgumentNullException(nameof(techStatus));

            var tech = techs.Get(techId);
            if (tech != null)
            {
                tech.Status = techStatus;
                tech.PersistentCityStatus = techStatus;

                return true;
            }

            var newTech = new AiCharacterXmlTechsTech
            {
                TechId = techId,
                Status = techStatus,
                PersistentCityStatus = techStatus
            };

            techs.Add(newTech);

            return true;
        }

        public static void ForceLevelUp(this AiCharacterXml myCharacter, ICharacterLevels characterLevels,
            IEquipmentData equipments, ICivilizations civilizations, int level)
        {
            myCharacter.CurrentAge = 1;

            myCharacter.Level = 1;

            myCharacter.Xp = 0;

            myCharacter.SkillPoints = 0;

            myCharacter.ActiveTechs.Clear();

            if (level > characterLevels.MaxLevel)
                level = characterLevels.MaxLevel;

            if (level < 1)
                level = 1;

            var regions = new HashSet<int> { 0 };

            foreach (var lvl in characterLevels.Gets(key => key.Level <= level)
                .OrderBy(key => key.Level))
            {
                if (lvl.AgeUpEffect?.EnableAge > myCharacter.CurrentAge)
                    myCharacter.CurrentAge = (byte)lvl.AgeUpEffect.EnableAge;

                if (lvl.SkillPointsEffect?.SkillPoints > 0)
                    myCharacter.SkillPoints += lvl.SkillPointsEffect.SkillPoints;

                if (lvl.UnlockRegionEffect != null)
                    foreach (var region in lvl.UnlockRegionEffect)
                        regions.Add(region.Id);

                myCharacter.Xp = lvl.Xp;
            }

            //myCharacter.UnlockedRegion = UnlockedRegions.GetUnlockedRegion(regions);

            foreach (var equipment in equipments.Gets(key => key.Civilization == myCharacter.CivId)
                .OrderBy(key => key.Id))
            {
                var ranks = equipment.Ranks.Gets().ToArray();
                for (var index = 0; index < equipment.MaxRank; index++)
                {
                    var rank = ranks[index];
                    var tech = rank.Tech;

                    if (equipment.GrantedAtLevel && equipment.GrantingLevel <= level ||
                        equipment.QuestReward && equipment.AgeRequirement <= myCharacter.CurrentAge)
                    {
                        var status = !equipment.BldOrUnit ? TechStatusEnum.Obtainable : TechStatusEnum.Active;

                        if (string.IsNullOrWhiteSpace(tech))
                        {
                            var ageTech = civilizations.Get(myCharacter.CivId).Agetech
                                .First(key => key.Tierequipmentid == equipment.Id);

                            if (!equipment.BldOrUnit)
                                status = string.Equals(ageTech.Age, "Age0", StringComparison.OrdinalIgnoreCase)
                                    ? TechStatusEnum.Active
                                    : TechStatusEnum.Obtainable;

                            tech = ageTech.Tech;
                        }

                        myCharacter.ActiveTechs.AddOrUpdate(tech, status);
                    }
                    else
                    {
                        TechStatusEnum status;
                        if (equipment.AgeRequirement <= myCharacter.CurrentAge)
                        {
                            status = !equipment.BldOrUnit ? TechStatusEnum.Obtainable : TechStatusEnum.Active;
                            if (rank.Cost > 0)
                                myCharacter.SkillPoints -= rank.Cost;
                        }
                        else
                        {
                            status = TechStatusEnum.Unobtainable;
                        }

                        myCharacter.ActiveTechs.AddOrUpdate(tech, status);
                    }
                }
            }
        }
    }
}