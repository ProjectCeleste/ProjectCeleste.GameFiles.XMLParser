#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [XmlRoot(ElementName = "Decay")]
    public class ProtoAge4XmlUnitDecay
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "delay", Required = Required.Always)]
        [XmlAttribute(AttributeName = "delay")]
        public double Delay { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "duration", Required = Required.Always)]
        [XmlAttribute(AttributeName = "duration")]
        public double Duration { get; set; }
    }

    [XmlRoot(ElementName = "InitialResource")]
    public class ProtoAge4XmlUnitInitialResource
    {
        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "resourcetype", Required = Required.Always)]
        [XmlAttribute(AttributeName = "resourcetype")]
        public ResourceTypeEnum Resourcetype { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlText]
        public double Quantity { get; set; }
    }

    [XmlRoot(ElementName = "MinimapColor")]
    public class ProtoAge4XmlUnitMinimapColor
    {
        [Required]
        [Range(0, 1.0)]
        [JsonProperty(PropertyName = "red", Required = Required.Always)]
        [XmlAttribute(AttributeName = "red")]
        public double Red { get; set; }

        [Required]
        [Range(0, 1.0)]
        [JsonProperty(PropertyName = "blue", Required = Required.Always)]
        [XmlAttribute(AttributeName = "blue")]
        public double Blue { get; set; }

        [Required]
        [Range(0, 1.0)]
        [JsonProperty(PropertyName = "green", Required = Required.Always)]
        [XmlAttribute(AttributeName = "green")]
        public double Green { get; set; }
    }

    [XmlRoot(ElementName = "Event")]
    public class ProtoAge4XmlUnitEvent
    {
        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public EventEnum Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "AnimFile", Required = Required.Always)]
        [XmlElement(ElementName = "AnimFile")]
        public string AnimFile { get; set; }
    }

    [XmlRoot(ElementName = "ProtoAction")]
    public class ProtoAge4XmlUnitProtoAction
    {
        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "Name", Required = Required.Always)]
        [XmlElement(ElementName = "Name")]
        public ProtoActionNameEnum Name { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "Damage", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Damage")]
        public double Damage { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "ROF", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ROF")]
        public double Rof { get; set; }

        [DefaultValue(DamageTypeEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "DamageType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DamageType")]
        public DamageTypeEnum DamageType { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "MaxRange", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MaxRange")]
        public List<double> MaxRange { get; set; }

        [DefaultValue(ProjectileTypeEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "Projectile", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Projectile")]
        public ProjectileTypeEnum Projectile { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "MaxHeight", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MaxHeight")]
        public double MaxHeight { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "ImpactEffect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ImpactEffect")]
        public List<string> ImpactEffect { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Rate")]
        public List<ProtoAge4XmlUnitRate> Rate { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Type")]
        public List<ProtoActionTypeEnum> Type { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "DamageBonus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DamageBonus")]
        public List<ProtoAge4XmlUnitDamageBonus> DamageBonus { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "MinRange", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MinRange")]
        public double MinRange { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DamageArea", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DamageArea")]
        public double DamageArea { get; set; }

        [DefaultValue(DamageFlagTypeEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "DamageFlags", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DamageFlags")]
        public DamageFlagTypeEnum DamageFlags { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Accuracy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Accuracy")]
        public List<double> Accuracy { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "TrackRating", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "TrackRating")]
        public double TrackRating { get; set; }

        [DefaultValue(-1)]
        [Range(-1, 1)]
        [JsonProperty(PropertyName = "Active", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Active")]
        public int Active { get; set; } = -1;

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DamageCap", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DamageCap")]
        public double DamageCap { get; set; }

        [DefaultValue(0)]
        [Range(0, 1)]
        [JsonProperty(PropertyName = "HandLogic", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "HandLogic")]
        public int HandLogic { get; set; }

        [DefaultValue(0)]
        [Range(0, 1)]
        [JsonProperty(PropertyName = "Poison", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Poison")]
        public int Poison { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DamageOverTimeDuration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DamageOverTimeDuration")]
        public double DamageOverTimeDuration { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DamageOverTimeRate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DamageOverTimeRate")]
        public double DamageOverTimeRate { get; set; }
    }

    [XmlRoot(ElementName = "Armor")]
    public class ProtoAge4XmlUnitArmor
    {
        public ProtoAge4XmlUnitArmor()
        {
        }

        [JsonConstructor]
        public ProtoAge4XmlUnitArmor(
            [JsonConverter(typeof(StringEnumConverter))]
            [JsonProperty(PropertyName = "type", Required = Required.Always)] DamageTypeEnum type,
            [JsonProperty(PropertyName = "value", Required = Required.Always)] double value)
        {
            Type = type != DamageTypeEnum.None
                ? type
                : throw new ArgumentOutOfRangeException(nameof(type), type, null);
            Value = value;
        }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public DamageTypeEnum Type { get; set; }

        [Required]
        [Range(double.MinValue, double.MaxValue)]
        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
    }

    [XmlRoot(ElementName = "Cost")]
    public class ProtoAge4XmlUnitCost
    {
        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "resourcetype", Required = Required.Always)]
        [XmlAttribute(AttributeName = "resourcetype")]
        public ResourceTypeEnum ResourceType { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlText]
        public double Quantity { get; set; }
    }

    [XmlRoot(ElementName = "CarryCapacity")]
    public class ProtoAge4XmlUnitCarryCapacity
    {
        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "resourcetype", Required = Required.Always)]
        [XmlAttribute(AttributeName = "resourcetype")]
        public ResourceTypeEnum ResourceType { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlText]
        public double Quantity { get; set; }
    }

    [XmlRoot(ElementName = "Command")]
    public class ProtoAge4XmlUnitCommand
    {
        public ProtoAge4XmlUnitCommand()
        {
            Column = -1;
            Page = -1;
            Row = -1;
        }

        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlText]
        public UnitCommandEnum Name { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "row", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "row")]
        public int Row { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "page", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "page")]
        public int Page { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "column", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "column")]
        public int Column { get; set; }
    }

    public class ProtoAge4XmlRowPageColumn
    {
        public ProtoAge4XmlRowPageColumn()
        {
            Row = -1;
            Page = -1;
            Column = -1;
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlText]
        public string Name { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "row", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "row")]
        public int Row { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "page", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "page")]
        public int Page { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "column", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "column")]
        public int Column { get; set; }
    }

    [XmlRoot(ElementName = "Rate")]
    public class ProtoAge4XmlUnitRate
    {
        [Key]
        [Required]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        [XmlText]
        public double Amount { get; set; }
    }

    [XmlRoot(ElementName = "DamageBonus")]
    public class ProtoAge4XmlUnitDamageBonus
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        [XmlText]
        public double Amount { get; set; }
    }

    [XmlRoot(ElementName = "HeightBob")]
    public class ProtoAge4XmlUnitHeightBob
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "period", Required = Required.Always)]
        [XmlAttribute(AttributeName = "period")]
        public double Period { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "magnitude", Required = Required.Always)]
        [XmlAttribute(AttributeName = "magnitude")]
        public double Magnitude { get; set; }
    }

    [XmlRoot(ElementName = "Unit")]
    public class ProtoAge4XmlUnit : IProtoAge4Unit
    {
        public ProtoAge4XmlUnit()
        {
            TurnRadius = -1;
            CorpseDecalTime = -1;
            PopulationCount = -1;
            Train = new DictionaryContainer<string, ProtoAge4XmlRowPageColumn>(key => key.Name,
                StringComparer.OrdinalIgnoreCase);
            Tech = new DictionaryContainer<string, ProtoAge4XmlRowPageColumn>(key => key.Name,
                StringComparer.OrdinalIgnoreCase);
            CarryCapacity =
                new DictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCarryCapacity>(key => key.ResourceType);
            Cost = new DictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCost>(key => key.ResourceType);
            Command = new DictionaryContainer<UnitCommandEnum, ProtoAge4XmlUnitCommand>(key => key.Name);
            AllowedAge = -1;
            BuildPoints = -1;
            PopulationCapAddition = -1;
            Event = new DictionaryContainer<EventEnum, ProtoAge4XmlUnitEvent>(key => key.Name);
            Bounty = -1;
            VisualScale = -1;
        }

        public ProtoAge4XmlUnit(string name,
            int id,
            int dbid,
            int displayNameId,
            int editorNameId,
            int rolloverTextId,
            int shortRolloverTextId,
            double obstructionRadiusX,
            double obstructionRadiusZ,
            double maxVelocity,
            double maxRunVelocity,
            string movementType,
            double lifespan,
            double los,
            string soundFile,
            ProtoAge4XmlUnitDecay decay,
            HashSet<UnitFlagEnum> flag,
            string animFile,
            double visualScale,
            HashSet<UnitTypeEnum> unitType,
            ImpactTypeEnum impactType,
            string icon,
            string portraitIcon,
            double initialHitpoints,
            double maxHitpoints,
            double bounty,
            ProtoAge4XmlUnitInitialResource initialResource,
            ResourceSubTypeEnum resourceSubType,
            ProtoAge4XmlUnitMinimapColor minimapColor,
            int gathererLimit,
            double turnRate,
            int wanderDistance,
            string unitAiType,
            DictionaryContainer<EventEnum, ProtoAge4XmlUnitEvent> @event,
            ProtoAge4XmlUnitEvent[] eventArray,
            string formationCategory,
            PhysicsInfoEnum physicsInfo,
            int selectionPriority,
            string initialUnitAiStance,
            string tactics,
            List<ProtoAge4XmlUnitProtoAction> protoAction,
            int populationCapAddition,
            string placementFile,
            double buildPoints,
            double buildingWorkRate,
            int allowedAge,
            int builderLimit,
            List<ProtoAge4XmlUnitArmor> armor,
            HashSet<UnitTypeEnum> contain,
            DictionaryContainer<UnitCommandEnum, ProtoAge4XmlUnitCommand> command,
            ProtoAge4XmlUnitCommand[] commandArray,
            int unitLevel,
            string trait1,
            string trait2,
            string trait3,
            string trait4,
            string trait5,
            string vanTrait1,
            string vanTrait2,
            string vanTrait3,
            DictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCost> cost,
            ProtoAge4XmlUnitCost[] costArray,
            DictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCarryCapacity> carryCapacity,
            ProtoAge4XmlUnitCarryCapacity[] carryCapacityArray,
            double repairPoints,
            DictionaryContainer<string, ProtoAge4XmlRowPageColumn> tech,
            ProtoAge4XmlRowPageColumn[] techArray,
            double idleTimeout,
            string socketUnitType,
            double allowedHeightVariance,
            string minimapIcon,
            string projectileProtoUnit,
            int buildLimit,
            int maxContained,
            string inputContext,
            DictionaryContainer<string, ProtoAge4XmlRowPageColumn> train,
            ProtoAge4XmlRowPageColumn[] trainArray,
            int populationCount,
            double corpseDecalTime,
            double trainPoints,
            double autoAttackRange,
            double turnRadius,
            ProtoAge4XmlUnitHeightBob heightBob,
            string designTag,
            string deathMessage)
        {
            Name = name;
            Id = id;
            Dbid = dbid;
            DisplayNameId = displayNameId;
            EditorNameId = editorNameId;
            RolloverTextId = rolloverTextId;
            ShortRolloverTextId = shortRolloverTextId;
            ObstructionRadiusX = obstructionRadiusX;
            ObstructionRadiusZ = obstructionRadiusZ;
            MaxVelocity = maxVelocity;
            MaxRunVelocity = maxRunVelocity;
            MovementType = movementType;
            Lifespan = lifespan;
            Los = los;
            SoundFile = soundFile;
            Decay = decay;
            Flag = flag;
            AnimFile = animFile;
            VisualScale = visualScale;
            UnitType = unitType;
            ImpactType = impactType;
            Icon = icon;
            PortraitIcon = portraitIcon;
            InitialHitpoints = initialHitpoints;
            MaxHitpoints = maxHitpoints;
            Bounty = bounty;
            InitialResource = initialResource;
            ResourceSubType = resourceSubType;
            MinimapColor = minimapColor;
            GathererLimit = gathererLimit;
            TurnRate = turnRate;
            WanderDistance = wanderDistance;
            UnitAiType = unitAiType;
            Event = @event;
            EventArray = eventArray;
            FormationCategory = formationCategory;
            PhysicsInfo = physicsInfo;
            SelectionPriority = selectionPriority;
            InitialUnitAiStance = initialUnitAiStance;
            Tactics = tactics;
            ProtoAction = protoAction;
            PopulationCapAddition = populationCapAddition;
            PlacementFile = placementFile;
            BuildPoints = buildPoints;
            BuildingWorkRate = buildingWorkRate;
            AllowedAge = allowedAge;
            BuilderLimit = builderLimit;
            Armor = armor;
            Contain = contain;
            Command = command;
            CommandArray = commandArray;
            UnitLevel = unitLevel;
            Trait1 = trait1;
            Trait2 = trait2;
            Trait3 = trait3;
            Trait4 = trait4;
            Trait5 = trait5;
            VanTrait1 = vanTrait1;
            VanTrait2 = vanTrait2;
            VanTrait3 = vanTrait3;
            Cost = cost;
            CostArray = costArray;
            CarryCapacity = carryCapacity;
            CarryCapacityArray = carryCapacityArray;
            RepairPoints = repairPoints;
            Tech = tech;
            TechArray = techArray;
            IdleTimeout = idleTimeout;
            SocketUnitType = socketUnitType;
            AllowedHeightVariance = allowedHeightVariance;
            MinimapIcon = minimapIcon;
            ProjectileProtoUnit = projectileProtoUnit;
            BuildLimit = buildLimit;
            MaxContained = maxContained;
            InputContext = inputContext;
            Train = train;
            TrainArray = trainArray;
            PopulationCount = populationCount;
            CorpseDecalTime = corpseDecalTime;
            TrainPoints = trainPoints;
            AutoAttackRange = autoAttackRange;
            TurnRadius = turnRadius;
            HeightBob = heightBob;
            DesignTag = designTag;
            DeathMessage = deathMessage;
        }

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<EventEnum, ProtoAge4XmlUnitEvent> Event { get; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "WanderDistance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "WanderDistance")]
        public int WanderDistance { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "UnitAIType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "UnitAIType")]
        public string UnitAiType { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Event", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Event")]
        public ProtoAge4XmlUnitEvent[] EventArray
        {
            get => Event.Count > 0 ? Event.Gets().ToArray() : null;
            set
            {
                Event.Clear();

                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Event.Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<UnitCommandEnum, ProtoAge4XmlUnitCommand> Command { get; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Armor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Armor")]
        public List<ProtoAge4XmlUnitArmor> Armor { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Contain", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Contain")]
        public HashSet<UnitTypeEnum> Contain { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Command", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Command")]
        public ProtoAge4XmlUnitCommand[] CommandArray
        {
            get => Command.Count > 0 ? Command.Gets().ToArray() : null;
            set
            {
                Command.Clear();

                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Command.Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCost> Cost { get; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "VanTrait2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "VanTrait2")]
        public string VanTrait2 { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "VanTrait3", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "VanTrait3")]
        public string VanTrait3 { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Cost", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Cost")]
        public ProtoAge4XmlUnitCost[] CostArray
        {
            get => Cost.Count > 0 ? Cost.Gets().ToArray() : null;
            set
            {
                Cost.Clear();

                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Cost.Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.ResourceType}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCarryCapacity> CarryCapacity { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "CarryCapacity", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "CarryCapacity")]
        public ProtoAge4XmlUnitCarryCapacity[] CarryCapacityArray
        {
            get => CarryCapacity.Count > 0 ? CarryCapacity.Gets().ToArray() : null;
            set
            {
                CarryCapacity.Clear();

                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        CarryCapacity.Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.ResourceType}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<string, ProtoAge4XmlRowPageColumn> Tech { get; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "RepairPoints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "RepairPoints")]
        public double RepairPoints { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Tech", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Tech")]
        public ProtoAge4XmlRowPageColumn[] TechArray
        {
            get => Tech.Count > 0 ? Tech.Gets().ToArray() : null;
            set
            {
                Tech.Clear();

                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Tech.Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<string, ProtoAge4XmlRowPageColumn> Train { get; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "MaxContained", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MaxContained")]
        public int MaxContained { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "InputContext", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "InputContext")]
        public string InputContext { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Train", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Train")]
        public ProtoAge4XmlRowPageColumn[] TrainArray
        {
            get => Train.Count > 0 ? Train.Gets().ToArray() : null;
            set
            {
                Train.Clear();

                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Train.Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DBID", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DBID")]
        public int Dbid { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DisplayNameID", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DisplayNameID")]
        public int DisplayNameId { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "EditorNameID", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "EditorNameID")]
        public int EditorNameId { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "RolloverTextID", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "RolloverTextID")]
        public int RolloverTextId { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "ShortRolloverTextID", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ShortRolloverTextID")]
        public int ShortRolloverTextId { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "ObstructionRadiusX", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ObstructionRadiusX")]
        public double ObstructionRadiusX { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "ObstructionRadiusZ", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ObstructionRadiusZ")]
        public double ObstructionRadiusZ { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "MaxVelocity", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MaxVelocity")]
        public double MaxVelocity { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "MaxRunVelocity", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MaxRunVelocity")]
        public double MaxRunVelocity { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "MovementType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MovementType")]
        public string MovementType { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "Lifespan", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Lifespan")]
        public double Lifespan { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "LOS", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "LOS")]
        public double Los { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "SoundFile", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "SoundFile")]
        public string SoundFile { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Decay", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Decay")]
        public ProtoAge4XmlUnitDecay Decay { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Flag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Flag")]
        public HashSet<UnitFlagEnum> Flag { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "AnimFile", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "AnimFile")]
        public string AnimFile { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "VisualScale", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "VisualScale")]
        public double VisualScale { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "UnitType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "UnitType")]
        public HashSet<UnitTypeEnum> UnitType { get; set; }

        [DefaultValue(ImpactTypeEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "ImpactType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ImpactType")]
        public ImpactTypeEnum ImpactType { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Icon", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Icon")]
        public string Icon { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "PortraitIcon", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "PortraitIcon")]
        public string PortraitIcon { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "InitialHitpoints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "InitialHitpoints")]
        public double InitialHitpoints { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "MaxHitpoints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MaxHitpoints")]
        public double MaxHitpoints { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "Bounty", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Bounty")]
        public double Bounty { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "InitialResource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "InitialResource")]
        public ProtoAge4XmlUnitInitialResource InitialResource { get; set; }

        [DefaultValue(ResourceSubTypeEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "ResourceSubType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ResourceSubType")]
        public ResourceSubTypeEnum ResourceSubType { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "MinimapColor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MinimapColor")]
        public ProtoAge4XmlUnitMinimapColor MinimapColor { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "GathererLimit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "GathererLimit")]
        public int GathererLimit { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "TurnRate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "TurnRate")]
        public double TurnRate { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "FormationCategory", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "FormationCategory")]
        public string FormationCategory { get; set; }

        [DefaultValue(PhysicsInfoEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "PhysicsInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "PhysicsInfo")]
        public PhysicsInfoEnum PhysicsInfo { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "SelectionPriority", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "SelectionPriority")]
        public int SelectionPriority { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "InitialUnitAIStance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "InitialUnitAIStance")]
        public string InitialUnitAiStance { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Tactics", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Tactics")]
        public string Tactics { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "ProtoAction", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ProtoAction")]
        public List<ProtoAge4XmlUnitProtoAction> ProtoAction { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "PopulationCapAddition", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "PopulationCapAddition")]
        public int PopulationCapAddition { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "PlacementFile", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "PlacementFile")]
        public string PlacementFile { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "BuildPoints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "BuildPoints")]
        public double BuildPoints { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "BuildingWorkRate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "BuildingWorkRate")]
        public double BuildingWorkRate { get; set; }

        [DefaultValue(-1)]
        [Range(-1, 3)]
        [JsonProperty(PropertyName = "AllowedAge", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "AllowedAge")]
        public int AllowedAge { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "BuilderLimit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "BuilderLimit")]
        public int BuilderLimit { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "UnitLevel", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "UnitLevel")]
        public int UnitLevel { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Trait1", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Trait1")]
        public string Trait1 { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Trait2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Trait2")]
        public string Trait2 { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Trait3", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Trait3")]
        public string Trait3 { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Trait4", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Trait4")]
        public string Trait4 { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "Trait5", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Trait5")]
        public string Trait5 { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "VanTrait1", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "VanTrait1")]
        public string VanTrait1 { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "IdleTimeout", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "IdleTimeout")]
        public double IdleTimeout { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "SocketUnitType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "SocketUnitType")]
        public string SocketUnitType { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "AllowedHeightVariance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "AllowedHeightVariance")]
        public double AllowedHeightVariance { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "MinimapIcon", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "MinimapIcon")]
        public string MinimapIcon { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "ProjectileProtoUnit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "ProjectileProtoUnit")]
        public string ProjectileProtoUnit { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "BuildLimit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "BuildLimit")]
        public int BuildLimit { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "PopulationCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "PopulationCount")]
        public int PopulationCount { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "CorpseDecalTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "CorpseDecalTime")]
        public double CorpseDecalTime { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "TrainPoints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "TrainPoints")]
        public double TrainPoints { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "AutoAttackRange", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "AutoAttackRange")]
        public double AutoAttackRange { get; set; }

        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "TurnRadius", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "TurnRadius")]
        public double TurnRadius { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "HeightBob", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "HeightBob")]
        public ProtoAge4XmlUnitHeightBob HeightBob { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "DesignTag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DesignTag")]
        public string DesignTag { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "DeathMessage", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "DeathMessage")]
        public string DeathMessage { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<string, ProtoAge4XmlRowPageColumn> IProtoAge4Unit.Tech => Tech;

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<string, ProtoAge4XmlRowPageColumn> IProtoAge4Unit.Train => Train;

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCarryCapacity> IProtoAge4Unit.CarryCapacity =>
            CarryCapacity;

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<UnitCommandEnum, ProtoAge4XmlUnitCommand> IProtoAge4Unit.Command => Command;

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<ResourceTypeEnum, ProtoAge4XmlUnitCost> IProtoAge4Unit.Cost => Cost;

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<EventEnum, ProtoAge4XmlUnitEvent> IProtoAge4Unit.Event => Event;
    }

    [XmlRoot(ElementName = "Proto")]
    public class ProtoAge4Xml : DictionaryContainer<string, ProtoAge4XmlUnit, IProtoAge4Unit>,
        IProtoAge4Xml
    {
        public ProtoAge4Xml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public ProtoAge4Xml([JsonProperty(PropertyName = "version", Required = Required.Always, Order = 1)] int version,
            [JsonProperty(PropertyName = "Unit", Required = Required.Always)] IEnumerable<ProtoAge4XmlUnit> power) :
            base(power, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
            Version = version >= 0 ? version : throw new ArgumentOutOfRangeException(nameof(version), version, null);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "Unit", Required = Required.Always, Order = 2)]
        [XmlElement(ElementName = "Unit")]
        public ProtoAge4XmlUnit[] UnitArray
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "version", Required = Required.Always, Order = 1)]
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public bool TryGet(string key, out IProtoAge4Unit value)
        {
            if (!TryGet(key, out ProtoAge4XmlUnit item))
            {
                value = null;
                return false;
            }
            value = item;
            return true;
        }

        public void SetVersion(int version)
        {
            Version = version >= 0 ? version : throw new ArgumentOutOfRangeException(nameof(version), version, null);
        }

        public static IProtoAge4Xml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<ProtoAge4Xml>(file);
        }
    }
}