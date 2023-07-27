using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
{
    public static class EconTraitExt
    {
        public static string GetDisplayNameLocalized(this IEconTrait item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this IEconTrait item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }

        public static string GetDisplayNameLocalized(this EconTraitXmlEffect effect, ILanguages languages,
            string language = "English")
        {
            switch (effect.SubType)
            {
                case EffectSubTypeEnum.ActionEnable:
                    {
                        return languages["stringtablex"][language][42080].Text.Replace("%2s",
                            effect.Action.GetDisplayNameLocalized(languages, language));
                    }
                case EffectSubTypeEnum.AreaDamageReduction:
                    {
                        return
                            $"{languages["stringtablex"][language][58257].Text}:";
                    }
                case EffectSubTypeEnum.Armor:
                    {
                        return languages["stringtablex"][language][49361].Text.Replace(" %s%2.1f", string.Empty)
                            .Replace("%s", effect.DamageType.GetDisplayNameLocalized(languages, language));
                    }
                case EffectSubTypeEnum.BuildingWorkRate:
                    {
                        return languages["stringtablex"][language][55094].Text.Replace(" +%1.1f", string.Empty);
                    }
                case EffectSubTypeEnum.BuildPoints:
                    {
                        return languages["stringtablex"][language][58300].Text;
                    }
                case EffectSubTypeEnum.CarryCapacity:
                    {
                        //return languages["stringtablex"][language][64947].Text + languages["stringtablex"][language][66918].Text;
                        // ReSharper disable once SwitchStatementMissingSomeCases
                        switch (effect.Resource)
                        {
                            //ResourceTypeEnum is taken from Resource.cs
                            //Will this work as it is?
                            case ResourceTypeEnum.Food:
                                return
                                    languages["stringtablex"][language][18900].Text + " " + languages["stringtablex"][language][64947].Text + " " + languages["stringtablex"][language][66918].Text + ":";
                            case ResourceTypeEnum.Gold:
                                return
                                    languages["stringtablex"][language][18129].Text + " " + languages["stringtablex"][language][64947].Text + " " + languages["stringtablex"][language][66918].Text + ":";
                            case ResourceTypeEnum.Stone:
                                return
                                    languages["stringtablex"][language][28529].Text + " " + languages["stringtablex"][language][64947].Text + " " + languages["stringtablex"][language][66918].Text + ":";
                            case ResourceTypeEnum.Wood:
                                return
                                    languages["stringtablex"][language][18899].Text + " " + languages["stringtablex"][language][64947].Text + " " + languages["stringtablex"][language][66918].Text + ":";
                            default:
                                //throw new ArgumentOutOfRangeException(nameof(effect.UnitType), effect.UnitType, null);
                                return languages["stringtablex"][language][64947].Text + " " + languages["stringtablex"][language][66918].Text + ":";
                        }
                    }
                case EffectSubTypeEnum.ConvertResist:
                    {
                        return
                            $"{languages["stringtablex"][language][58299].Text}:";
                    }
                case EffectSubTypeEnum.CostAll:
                    {
                        return languages["stringtablex"][language][34447].Text;
                    }
                case EffectSubTypeEnum.Damage:
                    {
                        return languages["stringtablex"][language][58207].Text.Replace(" %s%.1f", string.Empty);
                    }
                case EffectSubTypeEnum.DamageBonus:
                    {
                        return effect.UnitType != EffectUnitTypeEnum.Invalid
                            ? effect.UnitType.GetDisplayNameLocalized(languages, language) + " " + languages
                                  ["stringtablex"][language][57581].Text
                            : languages["stringtablex"][language][57581].Text;
                    }
                case EffectSubTypeEnum.DamageBonusReduction:
                    {
                        return effect.UnitType != EffectUnitTypeEnum.Invalid
                            ? effect.UnitType.GetDisplayNameLocalized(languages, language) + " " + languages
                                  ["stringtablex"][language][57582].Text
                            : languages["stringtablex"][language][57582].Text;
                    }
                case EffectSubTypeEnum.HitPercent:
                    {
                        switch (effect.Action)
                        {
                            //Should show what unit receives the Critical Chance
                            case EffectActionTypeEnum.MeleeAttack:
                                return
                                    languages["stringtablex"][language][58251].Text + " " + languages["stringtablex"][language][55093].Text.Replace(" +%1.0f", ":");;
                            case EffectActionTypeEnum.RangedAttack:
                                return
                                    languages["stringtablex"][language][58250].Text + " " + languages["stringtablex"][language][55093].Text.Replace(" +%1.0f", ":");;
                            default:
                                return 
                                    languages["stringtablex"][language][55093].Text.Replace(" +%1.0f", ":");;
                        }
                        //return languages["stringtablex"][language][55093].Text.Replace(" +%1.0f", ":");;
                    }
                case EffectSubTypeEnum.Hitpoints:
                    {
                        return languages["stringtablex"][language][57580].Text;
                    }
                case EffectSubTypeEnum.Los:
                    {
                        return languages["stringtablex"][language][58204].Text;
                    }
                case EffectSubTypeEnum.MaximumRange:
                    {
                        switch (effect.Action)
                        {
                            //Should show what type of Max range bonus is applied
                            case EffectActionTypeEnum.RangedAttack:
                                return
                                    languages["stringtablex"][language][58250].Text + " " + languages["stringtablex"][language][58203].Text;
                            case EffectActionTypeEnum.RangedAttack2:
                                return
                                    languages["stringtablex"][language][58250].Text + " " + languages["stringtablex"][language][58203].Text;
                            //This is either burning pitch or is now for Set priest for AOE convert... there is no string showing other
                            case EffectActionTypeEnum.BurningAttack:
                                return
                                    languages["stringtablex"][language][58203].Text;
                            case EffectActionTypeEnum.Convert:
                                return
                                    languages["stringtablex"][language][65459].Text + " " + languages["stringtablex"][language][58203].Text;
                            default:
                                return 
                                    languages["stringtablex"][language][58203].Text;
                        }
                        //return languages["stringtablex"][language][58203].Text;
                    }
                case EffectSubTypeEnum.MaximumVelocity:
                    {
                        return languages["stringtablex"][language][58206].Text;
                    }
                case EffectSubTypeEnum.TargetSpeedBoost:
                    {
                        return languages["stringtablex"][language][57584].Text;
                    }
                case EffectSubTypeEnum.TargetSpeedBoostResist:
                    {
                        return languages["stringtablex"][language][57585].Text;
                    }
                case EffectSubTypeEnum.TrainPoints:
                    {
                        return languages["stringtablex"][language][57583].Text;
                    }
                case EffectSubTypeEnum.ArmorVulnerability:
                    {
                        return languages["stringtablex"][language][300021].Text;
                    }
                case EffectSubTypeEnum.WorkRate:
                    {
                        switch (effect.UnitType)
                        {
                            case EffectUnitTypeEnum.AbstractFruit:
                                return
                                    $"{languages["stringtablex"][language][65866].Text}:";
                            case EffectUnitTypeEnum.AbstractFish:
                                return
                                    $"{languages["stringtablex"][language][65870].Text}:";
                            case EffectUnitTypeEnum.Fish:
                                return
                                    $"{languages["stringtablex"][language][65870].Text}:";
                            case EffectUnitTypeEnum.Gold:
                                return
                                    $"{languages["stringtablex"][language][65872].Text}:";
                            case EffectUnitTypeEnum.Herdable:
                                return
                                    $"{languages["stringtablex"][language][65867].Text}:";
                            case EffectUnitTypeEnum.Huntable:
                                return
                                    $"{languages["stringtablex"][language][65868].Text}:";
                            case EffectUnitTypeEnum.Stone:
                                return
                                    $"{languages["stringtablex"][language][65873].Text}:";
                            case EffectUnitTypeEnum.Tree:
                                return
                                    $"{languages["stringtablex"][language][65871].Text}:";
                            case EffectUnitTypeEnum.Building:
                                return
                                    $"{languages["stringtablex"][language][55353].Text}:";
                            case EffectUnitTypeEnum.LogicalTypeHealed:
                                switch (effect.Action)
                                {
                                    case EffectActionTypeEnum.SelfHeal:
                                        return
                                            $"{languages["stringtablex"][language][300031].Text}:";
                                    default: return
                                        $"{languages["stringtablex"][language][55354].Text}:";
                                }
                            case EffectUnitTypeEnum.AbstractTownCenter:
                                return
                                    languages["stringtablex"][language][55355].Text + " " + languages["stringtablex"][language][54006].Text + ":";
                            case EffectUnitTypeEnum.AbstractDock:
                                return
                                    languages["stringtablex"][language][55355].Text + " " + languages["stringtablex"][language][49782].Text + ":";
                            case EffectUnitTypeEnum.Dropsite:
                                return
                                    languages["stringtablex"][language][56285].Text + " " + languages["stringtablex"][language][56286].Text + ":";
                            case EffectUnitTypeEnum.ActionTrain:
                                return
                                    languages["stringtablex"][language][56285].Text + " " + languages["stringtablex"][language][56288].Text + ":";
                            case EffectUnitTypeEnum.ActionBuild:
                                return
                                    languages["stringtablex"][language][56285].Text + " " + languages["stringtablex"][language][56287].Text + ":";
                            case EffectUnitTypeEnum.ConvertableCavalry:
                                return
                                    languages["stringtablex"][language][38214].Text + " " + languages["stringtablex"][language][65459].Text + ":";
                            case EffectUnitTypeEnum.ConvertableSiege:
                                return
                                    languages["stringtablex"][language][42026].Text + " " + languages["stringtablex"][language][65459].Text + ":";
                            case EffectUnitTypeEnum.ConvertableInfantry:
                                return
                                    languages["stringtablex"][language][42167].Text + " " + languages["stringtablex"][language][65459].Text + ":";
                            default:
                                //Instead of throw excemption, I put a default text.
                                return languages["stringtablex"][language][66811].Text.Replace(" +%1.1f", string.Empty) + ":";
                                //throw new ArgumentOutOfRangeException(nameof(effect.UnitType), effect.UnitType, null);
                        }
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(effect.SubType), effect.SubType, null);
                    }
            }
        }

        public static string GetDisplayNameLocalized(this EffectActionTypeEnum type, ILanguages languages,
            string language = "English")
        {
            switch (type)
            {
                case EffectActionTypeEnum.Invalid:
                    throw new InvalidDataException($"Invalid type '{type}'");
                case EffectActionTypeEnum.Build:
                    return languages["stringtablex"][language][55353].Text;
                case EffectActionTypeEnum.Convert:
                    return languages["stringtablex"][language][57342].Text;
                case EffectActionTypeEnum.Empower:
                    return languages["stringtablex"][language][56285].Text;
                case EffectActionTypeEnum.FishGather:
                    return
                        $"{languages["stringtablex"][language][55352].Text} {languages["stringtablex"][language][22207].Text}";
                case EffectActionTypeEnum.Gather:
                    return languages["stringtablex"][language][55352].Text;
                case EffectActionTypeEnum.Heal:
                    return languages["stringtablex"][language][55354].Text;
                case EffectActionTypeEnum.MeleeAttack:
                    return languages["stringtablex"][language][58251].Text;
                case EffectActionTypeEnum.RangedAttack:
                    return languages["stringtablex"][language][58250].Text;
                case EffectActionTypeEnum.SelfHeal:
                    return languages["stringtablex"][language][57824].Text;
                case EffectActionTypeEnum.Trade:
                    return languages["stringtablex"][language][55355].Text;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string GetDisplayNameLocalized(this EffectUnitTypeEnum type, ILanguages languages,
            string language = "English")
        {
            switch (type)
            {
                case EffectUnitTypeEnum.Invalid:
                    throw new InvalidDataException($"Invalid type '{type}'");
                case EffectUnitTypeEnum.AbstractArcher:
                    return languages["stringtablex"][language][43016].Text;
                case EffectUnitTypeEnum.AbstractCavalry:
                    return languages["stringtablex"][language][38214].Text;
                case EffectUnitTypeEnum.AbstractDock:
                    return languages["stringtablex"][language][49725].Text;
                case EffectUnitTypeEnum.AbstractFarm:
                    return languages["stringtablex"][language][42006].Text;
                case EffectUnitTypeEnum.AbstractFish:
                    return languages["stringtablex"][language][22207].Text;
                case EffectUnitTypeEnum.AbstractFruit:
                    return languages["stringtablex"][language][57826].Text;
                case EffectUnitTypeEnum.AbstractInfantry:
                    return languages["stringtablex"][language][42167].Text;
                case EffectUnitTypeEnum.AbstractTownCenter:
                    return languages["stringtablex"][language][42029].Text;
                case EffectUnitTypeEnum.ActionBuild:
                    return languages["stringtablex"][language][56287].Text;
                case EffectUnitTypeEnum.ActionTrain:
                    return languages["stringtablex"][language][56288].Text;
                case EffectUnitTypeEnum.Building:
                    return languages["stringtablex"][language][57348].Text;
                case EffectUnitTypeEnum.ConvertableCavalry:
                    return languages["stringtablex"][language][38214].Text;
                case EffectUnitTypeEnum.ConvertableInfantry:
                    return languages["stringtablex"][language][42167].Text;
                case EffectUnitTypeEnum.ConvertableSiege:
                    return languages["stringtablex"][language][42026].Text;
                case EffectUnitTypeEnum.Dropsite:
                    return languages["stringtablex"][language][56286].Text;
                case EffectUnitTypeEnum.Fish:
                    return languages["stringtablex"][language][22207].Text;
                case EffectUnitTypeEnum.Gold:
                    return languages["stringtablex"][language][20193].Text;
                case EffectUnitTypeEnum.Herdable:
                    return languages["stringtablex"][language][22205].Text;
                case EffectUnitTypeEnum.Huntable:
                    return languages["stringtablex"][language][22206].Text;
                case EffectUnitTypeEnum.LogicalTypeHealed:
                    return languages["stringtablex"][language][22208].Text;
                case EffectUnitTypeEnum.Ship:
                    return languages["stringtablex"][language][42169].Text;
                case EffectUnitTypeEnum.Stone:
                    return languages["stringtablex"][language][55126].Text;
                case EffectUnitTypeEnum.Tree:
                    return languages["stringtablex"][language][22203].Text;
                case EffectUnitTypeEnum.UnitTypeBldgWatchPost:
                    return languages["stringtablex"][language][55099].Text;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string GetDisplayNameLocalized(this DamageTypeEnum type, ILanguages languages,
            string language = "English")
        {
            switch (type)
            {
                case DamageTypeEnum.None:
                    throw new InvalidDataException($"Invalid type '{type}'");
                case DamageTypeEnum.Hand:
                    return languages["stringtablex"][language][54789].Text;
                case DamageTypeEnum.Ranged:
                    return languages["stringtablex"][language][54790].Text;
                case DamageTypeEnum.Cavalry:
                    return languages["stringtablex"][language][54792].Text;
                case DamageTypeEnum.Siege:
                    return languages["stringtablex"][language][54791].Text;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string GetStatsLocalized(this IEconTrait item, ILanguages languages, int lvl,
            int seed = 0,
            string language = "English")
        {
            var modifiers = item.Effects.GetEffectsModifier(lvl, seed);
            switch (effect.Relativity)
            {
                case RelativityEnum.Absolute:
                    switch (effect.Action)
                    {
                        case EffectActionTypeEnum.SelfHeal:
                            return modifiers.Aggregate(string.Empty,
                                (current, modifier) => current +
                                                    $"{GetDisplayNameLocalized(modifier.Key, languages, language)} {Math.Round((modifier.Value), 2, MidpointRounding.AwayFromZero)}/s\r\n");;
                        default:
                            return modifiers.Aggregate(string.Empty,
                                (current, modifier) => current +
                                                    $"{GetDisplayNameLocalized(modifier.Key, languages, language)} {Math.Round((modifier.Value) * 100, 2, MidpointRounding.AwayFromZero)}%\r\n");;
                    }
                case RelativityEnum.Assign:
                    return modifiers.Aggregate(string.Empty,
                        (current, modifier) => current +
                                            $"{GetDisplayNameLocalized(modifier.Key, languages, language)} {Math.Round((modifier.Value), 2, MidpointRounding.AwayFromZero)}\r\n");;
                default:
                    return modifiers.Aggregate(string.Empty,
                        (current, modifier) => current +
                                            $"{GetDisplayNameLocalized(modifier.Key, languages, language)} {Math.Round((modifier.Value - 1.0) * 100, 2, MidpointRounding.AwayFromZero)}%\r\n");;
            }
        }

        public static IEnumerable<KeyValuePair<EconTraitXmlEffect, double>> GetEffectsModifier(
            this EconTraitXmlEffects effects,
            int lvl, int seed = 0)
        {
            return effects.Effect
                .Select((effect, i) => new KeyValuePair<EconTraitXmlEffect, double>(effect,
                    GetEffectModifier(effect, lvl, i, seed))).ToArray();
        }

        private static double GetEffectModifier(this EconTraitXmlEffect effect, int lvl, int index, int seed = 0)
        {
            var seedoffset = effect.SeedOffset;
            if (seedoffset != 0)
                seedoffset -= 1;
            else
                seedoffset = index;

            var finalSeed = seed > 0 && seedoffset < 4 ? (seed & (255 << (8 * seedoffset))) >> (8 * seedoffset) : 0;

            var result = effect.Scaling * lvl + effect.Amount;
            
            //if (finalSeed <= 0 && (result <= 1 || result > 4))
            if (finalSeed <= 0) {
                switch (effect.Relativity)
                {
                    case RelativityEnum.Absolute:
                        return result + 1;
                    case RelativityEnum.Assign:
                        return result + 1;
                    default:
                        return result;
                }
            }                
/*
            if (finalSeed <= 0)
                return result;
*/
            var modifier = ((int)(finalSeed * 0.078431375) - 10.0) * 0.004999999888241291 + 1.0;
            result = modifier * (result - 1.0) + 1.0;
            if (effect.IsBonus && result < 1)
                result = 1.0 - result + 1.0;

            //Ignore Armor and maybe if regen becomes a stat that 
            /*switch (effect.Relativity)
            {
                case RelativityEnum.Absolute:
                    return result + 1;
                case RelativityEnum.Assign:
                    return result + 1;
                default:
                    return result;
            }*/
            return result;
        }
    }
}