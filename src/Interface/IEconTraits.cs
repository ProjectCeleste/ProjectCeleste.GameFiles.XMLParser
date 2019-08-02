#region Using directives

using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconTrait
    {
        EAllianceEnum Alliance { get; set; }
        bool CanBeStoredInGearHall { get; set; }
        string CanBeStoredInGearHallStr { get; set; }
        int Dbid { get; set; }
        string DestroyableStr { get; set; }
        int DisplayNameId { get; set; }
        EconTraitXmlEffects Effects { get; set; }
        string EquipSoundSet { get; set; }
        EventEnum Event { get; set; }
        string Icon { get; set; }
        bool IsDestroyable { get; set; }
        bool IsSellable { get; set; }
        bool IsTradeable { get; set; }
        HashSet<int> ItemLevels { get; set; }
        string ItemLevelsStr { get; set; }
        string Name { get; set; }
        EOfferTypeEnum OfferType { get; set; }
        RarityEnum Rarity { get; set; }
        int RollOverTextId { get; set; }
        string SellableStr { get; set; }
        string TradeableStr { get; set; }
        TraitTypeEnum TraitType { get; set; }
        IDictionaryContainer<VisualFactorEnum, EconTraitXmlVisualFactor> VisualFactor { get; }
        EconTraitXmlVisualFactor[] VisualFactorArray { get; set; }
    }

    public interface IEconTraits : IDictionaryContainer<string, IEconTrait>
    {
    }

    public interface IEconTraitsXml : IEconTraits
    {
        void SaveToXmlFile(string file);
    }
}