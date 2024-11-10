#region Using directives

using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IProtoAge4Unit
    {
        int AllowedAge { get; }
        double AllowedHeightVariance { get; }
        string AnimFile { get; }
        List<ProtoAge4XmlUnitArmor> Armor { get; }
        double AutoAttackRange { get; }
        double Bounty { get; }
        int BuilderLimit { get; }
        double BuildingWorkRate { get; }
        int BuildLimit { get; }
        double BuildPoints { get; }
        IDictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCarryCapacity> CarryCapacity { get; }
        IDictionaryContainer<UnitCommandEnum, ProtoAge4XmlUnitCommand> Command { get; }
        HashSet<UnitTypeEnum> Contain { get; }
        double CorpseDecalTime { get; }
        IDictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCost> Cost { get; }
        int Dbid { get; }
        string DeathMessage { get; }
        ProtoAge4XmlUnitDecay Decay { get; }
        string DesignTag { get; }
        int DisplayNameId { get; }
        int EditorNameId { get; }
        IDictionaryContainer<EventEnum, ProtoAge4XmlUnitEvent> Event { get; }
        HashSet<UnitFlagEnum> Flag { get; }
        string FormationCategory { get; }
        int GathererLimit { get; }
        ProtoAge4XmlUnitHeightBob HeightBob { get; }
        string Icon { get; }
        int Id { get; }
        double IdleTimeout { get; }
        ImpactTypeEnum ImpactType { get; }
        double InitialHitpoints { get; }
        ProtoAge4XmlUnitInitialResource InitialResource { get; }
        string InitialUnitAiStance { get; }
        string InputContext { get; }
        double Lifespan { get; }
        double Los { get; }
        int MaxContained { get; }
        double MaxHitpoints { get; }
        double MaxRunVelocity { get; }
        double MaxVelocity { get; }
        ProtoAge4XmlUnitMinimapColor MinimapColor { get; }
        string MinimapIcon { get; }
        string MovementType { get; }
        string Name { get; }
        double ObstructionRadiusX { get; }
        double ObstructionRadiusZ { get; }
        PhysicsInfoEnum PhysicsInfo { get; }
        string PlacementFile { get; }
        int PopulationCapAddition { get; }
        int PopulationCount { get; }
        string PortraitIcon { get; }
        string ProjectileProtoUnit { get; }
        List<ProtoAge4XmlUnitProtoAction> ProtoAction { get; }
        double RepairPoints { get; }
        ResourceSubTypeEnum ResourceSubType { get; }
        int RolloverTextId { get; }
        int SelectionPriority { get; }
        int ShortRolloverTextId { get; }
        string SocketUnitType { get; }
        string SoundFile { get; }
        string Tactics { get; }
        IDictionaryContainer<string, ProtoAge4XmlRowPageColumn> Tech { get; }
        IDictionaryContainer<string, ProtoAge4XmlRowPageColumn> Train { get; }
        double TrainPoints { get; }
        double TargetSpeedBoostResist { get; }
        string Trait1 { get; }
        string Trait2 { get; }
        string Trait3 { get; }
        string Trait4 { get; }
        string Trait5 { get; }
        double TurnRadius { get; }
        double TurnRate { get; }
        string UnitAiType { get; }
        int UnitLevel { get; }
        HashSet<UnitTypeEnum> UnitType { get; }
        string VanTrait1 { get; }
        string VanTrait2 { get; }
        string VanTrait3 { get; }
        double VisualScale { get; }
        int WanderDistance { get; }
    }

    public interface IProtoAge4Xml : IProtoAge4
    {
        void SaveToXmlFile(string file);
    }

    public interface IProtoAge4 : IDictionaryContainer<string, IProtoAge4Unit>
    {
        int Version { get; }
        void SetVersion(int version);
    }
}