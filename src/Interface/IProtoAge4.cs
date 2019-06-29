#region Using directives

using System;
using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IProtoAge4Unit : IProtoAge4UnitReadOnly
    {
        new int AllowedAge { get; set; }
        new double AllowedHeightVariance { get; set; }
        new string AnimFile { get; set; }
        new List<ProtoAge4XmlUnitArmor> Armor { get; set; }
        new double AutoAttackRange { get; set; }
        new double Bounty { get; set; }
        new int BuilderLimit { get; set; }
        new double BuildingWorkRate { get; set; }
        new int BuildLimit { get; set; }
        new double BuildPoints { get; set; }
        new IDictionaryContainer<ResourceTypeFixEnum, ProtoAge4XmlUnitCarryCapacity> CarryCapacity { get; }
        new IDictionaryContainer<UnitCommandEnum, ProtoAge4XmlUnitCommand> Command { get; }
        new HashSet<UnitTypeEnum> Contain { get; set; }
        new double CorpseDecalTime { get; set; }
        new IDictionaryContainer<ResourceTypeFixEnum, ProtoAge4XmlUnitCost> Cost { get; }
        new int Dbid { get; set; }
        new string DeathMessage { get; set; }
        new ProtoAge4XmlUnitDecay Decay { get; set; }
        new string DesignTag { get; set; }
        new int DisplayNameId { get; set; }
        new int EditorNameId { get; set; }
        new IDictionaryContainer<EventEnum, ProtoAge4XmlUnitEvent> Event { get; }
        new HashSet<UnitFlagEnum> Flag { get; set; }
        new string FormationCategory { get; set; }
        new int GathererLimit { get; set; }
        new ProtoAge4XmlUnitHeightBob HeightBob { get; set; }
        new string Icon { get; set; }
        new int Id { get; set; }
        new double IdleTimeout { get; set; }
        new ImpactTypeEnum ImpactType { get; set; }
        new double InitialHitpoints { get; set; }
        new ProtoAge4XmlUnitInitialResource InitialResource { get; set; }
        new string InitialUnitAiStance { get; set; }
        new string InputContext { get; set; }
        new double Lifespan { get; set; }
        new double Los { get; set; }
        new int MaxContained { get; set; }
        new double MaxHitpoints { get; set; }
        new double MaxRunVelocity { get; set; }
        new double MaxVelocity { get; set; }
        new ProtoAge4XmlUnitMinimapColor MinimapColor { get; set; }
        new string MinimapIcon { get; set; }
        new string MovementType { get; set; }
        new string Name { get; set; }
        new double ObstructionRadiusX { get; set; }
        new double ObstructionRadiusZ { get; set; }
        new PhysicsInfoEnum PhysicsInfo { get; set; }
        new string PlacementFile { get; set; }
        new int PopulationCapAddition { get; set; }
        new int PopulationCount { get; set; }
        new string PortraitIcon { get; set; }
        new string ProjectileProtoUnit { get; set; }
        new List<ProtoAge4XmlUnitProtoAction> ProtoAction { get; set; }
        new double RepairPoints { get; set; }
        new ResourceSubTypeEnum ResourceSubType { get; set; }
        new int RolloverTextId { get; set; }
        new int SelectionPriority { get; set; }
        new int ShortRolloverTextId { get; set; }
        new string SocketUnitType { get; set; }
        new string SoundFile { get; set; }
        new string Tactics { get; set; }
        new IDictionaryContainer<string, ProtoAge4XmlRowPageColumn> Tech { get; }
        new IDictionaryContainer<string, ProtoAge4XmlRowPageColumn> Train { get; }
        new double TrainPoints { get; set; }
        new string Trait1 { get; set; }
        new string Trait2 { get; set; }
        new string Trait3 { get; set; }
        new string Trait4 { get; set; }
        new string Trait5 { get; set; }
        new double TurnRadius { get; set; }
        new double TurnRate { get; set; }
        new string UnitAiType { get; set; }
        new int UnitLevel { get; set; }
        new HashSet<UnitTypeEnum> UnitType { get; set; }
        new string VanTrait1 { get; set; }
        new string VanTrait2 { get; set; }
        new string VanTrait3 { get; set; }
        new double VisualScale { get; set; }
        new int WanderDistance { get; set; }
    }

    public interface IProtoAge4UnitReadOnly
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
        IReadOnlyContainer<ResourceTypeFixEnum, ProtoAge4XmlUnitCarryCapacity> CarryCapacity { get; }
        IReadOnlyContainer<UnitCommandEnum, ProtoAge4XmlUnitCommand> Command { get; }
        HashSet<UnitTypeEnum> Contain { get; }
        double CorpseDecalTime { get; }
        IReadOnlyContainer<ResourceTypeFixEnum, ProtoAge4XmlUnitCost> Cost { get; }
        int Dbid { get; }
        string DeathMessage { get; }
        ProtoAge4XmlUnitDecay Decay { get; }
        string DesignTag { get; }
        int DisplayNameId { get; }
        int EditorNameId { get; }
        IReadOnlyContainer<EventEnum, ProtoAge4XmlUnitEvent> Event { get; }
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
        IReadOnlyContainer<string, ProtoAge4XmlRowPageColumn> Tech { get; }
        IReadOnlyContainer<string, ProtoAge4XmlRowPageColumn> Train { get; }
        double TrainPoints { get; }
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

    public interface IProtoAge4 : IDictionaryContainer<string, IProtoAge4Unit>, IProtoAge4ReadOnly
    {
        new IProtoAge4Unit this[string key] { get; }
        new int Count { get; }
        new bool ContainsKey(string key);
        new IProtoAge4Unit Get(Func<IProtoAge4Unit, bool> critera);
        new IProtoAge4Unit Get(string key);
        new IEnumerable<IProtoAge4Unit> Gets();
        new IEnumerable<IProtoAge4Unit> Gets(Func<IProtoAge4Unit, bool> critera);
        new bool TryGet(string key, out IProtoAge4Unit value);

        void SetVersion(int version);
    }

    public interface IProtoAge4ReadOnly : IReadOnlyContainer<string, IProtoAge4UnitReadOnly>
    {
        int Version { get; }
    }
}