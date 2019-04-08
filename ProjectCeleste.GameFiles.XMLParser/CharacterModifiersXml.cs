#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Enum.CharacterModifier;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "modifiertype", Description = "")]
    [XmlRoot(ElementName = "modifiertype")]
    public class CharacterModifiersXmlModifiertype
    {
        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public CharacterModifierTypeEnum Type { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "tooltipstringid", Required = Required.Always)]
        [XmlElement(ElementName = "tooltipstringid")]
        public int Tooltipstringid { get; set; }
    }

    [JsonObject(Title = "modifiertypedata", Description = "")]
    [XmlRoot(ElementName = "modifiertypedata")]
    public class CharacterModifiersXmlModifiertypedata
    {
        [JsonProperty(PropertyName = "modifiertype", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<CharacterModifierTypeEnum, CharacterModifiersXmlModifiertype> ModifierType { get; } =
            new Dictionary<CharacterModifierTypeEnum, CharacterModifiersXmlModifiertype>();

        /// <summary>
        ///     Use ModifierType Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "modifiertype")]
        public CharacterModifiersXmlModifiertype[] ModifierTypeArrayDoNotUse
        {
            get => ModifierType.Values.ToArray();
            set
            {
                ModifierType.Clear();
                if (value == null)
                    return;
                foreach (var item in value)
                    ModifierType.Add(item.Type, item);
            }
        }
    }

    [JsonObject(Title = "modify", Description = "")]
    [XmlRoot(ElementName = "modify")]
    public class CharacterModifiersXmlModify
    {
        [Key]
        [JsonIgnore]
        [XmlIgnore]
        internal string UnikId => string.IsNullOrWhiteSpace(Category) ? $"{Type}" : $"{Type}-{Category}";

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public CharacterModifierTypeEnum Type { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "relativity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "relativity")]
        public CharacterModifierRelativityEnum Relativity { get; set; }

        [Required]
        [Range(double.MinValue, double.MaxValue)]
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        [XmlAttribute(AttributeName = "amount")]
        public double Amount { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "category", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "category")]
        public string Category { get; set; }

        [DefaultValue("true")]
        [JsonProperty(PropertyName = "visible", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "visible")]
        public string Visible { get; set; }
    }

    [JsonObject(Title = "modifier", Description = "")]
    [XmlRoot(ElementName = "modifier")]
    public class CharacterModifiersXmlModifier
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "category", Required = Required.Always)]
        [XmlElement(ElementName = "category")]
        public CharacterModifierCategoryEnum Category { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "descriptionid", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "descriptionid")]
        public int Descriptionid { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displaynameid", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "displaynameid")]
        public int Displaynameid { get; set; }

        /// <summary>
        ///     Use Duration TimeSpan Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue(null)]
        [JsonIgnore]
        [XmlElement(ElementName = "duration")]
        public string DurationXml
        {
            get => Duration.ToString();
            set => Duration = TimeSpan.Parse(value);
        }


        [DefaultValue(null)]
        [JsonProperty(PropertyName = "duration", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [XmlIgnore]
        public TimeSpan Duration { get; set; }


        [DefaultValue(null)]
        [JsonProperty(PropertyName = "icon", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [DefaultValue(CharacterModifierStackingBehaviorEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "stackingbehavior", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "stackingbehavior")]
        public CharacterModifierStackingBehaviorEnum StackingBehavior { get; set; } =
            CharacterModifierStackingBehaviorEnum.None;

        [JsonProperty(PropertyName = "modify", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, CharacterModifiersXmlModify> Modify { get; } =
            new Dictionary<string, CharacterModifiersXmlModify>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Modify Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "modify")]
        public CharacterModifiersXmlModify[] ModifyArrayDoNotUse
        {
            get => Modify.Values.ToArray();
            set
            {
                Modify.Clear();
                if (value == null)
                    return;
                foreach (var item in value)
                    Modify.Add(item.UnikId, item);
            }
        }
    }

    [JsonObject(Title = "modifiers", Description = "")]
    [XmlRoot(ElementName = "modifiers")]
    public class CharacterModifiersXmlModifiers
    {
        [JsonProperty(PropertyName = "modifier", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, CharacterModifiersXmlModifier> Modifier { get; } =
            new Dictionary<string, CharacterModifiersXmlModifier>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Modify Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "modifier")]
        public CharacterModifiersXmlModifier[] ModifierArrayDoNotUse
        {
            get => Modifier.Values.ToArray();
            set
            {
                Modifier.Clear();
                if (value == null)
                    return;
                foreach (var item in value)
                    Modifier.Add(item.Id, item);
            }
        }
    }

    [JsonObject(Title = "charactermodifiers", Description = "")]
    [XmlRoot(ElementName = "charactermodifiers")]
    public class CharacterModifiersXml
    {
        [Required]
        [JsonProperty(PropertyName = "modifiertypedata", Required = Required.Always)]
        [XmlElement(ElementName = "modifiertypedata")]
        public CharacterModifiersXmlModifiertypedata Modifiertypedata { get; set; } =
            new CharacterModifiersXmlModifiertypedata();

        [Required]
        [JsonProperty(PropertyName = "modifiers", Required = Required.Always)]
        [XmlElement(ElementName = "modifiers")]
        public CharacterModifiersXmlModifiers Modifiers { get; set; } = new CharacterModifiersXmlModifiers();


        public static CharacterModifiersXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<CharacterModifiersXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}