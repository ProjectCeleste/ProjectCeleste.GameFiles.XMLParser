#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "trait")]
    public class AiTraitXml
    {
        [XmlIgnore]
        public bool IsUsed { get; set; }

        /// <summary>
        ///     Use IsUsed Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [XmlAttribute(AttributeName = "used")]
        public string UsedStrDoNotUse
        {
            get => IsUsed ? "true" : "false";
            set => IsUsed = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [Required]
        [Range(0, 99)]
        [XmlAttribute(AttributeName = "level")]
        public int Level { get; set; }

        [DefaultValue(0)]
        [Range(-1, int.MaxValue)]
        [XmlAttribute(AttributeName = "seed")]
        public int Seed { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlAttribute(AttributeName = "protounit")]
        public string ProtoUnit { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlText]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "traits")]
    public class AiTraitsXml
    {
        [DefaultValue(null)]
        [XmlElement(ElementName = "trait")]
        public List<AiTraitXml> Trait { get; set; } = new List<AiTraitXml>();
    }

    [XmlRoot(ElementName = "tech")]
    public class AiTechXml
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [XmlText]
        public string TechId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlAttribute(AttributeName = "persistentcitystatus")]
        public string PersistentCityStatus { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
    }

    [XmlRoot(ElementName = "activetechs")]
    public class AiTechsXml
    {
        [XmlIgnore]
        public Dictionary<string, AiTechXml> Tech { get; } =
            new Dictionary<string, AiTechXml>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Tech Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue(null)]
        [XmlElement(ElementName = "tech")]
        public AiTechXml[] TechArrayDoNotUse
        {
            get => Tech.Values.ToArray();
            set
            {
                Tech.Clear();
                if (value == null)
                    return;

                foreach (var item in value)
                    Tech.Add(item.TechId, item);
            }
        }
    }

    [XmlRoot(ElementName = "assignedadvisors")]
    public class AiAssignedAdvisorsXml
    {
        [DefaultValue(null)]
        [MaxLength(4)]
        [XmlElement(ElementName = "assignedadvisor")]
        public HashSet<string> AssignedAdvisor { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    }

    [XmlRoot(ElementName = "availableadvisors")]
    public class AiAvailableAdvisorsXml
    {
        [DefaultValue(null)]
        [XmlElement(ElementName = "availableadvisor")]
        public HashSet<string> AvailableAdvisor { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    }

    [XmlRoot(ElementName = "protounits")]
    public class AiProtoUnitsXml
    {
        [DefaultValue(null)]
        [XmlElement(ElementName = "protounit")]
        public HashSet<string> ProtoUnit { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    }

    [XmlRoot(ElementName = "character")]
    public class AiCharacterXml
    {
        [Required]
        [Range(0, int.MaxValue)]
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "FileName")]
        public string FileName { get; set; }

        [Required]
        [XmlElement(ElementName = "CivId")]
        public CivilizationEnum CivId { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [DefaultValue(0)]
        [Range(0, 99)]
        [XmlElement(ElementName = "level")]
        public int Level { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "xp")]
        public int Xp { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "skillpoints")]
        public int SkillPoints { get; set; }

        [Required]
        [Range(0, 4)]
        [XmlElement(ElementName = "currentage")]
        public byte CurrentAge { get; set; }

        [Required]
        [XmlElement(ElementName = "activetechs")]
        public AiTechsXml ActiveTechs { get; set; } = new AiTechsXml();

        [Required]
        [XmlElement(ElementName = "protounits")]
        public AiProtoUnitsXml ProtoUnits { get; set; } = new AiProtoUnitsXml();

        [Required]
        [XmlElement(ElementName = "traits")]
        public AiTraitsXml Traits { get; set; } = new AiTraitsXml();

        [Required]
        [XmlElement(ElementName = "availableadvisors")]
        public AiAvailableAdvisorsXml AvailableAdvisors { get; set; } = new AiAvailableAdvisorsXml();

        [Required]
        [XmlElement(ElementName = "assignedadvisors")]
        public AiAssignedAdvisorsXml AssignedAdvisors { get; set; } = new AiAssignedAdvisorsXml();

        [Required]
        [XmlElement(ElementName = "unlockedregions")]
        public string UnlockedRegion { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "currentregion")]
        public int CurrentRegion { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "nextscenarioid")]
        public int NextScenarioId { get; set; }

        public static AiCharacterXml FromFile(string file, string baseFolder)
        {
            var aiCharacter = XmlUtils.FromXmlFile<AiCharacterXml>(file);

            if (!baseFolder.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase))
                baseFolder += Path.DirectorySeparatorChar;

            aiCharacter.FileName = file.ToLower().Replace(baseFolder.ToLower(), string.Empty)
                .Replace(".character", string.Empty);

            return aiCharacter;
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }

    public class AiCharactersXml
    {
        [XmlIgnore]
        public Dictionary<string, AiCharacterXml> AiCharacter { get; } =
            new Dictionary<string, AiCharacterXml>(StringComparer.OrdinalIgnoreCase);

        public static AiCharactersXml AiCharacterFromFolder(string folder)
        {
            var aiCharacters = new AiCharactersXml();
            foreach (var file in Directory.GetFiles(folder, "*.character", SearchOption.AllDirectories))
            {
                var newClass = AiCharacterXml.FromFile(file, folder);
                if (string.IsNullOrWhiteSpace(newClass.Name))
                    newClass.Name = Path.GetFileNameWithoutExtension(file);

                aiCharacters.AiCharacter.Add(newClass.FileName, newClass);
            }
            return aiCharacters;
        }
    }
}