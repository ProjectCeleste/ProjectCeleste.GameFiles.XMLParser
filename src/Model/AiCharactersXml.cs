#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "trait", Description = "")]
    [XmlRoot(ElementName = "trait")]
    public class AiCharacterXmlTraitsTrait
    {
        [Required]
        [JsonProperty(PropertyName = "used", Required = Required.Always)]
        [XmlAttribute(AttributeName = "used")]
        public bool Used { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlAttribute(AttributeName = "level")]
        public int Level { get; set; }

        [DefaultValue(0)]
        [Range(-1, int.MaxValue)]
        [JsonProperty(PropertyName = "seed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "seed")]
        public int Seed { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "protounit", Required = Required.Always)]
        [XmlAttribute(AttributeName = "protounit")]
        public string ProtoUnit { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlText]
        public string Name { get; set; }
    }

    [JsonObject(Title = "traits", Description = "")]
    [XmlRoot(ElementName = "traits")]
    public class AiCharacterXmlTraits
    {
        [Required]
        [JsonProperty(PropertyName = "trait", Required = Required.Always)]
        [XmlElement(ElementName = "trait")]
        public List<AiCharacterXmlTraitsTrait> Trait { get; set; } = new List<AiCharacterXmlTraitsTrait>();
    }

    [JsonObject(Title = "tech", Description = "")]
    [XmlRoot(ElementName = "tech")]
    public class AiCharacterXmlTechsTech
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "techid", Required = Required.Always)]
        [XmlText]
        public string TechId { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        [XmlAttribute(AttributeName = "status")]
        public TechStatusEnum Status { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "persistentcitystatus", Required = Required.Always)]
        [XmlAttribute(AttributeName = "persistentcitystatus")]
        public TechStatusEnum PersistentCityStatus { get; set; }
    }

    [JsonObject(Title = "activetechs", Description = "")]
    [XmlRoot(ElementName = "activetechs")]
    public class AiCharacterXmlTechs : DictionaryContainer<string, AiCharacterXmlTechsTech>
    {
        public AiCharacterXmlTechs() : base(key => key.TechId, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public AiCharacterXmlTechs(
            [JsonProperty(PropertyName = "tech", Required = Required.Always)]
            IEnumerable<AiCharacterXmlTechsTech> values) : base(values, key => key.TechId,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "tech", Required = Required.Always)]
        [XmlElement(ElementName = "tech")]
        public AiCharacterXmlTechsTech[] TechArrayDoNotUse
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
                        excs.Add(new Exception($"Item '{item.TechId}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "assignedadvisors", Description = "")]
    [XmlRoot(ElementName = "assignedadvisors")]
    public class AiCharacterXmlAssignedAdvisors
    {
        public AiCharacterXmlAssignedAdvisors()
        {
            AssignedAdvisor = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public AiCharacterXmlAssignedAdvisors(
            [JsonProperty(PropertyName = "assignedadvisor", Required = Required.Always)]
            HashSet<string> assignedAdvisor)
        {
            AssignedAdvisor = assignedAdvisor != null
                ? new HashSet<string>(assignedAdvisor, StringComparer.OrdinalIgnoreCase)
                : null;
        }

        [Required]
        [MaxLength(4)]
        [JsonProperty(PropertyName = "assignedadvisor", Required = Required.Always)]
        [XmlElement(ElementName = "assignedadvisor")]
        public HashSet<string> AssignedAdvisor { get; set; }
    }

    [JsonObject(Title = "availableadvisors", Description = "")]
    [XmlRoot(ElementName = "availableadvisors")]
    public class AiCharacterXmlAvailableAdvisors
    {
        public AiCharacterXmlAvailableAdvisors()
        {
            AvailableAdvisor = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public AiCharacterXmlAvailableAdvisors(
            [JsonProperty(PropertyName = "availableadvisor", Required = Required.Always)]
            HashSet<string> availableAdvisor)
        {
            AvailableAdvisor = availableAdvisor != null
                ? new HashSet<string>(availableAdvisor, StringComparer.OrdinalIgnoreCase)
                : null;
        }

        [Required]
        [JsonProperty(PropertyName = "availableadvisor", Required = Required.Always)]
        [XmlElement(ElementName = "availableadvisor")]
        public HashSet<string> AvailableAdvisor { get; set; }
    }

    [JsonObject(Title = "protounits", Description = "")]
    [XmlRoot(ElementName = "protounits")]
    public class AiCharacterXmlProtoUnits
    {
        public AiCharacterXmlProtoUnits()
        {
            ProtoUnit = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public AiCharacterXmlProtoUnits(
            [JsonProperty(PropertyName = "protounit", Required = Required.AllowNull)] HashSet<string> protoUnit)
        {
            ProtoUnit = protoUnit != null ? new HashSet<string>(protoUnit, StringComparer.OrdinalIgnoreCase) : null;
        }

        [Required]
        [JsonProperty(PropertyName = "protounit", Required = Required.AllowNull)]
        [XmlElement(ElementName = "protounit")]
        public HashSet<string> ProtoUnit { get; set; }
    }

    [JsonObject(Title = "character", Description = "")]
    [XmlRoot(ElementName = "character")]
    public class AiCharacterXml : IAiCharacter
    {
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "version", Required = Required.Always)]
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "FileName", Required = Required.Always)]
        [XmlElement(ElementName = "FileName")]
        public string FileName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "CivId", Required = Required.Always)]
        [XmlElement(ElementName = "CivId")]
        public CivilizationEnum CivId { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [Required]
        [Range(0, 99)]
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        [XmlElement(ElementName = "level")]
        public int Level { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "xp", Required = Required.Always)]
        [XmlElement(ElementName = "xp")]
        public int Xp { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "skillpoints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "skillpoints")]
        public int SkillPoints { get; set; }

        [Required]
        [Range(0, 4)]
        [JsonProperty(PropertyName = "currentage", Required = Required.Always)]
        [XmlElement(ElementName = "currentage")]
        public byte CurrentAge { get; set; }

        [Required]
        [JsonProperty(PropertyName = "activetechs", Required = Required.AllowNull)]
        [XmlElement(ElementName = "activetechs")]
        public AiCharacterXmlTechs ActiveTechs { get; set; }

        [Required]
        [JsonProperty(PropertyName = "protounits", Required = Required.AllowNull)]
        [XmlElement(ElementName = "protounits")]
        public AiCharacterXmlProtoUnits ProtoUnits { get; set; }

        [Required]
        [JsonProperty(PropertyName = "traits", Required = Required.AllowNull)]
        [XmlElement(ElementName = "traits")]
        public AiCharacterXmlTraits Traits { get; set; } = new AiCharacterXmlTraits();

        [Required]
        [JsonProperty(PropertyName = "availableadvisors", Required = Required.AllowNull)]
        [XmlElement(ElementName = "availableadvisors")]
        public AiCharacterXmlAvailableAdvisors AvailableAdvisors { get; set; }

        [Required]
        [JsonProperty(PropertyName = "assignedadvisors", Required = Required.AllowNull)]
        [XmlElement(ElementName = "assignedadvisors")]
        public AiCharacterXmlAssignedAdvisors AssignedAdvisors { get; set; }

        [Required(AllowEmptyStrings = true)]
        [JsonProperty(PropertyName = "unlockedregions", Required = Required.Always)]
        [XmlElement(ElementName = "unlockedregions")]
        public string UnlockedRegion { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "currentregion", Required = Required.Always)]
        [XmlElement(ElementName = "currentregion")]
        public int CurrentRegion { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "nextscenarioid", Required = Required.Always)]
        [XmlElement(ElementName = "nextscenarioid")]
        public int NextScenarioId { get; set; }

        public static AiCharacterXml FromXmlFile(string file, string baseFolder)
        {
            var aiCharacter = XmlUtils.FromXmlFile<AiCharacterXml>(file);

            if (!baseFolder.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase))
                baseFolder += Path.DirectorySeparatorChar;

            aiCharacter.FileName = file.ToLower().Replace(baseFolder.ToLower(), string.Empty)
                .Replace(".character", string.Empty);

            if (string.IsNullOrWhiteSpace(aiCharacter.Name))
                aiCharacter.Name = Path.GetFileNameWithoutExtension(file.ToLower());

            return aiCharacter;
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }

    [JsonObject(Title = "characters", Description = "")]
    [XmlRoot(ElementName = "characters")]
    public class AiCharactersXml : DictionaryContainer<string, AiCharacterXml, IAiCharacter>, IAiCharactersXml
    {
        public AiCharactersXml() : base(key => key.FileName, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public AiCharactersXml(
            [JsonProperty(PropertyName = "characters", Required = Required.Always)]
            IEnumerable<AiCharacterXml> values) : base(values, key => key.FileName,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "characters", Required = Required.Always)]
        [XmlElement(ElementName = "characters")]
        public AiCharacterXml[] Characters
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
                        excs.Add(new Exception($"Item '{item.FileName}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public void SaveToXmlFile(string id, string file)
        {
            this[id].SaveToXmlFile(file);
        }

        public static IAiCharactersXml AiCharacterFromFolder(string folder)
        {
            var aiCharacters = new List<AiCharacterXml>();
            var excs = new List<Exception>();
            foreach (var file in Directory.GetFiles(folder, "*.character", SearchOption.AllDirectories))
                try
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    if (!string.IsNullOrWhiteSpace(fileNameWithoutExtension) && string.Equals(fileNameWithoutExtension,
                            "defaultai", StringComparison.OrdinalIgnoreCase))
                        continue;
                    var newClass = AiCharacterXml.FromXmlFile(file, folder);
                    aiCharacters.Add(newClass);
                }
                catch (Exception e)
                {
                    excs.Add(new Exception($"Item '{file}'", e));
                }

            if (excs.Count > 0)
                throw new AggregateException(excs);

            return new AiCharactersXml(aiCharacters);
        }
    }
}