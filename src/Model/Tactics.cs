using ProjectCeleste.GameFiles.XMLParser.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [XmlRoot(ElementName = "tactics")]
    public class Tactics
    {
        [XmlElement(ElementName = "action")]
        public List<TacticAction> Action { get; set; }

        [XmlElement(ElementName = "tactic")]
        public Tactic Tactic { get; set; }

        [XmlElement(ElementName = "packsandunpacks")]
        public bool PacksAndUnpacks { get; set; }

        public static List<Tactics> FromXmlFiles(string xmlLocation)
        {
            var tactics = new List<Tactics>();
            var tacticFiles = Directory.EnumerateFiles(xmlLocation);

            foreach (var tacticsFile in tacticFiles)
            {
                var tactic = XmlUtils.FromXmlFile<Tactics>(tacticsFile);
                tactics.Add(tactic);
            }

            return tactics;
        }
    }

    [XmlRoot(ElementName = "tactic")]
    public class Tactic
    {
        [XmlElement(ElementName = "speedmodifier")]
        public string SpeedModifier { get; set; }

        [XmlElement(ElementName = "action")]
        public List<TacticAction> Action { get; set; }

        [XmlElement(ElementName = "attacktype")]
        public string AttackType { get; set; }

        [XmlElement(ElementName = "attackresponsetype")]
        public string AttackResponseType { get; set; }

        [XmlElement(ElementName = "runaway")]
        public string RunAway { get; set; }

        [XmlElement(ElementName = "autoretarget")]
        public string AutoRetarget { get; set; }

        [XmlElement(ElementName = "autoattacktype")]
        public string AutoAttackType { get; set; }

        [XmlElement(ElementName = "idleanim")]
        public string IdleAnim { get; set; }

        [XmlElement(ElementName = "moveanim")]
        public string MoveAnim { get; set; }

        [XmlElement(ElementName = "deathanim")]
        public string DeathAnim { get; set; }

        [XmlElement(ElementName = "boredanim")]
        public string BoredAnim { get; set; }

        [XmlElement(ElementName = "walkanim")]
        public string WalkAnim { get; set; }

        [XmlElement(ElementName = "joganim")]
        public string JogAnim { get; set; }

        [XmlElement(ElementName = "exclusive")]
        public string Exclusive { get; set; }

        [XmlElement(ElementName = "checkifcanstealth")]
        public CheckIfCanStealth CheckIfCanStealth { get; set; }

        [XmlElement(ElementName = "modelattachment")]
        public string ModelAttachment { get; set; }

        [XmlElement(ElementName = "modelattachmentbone")]
        public string ModelAttachmentBone { get; set; }

        [XmlElement(ElementName = "transition")]
        public Transition Transition { get; set; }
    }

    [XmlRoot(ElementName = "action")]
    public class TacticAction
    {
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "anim")]
        public string Anim { get; set; }

        [XmlElement(ElementName = "maxrange")]
        public string MaxRange { get; set; }

        [XmlElement(ElementName = "rate")]
        public List<Rate> Rate { get; set; }

        [XmlElement(ElementName = "dropsitegathering")]
        public string DropSiteGathering { get; set; }

        [XmlElement(ElementName = "typedmaxrange")]
        public List<TypedMaxRange> TypedMaxRange { get; set; }

        [XmlElement(ElementName = "name")]
        public Name Name { get; set; }

        [XmlElement(ElementName = "attackaction")]
        public string AttackAction { get; set; }

        [XmlElement(ElementName = "rangedlogic")]
        public string RangedLogic { get; set; }

        [XmlElement(ElementName = "maxheight")]
        public string MaxHeight { get; set; }

        [XmlElement(ElementName = "accuracy")]
        public string Accuracy { get; set; }

        [XmlElement(ElementName = "trackrating")]
        public string TrackRating { get; set; }

        [XmlElement(ElementName = "handlogic")]
        public string HandLogic { get; set; }

        [XmlElement(ElementName = "impacteffect")]
        public string ImpactEffect { get; set; }

        [XmlElement(ElementName = "timer")]
        public string Timer { get; set; }

        [XmlElement(ElementName = "hpboost")]
        public string HpBoost { get; set; }

        [XmlElement(ElementName = "damagebonus")]
        public DamageBonus DamageBonus { get; set; }

        [XmlElement(ElementName = "modelattachment")]
        public string ModelAttachment { get; set; }

        [XmlElement(ElementName = "modelattachmentbone")]
        public string ModelAttachmentBone { get; set; }

        [XmlElement(ElementName = "active")]
        public string Active { get; set; }

        [XmlElement(ElementName = "persistent")]
        public string Persistent { get; set; }

        [XmlAttribute(AttributeName = "priority")]
        public string Priority { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlElement(ElementName = "hitpercent")]
        public string HitPercent { get; set; }

        [XmlElement(ElementName = "hitpercenttype")]
        public string HitPercentType { get; set; }

        [XmlElement(ElementName = "perfectaccuracy")]
        public string PerfectAccuracy { get; set; }

        [XmlElement(ElementName = "activeifcontainsunits")]
        public string ActiveIfContainsUnits { get; set; }

        [XmlElement(ElementName = "damagefactorcap")]
        public string DamageFactorCap { get; set; }

        [XmlElement(ElementName = "scalebycontainedunits")]
        public string ScaleByContainedUnits { get; set; }

        [XmlElement(ElementName = "projectile")]
        public string Projectile { get; set; }

        [XmlElement(ElementName = "hitpercentdamagemultiplier")]
        public string HitPercentDamageMultiplier { get; set; }

        [XmlElement(ElementName = "aoe")]
        public string Aoe { get; set; }

        [XmlElement(ElementName = "aoehealradius")]
        public string AoeHealRadius { get; set; }

        [XmlElement(ElementName = "affectstargetsincombat")]
        public string AffectsTargetsInCombat { get; set; }

        [XmlElement(ElementName = "rof")]
        public string Rof { get; set; }

        [XmlElement(ElementName = "chaos")]
        public string Chaos { get; set; }

        [XmlElement(ElementName = "reloadanim")]
        public string ReloadAnim { get; set; }

        [XmlElement(ElementName = "idleanim")]
        public string IdleAnim { get; set; }

        [XmlElement(ElementName = "targetspeedboost")]
        public string TargetSpeedBoost { get; set; }

        [XmlElement(ElementName = "minrange")]
        public string MinRange { get; set; }

        [XmlElement(ElementName = "damageflags")]
        public List<string> DamageFlags { get; set; }

        [XmlElement(ElementName = "speedboost")]
        public string SpeedBoost { get; set; }

        [XmlElement(ElementName = "singleuse")]
        public string SingleUse { get; set; }

        [XmlElement(ElementName = "maxspread")]
        public string MaxSpread { get; set; }

        [XmlElement(ElementName = "hitpercentanim")]
        public List<HitPercentAnim> HitPercentAnim { get; set; }

        [XmlElement(ElementName = "basedamagecap")]
        public string BaseDamageCap { get; set; }

        [XmlElement(ElementName = "targetground")]
        public string TargetGround { get; set; }

        [XmlElement(ElementName = "instantballistics")]
        public string InstantBallistics { get; set; }

        [XmlElement(ElementName = "selfdestruct")]
        public string SelfDestruct { get; set; }

        [XmlElement(ElementName = "modifytype")]
        public string ModifyType { get; set; }

        [XmlElement(ElementName = "modifymultiplier")]
        public string ModifyMultiplier { get; set; }

        [XmlElement(ElementName = "doesnotneedtofacetarget")]
        public string DoesNotNeedToFaceTarget { get; set; }

        [XmlElement(ElementName = "modifyexclusive")]
        public string ModifyExclusive { get; set; }

        [XmlElement(ElementName = "damageovertimeduration")]
        public string DamageOverTimeDuration { get; set; }

        [XmlElement(ElementName = "damageovertimerate")]
        public string DamageOverTimeRate { get; set; }

        [XmlElement(ElementName = "poison")]
        public string Poison { get; set; }

        [XmlElement(ElementName = "fire")]
        public string Fire { get; set; }

        [XmlElement(ElementName = "ignoreattacks")]
        public string IgnoreAttacks { get; set; }
    }

    [XmlRoot(ElementName = "rate")]
    public class Rate
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "hitpercentanim")]
    public class HitPercentAnim
    {
        [XmlAttribute(AttributeName = "hitpercenttype")]
        public string HitPercentType { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "typedmaxrange")]
    public class TypedMaxRange
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "name")]
    public class Name
    {
        [XmlAttribute(AttributeName = "stringid")]
        public string Stringid { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "damagebonus")]
    public class DamageBonus
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "transition")]
    public class Transition
    {
        [XmlElement(ElementName = "tactic")]
        public string Tactic { get; set; }

        [XmlElement(ElementName = "action")]
        public string Action { get; set; }

        [XmlElement(ElementName = "anim")]
        public string Anim { get; set; }

        [XmlElement(ElementName = "length")]
        public string Length { get; set; }

        [XmlElement(ElementName = "commandautomatic")]
        public string CommandAutomatic { get; set; }

        [XmlElement(ElementName = "exit")]
        public string Exit { get; set; }

        [XmlElement(ElementName = "automatic")]
        public string Automatic { get; set; }
    }


    [XmlRoot(ElementName = "checkifcanstealth")]
    public class CheckIfCanStealth
    {
        [XmlAttribute(AttributeName = "range")]
        public string Range { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
